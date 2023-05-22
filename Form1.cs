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
            //GenerateRandomCircle(); // Початкове генерування кружечка

        }
        private const int circleSize = 50; // Розмір кручка
        private int score = 0; // Лічильник балів
        private bool gameOver = false;
        private int circleDisappearTime = 2000;
        private void GenerateRandomCircle()
        {
            // Визначте розміри вікна або області, де будуть з'являтися кружечки
            int maxX = pictureBox1.Width - circleSize;
            int maxY = pictureBox1.Height - circleSize;

            // Створюємо генератор випадкових чисел
            Random random = new Random();

            // Генеруємо випадкові координати X і Y
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

            // Створюємо кружечок
            PictureBox circle = new PictureBox();
            circle.BackColor = randomColor; // Задаємо колір кружечка
            circle.Size = new Size(circleSize, circleSize); // Задаємо розмір кружечка
            circle.Location = new Point(x, y); // Задаємо координати кружечка

            // Додаємо обробник події кліку на кружечок
            circle.Click += Circle_Click;

            // Додаємо кружечок до форми або контейнера (наприклад, PictureBox)
            pictureBox1.Controls.Add(circle);
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = circleDisappearTime; // Задаємо інтервал часу
            timer.Tick += (sender, e) =>
            {
                timer.Stop(); // Зупиняємо таймер
                pictureBox1.Controls.Remove(circle); // Видаляємо кружечок з форми або контейнера
                UpdateScoreLabel(); // Оновлюємо бали
                CheckGameOver(); // Перевіряємо, чи гра не закінчилася
            };
            timer.Start(); // Запускаємо таймер
        }
    
        private void Circle_Click(object sender, EventArgs e)
        {
            PictureBox circle = (PictureBox)sender;
            pictureBox1.Controls.Remove(circle); // Видаляємо кружечок з форми або контейнера
            //switch(circle.BackColor)
            //{
            //    case Color.Red:
            //        score += 10; break;
            //}
            //score++; // Збільшуємо лічильник балів
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
            UpdateScoreLabel(); // Оновлюєм
        }
        private void UpdateScoreLabel()
        {
            scoreLabel.Text = "Score: " + score.ToString();
            if (score == -50) { gameOver = true; }// Оновлюємо текст мітки з балами
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            while (gameOver == false)
            {
                GenerateRandomCircle(); // Початкове генерування кружечка
            }

        }

        private void scoreLabel_Click(object sender, EventArgs e)
        {

        }
        private void GameOver()
        {
            // Логіка завершення гри
            // Наприклад, збереження результатів гравця, відображення рейтингу тощо
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