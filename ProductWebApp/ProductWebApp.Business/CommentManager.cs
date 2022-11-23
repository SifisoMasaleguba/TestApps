using ProductWebApp.Entities.Models;
using ProductWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebApp.Business
{
    public class CommentManager
    {
       
        public IEnumerable<Comment> GetComments(int productId)
        {
            CommentRepository repository = new CommentRepository();
            return repository.GetComments(productId);
        }
        public void AddComment(Comment comment)
        {
            CommentRepository repository = new CommentRepository();
            repository.AddComment(comment);
        }

    }
}
