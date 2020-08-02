using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext __context;

        public MoviesController()
        {
            __context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            __context.Dispose();
        }

        public  IEnumerable<MovieDto> GetMovies()
               
        {
           
            return __context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        public Movie GetMovie(int id)
        {
            var movie = __context.Movies.SingleOrDefault(c => c.Id == id);
            return movie;
        }
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            __context.Movies.Add(movie);
            __context.SaveChanges();
            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }
        [HttpPut]
        public void UpdateCustomer(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = __context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);
            __context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = __context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            __context.Movies.Remove(movieInDb);
            __context.SaveChanges();



        }

    }
}
