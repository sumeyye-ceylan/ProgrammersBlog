using AutoMapper;
using ProgrammersBlog.Entities.Concrete;
using ProgrammersBlog.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammersBlog.Services.AutoMapper.Profiles
{
    public class ArticleProfile :Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleAddDto,Article>().ForMember(dest =>dest.CreatedDate ,opt=>opt.MapFrom(x=>DateTime.Now));//ArticleAddDto içinde olmadığı için biz verdik  bu alanı Article class içerisinde görecek  bu alanı içerisindeki property için işlem yapmak istiyorum(formmember ile ) ardından da bu işlemi neye göre yapacağını veriyorum
            CreateMap<ArticleUpdateDto,Article>().ForMember(dest=>dest.ModifiedDate,opt=>opt.MapFrom(x=>DateTime.Now));
        }
    }
}
