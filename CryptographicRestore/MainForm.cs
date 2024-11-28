using CryptographicRestore.Crypton;
using CryptographicRestore.Crypton.Model;
using CryptographicRestore.Crypton.Tools;
using CryptographicRestore.FileOperator;

namespace CryptographicRestore
{
    /// <summary>
    /// 主窗体
    ///     操作流程为：
    ///     1. 导入文件: 自动显示原始文件 md5, SHA1, 文件大小，创建时间，修改时间
    ///     2. 加密文件: 选择方法, 自动显示加密后文件 md5, SHA1, 文件大小，创建时间，修改时间
    ///     3. 解密文件: 自动显示解密后文件 md5, SHA1, 文件大小，创建时间，修改时间
    ///     4. 导出文件: 粘贴到另一个地方
    /// </summary>
    public partial class MainForm : Form
    {
        private AESModel aesModel;      // 加密模型
        private FileMeta meta;          // 文件元数据

        private string? originFile;     // 原始文件
        private string? cryptonFile;    // 加密文件
        private string? decryptFile;    // 解密文件（未导出）

        public MainForm()
        {
            InitializeComponent();

            aesModel = new AESModel();
            meta = new FileMeta();

            aesModel.Key = RGenerate.GenerateKey(); // 生成Key
            aesModel.IV = RGenerate.GenerateIV();   // 生成IV向量
        }

        /// <summary>
        /// 导入文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OriginInput_Click(object sender, EventArgs e)
        {
            // 获取原始文件
            originFile = FileSelector.SelectFile();

            if (string.IsNullOrEmpty(originFile))
            {
                Console.WriteLine(@"未载入文件");
                return;
            }

            Inp_OriginFile.Text = originFile;

            // md5, SHA1, 文件大小，创建时间，修改时间
            var md5 = AES.CalculateFileHash(originFile);
            var sha1 = AES.CalculateFileSHA1(originFile);
            var size = AES.GetFileSize(originFile);
            meta = AES.GetFileMeta(originFile);

            RText_Origin.Text =
                $@"size:{size}{Environment.NewLine}" +
                $@"md5:{md5}{Environment.NewLine}" +
                $@"sha1:{sha1}{Environment.NewLine}" +
                $@"CreatedTime:{meta.CreatedTime}{Environment.NewLine}" +
                $@"ModifiedTime:{meta.ModifiedTime}{Environment.NewLine}" +
                $@"AccessedTime:{meta.AccessedTime}{Environment.NewLine}";
        }

        /// <summary>
        /// 导出文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ExportFile_Click(object sender, EventArgs e)
        {
            FileSelector.CopyFileToSelectedPath(decryptFile!);
        }

        /// <summary>
        /// 加密文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Crypton_Click(object sender, EventArgs e)
        {
            cryptonFile = ".\\cry.dat";

            Inp_CryptonFile.Text = cryptonFile;
            AES.EncryptFile(originFile!, cryptonFile, aesModel.Key, aesModel.IV);

            // md5, SHA1, 文件大小，创建时间，修改时间
            var md5 = AES.CalculateFileHash(cryptonFile);
            var sha1 = AES.CalculateFileSHA1(cryptonFile);
            var size = AES.GetFileSize(cryptonFile);
            var cryMeta = AES.GetFileMeta(cryptonFile);

            RText_Crypton.Text =
                $@"size:{size}{Environment.NewLine}" +
                $@"md5:{md5}{Environment.NewLine}" +
                $@"sha1:{sha1}{Environment.NewLine}" +
                $@"CreatedTime:{cryMeta.CreatedTime}{Environment.NewLine}" +
                $@"ModifiedTime:{cryMeta.ModifiedTime}{Environment.NewLine}" +
                $@"AccessedTime:{cryMeta.AccessedTime}{Environment.NewLine}";
        }

        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Decrypt_Click(object sender, EventArgs e)
        {
            var (oriFileName, oriExtension) = FileSelector.GetFileNameAndExtension(originFile!);

            decryptFile = ".\\" + oriFileName + "." + oriExtension;

            Inp_DecryptFile.Text = decryptFile;
            AES.DecryptFile(cryptonFile!, decryptFile, aesModel.Key, aesModel.IV, ref meta);

            // md5, SHA1, 文件大小，创建时间，修改时间
            var md5 = AES.CalculateFileHash(decryptFile);
            var sha1 = AES.CalculateFileSHA1(decryptFile);
            var size = AES.GetFileSize(decryptFile);
            var cryMeta = AES.GetFileMeta(decryptFile);

            RText_Decrypt.Text =
                $@"size:{size}{Environment.NewLine}" +
                $@"md5:{md5}{Environment.NewLine}" +
                $@"sha1:{sha1}{Environment.NewLine}" +
                $@"CreatedTime:{cryMeta.CreatedTime}{Environment.NewLine}" +
                $@"ModifiedTime:{cryMeta.ModifiedTime}{Environment.NewLine}" +
                $@"AccessedTime:{cryMeta.AccessedTime}{Environment.NewLine}";
        }
    }
}
