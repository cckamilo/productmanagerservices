using System;
using AutoMapper;
using DataAccess.MongoDB.Interfaces;
using DataAccess.MongoDB.Models;
using Models.ProductsApi.Interfaces;
using Models.ProductsApi.Models;
using Models.ProductsApi.ResponseModels;

namespace Business.ServiceProducts.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<ItemsModel, Items>();
            CreateMap<FileModel, File>();
            CreateMap<ProductsModel, Products>();
            CreateMap<CategoriesModel, Categories>();
            CreateMap<SubCategoriesModel, SubCategories>();
            CreateMap<GendersModel, Genders>();
            CreateMap<SizesModel, Sizes>();
            CreateMap<GroupItemsModel, GroupItems>();
            CreateMap<IItemsModel, IItems>();
            
        }
    }
}
