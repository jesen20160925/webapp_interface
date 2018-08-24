using KMSD.WebApp.Core.Ioc;
using KMSD.WebApp.Domain.BackData;
using KMSD.WebApp.Log;
using KMSD.WebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMSD.WebApp.Service
{
    /// <summary>
    /// 首页数据
    /// author:胡进顺
    /// date:2018-07-24
    /// </summary>
    public interface IHomeService : IAutofacDependency
    {
        BackMessage GetHomeIndexData();
    }

    /// <summary>
    /// 首页数据
    /// author:胡进顺
    /// date:2018-07-24
    /// </summary>
    public class HomeService : BaseRepositoryFactory, IHomeService
    {
        /// <summary>
        /// 获取首页数据
        /// </summary>
        /// <returns></returns>
        public BackMessage GetHomeIndexData()
        {
            BackMessage backMessage = new BackMessage();
            try
            {
                HomeIndexBD homeIndexBD = new HomeIndexBD();
                homeIndexBD.Banner = GetBanner() as List<Banner>;
                homeIndexBD.HomeJBox = GetHomeJBox() as List<HomeJBox>;
                homeIndexBD.Notice = GetNotice();
                homeIndexBD.Products = GetProducts();
                homeIndexBD.BottomAd = GetBottomAd() as List<BottomAd>;

                backMessage.Code = 200;
                backMessage.Msg = "success";
                backMessage.Data = homeIndexBD;
                return backMessage;

            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }


        /// <summary>
        /// 获取首页Banner图
        /// </summary>
        /// <returns></returns>
        private IList<Banner> GetBanner()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT ImgPath AS Img,ImgTitle AS Title,'' AS Url FROM IndexPhoto WHERE IsUse = 1 and PhotoType = 1;");

            return this.BaseRepository().FindList<Banner>(sb.ToString()).ToList();
        }

        /// <summary>
        /// 获取首页工具箱
        /// </summary>
        /// <returns></returns>
        private IList<HomeJBox> GetHomeJBox()
        {
            return new List<HomeJBox>() {
                new HomeJBox(){ ImgUrl="", Name="产品套装系列", PathUrl="", CategoryId=2},
                new HomeJBox(){ ImgUrl="", Name="家居清洁护理品", PathUrl="", CategoryId=481},
                new HomeJBox(){ ImgUrl="", Name="营养保健食品", PathUrl="", CategoryId=478},
                new HomeJBox(){ ImgUrl="", Name="美容护肤品", PathUrl="", CategoryId=479},
                new HomeJBox(){ ImgUrl="", Name="个人护理品", PathUrl="", CategoryId=480},
                new HomeJBox(){ ImgUrl="", Name="家居健康用品", PathUrl="", CategoryId=482},
                new HomeJBox(){ ImgUrl="", Name="辅销产品", PathUrl="", CategoryId=3},
                new HomeJBox(){ ImgUrl="", Name="时代商城", PathUrl="", CategoryId=0},
            };
        }

        /// <summary>
        /// 获取首页的通知信息，6条
        /// </summary>
        /// <returns></returns>
        private Notice GetNotice()
        {
            Notice notice = new Notice();

            StringBuilder sb = new StringBuilder();
            sb.Append(@"SELECT TOP(6) ClassID AS TYPE,SendDate AS TIME,InfoTitle AS Title,Content AS Content FROM MessageSend ms WHERE ms.LoginRole=2 AND ms.MessageType='a' ORDER BY ms.ID DESC;");

            var noticeInfo = this.BaseRepository().FindList<NoticeInfo>(sb.ToString()).ToList();

            notice.HasNotice = noticeInfo != null ? true : false;

            notice.NoticeInfo = noticeInfo;

            return notice;
        }

        /// <summary>
        /// 获取首页的产品信息
        /// </summary>
        /// <returns></returns>
        private Products GetProducts()
        {
            Products products = new Products();

            StringBuilder sb = new StringBuilder();
            sb.Append(@" SELECT p.ProductID AS ProductId,p.ProductCode AS ProductCode,p.ProductName AS ProductName,
                    p.ProductImage AS Img,p.PreferentialPrice AS Price,p.PreferentialPV AS Pv, 1 AS Discount,p.IsHot,p.IsNew  
                    FROM Product p WHERE p.IsHot = 1 OR p.IsNew = 1 ;");

            var productBDList = this.BaseRepository().FindList<ProductBD>(sb.ToString());

            //如果已登录，要看级别，算折扣，游客不需要

            //products.NewProducts = ( from p in productBDList
            //                       where p.IsNew == 1
            //                       select p ).ToList();

            if (productBDList != null)
            {
                var newProducts = productBDList.Where(p => p.IsNew == 1);
                products.NewProducts = newProducts == null ? null : newProducts.ToList();
                var hotProducts = productBDList.Where(p => p.IsHot == 1);
                products.HotSellProducts = hotProducts == null ? null : hotProducts.ToList();
            }

            return products;

        }

        /// <summary>
        /// 获取底部广告
        /// </summary>
        /// <returns></returns>
        private IList<BottomAd> GetBottomAd()
        {
            return new List<BottomAd>()
            {
                new BottomAd(){ Img="",Url=""},
                new BottomAd(){Img="",Url=""}
            };
        }
    }
}
