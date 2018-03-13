using System.Collections.Generic;
using System.Linq;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Interface;
using TravelApp.DAL.Models;

namespace TravelApp.BLL.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IUnitOfWork _uow;

        public AdministratorService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public bool AddAdministrator(AdministratorDTO administrator)
        {
            using (_uow)
            {
                Administrator tempAdministrator = new Administrator();
                _uow.AdministratorRepository.Insert(tempAdministrator);
                _uow.Save();
            }
            return true;
        }

        public bool DeleteAdministrator(int id)
        {
            using (_uow)
            {
                var tempAdministrator = _uow.AdministratorRepository.GetById(id);
                _uow.AdministratorRepository.Delete(tempAdministrator);
                _uow.Save();
            }
            return true;
        }

        public ICollection<AdministratorDTO> GetAllAdministrator()
        {
            var administrators = new List<AdministratorDTO>();
            using (_uow)
            {
                administrators = _uow.AdministratorRepository.Query().Select(d => new AdministratorDTO()
                {
                    Id = d.Id,
                    Email = d.Email,
                    Name = d.FullName
                }).ToList();
            }
            return administrators;
        }

        public AdministratorDTO GetAdministratorById(int id)
        {
            using (_uow)
            {
                return _uow.AdministratorRepository.Query().Select(d => new AdministratorDTO()
                {
                    Id = d.Id,
                    Email = d.Email,
                    Name = d.FullName
                }).FirstOrDefault(d => d.Id == id);
            }
        }

        public bool UpdateAdministrator(AdministratorDTO administrator)
        {
            using (_uow)
            {
                var tempAdministrator = _uow.AdministratorRepository.GetById(administrator.Id);
                tempAdministrator.Email = administrator.Email;
                tempAdministrator.FullName = administrator.Name;
                tempAdministrator.UserName = administrator.Email;
                _uow.AdministratorRepository.Update(tempAdministrator);
                _uow.Save();
            }
            return true;
        }
    }
}
