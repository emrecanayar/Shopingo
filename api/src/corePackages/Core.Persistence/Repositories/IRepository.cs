﻿using Core.Domain.Dtos;
using Core.Domain.Entities.Base;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public interface IRepository<T> : IQuery<T> where T : Entity
    {
        T Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        IPaginate<T> GetList(Expression<Func<T, bool>>? predicate = null,
                             Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                             int index = 0, int size = 10, bool enableTracking = true);

        IPaginate<T> GetListByDynamic(Dynamic.Dynamic dynamic, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, int index = 0, int size = 10, bool enableTracking = true);

        T Add(T entity);
        List<T> AddRange(List<T> entity);
        T Update(T entity);
        List<T> UpdateRange(List<T> entity);
        T Delete(T entity);
        List<T> DeleteRange(List<T> entity);
        void Remove(int id);
        void Remove(T entity);
        MultiLanguageDto<F> CreateNewInstanceWithLanguage<F>() where F : class, IDto, new();
        T UpsertTranslations(T entity, List<DictionaryDto> translations);
    }
}
