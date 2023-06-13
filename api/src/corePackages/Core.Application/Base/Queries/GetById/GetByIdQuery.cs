using AutoMapper;
using Core.Application.Base.Rules;
using Core.Application.ResponseTypes.Concrete;
using Core.Domain.Entities.Base;
using Core.Persistence.Dynamic;
using Core.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Core.Application.Base.Queries.GetById
{
    public class GetByIdQuery<TEntity, TModel> : IRequest<CustomResponseDto<TModel>>
    where TEntity : Entity
    where TModel : class
    {
        public Guid Id { get; set; }
        public IncludeProperty? IncludeProperty { get; set; }

        public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery<TEntity, TModel>, CustomResponseDto<TModel>>
        {
            private readonly IAsyncRepository<TEntity> _asyncRepository;
            private readonly IMapper _mapper;
            private readonly BaseBusinessRules<TEntity> _baseBusinessRules;

            public GetByIdQueryHandler(IAsyncRepository<TEntity> asyncRepository, IMapper mapper, BaseBusinessRules<TEntity> baseBusinessRules)
            {
                _asyncRepository = asyncRepository;
                _mapper = mapper;
                _baseBusinessRules = baseBusinessRules;
            }

            public async Task<CustomResponseDto<TModel>> Handle(GetByIdQuery<TEntity, TModel> request,
                                                    CancellationToken cancellationToken)
            {
                await _baseBusinessRules.BaseIdShouldExistWhenSelected(request.Id);
                IQueryable<TEntity> query = _asyncRepository.Query();

                if (request.IncludeProperty?.IncludeProperties != null)
                {
                    StringIncludeSpecification<TEntity> includeSpecification = new StringIncludeSpecification<TEntity>();
                    foreach (string includeProperty in request.IncludeProperty.IncludeProperties)
                    {
                        includeSpecification.Include(includeProperty);
                    }

                    query = includeSpecification.ApplyIncludes(query);
                }

                query = query.Where(x => x.Id == request.Id);
                TEntity entity = await query.SingleOrDefaultAsync();

                TModel mappedTModel = _mapper.Map<TModel>(entity);
                return CustomResponseDto<TModel>.Success((int)HttpStatusCode.OK, mappedTModel, isSuccess: true);
            }
        }
    }
}
