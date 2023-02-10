namespace BlazorAbbPoc.Server.Configurations
{
    public class AnomalyDetectionOptions
    {
        public const string AnomalyDetection = "AnomalyDetection";

        public long GapThresholdSeconds { get; set; } = 3600;
    }
}
