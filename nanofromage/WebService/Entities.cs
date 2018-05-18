using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebService
{
    public class Donjon
    {
        public const String PATH = "/donjons";
        public const String BY_DONJON = "/donjons/";
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int level { get; set; }
        public int xp { get; set; }
        public int loot { get; set; }
        public List<Donjon> Donjons { get; set; }
    }

    public class Quest
    {
        public const String PATH = "/quetes";
        public const String BY_QUEST = "/quetes/";
        public int id { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public int time { get; set; }
        public int xp { get; set; }
        public int loot { get; set; }
    }

    public class Post
    {
        public const String PATH = "/posts/";
        public const String BY_USER = "/posts/?userId=";
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }

    public class Comment
    {
        public const String PATH = "/comments/";
        public const String BY_USER = "/comments/?userId=";
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }

    public class Album
    {
        public const String PATH = "/albums/";
        public const String BY_USER = "/albums/?userId=";
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public List<Photo> Photos { get; set; }
    }

    public class Photo
    {
        public const String PATH = "/photos/";
        public const String BY_ALBUM = "/photos/?albumId=";
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }

    public class Todo
    {
        public const String PATH = "/todos/";
        public const String BY_USER = "/todos/?userId=";
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }

    public class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }

    public class User
    {
        public const String PATH = "/users/";
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }
        public List<Post> Posts { get; set; }
        public List<Todo> Todos { get; set; }
        //public List<Comment> Comments { get; set; }
        public List<Album> Albums { get; set; }
    }
}
