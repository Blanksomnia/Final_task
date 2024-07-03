using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Final_Task
{
    internal class BlackJack : CasinoGameBase
    {
        private static readonly Random _random = new Random();
        private List<string> Deck = new List<string>();
        private List<string> CardValues = new List<string> { "6", "7", "8", "9", "10", "Jack", "Queen", "Knight", "Ace" };
        private List<string> СardSuits = new List<string> { "Diamond", "Heart", "Сlubs", "Spades" };
        private List<string> Сards = new List<string>();
        private List<string> _list1 = new List<string>();
        private List<string> _list2 = new List<string>();
        public void Card()
        {
            for (int i = 0; i < СardSuits.Count; i++)
            {

                for (int j = 0; j < CardValues.Count; j++)
                {
                    Сards.Add(Convert.ToString(СardSuits[i] + "_" + CardValues[j]));
                }
            }
        }
        public void Shuffle()
        {
            List<int> possible = Enumerable.Range(0, 36).ToList();
            for (int j = 1; j < 37; j++)
            {
                int index = _random.Next(0, possible.Count);
                Deck.Add(Сards[possible[index]]);
                possible.RemoveAt(index);
            }

        }
        public  void ScorePoints(string result, string card)
        {
            int _point = 0;
            for (int i = 0; i < СardSuits.Count; i++)
            {
                if (card == $"{СardSuits[i]}_6")
                {
                    _point = _point + 6;
                }
                if (card == $"{СardSuits[i]}_7")
                {
                    _point = _point + 7;
                }
                if (card == $"{СardSuits[i]}_8")
                {
                    _point = _point + 8;
                }
                if (card == $"{СardSuits[i]}_9")
                {
                    _point = _point + 9;
                }
                if (card == $"{СardSuits[i]}_10")
                {
                    _point = _point + 10;
                }
                if (card == $"{СardSuits[i]}_Jack")
                {
                    _point = _point + 10;
                }
                if (card == $"{СardSuits[i]}_Queen")
                {
                    _point = _point + 10;
                }
                if (card == $"{СardSuits[i]}_Knight")
                {
                    _point = _point + 10;
                }
                if (card == $"{СardSuits[i]}_Ace")
                {
                    _point = _point + 11;
                }
            }
            if (result == "1")
            {
                result1player = result1player + _point;
            }
            if (result == "2")
            {
                result2player = result2player + _point;
            }
        }
        public int result1player = 0;
        public int result2player = 0;
        private int NextNumber()
        {
            return _random.Next(36);
        }
        public void inGame()
        {
            var object1 = new Profile();
            Card();
            Shuffle();
            _list1.Add(Deck[1]);
            Deck.Remove(Deck[1]);
            _list1.Add(Deck[1]);
            Deck.Remove(Deck[1]);
            _list2.Add(Deck[1]);
            Deck.Remove(Deck[1]);
            _list2.Add(Deck[1]);
            Deck.Remove(Deck[1]);
            Console.WriteLine("подбор карт - ");
            for (int i = 0; i < _list1.Count; i++)
            {
                Console.WriteLine(_list1[i]);
                ScorePoints("1", _list1[i]);
            }
            for (int i = 0;i < _list2.Count; i++)
            {
                Console.WriteLine(_list2[i]);
                ScorePoints("2", _list2[i]);
            }
            if (result1player == result2player || result1player < 21 && result2player < 21)
            {
                Console.WriteLine("подбор карт - ");
                _list1.Add(Deck[1]);
                Deck.Remove(Deck[1]);
                _list2.Add(Deck[1]);
                Deck.Remove(Deck[1]);
                result1player = 0; result2player = 0;
                for (int i = 0; i < _list1.Count; i++)
                {
                    ScorePoints("1", _list1[i]);
                }
                for (int i = 0; i < _list2.Count; i++)
                {
                    ScorePoints("2", _list2[i]);
                }
                Console.WriteLine(_list1.Last());
                Console.WriteLine(_list2.Last());
            }
            Console.WriteLine($"результат 1 игрока - {result1player}");
            Console.WriteLine($"результат 2 игрока - {result2player}");
            PlayGameBlackJack(result1player, result2player);
            new IGame().StartGame();

        }
    }
}
