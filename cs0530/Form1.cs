namespace cs0530
{
    public partial class Form1 : Form
    {
        static int LabelCount => 10;

        int[] vx = new int[LabelCount];
        int[] vy = new int[LabelCount];
        Label[] labels = new Label[LabelCount];

        int counter = 0;
        static Random random = new Random();

        public Form1()
        {
            InitializeComponent();

            //MessageBox.Show($"{label1.Right} {label1.Bottom}");
            for (int i = 0; i < LabelCount; i++)
            {
                vx[i] = random.Next(-10, 11);
                vy[i] = random.Next(-10, 11);

                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Text = "Ÿ";
                labels[i].Font = new Font("Yu Gothic UI", 24F);
                Controls.Add(labels[i]);

                labels[i].Left = random.Next(ClientSize.Width - labels[i].Width);
                labels[i].Top = random.Next(ClientSize.Height - labels[i].Height);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            label3.Text = $"{counter}";

            var mpos = MousePosition;
            var fpos = PointToClient(mpos);
            Text = $"{mpos.X}, {mpos.Y} / {fpos.X}, {fpos.Y}";

            label2.Left = fpos.X - label2.Width / 2;
            label2.Top = fpos.Y - label2.Height / 2;

            for (int i = 0; i < LabelCount; i++)
            {
                labels[i].Left += vx[i];
                labels[i].Top += vy[i];

                if (labels[i].Left < 0)
                {
                    vx[i] = Math.Abs(vx[i]);
                }
                else if (labels[i].Right > ClientSize.Width)
                {
                    vx[i] = -Math.Abs(vx[i]);
                }

                if (labels[i].Top < 0)
                {
                    vy[i] = Math.Abs(vy[i]);
                }
                else if (labels[i].Bottom > ClientSize.Height)
                {
                    vy[i] = -Math.Abs(vy[i]);
                }

                if ((fpos.X > labels[i].Left)
                    && (fpos.X < labels[i].Right)
                    && (fpos.Y > labels[i].Top)
                    && (fpos.Y < labels[i].Bottom))
                {
                    timer1.Stop();
                    button1.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            counter = 0;
            button1.Visible = false;

            for (int i = 0; i < LabelCount; i++)
            {
                vx[i] = random.Next(-10, 11);
                vy[i] = random.Next(-10, 11);

                labels[i].Left = random.Next(ClientSize.Width - labels[i].Width);
                labels[i].Top = random.Next(ClientSize.Height - labels[i].Height);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                MessageBox.Show($"{i}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < 10; i++)
            {
                if (i == 2)
                {
                    continue;
                }
                if (i == 5)
                {
                    break;
                }
                MessageBox.Show(i.ToString());
            }
        }
    }
}
