internal class Program
{
    static int[] stackX = new int[2500];
    static int[] stackY = new int[2500];
    static int stackTop = -1;

    static void Main(string[] args)
    {
        int[,] array = new int[50, 50];
        Random rnd = new Random();

        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                array[i, j] = rnd.Next(2);
            }
        }
        
        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                Console.Write(array[i,j]+ " ");
            }
            Console.WriteLine();
        }

        bool[,] visited = new bool[50,50];
        int group = 0;

        for (int i = 0; i < 50; i++)
        {
            for (int j = 0; j < 50; j++)
            {
                if (array[i,j]==1 && !visited[i,j])
                {
                    Search(array, visited, i, j);
                    group++;
                }
            }
        }

        Console.WriteLine(group);
    }

    static void Search(int[,] array, bool[,] visited, int startx, int starty)
    {
        Push(startx,starty);
        while (!IsStackEmpty())
        {
            int x = PopX();
            int y = PopY();
            if (x < 0 || x >= 50 || y < 0 || y >= 50 || array[x, y] == 0 || visited[x, y])
            {
                continue;
            }

            visited[x, y] = true;
            
            Push(x - 1 , y - 1); // sol üst
            Push(x - 1 , y ); // üst
            Push(x - 1, y + 1); // sağ üst
            Push(x, y - 1 ); // solu
            Push(x, y + 1); // sağı
            Push(x + 1 ,y - 1); // sol alt
            Push(x + 1 ,y); // alt
            Push(x + 1 ,y + 1); // sağ alt
        }
    }

    static void Push(int x, int y)
    {
        stackTop++;
        stackX[stackTop] = x;
        stackY[stackTop] = y;
    }

    static int PopX()
    {
        return stackX[stackTop];
    }

    static int PopY()
    {
        int value =stackY[stackTop];
        stackTop--;
        return value;
    }

    static bool IsStackEmpty()
    {
        return stackTop == -1;
    }
}