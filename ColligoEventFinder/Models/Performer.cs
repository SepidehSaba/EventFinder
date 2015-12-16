using System.Runtime.Serialization;
namespace ColligoEventFinder.Models
{
    [DataContract]
    public class Performer
    {
        [DataMember(Name = "name")]
        public string Name { get; protected set; }
    }
}