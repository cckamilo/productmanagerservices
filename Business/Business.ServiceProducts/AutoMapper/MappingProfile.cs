using System;
using AutoMapper;
using DataAccess.MongoDB.Models;
using Models.ProductsApi.Models;

namespace Business.ServiceProducts.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemsModel, Items>();
            CreateMap<FileModel, File>();
            CreateMap<ProductsModel, Products>();

    }
    }
}
