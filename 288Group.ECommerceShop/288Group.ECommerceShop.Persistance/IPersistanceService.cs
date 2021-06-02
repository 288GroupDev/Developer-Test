﻿using _288Group.ECommerceShop.DTOs;
using System;

namespace _288Group.ECommerceShop.Persistance
{
    public interface IPersistanceService
    {
        /// <returns>The provided errorMessage parameter for output to UI</returns>
        string LogError(string errorMessage, Exception ex = null);
        ProductsDTO GetAllProducts();
        ProductsDTO GetProducts(long[] productIds);   
        long? GetUserId(string username, string password);
        string GetUsername(long userId);
        CreateNewUserResponseDTO AddUser(string username, string password);
        BasketDTO GetBasket(long userId, long? discountCodeId = null);
        long? AddProductToBasket(long userId, long productId);
    }
}
