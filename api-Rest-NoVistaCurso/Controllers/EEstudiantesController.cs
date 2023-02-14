using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using api_Rest_NoVistaCurso;

namespace api_Rest_NoVistaCurso.Controllers
{
    public class EEstudiantesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/EEstudiantes
        public IQueryable<EEstudiantes> GetEEstudiantes()
        {
            return db.EEstudiantes;
        }

        // GET: api/EEstudiantes/5
        [ResponseType(typeof(EEstudiantes))]
        public IHttpActionResult GetEEstudiantes(int id)
        {
            EEstudiantes eEstudiantes = db.EEstudiantes.Find(id);
            if (eEstudiantes == null)
            {
                return NotFound();
            }

            return Ok(eEstudiantes);
        }


        // PUT: api/EEstudiantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEEstudiantes(int id, EEstudiantes eEstudiantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eEstudiantes.IdEstudiante)
            {
                return BadRequest();
            }

            db.Entry(eEstudiantes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EEstudiantesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EEstudiantes
        [ResponseType(typeof(EEstudiantes))]
        public IHttpActionResult PostEEstudiantes(EEstudiantes eEstudiantes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EEstudiantes.Add(eEstudiantes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eEstudiantes.IdEstudiante }, eEstudiantes);
        }

        // DELETE: api/EEstudiantes/5
        [ResponseType(typeof(EEstudiantes))]
        public IHttpActionResult DeleteEEstudiantes(int id)
        {
            EEstudiantes eEstudiantes = db.EEstudiantes.Find(id);
            if (eEstudiantes == null)
            {
                return NotFound();
            }

            db.EEstudiantes.Remove(eEstudiantes);
            db.SaveChanges();

            return Ok(eEstudiantes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EEstudiantesExists(int id)
        {
            return db.EEstudiantes.Count(e => e.IdEstudiante == id) > 0;
        }
    }
}