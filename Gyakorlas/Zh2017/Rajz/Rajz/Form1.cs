namespace Rajz
{
    public partial class Form1 : Form
    {

        private Rectangle rec;
        private System.Windows.Forms.Timer timer = new();
        private Random random = new Random();
        int count = 0;

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000;
            timer.Tick += tick;
            Paint += MyPaint;
            //KeyDown += keyDown;
            rec.X = 100;
            rec.Y = 100;
            rec.Width = 10;
            rec.Height = 10;
        }

        private void tick(object sneder, EventArgs e){
            int x, y;
            x = random.Next(100);
            y = random.Next(100);
            if(x != rec.X && y != rec.Y ){ count++; rec.X = x; rec.Y = y; }
            Invalidate();
        }

        private void MyPaint(object sender, PaintEventArgs e){
            e.Graphics.FillRectangle(Brushes.Green, rec);
            e.Graphics.DrawString(string.Format("{0}", count), this.Font, Brushes.Black, 10, 10);
        }

        protected override void OnKeyDown(KeyEventArgs e){ 
            base.OnKeyDown(e);
            if(e.KeyCode == Keys.S) {
                timer.Start();

            }
        }
    }
}