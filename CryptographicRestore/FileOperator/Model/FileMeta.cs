namespace CryptographicRestore.FileOperator;

/// <summary>
/// 文件原数据
/// </summary>
public class FileMeta
{
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// 修改时间
    /// </summary>
    public DateTime ModifiedTime { get; set; }

    /// <summary>
    /// 文件访问时间
    /// </summary>
    public DateTime AccessedTime { get; set; }
}