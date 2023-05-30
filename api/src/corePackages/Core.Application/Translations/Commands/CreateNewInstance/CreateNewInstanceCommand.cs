using Core.Application.ObjectPool;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Dtos;
using Core.Domain.Entities.Base;
using Core.Persistence.Repositories;
using MediatR;
using Microsoft.Extensions.ObjectPool;

namespace Core.Application.Base.Translations.Commands.CreateNewInstance
{
    public class CreateNewInstanceCommand<TDto, TEntity> : IRequest<CustomResponseDto<MultiLanguageDto<TDto>>>
     where TDto : class, IDto, new()
     where TEntity : Entity
    {
        public class CreateNewInstanceCommandHandler : IRequestHandler<CreateNewInstanceCommand<TDto, TEntity>, CustomResponseDto<MultiLanguageDto<TDto>>>
        {
            private readonly IRepository<TEntity> _repository;
            private readonly ObjectPool<CustomResponseDto<MultiLanguageDto<TDto>>> _responsePool;
            public CreateNewInstanceCommandHandler(IRepository<TEntity> repository, IObjectPoolFactory objectPoolFactory)
            {
                _repository = repository;
                _responsePool = objectPoolFactory.Create<CustomResponseDto<MultiLanguageDto<TDto>>>();
            }

            public async Task<CustomResponseDto<MultiLanguageDto<TDto>>> Handle(CreateNewInstanceCommand<TDto, TEntity> request, CancellationToken cancellationToken)
            {
                CustomResponseDto<MultiLanguageDto<TDto>> result = _responsePool.Get();

                result.Data = _repository.CreateNewInstanceWithLanguage<TDto>();

                return result;
            }
        }
    }
}
