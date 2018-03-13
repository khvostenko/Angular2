using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;

namespace TravelApp.Controllers
{
    public class PhotosController : ApiController
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        public ICollection<PhotoDTO> Get()
        {
            return _photoService.GetAllPhotos();
        }

        [HttpGet]
        [Route("api/photosbyuser/{id}")]
        public ICollection<PhotoDTO> GetAllPhotoByUser(int userID)
        {
            return _photoService.GetAllPhotosByUser(userID);
        }

        [HttpGet]
        [Route("api/photosbycity/{cityID}")]
        public ICollection<PhotoDTO> GetAllPhotoByCity(int cityID)
        {
            return _photoService.GetAllPhotosByCity(cityID);
        }
        [Route("api/photosbyid/{id}")]
        public PhotoDTO Get(int id)
        {
            return _photoService.GetPhotoById(id);
        }

        [HttpPut]
        public void Put([FromBody]PhotoDTO photo)
        {
            _photoService.UpdatePhoto(photo);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _photoService.DeletePhoto(id);
            return true;
        }

        [HttpPost]
        public bool Post([FromBody]PhotoDTO photo)
        {
            _photoService.AddPhoto(photo);
            return true;
        }

    }
}
