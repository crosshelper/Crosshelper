using System;
namespace Crosshelper.Models
{
    public class TopicInfo
    {
        public int TopicID { get; set; }
        public int UserID { get; set; }
        public int TagID { get; set; }
        public string Zipcode { get; set; }
        public string Language { get; internal set; }
        public string Description { get; internal set; }

        public TopicInfo()
        {
        }
    }
}
