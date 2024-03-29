﻿// See https://aka.ms/new-console-template for more information
using xadrez_console;
using xadrez_console.tabuleiro;
using xadrez_console.Xadrex;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                PartidaDeXadrex partida = new PartidaDeXadrex();

                while (!partida.terminada)
                {
                    try
                    {
                        {
                            Console.SetBufferSize(1,1);
                            Console.Clear();
                            Tela.imprimirPartida(partida);
                            Console.WriteLine();
                            Console.Write("Origem:  ");
                            Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                            partida.validarPosicaoDeOrigem(origem);
                            bool[,] posicoesPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                            Console.Clear();
                            Tela.imprimirTabuleiro(partida.tab, posicoesPossiveis);
                            Console.WriteLine();
                            Console.Write("Destino: ");
                            Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                            partida.validarPosicaoDestino(origem, destino);
                            partida.realizaJogada(origem, destino);
                        }
                    }
                    catch (TabuleiroException e)
                    {

                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.imprimirPartida(partida);
            }
            catch (TabuleiroException e)
            {

                Console.WriteLine(e.Message);
            }


            Console.ReadLine();
        }
    }
}