using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Model;
using Service;
using MovieClient;

namespace MovieClientTetsts
{
    [TestClass]
    public class MovieTreeViewModelTests
    {
        private Mock<IMovieService> _mockRepository;


        [TestMethod]
        public void Movies_ShouldReturnListOfMovies()
        {
            _mockRepository = new Mock<IMovieService>();

            //Data
            var m1 = new Movie();
            var m2 = new Movie();
            var movieList = new List<Movie>() {m1, m2};
            var viewModel = new MovieTreeViewModel(_mockRepository.Object);
            
            //Setup
            _mockRepository.Setup(x=>x.Movies).Returns(movieList).Verifiable();

            //Test
            var myList = viewModel.Movies;
            Assert.AreEqual(2, myList.Count);
            _mockRepository.Verify();
        }
    }
}
