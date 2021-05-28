using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L3_p1
{
    public partial class Form1 : Form
    {
        List<Polosa> pList;
        Random random;

        const int nPolos = 5;

        const int wPolos = 200;
        const int hPolos = 50;
        int ori;

        int quant = nPolos;

        public Form1()
        {
            InitializeComponent();
            pList = new List<Polosa>();
            random = new Random();
            AddPoloski(nPolos);

            timer1.Interval = 500;
            timer1.Start();
        }

        private void AddPoloski(int nPolos)
        {
            for(int i = 0; i < nPolos; i++)
            {
                ori = random.Next(0, 9);

                int x = random.Next(this.Width - 200);
                int y = random.Next(this.Height - 200);

                if(ori < 5)
                {
                    Polosa p = new Polosa(x, y, wPolos, hPolos);
                    p.set_color(random.Next(0,255), random.Next(0, 255), random.Next(0, 255));
                    pList.Add(p);
                }
                else
                {
                    Polosa p = new Polosa(x, y, hPolos, wPolos);
                    p.set_color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                    pList.Add(p);
                }

                
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            foreach(Polosa p in pList)
            {
                p.Paint(g);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AddPoloski(1);
            Invalidate();
            quant++;
            if(quant == 2 * nPolos)
            {
                MessageBox.Show("You lose");
                this.Close();
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int iPolos = FindPolosa(e.X, e.Y);
            if (iPolos == -1)
                return;

            if (Overlap(iPolos))
                return;

            pList.RemoveAt(iPolos);
            Invalidate();

            quant--;
            if(quant == 0)
            {
                MessageBox.Show("You win");
                this.Close();
            }
            
        }

        private bool Overlap(int iPolos)
        {
            for(int i=iPolos+1; i<pList.Count; i++)
            {
                if (pList[iPolos].Overlap(pList[i]))
                    return true;
            }
            return false;
        }

        private int FindPolosa(int x, int y)
        {
            for(int i= pList.Count-1; i>=0; i--)
            {
                if (pList[i].isInside(x, y))
                    return i;
            }
            return -1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
