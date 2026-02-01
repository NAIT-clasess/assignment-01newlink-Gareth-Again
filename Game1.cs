using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_01;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D staticSprite;
    Texture2D background;
    Texture2D[] animatedSprites1;
    Texture2D spritesheet;

    SpriteFont font;

    int counter;
    int activeFrame;
    int toadMove;
    int counter2;
    int activeFrame2;
    int numFrames;
    int toadetteMove;

    public Game1()
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

        // TODO: use this.Content to load your game content here
        staticSprite = Content.Load<Texture2D>("Emil");
        background = Content.Load<Texture2D>("Replicant");

        animatedSprites1 = new Texture2D[2];
        animatedSprites1[0] = Content.Load<Texture2D>("ToadRun1");
        animatedSprites1[1] = Content.Load<Texture2D>("ToadRun2");

        spritesheet = Content.Load<Texture2D>("ToadetteSpinV2");
        activeFrame2 = 0;
        numFrames = 4;
        counter2 = 0;

        font = Content.Load<SpriteFont>("SansFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        counter++;
        if (counter >14)
        {
            counter = 0;
            activeFrame++;

            if (activeFrame > animatedSprites1.Length - 1)
            {
                activeFrame = 0;
            }

        }
        toadMove++;

        counter2++;
        if (counter2 > 14)
        {
            counter2 = 0;
            activeFrame2++;

            if (activeFrame2 == numFrames)
            {
                activeFrame2 = 0;
            }
        }
        if (Keyboard.GetState().IsKeyDown(Keys.Space))
        {
            toadetteMove++;
        }
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();

        _spriteBatch.Draw(background, new Rectangle(0, 0, 1000, 562), Color.White);
        _spriteBatch.Draw(staticSprite, new Vector2(100, 100), Color.White);

        _spriteBatch.Draw(animatedSprites1[activeFrame], new Rectangle (toadMove + 400, 100, 100, 105), Color.White);

        _spriteBatch.Draw(spritesheet, 
        new Rectangle (550, 100-toadetteMove, 160, 120), 
        new Rectangle (activeFrame2 * 32, 0, 32, 24),
        Color.White);

        _spriteBatch.DrawString(font, "Press Space to make Toadette go up", Vector2.Zero, Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
