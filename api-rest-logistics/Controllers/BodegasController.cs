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
    public class BodegasController : ApiController
    {
        private Model db = new Model();

        // GET: api/Bodegas
        public IQueryable<Bodega> GetBodega()
        {
            return db.Bodega;
        }

        // GET: api/Bodegas/5
        [ResponseType(typeof(Bodega))]
        public async Task<IHttpActionResult> GetBodega(int id)
        {
            Bodega bodega = await db.Bodega.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }

            return Ok(bodega);
        }

        // PUT: api/Bodegas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBodega(int id, Bodega bodega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bodega.IdBodega)
            {
                return BadRequest();
            }

            db.Entry(bodega).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BodegaExists(id))
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

        // POST: api/Bodegas
        [ResponseType(typeof(Bodega))]
        public async Task<IHttpActionResult> PostBodega(Bodega bodega)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bodega.Add(bodega);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bodega.IdBodega }, bodega);
        }

        // DELETE: api/Bodegas/5
        [ResponseType(typeof(Bodega))]
        public async Task<IHttpActionResult> DeleteBodega(int id)
        {
            Bodega bodega = await db.Bodega.FindAsync(id);
            if (bodega == null)
            {
                return NotFound();
            }

            db.Bodega.Remove(bodega);
            await db.SaveChangesAsync();

            return Ok(bodega);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BodegaExists(int id)
        {
            return db.Bodega.Count(e => e.IdBodega == id) > 0;
        }
    }
}