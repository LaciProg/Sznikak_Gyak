namespace Rajz
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer =new();
	    private Random random = new();
        private bool key = false;
        private bool show = false;
        private DateTime dt;
        private DateTime startTime;
        private int rt;
        public Form1()
        {
            InitializeComponent();
            timer.Start();
    
            rt = random.Next(150);
            startTime = DateTime.Now;
            timer.Tick += timeing;
            Paint += MyPaint;
            KeyDown += MyKeyDown;
        }

        private void MyPaint(object sender, PaintEventArgs e)
        {
            if (!show) return;
            e.Graphics.FillRectangle(Brushes.Red, 20, 20, 50, 50);
            if (key)
            {
                e.Graphics.DrawString((DateTime.Now - startTime).ToString(), this.Font, Brushes.Black, 100, 100);
            }
        }

        private void timeing(object sender, EventArgs e)
        {
            if (rt == 0) { timer.Stop(); show = true; Invalidate(); }
            else
            {
                rt--;
            }
        }

        private void MyKeyDown(object Sender, KeyEventArgs e)
        {
            if (show) { key = true; Invalidate(); }
        }



    }
}