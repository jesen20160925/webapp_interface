using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMSD.WebApp.Domain.BackData
{
    /// <summary>
    /// 带BD的为返回数据实体 Back Data
    /// </summary>
    public class ProductBD
    {
        public int ProductId { get; set; }

        public string ProductCode { get; set; }

        public string ProductName { get; set; }

        public string Img { get; set; }

        public decimal Price { get; set; }

        public decimal Pv { get; set; }

        public int IsHot { get; set; }

        public int IsNew { get; set; }

        public decimal Discount { get; set; }

        /// <summary>
        ///积分
        /// </summary>
        public decimal Integral { get; set; }

    }
}
