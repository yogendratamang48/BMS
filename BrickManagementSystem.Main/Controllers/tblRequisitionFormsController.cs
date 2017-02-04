using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BrickManagementSystem.Main.Models;

namespace BrickManagementSystem.Main.Controllers
{
    public class tblRequisitionFormsController : Controller
    {
        private BrickManagementDBEntities db = new BrickManagementDBEntities();

        // GET: tblRequisitionForms
        public ActionResult Index()
        {
            var tblRequisitionForms = db.tblRequisitionForms.Include(t => t.mstCompanyInfo);
            return View(tblRequisitionForms.ToList());
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
