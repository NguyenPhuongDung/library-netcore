using Microsoft.AspNetCore.Http;

namespace Library.Entities
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Descriptions {get; set;}
        public string Image {get; set;}

    }
}