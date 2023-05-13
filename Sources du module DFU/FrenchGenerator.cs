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

        public abstract FrenchName LookupMaybeName(string name);

        public abstract FrenchAdjective LookupMaybeAdjective(string adjective);
        public abstract FrenchName LookupName(string name);

        public abstract FrenchAdjective LookupAdjective(string adjective);

        public string FrenchNameWithArticle(string englishName)
        {
            var frenchName = LookupName(englishName);
            return FrenchNameWithArticle(frenchName);
        }

        public string FrenchNameWithArticle(FrenchName frenchName)
        {
            string article = FrenchArticle(frenchName);
            return string.Format("{0}{1}", article, frenchName.name);
        }

        public string FrenchNameWithArticleAndAdjective(string stringAdjective, string stringName)
        {
            var name = LookupName(stringName);
            return FrenchNameWithArticleAndAdjective(stringAdjective, name);
        }

        public string FrenchNameWithArticleAndAdjective(FrenchAdjective adjective, string stringName)
        {
            var name = LookupName(stringName);
            return FrenchNameWithArticleAndAdjective(adjective, name);
        }

        public string FrenchNameWithArticleAndAdjective(string stringAdjective, FrenchName name)
        {
            var adjective = LookupAdjective(stringAdjective);
            return FrenchNameWithArticleAndAdjective(adjective, name);
        }

        public string FrenchNameWithArticleAndAdjective(FrenchAdjective adjective, FrenchName name)
        {
            if (adjective.comesBeforeName)
            {
                // Assume the article is not elided in front of this adjective. Could be a bit optimistic
                string article = FrenchArticle(new FrenchName(adjective.variants[name.genderNumber], name.genderNumber, false));
                return string.Format("{0}{2} {1}", article, name.name, adjective.variants[name.genderNumber]);
            }
            else
            {
                string article = FrenchArticle(name);
                return string.Format("{0}{1} {2}", article, name.name, adjective.variants[name.genderNumber]);
            }
        }

        public string FrenchNameWithAdjective(string stringAdjective, string stringName)
        {
            var frenchAdjective = LookupAdjective(stringAdjective);
            return FrenchNameWithAdjective(frenchAdjective, stringName);
        }

        public string FrenchNameWithAdjective(string stringAdjective, FrenchName name)
        {
            var frenchAdjective = LookupAdjective(stringAdjective);
            return FrenchNameWithAdjective(frenchAdjective, name);
        }

        public string FrenchNameWithAdjective(FrenchAdjective adjective, string stringName)
        {
            var frenchName = LookupName(stringName);
            return FrenchNameWithAdjective(adjective, frenchName);
        }

        public string FrenchNameWithAdjective(FrenchAdjective adjective, FrenchName name)
        {
            return adjective.comesBeforeName
                ? string.Format("{1} {0}", name.name, adjective.variants[name.genderNumber])
                : string.Format("{0} {1}", name.name, adjective.variants[name.genderNumber]);
        }

        public string GetFrenchName(string englishName)
        {
            var frenchName = LookupName(englishName);
            return GetFrenchName(frenchName);
        }

        public string GetFrenchName(FrenchName frenchName)
        {
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

        public string FrenchNameWithMaybeArticle(string articlePattern, string englishName)
        {
            return articlePattern?.Length == 0 ? GetFrenchName(englishName) : FrenchNameWithArticle(englishName);
        }

        public string FrenchNameWithMaybeArticleAndAdjective(string articlePattern, string englishAdjective, string englishName)
        {
            return articlePattern?.Length == 0 ? FrenchNameWithAdjective(englishAdjective, englishName) : FrenchNameWithArticleAndAdjective(englishAdjective, englishName);
        }
    }
}
