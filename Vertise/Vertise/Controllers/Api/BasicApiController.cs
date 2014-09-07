using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;

namespace Vertise.Controllers.Api
{
    public class BasicApiController : ApiController
    {
        protected PageResult<T> Page<T>(IQueryable<T> query, ODataQueryOptions<T> options) {
            IQueryable results = options.ApplyTo(query, new ODataQuerySettings() { PageSize = options.Top == null ? 20 : (options.Top.Value > 200 ? 200 : options.Top.Value) });
            return new PageResult<T>(results as IEnumerable<T>, Request.ODataProperties().NextLink, Request.ODataProperties().TotalCount);
        }
    }
}