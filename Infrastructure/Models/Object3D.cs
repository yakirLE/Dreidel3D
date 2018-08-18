using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace C16_Ex04_Yakir_201049475_Omer_300471430
{
    public abstract class Object3D : DrawableGameComponent
    {
        private BasicEffect m_BasicEffect;
        private RasterizerState m_RasterizerState;
        private ICamera3DManager m_Camera;
        private Vector3 m_Position;
        private Vector3 m_Rotation;
        private Vector3 m_Scale;
        private Vector3 m_Velocity;
        private Vector3 m_RotationVelocity;
        private Matrix m_WorldMatrix;

        public Vector3 RotationVelocity
        {
            get { return m_RotationVelocity; }
            set { m_RotationVelocity = value; }
        }

        public Vector3 Velocity
        {
            get { return m_Velocity; }
            set { m_Velocity = value; }
        }

        public Matrix WorldMatrix
        {
            get { return m_WorldMatrix; }
            set { m_WorldMatrix = value; }
        }

        public Vector3 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        
        public Vector3 Rotation
        {
            get { return m_Rotation; }
            set { m_Rotation = value; }
        }

        public Vector3 Scale
        {
            get { return m_Scale; }
            set { m_Scale = value; }
        }

        protected BasicEffect BasicEffect
        {
            get { return m_BasicEffect; }
            set { m_BasicEffect = value; }
        }

        protected RasterizerState RasterizerState
        {
            get { return m_RasterizerState; }
            set { m_RasterizerState = value; }
        }

        protected ICamera3DManager Camera
        {
            get { return m_Camera; }
            set { m_Camera = value; }
        }

        public Object3D(Game i_Game)
            : base(i_Game)
        {
            m_Position = Vector3.Zero;
            m_Rotation = Vector3.Zero;
            m_Scale = Vector3.One;
            m_Velocity = Vector3.Zero;
            m_RotationVelocity = Vector3.Zero;
            m_WorldMatrix = Matrix.Identity;
        }

        protected abstract void DrawTechnique();

        protected virtual void SetCullMode()
        {
            this.RasterizerState.CullMode = CullMode.CullCounterClockwiseFace;
        }

        public override void Initialize()
        {
            this.Camera = this.Game.Services.GetService(typeof(ICamera3DManager)) as ICamera3DManager;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.BasicEffect = new BasicEffect(this.GraphicsDevice);
            this.RasterizerState = new RasterizerState();
            SetCullMode();
            base.LoadContent();
        }

        public override void Update(GameTime i_GameTime)
        {
            this.Position += this.Velocity * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
            this.Rotation += this.RotationVelocity * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
            buildWorldMatrix();
            base.Update(i_GameTime);
        }

        public override void Draw(GameTime i_GameTime)
        {
            this.GraphicsDevice.RasterizerState = this.RasterizerState;
            this.BasicEffect.World = this.WorldMatrix;
            this.BasicEffect.View = this.Camera.CameraState;
            this.BasicEffect.Projection = this.Camera.CameraSettings;
            foreach(EffectPass pass in this.BasicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                DrawTechnique();
            }

            base.Draw(i_GameTime);
        }

        protected override void UnloadContent()
        {
            if(this.BasicEffect != null)
            {
                this.BasicEffect.Dispose();
                this.BasicEffect = null;
            }
        }

        private void buildWorldMatrix()
        {
            this.WorldMatrix =
                Matrix.CreateScale(this.Scale) *
                Matrix.CreateRotationX(this.Rotation.X) *
                Matrix.CreateRotationY(this.Rotation.Y) *
                Matrix.CreateRotationZ(this.Rotation.Z) *
                Matrix.CreateTranslation(this.Position);
        }
    }
}
