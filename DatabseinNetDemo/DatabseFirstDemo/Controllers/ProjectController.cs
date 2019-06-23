using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabseFirstDemo.Models;

namespace DatabseFirstDemo.Controllers
{
    public class ProjectController : Controller
    {
        private ProjectTasksEntities db = new ProjectTasksEntities();

        // GET: /Project/
        public ActionResult Index()
        {
            var tblprojects = db.tblProjects.Include(t => t.tblContact).Include(t => t.tblContact1).Include(t => t.tblEndUser).Include(t => t.tblGroup).Include(t => t.tblPriority).Include(t => t.tblPublicity).Include(t => t.tblStatu);
            return View(tblprojects.ToList());
        }

        // GET: /Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProject tblproject = db.tblProjects.Find(id);
            if (tblproject == null)
            {
                return HttpNotFound();
            }
            return View(tblproject);
        }

        // GET: /Project/Create
        public ActionResult Create()
        {
            ViewBag.AssignedTo = new SelectList(db.tblContacts, "ContactID", "LastName");
            ViewBag.OpenedBy = new SelectList(db.tblContacts, "ContactID", "LastName");
            ViewBag.EndUserID = new SelectList(db.tblEndUsers, "EndUserID", "EndUserName");
            ViewBag.GroupID = new SelectList(db.tblGroups, "GroupID", "GroupName");
            ViewBag.PriorityID = new SelectList(db.tblPriorities, "PriorityID", "PriorityName");
            ViewBag.PublicityID = new SelectList(db.tblPublicities, "PublicityID", "PublicityName");
            ViewBag.StatusID = new SelectList(db.tblStatus, "StatusID", "StatusName");
            return View();
        }

        // POST: /Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ProjectID,EndUserID,AssignedTo,OpenedBy,OpenedDate,StatusID,ProjectName,SubCategory,PriorityID,Description,ScheduledStart,ActualStart,ScheduledFinish,EstFinish,ActualFinish,EstDurationDays,DateModified,RelatedIssues,Comments,PublicityID,PctComplete,MgrComments,GroupID")] tblProject tblproject)
        {
            if (ModelState.IsValid)
            {
                db.tblProjects.Add(tblproject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AssignedTo = new SelectList(db.tblContacts, "ContactID", "LastName", tblproject.AssignedTo);
            ViewBag.OpenedBy = new SelectList(db.tblContacts, "ContactID", "LastName", tblproject.OpenedBy);
            ViewBag.EndUserID = new SelectList(db.tblEndUsers, "EndUserID", "EndUserName", tblproject.EndUserID);
            ViewBag.GroupID = new SelectList(db.tblGroups, "GroupID", "GroupName", tblproject.GroupID);
            ViewBag.PriorityID = new SelectList(db.tblPriorities, "PriorityID", "PriorityName", tblproject.PriorityID);
            ViewBag.PublicityID = new SelectList(db.tblPublicities, "PublicityID", "PublicityName", tblproject.PublicityID);
            ViewBag.StatusID = new SelectList(db.tblStatus, "StatusID", "StatusName", tblproject.StatusID);
            return View(tblproject);
        }

        // GET: /Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProject tblproject = db.tblProjects.Find(id);
            if (tblproject == null)
            {
                return HttpNotFound();
            }
            ViewBag.AssignedTo = new SelectList(db.tblContacts, "ContactID", "LastName", tblproject.AssignedTo);
            ViewBag.OpenedBy = new SelectList(db.tblContacts, "ContactID", "LastName", tblproject.OpenedBy);
            ViewBag.EndUserID = new SelectList(db.tblEndUsers, "EndUserID", "EndUserName", tblproject.EndUserID);
            ViewBag.GroupID = new SelectList(db.tblGroups, "GroupID", "GroupName", tblproject.GroupID);
            ViewBag.PriorityID = new SelectList(db.tblPriorities, "PriorityID", "PriorityName", tblproject.PriorityID);
            ViewBag.PublicityID = new SelectList(db.tblPublicities, "PublicityID", "PublicityName", tblproject.PublicityID);
            ViewBag.StatusID = new SelectList(db.tblStatus, "StatusID", "StatusName", tblproject.StatusID);
            return View(tblproject);
        }

        // POST: /Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ProjectID,EndUserID,AssignedTo,OpenedBy,OpenedDate,StatusID,ProjectName,SubCategory,PriorityID,Description,ScheduledStart,ActualStart,ScheduledFinish,EstFinish,ActualFinish,EstDurationDays,DateModified,RelatedIssues,Comments,PublicityID,PctComplete,MgrComments,GroupID")] tblProject tblproject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblproject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AssignedTo = new SelectList(db.tblContacts, "ContactID", "LastName", tblproject.AssignedTo);
            ViewBag.OpenedBy = new SelectList(db.tblContacts, "ContactID", "LastName", tblproject.OpenedBy);
            ViewBag.EndUserID = new SelectList(db.tblEndUsers, "EndUserID", "EndUserName", tblproject.EndUserID);
            ViewBag.GroupID = new SelectList(db.tblGroups, "GroupID", "GroupName", tblproject.GroupID);
            ViewBag.PriorityID = new SelectList(db.tblPriorities, "PriorityID", "PriorityName", tblproject.PriorityID);
            ViewBag.PublicityID = new SelectList(db.tblPublicities, "PublicityID", "PublicityName", tblproject.PublicityID);
            ViewBag.StatusID = new SelectList(db.tblStatus, "StatusID", "StatusName", tblproject.StatusID);
            return View(tblproject);
        }

        // GET: /Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProject tblproject = db.tblProjects.Find(id);
            if (tblproject == null)
            {
                return HttpNotFound();
            }
            return View(tblproject);
        }

        // POST: /Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblProject tblproject = db.tblProjects.Find(id);
            db.tblProjects.Remove(tblproject);
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
