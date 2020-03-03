using System;

namespace Lab7
{
    class Frame 
    {
        public EFeatures Features;

        public uint ID;

        public string Name;

        public Frame(uint id, string name)
        {
            Features = EFeatures.Default;
            this.ID = id;
            this.Name = name;
        }
        
        public void ToggleFeatures(EFeatures feature) 
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            Features ^= feature;
            Console.WriteLine($"Result: {Features} ");
        }

        public void TurnOnFeatures(EFeatures feature) 
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            Features |= feature;
            Console.WriteLine($"Result: {Features} ");
        }

        public void TurnOffFeatures(EFeatures feature)
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            Features &= ~feature;
            Console.WriteLine($"Result: {Features} ");
        }

    }
}