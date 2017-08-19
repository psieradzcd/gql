using System.Collections.Generic;

namespace Gqlpoc.Web
{
    public class GqlQuery
    {
        public string OperationName { get; set; }

        public string NamedQuery { get; set; }
        
        public string Query { get; set; }
        
        public Dictionary<string, object> Variables { get; set; }
    }
}