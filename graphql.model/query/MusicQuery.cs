using Gqlpoc.Database.Repositories;
using Gqlpoc.GraphQL.Model.Utils;
using GraphQL.Types;

namespace Gqlpoc.GraphQL.Model.Query
{
    public class MusicQuery : ObjectGraphType
    {
        private readonly IArtistRepository _artistRepository;
        
        public MusicQuery(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
            Define();
        }

        protected virtual void Define()
        {
            Field<ArtistType>(
                "artist",
                arguments: new QueryArguments(
                    new IntArgument { Name = "id" }
                ),
                resolve: ctx => {
                    var id = ctx.GetArgument<int>("id");
                    var artist = _artistRepository.GetArtist(id);
                    return new Artist
                    {
                        Id = artist.Id,
                        Name = artist.Name
                    };
                }
            );
        }
    }
}