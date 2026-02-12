using System;

namespace Task4
{
    public class Program
    {
        public static void Execute()
        {
            float budget = 183.23f;
            float bagVolume = 64.11f;
            int people = 7;
            int Npresents = 12;

            float [] presentVolume = new float[Npresents];
            float [] presentPrice = new float[Npresents];
                
            presentVolume[0] = 4.53f;
            presentPrice[0] = 12.23f;
            presentVolume[1] = 9.11f;
            presentPrice[1] = 45.03f;
            presentVolume[2] = 4.53f;
            presentPrice[2] = 12.23f;
            presentVolume[3] = 6.00f;
            presentPrice[3] = 32.93f;
            presentVolume[4] = 1.04f;
            presentPrice[4] = 6.99f;
            presentVolume[5] = 0.87f;
            presentPrice[5] = 0.46f;
            presentVolume[6] = 2.57f;
            presentPrice[6] = 7.34f;
            presentVolume[7] = 19.45f;
            presentPrice[7] = 65.98f;
            presentVolume[8] = 65.59f;
            presentPrice[8] = 152.13f;
            presentVolume[9] = 14.14f;
            presentPrice[9] = 7.23f;
            presentVolume[10] = 16.66f;
            presentPrice[10] = 10.00f;
            presentVolume[11] = 13.53f;
            presentPrice[11] = 25.25f;

            float result = PresentList
            (
                budget, 
                bagVolume, 
                people, 
                Npresents, 
                presentVolume, 
                presentPrice
            );

            Console.WriteLine(result);
        }

        public static float PresentList
        (
            float budget, 
            float bagVolume, 
            int people, 
            int Npresents, 
            float [] presentVolume, 
            float [] presentPrice
        )
        {
            return Solve(
                0,
                0,
                0f,
                0f,

                budget,
                bagVolume,
                people,
                Npresents,
                presentVolume,
                presentPrice
            );
        }

        private static float Solve
        (
            int index,
            int count,
            float usedVolume,
            float usedMoney,

            float budget,
            float bagVolume,
            int people,
            int Npresents,
            float[] presentVolume,
            float[] presentPrice
        )
        {
            // invalid branches
            if (usedVolume > bagVolume || usedMoney > budget)
                return float.NegativeInfinity;

            // base case
            if (index == Npresents)
            {
                // must give equal number of presents to each person
                if (count % people == 0)
                    return usedMoney;

                return float.NegativeInfinity;
            }

            // option 1: skip current present
            float skip = Solve(
                index + 1,
                count,
                usedVolume,
                usedMoney,

                budget,
                bagVolume,
                people,
                Npresents,
                presentVolume,
                presentPrice
            );

            // option 2: take current present
            float take = Solve(
                index + 1,
                count + 1,
                usedVolume + presentVolume[index],
                usedMoney + presentPrice[index],

                budget,
                bagVolume,
                people,
                Npresents,
                presentVolume,
                presentPrice
            );

            return Math.Max(skip, take);
        }
    }
}