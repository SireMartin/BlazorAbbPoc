using BlazorAbbPoc.Shared.Plc;

namespace BlazorAbbPoc.Shared;

public class ChartData
{
    public IEnumerable<TimeSeries>? TimeSeriesData { get; set; }
    public Aggregated? AggregatedData { get; set; }

    public class TimeSeries
    {
        public int? l1V { get; set; }
        public int? l2V { get; set; }
        public int? l3V { get; set; }

        public int? l1A { get; set; }
        public int? l2A { get; set; }
        public int? l3A { get; set; }
        public int? nA { get; set; }

        public DateTime timestamp { get; set; }
    }

    public class Aggregated
    {
        public int? l1ActE { get; set; }
        public int? l2ActE { get; set; }
        public int? l3ActE { get; set; }
        public int? totActE { get; set; }

        public int? l1ReactE { get; set; }
        public int? l2ReactE { get; set; }
        public int? l3ReactE { get; set; }
        public int? totReactE { get; set; }

        public int? l1AppE { get; set; }
        public int? l2AppE { get; set; }
        public int? l3AppE { get; set; }
        public int? totAppE { get; set; }
    }
}
