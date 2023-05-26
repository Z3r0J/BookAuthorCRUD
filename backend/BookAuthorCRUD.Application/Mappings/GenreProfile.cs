﻿using AutoMapper;
using BookAuthorCRUD.Application.Feature.Genre.Command.Create;
using BookAuthorCRUD.Application.Feature.Genre.Command.Update;
using BookAuthorCRUD.Contract.DTOs.Genre;
using BookAuthorCRUD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAuthorCRUD.Application.Mappings;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<GenreResponse, Genre>()
            .ForMember(x => x.Books, opt => opt.Ignore())
            .ReverseMap()
            .ForMember(x => x.Books, opt => opt.Ignore());

        CreateMap<CreateGenreCommand, GenreRequest>().ReverseMap();
        CreateMap<UpdateGenreCommand, GenreRequest>().ReverseMap();
    }
}
