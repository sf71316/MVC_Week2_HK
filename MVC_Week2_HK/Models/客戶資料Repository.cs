using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
	
namespace MVC_Week1_HK.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p=>p.IsDelete==false);
        }
        public 客戶資料 Find(Func<客戶資料, bool> func)
        {
            return base.All().Where(p => p.IsDelete == false).FirstOrDefault(func);
        }
        public void Edit(客戶資料 entity)
        {
            entity.UpdateDateTime = DateTime.Now;
            this.UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
            this.UnitOfWork.Commit();
        }
        public override void Delete(客戶資料 entity)
        {
            entity.IsDelete = true;
            this.UnitOfWork.Commit();
        }
	}

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}