using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
	
namespace MVC_Week1_HK.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => p.IsDelete == false);
        }
        public 客戶銀行資訊 Find(Func<客戶銀行資訊, bool> func)
        {
            return base.All().Where(p => p.IsDelete == false).FirstOrDefault(func);
        }
        public void Edit(客戶銀行資訊 entity)
        {
            entity.UpdateDateTime = DateTime.Now;
            this.UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
            this.UnitOfWork.Commit();
        }
        public override void Delete(客戶銀行資訊 entity)
        {
            entity.IsDelete = true;
            this.UnitOfWork.Commit();
        }
	}

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}