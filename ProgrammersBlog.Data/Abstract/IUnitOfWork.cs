using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Abstract
{
    public interface IUnitOfWork :IAsyncDisposable //burada amacımız tüm intefaceleri yönetmektir.
    {
        IArticleRepository Articles { get; }// sadece verilere ulaşmak istiyoruz o yüzden get 
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
         // _unitofwork.Categories.AddAsync(category) 
        // hiçbir yerde save yapmadık burada işlemleri yaptıktan sonra save işlemlerini  yapacağız  

        Task<int> SaveAsync();
    }
}
