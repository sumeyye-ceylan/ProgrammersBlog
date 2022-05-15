using ProgrammersBlog.Data.Abstract;
using ProgrammersBlog.Data.Concrete.EntityFramework.Contexts;
using ProgrammersBlog.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProgrammersBlogContext _context;
        private EfArticleRepository efArticleRepository;
        private EfCategoryRepository efCategoryRepository;
        private EfCommentRepository efCommentRepository;
       

        public UnitOfWork(ProgrammersBlogContext context)
        {
            _context = context;
        }

        // public IArticleRepository Articles => throw new NotImplementedException(); // bunları new'leyemeyiz return etmemiz için somut hallerini oluşturmamız lazım 
        public IArticleRepository Articles => efArticleRepository ?? new EfArticleRepository(_context);

        public ICategoryRepository Categories => efCategoryRepository ?? new EfCategoryRepository(_context);

        public ICommentRepository Comments => efCommentRepository ?? new EfCommentRepository(_context); // ?? adı null coalescing operatörü 

        //eğer efUserRepository yok veya null ise yenisini oluşturup return ediyoruz.
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
