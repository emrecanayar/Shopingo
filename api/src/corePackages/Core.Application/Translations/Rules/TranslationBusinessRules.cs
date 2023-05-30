using Core.Application.Base.Constants;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Domain.Entities.Base;
using Core.Persistence.Repositories;

namespace Core.Application.Translations.Rules
{
    public class TranslationBusinessRules<TEntity> : BaseBusinessRules
      where TEntity : Entity
    {
        private readonly IAsyncRepository<TEntity> _asyncRepository;

        public TranslationBusinessRules(IAsyncRepository<TEntity> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }

        public async Task TranslationIdShouldExistWhenSelected(Guid id)
        {
            TEntity? translation = await _asyncRepository.GetAsync(x => x.Id == id, enableTracking: false);
            if (translation is null) throw new BusinessException(typeof(TEntity).Name + BaseMessages.EntityDoesNotExist);
        }

        public Task TranslationShouldBeExist(TEntity? translation)
        {
            if (translation is null) throw new NotFoundException(typeof(TEntity).Name + BaseMessages.EntityDoesNotExist);
            return Task.CompletedTask;
        }
    }
}
