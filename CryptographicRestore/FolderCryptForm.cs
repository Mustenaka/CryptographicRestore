using CryptographicRestore.Crypton.Model;
using CryptographicRestore.Crypton.Tools;
using CryptographicRestore.FileOperator;
using CryptographicRestore.Crypton;

namespace CryptographicRestore
{
    public partial class FolderCryptForm : Form
    {
        private AESModel aesModel;      // 加密模型
        private FileMeta meta;          // 文件元数据

        private string? originFloder;   // 原始文件夹
        private string? zipFile;        // 原始文件夹压缩文件路径
        private string? cryptonFile;    // 加密文件夹
        private string? decryptFile;    // 解密文件（未导出）
        private string? destFolder;     // 导出文件夹


        public FolderCryptForm()
        {
            InitializeComponent();

            aesModel = new AESModel();
            meta = new FileMeta();

            aesModel.Key = RGenerate.GenerateKey(); // 生成Key
            aesModel.IV = RGenerate.GenerateIV();   // 生成IV向量
        }

        /// <summary>
        /// 导入文件夹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OriginInput_Click(object sender, EventArgs e)
        {
            originFloder = FileSelector.SelectFolder();

            if (string.IsNullOrEmpty(originFloder))
            {
                Console.WriteLine(@"未载入文件");
                return;
            }

            Inp_OriginFile.Text = originFloder;

            zipFile = "zip.zip";
            FileCompressor.CompressFolderToZip(originFloder, zipFile);

            // md5, SHA1, 文件大小，创建时间，修改时间
            var md5 = AES.CalculateFileHash(zipFile);
            var sha1 = AES.CalculateFileSHA1(zipFile);
            var size = AES.GetFileSize(zipFile);
            meta = AES.GetFileMeta(zipFile);

            RText_Origin.Text =
                $@"size:{size}{Environment.NewLine}" +
                $@"md5:{md5}{Environment.NewLine}" +
                $@"sha1:{sha1}{Environment.NewLine}" +
                $@"CreatedTime:{meta.CreatedTime}{Environment.NewLine}" +
                $@"ModifiedTime:{meta.ModifiedTime}{Environment.NewLine}" +
                $@"AccessedTime:{meta.AccessedTime}{Environment.NewLine}";
        }

        /// <summary>
        /// 加密文件夹对应的压缩文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Crypton_Click(object sender, EventArgs e)
        {
            cryptonFile = ".\\cry.dat";

            Inp_CryptonFile.Text = cryptonFile;
            AES.EncryptFile(zipFile!, cryptonFile, aesModel.Key, aesModel.IV);

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
        /// 解密这个压缩文件还原zip
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Decrypt_Click(object sender, EventArgs e)
        {
            var (oriFileName, oriExtension) = FileSelector.GetFileNameAndExtension(zipFile!);

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

        /// <summary>
        /// 导出这个解密文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ExportFile_Click(object sender, EventArgs e)
        {
            destFolder = FileSelector.SelectFolder();

            FileCompressor.ExtractZipToFolder(decryptFile, destFolder);

            MessageBox.Show(@$"导出成功，请查看 {destFolder}");
        }
    }
}
