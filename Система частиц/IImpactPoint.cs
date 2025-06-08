using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Система_частиц.Particle;

namespace Система_частиц
{
    public abstract class IImpactPoint
    {
        public float X; // ну точка же, вот и две координаты
        public float Y;

        // абстрактный метод с помощью которого будем изменять состояние частиц
        // например притягивать
        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g) { }
    }

    public class GravityPoint : IImpactPoint
    {
        public int Power = 100; // сила притяжения/отталкивания
        public int ParticleCount = 0; // количество частиц внутри круга
        public Color PointColor = Color.Red; // Цвет круга
        public bool IsAntiGravity = false; // Режим антигравитации

        // Сбрасывает количество частиц
        public void ResetParticleCount()
        {
            ParticleCount = 0;
        }

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); // расстояние от центра точки до центра частицы

            if (r + particle.Radius < Power / 2) // если частица внутри окружности
            {
                ParticleCount++; // увеличиваем счетчик частиц

                float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                if (IsAntiGravity)
                {
                    // Отталкиваем частицу (антигравитация)
                    particle.SpeedX -= gX * Power / r2;
                    particle.SpeedY -= gY * Power / r2;
                }
                else
                {
                    // Притягиваем частицу (обычная гравитация)
                    particle.SpeedX += gX * Power / r2;
                    particle.SpeedY += gY * Power / r2;
                }

                // Перекрашиваем частицу при попадании в круг
                if (particle is ParticleColorful colorfulParticle)
                {
                    colorfulParticle.ChangeColor(PointColor); // меняем цвет на цвет круга
                }
            }
        }

        public override void Render(Graphics g)
        {
            // рисую окружность с выбранным цветом
            using (var brush = new SolidBrush(Color.FromArgb(100, PointColor)))
            {
                g.FillEllipse(brush, X - Power / 2, Y - Power / 2, Power, Power);
            }

            g.DrawEllipse(new Pen(PointColor), X - Power / 2, Y - Power / 2, Power, Power);

            var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            var font = new Font("Verdana", 10);

            // текст с информацией - показываем режим
            var modeText = IsAntiGravity ? "Антигравитон" : "Гравитон";
            var text = $"{modeText}\nЧастиц: {ParticleCount}";
            g.DrawString(text, font, new SolidBrush(Color.Black), X, Y, stringFormat);
        }
    }

    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100; // сила отторжения
        public int Radius = 100; // радиус действия антигравитона
        public Color PointColor = Color.Blue; // Цвет круга антигравитона

        // Метод воздействия на частицы
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double distance = Math.Sqrt(gX * gX + gY * gY);

            // Если частица находится внутри круга антигравитона
            if (distance < Radius)
            {
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX -= gX * Power / r2; // Отталкиваем частицу
                particle.SpeedY -= gY * Power / r2; // Отталкиваем частицу
            }
        }

        // Метод рисования круга антигравитона
        public override void Render(Graphics g)
        {
            // Рисуем сам круг
            using (var brush = new SolidBrush(Color.FromArgb(100, PointColor)))
            {
                g.FillEllipse(brush, X - Radius / 2, Y - Radius / 2, Radius, Radius);
            }

            g.DrawEllipse(new Pen(PointColor), X - Radius / 2, Y - Radius / 2, Radius, Radius);

            var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            var font = new Font("Verdana", 10);

            // Текст с информацией
            var text = $"Антигравитон";
            g.DrawString(text, font, new SolidBrush(Color.Black), X, Y, stringFormat);
        }
    }

    public class BlackHolePoint : IImpactPoint
    {
        public int Radius = 50; // Радиус черной дыры
        public int ParticlesEaten = 0; // Счетчик съеденных частиц
        public Color PointColor = Color.Black; // Цвет черной дыры

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double distance = Math.Sqrt(gX * gX + gY * gY);

            // Если частица находится внутри черной дыры, она уничтожается
            if (distance < Radius)
            {
                particle.Life = 0; // Уничтожаем частицу
                ParticlesEaten++;  // Увеличиваем счетчик съеденных частиц
            }
        }

        public override void Render(Graphics g)
        {
            // Рисуем черную дыру
            using (var brush = new SolidBrush(PointColor))
            {
                g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }

            g.DrawEllipse(new Pen(Color.White, 2), X - Radius, Y - Radius, Radius * 2, Radius * 2);

            var stringFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
            var font = new Font("Verdana", 10);

            // текст с количеством съеденных частиц внутри круга
            var text = $"Съедено: {ParticlesEaten}";
            g.DrawString(text, font, new SolidBrush(Color.White), X, Y, stringFormat);
        }

        // Метод сброса счетчика
        public void ResetParticlesEaten()
        {
            ParticlesEaten = 0;
        }

        // Добавить в файл IImpactPoint.cs новый класс:

        public class ColorPoint : IImpactPoint
        {
            public int Radius = 30; // Радиус точки перекрашивания
            public Color PointColor = Color.Red; // Цвет точки
            public bool IsEnabled = true; // Включена ли точка

            public override void ImpactParticle(Particle particle)
            {
                if (!IsEnabled) return; // Если точка выключена, не воздействуем

                float gX = X - particle.X;
                float gY = Y - particle.Y;
                double distance = Math.Sqrt(gX * gX + gY * gY);

                // Если частица находится внутри радиуса точки
                if (distance < Radius)
                {
                    // Перекрашиваем частицу
                    if (particle is ParticleColorful colorfulParticle)
                    {
                        colorfulParticle.ChangeColor(PointColor);
                    }
                }
            }

            public override void Render(Graphics g)
            {
                if (!IsEnabled) return; // Если выключена, не рисуем

                // Рисуем полупрозрачный цветной круг как у гравитона
                using (var brush = new SolidBrush(Color.FromArgb(100, PointColor)))
                {
                    g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
                }

                g.DrawEllipse(new Pen(PointColor), X - Radius, Y - Radius, Radius * 2, Radius * 2);
            }
        }
    }
}