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
using System.Web.UI.WebControls;
using api_rest_logistics.Models;
using api_rest_logistics.Security;

namespace api_rest_logistics.Controllers
{
    [Authorize]
    public class EntregaTipoProductosController : ApiController
    {
        private Model db = new Model();

        // GET: api/EntregaTipoProductos
        public IQueryable<EntregaTipoProducto> GetEntregaTipoProducto()
        {
            return db.EntregaTipoProducto;
        }

        // GET: api/EntregaTipoProductos/5
        [ResponseType(typeof(EntregaTipoProducto))]
        public async Task<IHttpActionResult> GetEntregaTipoProducto(int id)
        {
            EntregaTipoProducto entregaTipoProducto = await db.EntregaTipoProducto.FindAsync(id);
            if (entregaTipoProducto == null)
            {
                return NotFound();
            }

            return Ok(entregaTipoProducto);
        }

        // PUT: api/EntregaTipoProductos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEntregaTipoProducto(int id, EntregaTipoProducto entregaTipoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entregaTipoProducto.IdEntregaTipoProducto)
            {
                return BadRequest();
            }

            db.Entry(entregaTipoProducto).State = EntityState.Modified;

            try
            {
                try
                {
                    using (Model db = new Model())
                    {
                        var lst = db.TipoProducto
                        .Where(d => d.IdTipoProducto == entregaTipoProducto.TipoProductoId);

                        if (lst.Count() > 0)
                        {
                            foreach (var item in lst)
                            {
                                entregaTipoProducto.Precio = item.Precio;
                                entregaTipoProducto.Total = entregaTipoProducto.Cantidad * entregaTipoProducto.Precio;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntregaTipoProductoExists(id))
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

        // POST: api/EntregaTipoProductos
        [ResponseType(typeof(EntregaTipoProducto))]
        public async Task<IHttpActionResult> PostEntregaTipoProducto(EntregaTipoProducto entregaTipoProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                using (Model db = new Model())
                {
                    var lst = db.TipoProducto
                    .Where(d => d.IdTipoProducto == entregaTipoProducto.TipoProductoId);

                    if (lst.Count() > 0)
                    {
                        foreach (var item in lst)
                        {
                            entregaTipoProducto.Precio = item.Precio;
                            entregaTipoProducto.Total = entregaTipoProducto.Cantidad * entregaTipoProducto.Precio;
                        }
                    }                   
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            db.EntregaTipoProducto.Add(entregaTipoProducto);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = entregaTipoProducto.IdEntregaTipoProducto }, entregaTipoProducto);



        }

        // DELETE: api/EntregaTipoProductos/5
        [ResponseType(typeof(EntregaTipoProducto))]
        public async Task<IHttpActionResult> DeleteEntregaTipoProducto(int id)
        {
            EntregaTipoProducto entregaTipoProducto = await db.EntregaTipoProducto.FindAsync(id);
            if (entregaTipoProducto == null)
            {
                return NotFound();
            }

            db.EntregaTipoProducto.Remove(entregaTipoProducto);
            await db.SaveChangesAsync();

            return Ok(entregaTipoProducto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EntregaTipoProductoExists(int id)
        {
            return db.EntregaTipoProducto.Count(e => e.IdEntregaTipoProducto == id) > 0;
        }
    }
}