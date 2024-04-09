using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dto.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int? CommentId { get; set; }

    }
}
