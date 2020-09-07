using System;

namespace Lab7
{
    public class Frame 
    {
        private EFeatureFlags mFeatures;
        public EFeatureFlags Features
        {
            get { return mFeatures; }
        }

        public uint ID
        {
            get;
        }

        public string Name
        {
            get;
        }

        public Frame(uint id, string name)
        {
            this.mFeatures = EFeatureFlags.Default;
            this.ID = id;
            this.Name = name;
        }
        
        public void ToggleFeatures(EFeatureFlags feature) 
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            this.mFeatures ^= feature;
            Console.WriteLine($"Result: {Features} ");
        }

        public void TurnOnFeatures(EFeatureFlags feature) 
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            this.mFeatures |= feature;
            Console.WriteLine($"Result: {Features} ");
        }

        public void TurnOffFeatures(EFeatureFlags feature)
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            this.mFeatures &= ~feature;
            Console.WriteLine($"Result: {Features} ");
        }

    }
}