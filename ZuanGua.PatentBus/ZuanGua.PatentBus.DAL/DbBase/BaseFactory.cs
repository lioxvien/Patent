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
    public class BaseFactory<T> where T : class ,new()
    {
        /// <summary>
        /// 定义基础库
        /// </summary>
        /// <returns></returns>
        public IBaseDal InitialBaseDal()
        {
            return new BaseDal();
        }

        #region 增
        public int Insert(T model)
        {
            return InitialBaseDal().Insert(model);
        }
        #endregion

        #region 删
        public int Delete(T model)
        {
            return InitialBaseDal().Delete(model);
        }

        public int Delete(Expression<Func<T, bool>> condition)
        {
            return InitialBaseDal().Delete(condition);
        }
        #endregion

        #region 改
        public int Update(T model)
        {
            return InitialBaseDal().Update(model);
        }

        public int Update(Expression<Func<T,bool>> condition)
        {
            return InitialBaseDal().Update(condition);
        }
        #endregion

        #region 查
        public T LoadEntity(object key)
        {
            return InitialBaseDal().LoadEntity<T>(key);
        }
        public IQueryable<T> LoadIQueryable()
        {
            return InitialBaseDal().LoadIQueryable<T>();
        }
        public IQueryable<T> LoadIQueryable(Expression<Func<T, bool>> condition)
        {
            return InitialBaseDal().LoadIQueryable(condition);
        }
        public IEnumerable<T> LoadList()
        {
            return InitialBaseDal().LoadList<T>();
        }
        public IEnumerable<T> LoadList(Expression<Func<T, bool>> condition)
        {
            return InitialBaseDal().LoadList(condition);
        }
        public IEnumerable<T> LoadList(Expression<Func<T, bool>> condition, PageModels pagination)
        {
            return InitialBaseDal().LoadList(condition, pagination);
        }

        public DataTable LoadTable(string strSql)
        {
            return InitialBaseDal().LoadTable(strSql);
        }
        public DataTable LoadTable(string strSql, PageModels pagination)
        {
            return InitialBaseDal().LoadTable(strSql, pagination);
        }
        #endregion
    }
}
