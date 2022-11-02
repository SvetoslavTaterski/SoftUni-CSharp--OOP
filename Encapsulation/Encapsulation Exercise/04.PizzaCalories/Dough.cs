using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        protected string FlourType 
        {
            get
            {
                return flourType;
            }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        protected string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        protected double Grams 
        {
            get
            {
                return grams;
            }
            set
            {
                if (value <= 0 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                grams = value;
            }
        }

        public double CaloriesPerGram 
        {
            get 
            {
                double modifier = 0;
                double otherModifier = 0;

                if (flourType.ToLower() == "white")
                {
                    modifier = 1.5;

                    if (bakingTechnique.ToLower() == "crispy")
                    {
                        otherModifier = 0.9;
                    }
                    else if (bakingTechnique.ToLower() == "chewy")
                    {
                        otherModifier = 1.1;
                    }
                    else if (bakingTechnique.ToLower() == "homemade")
                    {
                        otherModifier = 1.0;
                    }
                }
                else if (flourType.ToLower() == "wholegrain")
                {
                    modifier = 1.0;

                    if (bakingTechnique.ToLower() == "crispy")
                    {
                        otherModifier = 0.9;
                    }
                    else if (bakingTechnique.ToLower() == "chewy")
                    {
                        otherModifier = 1.1;
                    }
                    else if (bakingTechnique.ToLower() == "homemade")
                    {
                        otherModifier = 1.0;
                    }
                }

                return (2 * grams) * modifier * otherModifier;
            }
        }
    }
}
