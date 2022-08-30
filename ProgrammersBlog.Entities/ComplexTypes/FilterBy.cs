using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.ComplexTypes
{
    public enum FilterBy
    { //GetAllByUserIdOnFilter(FilterBy=FilterBy.Category,int categoryId);
        Category = 0,
        Date = 1,
        ViewCount = 2,
        CommentCount = 3
    }
}
