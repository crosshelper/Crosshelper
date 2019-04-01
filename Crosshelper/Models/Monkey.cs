using System;
namespace Crosshelper.Models
{
    public class Monkey
    {
        public Monkey()
        {
        }
        public string Name { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
