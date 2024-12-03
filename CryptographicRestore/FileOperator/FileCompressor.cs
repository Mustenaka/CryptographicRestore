using System.IO.Compression;

namespace CryptographicRestore.FileOperator;

public static class FileCompressor
{
    /// <summary>
    /// 将指定的文件夹压缩为ZIP文件
    /// </summary>
    /// <param name="sourceFolderPath">源文件夹路径</param>
    /// <param name="zipFilePath">目标ZIP文件路径</param>
    public static void CompressFolderToZip(string sourceFolderPath, string zipFilePath)
    {
        // 检查源文件夹是否存在
        if (!Directory.Exists(sourceFolderPath))
        {
            throw new DirectoryNotFoundException($"源文件夹 '{sourceFolderPath}' 不存在。");
        }

        // 如果zipFilePath已经有，则覆盖
        if (File.Exists(zipFilePath))
        {
            File.Delete(zipFilePath);
        }

        // 创建并压缩文件夹
        ZipFile.CreateFromDirectory(sourceFolderPath, zipFilePath, CompressionLevel.Fastest, includeBaseDirectory: false);

        // 可选：如果需要保留文件夹本身而非仅包含文件，可以将 includeBaseDirectory 设置为 true
        // ZipFile.CreateFromDirectory(sourceFolderPath, zipFilePath, CompressionLevel.Fastest, includeBaseDirectory: true);
    }

    /// <summary>
    /// 将指定的ZIP文件解压到指定文件夹
    /// </summary>
    /// <param name="zipFilePath">源ZIP文件路径</param>
    /// <param name="destinationFolderPath">目标文件夹路径</param>
    public static void ExtractZipToFolder(string zipFilePath, string destinationFolderPath)
    {
        // 检查ZIP文件是否存在
        if (!File.Exists(zipFilePath))
        {
            throw new FileNotFoundException($"ZIP文件 '{zipFilePath}' 不存在。");
        }

        // 如果目标文件夹不存在，则创建它
        if (!Directory.Exists(destinationFolderPath))
        {
            Directory.CreateDirectory(destinationFolderPath);
        }

        // 解压文件到目标文件夹
        ZipFile.ExtractToDirectory(zipFilePath, destinationFolderPath);
    }
}