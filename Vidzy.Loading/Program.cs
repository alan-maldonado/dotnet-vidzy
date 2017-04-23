

using System;
using System.Linq;
using System.Data.Entity;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            // Lazy Loading
            // Include virtual to Genre property, but will cause n + 1 problem

            // Eager loading
            //var videos = context.Videos.Include(v => v.Genre).ToList();

            // Explicit Loading
            var videos = context.Videos.ToList();
            context.Videos.Select(v => v.Genre).Load();

            foreach (var video in videos)
            {
                Console.WriteLine("{0} - {1}", video.Name, video.Genre.Name);
            }

        }
    }
}
