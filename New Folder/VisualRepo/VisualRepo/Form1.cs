using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualRepo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private delegate void Synchro(string text);

        private void updateTask(string text)
        {
            if(richTextBox1.InvokeRequired)
            {
                richTextBox1.Invoke(new Synchro(updateTask), text);
            }
            else
            {
                 richTextBox1.Text += text;
            }

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "test";
        }


        bool isstream = false;
        private async void button2_Click(object sender, EventArgs e)
        {

            if(!isstream)
            {
                isstream = true;
                await looptask();
            }
            else
            {
                isstream = false;
            }

        }

        private async Task looptask()
        {
            while(isstream)
            {
                await Task.Run( () => updateTask(textBox1.Text));
                await Task.Delay(1000);
            }

        }
    }
}
