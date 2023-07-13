public class Renderer
{
    private char[,] Grid = new char[9, 9];

    private char[,] Screen = new char[3, 3];
    private int ScreenLocationX = 0;
    private int ScreenLocationY = 0;


    public Renderer()
    {
        for (int i = 0; i < Grid.GetLength(0); i++)
        {
            for (int j = 0; j < Grid.GetLength(1); j++)
            {
                Grid[i, j] = '.';
            }
        }
    }

    public Renderer(char[,] grid)
    {
        Grid = grid;
    }

    private void LoadPixelsFromGridToScreen(int gridX, int gridY, int screenX, int screenY)
    {
        Thread.Sleep(TimeSpan.FromSeconds(1));
        Screen[screenX, screenY] = Grid[gridX, gridY];
    }

    private void MovePixelsAcrossScreen(int sourceX, int sourceY, int targetX, int targetY)
    {
        Thread.Sleep(TimeSpan.FromMilliseconds(1));
        Screen[targetX, targetY] = Screen[sourceX, sourceY];
    }

    public void SetPixelAtGrid(int gridX, int gridY, char pixel)
    {
        Grid[gridX, gridY] = pixel;
    }

    // TODO: Optimize this, currently always takes 9 seconds
    /// <summary>
    /// Loads 3 x 3 sub-grid to the screen, starting from the given coordinates. 
    /// Screen display is cyclic, so it will show the other side of the grid if it reached an edge.
    /// </summary>
    /// <returns>A deep copy of the screen</returns>
    public char[,] DisplayLocationAtScreen(int x, int y)
    {
        ScreenLocationX = x;
        ScreenLocationY = y;

        for (int i = 0; i < Screen.GetLength(0); i++)
        {
            for (int j = 0; j < Screen.GetLength(1); j++)
            {
                var gridX = (ScreenLocationX + i) % Grid.GetLength(0);
                var gridY = (ScreenLocationY + j) % Grid.GetLength(1);
                LoadPixelsFromGridToScreen(gridX, gridY, i, j);
            }
        }

        var screenClone = new char[3, 3];
        Array.Copy(Screen, screenClone, 9);
        return screenClone;
    }
}
