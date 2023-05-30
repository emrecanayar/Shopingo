using Application.Features.SystemParameters.Dtos;
using Core.Domain.Entities;
using webAPI.Application.Features;
using webAPI.Application.Features.SystemParameters.Rules;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Services.SystemParameterService
{
    public class SystemParameterManager : ISystemParameterService
    {
        private readonly ISystemParameterRepository _systemParameterRepository;
        private readonly SystemParameterBusinessRules _systemParameterBusinessRules;

        public SystemParameterManager(ISystemParameterRepository systemParameterRepository, SystemParameterBusinessRules systemParameterBusinessRules)
        {
            _systemParameterRepository = systemParameterRepository;
            _systemParameterBusinessRules = systemParameterBusinessRules;
        }

        public async Task<SystemParameterDto> GetByKey(string key)
        {
            await _systemParameterBusinessRules.SystemParameterKeyShouldExistWhenSelected(key);

            SystemParameter? SystemParameter = await _systemParameterRepository.GetAsync(b => b.ParameterKey == key);
            SystemParameterDto SystemParameterDto = ObjectMapper.Mapper.Map<SystemParameterDto>(SystemParameter);
            return SystemParameterDto;
        }
    }
}