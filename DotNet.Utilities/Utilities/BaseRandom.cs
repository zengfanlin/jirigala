//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
	/// <summary>
    /// BaseRandom
	/// 产生随机数
	/// 
	/// 随机数管理，最大值、最小值可以自己进行设定。
	/// 
    /// 修改纪录
    /// 
    ///     2009.07.08 版本：3.0 JiRiGaLa	更新完善程序，将方法修改为静态方法。
    ///		2007.06.30 版本：3.2 JiRiGaLa   产生随机字符。
    ///		2006.02.05 版本：3.1 JiRiGaLa   重新调整主键的规范化。
    ///		2004.11.12 版本：3.0 JiRiGaLa   最后修改，改进成以后可以扩展到多种数据库的结构形式。
    ///	    2004.11.12 版本：3.0 JiRiGaLa   一些方法改进，主键格式优化，基本上看上去还过得去了。
    ///     2005.03.07 版本：2.0 JiRiGaLa   2005.03.07 更新程序排版。
    ///     2005.08.13 版本：1.0 JiRiGaLa   参数格式标准化。
    ///     
    /// 版本：3.2
	/// <author>
	///		<name>JiRiGaLa</name>
    ///		<date>2007.06.30</date>
	/// </author> 
	/// </summary>
	public class BaseRandom
	{
		public static int Minimum = 100000;
        public static int Maximal = 999999;
        public static int RandomLength = 6;

        private static string RandomString = "123456789ABCDEFGHIJKMLNPQRSTUVWXYZ";
        private static Random Random = new Random(DateTime.Now.Second);

        #region public static string GetRandomString() 产生随机字符
        /// <summary>
        /// 产生随机字符
        /// </summary>
        /// <returns>字符串</returns>
        public static string GetRandomString()
        {
            string returnValue = string.Empty;
            for (int i = 0; i < RandomLength; i++)
            {
                int r = Random.Next(0, RandomString.Length - 1);
                returnValue += RandomString[r];
            }
            return returnValue;
        }
        #endregion

        #region public static int GetRandom()
        /// <summary>
        /// 产生随机数
        /// </summary>
        /// <returns>随机数</returns>
        public static int GetRandom()
		{
			return Random.Next(Minimum, Maximal);
		}
		#endregion

        #region public static int GetRandom(int minimum, int maximal)
        /// <summary>
		/// 产生随机数
		/// </summary>
		/// <param name="minimum">最小值</param>
		/// <param name="maximal">最大值</param>
		/// <returns>随机数</returns>
        public static int GetRandom(int minimum, int maximal)
		{
            return Random.Next(minimum, maximal);
		}
		#endregion
	}
}