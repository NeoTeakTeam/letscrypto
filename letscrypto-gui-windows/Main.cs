using core;

namespace letscrypto_gui_windows
{
    public partial class Main : Form
    {
        private Core coreInstance = new();


        public Main()
        {
            InitializeComponent();
        }

        private void randomOffset_Click(object sender, EventArgs e)
        {
            uoffset.Text = coreInstance.randomOffset().ToString();
        }

        private void generateKey_Click(object sender, EventArgs e)
        {
            // 验证输入是否为整数
            if (int.TryParse(generateBox.Text, out int count))
            {
                ukey.Text = coreInstance.generateKey(count);
            }
            else
            {
                MessageBox.Show("输入无效，请输入一个整数！", "错误");
            }
        }

        private void savekey_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new();
            file.Filter = "密钥文件(*.key)|*.key|所有文件(*.*)|*.*";
            file.FilterIndex = 1;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = file.FileName;
                File.WriteAllText(selectedFilePath, coreInstance.formatKey(ukey.Text));
            }
        }

        private void textReadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new();
            file.Filter = "所有文件(*.*)|*.*";
            file.FilterIndex = 1;
            file.Multiselect = false;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = file.FileName;
                utext.Text = File.ReadAllText(selectedFilePath);
            }
        }

        private void keyLoadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new();
            file.Filter = "密钥文件(*.key)|*.key|所有文件(*.*)|*.*";
            file.FilterIndex = 1;
            file.Multiselect = false;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = file.FileName;
                ukeyfile.Text = selectedFilePath;
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new();
            file.Filter = "所有文件(*.*)|*.*";
            file.FilterIndex = 1;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = file.FileName;
                File.WriteAllText(selectedFilePath, resultTip.Text);
            }
        }

        private void encryptFromCustomKey_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(uoffset.Text, out int offset))
            {
                MessageBox.Show("偏移值必须为整数!", "错误");
                return;
            }

            result.Text = coreInstance.encrypt(utext.Text, ukey.Text, offset);
        }

        private void encryptFromKeyOfFile_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(uoffset.Text, out int offset))
            {
                MessageBox.Show("偏移值必须为整数!", "错误");
                return;
            }
            var key = ukeyfile.Text;
            var realKey = "";

            if (!File.Exists(key))
            {
                MessageBox.Show("key 不存在", "错误");
                return;
            }
            var keyLines = File.ReadAllLines(key);

            // 检测头部和尾部
            if (keyLines.First() != "------------------- Key --------------------" ||
                keyLines.Last() != "------------------- End --------------------")
            {
                MessageBox.Show("key 无效", "错误");
                return;
            }

            var realKeyLists = keyLines.Skip(1).Take(keyLines.Count() - 2).ToList();
            if (realKeyLists == null || !realKeyLists.Any())
            {
                MessageBox.Show("key 无效(没有数据)", "错误");
                return;
            }
            realKey = string.Join("", realKeyLists).Replace("\n", "");

            coreInstance.encrypt(utext.Text, realKey, offset);
        }

        private void decryptFromCustomKey_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(uoffset.Text, out int offset))
            {
                MessageBox.Show("偏移值必须为整数!", "错误");
                return;
            }

            result.Text = coreInstance.decrypt(utext.Text, ukey.Text, offset);
        }

        private void decryptFromKeyOfFile_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(uoffset.Text, out int offset))
            {
                MessageBox.Show("偏移值必须为整数!", "错误");
                return;
            }
            var key = ukeyfile.Text;
            var realKey = "";

            if (!File.Exists(key))
            {
                MessageBox.Show("key 不存在", "错误");
                return;
            }
            var keyLines = File.ReadAllLines(key);

            // 检测头部和尾部
            if (keyLines.First() != "------------------- Key --------------------" ||
                keyLines.Last() != "------------------- End --------------------")
            {
                MessageBox.Show("key 无效", "错误");
                return;
            }

            var realKeyLists = keyLines.Skip(1).Take(keyLines.Count() - 2).ToList();
            if (realKeyLists == null || !realKeyLists.Any())
            {
                MessageBox.Show("key 无效(没有数据)", "错误");
                return;
            }
            realKey = string.Join("", realKeyLists).Replace("\n", "");

            coreInstance.decrypt(utext.Text, realKey, offset);
        }
    }
}
