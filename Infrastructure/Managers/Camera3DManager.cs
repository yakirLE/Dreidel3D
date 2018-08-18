using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using C16_Ex04_Yakir_201049475_Omer_300471430.Interfaces;

namespace C16_Ex04_Yakir_201049475_Omer_300471430
{
    public class Camera3DManager : DrawableGameComponent, ICamera3DManager
    {
        private const float k_NearPlaneDistance = 0.5f;
        private const float k_FarPlaneDistance = 1000.0f;
        private const float k_ViewAngle = MathHelper.PiOver4;
        private const float k_CameraSpeed = 100;
        private IInputManager m_InputManager;
        private Matrix m_CameraSettings;
        private Matrix m_CameraState;
        private Vector3 m_CameraLooksAt;
        private Vector3 m_CameraLocation;
        private Vector3 m_CameraUpDirection;

        public Matrix CameraSettings
        {
            get { return m_CameraSettings; }
            set { m_CameraSettings = value; }
        }

        public Matrix CameraState
        {
            get { return m_CameraState; }
            set { m_CameraState = value; }
        }

        public Camera3DManager(Game i_Game)
            : base(i_Game)
        {
            i_Game.Services.AddService(typeof(ICamera3DManager), this);
            m_CameraLooksAt = Vector3.Zero;
            m_CameraLocation = new Vector3(0, 0, k_CameraSpeed * 2);
            m_CameraUpDirection = new Vector3(0, 1, 0);
            this.UpdateOrder = int.MinValue;
            i_Game.Components.Add(this);
        }

        public override void Initialize()
        {
            m_InputManager = this.Game.Services.GetService(typeof(IInputManager)) as IInputManager;
            setCameraSettings();
            base.Initialize();
        }

        public override void Update(GameTime i_GameTime)
        {
            handleInputs(i_GameTime);
            setCameraState();
            base.Update(i_GameTime);
        }

        private void handleInputs(GameTime i_GameTime)
        {
            if (m_InputManager.IsKeyHeld(Keys.Up))
            {
                m_CameraLocation.Z += -k_CameraSpeed * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (m_InputManager.IsKeyHeld(Keys.Down))
            {
                m_CameraLocation.Z += k_CameraSpeed * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (m_InputManager.IsKeyHeld(Keys.Right))
            {
                m_CameraLocation.X += k_CameraSpeed * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (m_InputManager.IsKeyHeld(Keys.Left))
            {
                m_CameraLocation.X += -k_CameraSpeed * (float)i_GameTime.ElapsedGameTime.TotalSeconds;
            }
        }

        private void setCameraSettings()
        {
            m_CameraSettings = Matrix.CreatePerspectiveFieldOfView(
                k_ViewAngle,
                GraphicsDevice.Viewport.AspectRatio,
                k_NearPlaneDistance,
                k_FarPlaneDistance);
        }

        private void setCameraState()
        {
            m_CameraState = Matrix.CreateLookAt(
                m_CameraLocation, 
                m_CameraLooksAt, 
                m_CameraUpDirection);
        }
    }
}
