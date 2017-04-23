using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidzy.DbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new VidzyContext();

            context.AddVideo("Scary Movie", new DateTime(2016, 12, 24), "Comedy", Classification.Silver);
            context.AddVideo("La la land", new DateTime(2017, 1, 14), "Romance", Classification.Gold);
        }
    }
}
