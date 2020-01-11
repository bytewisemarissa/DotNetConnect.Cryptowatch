using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HelpfulThings.Connect.Cryptowatch.DataModel;
using HelpfulThings.Connect.Cryptowatch.Exceptions;
using HelpfulThings.Connect.Cryptowatch.Ioc;
using HelpfulThings.Connect.Cryptowatch.Metering;
using HelpfulThings.Connect.Cryptowatch.Result;
using Newtonsoft.Json;

namespace HelpfulThings.Connect.Cryptowatch
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

        public RequestRouter(CryptowatchApiOptions configuration, IRequestMeteringMonitor requestMeteringMonitor)
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
