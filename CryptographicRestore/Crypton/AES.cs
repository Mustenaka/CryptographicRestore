using CryptographicRestore.FileOperator;
using System.Security.Cryptography;

namespace CryptographicRestore.Crypton;

/// <summary>
/// AES 加密算法，包含如下模块
///     1. 加密文件并保存元数据
///     2. 解密文件并恢复元数据
///     3. 验证文件完整性
/// </summary>
public static class AES
{
    /// <summary>
    /// 加密文件并保存元数据
    /// </summary>
    /// <param name="inputFilePath">原始文件</param>
    /// <param name="outputFilePath">加密文件</param>
    /// <param name="key">Key文件</param>
    /// <param name="iv">IV向量</param>
    public static void EncryptFile(string inputFilePath, string outputFilePath, byte[] key, byte[] iv)
    {
        // 加密文件内容
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            aes.Padding = PaddingMode.PKCS7; // 确保填充模式一致

            using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            using (CryptoStream cryptoStream = new CryptoStream(outputFileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
            {
                inputFileStream.CopyTo(cryptoStream);
            }
        }
    }

    /// <summary>
    /// 解密文件并恢复元数据
    /// </summary>
    /// <param name="inputFilePath"></param>
    /// <param name="outputFilePath"></param>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    public static void DecryptFile(string inputFilePath, string outputFilePath, byte[] key, byte[] iv, ref FileMeta metadata)
    {
        // 解密文件内容
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            aes.Padding = PaddingMode.PKCS7; // 确保填充模式一致

            using (FileStream inputFileStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream outputFileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
            using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
            {
                cryptoStream.CopyTo(outputFileStream);
            }
        }

        // 恢复元数据
        FileInfo fileInfo = new FileInfo(outputFilePath);
        fileInfo.CreationTimeUtc = metadata.CreatedTime;
        fileInfo.LastWriteTimeUtc = metadata.ModifiedTime;
        fileInfo.LastAccessTimeUtc = metadata.AccessedTime;
    }

    /// <summary>
    /// 获取文件元数据
    /// </summary>
    /// <param name="inputFilePath"></param>
    /// <returns></returns>
    public static FileMeta GetFileMeta(string inputFilePath)
    {
        FileInfo fileInfo = new FileInfo(inputFilePath);

        // 保存元数据
        FileMeta metadata = new()
        {
            CreatedTime = fileInfo.CreationTimeUtc,
            ModifiedTime = fileInfo.LastWriteTimeUtc,
            AccessedTime = fileInfo.LastAccessTimeUtc
        };

        return metadata;
    }

    /// <summary>
    /// 获取文件大小
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    /// <exception cref="FileNotFoundException"></exception>
    public static long GetFileSize(string filePath)
    {
        // 检查文件是否存在
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("文件不存在: " + filePath);
        }

        // 使用 FileInfo 获取文件大小
        FileInfo fileInfo = new FileInfo(filePath);
        return fileInfo.Length; // 返回字节大小
    }

    /// <summary>
    /// 验证文件完整性
    /// </summary>
    /// <param name="filePath1"></param>
    /// <param name="filePath2"></param>
    /// <returns></returns>
    public static bool VerifyFileIntegrity(string filePath1, string filePath2)
    {
        string hash1 = CalculateFileHash(filePath1);
        string hash2 = CalculateFileHash(filePath2);
        return hash1 == hash2;
    }

    /// <summary>
    /// 计算文件的 MD5 哈希值（信息摘要）
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static string CalculateFileHash(string filePath)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (MD5 md5 = MD5.Create())
        {
            byte[] hashBytes = md5.ComputeHash(fileStream);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }

    /// <summary>
    /// 计算文件的 SHA1 哈希值（信息摘要）
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static string CalculateFileSHA1(string filePath)
    {
        using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] hashBytes = sha1.ComputeHash(fileStream);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
        }
    }
}