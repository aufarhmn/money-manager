﻿using ClientDataAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace ClientDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientContext _dbContext;

        public ClientsController(ClientContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Client>>> GetClient()
        {
            if(_dbContext.Clients == null)
            {
                return NotFound();
            }

            return await _dbContext.Clients.ToListAsync();
        }

        //GET BY ID
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            if(_dbContext.Clients == null)
            {
                return NotFound();
            }

            var client = await _dbContext.Clients.FindAsync(id);

            if(client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpGet("getByName/{name}")]
        public async Task<ActionResult<Client>> GetClient(string name)
        {
            if (_dbContext.Clients == null)
            {
                return NotFound();
            }

            var client = await _dbContext.Clients.FirstOrDefaultAsync(a => a.clientName == name);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        //POST
        [HttpPost("postAll")]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClient), new { Id = client.Id }, client);
        }

        //PUT
        [HttpPut("putById/{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if(id != client.Id)
            {
                return BadRequest();
            }

            _dbContext.Entry(client).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool ClientExist(long id)
        {
            return (_dbContext.Clients?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // DELETE
        [HttpDelete("deleteById/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (_dbContext.Clients == null)
            {
                return NotFound();
            }

            var client = await _dbContext.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

    }
}
