using Gqlpoc.Database.Repositories;
using GraphQL.Types;

namespace Gqlpoc.Web.Query
{
    public class MusicQuery : ObjectGraphType
    {
        private readonly IArtistRepository _artistRepository;
        public MusicQuery(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        protected virtual void Define()
        {
            Field<ArtistInterface>(
                "artist",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                ),
                resolve: ctx => {
                    var id = ctx.GetArgument<int>("id");
                    var artist = _artistRepository.GetArtist(id);
                    return artist;
                }
            );
        }
    }
}