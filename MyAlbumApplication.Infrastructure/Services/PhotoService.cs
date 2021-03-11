using Microsoft.Extensions.Options;
using MyAlbumApplication.Core.Helper;
using MyAlbumApplication.Core.Interfaces;
using MyAlbumApplication.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAlbumApplication.Infrastructure.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly ConnectionUrl _ConnectionUrl;
        private readonly UrlSettings _UrlSettings;
        public PhotoService(ConnectionUrl connectionUrl, IOptions<UrlSettings> urlSettings)
        {
            // Kenneth Si quieres implementar el logger del lado del controller tambien se puede y se hace igual que aqui
            _ConnectionUrl = connectionUrl ?? throw new ArgumentNullException(nameof(connectionUrl));
            _UrlSettings = urlSettings.Value;

        }
        /// <summary>
        /// method that call get list from url for get albums
        /// </summary>
        /// <returns>album list</returns>
        public async Task<List<Album>> GetAlbumListAsync()
        {
            List<Album> albums = await GetAlbumListFromUrlAsync();
            return albums;
        }

        public async Task<AlbumsListPagination> GetAlbumPaginated()
        {
            List<Album> albums = await GetAlbumListFromUrlAsync();
            AlbumsListPagination model = new AlbumsListPagination
            {
                Total = albums.Count,
                Items_page = 7,
                Current_page = 1,
                Last_page = Convert.ToInt32(Math.Round(Convert.ToDecimal(albums.Count / 7), 0)),
                Next_page_url = $"{_UrlSettings.Albums}?page=2",
                Prev_page_url = null,
                From = 1,
                To = 10,
                Data = albums.ToArray()
            };

            return model;
         
        }
        /// <summary>
        /// method that call get list from url for get comments
        /// </summary>
        /// <returns>comments list</returns>
        public async Task<List<Comment>> GetCommentsListAsync(int albumId)
        {
            List<Comment> comments = await GetCommentsListFromUrlAsync(albumId);
            return comments;
        }
        /// <summary>
        /// method that call get list from url for get photos
        /// </summary>
        /// <returns>photos list</returns>
        public async Task<List<Photo>> GetPhotoListAsync(int albumId)
        {
            List<Photo> photos = await GetPhotosListFromUrlAsync(albumId);
            return photos;
        }


        /// <summary>
        /// method that call web request url of settings albums
        /// </summary>
        /// <returns>album list</returns>
        public async Task<List<Album>> GetAlbumListFromUrlAsync()
        {
            List<Album> output = new List<Album>();

            try
            {
                Response albums = await _ConnectionUrl.WebRequestAsync(_UrlSettings.Albums, HttpMethod.GET);

                output = JsonConvert.DeserializeObject<List<Album>>(albums.Message).OrderBy(a => a.Title).ToList();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }
        /// <summary>
        /// method that call web request url of settings photos
        /// </summary>
        /// <returns>photos list</returns>
        public async Task<List<Photo>> GetPhotosListFromUrlAsync(int albumId)
        {
            List<Photo> output = new List<Photo>();

            try
            {
                Response photos = await _ConnectionUrl.WebRequestAsync(_UrlSettings.Photos, HttpMethod.GET);

                output = JsonConvert.DeserializeObject<List<Photo>>(photos.Message)
                                .Where(x => x.AlbumId == albumId).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }
        /// <summary>
        /// method that call web request url of settings comments
        /// </summary>
        /// <returns>comments list</returns>
        public async Task<List<Comment>> GetCommentsListFromUrlAsync(int albumId)
        {
            List<Comment> output = new List<Comment>();

            try
            {
                Response comment = await _ConnectionUrl.WebRequestAsync(_UrlSettings.Comments, HttpMethod.GET);

                output = JsonConvert.DeserializeObject<List<Comment>>(comment.Message)
                                .Where(x => x.PostId == albumId).ToList();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }
    }
}
