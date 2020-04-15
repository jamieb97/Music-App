using System;
using System.Collections.Generic;

namespace Music_API.Models
{
    public partial class Track
    {
        public int TrackId { get; set; }
        public string TrackName { get; set; }
        public string Artist { get; set; }
        public int? ReleaseDate { get; set; }
        public bool? Explicits { get; set; }
        public TimeSpan? TrackLength { get; set; }
        public string TrackLink { get; set; }
    }
}
