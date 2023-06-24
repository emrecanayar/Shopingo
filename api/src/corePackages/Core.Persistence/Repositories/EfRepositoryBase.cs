using AutoMapper;
using Core.Domain.Dtos;
using Core.Domain.Entities;
using Core.Domain.Entities.Base;
using Core.Helpers.Helpers;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using static Core.Domain.ComplexTypes.Enums;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>, IRepository<TEntity>
    where TEntity : Entity, new()
    where TContext : DbContext
    {
        protected TContext Context { get; }
        public string CurrentCultureSymbol { get; private set; }
        protected readonly IMapper _mapper;
        protected readonly string NameOfClass;
        protected Dictionary<string, string> translationKeyValue { get; set; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public EfRepositoryBase(TContext context, IMapper mapper, string nameOfClass = "")
        {
            Context = context;
            _mapper = mapper;
            CurrentCultureSymbol = Thread.CurrentThread.CurrentCulture.Name;
            NameOfClass = nameOfClass;
        }


        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>,
                                            IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true,
                                            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<TEntity?> GetIgnoreQueryFilterAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await queryable.IgnoreQueryFilters().FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                           int index = 0, int size = 10, bool enableTracking = true,
                                                           CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<IPaginate<TEntity>> GetListIgnoreQueryFiltersAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).IgnoreQueryFilters().ToPaginateAsync(index, size, 0, cancellationToken);
            return await queryable.IgnoreQueryFilters().ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
                                                                    Func<IQueryable<TEntity>,
                                                                    IIncludableQueryable<TEntity, object>> include = null,
                                                                    int index = 0, int size = 10,
                                                                    bool enableTracking = true,
                                                                    CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
        }


        public async Task<IPaginate<TEntity>> GetListIgnoreByDynamicAsync(Dynamic.Dynamic dynamic, Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            return await queryable.IgnoreQueryFilters().ToPaginateAsync(index, size, 0, cancellationToken);
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<TEntity>> AddRangeAsync(List<TEntity> entityList)
        {
            Context.AddRangeAsync(entityList);
            await Context.SaveChangesAsync();
            return entityList;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<TEntity>> UpdateRangeAsync(List<TEntity> entityList)
        {
            foreach (var entity in entityList)
            {
                Context.Entry(entity).State = EntityState.Modified;
            }

            await Context.SaveChangesAsync();

            return entityList;
        }


        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<TEntity>> DeleteRangeAsync(List<TEntity> entityList)
        {
            foreach (var entity in entityList)
            {
                Context.Entry(entity).State = EntityState.Deleted;
            }

            await Context.SaveChangesAsync();

            return entityList;
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity?> query = Context.Set<TEntity>().AsQueryable();
            if (include != null) query = include(query);
            return query.FirstOrDefault(predicate);
        }

        public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                          int index = 0, int size = 10,
                                          bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return orderBy(queryable).ToPaginate(index, size);
            return queryable.ToPaginate(index, size);
        }

        public IPaginate<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic,
                                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                                   int index = 0, int size = 10,
                                                   bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return queryable.ToPaginate(index, size);
        }

        public TEntity Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        }
        public List<TEntity> AddRange(List<TEntity> entity)
        {
            Context.AddRange(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public List<TEntity> UpdateRange(List<TEntity> entity)
        {
            Context.UpdateRange(entity);
            Context.SaveChanges();
            return entity;
        }

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.UpdateRange(entities);
            await Context.SaveChangesAsync();
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity;
        }

        public List<TEntity> DeleteRange(List<TEntity> entity)
        {
            Context.RemoveRange(entity);
            Context.SaveChanges();
            return entity;
        }
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Context.Set<TEntity>().AnyAsync(expression);
        }

        public void Remove(int id)
        {
            TEntity entity = Context.Set<TEntity>().Find(id);
            Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public async Task RemoveAsync(int id)
        {
            TEntity entity = Context.Set<TEntity>().Find(id);
            await RemoveAsync(entity);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            entity.IsDeleted = true;
            await UpdateAsync(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }

            await UpdateRangeAsync(entities);
        }
        public TEntity UpsertTranslations(TEntity entity, List<DictionaryDto> translations)
        {
            var addedList = new List<Dictionary>();
            var updatedList = new List<Dictionary>();
            if (translationKeyValue?.Count > 0)
            {
                if (entity.Id == Guid.Empty)
                {
                    foreach (var item in translationKeyValue)
                    {
                        entity.GetType().GetProperty(item.Key).SetValue(entity, Guid.NewGuid().ToString().ToUpper());
                    }
                    List<Dictionary> translationList = _mapper.Map<List<Dictionary>>(translations);
                    foreach (var item in translationList)
                    {
                        item.ValueType = "dynamic";
                        item.Entity = NameOfClass;
                        var propertyName = item.Property;
                        var propertyKey = translationKeyValue.FirstOrDefault(x => x.Value == propertyName).Key;
                        item.EntryKey = entity.GetType().GetProperty(propertyKey).GetValue(entity).ToString();
                        item.LanguageId = CustomStringLocalizer.GetActiveLanguages().Where(x => x.Symbol == item.Language.Symbol).FirstOrDefault().Id;
                        item.Language = default;
                    }
                    addedList.AddRange(translationList);
                }
                else
                {
                    List<Dictionary> translationList = _mapper.Map<List<Dictionary>>(translations);
                    foreach (var item in translationList)
                    {
                        if (item.Id > Guid.Empty)
                        {
                            var dictionaryRecord = Context.Set<Dictionary>().FirstOrDefault(x => x.Id == item.Id);
                            dictionaryRecord.EntryValue = item.EntryValue;
                            updatedList.Add(dictionaryRecord);
                        }
                        else
                        {
                            item.ValueType = "dynamic";
                            item.Entity = NameOfClass;
                            var propertyName = item.Property;
                            var propertyKey = translationKeyValue.FirstOrDefault(x => x.Value == propertyName).Key;
                            item.EntryKey = entity.GetType().GetProperty(propertyKey).GetValue(entity).ToString();
                            item.LanguageId = CustomStringLocalizer.GetActiveLanguages().Where(x => x.Symbol == item.Language.Symbol).FirstOrDefault().Id;
                            item.Language = default;
                            addedList.Add(item);
                        }
                    }
                }
                translations.Clear();

                if (addedList.Count > 0)
                {
                    Context.Set<Dictionary>().AddRange(addedList);
                    translations.AddRange(_mapper.Map<List<DictionaryDto>>(addedList));
                }
                if (updatedList.Count > 0)
                {
                    Context.Set<Dictionary>().UpdateRange(updatedList);
                    translations.AddRange(_mapper.Map<List<DictionaryDto>>(updatedList));
                }
                if (translations.Count > 0)
                {
                    Context.SaveChanges();
                }
            }
            return entity;
        }
        MultiLanguageDto<F> IRepository<TEntity>.CreateNewInstanceWithLanguage<F>()
        {
            var entityWithTranslation = new MultiLanguageDto<F>();
            TEntity entity = new TEntity();
            entity.Status = RecordStatu.Active;
            entityWithTranslation.Entity = _mapper.Map<F>(entity);

            if (translationKeyValue?.Count > 0)
            {
                foreach (var item in translationKeyValue)
                {
                    var property = entityWithTranslation.Entity.GetType().GetProperty(item.Key);
                    var guidKey = Guid.NewGuid().ToString().ToUpper();
                    property.SetValue(entityWithTranslation.Entity, guidKey);
                    entityWithTranslation.Translations.AddRange(createTranslations(item, guidKey));
                }
            }
            return entityWithTranslation;
        }
        private List<DictionaryDto> createTranslations(KeyValuePair<string, string> propertyMap, string key)
        {
            List<Dictionary> missingDictionaries = new List<Dictionary>();
            var languages = CustomStringLocalizer.GetActiveLanguages().OrderBy(x => x.Symbol).ToList();
            if (languages.Any())
            {
                foreach (var item in languages)
                {
                    missingDictionaries.Add(new Dictionary()
                    {
                        Entity = NameOfClass,
                        EntryKey = key,
                        EntryValue = String.Empty,
                        LanguageId = item.Id,
                        Status = RecordStatu.Active,
                        ValueType = "dynamic",
                        Property = propertyMap.Value,
                        Language = item.ToMap<Language>()
                    });
                }
            }
            return _mapper.Map<List<DictionaryDto>>(missingDictionaries);
        }
        private void checkAndCreateMissingTranslations(KeyValuePair<string, string> propertyMap, string key)
        {
            List<Dictionary> missingDictionaries = new List<Dictionary>();
            var currentDictionary = CustomStringLocalizer.GetValues(key, true).ToList();
            var languages = CustomStringLocalizer.GetActiveLanguages().ToList();
            var differences = languages.Select(x => x.Symbol).Except(currentDictionary.Select(x => x.Language.Symbol));
            if (differences.Any())
            {
                var defaultDictionary = currentDictionary.OrderBy(x => x.Language.Id).FirstOrDefault();
                foreach (var item in differences)
                {
                    if (defaultDictionary != null)
                    {
                        missingDictionaries.Add(new Dictionary()
                        {
                            Entity = NameOfClass,
                            EntryKey = defaultDictionary.EntryKey,
                            EntryValue = defaultDictionary.EntryValue,
                            LanguageId = languages.Where(x => x.Symbol == item).FirstOrDefault().Id,
                            Status = RecordStatu.Active,
                            ValueType = "dynamic",
                            Property = propertyMap.Value,
                        });
                    }
                    else
                    {
                        missingDictionaries.Add(new Dictionary()
                        {
                            Entity = NameOfClass,
                            EntryKey = key,
                            EntryValue = string.Empty,
                            LanguageId = languages.Where(x => x.Symbol == item).FirstOrDefault().Id,
                            Status = RecordStatu.Active,
                            ValueType = "dynamic",
                            Property = propertyMap.Value,
                        });
                    }
                }

                Context.Set<Dictionary>().AddRange(missingDictionaries);
                Context.SaveChanges();
            }
        }


    }
}