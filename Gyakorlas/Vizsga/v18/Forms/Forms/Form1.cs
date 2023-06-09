namespace Forms
{
    public partial class Form1 : Form
    {
        private Rectangle rec;
        private System.Windows.Forms.Timer timer = new();
        int blue = 1;
        private int time;
        private Random random;
        public Form1()
        {
            InitializeComponent();
            rec = new Rectangle(200,200,10,10);
            Paint += MyPaint;
            timer.Tick += MyTick;
            random = new();
            time = random.Next(1, 6);
            timer.Interval = 1000;
            MouseMove += MyMouseMove;
            timer.Start();
        }

        private void MyPaint(object sender, PaintEventArgs e) {
        if(blue == 1) { e.Graphics.DrawRectangle(Pens.Blue, rec); }
        else e.Graphics.DrawRectangle(Pens.Red, rec);

        }

        private void MyTick(object sender, EventArgs e) {
            --time;
            if(time == 0) { blue *=-1; 
            time = random.Next(1, 6);
            }
            Invalidate();
        }

        private void MyMouseMove(object sender, MouseEventArgs e) { 
            if(rec.Contains(e.X, e.Y)) { timer.Stop(); }
        }
    }
}