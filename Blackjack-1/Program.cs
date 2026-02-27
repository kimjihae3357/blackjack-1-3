using System;

namespace Blackjack_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 블랙잭 게임 ===");

            int[] deck = new int[52];
            int deckIndex = 0;
            Random rand = new Random();

            Shuffle(deck);

            bool gamePlayingFlag = true;
            
            while (gamePlayingFlag)
            {
                CheckAndShuffleCard(deck, deckIndex);

                Player player = new Player();
                Player dealer = new Player();

                player.AddCard(deck[deckIndex++]);

                CheckAndShuffleCard(deck, deckIndex);
                dealer.AddCard(deck[deckIndex++]);

                CheckAndShuffleCard(deck, deckIndex);
                player.AddCard(deck[deckIndex++]);

                CheckAndShuffleCard(deck, deckIndex);
                dealer.AddCard(deck[deckIndex++]);

                Console.WriteLine("=== 초기 패 ===");
                Console.Write($"딜러의 패: [??] ");
                PrintCard(dealer.cards[1]);
                Console.WriteLine();
                Console.WriteLine("딜러 점수: ?\n");
                Console.Write("플레이어의 패: ");

                for (int i = 0; i < player.cardCount; i++)
                {
                    PrintCard(player.cards[i]);
                }

                Console.WriteLine($"\n플레이어 점수: {player.score}");

                while (player.score < 21)
                {
                    Console.Write("H(Hit) 또는 S(Stand)를 선택하세요: ");
                    
                    string input = Console.ReadLine().ToUpper();

                    if (input == "H")
                    {
                        Console.WriteLine("\n\n플레이어가 Hit를 선택했습니다.");
                        CheckAndShuffleCard(deck, deckIndex);
                        int card = deck[deckIndex++];
                        player.AddCard(card);

                        Console.Write($"플레이어가 카드를 받았습니다.: ");
                        PrintCard(card);
                        Console.Write("\n플레이어의 패: ");

                        for (int i = 0; i < player.cardCount;i++)
                        {
                            PrintCard(player.cards[i]);
                        }

                        Console.WriteLine();
                        Console.WriteLine($"플레이어 점수: {player.score}");

                    }
                    else if (input == "S")
                    {
                        Console.WriteLine("\n\n플레이어가 Stand를 선택했습니다.");
                        break;
                    }
                }

                if (player.score > 21)
                {
                    Console.WriteLine("플레이어 Bust 딜러 승리!");
                }
                else
                {
                    Console.Write("딜러의 숨겨진 카드: ");
                    PrintCard(dealer.cards[0]);
                    Console.WriteLine();
                    Console.Write("딜러의 패: ");
                    for (int i = 0; i < dealer.cardCount; i++)
                    {
                        PrintCard(dealer.cards[i]);
                    }
                    Console.WriteLine($"\n딜러 점수: {dealer.score}");

                    while (dealer.score < 17)
                    {
                        CheckAndShuffleCard(deck, deckIndex);
                        int card = deck[deckIndex++];
                        dealer.AddCard(card);

                        Console.Write("\n딜러가 카드를 받습니다: ");
                        PrintCard(card);
                        Console.Write("\n딜러의 패: ");
                        for (int i = 0; i < dealer.cardCount; i++)
                        {
                            PrintCard(dealer.cards[i]);
                        }
                        Console.WriteLine($"\n딜러 점수: {dealer.score}");   
                    }
                }
                Console.WriteLine("\n\n\n\n=== 게임 결과 ===");
                Console.WriteLine($"플레이어: {player.score}");
                Console.WriteLine($"딜러: {dealer.score}");

                if (dealer.score < player.score || dealer.score > 21)
                {
                    if (dealer.score > 21)
                    {
                        Console.WriteLine("\n딜러 Bust, 플레이어 승리!");
                    }
                    else
                    {
                        Console.WriteLine("\n플레이어 승리!");
                    }
                    
                }
                else if (dealer.score > player.score)
                {
                    Console.WriteLine("\n딜러 승리!");
                }
                else
                {
                    Console.WriteLine("\n무승부!");
                }
                Console.Write("\n새 게임을 하시겠습니까? (Y/N): ");
                string finishInput = Console.ReadLine().ToUpper();

                if (finishInput == "N")
                {
                    Console.WriteLine("게임을 종료합니다.");
                    gamePlayingFlag = false;
                }
                else
                {
                    Console.Clear();
                }
            }
        }
        static void Shuffle(int[] deck)
        {
            Random rand = new Random();
            Console.WriteLine("\n\n카드를 섞는 중...");

            for (int i = 0; i < deck.Length; i++)
            {
                deck[i] = i;
            }

            for (int i = 0; i < deck.Length; i++)
            {
                int j = rand.Next(deck.Length);
                int temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }
        }

        static void PrintCard(int card)
        {
            string[] symbols = { "♠", "♥", "♣", "◆" };
            string[] numbers = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
            int symbol = card / 13;
            int number = card % 13;

            Console.Write($"[{symbols[symbol]}{numbers[number]}] ");
        }

        static void CheckAndShuffleCard(int[] deck, int deckIndex)
        {
            if (deckIndex >= deck.Length)
            {
                Shuffle(deck);

                deckIndex = 0;
            }
        }
    }
}