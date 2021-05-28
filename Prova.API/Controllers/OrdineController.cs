using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prova.Core.BusinessLayer;
using Prova.Core.EF.Repository;
using Prova.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdineController : ControllerBase
    {
        private ILibraryBL businessLayer;

        public OrdineController()
        {
            var clienteRepo = new EFClienteRepository();
            var ordineRepo = new EFOrdineRepository();
            this.businessLayer = new LibraryBL(clienteRepo, ordineRepo);
        }

        // GET
        [HttpGet]
        public ActionResult Get()
        {
            var result = this.businessLayer.FetchOrdini();

            return Ok(result);
        }

        // GET 
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Ordine ID.");

            var ordine = this.businessLayer.FetchOrdineById(id);

            if (ordine == null)
                return NotFound($"Ordine with ID = {id} is missing.");

            return Ok(ordine);
        }

        // POST
        [HttpPost]
        public ActionResult Post([FromBody] Ordine newOrdine)
        {
            if (newOrdine == null)
                return BadRequest("Invalid Ordine data.");

            this.businessLayer.CreateOrdine(newOrdine);

            return Created($"/ordine/{newOrdine.ID}", newOrdine);
        }

        // PUT
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ordine editedOrdine)
        {
            if (editedOrdine == null)
                return BadRequest("Invalid Ordine data.");

            if (id != editedOrdine.ID)
                return BadRequest("Ordine IDs don't match.");

            this.businessLayer.EditOrdine(editedOrdine);

            return Ok();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Ordine ID.");

            var ordineToBeDeleted = this.businessLayer.FetchOrdineById(id);

            if (ordineToBeDeleted != null)
                this.businessLayer.DeleteOrdine(ordineToBeDeleted);

            return Ok();
        }
    }
}
