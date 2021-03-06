﻿using System;
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
    public class BankController : BaseController
    {
       // private DbEntities db = new DbEntities();
        private 客戶銀行資訊Repository BankRepo = RepositoryHelper.Get客戶銀行資訊Repository();
        // GET: Bank
        public ActionResult Index()
        {
            var 客戶銀行資訊 =this.BankRepo.All().Include(客 => 客.客戶資料);
            return View(客戶銀行資訊.ToList());
        }

        // GET: Bank/Details/5
        [IDFilter]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.BankRepo.Find(p=>p.Id==id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // GET: Bank/Create
        public ActionResult Create()
        {
            ViewBag.客戶Id = new SelectList(RepositoryHelper.Get客戶資料Repository().All(), "Id", "客戶名稱");
            return View();
        }

        // POST: Bank/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            客戶銀行資訊 客戶銀行資訊 = new 客戶銀行資訊();
            if (this.TryUpdateModel<I客戶銀行資訊Data>(客戶銀行資訊))
            {
                this.BankRepo.Add(客戶銀行資訊);
                this.BankRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.客戶Id = new SelectList(RepositoryHelper.Get客戶資料Repository().All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: Bank/Edit/5
        [IDFilter]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.BankRepo.Find(p=>p.Id==id.Value);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            ViewBag.客戶Id = new SelectList(RepositoryHelper.Get客戶資料Repository().All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // POST: Bank/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FormCollection form)
        {
            客戶銀行資訊 客戶銀行資訊 = new 客戶銀行資訊();
            if (this.TryUpdateModel<I客戶銀行資訊Data>(客戶銀行資訊))
            {
                
                this.BankRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.客戶Id = new SelectList(RepositoryHelper.Get客戶資料Repository().All(), "Id", "客戶名稱", 客戶銀行資訊.客戶Id);
            return View(客戶銀行資訊);
        }

        // GET: Bank/Delete/5
        [IDFilter]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶銀行資訊 客戶銀行資訊 = this.BankRepo.Find(p=>p.Id==id);
            if (客戶銀行資訊 == null)
            {
                return HttpNotFound();
            }
            return View(客戶銀行資訊);
        }

        // POST: Bank/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [IDFilter]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶銀行資訊 客戶銀行資訊 =this.BankRepo.Find(p=>p.Id==id);
            this.BankRepo.Delete(客戶銀行資訊);
            this.BankRepo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
