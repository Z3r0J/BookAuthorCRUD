using AutoMapper;
using BookAuthorCRUD.Application.Feature.Author.Command.Create;
using BookAuthorCRUD.Application.Feature.Author.Command.Update;
using BookAuthorCRUD.Contract.DTOs.Author;
using BookAuthorCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Test.Application.Test.Mapping
{
    public class AuthorMappingTest
    {
        private readonly IServiceProvider _serviceProvider = Startup.ServiceProvider();
        private readonly IMapper _mapper;

        public AuthorMappingTest()
        {
            _mapper = (IMapper)_serviceProvider.GetService(typeof(IMapper))!;
        }

        [Theory]
        [InlineData(typeof(Author), typeof(AuthorResponse))]
        public void ShouldConvertAuthorToResponse(Type source, Type destination)
        {
            //Arrange
            _mapper.Map(source, destination);

            //Act

            //Assert
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
        [Theory]
        [InlineData(typeof(CreateAuthorCommand), typeof(AuthorRequest))]
        public void ShouldConvertCommandToRequest(Type source, Type destination)
        {
            //Arrange
            _mapper.Map(source, destination);

            //Act

            //Assert
            _mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(UpdateAuthorCommand), typeof(AuthorRequest))]
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
