using System;
namespace Crosshelper.Models
{
    public class HelperProfileContent
    {
        public HelperProfileContent()
        {
        }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Rating { get; set; }
        public string Language { get; set; }
        public string Tags { get; set; }
        public string Baseprice { get; set; }
        public string Bio { get; set; }
        public string Review { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
