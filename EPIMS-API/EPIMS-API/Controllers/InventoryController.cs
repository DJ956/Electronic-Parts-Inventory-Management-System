using EPIMS_API.Domain.Model.Request.Inventory;
using EPIMS_API.Domain.Model.Response;
using EPIMS_API.Domain.Model.Response.Inventory;
using EPIMS_API.Domain.Repository;
using EPIMS_API.Domain.Service.Inventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryRepository repository;

        public InventoryController(IInventoryRepository repository) : base()
        {
            this.repository = repository;
        }

        /// <summary>
        /// 在庫情報を取得する
        /// </summary>
        /// <param name="inventoryNo">在庫番号</param>
        /// <returns></returns>
        [HttpGet("{inventoryNo}")]
        public async Task<ActionResult<GetInventoryResponse>> GetInventory(int inventoryNo)
        {
            var service = new InventoryService(repository);
            var response = await service.GetInventory(inventoryNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// 製品番号と一致する在庫情報リストを取得する。
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        [HttpGet("product/{productNo}")]
        public async Task<ActionResult<GetInventoryListResponse>> GetInventoryList(int productNo)
        {
            var service = new InventoryService(repository);
            var response = await service.GetInventoryList(productNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// 在庫数を取得する取得される在庫数はステータスコードが002:入庫済のもののみとなる。
        /// </summary>
        /// <param name="productNo">製品番号</param>
        /// <returns></returns>
        [HttpGet("product/{productNo}/sum-stock-quantity")]
        public async Task<ActionResult<GetSumStockQuantityResponse>> GetSumStockQuantity(int productNo)
        {
            var service = new InventoryService(repository);
            var response = await service.GetSumStockQuantity(productNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }


        /// <summary>
        /// 在庫情報登録を行う。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("registry")]
        public async Task<ActionResult<BaseResponse>> RegistryInventory(RegistryInventoryRequest request)
        {
            var service = new InventoryService(repository);
            var response = await service.RegistryInventory(request);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// 在庫情報を引当中に更新する
        /// </summary>
        /// <param name="inventoryNo">在庫番号</param>
        /// <returns></returns>
        [HttpPut("update/allowcated")]
        public async Task<ActionResult<UpdateInventoryResponse>> UpdateInventory2Allowcated(int inventoryNo)
        {
            var service = new InventoryService(repository);
            var response = await service.UpdateInventory2Allowcated(inventoryNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// 在庫情報を出庫済みに更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        [HttpPut("update/delivered")]
        public async Task<ActionResult<UpdateInventoryResponse>> UpdateInventory2Delivered(int inventoryNo)
        {
            var service = new InventoryService(repository);
            var response = await service.UpdateInventory2Delivered(inventoryNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// 在庫情報を破棄・廃棄に更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        [HttpPut("update/discard")]
        public async Task<ActionResult<UpdateInventoryResponse>> UpdateInventory2Discard(int inventoryNo)
        {
            var service = new InventoryService(repository);
            var response = await service.UpdateInventory2Discard(inventoryNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }

        /// <summary>
        /// 在庫情報を注文中に更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        [HttpPut("update/order")]
        public async Task<ActionResult<UpdateInventoryResponse>> UpdateInventory2Order(int inventoryNo)
        {
            var service = new InventoryService(repository);
            var response = await service.UpdateInventory2Order(inventoryNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }


        /// <summary>
        /// 在庫情報を入庫済みに更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        [HttpPut("update/stocked")]
        public async Task<ActionResult<UpdateInventoryResponse>> UpdateInventory2Stocked(int inventoryNo)
        {
            var service = new InventoryService(repository);
            var response = await service.UpdateInventory2Stocked(inventoryNo);
            if (response.ReturnCode == 0) { return Ok(response); }
            return BadRequest(response);
        }
    }
}
