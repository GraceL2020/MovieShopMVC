using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieShop.Data;
using MovieShop.Entities;
using MovieShop.Services;
using Moq;

namespace MovieShop.UnitTest
{
    [TestClass]
    public class MovieServiceUnitTest
    {
        private IMovieService _sut; // System Under Test
        private List<Movie> _fakeMovies;
        private readonly Mock<IMovieRepository> _mockMovieRepository;

        public MovieServiceUnitTest()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _sut = new MovieService(_mockMovieRepository.Object);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _fakeMovies = new List<Movie>
            {
                          new Movie
                          {
                              Id = 1,
                              Title = "TestMovie1",
                              Budget = 25000,
                          },
                          new Movie
                          {
                              Id = 2,
                              Title = "TestMovie2",
                              Budget = 245400,
                          },
                          new Movie
                          {
                              Id = 3,
                              Title = "TestMovie3",
                              Budget = 230000,
                          },
                          new Movie
                          {
                              Id = 4,
                              Title = "TestMovie4",
                              Budget =87000,
                          },
                          new Movie
                          {
                              Id = 5,
                              Title = "TestMovie5",
                              Budget = 125000,
                          }
            };

            //using Moq to setup mock methods fro IMovieRepository

            _mockMovieRepository.Setup(m => m.GetTopGrossingMovies()).Returns(_fakeMovies);
            _mockMovieRepository.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int m)=>_fakeMovies.FirstOrDefault(x=>x.Id==m));
        }

        [TestMethod]
        public void Test_For_TopGrossingMovies_From_FakeData()
        {
            //act
            var topMovies = _sut.GetTopGrossingMovies();

            //Assert
            //can do multiple asserts in one unit test method
            Assert.IsNotNull(topMovies);
            Assert.AreEqual(5,topMovies.Count());
            CollectionAssert.AllItemsAreInstancesOfType(topMovies.ToList(), typeof(Movie));

            //new unit test method for testing getMovieDetails
            //

        }

        [TestMethod]
        public void Test_For_GetMovieDetails_From_FakeData()
        {
            //act
            var movie = _sut.GetMovieDetails(3);

            //Assert
            //can do multiple asserts in one unit test method
            Assert.IsNotNull(movie);
            Assert.IsNotNull(movie.Title);
            Assert.IsNotNull(movie.Id);

        }
    }

//    public class FakeMovieRepository : IMovieRepository
//    {
//        private List<Movie> _fakeMovies;
//        public void Add(Movie entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(Movie entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(Expression<Func<Movie, bool>> where)
//        {
//            throw new NotImplementedException();
//        }

//        public Movie Get(Expression<Func<Movie, bool>> where)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Movie> GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        public Movie GetById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Movie> GetMany(Expression<Func<Movie, bool>> where)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Movie> GetMoviesByTitle(string title, int pageIndex)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Movie> GetTopGrossingMovies()
//        {
//            _fakeMovies = new List<Movie>
//            {
//                          new Movie
//                          {
//                              Id = 1,
//                              Title = "TestMovie1",
//                              Budget = 25000,
//                          },
//                          new Movie
//                          {
//                              Id = 2,
//                              Title = "TestMovie2",
//                              Budget = 245400,
//                          },
//                          new Movie
//                          {
//                              Id = 3,
//                              Title = "TestMovie3",
//                              Budget = 230000,
//                          },
//                          new Movie
//                          {
//                              Id = 4,
//                              Title = "TestMovie4",
//                              Budget =87000,
//                          },
//                          new Movie
//                          {
//                              Id = 5,
//                              Title = "TestMovie5",
//                              Budget = 125000,
//                          }
//            };
//            return _fakeMovies;
//        }

//        public IEnumerable<Movie> GetTopRatedMovies()
//        {
//            throw new NotImplementedException();
//        }

//        public bool Save()
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Movie entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
}
