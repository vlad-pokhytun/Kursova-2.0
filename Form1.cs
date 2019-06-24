using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ToBinary(textBox1.Text);
        }

        static string ToBinary(string input)
        {
            var builder = new System.Text.StringBuilder();
            var bytes = System.Text.Encoding.UTF8.GetBytes(input); // Convert the text to bytes using the encoding

            foreach (var b in bytes)
                builder.Append(Convert.ToString(b, 2).PadLeft(8, '0')); //Convert the byte to its binary representation

            return builder.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = ToText(textBox3.Text);
        }

        static string ToText(string bytes)
        {

            int byteCount = 8;
            var byteArray = new byte[bytes.Length / 8]; // An array for the bytes
            for (int i = 0; i < bytes.Length / byteCount; i++)
            {
                var subBytes = bytes.Substring(i * byteCount, byteCount); // Get a subpart of 8 bits
                var b = Convert.ToByte(subBytes.TrimStart('0'), 2); // Convert the subpart to a byte
                byteArray[i] = b; // Add the byte to the array
            }

            return System.Text.Encoding.UTF8.GetString(byteArray); // Convert the array to text using the right encoding.
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.WriteAllText("binary.txt", string.Join(Environment.NewLine, textBox2.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            File.WriteAllText("text.txt", string.Join(Environment.NewLine, textBox4.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(@"text.txt");
            while (!reader.EndOfStream)
            {
                textBox1.Text = reader.ReadLine();
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader(@"binary.txt");
            while (!reader.EndOfStream)
            {
                textBox3.Text = reader.ReadLine();
            }
        }
    }
}
