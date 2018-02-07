using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularProject.Services.Poker
{
    public class PokerService : BaseService
    {
        public enum GameMode
        {
            BigTwo = 1
        }
        public class BigTwoViewModel
        {
            public List<string> GamerOne { get; set; }
            public List<string> GamerTwo { get; set; }
            public List<string> GamerThree { get; set; }
            public List<string> GamerFour { get; set; }
        }

        public List<string> Pokers { get; set; }
        public PokerService()
        {
            for (int i = 1; i < 53; i++)
                Pokers.Add(i.ToString());
        }
        public List<string> Wash(List<string> pokers)
        {
            List<string> results = new List<string>();
            Random random = new Random();

            do
            {
                var tmp = random.Next(1, 53).ToString();
                if (!results.Contains(tmp))
                {
                    pokers.Remove(tmp);
                    results.Add(tmp);
                }
            } while (pokers.Count > 0);

            return results;
        }
        public BigTwoViewModel Send(List<string> pokers, GameMode mode)
        {
            BigTwoViewModel result = new BigTwoViewModel();

            return result;
        }
    }
}