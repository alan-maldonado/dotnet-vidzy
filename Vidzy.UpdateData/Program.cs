
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void AddVideo()
        {
            using (var context = new VidzyContext())
            {
                var actionGenre = context.Genres.Single(g => g.Name == "Action");
                context.Videos.Add(new Video
                {
                    Name = "Terminator",
                    ReleaseDate = new System.DateTime(1984, 10, 26),
                    Genre = actionGenre
                });

                context.SaveChanges();
            }
        }

        static void AddTags()
        {
            using (var context = new VidzyContext())
            {
                var classicsTag = context.Tags.SingleOrDefault(t => t.Name == "classics");
                if (classicsTag == null)
                {
                    classicsTag = new Tag
                    {
                        Name = "classics"
                    };

                    context.Tags.Add(classicsTag);
                }

                var dramaTag = context.Tags.SingleOrDefault(t => t.Name == "drama");
                if (dramaTag == null)
                {
                    dramaTag = new Tag
                    {
                        Name = "drama"
                    };

                    context.Tags.Add(dramaTag);
                }

                context.SaveChanges();
            }
        }
    }
}
