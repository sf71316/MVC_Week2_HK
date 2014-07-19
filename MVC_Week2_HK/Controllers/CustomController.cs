using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Week1_HK.Models;
using MVC_Week1_HK.ActionFilter;

namespace MVC_Week1_HK.Controllers
{
    public class CustomController : BaseController
    {
        private 客戶資料Repository CustomRepos = RepositoryHelper.Get客戶資料Repository();

        // GET: Custom
        public ActionResult Index()
        {
            return View(CustomRepos.All().ToList());
        }

        // GET: Custom/Details/5
        [IDFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = CustomRepos.Find(p=>p.Id==id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // GET: Custom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Custom/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        public ActionResult Create(FormCollection form)
        {
            客戶資料 客戶資料=new 客戶資料();
            if (this.TryUpdateModel<I客戶資料Data>(客戶資料))
            {
             //   db.客戶資料.Add(客戶資料);
               // db.SaveChanges();
                CustomRepos.Add(客戶資料);
                CustomRepos.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: Custom/Edit/5
        [IDFilter]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = CustomRepos.Find(p => p.Id == id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: Custom/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            客戶資料 客戶資料 = new 客戶資料();
            if (this.TryUpdateModel<I客戶資料Data>(客戶資料))
            {
                this.CustomRepos.Edit(客戶資料);
                
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: Custom/Delete/5
        [IDFilter]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = CustomRepos.Find(p => p.Id == id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: Custom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [IDFilter]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = CustomRepos.Find(p => p.Id == id);
            //db.客戶資料.Remove(客戶資料);
            //db.SaveChanges();
            CustomRepos.Delete(客戶資料);
            CustomRepos.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
             //   db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
