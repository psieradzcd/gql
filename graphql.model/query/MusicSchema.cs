using System;
using GraphQL.Types;

namespace Gqlpoc.GraphQL.Model.Query
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