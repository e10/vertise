using System.Web.Http.OData.Query;
using AutoMapper.QueryableExtensions;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using Microsoft.AspNet.Identity;
using Vertise.Core.Data;
using Vertise.Repositories;
using Vertise.ViewModels;

namespace Vertise.Controllers.Api
{
    [Authorize]
    public class MessagesController : BasicApiController
    {
        private readonly IMessageRepository _repository;

        public MessagesController(IMessageRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Messages
        public PageResult<MessageResult> GetMessages(ODataQueryOptions<MessageResult> options)
        {
            return Page(_repository.All.Project().To<MessageResult>(),options);
        }

        // GET: api/Messages/5
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> GetMessage(int id)
        {
            var message = await _repository.ByIdAsync(id);
            if (message == null){ return NotFound(); }

            return Ok(message);
        }

        // POST: api/Messages
        [ResponseType(typeof(Message))]
        public async Task<IHttpActionResult> PostMessage(MessageCreateModel model)
        {
            if (!ModelState.IsValid){ return BadRequest(ModelState); }
            var message = model.ToEntity(User.Identity.GetUserId());
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