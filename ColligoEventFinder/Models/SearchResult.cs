using System;
using System.Runtime.Serialization;

namespace ColligoEventFinder.Models
{
    // The root Data Conract for storing search result
    // Json response from Eventful are parsed and stored in this structure
    [DataContract]
    public class SearchResult
    {
        [DataMember(Name = "events")]
        public Events FoundEvents { get; protected set; }

        [DataMember(Name = "page_count")]
        public int PageCount { get; protected set; }

        [DataMember(Name = "page_number")]
        public int PageNumber { get; protected set; }
    }
}