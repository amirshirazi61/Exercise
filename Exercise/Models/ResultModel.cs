namespace Exercise.Models
{
    public class ResultModel
    {
        public ResultModel()
        {
            this.Link = new Link();
            this.Address = new Address();
            this.Zestimate = new Zestimate();
            this.LocalRealState = new LocalRealState();
        }

        public Address Address { get; set; }
        public Link Link { get; set; }
        public LocalRealState LocalRealState { get; set; }
        public Zestimate Zestimate { get; set; }
        public string Zpid { get; internal set; }
    }
}