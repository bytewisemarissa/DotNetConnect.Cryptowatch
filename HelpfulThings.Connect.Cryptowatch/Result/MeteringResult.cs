namespace HelpfulThings.Connect.Cryptowatch.Result
{
    public class MeteringResult
    {
        public static MeteringResult Proceeded = new MeteringResult(true, false);
        public static MeteringResult ProceededSlow = new MeteringResult(true, true);
        public static MeteringResult Reject = new MeteringResult(false, false);

        public readonly bool RequestIsAllowed;
        public readonly bool RequestShouldSlowMode;
        
        private MeteringResult(bool requestIsAllowed, bool requestShouldSlowMode)
        {
            RequestIsAllowed = requestIsAllowed;
            RequestShouldSlowMode = requestShouldSlowMode;
        }
    }
}
