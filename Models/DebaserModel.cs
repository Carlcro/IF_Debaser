using Newtonsoft.Json;

namespace IF_Debaser.Models
{
    public class DebaserModel
    {
        public int eventId { get; set; }
        public string eventDate { get; set; }
        public string club { get; set; }
        [JsonProperty("event")]
        public string eventType { get; set; }
        public string subhead { get; set; }
        public string description { get; set; }
        public string open { get; set; }
        public string admission { get; set; }
        public string venue { get; set; }
        public string imageurl { get; set; }

    }

}