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
using AutoMapper.QueryableExtensions;
using Vertise.Core.Data;
using Vertise.Repositories;
using Vertise.ViewModels;

namespace Vertise.Controllers.Api
{
    [Authorize]
    public class MessagesController : ApiController
    {
        private readonly IMessageRepository _repository;

        public MessagesController(IMessageRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Messages
        public IQueryable<MessageResult> GetMessages()
        {
            return _repository.All.Project().To<MessageResult>();
        }

        // GET: api/Messages/5
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> GetMessage(int id)
        {
            var message = await _repository.ByIdAsync(id);
            if (message == null){ return NotFound(); }

            return Ok(message);
        }

        // PUT: api/Messages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMessage(int id, Message message)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (id != message.Id) { return BadRequest(); }
            _repository.AddOrUpdate(message);
            try
            {
                await _repository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repository.Any(id)){ return NotFound(); }
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Messages
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> PostMessage(Message message)
        {
            if (!ModelState.IsValid){ return BadRequest(ModelState); }
            _repository.AddOrUpdate(message);
            await _repository.SaveChangesAsync();
            return CreatedAtRoute("DefaultApi", new { id = message.Id }, message);
        }

        // DELETE: api/Messages/5
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> DeleteMessage(int id)
        {
            var message = await _repository.ByIdAsync(id);
            if (message == null){ return NotFound(); }
            _repository.Delete(message);
            await _repository.SaveChangesAsync();
            return Ok(message);
        }

        protected override void Dispose(bool disposing){
            if (disposing){ _repository.Dispose();}
            base.Dispose(disposing);
        }
    }
}