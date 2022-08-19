using Application.Features.Products.Commands.Response;
using MediatR;


namespace Application.Features.Products.Commands.Request
{
    public class UpdateProductCommandRequest: IRequest<UpdateProductCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
