using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ColligoEventFinder.Models
{
    [DataContract]
    public class Events
    {
        [DataMember(Name = "event")]
        public IEnumerable<Event> EventList { get; protected set; }
    }
}