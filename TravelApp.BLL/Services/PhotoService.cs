using System.Collections.Generic;
using System.Linq;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Interface;
using TravelApp.DAL.Models;

namespace TravelApp.BLL.Services
{
    public class PhotoService:IPhotoService
    {
        private readonly IUnitOfWork _uow;

        public PhotoService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public bool AddPhoto(PhotoDTO photo)
        {
            using (_uow)
            {
                var tempPhoto = new Photo();
                tempPhoto.CityId = photo.CityId;
                tempPhoto.Image = photo.Image;
                tempPhoto.PersonId = photo.PersonId;
                tempPhoto.Date = photo.Date;
                _uow.PhotoRepository.Insert(tempPhoto);
                _uow.Save();
            }
            return true;
        }

        public bool DeletePhoto(int id)
        {
            using (_uow)
            {
                var tempPhoto = _uow.PhotoRepository.GetById(id);
                _uow.PhotoRepository.Delete(tempPhoto);
                _uow.Save();
            }
            return true;
        }

        public ICollection<PhotoDTO> GetAllPhotos()
        {
            using (_uow)
            {
                return _uow.PhotoRepository.Query().Select(d => new PhotoDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId,
                    Date = d.Date,
                    Image = d.Image,
                    PersonId = d.PersonId
                }).ToList();
            }
        }

        public ICollection<PhotoDTO> GetAllPhotosByCity(int cityID)
        {
            using (_uow)
            {
                return _uow.PhotoRepository.Query().Select(d => new PhotoDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId,
                    PersonId = d.PersonId,
                    Date = d.Date,
                    Image = d.Image
                }).Where(d => d.CityId == cityID).ToList();
            }
        }

        public ICollection<PhotoDTO> GetAllPhotosByUser(int userID)
        {
            using (_uow)
            {
                return _uow.PhotoRepository.Query().Select(d => new PhotoDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId,
                    PersonId = d.PersonId,
                    Date = d.Date,
                    Image = d.Image
                }).Where(d => d.PersonId == userID).ToList();
            }
        }

        public PhotoDTO GetPhotoById(int id)
        {
            using (_uow)
            {
                return _uow.PhotoRepository.Query().Select(d => new PhotoDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId,
                    PersonId = d.PersonId,
                    Image = d.Image,
                    Date = d.Date
                }).FirstOrDefault(d => d.Id == id);
            }
        }

        public bool UpdatePhoto(PhotoDTO photo)
        {
            using (_uow)
            {
                var tempPhoto = _uow.PhotoRepository.GetById(photo.Id);
                tempPhoto.PersonId = photo.PersonId;
                tempPhoto.CityId = photo.CityId;
                tempPhoto.Image = photo.Image;
                tempPhoto.Date = photo.Date;
                _uow.PhotoRepository.Update(tempPhoto);
                _uow.Save();
            }
            return true;
        }
    }
}
