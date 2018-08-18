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
    public class TriangleListColorBox : VertexPositionColorObject3D
    {
        protected const int k_NumOfTrianglesInABox = 12;
        private Color m_FrontColor;
        private Color m_BackColor;
        private Color m_TopColor;
        private Color m_BottomColor;
        private Color m_RightColor;
        private Color m_LeftColor;

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

        public Color BottomColor
        {
            get { return m_BottomColor; }
            set { m_BottomColor = value; }
        }

        public Color TopColor
        {
            get { return m_TopColor; }
            set { m_TopColor = value; }
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

        public TriangleListColorBox(Game i_Game, Vector3 i_Size)
            : base(i_Game, i_Size)
        {
            SetSolidColor(Color.Gray);
            this.Vertices = new VertexPositionColor[k_NumOfTrianglesInABox * 3];
            this.TrianglesAmountToDraw = k_NumOfTrianglesInABox;
        }

        public void SetSolidColor(Color i_SolidColor)
        {
            m_FrontColor = m_BackColor = m_TopColor = m_BottomColor = m_RightColor = m_LeftColor = i_SolidColor;
        }

        protected override void SetVertices()
        {
            Vector3 v0, v1, v2, v3, v4, v5, v6, v7;

            v0 = new Vector3(-Width / 2, Height / 2, -Depth / 2);
            v1 = new Vector3(-Width / 2, -Height / 2, -Depth / 2);
            v2 = new Vector3(Width / 2, -Height / 2, -Depth / 2);
            v3 = new Vector3(Width / 2, Height / 2, -Depth / 2);
            v4 = new Vector3(-Width / 2, -Height / 2, Depth / 2);
            v5 = new Vector3(-Width / 2, Height / 2, Depth / 2);
            v6 = new Vector3(Width / 2, -Height / 2, Depth / 2);
            v7 = new Vector3(Width / 2, Height / 2, Depth / 2);
            /// Back Standing Square
            this.Vertices[0] = new VertexPositionColor(v0, this.BackColor);
            this.Vertices[1] = new VertexPositionColor(v1, this.BackColor);
            this.Vertices[2] = new VertexPositionColor(v2, this.BackColor);
            this.Vertices[3] = new VertexPositionColor(v0, this.BackColor);
            this.Vertices[4] = new VertexPositionColor(v2, this.BackColor);
            this.Vertices[5] = new VertexPositionColor(v3, this.BackColor);
            /// Front Standing Square
            this.Vertices[6] = new VertexPositionColor(v4, this.FrontColor);
            this.Vertices[7] = new VertexPositionColor(v5, this.FrontColor);
            this.Vertices[8] = new VertexPositionColor(v6, this.FrontColor);
            this.Vertices[9] = new VertexPositionColor(v6, this.FrontColor);
            this.Vertices[10] = new VertexPositionColor(v5, this.FrontColor);
            this.Vertices[11] = new VertexPositionColor(v7, this.FrontColor);
            /// Top Square
            this.Vertices[12] = new VertexPositionColor(v0, this.TopColor);
            this.Vertices[13] = new VertexPositionColor(v7, this.TopColor);
            this.Vertices[14] = new VertexPositionColor(v5, this.TopColor);
            this.Vertices[15] = new VertexPositionColor(v7, this.TopColor);
            this.Vertices[16] = new VertexPositionColor(v0, this.TopColor);
            this.Vertices[17] = new VertexPositionColor(v3, this.TopColor);
            /// Floor Square
            this.Vertices[18] = new VertexPositionColor(v1, this.BottomColor);
            this.Vertices[19] = new VertexPositionColor(v4, this.BottomColor);
            this.Vertices[20] = new VertexPositionColor(v6, this.BottomColor);
            this.Vertices[21] = new VertexPositionColor(v6, this.BottomColor);
            this.Vertices[22] = new VertexPositionColor(v2, this.BottomColor);
            this.Vertices[23] = new VertexPositionColor(v1, this.BottomColor);
            /// Right Square
            this.Vertices[24] = new VertexPositionColor(v7, this.RightColor);
            this.Vertices[25] = new VertexPositionColor(v3, this.RightColor);
            this.Vertices[26] = new VertexPositionColor(v6, this.RightColor);
            this.Vertices[27] = new VertexPositionColor(v6, this.RightColor);
            this.Vertices[28] = new VertexPositionColor(v3, this.RightColor);
            this.Vertices[29] = new VertexPositionColor(v2, this.RightColor);
            /// Left Square     
            this.Vertices[30] = new VertexPositionColor(v0, this.LeftColor);
            this.Vertices[31] = new VertexPositionColor(v5, this.LeftColor);
            this.Vertices[32] = new VertexPositionColor(v4, this.LeftColor);
            this.Vertices[33] = new VertexPositionColor(v4, this.LeftColor);
            this.Vertices[34] = new VertexPositionColor(v1, this.LeftColor);
            this.Vertices[35] = new VertexPositionColor(v0, this.LeftColor);
        }

        public override void Initialize()
        {
            base.Initialize();
            SetVertices();
        }
    }
}
