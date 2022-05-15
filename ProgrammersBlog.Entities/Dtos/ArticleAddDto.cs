using ProgrammersBlog.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Entities.Dtos
{
    public class ArticleAddDto
    {
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]// bu değer displayname 'deki değerin buraya gelmesi
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır. ")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Title { get; set; }

        [DisplayName("İçerik")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        [MinLength(20, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Content { get; set; }

        [DisplayName("Thumbnail")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        [MaxLength(300, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır. ")]
        [MinLength(5, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string Thumbnail { get; set; }

        [DisplayName("Tarih")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayName("Seo Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]// bu değer displayname 'deki değerin buraya gelmesi
        [MaxLength(100, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır. ")]
        [MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoAuthor { get; set; }

        [DisplayName("Seo Açıklama")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]// bu değer displayname 'deki değerin buraya gelmesi
        [MaxLength(200, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır. ")]
        [MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoDescription { get; set; }

        [DisplayName("Seo Etiketler")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]// bu değer displayname 'deki değerin buraya gelmesi
        [MaxLength(70, ErrorMessage = "{0} alanı {1} karakterden büyük olmamalıdır. ")]
        [MinLength(1, ErrorMessage = "{0} alanı {1} karakterden küçük olmamalıdır.")]
        public string SeoTags { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]// bu değer displayname 'deki değerin buraya gelmesi
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [DisplayName("Aktif mi ? ")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir")]
        public bool IsActive { get; set; }

       // AutoMapper, projemizde Entity nesnelerini database'den çektiğimiz haliyle değil, bu nesneleri istediğimiz (UI'da bizim için gerekli olacak)
       //formata çevirmemizi sağlayan basit bir kütüphanedir.DTO(Data Transfer Object) ise AutoMapper'ın dönüştürmesini istediğimiz format modelidir.

    }
}
