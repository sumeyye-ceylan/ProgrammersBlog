using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out T> : IResult // istediğimiz şekilde entity taşıyabilmek için out T yaptık list veya tek başına
    {
        public T Data { get; } //new DataResult<Category>(ResultStatus.Success);
                               // new DataResult<IList<Category>>(ResultStatus.Success,categoryList) bu iki tipi de kullanabilmek adına
    }
}
