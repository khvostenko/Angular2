using TravelApp.BLL.DTO;
using System.Collections.Generic;

namespace TravelApp.BLL.Interfaces
{
    public interface ICommentService
    {
        ICollection<CommentDTO> GetAllComments();
        ICollection<CommentDTO> GetAllCommentsByCity(int cityID);
        ICollection<CommentDTO> GetAllCommentsByUser(int userID);
        CommentDTO GetCommentById(int id);
        bool UpdateComment(CommentDTO comment);
        bool DeleteComment(int id);
        bool AddComment(CommentDTO comment);
    }
}
