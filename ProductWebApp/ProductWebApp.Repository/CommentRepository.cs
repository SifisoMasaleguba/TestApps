using ProductWebApp.Entities.Models;
using ProductWebApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductWebApp.Repository.DataSource;
using Dapper;
using System.Data;

namespace ProductWebApp.Repository
{
    public class CommentRepository : ICommentRepository
    {
        DataSourceWeb dataSourceWeb;
        public CommentRepository() {
            dataSourceWeb = new DataSourceWeb();
        }

        public void AddComment(Comment comment)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", comment.ProductId);
            parameters.Add("@Comment", comment.comment);
            parameters.Add("@Email", comment.Email);
            dataSourceWeb.Connection().Execute("STP_COMMENT_ADD", parameters, commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<Comment> GetComments(int productId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@ProductId", productId);
            return dataSourceWeb.Connection().Query<Comment>("STP_COMMENT", parameters, commandType: CommandType.StoredProcedure).ToList();
           
        }
    }
}
