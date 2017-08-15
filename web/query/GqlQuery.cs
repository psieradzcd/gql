namespace Gqlpoc.Web.Query
{
    public class GqlQuery
    {
        public string OperationName { get; set; }

        public string NamedQuery { get; set; }
        
        public string Query { get; set; }
        
        public string Variables { get; set; }
    }
}