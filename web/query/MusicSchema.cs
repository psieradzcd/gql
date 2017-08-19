using System;
using GraphQL.Types;

namespace Gqlpoc.Web.Query
{
    public class MusicSchema : Schema
    {
        public MusicSchema(MusicQuery query, IGraphType[] relatedTypes)
        {
            RegisterTypes(relatedTypes);
            Query = query;
        }
    }
}