namespace Gqlpoc.GraphQL.Model.Query
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Album[] Albums { get; set; }
    }
}