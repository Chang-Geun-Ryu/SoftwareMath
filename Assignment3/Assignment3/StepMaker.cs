using System.Collections.Generic;
using System;

namespace Assignment3 
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            List<int> stepList = new List<int>();

            for(int i = 0; i < steps.Length - 1; i++)
            {
                int nAbs = Math.Abs(steps[i + 1] - steps[i]);

                if(nAbs > 10)
                {
                    List<int> tempList = new List<int>{steps[i], steps[i + 1]};

                    var temp = (makeStepTail(tempList, noise, 0));
                    stepList.AddRange(temp);
                }
                else 
                {
                    stepList.Add(steps[i]);
                }
            }

            stepList.Add(steps[steps.Length-1]);
            // return new List<int> (makeStepTail(steps, noise, 0));
            return stepList;
        }

        private static List<int> makeStepTail(List<int> steps, INoise noise, int acc)
        {

            List<int> stepList = getLinearValue(steps[0], steps[1], noise, acc);
            steps.InsertRange(1, stepList);
            
            if (checkSteps(steps.ToArray()))
            {
                steps.RemoveAt(steps.Count-1);
                return steps;
            }

            acc += 1;
            List<int> result = new List<int>();
            for(int i = 0; i < steps.Count - 1; i++)
            {
                int nAbs = Math.Abs(steps[i + 1] - steps[i]);
                if(nAbs > 10)
                {
                    var temp = makeStepTail(new List<int> {steps[i], steps[i + 1]}, noise, acc);
                    // temp.RemoveAt(temp.Count-1);
                    result.AddRange(temp);
                }
                else 
                {
                    
                    result.Add(steps[i]);
                }
            }
            
            return result;
        }

        private static List<int> getLinearValue(int nStart, int nEnd, INoise noise, int acc)
        {
            List<int> linearValues = new List<int> { };

            for(int i = 1; i < 5; i++ )
            {
                // decimal start = nStart;
                // decimal end = nEnd;
                // decimal noiseResult = noise.GetNext(acc);
                // decimal value = i;
                // linearValues.Add((int)(noiseResult + start + (end - start) * (1.0m * value) / 5.0m));
                int temp = noise.GetNext(acc) +  (int)((decimal)nStart + (decimal)((nEnd - nStart) * i) / 5.0m);
                linearValues.Add(temp);
            }

            return linearValues;
        }

        private static bool checkSteps(int[] steps) 
        {
            bool bResult = true;

            for (int i = 0; i < steps.Length - 1; i++)
            {
                int nAbs = Math.Abs(steps[i + 1] - steps[i]);
                if (nAbs > 10) 
                {
                    bResult = false;
                }
            }

            return bResult;
        }
    }
}