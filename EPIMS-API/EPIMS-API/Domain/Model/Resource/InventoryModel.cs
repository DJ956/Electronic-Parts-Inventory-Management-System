using EPIMS_API.Domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPIMS_API.Domain.Model.Resource
{
    public class InventoryModel
    {
        private readonly InventoryData data;

        public InventoryModel(InventoryData data)
        {
            this.data = data;
        }

        public int InventoryNo { get { return this.data.InventoryNo; } }

        public int ProductNo { get { return this.data.ProductNo; } }

        public int StockQuantity { get { return this.data.StockQuantity; } }

        public DateTime DeliveredDate { get { return this.data.DeliveredDate; } }

        public string Loacation { get { return this.data.Location; } }

        public string StatusCode { get { return this.data.StatusCode; } }

        public string StatucCodeaName { get; set; } = "";
    }
}
