using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Library.Utilities.Dictionaries;

namespace Library.Utilities.Extensions
{
    public static class LinqSupport
    {
        public static PagingResult<TEntity> GetPagingResult<TTable, TEntity>(this IQueryable<TTable> source, Func<IQueryable<TTable>, IOrderedQueryable<TTable>> setOrderFunction, int page, int size, Func<TTable, TEntity> toEntity) where TEntity : class
        {
            var result = setOrderFunction(source).Skip(page * size).Take(size + 1).ToArray();
            return new PagingResult<TEntity>
            {
                Items = result.Take(size).ConvertArray(toEntity),
                HasMoreRecords = result.Length > size,
                Totals = source.Count(),
            };
        }

        public static PagingResult<TEntity> GetPagingResult<TTable, TEntity>(this IQueryable<TTable> source, int page, int size, Func<TTable, TEntity> toEntity, Func<IEnumerable<TEntity>, IOrderedEnumerable<TEntity>> setOrderFunction) where TEntity : class
        {
            var result = source.ConvertArray(toEntity);
            var items = setOrderFunction(result).Skip(page * size).Take(size + 1).ToArray();
            return new PagingResult<TEntity>
            {
                Items = items.Take(size).ToArray(),
                HasMoreRecords = items.Length > size,
                Totals = source.Count(),
            };
        }

        public static TResult[] ConvertArray<TSource, TResult>(this IEnumerable<TSource> items, Func<TSource, TResult> toResult)
        {
            return items?.Select(toResult).ToArray() ?? EmptyArray<TResult>.Instance;
        }
    }
    public static class EmptyArray<T>
    {
        private static readonly T[] InstanceInternal = new T[0];

        public static T[] Instance
        {
            get { return InstanceInternal; }
        }
    }
}
