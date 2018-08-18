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
    public abstract class PrimitiveObject3D : Object3D
    {
        private int m_StartingVertice;
        private int m_TrianglesAmountToDraw;
        private PrimitiveType m_PrimitiveType;
        private Vector3 m_Size;

        public float Width
        {
            get { return m_Size.X; }
            set { m_Size.X = value; }
        }

        public float Height
        {
            get { return m_Size.Y; }
            set { m_Size.Y = value; }
        }

        public float Depth
        {
            get { return m_Size.Z; }
            set { m_Size.Z = value; }
        }

        protected int TrianglesAmountToDraw
        {
            get { return m_TrianglesAmountToDraw; }
            set { m_TrianglesAmountToDraw = value; }
        }

        protected int StartingVertice
        {
            get { return m_StartingVertice; }
            set { m_StartingVertice = value; }
        }

        protected PrimitiveType PrimitiveType
        {
            get { return m_PrimitiveType; }
            set { m_PrimitiveType = value; }
        }

        public PrimitiveObject3D(Game i_Game, Vector3 i_Size)
            : base(i_Game)
        {
            m_StartingVertice = 0;
            m_Size = i_Size;
            m_PrimitiveType = PrimitiveType.TriangleList;
        }

        protected abstract void SetVertices();

        public override void Initialize()
        {
            base.Initialize();
            SetVertices();
        }
    }
}
