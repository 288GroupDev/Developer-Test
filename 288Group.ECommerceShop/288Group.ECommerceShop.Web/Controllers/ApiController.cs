using _288Group.ECommerceShop.DTOs;
using _288Group.ECommerceShop.Persistance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Text.Json;

namespace _288Group.ECommerceShop.Web.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class ApiController : Controller
    {
        private readonly IPersistanceService _service;

        public ApiController(IPersistanceService service)
            => _service = service;

        [HttpPost]
        [Route("AddProductsToBasket")]
        public string AddProductsToBasket(AddProductsToBasketDTO data)
        {
            try
            {
                if (data.UserId == 0)
                {
                    return "Guest account is not valid. Please choose a User.";
                }

                // TODO: move this down into service and do bulk insert
                StringBuilder errorMessages = new StringBuilder();
                foreach (var productId in data.ProductIds)
                {
                    try
                    {
                        long? newProductId = _service.AddProductToBasket(data.UserId, productId);

                        if (newProductId == null)
                        {
                            errorMessages.Append(_service.LogError($"Unable to product {productId} to Basket"));
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessages.Append(_service.LogError($"Unable to product {productId} to Basket", ex));
                    }
                }

                if (errorMessages.Length == 0)
                {
                    return "All Products added to Basket";
                }

                return errorMessages.ToString();
            }
            catch (Exception ex)
            {
                return _service.LogError($"AddProductsToBasket", ex);
            }
        }   

        [HttpPost]
        [Route("GetBasket")]
        public string GetBasket(long UserId)
        {
            try
            {
                if (UserId == 0)
                {
                    return JsonSerializer.Serialize(new AjaxResponseDTO(true, "Guest account is not valid for getting basket. Please select a user.", null));
                }

                var basket = _service.GetBasket(UserId);
                return JsonSerializer.Serialize(new AjaxResponseDTO(false, null, basket));
            }
            catch (Exception ex)
            {
                return JsonSerializer.Serialize(new AjaxResponseDTO(true, _service.LogError($"Unable to retrieve total cost of Basket for user {UserId}", ex), null));
            }
        }
    }
}
