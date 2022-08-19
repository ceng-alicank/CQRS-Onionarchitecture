using Application.Features.Products.Commands.Request;
using Application.Features.Products.Commands.Response;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            if (request.Id != Guid.Empty)
            {
                Product product = _mapper.Map<Product>(request);
                await _productRepository.Update(product);
                return _mapper.Map<UpdateProductCommandResponse>(product);
            }
            return null;
        }
    }
}
