using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TityoAttendance.TityoAttendance.TityoAddress;
using TityoAttendance.TityoAttendance.TityoCompany.Dto;

namespace TityoAttendance.TityoAttendance.TityoCompany
{
    public class CompanyAppService : AsyncCrudAppService<Company, CompanyDto, int, PagedTityoResultRequestDto, CreateCompanyDto, CompanyDto>, ICompanyAppService
    {
        private readonly IRepository<Company, int> _companyRepository;
        private readonly IRepository<Address, int> _addressRepository;
        private readonly IRepository<UserCompanyMap, int> _userCompanyMapRepository;

        public CompanyAppService(IRepository<Company, int> companyRepository, IRepository<Address, int> addressRepository, IRepository<UserCompanyMap, int> userCompanyMapRepository) : base(companyRepository)
        {
            _companyRepository = companyRepository;
            _addressRepository = addressRepository;
            _userCompanyMapRepository = userCompanyMapRepository;
        }

        public async Task<List<CompanyDto>> GetAllByUserAsync()
        {
            var companies = await _userCompanyMapRepository
                .GetAllIncluding(c => c.Company)
                .Where(c => c.UserId == AbpSession.UserId)
                .Select(c => c.Company)
                .ToListAsync();

            return new List<CompanyDto>(ObjectMapper.Map<List<CompanyDto>>(companies));
        }

        public async Task<ListResultDto<CompanyDto>> GetAllWithAddressAsync(PagedTityoResultRequestDto inputDto)
        {
            var companies = await _companyRepository
                .GetAllIncluding(c => c.Address)
                .Include(a => a.Address.Country)
                .Include(a => a.Address.County)
                .Include(a => a.Address.City)
                .Include(a => a.Address.NatureOfPublicPlace)
                .WhereIf(!inputDto.Keyword.IsNullOrWhiteSpace(), c => c.Name.Contains(inputDto.Keyword) || c.Email.Contains(inputDto.Keyword) || c.Address.Country.Name.Contains(inputDto.Keyword) || c.Address.County.Name.Contains(inputDto.Keyword) || c.Address.City.Name.Contains(inputDto.Keyword) || c.Address.Street.Contains(inputDto.Keyword)).ToListAsync();

            return new ListResultDto<CompanyDto>(ObjectMapper.Map<List<CompanyDto>>(companies));
        }

        public async Task<CompanyDto> GetCompanyDtoAsync(int id)
        {
            var company = await _companyRepository
                .GetAllIncluding(c => c.Address)
                .Include(a => a.Address.Country)
                .Include(a => a.Address.County)
                .Include(a => a.Address.City)
                .Include(a => a.Address.NatureOfPublicPlace)
                .FirstOrDefaultAsync(c => c.Id == id);

            return ObjectMapper.Map<CompanyDto>(company);
        }

        public override async Task<CompanyDto> Create(CreateCompanyDto input)
        {
            var company = ObjectMapper.Map<Company>(input);

            await _companyRepository.InsertAsync(company);

            CurrentUnitOfWork.SaveChanges();

            CompanyDto insertedCompany = MapToEntityDto(company);

            // Create UserCompanyMap
            UserCompanyMap userCompanyMap = new UserCompanyMap() { CompanyId = insertedCompany.Id, UserId = AbpSession.UserId.Value };
            await _userCompanyMapRepository.InsertAsync(userCompanyMap);

            return insertedCompany;
        }

        public override async Task<CompanyDto> Update(CompanyDto input)
        {
            var company = await _companyRepository
                .GetAllIncluding(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == input.Id);

            company.Email = input.Email;
            company.Name = input.Name;
            company.MobilePhone = input.MobilePhone;
            company.Address.CountryId = input.Address.CountryId;
            company.Address.CountyId = input.Address.CountyId;
            company.Address.CityId = input.Address.CityId;
            company.Address.NatureOfPublicPlaceId = input.Address.NatureOfPublicPlaceId;
            company.Address.HouseNumber = input.Address.HouseNumber;
            company.Address.Street = input.Address.Street;

            await _companyRepository.UpdateAsync(company);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            // Delete company
            var company = await _companyRepository.GetAsync(input.Id);
            await _companyRepository.DeleteAsync(company);

            // Delete address based on company
            var address = await _addressRepository.GetAsync(company.AddressId);
            await _addressRepository.DeleteAsync(address);

            // Delete UserCompanyMaps based on logged in UserId and Company
            var userCompanyMap = await _userCompanyMapRepository.FirstOrDefaultAsync(c => c.CompanyId == input.Id && c.UserId == AbpSession.UserId.Value);
            await _userCompanyMapRepository.DeleteAsync(userCompanyMap);
        }
    }
}
