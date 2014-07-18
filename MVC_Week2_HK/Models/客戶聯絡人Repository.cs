using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
	
namespace MVC_Week1_HK.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.IsDelete == false);
        }
        public 客戶聯絡人 Find(Func<客戶聯絡人,bool> func)
        {
            return base.All().Where(p => p.IsDelete == false).FirstOrDefault(func);
        }
        public void Edit(客戶聯絡人 entity)
        {
            entity.UpdateDateTime = DateTime.Now;
            this.UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
            this.UnitOfWork.Commit();
        }
        public override void Delete(客戶聯絡人 entity)
        {
            entity.IsDelete = true;
            this.UnitOfWork.Commit();
        }
	}

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}