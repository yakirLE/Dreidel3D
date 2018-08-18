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
    public class TriangleListColorDreidel : Dreidel
    {
        public TriangleListColorDreidel(Game i_Game)
            : base(i_Game)
        {
            this.Body = new TriangleListColorDreidelBody(i_Game, Vector3.One * this.DreidelBaseSize);
            paintBody();
            this.Handle.SetSolidColor(Color.Yellow);
            i_Game.Components.Add(this.Body);
        }

        private void paintBody()
        {
            TriangleListColorDreidelBody body;

            body = this.Body as TriangleListColorDreidelBody;
            body.RightColor = new Color(76, 255, 0);
            body.LeftColor = Color.Blue;
            body.BackColor = Color.Red;
            body.FrontColor = Color.Yellow;
        }
    }
}
