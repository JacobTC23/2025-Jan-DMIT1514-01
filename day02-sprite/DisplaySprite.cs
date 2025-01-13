using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace day02_sprite;

public class DisplaySprite : Game
{
    private const int _WindowWidth = 640;
    private const int _WindowHeight = 320;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _backgroundImage;
    private Texture2D _beetleImage;

    private float _x = 0;
    private float _y = 0;

    public DisplaySprite()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = _WindowWidth;
        _graphics.PreferredBackBufferHeight = _WindowHeight;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _backgroundImage = Content.Load<Texture2D>("Station");
        _beetleImage = Content.Load<Texture2D>("Beetle");
    }

    protected override void Update(GameTime gameTime)
    {
        _x = _x + 1; //or _x++ or _x += 1
        _y = _y + 1;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_backgroundImage, Vector2.Zero, Color.White);

        _spriteBatch.Draw(_beetleImage, new Vector2(_x, _y), Color.White);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
