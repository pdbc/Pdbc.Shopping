using Pdbc.Shopping.Domain.Model;
using System;
using System.Linq;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Data.Seed
{
    public class ShoppingDataObjects : IHaveDataObjects
    {
        private readonly ShoppingDbContext _context;

        public ShoppingDataObjects(ShoppingDbContext context)
        {
            _context = context;
        }

        public void LoadObjects()
        {
            GenreLatin = GetGenreFor(ShoppingDataObjectsValues.GenreLatin);
            GenreElectricShopping = GetGenreFor(ShoppingDataObjectsValues.GenreElectricShopping);
            GenreDutch = GetGenreFor(ShoppingDataObjectsValues.GenreDutch);
            GenreFolk = GetGenreFor(ShoppingDataObjectsValues.GenreFolk);

        }

        public Genre GenreLatin { get; set; }
        public Genre GenreElectricShopping { get; set; }
        public Genre GenreDutch { get; set; }
        public Genre GenreFolk { get; set; }


        public Genre GetGenreFor(String name)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Name == name);
            return genre;
        }


    }
}