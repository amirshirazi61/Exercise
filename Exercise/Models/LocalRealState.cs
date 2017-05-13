namespace Exercise.Models
{
    public class LocalRealState
    {
        public LocalRealState()
        {
            this.Region = new RegionModel();
        }
        public RegionModel Region { get; set; }
    }
}