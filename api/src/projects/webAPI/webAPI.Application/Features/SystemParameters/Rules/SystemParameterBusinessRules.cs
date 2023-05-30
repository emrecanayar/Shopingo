using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities;
using Core.Persistence.Paging;
using webAPI.Application.Features.StaticTexts.Constants;
using webAPI.Application.Services.Repositories;

namespace webAPI.Application.Features.SystemParameters.Rules;

public class SystemParameterBusinessRules : BaseBusinessRules
{
    private readonly ISystemParameterRepository _systemParameterRepository;

    public SystemParameterBusinessRules(ISystemParameterRepository systemParameterRepository)
    {
        _systemParameterRepository = systemParameterRepository;
    }

    public async Task SystemParameterIdShouldExistWhenSelected(Guid id)
    {
        SystemParameter? result = await _systemParameterRepository.GetAsync(b => b.Id == id);
        if (result is null) throw new NotFoundException(SystemParameterMessages.SystemParameterDontExists);
    }
    public async Task SystemParameterCanNotBeDuplicatedWhenInserted(string key)
    {
        IPaginate<SystemParameter> result = await _systemParameterRepository.GetListAsync(b => b.ParameterKey == key);
        if (result.Items.Any()) throw new BusinessException(SystemParameterMessages.SystemParameterExists);
    }
    public async Task SystemParameterKeyShouldExistWhenSelected(string key)
    {
        SystemParameter? result = await _systemParameterRepository.GetAsync(b => b.ParameterKey == key);
        if (result is null) throw new NotFoundException(SystemParameterMessages.SystemParameterDontExists);
    }
}