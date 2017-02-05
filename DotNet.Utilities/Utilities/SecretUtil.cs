//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Web.Security;

namespace DotNet.Utilities
{
    public class SecretUtil
    {
        #region public static string SqlSafe(string value) 检查参数的安全性
        /// <summary>
        /// 检查参数的安全性
        /// </summary>
        /// <param name="value">参数</param>
        /// <returns>安全的参数</returns>
        public static string SqlSafe(string value)
        {
            value = value.Replace("'", "''");
            // value = value.Replace("%", "'%");
            return value;
        }
        #endregion

        #region public static bool CheckRegister() 检查注册码是否正确
        /// <summary>
        /// 检查注册码是否正确
        /// </summary>
        /// <returns>是否进行了注册</returns>
        public static bool CheckRegister()
        {
            bool returnValue = true;
            // if (BaseConfiguration.Instance.CustomerCompanyName.Length == 0)
            // {
            //     returnValue = false;
            // }
            // 只能先用一年再说,否则会惹很多麻烦
            if (BaseSystemInfo.NeedRegister)
            {
                if ((DateTime.Now.Year >= 2014) && (DateTime.Now.Month > 7))
                {
                    returnValue = false;
                }
            }
            // 一定要检查注册码,否则这个软件到处别人复制,我的基类也得不到保障了,这是我的心血,得会珍惜自己的劳动成果.
            // 2007.04.14 JiRiGaLa 改进注册方式,让底层程序更安全一些
            //if (BaseConfiguration.Instance.RegisterKey.Equals(CodeChange(BaseConfiguration.Instance.DataBase + BaseConfiguration.Instance.CustomerCompanyName)))
            //{
            //    returnValue = true;
            //}
            return returnValue;
        }
        #endregion


        //
        // 一 用户密码加密函数
        //

        /// <summary>
        /// 用户密码加密函数
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns>加密值</returns>
        public static string md5(string password)
        {
            return md5(password, 32);
        }


        /// <summary>
        /// 加密用户密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="codeLength">多少位</param>
        /// <returns>加密密码</returns>
        public static string md5(string password, int codeLength)
        {
            if (!string.IsNullOrEmpty(password))
            {
                // 16位MD5加密（取32位加密的9~25字符）  
                if (codeLength == 16)
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5").ToLower().Substring(8, 16);
                }

                // 32位加密
                if (codeLength == 32)
                {
                    return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "MD5").ToLower();
                }
            }
            return string.Empty;
        }


        #region 16位MD5加密 public static string MD5Encrypt16(string password)
        /// <summary>
        /// 16位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt16(string password)
        {
            var md5 = new MD5CryptoServiceProvider();
            string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(password)), 4, 8);
            t2 = t2.Replace("-", "");
            return t2;
        }

        #endregion

        #region 32位MD5加密 public static string MD5Encrypt32(string password)
        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string MD5Encrypt32(string password)
        {
            string cl = password;
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
        #endregion

        // 编码
        public static string EncodeBase64(string codeType, string code)
        {
            string encode = "";
            byte[] bytes = Encoding.GetEncoding(codeType).GetBytes(code);
            try
            {
                encode = Convert.ToBase64String(bytes);
            }
            catch
            {
                encode = code;
            }
            return encode;
        }

        // 解码
        public static string DecodeBase64(string codeType, string code)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(code);
            try
            {
                decode = Encoding.GetEncoding(codeType).GetString(bytes);
            }
            catch
            {
                decode = code;
            }
            return decode;
        }



        /// <summary>
        /// DES数据加密
        /// </summary>
        /// <param name="targetValue">目标字段</param>
        /// <returns>加密</returns>
        public static string Encrypt(string targetValue)
        {
            return Encrypt(targetValue, "DotNetKey");
        }

        /// <summary>
        /// DES数据加密
        /// </summary>
        /// <param name="targetValue">目标值</param>
        /// <param name="key">密钥</param>
        /// <returns>加密值</returns>
        public static string Encrypt(string targetValue, string key)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }

            var returnValue = new StringBuilder();
            var des = new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(targetValue);
            // 通过两次哈希密码设置对称算法的初始化向量   
            des.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                  (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").
                                                       Substring(0, 8), "sha1").Substring(0, 8));
            // 通过两次哈希密码设置算法的机密密钥   
            des.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                 (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                                                      .Substring(0, 8), "md5").Substring(0, 8));
            var ms = new MemoryStream();
            var cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            foreach (byte b in ms.ToArray())
            {
                returnValue.AppendFormat("{0:X2}", b);
            }
            return returnValue.ToString();
        }


        /// <summary>
        /// DES数据解密
        /// </summary>
        /// <param name="targetValue">目标字段</param>
        /// <returns>解密</returns>
        public static string Decrypt(string targetValue)
        {
            return Decrypt(targetValue, "DotNetKey");
        }

        /// <summary>
        /// DES数据解密
        /// </summary>
        /// <param name="targetValue"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Decrypt(string targetValue, string key)
        {
            if (string.IsNullOrEmpty(targetValue))
            {
                return string.Empty;
            }
            // 定义DES加密对象
            var des = new DESCryptoServiceProvider();   
            int len = targetValue.Length / 2;
            var inputByteArray = new byte[len];
            int x, i;
            for (x = 0; x < len; x++)
            {
                i = Convert.ToInt32(targetValue.Substring(x * 2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            // 通过两次哈希密码设置对称算法的初始化向量   
            des.Key = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                  (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5").
                                                       Substring(0, 8), "sha1").Substring(0, 8));
            // 通过两次哈希密码设置算法的机密密钥   
            des.IV = Encoding.ASCII.GetBytes(FormsAuthentication.HashPasswordForStoringInConfigFile
                                                 (FormsAuthentication.HashPasswordForStoringInConfigFile(key, "md5")
                                                      .Substring(0, 8), "md5").Substring(0, 8));
            // 定义内存流
            var ms = new MemoryStream();   
            // 定义加密流
            var cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);   
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }




        /// <summary>
        /// 获取私钥
        /// </summary>
        /// <param name="digitalSignatureFile">数字证书文件</param>
        /// <param name="signedPassword">签名密码</param>
        /// <returns>私钥</returns>
        public static string GetPrivateKey(string digitalSignatureFile, string signedPassword)
        {
            // 0:这里需要处理异常信息
            // 1:定义私钥
            string privateKey = string.Empty;
            // 2:读取证书文件
            string digitalSignature = FileUtil.ReadBinaryFile(digitalSignatureFile);
            // 3:解密文件
            string xmlFile = SecretUtil.Decrypt(digitalSignature);
            // 4:按XML文件读取
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlFile);
            string keySignedPassword = xmlDocument.SelectSingleNode("//DigitalSignature/Key").Attributes["SignedPassword"].Value;
            // 5:若签名密码不对，不应该能读取私钥
            if (md5(signedPassword, 32).Equals(keySignedPassword))
            {
                privateKey = xmlDocument.SelectSingleNode("//DigitalSignature/Key").Attributes["PrivateKey"].Value;
            }
            return privateKey;
        }

        /// <summary>
        /// 获取签名密码
        /// </summary>
        /// <param name="digitalSignatureFile">数字证书文件</param>
        /// <returns>私钥</returns>
        public static string GetSignedPassword(string digitalSignatureFile)
        {
            // 0:这里需要处理异常信息
            // 1:定义私钥
            string signedPassword = string.Empty;
            // 2:读取证书文件
            string digitalSignature = FileUtil.ReadBinaryFile(digitalSignatureFile);
            // 3:解密文件
            string xmlFile = SecretUtil.Decrypt(digitalSignature);
            // 4:按XML文件读取
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xmlFile);
            signedPassword = xmlDocument.SelectSingleNode("//DigitalSignature/Key").Attributes["SignedPassword"].Value;
            return signedPassword;
        }

        /// <summary>
        /// 对数据进行签名
        /// 
        /// 将来需要改进为，对散列值进行签名
        /// </summary>
        /// <param name="dataToSign">需要签名的数据</param>
        /// <param name="privateKey">私钥</param>
        /// <returns>签名结果</returns>
        public static string HashAndSign(string dataToSign, string privateKey)
        {
            ASCIIEncoding byteConverter = new ASCIIEncoding();
            byte[] DataToSign = byteConverter.GetBytes(dataToSign);
            try
            {
                RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
                cryptoServiceProvider.ImportCspBlob(Convert.FromBase64String(privateKey));
                byte[] SignedData = cryptoServiceProvider.SignData(DataToSign, new SHA1CryptoServiceProvider());
                string signedData = Convert.ToBase64String(SignedData);
                return signedData;
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// 验证数字签名
        /// 
        /// 将来需要改进为，按散列值进行验证
        /// </summary>
        /// <param name="dataToVerify">需要验证的数据</param>
        /// <param name="signedData">签名结果</param>
        /// <param name="publicKey">公钥</param>
        /// <returns>正确</returns>
        public static bool VerifySignedHash(string dataToVerify, string signedData, string publicKey)
        {
            byte[] SignedData = Convert.FromBase64String(signedData);

            ASCIIEncoding byteConverter = new ASCIIEncoding();
            byte[] DataToVerify = byteConverter.GetBytes(dataToVerify);
            try
            {
                RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider();
                cryptoServiceProvider.ImportCspBlob(Convert.FromBase64String(publicKey));
                return cryptoServiceProvider.VerifyData(DataToVerify, new SHA1CryptoServiceProvider(), SignedData);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}