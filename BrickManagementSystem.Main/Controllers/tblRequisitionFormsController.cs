using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BrickManagementSystem.Main.Models;
using BrickManagementSystem.Main.Models.ViewModels;

namespace BrickManagementSystem.Main.Controllers
{
    public class tblRequisitionFormsController : Controller
    {
        private BrickManagementDBEntities db = new BrickManagementDBEntities();
        public static List<tblItemInfo> lstItems = new List<tblItemInfo>();
        public bool IsAllDataObtained = false;

      
        [HttpPost]

        public ActionResult SaveItems(List<Item> serializedData) {
        //        
        var lstItem = serializedData;
        List<tblItemInfo> lstInnerItems = new List<tblItemInfo>();
        foreach (var item in lstItem)
        {
            tblItemInfo i = new tblItemInfo
            {
                ItemName = item.ItemName,
                KhataNumber = item.KhataNumber,
                Quantity = Convert.ToInt32(item.Quantity),
                Unit = item.Unit,
                Remarks = item.Remarks

            };
            lstInnerItems.Add(i);
        }
        lstItems = lstInnerItems;
            IsAllDataObtained = true;
        var result = new { Success = "True", Message = "Error Message" };

        return Json(result, JsonRequestBehavior.AllowGet);

    }

        // GET: tblRequisitionForms
        public ActionResult Index()
        {
            var tblRequisitionForms = db.tblRequisitionForms.Include(t => t.mstCompanyInfo);
            return View(tblRequisitionForms.ToList());
        }

        public ActionResult GetData() {
            var lstForms = db.tblRequisitionForms.Select(x => new { EmployeeName = x.EmployeeName, Purpose = x.Purpose, RequestedDate = x.RequestedDate.ToString(), CreatedBy = x.CreatedBy, CompanyID=x.mstCompanyInfo.Name });
            return Json(lstForms , JsonRequestBehavior.AllowGet);
        }

        // GET: tblRequisitionForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRequisitionForm tblRequisitionForm = db.tblRequisitionForms.Find(id);
            if (tblRequisitionForm == null)
            {
                return HttpNotFound();
            }
            return View(tblRequisitionForm);
        }

        // GET: tblRequisitionForms/Create
        public ActionResult Create()
        {

            ViewBag.CompanyID = new SelectList(db.mstCompanyInfoes, "CompanyID", "Name");
            ViewBag.Author = "DefaultAuthor";
            return View();
        }

        // POST: tblRequisitionForms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReqID,CompanyID,EmployeeName,Purpose,RequestedDate,CreatedBy")] tblRequisitionForm tblRequisitionForm)
        {
            if (ModelState.IsValid)
            {
                db.tblRequisitionForms.Add(tblRequisitionForm);
                db.SaveChanges();
                
                foreach(tblItemInfo i in lstItems) {
                        i.ReqID = tblRequisitionForm.ReqID;
                        db.tblItemInfoes.Add(i);

                }
                    db.SaveChanges();
               
               
                return RedirectToAction("Index");
            }

            ViewBag.CompanyID = new SelectList(db.mstCompanyInfoes, "CompanyID", "Name", tblRequisitionForm.CompanyID);
            return View(tblRequisitionForm);
        }

        // GET: tblRequisitionForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRequisitionForm tblRequisitionForm = db.tblRequisitionForms.Find(id);
            if (tblRequisitionForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyID = new SelectList(db.mstCompanyInfoes, "CompanyID", "Name", tblRequisitionForm.CompanyID);
            return View(tblRequisitionForm);
        }

        // POST: tblRequisitionForms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReqID,CompanyID,EmployeeName,Purpose,RequestedDate,CreatedBy")] tblRequisitionForm tblRequisitionForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblRequisitionForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyID = new SelectList(db.mstCompanyInfoes, "CompanyID", "Name", tblRequisitionForm.CompanyID);
            return View(tblRequisitionForm);
        }

        // GET: tblRequisitionForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblRequisitionForm tblRequisitionForm = db.tblRequisitionForms.Find(id);
            if (tblRequisitionForm == null)
            {
                return HttpNotFound();
            }
            return View(tblRequisitionForm);
        }

        // POST: tblRequisitionForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblRequisitionForm tblRequisitionForm = db.tblRequisitionForms.Find(id);
            db.tblRequisitionForms.Remove(tblRequisitionForm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SubmitToRequisition(int? reqID) {

            IncomingDemand incomingDemand = new IncomingDemand { ReqID = reqID };
            db.IncomingDemands.Add(incomingDemand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
