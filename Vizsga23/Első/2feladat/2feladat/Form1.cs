namespace _2feladat
{
    public partial class Form1 : Form   //Formb�l sz�rmazunk le
    {
        private System.Windows.Forms.Timer timer = new();   //Csak timer
        private Random random = new();
        private Rectangle rec;                              //Tudjunk r� hivatkozni
        private bool blue = true;                           //Sz�ne, lehet higy van r� szebb megold�s vizsg�n ezt csin�ltam
        private bool valid = false;                         //Volt m�r klikk?, lehet higy van r� szebb megold�s vizsg�n ezt csin�ltam
        private int teleport;                               //�thelyez�shez
        private int x, y;                                   //Eg�r poz�ci�
        public Form1()
        {
            InitializeComponent();
            timer.Interval = 1000;  //mp-nk�nt tickel
            //Esem�nyek beregisztr�l�sa, lehettt volna overridolni is
            timer.Tick += MyTick;
            MouseDown += MyMouseDown;
            MouseMove += MyMouseMove;
            KeyDown += MyKeyDown;
            Paint += MyPaint;
        }

        private void MyMouseDown(object sender, MouseEventArgs e)
        {
            rec = new Rectangle(e.X - 5, e.Y - 5, 10, 10);  //Eg�r helye -5, �gy a bal fels� sarkot eltoltuk (alapb�l azt adjuk meg) �gy a n�gyzet k�zepe a kurzorn�l lesz
            valid = true;
            teleport = random.Next(6) + 5;  //Id� az �thelyez�sig
            timer.Start();                  //Id�z�t� ind�t�sa
            Invalidate();                   //Rajzol�s
        }

        private void MyKeyDown(object sender, KeyEventArgs e)
        {
            if (valid) { if (e.KeyCode == Keys.K) { blue = false; Invalidate(); } } //Ha k-t nyomtuk prosk�nt rajzoljuk majd ki
        }

        private void MyMouseMove(object sender, MouseEventArgs e)
        {
            x = e.X; y = e.Y; Invalidate();                         //Sz�veg ki�r�s�hoz tudni kell az eg�t hely�t
        }

        private void MyTick(object sender, EventArgs e)
        {
            teleport--;                                                                     //Cs�kkentjuk az id�t
            if (teleport == 0) { rec.X = 200; rec.Y = 200; timer.Stop(); Invalidate(); }    //Ha nulla �thelyet�nk
        }

        private void MyPaint(object sender, PaintEventArgs e){
            Graphics g = e.Graphics;                                    //R�videbb hivatkoz�s
            //string s = "Coordinates: " + x + " " + y;                 //Ha nem ismered a string.Format()-ot             
            g.DrawString(string.Format("Coordinates: " + x + " " + y) /*vagy sim�n s*/, this.Font, Brushes.Black, 50, 100);
            if(valid) {                                 //Ha m�r volt katt
                if(blue) {
                    g.DrawRectangle(Pens.Blue, rec);    //K�k
                }
                else{                  
                    g.DrawRectangle(Pens.Red, rec);     //Piros
                }
            }
        }
    }
}