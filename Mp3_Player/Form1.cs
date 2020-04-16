using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Mp3_Player
{
    public partial class Form1 : Form
    {
        SoundPlayer player;
        string filename = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                player.SoundLocation = filename;
                player.Play();

            }catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenMedia();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenMedia();
        }
        private void OpenMedia()
        {
            OpenFileDialog _opg = new OpenFileDialog()
            {
                Filter = "WAV|*.wav|another file|*",
                Multiselect = false,
                ValidateNames = true
            };
            if (_opg.ShowDialog() == DialogResult.OK)
            {
                filename = textBox1.Text = _opg.FileName;
            }
        }
    }
}
