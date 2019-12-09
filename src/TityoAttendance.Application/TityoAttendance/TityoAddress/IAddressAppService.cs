using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using TityoAttendance.TityoAttendance.TityoAddress.Dto;

namespace TityoAttendance.TityoAttendance.TityoAddress
{
    public interface IAddressAppService : IAsyncCrudAppService<AddressDto, int, PagedTityoResultRequestDto, CreateAddressDto, AddressDto>
    {
        Task<ListResultDto<CountryDto>> GetCountries();
        Task<ListResultDto<CountyDto>> GetCounties(string countryCode);
        Task<ListResultDto<CityDto>> GetCities(string countyCode);
        Task<ListResultDto<NatureOfPublicPlaceDto>> GetNatureOfPublicPlaces();
    }
}
