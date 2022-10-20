﻿namespace TailwindTraders.Api.Core.Services.Implementations;

internal class CartService : TailwindTradersServiceBase, ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository, IMapper mapper, IConfiguration configuration) : base(mapper, configuration)
    {
        _cartRepository = cartRepository;
    }

    public async Task<List<CartDto>> GetCartAsync(string email, CancellationToken cancellationToken = default)
    {
        var allCartItemsDao = await _cartRepository.ListAsync(null, cancellationToken);
            
        var cartItemsDao = allCartItemsDao.Where(cart => cart.Email == email).ToList();

        if (cartItemsDao is null) throw new CartNotFoundException(email);

        var cartItemsDto = new List<CartDto>();

        cartItemsDao.ForEach(item => cartItemsDto.Add(Mapper.Map<CartDto>(item)));

        return cartItemsDto;
    }

    public async Task AddItemToCartAsync(CartDto cartItemDto, CancellationToken cancellationToken)
    {
        var cartItemDao = Mapper.Map<CartDao>(cartItemDto);

        await _cartRepository.AddAsync(cartItemDao.Email, cartItemDao, cancellationToken);
    }

    public async Task UpdateCartItemQuantityAsync(CartDto cartItemDto, CancellationToken cancellationToken)
    {
        var cartItemDao = Mapper.Map<CartDao>(cartItemDto);

        await _cartRepository.UpsertAsync(cartItemDao.Email, cartItemDao, cancellationToken);
    }

    public async Task RemoveItemFromCartAsync(CartDto cartItemDto, CancellationToken cancellationToken)
    {
        var cartItemDao = Mapper.Map<CartDao>(cartItemDto);

        await _cartRepository.DeleteAsync(cartItemDao.Email, cartItemDao.id, cancellationToken);
    }
}