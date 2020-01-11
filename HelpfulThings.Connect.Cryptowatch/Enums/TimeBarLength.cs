using HelpfulThings.Connect.Cryptowatch.Exceptions;

namespace HelpfulThings.Connect.Cryptowatch.Enums
{
    public class TimeBarLength
    {
        public static readonly TimeBarLength OneMinute = new TimeBarLength(60);
        public static readonly TimeBarLength ThreeMinutes = new TimeBarLength(180);
        public static readonly TimeBarLength FiveMinutes = new TimeBarLength(300);
        public static readonly TimeBarLength FifteenMinutes = new TimeBarLength(900);
        public static readonly TimeBarLength ThirtyMinutes = new TimeBarLength(1800);
        public static readonly TimeBarLength OneHour = new TimeBarLength(3600);
        public static readonly TimeBarLength TwoHours = new TimeBarLength(7200);
        public static readonly TimeBarLength FourHours = new TimeBarLength(14400);
        public static readonly TimeBarLength SixHours = new TimeBarLength(21600);
        public static readonly TimeBarLength TwelveHours = new TimeBarLength(43200);
        public static readonly TimeBarLength OneDay = new TimeBarLength(86400);
        public static readonly TimeBarLength ThreeDays = new TimeBarLength(259200);
        public static readonly TimeBarLength OneWeek = new TimeBarLength(604800);
        public static readonly TimeBarLength OneWeekMondayAligned = new TimeBarLength(604800);

        public readonly int LengthInSeconds;

        private TimeBarLength(int seconds)
        {
            LengthInSeconds = seconds;
        }

        public static TimeBarLength GetBarLengthFromSeconds(string seconds)
        {
            switch (seconds)
            {
                case "60":
                    return OneMinute;
                case "180":
                    return ThreeMinutes;
                case "300":
                    return FiveMinutes;
                case "900":
                    return FifteenMinutes;
                case "1800":
                    return ThirtyMinutes;
                case "3600":
                    return OneHour;
                case "7200":
                    return TwoHours;
                case "14400":
                    return FourHours;
                case "21600":
                    return SixHours;
                case "43200":
                    return TwelveHours;
                case "86400":
                    return OneDay;
                case "259200":
                    return ThreeDays;
                case "604800":
                    return OneWeek;
                case "604800_Monday":
                    return OneWeekMondayAligned;
                default:
                    throw new BarLengthException($"Bar length {seconds} is not defined.");
            }
        }
    }
}
