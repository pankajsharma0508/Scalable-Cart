using Cart.Data.Command;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Bson;

namespace Cart.Data.Handlers
{
    public class CreateCartCommandHandler : BaseRequestHandler, IRequestHandler<CreateUserCartCommand, Models.UserCart>
    {
        public async Task<Models.UserCart> Handle(CreateUserCartCommand request, CancellationToken cancellationToken)
        {
            var _dbContext = GetDBContext();
            _dbContext.UserCarts.Add(request.Cart);
            await _dbContext.SaveChangesAsync();
            return request.Cart;
        }
    }

    public class UpdateUserCartCommandHandler : BaseRequestHandler, IRequestHandler<UpdateUserCartCommand, Models.UserCart>
    {
        public async Task<Models.UserCart> Handle(UpdateUserCartCommand request, CancellationToken cancellationToken)
        {
            var _dbContext = GetDBContext();
            var UserCart = await _dbContext.UserCarts.FindAsync(request.Cart._id);
            if (UserCart != null)
            {
                // Update specific properties
                UserCart.Name = request.Cart.Name;
                await _dbContext.SaveChangesAsync();
                return UserCart;
            }
            throw new Exception("Unable to find the cart");
        }
    }

    public class DeleteUserCartCommandHandler : BaseRequestHandler, IRequestHandler<DeleteUserCartCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserCartCommand request, CancellationToken cancellationToken)
        {
            var _dbContext = GetDBContext();

            var UserCart = await _dbContext.UserCarts.FindAsync(new ObjectId(request.Id));
            if (UserCart != null)
            {
                _dbContext.UserCarts.Remove(UserCart);
                await _dbContext.SaveChangesAsync();
            }
            return true;
        }
    }
}
