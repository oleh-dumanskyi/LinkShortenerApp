using AutoMapper;
using Shortener.Application.Common.Mappings;
using Shortener.Application.Urls.Queries.GetUrlByShortUri;

namespace Shortener.WebApi.Models
{
    public class GetUrlDto : IMapWith<GetUrlQuery>
    {
        public Uri ShortUri { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetUrlDto, GetUrlQuery>()
                .ForMember(command => command.ShortenedUri, opt => opt.MapFrom(urlDto => urlDto.ShortUri));
        }
    }
}