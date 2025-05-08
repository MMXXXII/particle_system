using static Система_частиц.Emitter;
using static Система_частиц.Particle;

namespace Система_частиц
{

    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // добавим поле для эмиттера

        GravityPoint point1; // добавил поле под первую точку


        public Form1()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter // создаю эмиттер и привязываю его к полю emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.Black,  // Начальный цвет - черный
                ColorTo = Color.FromArgb(0, Color.Black),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };



            emitters.Add(this.emitter);

            // привязываем гравитоны к полям
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };


            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);



        }


        // ну и обработка тика таймера, тут просто декомпозицию выполнили
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isPaused) // Если не на паузе, обновляем эмиттер
            {
                // Сбрасываем счетчик частиц в гравитационной точке
                point1.ResetParticleCount();

                // Обновляем состояние эмиттера
                emitter.UpdateState();

                using (var g = Graphics.FromImage(picDisplay.Image))
                {
                    g.Clear(Color.White);
                    emitter.Render(g);
                }

                // Используем новый счетчик TotalParticlesCreated
                label4.Text = $"Всего создано частиц: {emitter.TotalParticlesCreated}";

                picDisplay.Invalidate();
            }
        }




        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // это не трогаем
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            // а тут передаем положение мыши, в положение гравитона
            point1.X = e.X;
            point1.Y = e.Y;
        }

        private void tbDirection_Scroll_1(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            label2.Text = $"Направление: {tbDirection.Value}°"; // добавил вывод значения
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
            label3.Text = $"Размер гравитона: {tbGraviton.Value}";
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            // Изменяем минимальную и максимальную скорость в зависимости от положения ползунка
            emitter.SpeedMin = tbSpeed.Value / 2; // Минимальная скорость будет в диапазоне от 0 до 50
            emitter.SpeedMax = tbSpeed.Value;     // Максимальная скорость будет от 0 до 100

            // Отображаем текущую скорость на метке (опционально)
            label5.Text = $"Скорость: {tbSpeed.Value}";
        }

        private void btnChooseColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    point1.PointColor = colorDialog.Color; // устанавливаем цвет для точки
                    emitter.ColorFrom = colorDialog.Color; // начальный цвет для частиц
                    emitter.ColorTo = Color.FromArgb(0, colorDialog.Color); // конечный цвет для частиц
                }
            }
        }

        private bool isPaused = false; // Переменная для отслеживания состояния паузы

        private void pause_Click(object sender, EventArgs e)
        {
            isPaused = !isPaused; // Переключаем состояние паузы

            // Обновляем текст кнопки в зависимости от состояния
            if (isPaused)
            {
                pause.Text = "Пуск"; // Текст кнопки при паузе
            }
            else
            {
                pause.Text = "Пауза"; // Текст кнопки при запуске
            }
        }

    }
}
