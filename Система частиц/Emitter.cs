using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Система_частиц.Particle;

namespace Система_частиц
{
    public class Emitter
    {
        public int X; // координата X центра эмиттера
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость
        public int SpeedMax = 10; // начальная максимальная скорость
        public int RadiusMin = 2; // минимальный радиус
        public int RadiusMax = 10; // максимальный радиус
        public int LifeMin = 20; // минимальное время жизни
        public int LifeMax = 100; // максимальное время жизни
        public int ParticlesPerTick = 1;

        public Color ColorFrom = Color.Black; // начальный цвет частицы (черный)
        public Color ColorTo = Color.Red; // цвет, в который частица будет перекрашиваться в момент попадания в круг

        List<Particle> particles = new List<Particle>();
        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // точки притяжения

        public int MousePositionX;
        public int MousePositionY;

        public float GravitationX = 0;
        public float GravitationY = 0;
        public int TotalParticlesCreated { get; private set; } = 0;

        // Метод создания частицы
        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.ResetColor(); // Начальный цвет - черный

            return particle;
        }

        public virtual void ResetParticle(Particle particle)
        {
            // Сбрасываем параметры частицы
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);
            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;
            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);

            // Принудительно сбрасываем цвет частицы на черный
            if (particle is ParticleColorful colorfulParticle)
            {
                colorfulParticle.CurrentColor = Color.Black; // Начальный цвет - черный
                colorfulParticle.IsColored = false;          // Сбрасываем флаг перекрашивания
            }
        }

        // Обновление состояния частиц
        // Обновление состояния частиц
        // Обновление состояния частиц
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick;

            // Если время жизни 0, не создаем новые частицы
            if (LifeMax <= 0)
            {
                particlesToCreate = 0;
            }

            // Создаем список частиц для удаления
            List<Particle> particlesToRemove = new List<Particle>();

            foreach (var particle in particles)
            {
                if (particle.Life <= 0)
                {
                    // Добавляем частицу в список на удаление
                    particlesToRemove.Add(particle);
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                    particle.Life -= 1;

                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }

                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }

            // Удаляем все мертвые частицы
            foreach (var particle in particlesToRemove)
            {
                particles.Remove(particle);
            }

            // Создаем новые частицы только если время жизни больше 0
            for (int i = 0; i < particlesToCreate; i++)
            {
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
                TotalParticlesCreated++;
            }
        }

        // Отображение частиц
        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }
    }
}