using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Графический_редактор
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pictureBox1.Image = bm;
        }

        Bitmap bm;
        Graphics g;
        bool paint = false;
        bool fill = false;
        Point py;
        Pen p = new Pen(Color.Black,1);
        Brush brush = new SolidBrush(Color.Black);
        int index;
        int x, y, sX, sY, cX, cY;
        ColorDialog cd = new ColorDialog();

        

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;

            cX = e.X;
            cY = e.Y;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pictureBox1.Image = bm;
            index = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
                ((Button)sender).BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Red);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Black);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            p = new Pen(Color.Blue);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {  
                Bitmap bitmap = new Bitmap(pictureBox1.Size.Width, pictureBox1.Size.Height);
                pictureBox1.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                bitmap.Save(saveFileDialog1.FileName);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bitmap;
            }
        }

            private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (paint)
            {

            }
            pictureBox1.Refresh();
            x = e.X;
            y = e.Y;
            sX = e.X - e.X;
            sY = e.Y - e.Y;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (fill)
            {
                fill = false;
            }
            else
            {
                fill = true;
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;
            brush = new SolidBrush(button5.BackColor);
            sX = x - cX;
            sY = y - cY;

            if (index == 1)
            {
                if (fill)
                {
                    g.FillEllipse(brush, cX, cY, sX, sY);
                }

                else
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
            }
            if (index == 2)
            {
                if (fill)
                {
                    g.FillRectangle(brush, cX, cY, sX, sY);
                }
                else
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
            }
            if (index == 3)
            {
                g.DrawLine(p, cX, cY, x, y);
            }

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
           /* Graphics g = e.Graphics;

            if (paint)
            {
                if (index == 1)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                if (index == 2)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
                if (index == 3)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }*/
        }
        private void button8_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            index = 1;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            index = 3;
        }
    }
}
