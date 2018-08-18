using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C16_Ex04_Yakir_201049475_Omer_300471430.Infrastructure.Models;
using C16_Ex04_Yakir_201049475_Omer_300471430.Interfaces;
using C16_Ex04_Yakir_201049475_Omer_300471430.Enums;
using C16_Ex04_Yakir_201049475_Omer_300471430.CustomEventArgs;

namespace C16_Ex04_Yakir_201049475_Omer_300471430.Models
{
    public abstract class Dreidel : GameComponent
    {
        public event EventHandler<DreidelEventArgs> StoppedSpinning;

        private const int k_DreidelBaseSize = 20;
        private float m_SpinSpeed;
        private TriangleListColorBox m_Handle;
        private TriangleListColorPyramid m_Tip;
        private PrimitiveObject3D m_Body;
        protected IGameManager m_GameManager;

        public int DreidelBaseSize
        {
            get { return k_DreidelBaseSize; }
        } 

        public float DreidelHeight
        {
            get { return m_Body.Height + (m_Tip.Height / 4) + (m_Tip.Height / 2) + m_Handle.Height; }
        }

        public Vector3 DreidelPosition
        {
            get { return m_Body.Position; }
            set { m_Body.Position = value; }
        }

        protected Vector3 DreidelRotation
        {
            get { return m_Body.Rotation; }
            set { m_Body.Rotation = m_Handle.Rotation = m_Tip.Rotation = value; }
        }

        protected Vector3 DreidelRotationVelocity
        {
            get { return m_Body.RotationVelocity; }
            set { m_Body.RotationVelocity = m_Handle.RotationVelocity = m_Tip.RotationVelocity = value; }
        }

        protected PrimitiveObject3D Body
        {
            get { return m_Body; }
            set { m_Body = value; }
        }

        protected TriangleListColorPyramid Tip
        {
            get { return m_Tip; }
            set { m_Tip = value; }
        }

        protected TriangleListColorBox Handle
        {
            get { return m_Handle; }
            set { m_Handle = value; }
        }

        public Dreidel(Game i_Game)
            : base(i_Game)
        {
            Vector3 dreidelBase;

            m_GameManager = this.Game.Services.GetService(typeof(IGameManager)) as IGameManager;
            dreidelBase = Vector3.One * k_DreidelBaseSize;
            m_Handle = new TriangleListColorBox(i_Game, new Vector3(k_DreidelBaseSize / 4, k_DreidelBaseSize / 3, k_DreidelBaseSize / 4));
            m_Tip = new TriangleListColorPyramid(i_Game, dreidelBase);
            monitorMe();
            i_Game.Components.Add(m_Handle);
            i_Game.Components.Add(m_Tip);
        }

        public override void Update(GameTime i_GameTime)
        {
            this.Handle.Position = new Vector3(this.Body.Position.X, this.Body.Position.Y + (this.Body.Height / 2) + (this.Handle.Height / 2), this.Body.Position.Z);
            this.Tip.Position = new Vector3(this.Body.Position.X, this.Body.Position.Y - this.Body.Height, this.Body.Position.Z);
            slowSpinVelocity(i_GameTime);
            base.Update(i_GameTime);
        }

        private void monitorMe()
        {
            m_GameManager.AddToMonitor(this);
        }

        private void slowSpinVelocity(GameTime i_GameTime)
        {
            double s, v0, t, a;

            v0 = m_SpinSpeed;
            t = (v0 - 2) * (Math.PI / v0);
            s = 0.5f * v0 * t;
            a = (2 * (s - (v0 * t))) / Math.Pow(t, 2);
            if (this.DreidelRotationVelocity.Y < 0)
            {
                this.DreidelRotationVelocity -= new Vector3(0, 1, 0) * (float)a * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (this.DreidelRotationVelocity.Y > 0)
            {
                this.DreidelRotationVelocity = Vector3.Zero;
                OnStoppedSpinning(new DreidelEventArgs(getCurrentLetter()));
            }
        }

        private float mod(float i_A, float i_N)
        {
            return ((i_A % i_N) + i_N) % i_N;
        }

        private bool between(float i_Num, float i_MinNum, float i_MaxNum)
        {
            return i_Num >= i_MinNum && i_Num <= i_MaxNum;
        }

        private eLetters getCurrentLetter()
        {
            eLetters currentLetter;
            float moduloRotation;

            currentLetter = eLetters.Nes;
            moduloRotation = mod(this.DreidelRotation.Y, MathHelper.TwoPi);
            if(between(moduloRotation, MathHelper.PiOver2, (float)Math.PI))
            {
                currentLetter = eLetters.Po;
            }
            else if (between(moduloRotation, (float)Math.PI, (float)Math.PI * 1.5f))
            {
                currentLetter = eLetters.Haya;
            }
            else if (moduloRotation >= (float)Math.PI * 1.5f)
            {
                currentLetter = eLetters.Gadol;
            }

            return currentLetter;
        }

        public void Spin(int i_SpinVelocity)
        {
            m_SpinSpeed = i_SpinVelocity;
            this.DreidelRotation = Vector3.Zero;
            this.DreidelRotationVelocity = new Vector3(0, -1, 0) * i_SpinVelocity;
        }

        protected virtual void OnStoppedSpinning(DreidelEventArgs e)
        {
            if(StoppedSpinning != null)
            {
                StoppedSpinning.Invoke(this, e);
            }
        }
    }
}
