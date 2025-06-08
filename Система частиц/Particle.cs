using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Система_частиц
{
    public class Particle
    {
        public int Radius; // радиус частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве

        public float SpeedX; // скорость перемещения по оси X
        public float SpeedY; // скорость перемещения по оси Y

        // добавили генератор случайных чисел
        public float Life; // запас здоровья частицы

        public static Random rand = new Random();

        public virtual void Draw(Graphics g)
        {
            /* ... */
        }

        public Particle()
        {
            // генерируем произвольное направление и скорость
            var direction = (double)rand.Next(360);
            var speed = 1 + rand.Next(10);

            // рассчитываем вектор скорости
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            // а это не трогаем
            Radius = 2 + rand.Next(10);
            Life = 20 + rand.Next(100);
        }

        // новый класс для цветных частиц
        public class ParticleColorful : Particle
        {
            public Color FromColor { get; set; } = Color.Black; // Исходный цвет (черный)
            public Color CurrentColor { get; set; }             // Текущий цвет частицы
            public bool IsColored { get; set; } = false;        // Флаг, который будет указывать, перекрашивалась ли частица

            public ParticleColorful()
            {
                CurrentColor = FromColor; // Изначально частица черная
            }

            // Переопределяем метод Draw
            public override void Draw(Graphics g)
            {
                var b = new SolidBrush(CurrentColor);
                g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
                b.Dispose();
            }

            // Метод для изменения цвета при попадании в круг
            public void ChangeColor(Color color)
            {
                CurrentColor = color;
                IsColored = true; // Устанавливаем флаг, что частица перекрасилась
            }

            // Метод для сброса цвета в черный после исчезновения, если не перекрашивалась
            public void ResetColor()
            {
                if (!IsColored) // Если цвет не менялся, то сбрасываем на черный
                {
                    CurrentColor = FromColor;
                }
            }
        }
    }
}