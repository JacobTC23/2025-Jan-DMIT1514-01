using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace day01_intro;

public class MyFirstGame : Game
{
    //represents the screen of the device
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private SpriteFont _arialFont;
    private string _message = "Hello World!";
    public MyFirstGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        //"SystemArialFont" must match the file name
        _arialFont = Content.Load<SpriteFont>("SystemArialFont");
    }

    protected override void Update(GameTime gameTime)
    {
        //game logic goes here
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        //draw logic and commands go here
        GraphicsDevice.Clear(Color.DarkKhaki);
        
        _spriteBatch.Begin();
        _spriteBatch.DrawString(_arialFont, _message, Vector2.Zero, Color.White);
        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
