using System;
using System.Collections.Generic;
using System.Text;

namespace MyAlbumApplication.Core.Models
{

    public class AlbumsListPagination
    {
        public int Total { get; set; }
        public int Items_page { get; set; }
        public int Current_page { get; set; }
        public int Last_page { get; set; }
        public string Next_page_url { get; set; }
        public object Prev_page_url { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public Object[] Data { get; set; }
    }


}
