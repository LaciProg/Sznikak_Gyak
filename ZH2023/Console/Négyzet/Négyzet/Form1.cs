namespace Négyzet
{
    public partial class Form1 : Form
    {

        private Random random = new();
        private System.Windows.Forms.Timer timer = new();
        private Rectangle rec;
        private bool show = false;

        public Form1()
        {
            InitializeComponent();
            timer.Tick += MyTick;
            Paint += MyPaint;
            KeyDown += MyKeyDown;
            MouseDown += MyMouseDown;
        }

        private void MyTick(object sender, EventArgs e){
            timer.Stop();
            show = true;
            rec.X = rec.Y = 200;
            Invalidate();
        }

        private void MyKeyDown(object sender, KeyEventArgs e){

            if(e.KeyCode == Keys.C){
                show = false;
                Invalidate();
            }
        }

        private void MyMouseDown(object sender, MouseEventArgs e){
            timer.Interval = random.Next(2000, 4001);
            timer.Start();
            rec.X = e.X; rec.Y = e.Y;
            rec.Width = rec.Height = 20;
            show = true;
            Invalidate();
        }

        private void MyPaint(object sender, PaintEventArgs e){
            if (show)
            {
                e.Graphics.DrawRectangle(Pens.Green, rec);
                e.Graphics.DrawString("Látható", this.Font, Brushes.Black, new Point(50, 100));
            }
            else{
                e.Graphics.DrawRectangle(new Pen(Color.Empty), rec);
                e.Graphics.DrawString("Nem látható", this.Font, Brushes.Black, new Point(50, 100));
            }

        }
    }
}