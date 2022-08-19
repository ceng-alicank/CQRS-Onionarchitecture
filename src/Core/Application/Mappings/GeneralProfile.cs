using Application.Features.Products.Commands.Request;
using Application.Features.Products.Commands.Response;
using Application.Features.Products.Queries.Response;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProductCommandRequest, Product>();
            CreateMap<Product, CreateProductCommandResponse>();

            CreateMap<UpdateProductCommandRequest, Product>();
            CreateMap<Product, UpdateProductCommandResponse>();

            CreateMap<Product, GetProductByIdQueryResponse>();

        }
    }
}
