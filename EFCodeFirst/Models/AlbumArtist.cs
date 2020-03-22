using ModelDesignFirst;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCodeFirst.Models
{
    class AlbumArtist
    {
        public int AlbumId { get; set; }

        public Album Album { get; set; }
        public int ArtistId { get; set; }

        public Artist Artist { get; set; }
    }
}
