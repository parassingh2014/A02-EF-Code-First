using ConsoleApp1.DAL;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                //Create and save a new blog
                Console.WriteLine("Enter a name for a new blog");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                //Dispaly all the blogs from the database
                var allBlogs = db.Blogs.ToList();
                Console.WriteLine($"There are {allBlogs.Count} bogs in the database");
                foreach (var item in allBlogs)
                    Console.WriteLine(item.Name);

                //To do : Get the user to choose a blog and add a post to that blog.

                //var cBlogs = db.Blogs.
                /* Console.WriteLine("Choose a blog");
                 var choose = Console.ReadLine();

                 db.Blogs.
                 db.SaveChanges();
             */
            }
        }
    }
    namespace Entities
    {
        public class Blog
        {
            //ToDO: Follow up by making changes to entities and trying out Database Migrations
            // as discuseed in the MSDN demo linked to in Program.cs
            public int BlogId { get; set; }
            public string Name { get; set; }

            public virtual ICollection<Post> Posts { get; set; } 
          
        }
        public class Post
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public int BlodId { get; set; }


            public virtual Blog Blog{ get; set; }
        }
    }//close of the enitites namespace
    namespace DAL
    {
        public class BloggingContext : DbContext
        {
            public BloggingContext():base("name=BlogDb")
            {
                    
            }
            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
        }
    }
}
