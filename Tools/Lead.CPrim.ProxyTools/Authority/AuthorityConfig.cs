using Lead.CPrim.Interfaces;

namespace Lead.CPrim.ProxyTools.Authority
{
	/// <summary>权限管理级别配置</summary>
	public class AuthorityConfig
	{
		/// <summary>管理员</summary>
		public string Administrator { get; set; }
		/// <summary>开发者</summary>
		public string Development { get; set; }
		/// <summary>维护员</summary>
		public string Maintenance { get; set; }
	}

	/// <summary>加密狗</summary>
	public class SoftLockConfig
	{
		/// <summary>加密狗注册码</summary>
		public string CurRegisterCode { get; set; }
		/// <summary>加密狗最高级别</summary>
		public OpLevel MaxOpLvl { get; set; }
	}

	/// <summary>权限类</summary>
	public class AuthorityDb
    {
		/// <summary>用户名</summary>
        public string UserName { get; set; }

		/// <summary>用户ID卡号</summary>
        public string UserId { get; set; }

		/// <summary>工号</summary>
        public string ID { get; set; }

        /// <summary>密码</summary>
        public string PassWord { get; set; }

		/// <summary>登录级别</summary>
        public OpLevel Level { get; set; }
    }
}