﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly1.Models;
using Vidly1.Dtos;
using AutoMapper;

namespace Vidly1.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        
        // Get / Api/ Movies
        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDtos>));
        }

        // Get / Api / Movie /1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok (Mapper.Map<Movie, MovieDtos>(movie));
        }

        //Post / Api / Movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDtos moviedto )
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

           var movie = Mapper.Map<MovieDtos, Movie>(moviedto);
           _context.Movies.Add(movie);

            _context.SaveChanges();

            moviedto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviedto);

        }

        // PUT /Api / Movie /1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDtos moviedto)
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var MovieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (MovieInDb == null)
                return NotFound();

            Mapper.Map(moviedto, MovieInDb);
           
            _context.SaveChanges();
            return Ok();

        }
        //DELETE/ Api / Movie / 1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var MovieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (MovieInDb == null)
                return NotFound();
            _context.Movies.Remove(MovieInDb);
            _context.SaveChanges();
            return Ok();
        }

    }

    
}
