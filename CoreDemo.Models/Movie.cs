using System;
using System.Collections.Generic;
using System.Text;

namespace CoreDemo.Models
{
    public class Movie
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int CinemaId { set; get; }
        public string Starring { set; get; }
        public DateTime ReleaseTime { set; get; }
    }
}
