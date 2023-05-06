using System;
using System.Collections.Generic;

namespace PFDMainMod
{
    public abstract class FrenchGenerator
    {
        public enum FrenchGenderNumber {
            MasculinSingulier,
            FemininSingulier,
            MasculinPluriel,
            FemininPluriel
        }

        public class FrenchName {
            public readonly string name;
            public readonly FrenchGenderNumber genderNumber;
            public readonly bool elidedArticle;

            public FrenchName(string name, FrenchGenderNumber gender, bool elidedArticle)
            {
                this.name = name;
                this.genderNumber = gender;
                this.elidedArticle = elidedArticle;
            }
        }

        public class FrenchAdjective {
            public readonly Dictionary<FrenchGenderNumber, string> variants;
            public readonly bool comesBeforeName;
            public FrenchAdjective(string masculierSingulier, string femininSingulier, string masculinPluriel, string femininPluriel, bool comesBeforeName = false)
            {
                this.variants = new Dictionary<FrenchGenderNumber, string> {
                    [FrenchGenderNumber.MasculinSingulier] = masculierSingulier,
                    [FrenchGenderNumber.FemininSingulier] = femininSingulier,
                    [FrenchGenderNumber.MasculinPluriel] = masculinPluriel,
                    [FrenchGenderNumber.FemininPluriel] = femininPluriel
                };
                this.comesBeforeName = comesBeforeName;
            }
        }

        public static FrenchName MissingFrenchName(string name)
        {
            return new FrenchName(string.Format("<nom manquant: {0}>", name), FrenchGenderNumber.MasculinSingulier, false);
        }
        public static FrenchAdjective MissingFrenchAdjective(string name)
        {
            string msg = string.Format("<adjectif manquant: {0}>", name);
            return new FrenchAdjective(msg, msg, msg, msg);
        }

        public abstract FrenchName LookupName(string name);

        public abstract FrenchAdjective LookupAdjective(string adjective);

        public string FrenchNameWithArticle(string englishName)
        {
            var frenchName = LookupName(englishName);
            string article = FrenchArticle(frenchName);
            return string.Format("{0}{1}", article, frenchName.name);
        }

        public string FrenchNameWithArticleAndAdjective(string englishAdjective, string englishName)
        {
            var frenchName = LookupName(englishName);
            var adjective = LookupAdjective(englishAdjective);
            if (adjective.comesBeforeName)
            {
                // Assume the article is not elided in front of this adjective. Could be a bit optimistic
                string article = FrenchArticle(new FrenchName(adjective.variants[frenchName.genderNumber], frenchName.genderNumber, false));
                return string.Format("{0}{2} {1}", article, frenchName.name, adjective.variants[frenchName.genderNumber]);
            }
            else
            {
                string article = FrenchArticle(frenchName);
                return string.Format("{0}{1} {2}", article, frenchName.name, adjective.variants[frenchName.genderNumber]);
            }
        }

        public string FrenchNameWithAdjective(string englishAdjective, string englishName)
        {
            var frenchName = LookupName(englishName);
            var adjective = LookupAdjective(englishAdjective);
            return adjective.comesBeforeName
                ? string.Format("{1} {0}", frenchName.name, adjective.variants[frenchName.genderNumber])
                : string.Format("{0} {1}", frenchName.name, adjective.variants[frenchName.genderNumber]);
        }

        public string GetFrenchName(string englishName)
        {
            var frenchName = LookupName(englishName);
            return frenchName.name;
        }

        private string FrenchArticle(FrenchName frenchName)
        {
            switch (frenchName.genderNumber)
            {
                case FrenchGenderNumber.MasculinSingulier:
                    return frenchName.elidedArticle ? "l'" : "le ";
                case FrenchGenderNumber.FemininSingulier:
                    return frenchName.elidedArticle ? "l'" : "la ";
                case FrenchGenderNumber.MasculinPluriel:
                case FrenchGenderNumber.FemininPluriel:
                    return "les ";
                default:
                    throw new ArgumentException("Unhandled FrenchGender");
            }
        }
    }
}
