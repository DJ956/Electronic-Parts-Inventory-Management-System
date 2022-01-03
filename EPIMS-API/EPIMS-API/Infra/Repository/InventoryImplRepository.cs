using EPIMS_API.Domain.Context;
using EPIMS_API.Domain.Data;
using EPIMS_API.Domain.Factory;
using EPIMS_API.Domain.Model.Request.Inventory;
using EPIMS_API.Domain.Model.Response;
using EPIMS_API.Domain.Model.Response.Inventory;
using EPIMS_API.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Infra.Repository
{
    public class InventoryImplRepository : IInventoryRepository
    {

        private readonly EPIMSContext context;
        private readonly IInventoryModelFactory factory;

        public InventoryImplRepository(EPIMSContext context, IInventoryModelFactory factory)
        {
            this.context = context;
            this.factory = factory;
        }


        /// <summary>
        /// 在庫情報を取得する
        /// </summary>
        /// <param name="inventoryNo"></param>
        /// <returns></returns>
        public async Task<GetInventoryResponse> GetInventory(int inventoryNo)
        {
            var response = new GetInventoryResponse();
            var inventory = context.InventoryDatas.Where(i => i.InventoryNo == inventoryNo).FirstOrDefault();
            if (inventory == null)
            {
                response.ReturnCode = 1;
                response.Message = $"在庫情報が見つかりませんでした。(在庫番号={inventoryNo})";
                return response;
            }

            response.Inventory = factory.BuildModel(inventory);
            return response;
        }

        /// <summary>
        /// 製品番号と一致する在庫情報リストを取得する
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        public async Task<GetInventoryListResponse> GetInventoryList(int productNo)
        {
            var response = new GetInventoryListResponse();
            var list = context.InventoryDatas.Where(i => i.ProductNo == productNo);
            if (list.Any() == false)
            {
                response.ReturnCode = 1;
                response.Message = $"製品番号と一致する在庫情報が見つかりませんでした。(製品番号={productNo})";
                return response;
            }

            list.ToList().ForEach(i =>
            {
                response.Inventories.Add(factory.BuildModel(i));
            });

            return response;
        }

        /// <summary>
        /// 在庫数を取得する取得される在庫数はステータスコードが002:入庫済のもののみとなる。
        /// </summary>
        /// <param name="productNo"></param>
        /// <returns></returns>
        public async Task<GetSumStockQuantityResponse> GetSumStockQuantity(int productNo)
        {
            var response = new GetSumStockQuantityResponse();
            var list = context.InventoryDatas.Where(i => i.ProductNo == productNo && i.StatusCode == "002");
            if (list.Any() == false)
            {
                response.SumStockQuantity = 0;
                return response;
            }

            list.ToList().ForEach(i =>
            {
                response.SumStockQuantity += i.StockQuantity;
            });

            return response;
        }

        /// <summary>
        /// 在庫情報登録を行う。
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<BaseResponse> RegistryInventory(RegistryInventoryRequest request)
        {
            var response = new BaseResponse();
            //製品番号チェック
            var existsProduct = context.ProductDatas.Where(p => p.ProductNo == request.ProductNo).FirstOrDefault();
            if (existsProduct == null)
            {
                response.ReturnCode = 1;
                response.Message = $"製品が見つかりませんでした。(製品番号={request.ProductNo})";
                return response;
            }
            //コードマスタチェック
            var ivntList = context.CodeMasters.Where(c => c.ID == "IVNT").ToList();
            bool existsCode = ivntList.Exists(c => c.Code == request.StatusCode);
            if (existsCode == false)
            {
                response.ReturnCode = 1;
                response.Message = $"ステータスコードの値が不正です。(ステータスコード={request.StatusCode})";
                return response;
            }

            //データ追加
            var addData = new InventoryData()
            {
                ProductNo = request.ProductNo,
                StockQuantity = request.StockQuantity,
                DeliveredDate = request.DeliveredDate,
                Location = request.Location,
                StatusCode = request.StatusCode
            };


            await context.InventoryDatas.AddAsync(addData);
            int ret = await context.SaveChangesAsync();
            if (ret < 0)
            {
                response.ReturnCode = 1;
                response.Message = "在庫情報の登録に失敗しました。";
            }

            return response;
        }

        private async Task<UpdateInventoryResponse> UpdateInventory(int inventoryNo, string statusCode)
        {
            var response = new UpdateInventoryResponse();
            //在庫番号チェック
            var inventory = context.InventoryDatas.Where(i => i.InventoryNo == inventoryNo).FirstOrDefault();
            if (inventory == null)
            {
                response.ReturnCode = 1;
                response.Message = $"在庫情報見つかりませんでした。(在庫番号={inventoryNo})";
                return response;
            }

            inventory.StatusCode = statusCode;
            context.InventoryDatas.Update(inventory);

            int ret = await context.SaveChangesAsync();
            if (ret < 0)
            {
                response.ReturnCode = 1;
                response.Message = $"在庫情報の更新に失敗しました。";
            }

            return response;
        }


        public Task<UpdateInventoryResponse> UpdateInventory2Allowcated(int inventoryNo)
        {
            return this.UpdateInventory(inventoryNo, "003");
        }

        public Task<UpdateInventoryResponse> UpdateInventory2Delivered(int inventoryNo)
        {
            return this.UpdateInventory(inventoryNo, "004");
        }

        public Task<UpdateInventoryResponse> UpdateInventory2Discard(int inventoryNo)
        {
            return this.UpdateInventory(inventoryNo, "005");
        }

        public Task<UpdateInventoryResponse> UpdateInventory2Order(int inventoryNo)
        {
            return this.UpdateInventory(inventoryNo, "001");
        }

        public Task<UpdateInventoryResponse> UpdateInventory2Stocked(int inventoryNo)
        {
            return this.UpdateInventory(inventoryNo, "002");
        }

    }
}
