using GraphQL.Types;

namespace Gqlpoc.Web.Query
{
    public class AlbumInterface : InterfaceGraphType<Album>
    {
        public AlbumInterface()
        {
            Name = "Album";

            Field(x => x.Title).Description("Album title");
        }
    }
}