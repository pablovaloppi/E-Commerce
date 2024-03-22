using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Model
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int CommentId { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
        public Comment Response { get; set; }
    }
}
