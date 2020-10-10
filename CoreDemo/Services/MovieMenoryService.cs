using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Services
{
    public class MovieMenoryService : IMovieService
    {
        private readonly List<Movie> _movies = new List<Movie>();
        public MovieMenoryService()
        {
            _movies.Add(new Movie{
                CinemaId=1,
                Id=1,
                Name="Ant man",
                ReleaseTime=new DateTime(2018,1,1),
                Starring="Nick"
            });

            _movies.Add(new Movie
            {
                CinemaId=1,
                Id=2,
                Name="Super Man",
                ReleaseTime=new DateTime(2019,1,1),
                Starring="Mike"
            });

            _movies.Add(new Movie
            {
                CinemaId=2,
                Id=3,
                Name="Ghost",
                ReleaseTime=new DateTime(2020,1,1),
                Starring="jhon"


            });

        }

        public Task AddAsync(Movie model)
        {
            var maxId = _movies.Max(x => x.Id);
            model.Id = maxId + 1;
            _movies.Add(model);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Movie>> GetByCinemaAsync(int cinemaId)
        {
            return Task.Run(() => _movies.Where(x => x.CinemaId == cinemaId));
        }
    }
}
