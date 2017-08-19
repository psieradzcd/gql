using System;
using NSubstitute;
using GraphQL.Types;
using GraphQL;

namespace Tests.Fixtures
{
    public class GraphQLFixture : IDisposable
    {
        public ISchema Schema { get; set; }       

        public IDocumentExecuter Doc { get; set; }

        public ExecutionErrors Errors { get; set; }

        public GraphQLFixture()
        {
            Schema = Substitute.For<ISchema>();
            Doc = Substitute.For<IDocumentExecuter>();
            Errors = new ExecutionErrors();
            Errors.Add(new ExecutionError("wrong"));
        }

        public void Dispose()
        {
            //noop
        }
    }
}