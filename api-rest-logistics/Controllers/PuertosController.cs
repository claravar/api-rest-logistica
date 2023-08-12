using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using api_rest_logistics.Models;

namespace api_rest_logistics.Controllers
{
    [Authorize]
    public class PuertosController : ApiController
    {
        private Model db = new Model();

        // GET: api/Puertos
        public IQueryable<Puerto> GetPuerto()
        {
            return db.Puerto;
        }

        // GET: api/Puertos/5
        [ResponseType(typeof(Puerto))]
        public async Task<IHttpActionResult> GetPuerto(int id)
        {
            Puerto puerto = await db.Puerto.FindAsync(id);
            if (puerto == null)
            {
                return NotFound();
            }

            return Ok(puerto);
        }

        // PUT: api/Puertos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPuerto(int id, Puerto puerto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != puerto.IdPuerto)
            {
                return BadRequest();
            }

            db.Entry(puerto).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuertoExists(id))
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

        // POST: api/Puertos
        [ResponseType(typeof(Puerto))]
        public async Task<IHttpActionResult> PostPuerto(Puerto puerto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Puerto.Add(puerto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = puerto.IdPuerto }, puerto);
        }

        // DELETE: api/Puertos/5
        [ResponseType(typeof(Puerto))]
        public async Task<IHttpActionResult> DeletePuerto(int id)
        {
            Puerto puerto = await db.Puerto.FindAsync(id);
            if (puerto == null)
            {
                return NotFound();
            }

            db.Puerto.Remove(puerto);
            await db.SaveChangesAsync();

            return Ok(puerto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PuertoExists(int id)
        {
            return db.Puerto.Count(e => e.IdPuerto == id) > 0;
        }
    }
}