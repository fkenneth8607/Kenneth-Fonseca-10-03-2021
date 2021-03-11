using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlbumApplication.Core.Models
{
    /// <summary>
    /// Photo Class
    /// </summary>
    public class Photo
    {
        public int AlbumId{ get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }

    }
}
