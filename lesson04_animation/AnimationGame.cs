using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace lesson04_animation;

public class AnimationGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private CelAnimationSequence _personWalking;
    private CelAnimationPlayer _animationPlayer;

    public AnimationGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D spriteSheet = Content.Load<Texture2D>("Walking");
        //pass the constructor the spritesheet, the width of each cel, 
        //and the amount of time to display each cell
        _personWalking = new CelAnimationSequence(spriteSheet, 81, 1 / 8f);
        
        _animationPlayer = new CelAnimationPlayer();
        //start animating!
        _animationPlayer.Play(_personWalking);

    }

    protected override void Update(GameTime gameTime)
    {
        _animationPlayer.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _animationPlayer.Draw(_spriteBatch, Vector2.Zero, SpriteEffects.None);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
