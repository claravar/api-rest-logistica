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
    public class EntregasController : ApiController
    {
        private Model db = new Model();

        // GET: api/Entregas
        public IQueryable<Entrega> GetEntrega()
        {
            return db.Entrega;
        }

        // GET: api/Entregas/5
        [ResponseType(typeof(Entrega))]
        public async Task<IHttpActionResult> GetEntrega(int id)
        {
            Entrega entrega = await db.Entrega.FindAsync(id);
            if (entrega == null)
            {
                return NotFound();
            }

            return Ok(entrega);
        }

        // PUT: api/Entregas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEntrega(int id, Entrega entrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entrega.IdEntrega)
            {
                return BadRequest();
            }

            db.Entry(entrega).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregaExists(id))
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

        // POST: api/Entregas
        [ResponseType(typeof(Entrega))]
        public async Task<IHttpActionResult> PostEntrega(Entrega entrega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entrega.Add(entrega);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = entrega.IdEntrega }, entrega);
        }

        // DELETE: api/Entregas/5
        [ResponseType(typeof(Entrega))]
        public async Task<IHttpActionResult> DeleteEntrega(int id)
        {
            Entrega entrega = await db.Entrega.FindAsync(id);
            if (entrega == null)
            {
                return NotFound();
            }

            db.Entrega.Remove(entrega);
            await db.SaveChangesAsync();

            return Ok(entrega);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntregaExists(int id)
        {
            return db.Entrega.Count(e => e.IdEntrega == id) > 0;
        }
    }
}