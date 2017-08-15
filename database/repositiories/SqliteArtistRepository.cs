using System.Collections.Generic;
using System.Linq;
using Gqlpoc.Database;
using Gqlpoc.Database.Poco;
using NPoco;
using NPoco.Linq;

namespace Gqlpoc.Database.Repositories
{
    public class SqliteArtistRepository : IArtistRepository
    {
        private readonly IDatabase _db;

        public SqliteArtistRepository(IDatabase db)
        {
            _db = db;
        }

        public List<Album> GetAlbums(int id)
        {
            var result = _db.Query<Album>(
                    @"select 
                        * 
                    from Albums
                    where Albums.AlbumId = @0", id);

            return result.ToList();
        }

        public Artist GetArtist(int id)
        {   
            var result = _db.Query<Artist>(
                    @"select 
                        * 
                    from Artists
                    where Artists.ArtistId = @0", id)
                .SingleOrDefault();

            return result;
        }
    }
}