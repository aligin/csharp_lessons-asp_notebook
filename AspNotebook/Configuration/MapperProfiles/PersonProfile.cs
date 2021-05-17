using AspNotebook.Models;
using AspNotebook.ViewModels;
using AutoMapper;

namespace AspNotebook.Configuration.MapperProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonViewModel>();
        }
    }
}
