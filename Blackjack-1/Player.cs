using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack_1
{
    internal class Player
    {
        public int[] cards = new int[11];
        public int cardCount = 0;
        public int score = 0;

        public void AddCard(int card)
        {
            this.cards[cardCount] = card;
            cardCount++;
            CalculateScore();
        }

        private void CalculateScore()
        {
            int total = 0;
            int aceCount = 0;

            for (int i = 0; i < cardCount; i++)
            {
                int number = cards[i] % 13;

                if (number == 0)
                {
                    aceCount++;
                    total += 11;
                }
                else if (number >= 10)
                {
                    total += 10;
                }
                else
                {
                    total += number + 1;
                }

                while (total > 21 && aceCount > 0)
                {
                    total -= 10;
                    aceCount--;
                }

                score = total;
            }

            
        }

    }
}
