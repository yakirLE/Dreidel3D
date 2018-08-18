using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace C16_Ex04_Yakir_201049475_Omer_300471430.Models
{
    public class TriangleListColorPyramid : VertexPositionColorObject3D
    {
        private const int k_NumOfTrianglesInAPyramid = 6;
        private Color m_TipColor;
        private Color m_FrontColor;
        private Color m_BackColor;
        private Color m_BaseColor;
        private Color m_RightColor;
        private Color m_LeftColor;

        public Color TipColor
        {
            get { return m_TipColor; }
            set { m_TipColor = value; }
        }

        public Color LeftColor
        {
            get { return m_LeftColor; }
            set { m_LeftColor = value; }
        }

        public Color RightColor
        {
            get { return m_RightColor; }
            set { m_RightColor = value; }
        }

        public Color BaseColor
        {
            get { return m_BaseColor; }
            set { m_BaseColor = value; }
        }

        public Color BackColor
        {
            get { return m_BackColor; }
            set { m_BackColor = value; }
        }

        public Color FrontColor
        {
            get { return m_FrontColor; }
            set { m_FrontColor = value; }
        }

        public TriangleListColorPyramid(Game i_Game, Vector3 i_Size)
            : base(i_Game, i_Size)
        {
            SetSolidColor(Color.Gray);
            this.TipColor = Color.White;
        }

        public override void Initialize()
        {
            base.Initialize();
            this.TrianglesAmountToDraw = k_NumOfTrianglesInAPyramid;
        }

        public void SetSolidColor(Color i_SolidColor)
        {
            m_FrontColor = m_BackColor = m_BaseColor = m_RightColor = m_LeftColor = i_SolidColor;
        }

        protected override void SetVertices()
        {
            Vector3 v0, v1, v2, v3, v4;

            this.Vertices = new VertexPositionColor[k_NumOfTrianglesInAPyramid * 3];
            v0 = new Vector3(-Width / 2, Height / 2, Depth / 2);
            v1 = new Vector3(Width / 2, Height / 2, -Depth / 2);
            v2 = new Vector3(Width / 2, Height / 2, Depth / 2);
            v3 = new Vector3(-Width / 2, Height / 2, -Depth / 2);
            v4 = new Vector3(0, -Height / 4, 0);
            /// Base Square
            this.Vertices[0] = new VertexPositionColor(v0, this.BaseColor);
            this.Vertices[1] = new VertexPositionColor(v1, this.BaseColor);
            this.Vertices[2] = new VertexPositionColor(v2, this.BaseColor);
            this.Vertices[3] = new VertexPositionColor(v0, this.BaseColor);
            this.Vertices[4] = new VertexPositionColor(v3, this.BaseColor);
            this.Vertices[5] = new VertexPositionColor(v1, this.BaseColor);
            /// Front Triangle
            this.Vertices[6] = new VertexPositionColor(v0, this.FrontColor);
            this.Vertices[7] = new VertexPositionColor(v2, this.FrontColor);
            this.Vertices[8] = new VertexPositionColor(v4, this.TipColor);
            /// Right Triangle
            this.Vertices[9] = new VertexPositionColor(v2, this.RightColor);
            this.Vertices[10] = new VertexPositionColor(v1, this.RightColor);
            this.Vertices[11] = new VertexPositionColor(v4, this.TipColor);
            /// Left Triangle
            this.Vertices[12] = new VertexPositionColor(v0, this.LeftColor);
            this.Vertices[13] = new VertexPositionColor(v4, this.TipColor);
            this.Vertices[14] = new VertexPositionColor(v3, this.LeftColor);
            /// Back Triangle
            this.Vertices[15] = new VertexPositionColor(v1, this.BackColor);
            this.Vertices[16] = new VertexPositionColor(v3, this.BackColor);
            this.Vertices[17] = new VertexPositionColor(v4, this.TipColor);
        }
    }
}
