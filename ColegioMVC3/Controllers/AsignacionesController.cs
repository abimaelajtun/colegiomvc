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
    public class AsignacionesController : Controller
    {
        private ColegioDb db = new ColegioDb();

        // GET: Asignaciones
        public ActionResult Index()
        {
            var alumnosGrados = db.AlumnosGrados.Include(a => a.Alumno).Include(a => a.Grado);
            return View(alumnosGrados.ToList());
        }

        // GET: Asignaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoGrado alumnoGrado = db.AlumnosGrados.Find(id);
            if (alumnoGrado == null)
            {
                return HttpNotFound();
            }            
            return View(alumnoGrado);
        }

        // GET: Asignaciones/Create
        public ActionResult Create()
        {
            loadCreateAlumnosyGrados();
            return View();
        }

        private void loadCreateAlumnosyGrados()
        {
            //Lista personalizada de alumnos
            Dictionary<int, string> listadoAlumnos = new Dictionary<int, string>();
            foreach (Alumno alumno in db.Alumnos)
            {
                int llave = alumno.AlumnoId;
                String valor = alumno.AlumnoId + " - " + alumno.Nombres;
                listadoAlumnos.Add(llave, valor);
            }

            //Lista personalizada de alumnos
            Dictionary<int, string> listadoGrados = new Dictionary<int, string>();
            foreach (Grado grado in db.Grados)
            {
                int llave = grado.GradoId;
                String valor = grado.GradoId + " - " + grado.Nombre;
                listadoGrados.Add(llave, valor);
            }

            ViewBag.AlumnoId = new SelectList(listadoAlumnos, "Key", "Value");
            ViewBag.GradoId = new SelectList(listadoGrados, "Key", "Value");
        }

        // POST: Asignaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlumnoGradoId,Seccion,AlumnoId,GradoId")] AlumnoGrado alumnoGrado)
        {
            if (ModelState.IsValid)
            {
                db.AlumnosGrados.Add(alumnoGrado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            loadEditAlumnosyGrados(alumnoGrado.AlumnoId, alumnoGrado.GradoId);
            return View(alumnoGrado);
        }

        // GET: Asignaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoGrado alumnoGrado = db.AlumnosGrados.Find(id);
            if (alumnoGrado == null)
            {
                return HttpNotFound();
            }
            loadEditAlumnosyGrados(alumnoGrado.AlumnoId, alumnoGrado.GradoId);
            return View(alumnoGrado);
        }

        private void loadEditAlumnosyGrados(int alumnoId,int gradoId)
        {
            //Lista personalizada de alumnos
            Dictionary<int, string> listadoAlumnos = new Dictionary<int, string>();
            foreach (Alumno alumno in db.Alumnos)
            {
                int llave = alumno.AlumnoId;
                String valor = alumno.AlumnoId + " - " + alumno.Nombres;
                listadoAlumnos.Add(llave, valor);
            }

            //Lista personalizada de alumnos
            Dictionary<int, string> listadoGrados = new Dictionary<int, string>();
            foreach (Grado grado in db.Grados)
            {
                int llave = grado.GradoId;
                String valor = grado.GradoId + " - " + grado.Nombre;
                listadoGrados.Add(llave, valor);
            }

            ViewBag.AlumnoId = new SelectList(listadoAlumnos, "Key", "Value",alumnoId);
            ViewBag.GradoId = new SelectList(listadoGrados, "Key", "Value",gradoId);
        }

        // POST: Asignaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlumnoGradoId,Seccion,AlumnoId,GradoId")] AlumnoGrado alumnoGrado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alumnoGrado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            loadEditAlumnosyGrados(alumnoGrado.AlumnoId, alumnoGrado.GradoId);
            return View(alumnoGrado);
        }

        // GET: Asignaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlumnoGrado alumnoGrado = db.AlumnosGrados.Find(id);
            if (alumnoGrado == null)
            {
                return HttpNotFound();
            }
            return View(alumnoGrado);
        }

        // POST: Asignaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlumnoGrado alumnoGrado = db.AlumnosGrados.Find(id);
            db.AlumnosGrados.Remove(alumnoGrado);
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
