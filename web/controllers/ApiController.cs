using System;
using System.Threading.Tasks;
using Gqlpoc.Database.Repositories;
using Gqlpoc.Web.Query;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gqlpoc.Web.Controllers
{
    [Route("api")]
    public class ApiController : Controller
    {   
        private IDocumentExecuter _documentExecuter { get; set; }
        private readonly ISchema _schema;

        public ApiController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody]GqlQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            var executionOptions = new ExecutionOptions { 
                Schema = _schema, 
                Query = query.Query,
                Inputs = query.Variables.ToInputs()
            };
            try
            {
                var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

                if (result.Errors?.Count > 0) return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }        
        }
    }
}