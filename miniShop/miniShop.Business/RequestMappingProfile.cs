using AutoMapper;
using miniShop.Business.DTO.Requests;
using miniShop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miniShop.Business
{
   public class RequestMappingProfile : Profile
    {
        public RequestMappingProfile()
        {
            CreateMap<AddProductRequest, Product>().ReverseMap();
        }
    }
}
