using System.Collections.Generic;
using System.Linq;
using TravelApp.BLL.DTO;
using TravelApp.BLL.Interfaces;
using TravelApp.DAL.Interface;
using TravelApp.DAL.Models;

namespace TravelApp.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _uow;

        public CommentService(IUnitOfWorkFactory uowFactory)
        {
            _uow = uowFactory.Create();
        }

        public bool AddComment(CommentDTO comment)
        {
            using (_uow)
            {
                var tempComment = new Comment();
                tempComment.CityId = comment.CityId;
                tempComment.Date = comment.Date;
                tempComment.PersonId = comment.PersonId;
                tempComment.Text = comment.Text;
                _uow.CommentRepository.Insert(tempComment);
                _uow.Save();
            }
            return true;
        }

        public bool DeleteComment(int id)
        {
            using (_uow)
            {
                var tempComment = _uow.CommentRepository.GetById(id);
                _uow.CommentRepository.Delete(tempComment);
                _uow.Save();
            }
            return true;
        }

        public ICollection<CommentDTO> GetAllComments()
        {
            using (_uow)
            {
                return _uow.CommentRepository.Query().Select(d => new CommentDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId,
                    PersonId = d.PersonId,
                    Date = d.Date,
                    Text = d.Text
                }).ToList();
            }
        }

        public ICollection<CommentDTO> GetAllCommentsByCity(int cityID)
        {
            using (_uow)
            {
                return _uow.CommentRepository.Query().Select(d => new CommentDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId,
                    PersonId = d.PersonId,
                    Date = d.Date,
                    Text = d.Text
                }).Where(d => d.CityId == cityID).ToList();
            }
        }

        public ICollection<CommentDTO> GetAllCommentsByUser(int userID)
        {
            using (_uow)
            {
                return _uow.CommentRepository.Query().Select(d => new CommentDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId,
                    PersonId = d.PersonId,
                    Date = d.Date,
                    Text = d.Text
                }).Where(d => d.PersonId == userID).ToList();
            }
        }

        public CommentDTO GetCommentById(int id)
        {
            using (_uow)
            {
                return _uow.CommentRepository.Query().Select(d => new CommentDTO()
                {
                    Id = d.Id,
                    CityId = d.CityId,
                    PersonId = d.PersonId,
                    Date = d.Date,
                    Text = d.Text
                }).FirstOrDefault(d => d.Id == id);
            }
        }

        public bool UpdateComment(CommentDTO comment)
        {
            using (_uow)
            {
                var tempComment = _uow.CommentRepository.GetById(comment.Id);
                tempComment.PersonId = comment.PersonId;
                tempComment.CityId = comment.CityId;
                tempComment.Date = comment.Date;
                tempComment.Text = comment.Text;
                _uow.CommentRepository.Update(tempComment);
                _uow.Save();
            }
            return true;
        }
    }
}
