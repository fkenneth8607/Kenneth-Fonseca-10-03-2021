using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using MyAlbumApplication.Core.Interfaces;
using MyAlbumApplication.Core.Models;
using MyAlbumApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyAlbumApplication.Controllers
{
    public class PhotoController : Controller
    {
        private readonly IPhotoService _PhotoService;
        private readonly UrlSettings _UrlSettings;
        public PhotoController(IPhotoService photoService, IOptions<UrlSettings> urlSettings)
        {
            _PhotoService = photoService ?? throw new ArgumentNullException(nameof(photoService));
            _UrlSettings = urlSettings.Value;
        }


        public async Task<IActionResult> Index()
        {
            List<Album> albums = await _PhotoService.GetAlbumListAsync();

            ViewData["Albums"] = new SelectList(albums, "Id", "Title");

            return View();
        }

        public async Task<IActionResult> GetPhotos(int albumId)
        {
            List<Photo> photos = await _PhotoService.GetPhotoListAsync(albumId);
            return Json(photos);
        }

        public async Task<IActionResult> GetComments(int photoId)
        {
            List<Comment> comments = await _PhotoService.GetCommentsListAsync(photoId);
            return Json(comments);
        }


        public async Task<IActionResult> GetAlbumsTableAsync()
        {
            AlbumsListPagination albums = await _PhotoService.GetAlbumPaginated();
            return Json(albums);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
