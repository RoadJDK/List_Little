using System;
using AutoMapper;
using List_Little_Api.DTOs;

namespace List_Little_Api.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Person, List_Little_Domain.Models.Person>();
            CreateMap<List_Little_Domain.Models.Person, Person>();
        }
	}
}

