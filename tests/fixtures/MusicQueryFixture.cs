using System;
using Gqlpoc.Database.Repositories;
using Gqlpoc.GraphQL.Model.Query;
using GraphQL;
using GraphQL.Types;
using Tests.TestData;

namespace Tests.Fixtures
{
    public class MusicQueryFixture : IDisposable
    {
        public IArtistRepository Repository { get; }

        public MusicQuery Query { get; } 

        public ISchema Schema { get; }

        public IDocumentExecuter Executer { get; }

        public MusicQueryFixture()
        {
            Repository = new InMemoryArtistRepository();
            Query = new MusicQuery(Repository);
            Schema = new MusicSchema(
                Query, 
                new GraphType[] {
                    new AlbumType(),
                    new ArtistType(Repository) 
                }
            );
            Executer = new DocumentExecuter();
        }

        public void Dispose()
        {
            //noop
        }
    }
}