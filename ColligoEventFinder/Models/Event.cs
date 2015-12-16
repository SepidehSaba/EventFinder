using System.Runtime.Serialization;
using System;
namespace ColligoEventFinder.Models
{
    [DataContract]
    public class Event
    {
        private Image eventImage;
        private string eventDate;

        [DataMember(Name = "title")]
        public string Title { get; protected set; }

        [DataMember(Name = "venue_name")]
        public string Venue { get; protected set; }

        [DataMember(Name = "performers")]
        public Performers Team { get; protected set; }

        [DataMember(Name = "image")]
        public Image EventImage
        {
            get { return eventImage; }
            set
            {
                if (value != null && value.Url != null)
                {
                    this.eventImage = value;
                }
                else
                {
                    this.eventImage = new Image("images/noimage.jpg");
                }
            }
        }

        [DataMember(Name = "start_time")]
        public string EventDate
        {
            get { return eventDate; }
            set
            {
                string convertionFormat = "yyyy-MM-dd HH:mm:ss";
                DateTime dt = DateTime.ParseExact(value, convertionFormat, null);
                this.eventDate = dt.ToString("MM/dd/yy") + " " + dt.DayOfWeek.ToString();

            }
        }
    }
}