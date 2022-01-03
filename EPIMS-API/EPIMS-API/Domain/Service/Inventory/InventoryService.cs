using EPIMS_API.Domain.Model.Request.Inventory;
using EPIMS_API.Domain.Model.Response;
using EPIMS_API.Domain.Model.Response.Inventory;
using EPIMS_API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Service.Inventory
{
    public class InventoryService
    {
        private readonly IInventoryRepository repository;

        public InventoryService(IInventoryRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 在庫情報を取得する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        public Task<GetInventoryResponse> GetInventory(int inventoryNo)
        {
            return this.repository.GetInventory(inventoryNo);
        }

        /// <summary>
        /// 製品番号と一致する在庫情報リストを取得する
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        public Task<GetInventoryListResponse> GetInventoryList(int productNo)
        {
            return repository.GetInventoryList(productNo);
        }

        /// <summary>
        /// 在庫数を取得する取得される在庫数はステータスコードが002:入庫済のもののみとなる。
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        public Task<GetSumStockQuantityResponse> GetSumStockQuantity(int productNo)
        {
            return this.repository.GetSumStockQuantity(productNo);
        }


        /// <summary>
        /// 在庫情報登録を行う。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<BaseResponse> RegistryInventory(RegistryInventoryRequest request)
        {
            return repository.RegistryInventory(request);
        }

        /// <summary>
        /// 在庫情報を引当中に更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        public Task<UpdateInventoryResponse> UpdateInventory2Allowcated(int inventoryNo)
        {
            return repository.UpdateInventory2Allowcated(inventoryNo);
        }

        /// <summary>
        /// 在庫情報を出庫済みに更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        public Task<UpdateInventoryResponse> UpdateInventory2Delivered(int inventoryNo)
        {
            return repository.UpdateInventory2Delivered(inventoryNo);
        }

        /// <summary>
        /// 在庫情報を破棄・廃棄に更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        public Task<UpdateInventoryResponse> UpdateInventory2Discard(int inventoryNo)
        {
            return repository.UpdateInventory2Discard(inventoryNo);
        }

        /// <summary>
        /// 在庫情報を注文中に更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        public Task<UpdateInventoryResponse> UpdateInventory2Order(int inventoryNo)
        {
            return repository.UpdateInventory2Order(inventoryNo);
        }


        /// <summary>
        /// 在庫情報を入庫済みに更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        public Task<UpdateInventoryResponse> UpdateInventory2Stocked(int inventoryNo)
        {
            return repository.UpdateInventory2Stocked(inventoryNo);
        }
    }
}
