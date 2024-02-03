using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System;
using TerlikDAL;

public class Repository<T> : Singleton, InterRepository<T> where T : class
{
    private DbSet<T> Dbset;

    public Repository()
    {
        Dbset = db.Set<T>();
    }

    public List<T> Liste()
    {
        return Dbset.ToList();
    }

    public IQueryable<T> ListQueryable()
    {
        return Dbset.AsQueryable();
    }

    public List<T> Liste(Expression<Func<T, bool>> kosul)
    {
        return Dbset.Where(kosul).ToList();
    }

    public int Insert(T entity)
    {
        Dbset.Add(entity);
        return db.SaveChanges(); // returns the number of affected rows
    }

    public int Update(T entity)
    {
        db.Entry(entity).State = EntityState.Modified;
        return db.SaveChanges(); // returns the number of affected rows
    }

    public int Delete(T entity)
    {
        Dbset.Remove(entity);
        return db.SaveChanges(); // returns the number of affected rows
    }

    public T Find(Expression<Func<T, bool>> where)
    {
        return Dbset.FirstOrDefault(where);
    }
}
