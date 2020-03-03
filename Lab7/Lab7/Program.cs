using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Frame> frames = new List<Frame>
            {
                new Frame(1, "Glasses 1"),
                new Frame(2, "Glasses 2"),
                new Frame(3, "Glasses 3"),
                new Frame(4, "Glasses 4"),
                new Frame(5, "Glasses 5"),
                new Frame(6, "Glasses 6"),
                new Frame(7, "Glasses 7")
            };

            frames[0].TurnOnFeatures(EFeatures.Men | EFeatures.Women | EFeatures.Rectangle | EFeatures.Blue);
            frames[1].TurnOnFeatures(EFeatures.Women | EFeatures.Black);
            frames[2].TurnOnFeatures(EFeatures.Aviator | EFeatures.Red | EFeatures.Black);
            frames[3].TurnOnFeatures(EFeatures.Round);
            frames[4].TurnOnFeatures(EFeatures.Round | EFeatures.Red);
            frames[5].TurnOnFeatures(EFeatures.Men | EFeatures.Blue | EFeatures.Black);
            frames[6].TurnOnFeatures(EFeatures.Black);

            List<int> sortKeys = FilterEngine.GetSortKeys(frames, new List<EFeatures> { EFeatures.Rectangle, EFeatures.Black, EFeatures.Women });
            List<Tuple<int, Frame>> tuples = new List<Tuple<int, Frame>>();

            for (int i = 0; i < sortKeys.Count; i++)
            {
                tuples.Add(new Tuple<int, Frame>(sortKeys[i], frames[i]));
            }

            tuples.Sort((t1, t2) =>
            {
                Console.WriteLine($"{t2.Item1} - {t1.Item1}: {t2.Item1 - t1.Item1}");
                return t2.Item1 - t1.Item1;
            });

            List<Frame> sortedFrames = tuples.Select(t => t.Item2).ToList(); // sortedFrames: [ Glasses 1, Glasses 2, (Glasses 3 또는 Glasses 6 또는 Glasses 7), (Glasses 3 또는 Glasses 6 또는 Glasses 7), (Glasses 3 또는 Glasses 6 또는 Glasses 7), (Glasses 4 또는 Glasses 5), (Glasses 4 또는 Glasses 5) ]
            
            sortedFrames.ForEach( p => Console.WriteLine($"Result: {p.Name} "));
        }
    }
}
