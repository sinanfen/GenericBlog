using ProgrammersBlog.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Concrete
{
    public class Comment : EntityBase, IEntity
    {
        //public override bool IsActive { get; set; } = false; //False olarak atanmasını sağladık
        public string Text { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
