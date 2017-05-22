using System;

namespace game
{
    public class Game
    {
        private string[,] mapa { get; set; }
        private string jogador { get; set; }
        private int posLinha { get; set; }
        private int posColuna { get; set; }

        public Game()
        {
            mapa = new string[8, 16]
            {
                {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"},
                {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", " ", "#", "#", "#", "#"},
                {"#", " ", " ", " ", "#", "#", " ", "#", "#", "#", "#", " ", " ", " ", "#", "#"},
                {"#", " ", "#", " ", "#", "#", " ", "#", "#", "#", "#", " ", "#", " ", "#", "#"},
                {"#", " ", "#", " ", "#", "#", " ", " ", " ", " ", "#", " ", "#", " ", " ", "F"},
                {"#", " ", "#", " ", "#", "#", " ", "#", "#", " ", "#", " ", "#", " ", " ", "#"},
                {"#", " ", "#", " ", " ", " ", " ", "#", "#", " ", " ", " ", "#", "#", "#", "#"},
                {"#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#"}
            };

            jogador = "@";

            posLinha = 6;
            posColuna = 1;

            mapa[posLinha, posColuna] = jogador;
        }

        public void run()
        {
            var gameFinish = false;
            var largura = mapa.GetLength(0);
            var altura = mapa.GetLength(1);

            while (!gameFinish)
            {
                Console.Clear();

                for (int linha = 0; linha < largura; linha++)
                {
                    for (int coluna = 0; coluna < altura; coluna++)
                    {
                        Console.Write(mapa[linha, coluna]);
                    }
                    Console.WriteLine();
                }


                var ev = Console.ReadKey(true);

                //condicionais
                if (ev.Key == ConsoleKey.W || ev.Key == ConsoleKey.UpArrow)
                {
                    if (mapa[posLinha - 1, posColuna] != "#")
                    {
                        mapa[posLinha, posColuna] = " ";
                        posLinha--;
                    }
                }
                else if (ev.Key == ConsoleKey.S || ev.Key == ConsoleKey.DownArrow)
                {
                    if (mapa[posLinha + 1, posColuna] != "#")
                    {
                        mapa[posLinha, posColuna] = " ";
                        posLinha++;
                    }
                }
                else if(ev.Key == ConsoleKey.A || ev.Key == ConsoleKey.LeftArrow){
                    if (mapa[posLinha, posColuna - 1] != "#")
                    {
                        mapa[posLinha, posColuna] = " ";
                        posColuna--;
                    }
                }else if (ev.Key == ConsoleKey.D || ev.Key == ConsoleKey.RightArrow)
                {
                    if (mapa[posLinha, posColuna + 1] != "#")
                    {
                        mapa[posLinha, posColuna] = " ";
                        posColuna++;
                    }
                }

                if (mapa[posLinha, posColuna] == "F")
                {
                    gameFinish = true;
                    Console.WriteLine("Parabéns !!!!!");
                }

                mapa[posLinha, posColuna] = jogador;

            }

        }
    }
}