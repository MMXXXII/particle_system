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
        public int Power = 100; // сила притяжения
        public int ParticleCount = 0; // количество частиц внутри круга
        public Color PointColor = Color.Red; // Цвет круга

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

                // Притягиваем частицу
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;

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

            // текст с информацией
            var text = $"Частиц: {ParticleCount}";
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

}