using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Reg.Core.StructureMapWapperUtils;
using Visitor.Reg.Dao.Daos;
using Visitor.Reg.Entity.CommonModel;
using Visitor.Reg.Entity.Models;
//using Visitor.Reg.Service.SystemControl;

namespace Visitor.Reg.Service.Services
{
    public class BaseService : IBaseService
    {
        public IDaoFrame baseDao { get; set; }

        public BaseService()
        {
            baseDao = StructureMapWapper.GetInstance<IDaoFrame>();
        }

        public bool Add<T>(T t)
        {
            return baseDao.Add(t);
        }

        public bool Delete<T>(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetList<T>()
        {
            throw new NotImplementedException();
        }

        public T GetOne<T>(int id)
        {
            return baseDao.GetOne<T>(id);
        }

        public ResultModel<T> GetWithPages<K,T>(QueryBase queryBase, string orderBy, string orderDir = "desc") 
        {
            return baseDao.GetWithPages<T>(queryBase, orderBy, orderDir);

        }

        public bool Update<T>(T t) 
        {
           return baseDao.Update<T>(t);
        }

        public bool Delete<T>(List<int> ids)
        {
            return baseDao.Delete<T>(ids);
        }
    }
}
