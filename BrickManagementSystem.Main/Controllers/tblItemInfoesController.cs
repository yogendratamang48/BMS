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
    public class tblItemInfoesController : Controller
    {
        private BrickManagementDBEntities db = new BrickManagementDBEntities();

        // GET: tblItemInfoes
        public ActionResult Index()
        {
            var tblItemInfoes = db.tblItemInfoes.Include(t => t.tblRequisitionForm);
            return View(tblItemInfoes.ToList());
        }

        // GET: tblItemInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemInfo tblItemInfo = db.tblItemInfoes.Find(id);
            if (tblItemInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblItemInfo);
        }
        public ActionResult Save(string itemData) {

            return View();
        }
        // GET: tblItemInfoes/Create
        public ActionResult Create(int? reqID)
        {
            if (reqID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            ViewBag.ReqID = reqID;
            return View();
        }

        // POST: tblItemInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ReqID,KhataNumber,ItemName,Quantity,Unit,Remarks")] tblItemInfo tblItemInfo)
        {
            if (ModelState.IsValid)
            {
                db.tblItemInfoes.Add(tblItemInfo);
                db.SaveChanges();
                return RedirectToAction("Create", "tblItemInfoes", new { reqID = tblItemInfo.ReqID });
            }

            ViewBag.ReqID = tblItemInfo.ReqID;
            return RedirectToAction("Create", "tblItemInfoes", new { reqID = ViewBag.ReqID });
        }

        // GET: tblItemInfoes/Edit/5


        public ActionResult ShowItems(int? reqID) {
            if (reqID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var lstItems = db.tblItemInfoes.Where(m => m.ReqID == reqID).ToList();
            return PartialView("ShowItems", lstItems);
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
