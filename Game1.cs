using C16_Ex04_Yakir_201049475_Omer_300471430;
using C16_Ex04_Yakir_201049475_Omer_300471430.Managers;
using C16_Ex04_Yakir_201049475_Omer_300471430.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// $G$ RUL-006 (-40) Late submission - 1 day.
// $G$ SFN-011 (-7) Camera turns to zero Axis point after it is passed + It doesn't move as required to the sides.
namespace C16_Ex04_Yakir_201049475_Omer_300471430
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager m_Graphics;

        public Game1()
        {
            m_Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            InputManager inputManager = new InputManager(this);
            Camera3DManager camera = new Camera3DManager(this);
            GameManager gameManager = new GameManager(this);
            Player player = new Player(this);
            TriangleListColorDreidel triangleListColorDreidel1 = new TriangleListColorDreidel(this);
            TriangleListColorDreidel triangleListColorDreidel2 = new TriangleListColorDreidel(this);
            TriangleStripTextureDreidel triangleStripTextureDreidel1 = new TriangleStripTextureDreidel(this);
            TriangleStripTextureDreidel triangleStripTextureDreidel2 = new TriangleStripTextureDreidel(this);
            TriangleListVertexIndexBufferTextureDreidel triangleListVertexIndexBufferTextureDreidel1 = new TriangleListVertexIndexBufferTextureDreidel(this);
            TriangleListVertexIndexBufferTextureDreidel triangleListVertexIndexBufferTextureDreidel2 = new TriangleListVertexIndexBufferTextureDreidel(this);

            this.Components.Add(player);
            this.Components.Add(triangleListColorDreidel1);
            this.Components.Add(triangleListColorDreidel2);
            this.Components.Add(triangleStripTextureDreidel1);
            this.Components.Add(triangleStripTextureDreidel2);
            this.Components.Add(triangleListVertexIndexBufferTextureDreidel1);
            this.Components.Add(triangleListVertexIndexBufferTextureDreidel2);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Draw(gameTime);
        }
    }
}
