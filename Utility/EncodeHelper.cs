using System.Security.Cryptography;
using System;
using System.Text;

namespace CoreMVCBackend.Utility{
    public class EncodeHelper{
        public static string Encode(object EncodeType,string txt){
            string result=string.Empty;
            byte[] buff;
            try{
                buff=Encoding.UTF8.GetBytes(txt);
                switch(EncodeType){
                    case EncodeEnum.SHA1:
                        buff=new SHA1CryptoServiceProvider().ComputeHash(buff);
                    break;
                    case EncodeEnum.SHA256:
                        buff=new SHA256CryptoServiceProvider().ComputeHash(buff);
                    break;
                    case EncodeEnum.MD5:
                        buff=new MD5CryptoServiceProvider().ComputeHash(buff);
                    break;
                }
                result=BitConverter.ToString(buff);
            }catch(Exception ex){
                throw ex;
            }
            return result;
        }
    }
}