using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyGame
{
    public static class HpBarBase
    {
        public static void Draw(SpriteBatch spriteBatch, Vector2 point, int size, double percent)
        {
            //TODO:Change later
            if (percent > 1)
            {
                percent = 1;
            }
            int col = 10 * size;
            int row = size;
            Texture2D rect = new Texture2D(TexturePack.graphicsDevice, col, row);

            Color[,] data = new Color[col, row];

            for (int i = 0; i < size * percent * 10; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    data[i, j] = Color.Green;
                }
            }
            for (int i = (int)(size * (percent * 10)); i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    data[i, j] = Color.Red;
                }
            }
            Color[] dataToDraw = new Color[size * size * 10];
            int index = 0;
            for (int j = 0; j < row; j++)
            {
                for (int i = 0; i < col; i++)
                {
                    dataToDraw[index++] = data[i, j];
                }
            }

            rect.SetData(dataToDraw);
            spriteBatch.Begin();
            spriteBatch.Draw(rect, point, Color.White);
            spriteBatch.End();
            rect.Dispose();
        }
    }
}
