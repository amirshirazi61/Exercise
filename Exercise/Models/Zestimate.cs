using System.ComponentModel.DataAnnotations;

namespace Exercise.Models
{
    public class Zestimate
    {
        public Zestimate()
        {
            this.ValuationRange = new ValuationRange();
        }

        public decimal? Amount { get; set; }
        public string LastUpdated { get; set; }
        public string OneWeekChange { get; set; }
        public decimal? Percentile { get; set; }
        public ValuationRange ValuationRange { get; set; }
        public decimal? ValueChange { get; set; }
    }
}