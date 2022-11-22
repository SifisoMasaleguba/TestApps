using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductWebApp.Entities.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ProductId { get; set; }
        public string comment { get; set; }
        public string Email { get; set; }
        public DateTime DateOfComment { get; set; }       
    }
}
