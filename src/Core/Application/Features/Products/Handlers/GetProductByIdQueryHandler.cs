using Application.Features.Products.Queries.Request;
using Application.Features.Products.Queries.Response;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        IMapper _mapper;
        IProductRepository _productRepository;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            if (request.Id!=null)
            {
                var entity =  await _productRepository.GetById(request.Id);
                if (entity!=null)
                {
                    return _mapper.Map<GetProductByIdQueryResponse>(entity);
                }
            }
            return null;
        }
    }
}
