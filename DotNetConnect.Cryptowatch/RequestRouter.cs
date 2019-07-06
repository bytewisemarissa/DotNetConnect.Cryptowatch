using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DotNetConnect.Cryptowatch.Configuration;
using DotNetConnect.Cryptowatch.DataModel;
using DotNetConnect.Cryptowatch.Exceptions;
using DotNetConnect.Cryptowatch.Metering;
using DotNetConnect.Cryptowatch.Result;
using Newtonsoft.Json;

namespace DotNetConnect.Cryptowatch
{
    public interface IRequestRouter
    {
        IRequestMeteringMonitor RequestMeteringMonitor { get; }
        Task<T> MakeRequest<T>(string relativeUri);
        UriBuilder GetUriBuilder();
    }
    
    public class RequestRouter : IRequestRouter
    {
        private readonly HttpClient _httpClient;
        private readonly IRequestMeteringMonitor Monitor;

        public IRequestMeteringMonitor RequestMeteringMonitor => Monitor;

        public RequestRouter(DNCCryptowatchConfigurationModel configuration, IRequestMeteringMonitor requestMeteringMonitor)
        {
            Monitor = requestMeteringMonitor;

            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.cryptowat.ch/")
            };

            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(configuration.UserAgent, configuration.UserAgentVersion));
        }

        public async Task<T> MakeRequest<T>(string relativeUri)
        {
            var meterResult = Monitor.CheckMeter();

            if (meterResult == MeteringResult.Reject)
            {
                throw new MeteringException();
            }


            var requestSerial = Monitor.GetSerial();

            var response = await _httpClient.GetAsync(relativeUri);

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new ResourceNotFoundException(relativeUri);
                case HttpStatusCode.BadRequest:
                    throw new ImplementationException();
                case HttpStatusCode.InternalServerError:
                    throw new ServerSideException();
            }

            var responseJson = await response.Content.ReadAsStringAsync();

            var parsedResponse = JsonConvert.DeserializeObject<CryptowatchResponse<T>>(responseJson);

            Monitor.RegisterResult(requestSerial, parsedResponse.Allowance);

            T result = parsedResponse.Result;

            return result;
        }

        public UriBuilder GetUriBuilder()
        {
            return new UriBuilder(_httpClient.BaseAddress);
        }
    }
}
