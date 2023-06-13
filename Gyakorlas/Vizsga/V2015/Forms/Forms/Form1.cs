namespace Forms
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer = new();
        private Rectangle rec = new(10, 10, 50, 50);
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += MyTick;
            KeyDown += MyKeyDown;
            Paint += MyPaint;
        }

        public void MyKeyDown(object sender, KeyEventArgs e){
            if(e.KeyCode == Keys.R){
                timer.Start();
            }
        }

        public void MyTick(object sender, EventArgs e){
            if(rec.X < 100){ rec.X++; rec.Y++; Invalidate(); }
        }

        public void MyPaint(object sender ,PaintEventArgs e){
            e.Graphics.FillRectangle(Brushes.Red, rec);
        }
    }
}