
using System;
using Raylib_cs;
namespace vinterprojekt_Dingless


{
    class Program
    {
        static void Main(string[] args)
        {
            const int screenWidth = 800;
            const int screenHeight = 450;

            Raylib.InitWindow(screenWidth, screenHeight, "Spring!");

            // rita ut spelaren och motståndaren
            int playerX = 50;
            int playerY = 50;
            int playerSize = 30;

            int enemyX = 700;
            int enemyY = 400;
            int enemySize = 30;
            int enemySpeed = 1;

            bool gameOver = false;

            while (!Raylib.WindowShouldClose() && !gameOver)
            {
                // Kod för att röra på spelaren
                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    playerX -= 2;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    playerX += 2;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    playerY -= 2;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    playerY += 2;
                }

                // Rör motståndare mot spelare
                if (enemyX < playerX)
                {
                    enemyX += enemySpeed;
                }
                else
                {
                    enemyX -= enemySpeed;
                }
                if (enemyY < playerY)
                {
                    enemyY += enemySpeed;
                }
                else
                {
                    enemyY -= enemySpeed;
                }

                // Kollisioner mellan spelare och monster
                if (Math.Abs(playerX - enemyX) < playerSize + enemySize && Math.Abs(playerY - enemyY) < playerSize + enemySize)
                {
                    gameOver = false;
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                // Rita player
                Raylib.DrawRectangle(playerX - playerSize / 2, playerY - playerSize / 2, playerSize, playerSize, Color.BLUE);

                // Rita enemy
                Raylib.DrawCircle(enemyX, enemyY, enemySize, Color.RED);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}



