
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lesson03_draw_sprite_exercise_solution;

public class BouncingSprite : Game
{
    private const int _WindowWidth = 640;
    private const int _WindowHeight = 320;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _backgroundImage;
    private Texture2D _beetleImage;

    private float _x = 0, _velocityShipX = 5;
    private float _y = 0, _velocityShipY = 5;
    private float _shipRotation;

    public BouncingSprite()
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
        
        _x += _velocityShipX;
        if(_x <= 0 || _x + _beetleImage.Width >= _WindowWidth)
        {
            _velocityShipX *= -1;
        }

        _y += _velocityShipY;
        if(_y <= 0 || _y + _beetleImage.Height >= _WindowHeight)
        {
            _velocityShipY *= -1;
        }
        _shipRotation += 0.1f;
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        //Watch out! Order matters! More recenty draw calls draw over older ones.
        _spriteBatch.Draw(_backgroundImage, Vector2.Zero, Color.White);
        //_spriteBatch.Draw(_beetleImage, new Vector2(_x, _y), Color.White);
        // _spriteBatch.Draw(
        //     _beetleImage,
        //     new Vector2(_x, _y),
        //     null,                  // Source rectangle (null for full texture)
        //     Color.White,           // Tint color
        //     _shipRotation,        // Rotation angle in radians
        //     new Vector2(_beetleImage.Width / 2, _beetleImage.Height / 2),               // Origin point
        //     1.0f,                  // Scale
        //     SpriteEffects.None,    // No sprite effects
        //     0f                     // Layer depth
        // );
        _spriteBatch.Draw(_beetleImage, new Vector2(_x + (_beetleImage.Bounds.Width / 2), 
                _y + (_beetleImage.Bounds.Height / 2)), null, Color.White, _shipRotation, 
                new Vector2(_beetleImage.Bounds.Width / 2, _beetleImage.Bounds.Height / 2), 1, SpriteEffects.None, 0);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
