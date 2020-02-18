using System.Collections.Generic;
using System;

namespace Assignment3 
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            return makeStepTail(steps, noise, 0);
        }

        private static List<int> makeStepTail(int[] steps, INoise noise, int acc)
        {
            List<int> stepList = new List<int>();

            for (int i = 0; i < steps.Length - 1; i++) 
            {
                int nAbs = Math.Abs(steps[i + 1] - steps[i]);
                if (nAbs > 10) 
                {
                    stepList.Add(steps[i]);

                    for (int j = 1; j < 5; j++) 
                    {
                        int linearStep = (int)((double)j / 5.0 * (double)(steps[i + 1] - steps[i]) + (double)steps[i] + (double)noise.GetNext(acc));
                        // linearStep += (int);
                        stepList.Add(linearStep);
                    }
                }
                else 
                {
                    stepList.Add(steps[i]);
                }
            }

            stepList.Add(steps[steps.Length - 1]);
            
            if (StepMaker.checkSteps(stepList.ToArray()))
            {
                return stepList;
            }
            else 
            {
                acc += 1;
                return makeStepTail(stepList.ToArray(), noise, acc);
            }
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