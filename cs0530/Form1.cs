namespace cs0530
{
    public partial class Form1 : Form
    {
        int vx = -20;
        int vy = -10;

        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show($"{label1.Right} {label1.Bottom}");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var mpos = MousePosition;
            var fpos = PointToClient(mpos);
            Text = $"{mpos.X}, {mpos.Y} / {fpos.X}, {fpos.Y}";

            label2.Left = fpos.X - label2.Width / 2;
            label2.Top = fpos.Y - label2.Height / 2;

            label1.Left += vx;
            label1.Top += vy;

            if (label1.Left < 0)
            {
                vx = Math.Abs(vx);
            }
            else if (label1.Right > ClientSize.Width)
            {
                vx = -Math.Abs(vx);
            }

            if (label1.Top < 0)
            {
                vy = Math.Abs(vy);
            }
            else if (label1.Bottom > ClientSize.Height)
            {
                vy = -Math.Abs(vy);
            }

            // (label1.Left < fpos.X) && (fpos.X < label1.Right)
            if ((fpos.X > label1.Left)
                && (fpos.X < label1.Right)
                && (fpos.Y > label1.Top)
                && (fpos.Y < label1.Bottom))
            {
                timer1.Stop();
            }

        }
    }
}
