using System.ComponentModel.DataAnnotations;

namespace Exercise.Models
{
    public class RegionModel
    {
        public RegionModel()
        {
            this.Link = new Link();
        }

        public string Id { get; set; }
        public Link Link { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal? ZindexValue { get; set; }
    }
}