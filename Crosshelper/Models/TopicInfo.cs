using System;
namespace Crosshelper.Models
{
    public class TopicInfo
    {
        public int TopicID { get; set; }
        public string UserID { get; set; }
        public int TagID { get; set; }
        public string TagName { get; set; }
        public string Zipcode { get; set; }
        public string Language { get; internal set; }
        public string Description { get; internal set; }
        public string CaseTypeLabelText { get; internal set; }
        public int Status { get; internal set; }

        public TopicInfo()
        {
        }
    }
}
