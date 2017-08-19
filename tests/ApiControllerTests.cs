using System;
using System.Threading.Tasks;
using GraphQL.Types;
using NSubstitute;
using Xunit;
using Gqlpoc.Web.Controllers;
using GraphQL;
using Gqlpoc.Web;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Tests.Fixtures;

namespace Tests
{
    public class ApiControllerTests : IClassFixture<GraphQLFixture>
    {
        private readonly GraphQLFixture _fixture;

        public ApiControllerTests(GraphQLFixture fixture)
        {
            this._fixture = fixture;
        }

        [Fact]
        public async Task WhenValidQueryIsPassed_OkResultIsReturned()
        {
            var executionResult = new ExecutionResult();

            _fixture.Doc.ExecuteAsync(Arg.Any<ExecutionOptions>()).Returns(Task.FromResult(executionResult));

            var controller = new ApiController(_fixture.Doc, _fixture.Schema);
            var result = await controller.Get(new GqlQuery { Variables = new Dictionary<string, object>() });

            Assert.IsType(typeof(OkObjectResult), result);
        }

        [Fact]
        public async Task WhenInvalidQueryIsPassed_BadRequestResultIsReturned()
        {
            var executionResult = new ExecutionResult
            {
                Errors = _fixture.Errors
            };
         
            _fixture.Doc.ExecuteAsync(Arg.Any<ExecutionOptions>()).Returns(Task.FromResult(executionResult));

            var controller = new ApiController(_fixture.Doc, _fixture.Schema);
            var result = await controller.Get(new GqlQuery { Variables = new Dictionary<string, object>() });

            Assert.IsType(typeof(BadRequestObjectResult), result);
        }

        [Fact]
        public async Task WhenNoQueryIsPassed_BadRequestResultIsReturned()
        {
            var controller = new ApiController(_fixture.Doc, _fixture.Schema);
            var result = await controller.Get(null);

            Assert.IsType(typeof(BadRequestObjectResult), result);
       }
    }
}
