namespace ZH2022_2
{
    public partial class Form1 : Form
    {

        private int t = 100;
        private System.Windows.Forms.Timer timer;
        public Form1()
        {
            InitializeComponent();
            timer = new System.Windows.Forms.Timer();
            timer.Tick += click;
            timer.Interval = 100;
            Paint += MyPaint;
            KeyPress += MyKeyPress;
        }

        public void MyPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, 0, 255*t/100, 255*(100-t)/100), 10), 50, 50, 100, 100);
        }

        private void MyKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'x' )
            {
                timer.Start();
            }
        }

        private void click(object sender, EventArgs e)
        {

            t--;
            if(t == 0) { timer.Stop(); }
            Invalidate();
        }
    }
}