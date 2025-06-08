using static Система_частиц.BlackHolePoint;
using static Система_частиц.Emitter;
using static Система_частиц.Particle;

namespace Система_частиц
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint point1;
        BlackHolePoint blackHole;
        bool isBlackHoleEnabled = false;

        // Добавляем антигравитон
        AntiGravityPoint antiGravityPoint;
        bool isAntiGravityEnabled = false;

        // Добавляем 5 точек перекрашивания
        List<ColorPoint> colorPoints = new List<ColorPoint>();
        bool areColorPointsEnabled = false;

        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Black,
                ColorTo = Color.FromArgb(0, Color.Black),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);

            trackBar2.Minimum = 0;
            trackBar2.Maximum = 10;

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };

            emitter.impactPoints.Add(point1);

            blackHole = new BlackHolePoint
            {
                X = picDisplay.Width / 2 - 150,
                Y = picDisplay.Height / 2,
                Radius = 50
            };

            // Создаем антигравитон
            antiGravityPoint = new AntiGravityPoint
            {
                X = picDisplay.Width / 2 + 200,
                Y = picDisplay.Height / 2 + 100,
                Power = 100,
                Radius = 80
            };

            // Создаем 5 цветных точек на 2 см ниже центра
            CreateColorPoints();
        }

        private void CreateColorPoints()
        {
            Color[] colors = { Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Purple };

            // 2 см ≈ 75-80 пикселей при стандартном DPI
            int offsetBelow = 80; // 2 см ниже центра
            int centerX = picDisplay.Width / 2;
            int centerY = picDisplay.Height / 2;

            for (int i = 0; i < 5; i++)
            {
                var colorPoint = new ColorPoint
                {
                    // Располагаем точки горизонтально вокруг центра
                    X = centerX - 160 + i * 80, // От -160 до +160 от центра
                    Y = centerY + offsetBelow, // На 2 см ниже центра
                    PointColor = colors[i],
                    Radius = 25, // Чуть меньше радиус
                    IsEnabled = false // Изначально выключены
                };

                colorPoints.Add(colorPoint);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                point1.ResetParticleCount();
                emitter.UpdateState();

                using (var g = Graphics.FromImage(picDisplay.Image))
                {
                    g.Clear(Color.White);
                    emitter.Render(g);

                    // Рисуем цветные точки
                    foreach (var colorPoint in colorPoints)
                    {
                        colorPoint.Render(g);
                    }

                    // Рисуем антигравитон если включен
                    if (isAntiGravityEnabled)
                    {
                        antiGravityPoint.Render(g);
                    }
                }

                label4.Text = $"Всего создано частиц: {emitter.TotalParticlesCreated}";
                picDisplay.Invalidate();
            }
        }

        // Включение/выключение цветных точек
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            areColorPointsEnabled = checkBox2.Checked;

            foreach (var colorPoint in colorPoints)
            {
                colorPoint.IsEnabled = areColorPointsEnabled;

                if (areColorPointsEnabled)
                {
                    if (!emitter.impactPoints.Contains(colorPoint))
                    {
                        emitter.impactPoints.Add(colorPoint);
                    }
                }
                else
                {
                    if (emitter.impactPoints.Contains(colorPoint))
                    {
                        emitter.impactPoints.Remove(colorPoint);
                    }
                }
            }
        }

        // Включение/выключение антигравитона
        // В Form1.cs добавить/изменить метод:

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            // Переключаем режим существующего гравитона
            point1.IsAntiGravity = checkBox3.Checked;

            // Меняем цвет в зависимости от режима
            if (checkBox3.Checked)
            {
                point1.PointColor = Color.Blue; // Синий для антигравитона
            }
            else
            {
                point1.PointColor = Color.Red; // Красный для гравитона
            }
        }

        // Рандомизация цветов точек
        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();

            foreach (var colorPoint in colorPoints)
            {
                colorPoint.PointColor = Color.FromArgb(
                    rand.Next(256), // R
                    rand.Next(256), // G
                    rand.Next(256)  // B
                );
            }
        }

        // Все остальные методы остаются без изменений...
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }
            point1.X = e.X;
            point1.Y = e.Y;
        }

        private void tbDirection_Scroll_1(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            label2.Text = $"Направление: {tbDirection.Value}°";
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
            label3.Text = $"Размер гравитона: {tbGraviton.Value}";
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMin = tbSpeed.Value / 2;
            emitter.SpeedMax = tbSpeed.Value;
            label5.Text = $"Скорость: {tbSpeed.Value}";
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    point1.PointColor = colorDialog.Color;
                    emitter.ColorFrom = colorDialog.Color;
                    emitter.ColorTo = Color.FromArgb(0, colorDialog.Color);
                }
            }
        }

        private bool isPaused = false;

        private void pause_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                pause.Text = "Пуск";
            }
            else
            {
                pause.Text = "Пауза";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            isBlackHoleEnabled = checkBox1.Checked;

            if (isBlackHoleEnabled)
            {
                if (!emitter.impactPoints.Contains(blackHole))
                {
                    emitter.impactPoints.Add(blackHole);
                }
            }
            else
            {
                if (emitter.impactPoints.Contains(blackHole))
                {
                    emitter.impactPoints.Remove(blackHole);
                }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = trackBar1.Value;
            label6.Text = $"Угол разброса: {trackBar1.Value}°";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int lifetimeSeconds = trackBar2.Value;

            if (lifetimeSeconds == 0)
            {
                emitter.LifeMin = 0;
                emitter.LifeMax = 0;
                label7.Text = $"Время жизни: {lifetimeSeconds} сек";
            }
            else
            {
                int ticksPerSecond = 60;
                emitter.LifeMin = lifetimeSeconds * ticksPerSecond / 2;
                emitter.LifeMax = lifetimeSeconds * ticksPerSecond;
                label7.Text = $"Время жизни: {lifetimeSeconds} сек";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}