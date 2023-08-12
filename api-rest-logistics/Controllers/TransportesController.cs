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
    public class TransportesController : ApiController
    {
        private Model db = new Model();

        // GET: api/Transportes
        public IQueryable<Transporte> GetTransporte()
        {
            return db.Transporte;
        }

        // GET: api/Transportes/5
        [ResponseType(typeof(Transporte))]
        public async Task<IHttpActionResult> GetTransporte(int id)
        {
            Transporte transporte = await db.Transporte.FindAsync(id);
            if (transporte == null)
            {
                return NotFound();
            }

            return Ok(transporte);
        }

        // PUT: api/Transportes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTransporte(int id, Transporte transporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transporte.IdTransporte)
            {
                return BadRequest();
            }

            db.Entry(transporte).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransporteExists(id))
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

        // POST: api/Transportes
        [ResponseType(typeof(Transporte))]
        public async Task<IHttpActionResult> PostTransporte(Transporte transporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


           if(!FlotaExists(transporte.Flota) && (transporte.Placa == "")){
                db.Transporte.Add(transporte);
                await db.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError(nameof(transporte.Flota), $"El nombre {transporte.Flota} ya existe.");
                return BadRequest(ModelState);
            }
            
            if(!PlacaExists(transporte.Placa) && (transporte.Flota == ""))
            {
                db.Transporte.Add(transporte);
                await db.SaveChangesAsync();
            }
            else
            {
                ModelState.AddModelError(nameof(transporte.Placa), $"El nombre {transporte.Placa} ya existe.");
                return BadRequest(ModelState);
            }

            return CreatedAtRoute("DefaultApi", new { id = transporte.IdTransporte }, transporte);

        }

        // DELETE: api/Transportes/5
        [ResponseType(typeof(Transporte))]
        public async Task<IHttpActionResult> DeleteTransporte(int id)
        {
            Transporte transporte = await db.Transporte.FindAsync(id);
            if (transporte == null)
            {
                return NotFound();
            }

            db.Transporte.Remove(transporte);
            await db.SaveChangesAsync();

            return Ok(transporte);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransporteExists(int id)
        {
            return db.Transporte.Count(e => e.IdTransporte == id) > 0;
        }

        private bool FlotaExists(string flota)
        {
            return db.Transporte.Count(e => e.Flota.ToUpper() == flota.ToUpper()) > 0;
        }

        private bool PlacaExists(string placa)
        {
            return db.Transporte.Count(e => e.Placa.ToUpper() == placa.ToUpper()) > 0;
        }
    }
}