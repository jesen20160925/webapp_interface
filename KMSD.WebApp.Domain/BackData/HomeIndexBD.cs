using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Domain.BackData
{
    /// <summary>
    /// 首页数据
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class HomeIndexBD 
    {
        public List<Banner> Banner { get; set; }

        public List<HomeJBox> HomeJBox { get; set; }

        public Notice Notice { get; set; }

        public Products Products { get; set; }

        public List<BottomAd> BottomAd { get; set; }
    }

    /// <summary>
    /// 首页Banner
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class Banner
    {
        public string Img { get; set; }

        public string Title { get; set; }
        public string Url { get; set; }

    }

    /// <summary>
    /// 首页工具箱
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class HomeJBox
    {
        public string ImgUrl { get; set; }

        public string Name { get; set; }

        public string PathUrl { get; set; }

        public int CategoryId { get; set; }

    }

    /// <summary>
    /// 首页通知
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class Notice
    {
        public bool HasNotice { get; set; }

        public List<NoticeInfo> NoticeInfo { get; set; }
    }

    /// <summary>
    /// 通知信息
    /// author：胡进顺
    /// Date：2018-07-24
    /// </summary>
    public class NoticeInfo
    {
        public int Type { get; set; }

        public DateTime Time { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }


    public class Products
    {
        public List<ProductBD> NewProducts { get; set; }

        public List<ProductBD> HotSellProducts { get; set; }
    }

    public class BottomAd
    {
        public string Img { get; set; }

        public string Url { get; set; }

    }
}
