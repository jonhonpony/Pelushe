using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;

namespace TerlikDAL
{
    public interface InterRepository<T>
    {
        int Insert(T nesne);
        int Update(T nesne);
        int Delete(T nesne);

        List<T> Liste();

        List<T> Liste(Expression<Func<T, bool>> kosul);// koşul expression göndereceğimiz  için bu şekilde yazdık 

        T Find(Expression<Func<T, bool>> kosul);

        IQueryable<T> ListQueryable();

    }
}