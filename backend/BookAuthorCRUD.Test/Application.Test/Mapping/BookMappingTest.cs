using AutoMapper;
using BookAuthorCRUD.Application.Feature.Book.Command.Create;
using BookAuthorCRUD.Application.Feature.Book.Command.Update;
using BookAuthorCRUD.Contract.DTOs.Book;
using BookAuthorCRUD.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Test.Application.Test.Mapping
{
    public class BookMappingTest
    {
        private readonly IServiceProvider _serviceProvider = Startup.ServiceProvider();
        private readonly IMapper _mapper;

        public BookMappingTest()
        {
            _mapper = _serviceProvider.GetRequiredService<IMapper>();
        }

        [Theory]
        [InlineData(typeof(Book), typeof(BookResponse))]

        public void ShouldHaveValidConfiguration(Type source, Type destination)
        {
            //Arrange
            _mapper.Map(source, destination);

            //Act

            //Assert
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(CreateBookCommand), typeof(BookRequest))]
        public void ShouldConvertCommandToRequest(Type source, Type destination)
        {
            //Arrange
            _mapper.Map(source, destination);

            //Act

            //Assert
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(UpdateBookCommand), typeof(BookRequest))]
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
