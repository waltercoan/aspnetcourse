using AutoMapper;
using certificacaoaspnet.DAL;
using certificacaoaspnet.Dtos;
using certificacaoaspnet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace certificacaoaspnet.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private CertificacaoDbContext _context;

        public MoviesController()
        {
            _context = new CertificacaoDbContext();
        }
        //GET /api/movies
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies
                .Include(m=>m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }
        
        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if(movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            

            _context.SaveChanges();
        }
        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
