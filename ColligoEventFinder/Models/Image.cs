using System.Runtime.Serialization;

namespace ColligoEventFinder.Models
{
    [DataContract]
    public class Image
    {
        public Image(string url)
        {
            this.Url = url;
        }

        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}