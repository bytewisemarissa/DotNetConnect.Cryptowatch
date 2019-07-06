using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using DotNetConnect.Cryptowatch.Configuration;
using DotNetConnect.Cryptowatch.DataModel;
using DotNetConnect.Cryptowatch.Result;

namespace DotNetConnect.Cryptowatch.Metering
{
    public interface IRequestMeteringMonitor
    {
        long MeterMaxValue { get; }
        long MeterCurrentValue { get; }
        MeteringResult CheckMeter();
        long GetSerial();
        void RegisterResult(long requestSerial, Allowance requestAllowance);
    }

    public class RequestMeteringMonitor : IRequestMeteringMonitor
    {
        private readonly long _meterMaxValue;
        private readonly long _stopThreshold;

        private readonly object _serializerLock;
        private readonly object _resultsProcessingLock;
        
        private long _requestSerial;
        private long _processedSerial;
        private long _currentMeterValue;

        private Task _limitResetTask;

        public long MeterMaxValue => _meterMaxValue;
        public long MeterCurrentValue => _currentMeterValue;

        public RequestMeteringMonitor(DNCCryptowatchConfigurationModel configuration)
        {
            _meterMaxValue = configuration.RequestMeterMaximum;
            
            var stopThresholdPercentage = configuration.StopThresholdPercentage;
            _stopThreshold = (long) Math.Round(_meterMaxValue * stopThresholdPercentage);

            _serializerLock = new object();
            _resultsProcessingLock = new object();
            
            _requestSerial = 0;
            _processedSerial = 0;
            _currentMeterValue = _meterMaxValue;

            _limitResetTask = Task.Run(() => MeterResetWorker());
        }

        private void MeterResetWorker()
        {
            while (true)
            {
                var timeOfDay = DateTime.UtcNow.TimeOfDay;
                var nextFullHour = TimeSpan.FromHours(Math.Ceiling(timeOfDay.TotalHours));
                var delta = nextFullHour - timeOfDay;

                Task.Delay(delta);
                
                _currentMeterValue = _meterMaxValue;
            }
        }

        public MeteringResult CheckMeter()
        {
            if (_currentMeterValue > _stopThreshold)
            {
                return MeteringResult.Proceeded;
            }
            
            return MeteringResult.Reject;
        }

        public long GetSerial()
        {
            long returnSerial;

            lock (_serializerLock)
            {
                returnSerial = _requestSerial;
                _requestSerial++;
            }

            return returnSerial;
        }

        public void RegisterResult(long requestSerial, Allowance requestAllowance)
        {
            lock (_resultsProcessingLock)
            {
                if (requestSerial > _processedSerial)
                {
                    _processedSerial = requestSerial;
                    _currentMeterValue = requestAllowance.Remaining;
                }
            }
        }
    }
}
