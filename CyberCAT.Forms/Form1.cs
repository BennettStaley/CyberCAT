using CyberCAT.Core.ChunkedLz4;
using CyberCAT.Core.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberCAT.Forms
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private CyberPunkSaveFile saveFile;

        private void button1_Click(object sender, EventArgs e)
        {
            var file = textBox1.Text + "/sav.dat";
            if (File.Exists(file))
            {
                using (var compressedInputStream = File.OpenRead(file))
                {
                    saveFile = new CyberPunkSaveFile();
                    saveFile.ReadHeader(compressedInputStream);
                    saveFile.Decompress(compressedInputStream);
                    //saveFile.Compress("/Output/output.bin");
                    //_chunkedFile = new ChunkedLz4File(compressedInputStream);
                    //using (var inputStream = _chunkedFile.Decompress(compressedInputStream))
                    //{
                    //    using (var fileStream = File.Create(@"H:\CP2077_sg\output.bin"))
                    //    {
                    //        inputStream.Seek(0, SeekOrigin.Begin);
                    //        inputStream.CopyTo(fileStream);
                    //    }
                    //}
                }
            }
            else
            {
                MessageBox.Show("File does not exist");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (saveFile == null)
            {
                MessageBox.Show(
                    "Decompress first!",
                    "Error in Compressing",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Asterisk
                );
            }
            else
            {
                saveFile.Compress("output_2.bin");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
