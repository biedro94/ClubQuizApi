using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizApi.Models;
using Newtonsoft.Json;

namespace QuizApi.Controllers
{
    public class ScoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Scores
        public string Index()
        {
            
            string json = JsonConvert.SerializeObject(db.Scores.ToList().OrderByDescending(u => u.score).Take(10), Formatting.Indented);
            return json;
        }

        // GET: Scores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scores scores = db.Scores.Find(id);
            if (scores == null)
            {
                return HttpNotFound();
            }
            return View(scores);
        }

        //// GET: Scores/Create
        //public string Create()
        //{
            
        //}

        // POST: Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Scores/Create")]
        public int Create(string name, int score)
        {
            Scores scores= new Scores();
            scores.name = name;
            scores.score = score;

            try
            {
                db.Scores.Add(scores);
                db.SaveChanges();                
            }
            catch (Exception e)
            {
                return 0;
            }
            return 1;

        }
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,name,score")] Scores scores)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Scores.Add(scores);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(scores);
        //}

        // GET: Scores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scores scores = db.Scores.Find(id);
            if (scores == null)
            {
                return HttpNotFound();
            }
            return View(scores);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,score")] Scores scores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scores);
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scores scores = db.Scores.Find(id);
            if (scores == null)
            {
                return HttpNotFound();
            }
            return View(scores);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scores scores = db.Scores.Find(id);
            db.Scores.Remove(scores);
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
