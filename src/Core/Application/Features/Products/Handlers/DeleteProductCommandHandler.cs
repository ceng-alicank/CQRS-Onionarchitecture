using Application.Features.Products.Commands.Request;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Products.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductByIdCommandRequest, bool>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
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
