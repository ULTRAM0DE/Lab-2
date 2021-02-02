using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otrezki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            }
        Point p1, p2, p3, p4, p;
        
        private void button1_Click(object sender, EventArgs e)//кнопка "новая пара отрезков" - очищение экрана и обнуление входных параметров
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "0";
            label1.Text = "";
            pictureBox1.Image = null;
        }
         private int vector_mult(int ax,int ay,int bx,int by) //векторное произведение
         {
            return ax*by-bx*ay;
         }
         public bool areCrossing(Point p1, Point p2, Point p3, Point p4)//проверка пересечения
        {                                                       
          int v1 = vector_mult(p4.X - p3.X, p4.Y - p3.Y, p1.X - p3.X, p1.Y - p3.Y);
          int v2 = vector_mult(p4.X - p3.X, p4.Y - p3.Y, p2.X - p3.X, p2.Y - p3.Y);
          int v3 = vector_mult(p2.X - p1.X, p2.Y - p1.Y, p3.X - p1.X, p3.Y - p1.Y);
          int v4 = vector_mult(p2.X - p1.X, p2.Y - p1.Y, p4.X - p1.X, p4.Y - p1.Y);
          if ( (v1*v2)<0 && (v3*v4)<0 )
            return true;
          return false;
        }

        //построение уравнения прямой
        int A, B, C;//коэффициенты уравнения прямой вида: Ax+By+C=0
        public void LineEquation(Point p1,Point p2)
            {                                                             
                A=p2.Y-p1.Y;                                            
                B=p1.X-p2.X;
                C=-p1.X*(p2.Y-p1.Y)+p1.Y*(p2.X-p1.X);
            } 
        //поиск точки пересечения
        Point CrossingPoint(int a1,int b1,int c1,int a2,int b2,int c2)
        {
         
          Point pt=new Point();                         
          double d=(double)(a1*b2-b1*a2);
          double dx=(double)(-c1*b2+b1*c2);
          double dy=(double)(-a1*c2+c1*a2);
          pt.X=(int)(dx/d);
          pt.Y=(int)(dy/d);
          return pt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
           //получаем входные данные
            p1 = new Point(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
            p2 = new Point(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text));
            p3 = new Point(Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text));
            p4 = new Point(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text));
            //строим отрезки
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(new Pen(Color.Black, 2), p1, p2);
            g.DrawLine(new Pen(Color.Black, 2), p3, p4);
            label1.Text = "";     
            //проверяем отрезки на пересечение
            if (areCrossing(p1, p2, p3, p4))
            {
                int a1, b1, c1, a2, b2, c2;
                LineEquation(p1, p2);
                a1 = A; b1 = B; c1 = C;
                LineEquation(p3, p4);
                a2 = A; b2 = B; c2 = C;
                p = CrossingPoint(a1, b1, c1, a2, b2, c2);
                label1.Text = "Отрезки пересекаются" + "\n" + "в точке(" + Convert.ToString(p.X) + "," + Convert.ToString(p.Y) + ")";
            }
            else
                label1.Text = "Отрезки"+"\n" + "не пересекаются!";
        }
    }
}
