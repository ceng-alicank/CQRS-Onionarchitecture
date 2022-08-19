using Application.Features.Products.Queries.Response;
using MediatR;

namespace Application.Features.Products.Queries.Request
{
    public class GetProductByIdQueryRequest : IRequest<GetProductByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
