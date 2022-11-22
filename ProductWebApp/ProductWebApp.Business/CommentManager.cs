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
        private CommentRepository repository;
        public CommentManager() {
            repository = new CommentRepository();
        }

        public IEnumerable<Comment> GetComments(int productId)
        {
           return repository.GetComments(productId);
        }
        public void AddComment(Comment comment)
        {
             repository.AddComment(comment);
        }

    }
}
