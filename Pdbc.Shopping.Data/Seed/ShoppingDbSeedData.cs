using Pdbc.Shopping.Domain.Model;
using System;
using System.Linq;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Data.Seed
{
    public interface IShoppingDbSeedData : ISeedData
    {
    }
    public class ShoppingDbSeedData : IShoppingDbSeedData
    {
        private readonly ShoppingDbContext _dbContext;

        public ShoppingDbSeedData(ShoppingDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public void Seed()
        {
            SeedGenres();
            SeedArtists();
        }

        private void SeedGenres()
        {
            SeedGenreIfNotExists(_dbContext, ShoppingDataObjectsValues.GenreLatin);
            SeedGenreIfNotExists(_dbContext, ShoppingDataObjectsValues.GenreSchlager);
            SeedGenreIfNotExists(_dbContext, ShoppingDataObjectsValues.GenreJazz);
            SeedGenreIfNotExists(_dbContext, ShoppingDataObjectsValues.GenreRenB);
            SeedGenreIfNotExists(_dbContext, ShoppingDataObjectsValues.GenreRock);
            SeedGenreIfNotExists(_dbContext, ShoppingDataObjectsValues.GenrePop);
            SeedGenreIfNotExists(_dbContext, ShoppingDataObjectsValues.GenreElectricShopping);
            SeedGenreIfNotExists(_dbContext, ShoppingDataObjectsValues.GenreFolk);
            SeedGenreIfNotExists(_dbContext, ShoppingDataObjectsValues.GenreDutch);

            _dbContext.SaveChanges();
        }
        private void SeedArtists()
        {
            SeedArtistIfNotExists(_dbContext, ShoppingDataObjectsValues.Artist2Pac);
            SeedArtistIfNotExists(_dbContext, ShoppingDataObjectsValues.ArtistAerosmith);
            SeedArtistIfNotExists(_dbContext, ShoppingDataObjectsValues.ArtistAvicii);
            SeedArtistIfNotExists(_dbContext, ShoppingDataObjectsValues.ArtistEminem);
            SeedArtistIfNotExists(_dbContext, ShoppingDataObjectsValues.ArtistJonBonJovi);
            SeedArtistIfNotExists(_dbContext, ShoppingDataObjectsValues.ArtistQueen);
            SeedArtistIfNotExists(_dbContext, ShoppingDataObjectsValues.ArtistU2);


            _dbContext.SaveChanges();
        }

        private static void SeedGenreIfNotExists(ShoppingDbContext dbContext, String name)
        {
            var genre = dbContext.Genres.FirstOrDefault(x => x.Name == name);
            if (genre == null)
            {
                dbContext.Genres.Add(new GenreBuilder().WithName(name).Build());
            }
        }

        private static void SeedArtistIfNotExists(ShoppingDbContext dbContext, String name)
        {
            var genre = dbContext.Artists.FirstOrDefault(x => x.Name == name);
            if (genre == null)
            {
                dbContext.Artists.Add(new ArtistBuilder().WithName(name).Build());
            }
        }
    }
}