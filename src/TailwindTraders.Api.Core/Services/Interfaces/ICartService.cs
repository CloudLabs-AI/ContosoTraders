﻿namespace TailwindTraders.Api.Core.Services.Interfaces;

internal interface ICartService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="email"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<List<CartDto>> GetCartAsync(string email, CancellationToken cancellationToken);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cartItemDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task AddItemToCartAsync(CartDto cartItemDto, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cartItemDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task UpdateCartItemQuantityAsync(CartDto cartItemDto, CancellationToken cancellationToken);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cartItemDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task RemoveItemFromCartAsync(CartDto cartItemDto, CancellationToken cancellationToken);
}