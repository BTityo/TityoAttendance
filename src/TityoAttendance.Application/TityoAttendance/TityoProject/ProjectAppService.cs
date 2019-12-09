using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TityoAttendance.TityoAttendance.TityoProject.Dto;

namespace TityoAttendance.TityoAttendance.TityoProject
{
    public class ProjectAppService : AsyncCrudAppService<Project, ProjectDto, int, PagedTityoResultRequestDto, CreateProjectDto, ProjectDto>, IProjectAppService
    {
        private readonly IRepository<Project, int> _projectRepository;

        public ProjectAppService(IRepository<Project, int> projectRepository) : base(projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ListResultDto<ProjectDto>> GetAllByCompanyAsync(PagedTityoResultRequestDto inputDto, int companyId)
        {
            var projects = await _projectRepository
                .GetAllIncluding(p => p.CompanyId == companyId)
                .WhereIf(!inputDto.Keyword.IsNullOrWhiteSpace(), p => p.Name.Contains(inputDto.Keyword) || p.Description.Contains(inputDto.Keyword) || p.Color.Contains(inputDto.Keyword)).ToListAsync();

            return new ListResultDto<ProjectDto>(ObjectMapper.Map<List<ProjectDto>>(projects));
        }

        public override async Task<ProjectDto> Create(CreateProjectDto input)
        {
            var project = ObjectMapper.Map<Project>(input);

            await _projectRepository.InsertAsync(project);

            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(project);
        }

        public override async Task<ProjectDto> Update(ProjectDto input)
        {
            var project = await _projectRepository.FirstOrDefaultAsync(c => c.Id == input.Id);

            //project.Email = input.Email;
            //project.Name = input.Name;
            //project.MobilePhone = input.MobilePhone;
            //project.Address.CountryId = input.Address.CountryId;
            //project.Address.CountyId = input.Address.CountyId;
            //project.Address.CityId = input.Address.CityId;
            //project.Address.NatureOfPublicPlaceId = input.Address.NatureOfPublicPlaceId;
            //project.Address.HouseNumber = input.Address.HouseNumber;
            //project.Address.Street = input.Address.Street;
            MapToEntity(input, project);

            await _projectRepository.UpdateAsync(project);

            return await Get(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            var project = await _projectRepository.GetAsync(input.Id);
            await _projectRepository.DeleteAsync(project);
        }

        public async Task<bool> CheckColorIsExistsAsync(string color)
        {
            bool isExists = false;
            var project = await _projectRepository.FirstOrDefaultAsync(p => p.Color.ToUpper() == color.ToUpper());

            isExists = (project != null) ? true : false;

            return isExists;
        }
    }
}
