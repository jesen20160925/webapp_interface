using KMSD.WebApp.Domain.BackData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace KMSD.WebApp.Core.Result
{
    /// <summary>
    /// 返回消息封装
    /// Author:胡进顺
    /// Date:2018-08-22
    /// </summary>
    public class CustomResult
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        public static JsonResult ErrorMessage(string errMsg)
        {
            return new JsonResult()
            {
                Data = new BackMessage
                {
                    Code = 500,
                    Msg = errMsg,
                    Data = null
                }
            };
        }

        /// <summary>
        /// 正确返回字符串消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static JsonResult SuccessMessage(string msg)
        {
            return new JsonResult()
            {
                Data = new BackMessage()
                {
                    Code = 200,
                    Msg = msg,
                    Data = null
                }
            };
        }

        /// <summary>
        /// 正确返回对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static JsonResult SuccessMessage<T>(T data)
        {
            return new JsonResult()
            {
                Data = new BackMessage()
                {
                    Code = 200,
                    Msg = "success",
                    Data = data
                }
            };
        }
    }
}
