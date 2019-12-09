using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TityoAttendance.TityoAttendance.TityoAddress.Dto;

namespace TityoAttendance.TityoAttendance.TityoAddress
{
    public class AddressAppService : AsyncCrudAppService<Address, AddressDto, int, PagedTityoResultRequestDto, CreateAddressDto, AddressDto>, IAddressAppService
    {
        private readonly IRepository<Address, int> _addressRepository;
        private readonly IRepository<Country, int> _countryRepository;
        private readonly IRepository<County, int> _countyRepository;
        private readonly IRepository<City, int> _cityRepository;
        private readonly IRepository<NatureOfPublicPlace, int> _natureOfPublicPlacesRepository;

        public AddressAppService(
            IRepository<Address, int> repository,
            IRepository<Country, int> countryRepository,
            IRepository<County, int> countyRepository,
            IRepository<City, int> cityRepository,
            IRepository<NatureOfPublicPlace, int> natureOfPublicPlaceRepository) : base(repository)
        {
            _addressRepository = repository;
            _countryRepository = countryRepository;
            _countyRepository = countyRepository;
            _cityRepository = cityRepository;
            _natureOfPublicPlacesRepository = natureOfPublicPlaceRepository;
        }

        public override async Task<AddressDto> Create(CreateAddressDto input)
        {
            Address address = ObjectMapper.Map<Address>(input);

            await _addressRepository.InsertAsync(address);

            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(address);
        }

        public override async Task<AddressDto> Update(AddressDto input)
        {
            Address address = await _addressRepository.GetAsync(input.Id);

            MapToEntity(input, address);

            await _addressRepository.UpdateAsync(address);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            Address address = await _addressRepository.GetAsync(input.Id);
            await _addressRepository.DeleteAsync(address);
        }

        public async Task<ListResultDto<CountryDto>> GetCountries()
        {
            var countries = await _countryRepository.GetAllListAsync();

            // Put Hungary to the first
            int huIndex = countries.FindIndex(c => c.CountryCode == "HU");
            var huCountry = countries.FirstOrDefault(c => c.CountryCode == "HU");
            countries.RemoveAt(huIndex);
            countries.Insert(0, huCountry);

            return new ListResultDto<CountryDto>(ObjectMapper.Map<List<CountryDto>>(countries));
        }

        public async Task<ListResultDto<CountyDto>> GetCounties(string countryCode)
        {
            var counties = await _countyRepository.GetAllListAsync(c => c.CountryCode == countryCode);
            return new ListResultDto<CountyDto>(ObjectMapper.Map<List<CountyDto>>(counties));
        }

        public async Task<ListResultDto<CityDto>> GetCities(string countyCode)
        {
            var cities = await _cityRepository.GetAllListAsync(c => c.CountyCode == countyCode);
            return new ListResultDto<CityDto>(ObjectMapper.Map<List<CityDto>>(cities).OrderBy(c => c.Name).ToList());
        }

        public async Task<ListResultDto<NatureOfPublicPlaceDto>> GetNatureOfPublicPlaces()
        {
            var natureOfPublicPlaces = await _natureOfPublicPlacesRepository.GetAllListAsync();
            return new ListResultDto<NatureOfPublicPlaceDto>(ObjectMapper.Map<List<NatureOfPublicPlaceDto>>(natureOfPublicPlaces));
        }
    }
}
