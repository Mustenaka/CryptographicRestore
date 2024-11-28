namespace CryptographicRestore.Crypton.Model;

/// <summary>
/// AES算法需要保存数据
/// </summary>
public class AESModel
{
    /// <summary>
    /// Key文件
    /// </summary>
    public byte[] Key { get; set; }

    /// <summary>
    /// IV向量
    /// </summary>
    public byte[] IV { get; set; }
}