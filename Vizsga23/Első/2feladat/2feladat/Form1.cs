namespace _2feladat
{
    public partial class Form1 : Form   //Formból származunk le
    {
        private System.Windows.Forms.Timer timer = new();   //Csak timer
        private Random random = new();
        private Rectangle rec;                              //Tudjunk rá hivatkozni
        private bool blue = true;                           //Színe, lehet higy van rá szebb megoldás vizsgán ezt csináltam
        private bool valid = false;                         //Volt már klikk?, lehet higy van rá szebb megoldás vizsgán ezt csináltam
        private int teleport;                               //Áthelyezéshez
        private int x, y;                                   //Egér pozíció
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000;  //mp-nként tickel
            //Események beregisztrálása, lehettt volna overridolni is
            timer.Tick += MyTick;
            MouseDown += MyMouseDown;
            MouseMove += MyMouseMove;
            KeyDown += MyKeyDown;
            Paint += MyPaint;
        }

        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            rec = new Rectangle(e.X - 5, e.Y - 5, 10, 10);  //Egér helye -5, így a bal felsõ sarkot eltoltuk (alapból azt adjuk meg) így a négyzet közepe a kurzornál lesz
            valid = true;
            teleport = random.Next(6) + 5;  //Idõ az áthelyezésig
            timer.Start();                  //Idõzítõ indítása
            Invalidate();                   //Rajzolás
        }

        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (valid) { if (e.KeyCode == Keys.K) { blue = false; Invalidate(); } } //Ha k-t nyomtuk prosként rajzoljuk majd ki
        }

        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y; Invalidate();                         //Szöveg kiírásához tudni kell az egét helyét
        }

        private void MyTick(object sender, EventArgs e)
        {
            teleport--;                                                                     //Csökkentjuk az idõt
            if (teleport == 0) { rec.X = 200; rec.Y = 200; timer.Stop(); Invalidate(); }    //Ha nulla áthelyetünk
        }

        private void MyPaint(object sender, PaintEventArgs e){
            Graphics g = e.Graphics;                                    //Rövidebb hivatkozás
            //string s = "Coordinates: " + x + " " + y;                 //Ha nem ismered a string.Format()-ot             
            g.DrawString(string.Format("Coordinates: " + x + " " + y) /*vagy simán s*/, this.Font, Brushes.Black, 50, 100);
            if(valid) {                                 //Ha már volt katt
                if(blue) {
                    g.DrawRectangle(Pens.Blue, rec);    //Kék
                }
                else{                  
                    g.DrawRectangle(Pens.Red, rec);     //Piros
                }
            }
        }
    }
}