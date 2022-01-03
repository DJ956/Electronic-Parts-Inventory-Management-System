using EPIMS_API.Domain.Model.Request.Inventory;
using EPIMS_API.Domain.Model.Response;
using EPIMS_API.Domain.Model.Response.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Repository
{
    public interface IInventoryRepository
    {

        /// <summary>
        /// 製品番号と一致する在庫情報リストを取得する
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        Task<GetInventoryListResponse> GetInventoryList(int productNo);

        /// <summary>
        /// 在庫合計数を取得する
        /// </summary>
        /// <param name="productNo">製品番号</param>
        /// <returns></returns>
        Task<GetSumStockQuantityResponse> GetSumStockQuantity(int productNo);

        /// <summary>
        /// 在庫情報を取得する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        Task<GetInventoryResponse> GetInventory(int inventoryNo);

        /// <summary>
        /// 在庫情報登録を行う
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<BaseResponse> RegistryInventory(RegistryInventoryRequest request);

        /// <summary>
        /// 在庫情報を注文中に更新する
        /// </summary>
        Task<UpdateInventoryResponse> UpdateInventory2Order(int inventoryNo);

        /// <summary>
        /// 在庫情報を入庫済に更新する
        /// </summary>
        Task<UpdateInventoryResponse> UpdateInventory2Stocked(int inventoryNo);

        /// <summary>
        /// 在庫情報を引当中に更新する
        /// </summary>
        Task<UpdateInventoryResponse> UpdateInventory2Allowcated(int inventoryNo);

        /// <summary>
        /// 在庫情報を出庫済に更新する
        /// </summary>
        Task<UpdateInventoryResponse> UpdateInventory2Delivered(int inventoryNo);

        /// <summary>
        /// 在庫情報を破棄・廃棄に更新する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        Task<UpdateInventoryResponse> UpdateInventory2Discard(int inventoryNo);

    }
}
