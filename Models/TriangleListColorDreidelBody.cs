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
    public class TriangleListColorDreidelBody : TriangleListColorBox
    {
        private const int k_AmountOfLettersTriangels = 30;
        private const float k_LetterAdditiveDistance = 0.01f;
        private Color m_TintLetters;

        public TriangleListColorDreidelBody(Game i_Game, Vector3 i_Size)
            : base(i_Game, i_Size)
        {
            m_TintLetters = Color.Black;
            this.TrianglesAmountToDraw = k_NumOfTrianglesInABox + k_AmountOfLettersTriangels;
            this.Vertices = new VertexPositionColor[(k_NumOfTrianglesInABox * 3) + (k_AmountOfLettersTriangels * 3)];
        }

        private void createLetterNes(int i_StartingIndex)
        {
            Vector3 v0, v1, v2, v3, v4, v5, v6, v7, v8, v9;
            float z;

            z = (Depth / 2) + k_LetterAdditiveDistance;
            v0 = new Vector3(0, Height / 4, z);
            v1 = new Vector3(Width / 4, Height / 4, z);
            v2 = new Vector3(0, Height / 10, z);
            v3 = new Vector3(Width / 4, Height / 10, z);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v0, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v1, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v2, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v2, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v1, m_TintLetters);
            v4 = new Vector3(Width / 4, -Height / 10, z);
            v5 = new Vector3(Width / 10, -Height / 10, z);
            v6 = new Vector3(Width / 10, Height / 10, z);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v4, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v5, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v5, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v6, m_TintLetters);
            v7 = new Vector3(Width / 4, -Height / 4, z);
            v8 = new Vector3(-Width / 10, -Height / 4, z);
            v9 = new Vector3(-Width / 10, -Height / 10, z);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v4, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v7, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v8, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v4, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v8, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v9, m_TintLetters);
        }

        private void createLetterGadol(int i_StartingIndex)
        {
            Vector3 v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13;
            float x;

            x = (Width / 2) + k_LetterAdditiveDistance;
            v0 = new Vector3(x, Height / 4, Depth / 4);
            v1 = new Vector3(x, Height / 4, -Depth / 4);
            v2 = new Vector3(x, Height / 12, Depth / 4);
            v3 = new Vector3(x, Height / 12, -Depth / 4);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v0, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v1, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v2, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v2, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v1, m_TintLetters);
            v4 = new Vector3(x, -Height / 4, -Depth / 4);
            v5 = new Vector3(x, -Height / 4, -Depth / 11);
            v6 = new Vector3(x, Height / 12, -Depth / 11);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v4, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v5, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v5, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v6, m_TintLetters);
            v7 = new Vector3(x, 0, -Depth / 11);
            v8 = new Vector3(x, -Height / 9, -Depth / 11);
            v9 = new Vector3(x, -Height / 9, Depth / 4);
            v10 = new Vector3(x, 0, Depth / 4);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v7, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v8, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v9, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v7, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v9, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v10, m_TintLetters);
            v11 = new Vector3(x, -Height / 9, Depth / 9);
            v12 = new Vector3(x, -Height / 4, Depth / 4);
            v13 = new Vector3(x, -Height / 4, Depth / 9);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v11, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v13, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v12, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v11, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v12, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v9, m_TintLetters);
        }

        private void createLetterHaya(int i_StartingIndex)
        {
            Vector3 v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10;
            float z;

            z = (-Depth / 2) - k_LetterAdditiveDistance;
            v0 = new Vector3(Width / 4, Height / 4, z);
            v1 = new Vector3(Width / 4, Height / 12, z);
            v2 = new Vector3(-Width / 4, Height / 4, z);
            v3 = new Vector3(-Width / 4, Height / 12, z);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v0, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v2, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v1, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v1, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v2, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            v4 = new Vector3(-Width / 11, -Height / 4, z);
            v5 = new Vector3(-Width / 4, -Height / 4, z);
            v6 = new Vector3(-Width / 11, Height / 12, z);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v5, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v4, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v4, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v6, m_TintLetters);
            v7 = new Vector3(Width / 4, 0, z);
            v8 = new Vector3(Width / 4, -Height / 4, z);
            v9 = new Vector3(Width / 10, 0, z);
            v10 = new Vector3(Width / 10, -Height / 4, z);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v7, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v9, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v8, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v9, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v10, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v8, m_TintLetters);
        }

        private void createLetterPo(int i_StartingIndex)
        {
            Vector3 v0, v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15;
            float x;

            x = (-Width / 2) - k_LetterAdditiveDistance;
            v0 = new Vector3(x, Height / 4, -Depth / 4);
            v1 = new Vector3(x, Height / 4, Depth / 4);
            v2 = new Vector3(x, Height / 11, -Depth / 4);
            v3 = new Vector3(x, Height / 11, Depth / 4);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v0, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v1, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v2, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v2, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v1, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            v4 = new Vector3(x, -Height / 4, Depth / 4);
            v5 = new Vector3(x, -Height / 4, Depth / 11);
            v6 = new Vector3(x, Height / 11, Depth / 11);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v4, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v5, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v3, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v5, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v6, m_TintLetters);
            v7 = new Vector3(x, -Height / 4, -Depth / 4);
            v8 = new Vector3(x, -Height / 9, Depth / 11);
            v9 = new Vector3(x, -Height / 9, -Depth / 4);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v5, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v7, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v8, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v8, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v7, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v9, m_TintLetters);
            v10 = new Vector3(x, Height / 30, -Depth / 10);
            v11 = new Vector3(x, -Height / 9, -Depth / 10);
            v12 = new Vector3(x, Height / 30, -Depth / 4);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v9, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v10, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v11, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v9, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v12, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v10, m_TintLetters);
            v13 = new Vector3(x, Height / 30, 0);
            v14 = new Vector3(x, -Height / 22, -Depth / 10);
            v15 = new Vector3(x, -Height / 22, 0);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v10, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v13, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v14, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v14, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v13, m_TintLetters);
            this.Vertices[i_StartingIndex++] = new VertexPositionColor(v15, m_TintLetters);
        }

        protected override void SetVertices()
        {
            base.SetVertices();
            createLetterNes(36);
            createLetterGadol(54);
            createLetterHaya(78);
            createLetterPo(96);
        }
    }
}
