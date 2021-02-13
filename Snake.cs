﻿using System;
using System.Threading;

namespace Snake
{
    class Snake
    {
        int height = 20; // Board size 
        int width = 30;

        int[] x = new int[50];
        int[] y = new int[50];

        int fruitX;
        int fruitY;

        int parts = 3;

        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        char key = 'W';

        Random rnd = new Random();

        Snake()
        {
            x[0] = 10;
            y[0] = 10;
            Console.CursorVisible = false;
            fruitX = rnd.Next(2, (width - 2));
            fruitY = rnd.Next(2, (height - 2));
        }

        public void WriteBoard() //Board display
        {
            Console.Clear();
            for(int i = 1; i <= (width+2); i++)
            {
                Console.SetCursorPosition(i, 1);
                Console.Write("-");
            }
            
            for (int i = 1; i <= (width + 2); i++)
            {
                Console.SetCursorPosition(i, (height + 2));
                Console.Write("-");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition(1, i);
                Console.Write("|");
            }
            for (int i = 1; i <= (height + 1); i++)
            {
                Console.SetCursorPosition((width + 2), i);
                Console.Write("|");
            }

        }
        public void Input()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                key = keyInfo.KeyChar;
            }
        }
        public void WritePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("@");
        }

        public void Logic() //Game logic
        {
            if (x[0] == fruitX)
            {
                if (y[0] == fruitY)
                {
                    parts++;
                    fruitX = rnd.Next(2, (width -2));
                    fruitY = rnd.Next(2, (height - 2));
                }

            }
            for(int i = parts; i > 1; i--)
            {
                x[i - 1] = x[i - 2];
                y[i - 1] = y[i - 2];
            }
            switch(key)
            {
                case 'w':
                    y[0]--;
                    break;
                case 's':
                    y[0]++;
                    break;
                case 'd':
                    x[0]++;
                    break;
                case 'a':
                    x[0]--;
                    break;
            }
            for (int i = 0; i <= (parts -1); i++)
            {
                WritePoint(x[i], y[i]);
                WritePoint(fruitX, fruitY);
            }
            Thread.Sleep(100);
        }
        static void Main(string[] args)
        {
            Snake snake = new Snake();
            while (true)
            {
                snake.WriteBoard();
                snake.Input();
                snake.Logic();
            }
            Console.ReadKey();
        }
    }
}
