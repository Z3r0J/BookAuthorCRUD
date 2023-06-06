using AutoMapper;
using BookAuthorCRUD.Application.Feature.Genre.Command.Create;
using BookAuthorCRUD.Application.Feature.Genre.Command.Update;
using BookAuthorCRUD.Contract.DTOs.Genre;
using BookAuthorCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Test.Application.Test.Mapping
{
    public class GenreMappingTest
    {
        private readonly IServiceProvider _serviceProvider = Startup.ServiceProvider();
        private readonly IMapper _mapper;

        public GenreMappingTest()
        {
            _mapper = (IMapper)_serviceProvider.GetService(typeof(IMapper))!;
        }

        [Theory]
        [InlineData(typeof(Genre), typeof(GenreResponse))]

        public void ShouldHaveValidConfiguration(Type source, Type destination)
        {
            //Arrange
            _mapper.Map(source, destination);

            //Act

            //Assert
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(CreateGenreCommand), typeof(GenreRequest))]
        public void ShouldConvertCommandToRequest(Type source, Type destination)
        {
            //Arrange
            _mapper.Map(source, destination);

            //Act

            //Assert
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(UpdateGenreCommand), typeof(GenreRequest))]
        public void ShouldConvertUpdateCommandToRequest(Type source, Type destination)
        {
            //Arrange
            _mapper.Map(source, destination);

            //Act

            //Assert
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
