using Application.Features.Products.Commands.Request;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductByIdCommandRequest, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        
        public async Task<bool> Handle(DeleteProductByIdCommandRequest request, CancellationToken cancellationToken)
        {
            if(request.Id != Guid.Empty)
            {
                await _productRepository.Delete(request.Id);
                return true;
            }
            return false;
        }
    }
}
