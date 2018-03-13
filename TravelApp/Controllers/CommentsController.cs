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
    public class CommentsController : ApiController
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public ICollection<CommentDTO> Get()
        {
            return _commentService.GetAllComments();
        }

        [HttpGet]
        [Route("api/commentsbycity/{cityId}")]
        public ICollection<CommentDTO> GetAllCommentByCity(int cityId)
        {
            return _commentService.GetAllCommentsByCity(cityId);
        }

        [HttpGet]
        [Route("api/commentsbyuser/{userId}")]
        public ICollection<CommentDTO> GetAllCommentByUser(int userId)
        {
            return _commentService.GetAllCommentsByUser(userId);
        }
        [Route("api/commentsbyid/{id}")]
        public CommentDTO Get(int id)
        {
            return _commentService.GetCommentById(id);
        }

        [HttpPut]
        public void Put([FromBody]CommentDTO comment)
        {
            _commentService.UpdateComment(comment);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            _commentService.DeleteComment(id);
            return true;
        }

        [HttpPost]
        public bool Post([FromBody]CommentDTO comment )
        {
            _commentService.AddComment(comment);
            return true;
        }
     }
}
