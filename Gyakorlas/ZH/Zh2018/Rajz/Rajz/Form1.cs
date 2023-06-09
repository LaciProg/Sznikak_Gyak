using Microsoft.Win32;

namespace Rajz
{
    public partial class Form1 : Form
    {

        private Rectangle rec;
        private Random Random = new Random();
        private System.Windows.Forms.Timer timer = new();
        private int rand;


        private void kiir()
        {
            Console.WriteLine("● Periodikus időzített esemény\r\n" +
            "● Interval tulajdonság: millisec-ben az időintervallum\r\n" +
            "● bool Enabled tulajdonság: timer tiltás/engedélyezés\r\n" +
            "● Start() és Stop() műveletek\r\n" +
            "● Tick event (EventHandler típusú) ha lejár az időzítő\r\n" +
            "● Pontatlan (a garantált minimum felbontás kb. 20 ms)");

        }

        public Form1()
        {
            InitializeComponent();
            rec.X = 50;
            rec.Y = 50;
            rec.Width = 20;
            rec.Height = 20;
            Paint += MyPaint;
            KeyDown += keyDown;
            timer.Interval = 1000;
            timer.Tick += count;
        }

        private void MyPaint(object sender, PaintEventArgs e) {
            e.Graphics.FillRectangle(Brushes.Blue, rec);
            e.Graphics.DrawString("X: " + rec.X + " Y: " + rec.Y, new Font("Arial", 10), Brushes.Black, 500, 500);
        }

        private void keyDown(object sender, KeyEventArgs e){
            if(e.KeyCode == Keys.X){
                rand = Random.Next(6);
                timer.Start();          
            }

        }

        private void count(object sender, EventArgs e){
            rand--;
            if (rand == 0){ 
                timer.Stop();              
                rec.Y += 5;
                Invalidate();
            }

        }
    }
}