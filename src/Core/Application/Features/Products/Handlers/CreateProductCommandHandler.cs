using Application.Features.Products.Commands.Request;
using Application.Features.Products.Commands.Response;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (request != null)
            {
                var product = _mapper.Map<Product>(request);
                await _productRepository.Add(product);
                CreateProductCommandResponse response = _mapper.Map<CreateProductCommandResponse>(product);
                return response; 
            }
            return null;
        }
    }
}
