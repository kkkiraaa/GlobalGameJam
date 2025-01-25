using System;
using UnityEngine;

public class BubbleGenome : MonoBehaviour
{
    [System.Serializable]
    public class Gene
    {
        public int Size = 1;
        public int Elasticity = 1;
        public int Opacity = 1;
        public int SurfaceTension = 1;
        public int Stickiness = 1;
        public int Buoyancy = 1;
        public int Luminosity = 1;
        public int Reflectivity = 1;

        public Gene() => InitializeRandomGene();

        private void InitializeRandomGene()
        {
            System.Random rnd = new System.Random();
            Size = rnd.Next(2, 12);
            Elasticity = 5;
            Opacity = rnd.Next(2, 12);
            SurfaceTension = rnd.Next(2, 12);
            Stickiness = rnd.Next(2, 12);
            Buoyancy = rnd.Next(2, 12);
            Luminosity = rnd.Next(2, 12);
            Reflectivity = rnd.Next(2, 12);
        }

        public void Mutate(int seed, int characteristicsToChange = 3)
        {
            System.Random rnd = new System.Random(seed);
            
            for (int i = 0; i < characteristicsToChange; i++)
            {
                int charIndex = rnd.Next(8);
                int delta = rnd.Next(-2, 3);

                switch (charIndex)
                {
                    case 0: Size = Math.Clamp(Size + delta, 1, 12); break;
                    case 1: Elasticity = Math.Clamp(Elasticity + delta, 1, 12); break;
                    case 2: Opacity = Math.Clamp(Opacity + delta, 1, 12); break;
                    case 3: SurfaceTension = Math.Clamp(SurfaceTension + delta, 1, 12); break;
                    case 4: Stickiness = Math.Clamp(Stickiness + delta, 1, 12); break;
                    case 5: Buoyancy = Math.Clamp(Buoyancy + delta, 1, 12); break;
                    case 6: Luminosity = Math.Clamp(Luminosity + delta, 1, 12); break;
                    case 7: Reflectivity = Math.Clamp(Reflectivity + delta, 1, 12); break;
                }
            }
        }
    }

    public Gene CurrentGene = new Gene();
}