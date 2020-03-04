using System;

namespace Lab7
{
    public class Frame 
    {
        private EFeatures _Features;
        public EFeatures Features
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
            this._Features = EFeatures.Default;
            this.ID = id;
            this.Name = name;
        }
        
        public void ToggleFeatures(EFeatures feature) 
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            this._Features ^= feature;
            Console.WriteLine($"Result: {Features} ");
        }

        public void TurnOnFeatures(EFeatures feature) 
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            this._Features |= feature;
            Console.WriteLine($"Result: {Features} ");
        }

        public void TurnOffFeatures(EFeatures feature)
        {
            Console.WriteLine($"Features: {Features} ^ feature: {feature}");
            this._Features &= ~feature;
            Console.WriteLine($"Result: {Features} ");
        }

    }
}