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
using MVC_Week1_HK.Models.viewModel;
using OfficeOpenXml;

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
            else
            {
                ViewBag.Bank = RepositoryHelper.Get客戶銀行資訊Repository().All().Where(p => p.客戶Id == id.Value).ToList();
                ViewBag.Contact = RepositoryHelper.Get客戶聯絡人Repository().All().Where(p => p.客戶Id == id.Value).ToList();
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
            CustomRepos.UnitOfWork.LazyLoadingEnabled = false;
            客戶資料 客戶資料 = CustomRepos.Find(p => p.Id == id.Value);
           
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.Bank = RepositoryHelper.Get客戶銀行資訊Repository().All().Where(p => p.客戶Id == id.Value).ToList();
                ViewBag.Contact = RepositoryHelper.Get客戶聯絡人Repository().All().Where(p => p.客戶Id == id.Value).ToList();
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
            ViewBag.Bank = RepositoryHelper.Get客戶銀行資訊Repository().All().Where(p => p.客戶Id == 客戶資料.Id).ToList();
            ViewBag.Contact = RepositoryHelper.Get客戶聯絡人Repository().All().Where(p => p.客戶Id == 客戶資料.Id).ToList();
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
        public ActionResult DeleteBank(int? id,int? cid)
        {

            客戶銀行資訊Repository repo = RepositoryHelper.Get客戶銀行資訊Repository();
            var e = repo.Find(p => p.Id == id);
            repo.Delete(e);

            return RedirectToAction("Details", new { id = cid });
        }
        public ActionResult DeleteContact(int? id, int? cid)
        {
            客戶聯絡人Repository repo = RepositoryHelper.Get客戶聯絡人Repository();
            var e = repo.Find(p => p.Id == id);
            repo.Delete(e);
            return RedirectToAction("Details", new { id = cid });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBatch(BatchUpdateViewModel form)
        {
            //TODO Model繫結時未觸發模型驗證，而在執行更新方法時觸發
            if (this.ModelState.IsValid)
            {
                var _bankrepo = RepositoryHelper.Get客戶銀行資訊Repository();
                var _contactrepo = RepositoryHelper.Get客戶聯絡人Repository();
                foreach (var item in form.bank)
                {
                    var e = _bankrepo.Find(p => p.Id == item.Id);
                    e.帳戶號碼 = item.帳戶號碼;
                    _bankrepo.Edit(e);
                }
                foreach (var item in form.contact)
                {
                    var e = _contactrepo.Find(p => p.Id == item.Id);
                    e.電話 = item.電話;
                    _contactrepo.Edit(e);
                }
            }
            return RedirectToAction("Index");
        }
        public ActionResult Export()
        {
            using (ExcelPackage p = new ExcelPackage())
            {
                ExcelWorksheet sheet = p.Workbook.Worksheets.Add("客戶資料");
                sheet.Cells[1, 1].Value = "客戶名稱";
                sheet.Cells[1, 2].Value = "統一編號";
                sheet.Cells[1, 3].Value = "電話";
                sheet.Cells[1, 4].Value = "傳真";
                sheet.Cells[1, 5].Value = "地址";
                sheet.Cells[1, 6].Value = "Email";
                int row = 2;
                var custom = CustomRepos.All();
                foreach (var item in custom)
                {
                    sheet.Cells[row, 1].Value = item.客戶名稱;
                    sheet.Cells[row, 2].Value = item.統一編號;
                    sheet.Cells[row, 3].Value = item.電話;
                    sheet.Cells[row, 4].Value = item.傳真;
                    sheet.Cells[row, 5].Value = item.地址;
                    sheet.Cells[row, 6].Value = item.Email;
                    row++;
                }
                
                return File(p.GetAsByteArray(), "application/vnd.ms-excel",string.Format( "{0}_客戶資料匯出.xlsx",DateTime.Now.ToString("yyyyMMdd")));
            }
            
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
