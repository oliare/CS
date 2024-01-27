using System;
using System.Collections.Generic;
using System.Linq;

namespace hw_collections_
{
    class Game
    {
        public List<Player> players = new List<Player>();
        public List<Card> deck = new List<Card>(36);

        public Game(params Player[] players)
        {
            this.players.AddRange(players);
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
            int amount = 36 / players.Count;
            for (int i = 0; i < amount; i++)
            {
                for (int j = 0; j < players.Count; j++)
                {
                    players[j].GetCard(deck[deck.Count - 1]);
                    deck.RemoveAt(deck.Count - 1);
                }
            }
        }
        public void Play()
        {
            List<Card> list = players.Select(pl => pl.ShowCard()).ToList();

            Console.WriteLine(string.Join("\t\t", players.Select
                (pl => $"{pl.Name} ({pl.cards.Count} cards)")));

            list.Sort();
            Card max = list[list.Count - 1];
            Console.Write($"\n\t{max}");

            var winner = players.FirstOrDefault(pl => pl.Last == max);
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
            Console.WriteLine("\n\n\t*************** GAME OVER ***************\n");
            IsWin();
        }
        public bool GameOver()
        {
            return players.FindAll(s => s.cards.Count > 0).Count >= 2;
        }
        public void IsWin()
        {
            foreach (var player in players)
                if (player.cards.Count == 36)
                {
                    Console.WriteLine(player.Name + " is the WINNER!!\n");
                    return;
                }
        }
    }

    class Player
    {
        public List<Card> cards = new List<Card>();
        public string Name { get; set; }
        public Card Last { get; set; }
        public Player(string name)
        {
            Name = name;
        }
        public void GetCard(Card card)
        {
            cards.Add(card);
        }
        public void GetCards(params Card[] cards)
        {
            this.cards.AddRange(cards);
        }
        public Card ShowCard()
        {
            Card card = cards[0];
            Last = card;
            cards.RemoveAt(0);
            return card;
        }
    }
    class Card : IComparable<Card>
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public Card(string suit, string type)
        {
            Suit = suit;
            Rank = type;
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