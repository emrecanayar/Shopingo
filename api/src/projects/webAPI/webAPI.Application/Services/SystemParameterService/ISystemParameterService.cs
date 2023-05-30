using Application.Features.SystemParameters.Dtos;

namespace webAPI.Application.Services.SystemParameterService
{
    public interface ISystemParameterService
    {
        Task<SystemParameterDto> GetByKey(string key);
    }
}