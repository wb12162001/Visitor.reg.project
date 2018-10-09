using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Reg.Common.LogUtils;

namespace Visitor.Reg.Core.StructureMapWapperUtils
{
    public class StructureMapWapper
    {
        private static StructureMapWapper mySingleton;

        private static Container instance = null;
        private static readonly object padlock = new object();

        public Registry registry
        {
            get;set;
        }

        public static Container Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Container();
                    }
                    return instance;
                }
            }
        }

        // 定义私有构造函数，使外界不能创建该类实例
        private StructureMapWapper(Registry reg)
        {
            this.registry = reg;
        }

        //定义公有方法提供一个全局访问点。
        public static StructureMapWapper GetInstance(Registry reg)
        {
            //这里的lock其实使用的原理可以用一个词语来概括“互斥”这个概念也是操作系统的精髓
            //其实就是当一个进程进来访问的时候，其他进程便先挂起状态
            if (mySingleton == null)
            {
                mySingleton = new StructureMapWapper(reg);
                mySingleton.Init();
            }
            return mySingleton;
        }

        public void Init()
        {
            try
            {
                //http://structuremap.github.io/registration/
                //StructureMap.Configuration.ConfigurationConsta
                //ObjectFactory.Initialize(c =>
                //{
                //    c.AddConfigurationFromXmlFile("Config\\StructureMap\\Business.config");
                //    c.AddConfigurationFromXmlFile("Config\\StructureMap\\DataAccess.config");
                //});

                Instance.Configure(x =>
                {
                    x.AddRegistry(registry);
                });
            }
            catch (Exception ex)
            {
                //加系统日志
                LogHelper.Instance.Error("初始化StructureMap组件错误",ex);
                throw;
            }

        }

        public static T GetInstance<T>()
        {
            return Instance.GetInstance<T>();
            //return ObjectFactory.TryGetInstance<T>();
        }
    }

}
