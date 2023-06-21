namespace Winfos_2_feladat
{

/**
 * 2) 300,300-ban kék, kitöltetlen négyzet, k gombra kitöltõdik (uúgy kék színnel),
 * majd 1-5 mp alatt vissza kitöltetlenbe. 500,500-ban egérmutató koordinátái,
 * illetve egy string ami kiírja, hogy mi a négyzet állapota (teli/üres)
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
            X = e.X; Y = e.Y; Invalidate();         //Elmentjuk az egérkoordinátákat
        }

        private void MyTick(object sender, EventArgs e) {
            timer.Stop();       //Idõzítõ leáll
            state = false;      //Csak körvonal
            Invalidate();       //Újra rajzolás
        }

        private void MyPaint(object sender, PaintEventArgs e) {
            Graphics g = e.Graphics;
            g.DrawString("" + X + "," + Y, this.Font, Brushes.Black, 500, 500); //Koordináták
            if (state) {
                g.FillRectangle(Brushes.Blue, rec);                             //Négyzet
                g.DrawString("Teli", this.Font, Brushes.Black, 200, 200);       //Teli

            }
            else
            {
                g.DrawRectangle(Pens.Blue, rec);                                //Négyzet
                g.DrawString("Üres", this.Font, Brushes.Black, 200, 200);       //Üres
            }
        }
    }
}