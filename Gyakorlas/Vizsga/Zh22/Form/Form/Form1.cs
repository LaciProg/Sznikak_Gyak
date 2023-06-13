namespace FormsFeladat
{
    public partial class Form1 : Form
    {

        private Rectangle rec = new(50,50,100,100);
        private System.Windows.Forms.Timer timer = new();
        private double time = 0;
        public Form1()
        {
            InitializeComponent();
            timer.Tick += MyTick;
            Paint += MyPaint;
            KeyDown += MyKeyDown;
            MouseMove += MyMouseMove;
        }

        public void MyKeyDown(object sender, KeyEventArgs e){
            if(e.KeyCode == Keys.X){
                time = 0;
                timer.Start();
            }
        }

        public void MyTick(object sender, EventArgs e){
            time = time + 0.01;
            if(time >= 1){ timer.Stop(); }
            Invalidate();
        }

        private void MyPaint(object sender, PaintEventArgs e){
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, 0, (int)(255 * (1 - time)), (int)(255 * time))), rec);
        }

        private void MyMouseMove(object sender, MouseEventArgs e){ }
        
    }
}