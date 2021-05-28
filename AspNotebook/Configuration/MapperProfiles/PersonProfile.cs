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

            CreateMap<PersonPostViewModel, Person>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name.Trim()))
                .ForMember(dst => dst.Telephone, opt => opt.MapFrom(src => src.Telephone.Trim()))
                .ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<PersonPutViewModel, Person>()
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name.Trim()))
                .ForMember(dst => dst.Telephone, opt => opt.MapFrom(src => src.Telephone.Trim()))
                .ForMember(dst => dst.Id, opt => opt.Ignore());
        }
    }
}
