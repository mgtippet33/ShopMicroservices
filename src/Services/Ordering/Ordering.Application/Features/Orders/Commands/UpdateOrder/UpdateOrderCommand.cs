using MediatR;
using Ordering.Application.Features.Orders.Commands.CheckoutOrder;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : CheckoutOrderCommand, IRequest
    {
        public int Id { get; set; }
    }
}
