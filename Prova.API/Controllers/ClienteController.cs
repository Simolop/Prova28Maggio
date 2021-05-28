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
    public class ClienteController : ControllerBase
    {
        private ILibraryBL businessLayer;

        public ClienteController()
        {
            var clienteRepo = new EFClienteRepository();
            var ordineRepo = new EFOrdineRepository();
            this.businessLayer = new LibraryBL(clienteRepo, ordineRepo);
        }

        // GET
        [HttpGet]
        public ActionResult Get()
        {
            var result = this.businessLayer.FetchClienti();

            return Ok(result);
        }

            // GET 
            [HttpGet("{id}")]
            public ActionResult Get(int id)
            {
                if (id <= 0)
                    return BadRequest("Invalid Cliente ID.");

                var cliente = this.businessLayer.FetchClienteByID(id);

                if (cliente == null)
                    return NotFound($"Cliente with ID = {id} is missing.");

                return Ok(cliente);
            }

            // POST 
            [HttpPost]
            public ActionResult Post([FromBody] Cliente newCliente)
            {
                if (newCliente == null)
                    return BadRequest("Invalid Cliente data.");

                this.businessLayer.CreateCliente(newCliente);

                return Created($"/cliente/{newCliente.ID}", newCliente);
            }

            // PUT 
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] Cliente editedCliente)
            {
                if (editedCliente == null)
                    return BadRequest("Invalid Cliente data.");

                if (id != editedCliente.ID)
                    return BadRequest("Cliente IDs don't match.");

                this.businessLayer.EditCliente(editedCliente);

                return Ok();
            }

            // DELETE 
            [HttpDelete("{id}")]
            public ActionResult Delete(int id)
            {
                if (id <= 0)
                    return BadRequest("Invalid Cliente ID.");

                var clienteToBeDeleted = this.businessLayer.FetchClienteByID(id);

                if (clienteToBeDeleted != null)
                    this.businessLayer.DeleteCliente(clienteToBeDeleted);

                return Ok();
            }
    }
}
