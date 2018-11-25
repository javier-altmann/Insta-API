using System;

namespace DAL
{
    public class Post
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}