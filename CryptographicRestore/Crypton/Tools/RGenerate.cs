using System.Security.Cryptography;

namespace CryptographicRestore.Crypton.Tools;

/// <summary>
/// 密钥生成
/// </summary>
public static class RGenerate
{
    /// <summary>
    /// 生成随机密钥
    /// </summary>
    /// <returns></returns>
    public static byte[] GenerateKey()
    {
        using (Aes aes = Aes.Create())
        {
            aes.GenerateKey();
            return aes.Key;
        }
    }

    /// <summary>
    /// 生成随机初始向量
    /// </summary>
    /// <returns></returns>
    public static byte[] GenerateIV()
    {
        using (Aes aes = Aes.Create())
        {
            aes.GenerateIV();
            return aes.IV;
        }
    }
}