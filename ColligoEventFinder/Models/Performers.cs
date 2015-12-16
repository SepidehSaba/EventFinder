using System.Runtime.Serialization;

namespace ColligoEventFinder.Models
{
    [DataContract]
    public class Performers
    {
        [DataMember(Name = "performer")]
        public Performer PerformerTeam { get; protected set; }
    }
}