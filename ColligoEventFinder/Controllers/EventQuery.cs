using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ColligoEventFinder.Controllers
{
    public class EventQuery
    {
        public int pageNumber { get; set; }
        public string coordinates { get; set; }
        public string keywords { get; set; }
        public float radius { get; set; }
        public string dates { get; set; }
    }
}