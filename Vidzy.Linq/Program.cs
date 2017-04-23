using System;
using System.Linq;


namespace Vidzy.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            var actionMovies = context.Videos
                .Where(v => v.Genre.Name == "Action")
                .OrderBy(v => v.Name);

            Console.WriteLine("-------");
            foreach (var video in actionMovies)
            {
                Console.WriteLine(video.Name);
            }

            var goldDramaMovies = context.Videos
                .Where(v => v.Classification == Classification.Gold && v.Genre.Name == "Drama")
                .OrderByDescending(v => v.ReleaseDate);

            Console.WriteLine("-------");
            foreach (var video in goldDramaMovies)
            {
                Console.WriteLine(video.Name);
            }

            var moviesGenre = context.Videos
                .Select(v => new
                {
                    MovieName = v.Name,
                    Genre = v.Genre.Name
                });

            Console.WriteLine("-------");
            foreach (var video in moviesGenre)
            {
                Console.WriteLine(video.MovieName);
            }

            var groupByClassification = context.Videos
                .GroupBy(v => v.Classification)
                .Select(g => new {
                    Classification = g.Key,
                    Videos = g.OrderBy(v => v.Name)
                });

            Console.WriteLine("-------");
            foreach (var group in groupByClassification)
            {
                Console.WriteLine("Classification: " + group.Classification);
                foreach (var video in group.Videos)
                {
                    Console.WriteLine("\t" + video.Name);
                }
            }

            Console.WriteLine("-------");
            foreach (var group in groupByClassification)
            {
                Console.WriteLine("{0} ({1})", group.Classification, group.Videos.Count());

            }

            var genres = context.Genres
                .GroupJoin(context.Videos, 
                    g => g.Id,
                    v => v.GenreId,
                    (genre, videos) => new
                    {
                        Name = genre.Name,
                        Count = videos.Count()
                    })
                .OrderByDescending(g => g.Count);

            Console.WriteLine("-------");
            foreach (var genre in genres)
            {
                Console.WriteLine("{0} ({1})", genre.Name, genre.Count);

            }

        }
    }
}
