using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult // <out T> Kategoriyi tek başına veya IList IEnumerable olarak taşıyabiliriz. Bu yüzden out T kullandık. (İster liste ister tek entity)
    {
        public T Data { get; } // new DataResult<Category>(ResultStatus.Success,category);
                                //new DataResult<IList<Category>>(ResultStatus.Success,categoryList); //Ilist ve IEnumerable kullanmamızı (yani liste olarak) sağlayan = out T
    }
}
