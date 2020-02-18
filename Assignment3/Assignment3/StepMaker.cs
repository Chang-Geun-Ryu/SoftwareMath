using System.Collections.Generic;
using System;

namespace Assignment3 
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            return MakeStepTail(steps, noise, 0);
        }

        private static List<int> MakeStepTail(int[] steps, INoise noise, int acc)
        {
            List<int> stepList = new List<int>();

            for (int i = 0; i < steps.Length - 1; i++) 
            {
                if (steps[i + 1] - steps[i] > 10)
                {
                    stepList.Add(steps[i]);

                    for (int j = 1; j < 5; j++) 
                    {
                        int linearStep = (int)((double)j / 5.0 * (double)(steps[i + 1] - steps[i])) + steps[i];
                        linearStep += (int)noise.GetNext(acc);
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
                return MakeStepTail(stepList.ToArray(), noise, acc);
            }
        }

        private static bool checkSteps(int[] steps) 
        {
            for (int i = 0; i < steps.Length - 1; i++)
            {
               if (Math.Abs(steps[i + 1] - steps[i]) > 10) 
               {
                   return false;
               }
            }

            return true;
        }
    }
}