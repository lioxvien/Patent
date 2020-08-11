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
    public class BaseDal : IBaseDal
    {
        public Database db;

        public BaseDal()
        {
            db = new Database();
        }
        /// <summary>
        /// 事务开始
        /// </summary>
        /// <returns></returns>
        public IBaseDal BeginTrans()
        {
            db = db.BeginTrans();
            return this;
        }
        /// <summary>
        /// 提交当前操作的结果
        /// </summary>
        public int Commit()
        {
            return db.Commit();
        }
        /// <summary>
        /// 把当前操作回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            db.Rollback();
        }

        /// <summary>
        /// 插入数据记录
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="entity">插入的数据模型</param>
        /// <returns>是否成功</returns>
        public int Insert<T>(T entity) where T : class
        {
            return db.Insert<T>(entity);
        }

        /// <summary>
        /// 插入数据记录
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="entity">插入的数据模型</param>
        /// <returns>是否成功</returns>
        public int Insert<T>(IEnumerable<T> entity) where T : class
        {
            return db.Insert<T>(entity);
        }

        /// <summary>
        /// 删除数据记录
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="entity">删除的数据模型</param>
        /// <returns>是否成功</returns>
        public int Delete<T>(T entity) where T : class
        {
            return db.Delete<T>(entity);
        }

        /// <summary>
        /// 删除数据记录
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="condition">lambda表达式</param>
        /// <returns>是否成功</returns>
        public int Delete<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.Delete<T>(condition);
        }

        /// <summary>
        /// 修改数据记录
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="entity">修改的数据模型</param>
        /// <returns>是否成功</returns>
        public int Update<T>(T entity) where T : class
        {
            return db.Update<T>(entity);
        }
        /// <summary>
        /// 修改数据记录
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="entity">修改的数据模型</param>
        /// <returns>是否成功</returns>
        public int Update<T>(IEnumerable<T> entities) where T : class
        {
            return db.Update<T>(entities);
        }
        /// <summary>
        /// 获取实体数据
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="keyValue">主键</param>
        /// <returns>实体数据</returns>
        public T LoadEntity<T>(object keyValue) where T : class
        {
            return db.LoadEntity<T>(keyValue);
        }

        /// <summary>
        /// 获取实体数据列表
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <returns>实体数据列表</returns>
        public IQueryable<T> LoadIQueryable<T>() where T : class, new()
        {
            return db.LoadIQueryable<T>();
        }

        /// <summary>
        /// 获取实体数据列表
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="condition">lambda表达式</param>
        /// <returns>实体数据列表</returns>
        public IQueryable<T> LoadIQueryable<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.LoadIQueryable<T>(condition);
        }

        /// <summary>
        /// 获取实体数据列表
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <returns>实体数据列表</returns>
        public IEnumerable<T> LoadList<T>() where T : class, new()
        {
            return db.LoadList<T>();
        }

        /// <summary>
        /// 获取实体数据列表
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="condition">lambda表达式</param>
        /// <returns>实体数据列表</returns>
        public IEnumerable<T> LoadList<T>(Expression<Func<T, bool>> condition) where T : class, new()
        {
            return db.LoadList<T>(condition);
        }


        /// <summary>
        /// 获取实体数据列表
        /// </summary>
        /// <typeparam name="T">数据模型类</typeparam>
        /// <param name="condition">lambda表达式</param>
        /// <param name="pageModels">分页参数</param>
        /// <returns>实体数据列表</returns>
        public IEnumerable<T> LoadList<T>(Expression<Func<T, bool>> condition, PageModels pageModels) where T : class, new()
        {
            int total = pageModels.total;
            var data = db.LoadList<T>(condition, pageModels.orderrow, pageModels.ordertype.ToLower() == "asc" ? true : false, pageModels.pageSize, pageModels.pageIndex, out total);
            pageModels.total = total;
            return data;
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <returns>表数据</returns>
        public DataTable LoadTable(string strSql)
        {
            return db.LoadTable(strSql);
        }

        /// <summary>
        /// 获取表数据
        /// </summary>
        /// <param name="strSql">SQL语句</param>
        /// <param name="pageModels">分页参数</param>
        /// <returns>表数据</returns>
        public DataTable LoadTable(string strSql, PageModels pageModels)
        {
            int total = pageModels.total;
            var data = db.LoadTable(strSql, pageModels.orderrow, pageModels.ordertype.ToLower() == "asc" ? true : false, pageModels.pageSize, pageModels.pageIndex, out total);
            pageModels.total = total;
            return data;
        }
    }
}
