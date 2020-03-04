using System;

namespace Lab7
{
    public class Frame 
    {
        private EFeatureFlags _Features;
        public EFeatureFlags Features
        {
            get { return _Features; }
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
            this._Features = EFeatureFlags.Default;
            this.ID = id;
            this.Name = name;
        }
        
        public void ToggleFeatures(EFeatureFlags feature) 
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            this._Features ^= feature;
            Console.WriteLine($"Result: {Features} ");
        }

        public void TurnOnFeatures(EFeatureFlags feature) 
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            this._Features |= feature;
            Console.WriteLine($"Result: {Features} ");
        }

        public void TurnOffFeatures(EFeatureFlags feature)
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            this._Features &= ~feature;
            Console.WriteLine($"Result: {Features} ");
        }

    }
}