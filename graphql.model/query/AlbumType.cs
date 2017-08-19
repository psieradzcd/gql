using GraphQL.Types;

namespace Gqlpoc.GraphQL.Model.Query
{
    public class AlbumType : ObjectGraphType<Album>
    {
        public AlbumType()
        {
            Name = "Album";

            Field(x => x.Title).Description("Album title");
        }
    }
}