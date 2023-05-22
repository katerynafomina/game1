namespace game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // timer1.Start();
            //while (gameOver == false)
            //{
            //    GenerateRandomCircle();
                
            //}
            //GenerateRandomCircle(); // ��������� ����������� ��������

        }
        private const int circleSize = 50; // ����� ������
        private int score = 0; // ˳������� ����
        private bool gameOver = false;
        private int circleDisappearTime = 2000;
        private void GenerateRandomCircle()
        {
            // �������� ������ ���� ��� ������, �� ������ �'�������� ��������
            int maxX = pictureBox1.Width - circleSize;
            int maxY = pictureBox1.Height - circleSize;

            // ��������� ��������� ���������� �����
            Random random = new Random();

            // �������� �������� ���������� X � Y
            int x = random.Next(maxX);
            int y = random.Next(maxY);

            List<Color> colorContainer = new List<Color>
            {
                Color.Red,
                Color.Green,
                Color.Blue,
                Color.Yellow,
                //Color.Orange
            };

            Random randomcolor = new Random();
            int randomIndex = randomcolor.Next(0, colorContainer.Count);
            Color randomColor = colorContainer[randomIndex];

            // ��������� ��������
            PictureBox circle = new PictureBox();
            circle.BackColor = randomColor; // ������ ���� ��������
            circle.Size = new Size(circleSize, circleSize); // ������ ����� ��������
            circle.Location = new Point(x, y); // ������ ���������� ��������

            // ������ �������� ��䳿 ���� �� ��������
            circle.Click += Circle_Click;

            // ������ �������� �� ����� ��� ���������� (���������, PictureBox)
            pictureBox1.Controls.Add(circle);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = circleDisappearTime; // ������ �������� ����
            timer.Tick += (sender, e) =>
            {
                timer.Stop(); // ��������� ������
                pictureBox1.Controls.Remove(circle); // ��������� �������� � ����� ��� ����������
                UpdateScoreLabel(); // ��������� ����
                CheckGameOver(); // ����������, �� ��� �� ����������
            };
            timer.Start(); // ��������� ������
        }
    
        private void Circle_Click(object sender, EventArgs e)
        {
            PictureBox circle = (PictureBox)sender;
            pictureBox1.Controls.Remove(circle); // ��������� �������� � ����� ��� ����������
            //switch(circle.BackColor)
            //{
            //    case Color.Red:
            //        score += 10; break;
            //}
            //score++; // �������� �������� ����
            if (circle.BackColor == Color.Red)
            {
                score += 10;
            }
            else if(circle.BackColor == Color.Yellow)
            {
                score += 5;
            }
            else if (circle.BackColor == Color.Blue)
            {
                score += 0;
            }
            else if (circle.BackColor == Color.Green)
            {
                score -= 20;
            }
            UpdateScoreLabel(); // ��������
        }
        private void UpdateScoreLabel()
        {
            scoreLabel.Text = "Score: " + score.ToString();
            if (score == -50) { gameOver = true; }// ��������� ����� ���� � ������
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            while (gameOver == false)
            {
                GenerateRandomCircle(); // ��������� ����������� ��������
            }

        }

        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }
        private void GameOver()
        {
            // ����� ���������� ���
            // ���������, ���������� ���������� ������, ����������� �������� ����
            //gameOver = true;
            timer1.Stop();
            MessageBox.Show($"your score:{score}");
            score = 0;
        }
        private void Game()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            GameOver(); 
        }
        private void CheckGameOver()
        {
            if (gameOver == true) { GameOver(); }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GenerateRandomCircle();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}