using MediatR;

namespace Cart.Data.Command
{
    public class DeleteUserCartCommand : IRequest<bool>
    {
        public string Id { get; set; }
    }

    public class CreateUserCartCommand : IRequest<Models.UserCart>
    {
        public Models.UserCart Cart { get; set; }
    }

    public class UpdateUserCartCommand : IRequest<Models.UserCart>
    {
        public Models.UserCart Cart { get; set; }
    }
}
