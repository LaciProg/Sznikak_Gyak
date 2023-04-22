namespace Kapd_El_A_Négyzetet
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer = new();
        private Random Random = new Random();
        private Rectangle rec;
        private bool Catch = false;
        public Form1()
        {
            InitializeComponent();
            rec = new Rectangle(300,300,10,10);
            Paint += MyPaint;
            timer.Start();
            timer.Interval = 100;
            timer.Tick += Timeing;
            MouseMove += mouseMove;
            KeyDown += keyPress;
        }

        private void MyPaint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.Green, rec);
            e.Graphics.DrawString("X: "+rec.X+" Y: "+rec.Y, new Font("Arial", 10), Brushes.Black, new Point(500,500));
        }

        private void Timeing(object sender, EventArgs e) {
            if(!Catch){
                rec.X += Random.Next(-5, 6);
                rec.Y += Random.Next(-5, 6);           
            }          
            Invalidate();
        }

        private void keyPress(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.X) {
                rec.Width = 20;
                rec.Height = 20;
            }
        }

        private void mouseMove(object sender, MouseEventArgs e) {
            if(rec.Contains(e.Location)){
                Catch = true;
                timer.Stop();
            }
        }

        

    }
}