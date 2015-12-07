﻿using NetworkSocket.Core;
using NetworkSocket.Fast;
using FastServer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastServer.Filters
{
    /// <summary>
    /// 表示登录过滤器
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class LoginFilterAttribute : FastFilterAttribute
    {
        /// <summary>
        /// 登录过滤器
        /// </summary>
        public LoginFilterAttribute()
        {
            this.Order = -1;
        }

        protected override void OnExecuting(ActionContext filterContext)
        {
            var valid = filterContext.Session.TagData.TryGet<bool>("Logined");
            if (valid == false)
            {
                // 直接关闭客户端的连接
                // filterContext.Session.Close();

                // 以异常方式提示客户端
                throw new Exception("未登录就尝试请求其它服务");
            }
        }
    }
}
