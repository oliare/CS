using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_collections_
{
    class Game
    {
        public List<Player> players = new List<Player>();
        public List<Card> deck = new List<Card>();
        public Game(params string[] person)
        {
            foreach (var p in person)
            {
                players.Add(new Player(p));
            }
            DeckCreation();
        }
        protected IEnumerable<Card> GenerateCards()
        {
            List<Card> cards = new List<Card>();

            string[] suits = { "spades", "clubs", "hearts", "diamonds" };
            string[] ranks = { "6", "7", "8", "9", "10", "jack", "queen", "king", "ace" };

            foreach (var s in suits)
            {
                for (var i = 0; i < ranks.Length; i++)
                {
                    Card card = new Card(s, ranks[i]);
                    cards.Add(card);
                }
            }
            return cards;
        }
        public void DeckCreation()
        {
            foreach (var item in GenerateCards())
            {
                deck.Add(item);
            }
        }
        public void ShufflingCards()
        {
            var rnd = new Random();
            deck = deck.OrderBy(card => rnd.Next()).ToList();
        }
        public void HandingOutCards()
        {
            ShufflingCards();
            int div = 36 / players.Count;

            for (int i = 0; i < div; i++)
            {
                foreach (var player in players)
                {
                    if (deck.Any())
                    {
                        Card card = deck.Last();
                        player.GetCard(card);
                        deck.RemoveAt(deck.Count - 1);
                    }
                }
            }
        }
        public void Play()
        {
            List<Card> list = players.Select(pl => pl.CheckCard()).ToList();

            Console.WriteLine(string.Join("\t\t", players.Select
                (pl => $"{pl.Name} ({pl.cards.Count} cards)")));

            list.Sort();

            Card max = list[list.Count - 1];
            Console.Write($"\n\t{max}");

            var winner = players.FirstOrDefault(pl => pl.bottomCard == max);
            if (winner != null)
            {
                Console.WriteLine($"\n\n\t{winner.Name} is leading");
                winner.cards.AddRange(list);
            }
            list.Clear();
            Console.WriteLine("\n");
        }
        public void StartGame()
        {
            Console.WriteLine(String.Join("", players.Select
                (x => $"\t#{x.Name,-3}  --> {x.cards.Count,-22}\n")));
            while (GameOver())
                Play();
            Console.WriteLine("\n  *************** GAME OVER ***************\n");
            IsWin();
        }
        public bool GameOver()
        {
            return players.FindAll(s => s.cards.Count > 0).Count >= 2;
        }
        public void IsWin()
        {
            foreach (var player in players)
            {
                if (player.cards.Count == 36)
                {
                    Console.WriteLine(player.Name + " is the WINNER!!\n");
                    return;
                }
            }
        }
    }

    class Player
    {
        public List<Card> cards = new List<Card>();
        public string Name { get; set; }
        public Player(string name)
        {
            Name = name;
        }
        public Card bottomCard { get; set; }
        public Card CheckCard()
        {
            if (cards.Count > 0)
            {
                bottomCard = cards.First();
                cards.RemoveAt(0);
                return bottomCard;
            }
            return null;
        }
        public void GetCard(Card card)
        {
            cards.Add(card);
        }
        public void GetCards(params Card[] arr)
        {
            cards.AddRange(arr);
        }
    }
    class Card : IComparable<Card>
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }
        public override string ToString()
        {
            return $"{Suit} : {Rank}";
        }
        public int CompareTo(Card other)
        {
            return Rank.CompareTo(other.Rank);
        }
    }
}