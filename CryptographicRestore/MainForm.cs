using CryptographicRestore.Crypton;
using CryptographicRestore.Crypton.Model;
using CryptographicRestore.Crypton.Tools;
using CryptographicRestore.FileOperator;

namespace CryptographicRestore
{
    /// <summary>
    /// ������
    ///     ��������Ϊ��
    ///     1. �����ļ�: �Զ���ʾԭʼ�ļ� md5, SHA1, �ļ���С������ʱ�䣬�޸�ʱ��
    ///     2. �����ļ�: ѡ�񷽷�, �Զ���ʾ���ܺ��ļ� md5, SHA1, �ļ���С������ʱ�䣬�޸�ʱ��
    ///     3. �����ļ�: �Զ���ʾ���ܺ��ļ� md5, SHA1, �ļ���С������ʱ�䣬�޸�ʱ��
    ///     4. �����ļ�: ճ������һ���ط�
    /// </summary>
    public partial class MainForm : Form
    {
        private AESModel aesModel;      // ����ģ��
        private FileMeta meta;          // �ļ�Ԫ����

        private string? originFile;     // ԭʼ�ļ�
        private string? cryptonFile;    // �����ļ�
        private string? decryptFile;    // �����ļ���δ������

        public MainForm()
        {
            InitializeComponent();

            aesModel = new AESModel();
            meta = new FileMeta();

            aesModel.Key = RGenerate.GenerateKey(); // ����Key
            aesModel.IV = RGenerate.GenerateIV();   // ����IV����
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_OriginInput_Click(object sender, EventArgs e)
        {
            // ��ȡԭʼ�ļ�
            originFile = FileSelector.SelectFile();

            if (string.IsNullOrEmpty(originFile))
            {
                Console.WriteLine(@"δ�����ļ�");
                return;
            }

            Inp_OriginFile.Text = originFile;

            // md5, SHA1, �ļ���С������ʱ�䣬�޸�ʱ��
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
        /// �����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ExportFile_Click(object sender, EventArgs e)
        {
            FileSelector.CopyFileToSelectedPath(decryptFile!);
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Crypton_Click(object sender, EventArgs e)
        {
            cryptonFile = ".\\cry.dat";

            Inp_CryptonFile.Text = cryptonFile;
            AES.EncryptFile(originFile!, cryptonFile, aesModel.Key, aesModel.IV);

            // md5, SHA1, �ļ���С������ʱ�䣬�޸�ʱ��
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
        /// �����ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Decrypt_Click(object sender, EventArgs e)
        {
            var (oriFileName, oriExtension) = FileSelector.GetFileNameAndExtension(originFile!);

            decryptFile = ".\\" + oriFileName + "." + oriExtension;

            Inp_DecryptFile.Text = decryptFile;
            AES.DecryptFile(cryptonFile!, decryptFile, aesModel.Key, aesModel.IV, ref meta);

            // md5, SHA1, �ļ���С������ʱ�䣬�޸�ʱ��
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
