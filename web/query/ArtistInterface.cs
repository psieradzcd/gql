using Gqlpoc.Database.Repositories;
using GraphQL.Types;

namespace Gqlpoc.Web.Query
{
    public class ArtistInterface : InterfaceGraphType<Artist>
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistInterface(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        protected virtual void Define() 
        {

            Name = "Artist";

            Field(x => x.Id).Description("The Id of the artist");
            Field(x => x.Name).Description("Artist name");

            Field<ListGraphType<AlbumInterface>>(
                "albums",
                resolve: ctx =>
                {
                    var albums = _artistRepository.GetAlbums(ctx.Source.Id);
                    return albums;
                });
        }
    }
}