using TravelApp.BLL.DTO;
using System.Collections.Generic;


namespace TravelApp.BLL.Interfaces
{
    public interface IPhotoService
    {
        ICollection<PhotoDTO> GetAllPhotos();
        ICollection<PhotoDTO> GetAllPhotosByCity(int cityID);
        ICollection<PhotoDTO> GetAllPhotosByUser(int userID);
        PhotoDTO GetPhotoById(int id);
        bool UpdatePhoto(PhotoDTO photo);
        bool DeletePhoto(int id);
        bool AddPhoto(PhotoDTO photo);
    }
}
