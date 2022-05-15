using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);//böyle bir primarykey alanı var mı ?  
            builder.Property(a => a.Id).ValueGeneratedOnAdd();//identity alanımız 
            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired(true);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(100);
            builder.Property(a => a.SeoDescription).HasMaxLength(200);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(300);
            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(100);
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(100);
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(600);
            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(c => c.CategoryId);
            //burada ilk önce her makalenin bir categoriye ihtiyacı olduğu için onu ekledik. ardından bir kategoriye çok makale gelebilir o yüzden withmany ekledik sonra  da foreignkeyini ekledik 
            //foreign key ikincil yabancı anahtarı oluyor 
            builder.ToTable("Articles");
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(u => u.UserId);
            //builder.HasData(
            //    new Article
            //    {
            //        Id = 1,
            //        CategoryId = 1,
            //        UserId = 1,
            //        Title = "C# 9.0 ve  .Net 5.0 yenilikleri",
            //        Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. " +
            //    "Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır." +
            //    " Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının" +
            //    " yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
            //        Thumbnail = "Default.jpg",
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "C# 9.0 ve  .Net 5.0 yenilikleri ",
            //        SeoDescription = "C# 9.0 ve  .Net 5.0 yenilikleri",
            //        SeoAuthor = "Sumeyye Ceylan",
            //        SeoTags = "C# 9.0 , .Net 5.0 , .Net FrameWork , .Net Core",
            //        Date = DateTime.Now,
            //        ViewsCount = 10,
            //        CommentCount = 1
            //    },
            //    new Article
            //    {
            //        Id = 2,
            //        CategoryId = 2,
            //        UserId = 1,
            //        Title = "Python 11 ve 19 yenilikleri",
            //        Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. " +
            //    "Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır." +
            //    " Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının" +
            //    " yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
            //        Thumbnail = "Default.jpg",
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "Python 11 ve 19 yenilikleri",
            //        SeoDescription = "Python 11 ve 19 yenilikleri",
            //        SeoAuthor = "Sumeyye Ceylan",
            //        SeoTags = "Python 11 , Python 19",
            //        Date = DateTime.Now,
            //        ViewsCount = 102,
            //        CommentCount = 1
            //    },
            //    new Article
            //    {
            //        Id = 3,
            //        CategoryId = 3,
            //        UserId = 1,
            //        Title = "JavaScript ES2020 ve ES2019 yenilikleri",
            //        Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. " +
            //    "Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır." +
            //    " Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının" +
            //    " yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
            //        Thumbnail = "Default.jpg",
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "InitialCreate",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "InitialCreate",
            //        ModifiedDate = DateTime.Now,
            //        Note = "JavaScript ES2020 ve ES2019 yenilikleri ",
            //        SeoDescription = "JavaScript ES2020 ve ES2019 yenilikleri",
            //        SeoAuthor = "Sumeyye Ceylan",
            //        SeoTags = "JavaScript , ES2020 , ES2019 ",
            //        Date = DateTime.Now,
            //        ViewsCount = 140,
            //        CommentCount = 1
            //    }
            //);

        }
    }
}
