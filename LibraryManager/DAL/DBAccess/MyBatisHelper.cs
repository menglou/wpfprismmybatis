using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBAccess
{
   public class MyBatisHelper
    {
        private static volatile ISqlMapper mapper = null;

        private static string GetConfigPath()
        {
            //string baseDir = AppDomain.CurrentDomain.BaseDirectory; 
            string baseDir = AppDomain.CurrentDomain.BaseDirectory + "SqlMap.config"; //(@"../../SqlMap.config"); ;

            return baseDir;
        }

        public static void Configure(object obj)
        {
            mapper = (ISqlMapper)obj;
        }

        public static void InitMapper()
        {
            string configPath = GetConfigPath();
            ConfigureHandler hanlder = new ConfigureHandler(Configure);

            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            mapper = builder.ConfigureAndWatch(configPath, hanlder);
        }

        public static ISqlMapper Instance
        {
            get
            {
                try
                {
                    if (mapper == null)
                    {
                        lock (typeof(SqlMapper))
                        {
                            if (mapper == null)
                            {
                                InitMapper();
                            }
                        }
                    }
                    return mapper;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static T QueryForObject<T>(string statementName, object parameterObject)
        {
            T result = default(T);
            try
            {
                result = Instance.QueryForObject<T>(statementName, parameterObject);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询返回多条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="statementName"></param>
        /// <param name="parameterObject"></param>
        /// <returns></returns>
        public static IList<T> QueryForList<T>(string statementName, object parameterObject)
        {
            IList<T> result=new List<T>();
            try
            {
                result = Instance.QueryForList<T>(statementName, parameterObject);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void QueryForList<T>(string statementName, object parameterObject, IList<T> resultObject)
        {
            try
            {
                Instance.QueryForList<T>(statementName, parameterObject, resultObject);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static void QueryForList(string statementName, object parameterObject, IList resultObject)
        {
            try
            {
                Instance.QueryForList(statementName, parameterObject, resultObject);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public static object Save (string statementName, object parameterObject)
        {
            try
            {
                return Instance.Insert(statementName, parameterObject);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static int Update(string statementName, object parameterObject)
        {
            try
            {
                return Instance.Update(statementName, parameterObject); 
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public static int Delete(string statementName, object parameterObject)
        {
            try
            {
                return (int)Instance.Delete(statementName, parameterObject);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
