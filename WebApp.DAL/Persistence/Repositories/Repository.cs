using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using WebApp.DAL.Context;
using WebApp.DAL.Persistence.Abstract;

namespace WebApp.DAL.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Set;

        public Repository(DbContext context)
        {
            Context = context;
            Set = context.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return Set.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Set.ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate);
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition or a default value if no such element exists; 
        /// this method throws an exception if more than one element satisfies the condition.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.SingleOrDefault(predicate);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.FirstOrDefault(predicate);
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            Set.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            Set.Remove(entity);
        }

        //public void RemoveRange(IEnumerable<TEntity> entities)
        //{
        //    Set.RemoveRange(entities);
        //}

        //IQueryable<TEntity> IRepository<TEntity>.Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return _set.Where(predicate);
        //}

        public void Attach(TEntity entity)
        {
            Set.Attach(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public List<T> SPGet<T>(string query, List<SqlParameter> parameters) where T : class
        {
            SqlConnection connection = new SqlConnection(Context.Database.GetConnectionString());

            SqlCommand command = new SqlCommand(query);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            if (command.Connection.State != ConnectionState.Open)
                command.Connection.Open();

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter);
            }

            var reader = command.ExecuteReader();

            var result = DataReaderMapToList<T>(reader);

            command.Connection.Close();

            return result;
        }

        public int ExecuteWithStoreProcedure(string query, params object[] parameters)
        {
            SqlConnection connection = new SqlConnection(Context.Database.GetConnectionString());

            SqlCommand command = new SqlCommand(query);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            if (command.Connection.State != ConnectionState.Open)
                command.Connection.Open();

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                    command.Parameters.Add(parameter);
            }

            int noRows = command.ExecuteNonQuery();
            command.Connection.Close();

            return noRows;
        }

        private static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

        public virtual void Dispose()
        {
            //Set = null;
            GC.SuppressFinalize(this);
        }
    }
}
