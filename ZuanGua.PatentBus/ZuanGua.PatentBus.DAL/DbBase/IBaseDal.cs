using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZuanGua.PatentBus.Common;

namespace ZuanGua.PatentBus.DAL
{
    public interface IBaseDal
    {
        IBaseDal BeginTrans();
        int Commit();
        void Rollback();
        int Insert<T>(T entity) where T : class;
        int Insert<T>(IEnumerable<T> entity) where T : class;
        int Delete<T>(T entity) where T : class;
        int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new();
        int Update<T>(T entity) where T : class;
        int Update<T>(IEnumerable<T> entities) where T : class;
        T LoadEntity<T>(object keyValue) where T : class;
        IQueryable<T> LoadIQueryable<T>() where T : class, new();
        IQueryable<T> LoadIQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new();
        IEnumerable<T> LoadList<T>() where T : class, new();
        IEnumerable<T> LoadList<T>(Expression<Func<T, bool>> condition) where T : class, new();
        IEnumerable<T> LoadList<T>(Expression<Func<T, bool>> condition, PageModels pagination) where T : class, new();

        DataTable LoadTable(string strSql);
        DataTable LoadTable(string strSql, PageModels pagination);
    }
}
