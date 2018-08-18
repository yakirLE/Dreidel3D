using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace C16_Ex04_Yakir_201049475_Omer_300471430.Infrastructure.Models
{
    public abstract class VertexPositionTextureObject3D : PrimitiveObject3D
    {
        private string m_AssetName;
        private Texture2D m_Texture;
        private VertexPositionTexture[] m_Vertices;

        protected string AssetName
        {
            get { return m_AssetName; }
            set { m_AssetName = value; }
        }

        protected Texture2D Texture
        {
            get { return m_Texture; }
            set { m_Texture = value; }
        }

        protected VertexPositionTexture[] Vertices
        {
            get { return m_Vertices; }
            set { m_Vertices = value; }
        }

        public VertexPositionTextureObject3D(Game i_Game, Vector3 i_Size)
            : base(i_Game, i_Size)
        {
        }

        protected override void DrawTechnique()
        {
            this.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(
                this.PrimitiveType,
                this.Vertices,
                this.StartingVertice,
                this.TrianglesAmountToDraw);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            this.Texture = this.Game.Content.Load<Texture2D>(this.AssetName);
            this.BasicEffect.VertexColorEnabled = false;
            this.BasicEffect.Texture = this.Texture;
            this.BasicEffect.TextureEnabled = true;
        }
    }
}
