using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ColegioMVC3.Models;

namespace ColegioMVC3.Controllers
{
    public class GradosController : Controller
    {
        private ColegioDb db = new ColegioDb();

        // GET: Grados
        public ActionResult Index()
        {
            var grados = db.Grados.Include(g => g.Profesor);
            return View(grados.ToList());
        }

        // GET: Grados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Grados.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // GET: Grados/Create
        public ActionResult Create()
        {
            Dictionary<int, string> listadoProfesores = new Dictionary<int, string>();            
            foreach(Profesor profesor in db.Profesores)
            {
                int llave = profesor.ProfesorId;
                String valor = profesor.ProfesorId + " - " + profesor.Nombres;
                listadoProfesores.Add(llave, valor);
            }
            ViewBag.ProfesorId = new SelectList(listadoProfesores,"Key","Value");
            return View();
        }

        // POST: Grados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GradoId,Nombre,ProfesorId")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Grados.Add(grado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfesorId = new SelectList(db.Profesores, "ProfesorId", "Nombres", grado.ProfesorId);
            return View(grado);
        }

        // GET: Grados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Grados.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            //Lista personalizada de profesores
            Dictionary<int, string> listadoProfesores = new Dictionary<int, string>();
            foreach (Profesor profesor in db.Profesores)
            {
                int llave = profesor.ProfesorId;
                String valor = profesor.ProfesorId + " - " + profesor.Nombres;
                listadoProfesores.Add(llave, valor);
            }
            ViewBag.ProfesorId = new SelectList(listadoProfesores, "Key", "Value",grado.ProfesorId);            
            return View(grado);
        }

        // POST: Grados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GradoId,Nombre,ProfesorId")] Grado grado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfesorId = new SelectList(db.Profesores, "ProfesorId", "Nombres", grado.ProfesorId);
            return View(grado);
        }

        // GET: Grados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grado grado = db.Grados.Find(id);
            if (grado == null)
            {
                return HttpNotFound();
            }
            return View(grado);
        }

        // POST: Grados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grado grado = db.Grados.Find(id);
            db.Grados.Remove(grado);
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
