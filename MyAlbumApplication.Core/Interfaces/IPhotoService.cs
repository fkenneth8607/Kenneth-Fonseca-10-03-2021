using MyAlbumApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAlbumApplication.Core.Interfaces
{
    public interface IPhotoService
    {
        public Task<List<Album>> GetAlbumListAsync();

        public Task<List<Photo>> GetPhotoListAsync(int albumId);

        public Task<List<Comment>> GetCommentsListAsync(int albumId);

        public Task<AlbumsListPagination> GetAlbumPaginated();

    }
}
