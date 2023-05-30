using Application.Features.SystemParameters.Dtos;
using Core.Application.ResponseTypes.Concrete;
using MediatR;
using webAPI.Application.Services.SystemParameterService;
using System.Net;

namespace webAPI.Application.Features.SystemParameters.Queries.GetByUrlSystemParameter
{
    public class GetByKeySystemParameterQuery : IRequest<CustomResponseDto<SystemParameterDto>>
    {
        public string Key { get; set; }

        public class GetByKeySystemParameterQueryHandler : IRequestHandler<GetByKeySystemParameterQuery, CustomResponseDto<SystemParameterDto>>
        {
            private readonly ISystemParameterService _SystemParameterService;

            public GetByKeySystemParameterQueryHandler(ISystemParameterService SystemParameterService)
            {
                _SystemParameterService = SystemParameterService;
            }

            public async Task<CustomResponseDto<SystemParameterDto>> Handle(GetByKeySystemParameterQuery request, CancellationToken cancellationToken)
            {
                SystemParameterDto? SystemParameterDto = await _SystemParameterService.GetByKey(request.Key);
                return CustomResponseDto<SystemParameterDto>.Success((int)HttpStatusCode.OK, SystemParameterDto, true);
            }
        }
    }
}