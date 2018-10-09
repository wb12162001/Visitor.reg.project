using System;
using StructureMap;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Reg.Common.LogUtils;


namespace Visitor.Reg.StructureMap
{
    public class StructureMapWapper
    {

        private static Container instance = null;
        private static readonly object padlock = new object();

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
        public static void Init()
        {
            try
            {
                Visitor.Reg.Core.StructureMapWapperUtils.StructureMapWapper wapper = Visitor.Reg.Core.StructureMapWapperUtils.StructureMapWapper.GetInstance(new Visitor.Reg.Dao.StructureMap.MapRegistry());

                wapper.registry = new Visitor.Reg.Service.StructureMap.MapRegistry();
                wapper.Init();
                instance = Visitor.Reg.Core.StructureMapWapperUtils.StructureMapWapper.Instance;
                //http://structuremap.github.io/registration/
                //https://www.codeproject.com/Articles/1075597/Introduction-to-Dependency-Injection-and-Inversion
                //StructureMap.Configuration.ConfigurationConsta
                //ObjectFactory.Initialize(c =>
                //{
                //    c.AddConfigurationFromXmlFile("Config\\StructureMap\\Business.config");
                //    c.AddConfigurationFromXmlFile("Config\\StructureMap\\DataAccess.config");
                //});

                /*
                Instance.Configure(x =>
                {
                    //x.AddRegistry(new StructureMapRegistry());
                    x.AddRegistry(new Visitor.Reg.Dao.StructureMap.MapRegistry());
                    x.AddRegistry(new Visitor.Reg.Service.StructureMap.MapRegistry());
                });
                */

            }
            catch (Exception ex)
            {
                //加系统日志
                LogHelper.Instance.Error("初始化StructureMap组件错误", ex);
                throw;
            }

        }

        public static T GetInstance<T>()
        {
            return Instance.GetInstance<T>();
            //return Instance.TryGetInstance<T>();
            //return ObjectFactory.TryGetInstance<T>();
        }
    }
}
