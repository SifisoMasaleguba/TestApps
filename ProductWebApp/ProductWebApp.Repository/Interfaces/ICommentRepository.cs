using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebApp.Entities.Models;

namespace ProductWebApp.Repository.Interfaces
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetComments(int productId);
        void AddComment(Comment comment);
    }
}
