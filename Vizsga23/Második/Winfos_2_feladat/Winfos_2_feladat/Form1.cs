namespace Winfos_2_feladat
{

/**
 * 2) 300,300-ban k�k, kit�ltetlen n�gyzet, k gombra kit�lt�dik (u�gy k�k sz�nnel),
 * majd 1-5 mp alatt vissza kit�ltetlenbe. 500,500-ban eg�rmutat� koordin�t�i,
 * illetve egy string ami ki�rja, hogy mi a n�gyzet �llapota (teli/�res)
 * */

    public partial class Form1 : Form
    {
        private Rectangle rec = new(200, 300, 50, 50);
        private System.Windows.Forms.Timer timer = new();
        private bool state = false;
        private Random random = new Random();
        private int X, Y;
        public Form1()
        {
            InitializeComponent();
            timer.Tick += MyTick;
            KeyDown += MyKeyDown;
            Paint += MyPaint;
            MouseMove += MyMouseMove;
        }

        private void MyKeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.K) { 
                state = true;
                timer.Interval = (random.Next(5) + 1) * 1000;   //0-4  + 1 = 1-5  *1000 = secben
                timer.Start();
                Invalidate(); 
            }
        }

        private void MyMouseMove(object sender, MouseEventArgs e) {
            X = e.X; Y = e.Y; Invalidate();         //Elmentjuk az eg�rkoordin�t�kat
        }

        private void MyTick(object sender, EventArgs e) {
            timer.Stop();       //Id�z�t� le�ll
            state = false;      //Csak k�rvonal
            Invalidate();       //�jra rajzol�s
        }

        private void MyPaint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.DrawString("" + X + "," + Y, this.Font, Brushes.Black, 500, 500); //Koordin�t�k
            if (state) {
                g.FillRectangle(Brushes.Blue, rec);                             //N�gyzet
                g.DrawString("Teli", this.Font, Brushes.Black, 200, 200);       //Teli

            }
            else
            {
                g.DrawRectangle(Pens.Blue, rec);                                //N�gyzet
                g.DrawString("�res", this.Font, Brushes.Black, 200, 200);       //�res
            }
        }
    }
}