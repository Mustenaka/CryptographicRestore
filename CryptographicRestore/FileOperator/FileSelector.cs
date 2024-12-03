namespace CryptographicRestore.FileOperator;

/// <summary>
/// 文件选择器
/// </summary>
public static class FileSelector
{
    /// <summary>
    /// 打开文件选择窗口，选择指定格式的文件
    /// </summary>
    /// <param name="filter">文件过滤器，例如 "所有文件 (*.*)|*.*"</param>
    /// <returns>所选文件的路径，如果没有选择文件则返回 null</returns>
    public static string? SelectFile(string filter = "所有文件 (*.*)|*.*")
    {
        using (var openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = filter;
            openFileDialog.Title = @"请选择一个文件";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
        }

        return null;
    }

    /// <summary>
    /// 打开文件夹选择窗口，选择一个文件夹并返回其路径
    /// </summary>
    /// <returns>所选文件夹的路径，如果没有选择文件夹则返回 null</returns>
    public static string? SelectFolder()
    {
        using (var folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = @"请选择一个文件夹";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
        }

        return null;
    }

    /// <summary>
    /// 打开文件夹选择窗口，选择目标路径，并将指定文件拷贝到该路径
    /// </summary>
    /// <param name="sourceFilePath">源文件路径</param>
    /// <returns>如果拷贝成功则返回目标文件路径，否则返回 null</returns>
    public static string? CopyFileToSelectedPath(string sourceFilePath)
    {
        using (var folderBrowserDialog = new FolderBrowserDialog())
        {
            folderBrowserDialog.Description = @"请选择目标文件夹";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string targetFolderPath = folderBrowserDialog.SelectedPath;
                string targetFilePath = Path.Combine(targetFolderPath, Path.GetFileName(sourceFilePath));

                try
                {
                    File.Copy(sourceFilePath, targetFilePath, overwrite: true);
                    return targetFilePath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($@"文件拷贝失败: {ex.Message}", @"错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        return null;
    }

    /// <summary>
    /// 获取文件名和后缀名
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static (string FileName, string FileExtension) GetFileNameAndExtension(string filePath)
    {
        // 获取文件名（不含路径）
        string fileName = Path.GetFileNameWithoutExtension(filePath);

        // 获取文件扩展名
        string fileExtension = Path.GetExtension(filePath);

        return (fileName, fileExtension);
    }
}