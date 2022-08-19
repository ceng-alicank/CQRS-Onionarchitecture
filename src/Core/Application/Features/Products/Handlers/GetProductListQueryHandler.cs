using Application.Services.Repositories;
using Domain.Entities;
using MediatR;


namespace Application.Features.Products.Handlers
{
    
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQueryRequest, List<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> Handle(GetProductListQueryRequest request, CancellationToken cancellationToken)
        {
            var productlist =  await _productRepository.GetAll();
            if (productlist !=null)
            {
                return productlist;
            }
            return null;
        }
    }
    public class GetProductListQueryRequest : IRequest<List<Product>>
    {

    }

}
