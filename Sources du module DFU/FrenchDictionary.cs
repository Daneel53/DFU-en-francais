using UnityEngine;
using System.Collections.Generic;

namespace PFDMainMod
{
    public class FrenchDictionary : FrenchGenerator
    {
        private readonly static Dictionary<string, FrenchName> Names = new Dictionary<string, FrenchName>
        {
            // %rt
            ["Roi"] = new FrenchName("Roi", FrenchGenderNumber.MasculinSingulier, false),
            ["Reine"] = new FrenchName("Reine", FrenchGenderNumber.FemininSingulier, false),
            ["Duc"] = new FrenchName("Duc", FrenchGenderNumber.MasculinSingulier, false),
            ["Duchesse"] = new FrenchName("Duchesse", FrenchGenderNumber.FemininSingulier, false),
            ["Marquis"] = new FrenchName("Marquis", FrenchGenderNumber.MasculinSingulier, false),
            ["Marquise"] = new FrenchName("Marquise", FrenchGenderNumber.FemininSingulier, false),
            ["Comte"] = new FrenchName("Comte", FrenchGenderNumber.MasculinSingulier, false),
            ["Comtesse"] = new FrenchName("Comtesse", FrenchGenderNumber.FemininSingulier, false),
            ["Baron"] = new FrenchName("Baron", FrenchGenderNumber.MasculinSingulier, false),
            ["Baronne"] = new FrenchName("Baronne", FrenchGenderNumber.FemininSingulier, false),
            ["Seigneur"] = new FrenchName("Seigneur", FrenchGenderNumber.MasculinSingulier, false),
            ["Dame"] = new FrenchName("Dame", FrenchGenderNumber.FemininSingulier, false),
        };

        private readonly static Dictionary<string, FrenchAdjective> Adjectives = new Dictionary<string, FrenchAdjective>();

        public override FrenchName LookupName(string frenchNameString) {
            if(Names.TryGetValue(frenchNameString, out var frenchName)) {
                return frenchName;
            }
            Debug.LogWarningFormat("Couldn't find name {0}", frenchNameString);
            return EmptyFrenchName;
        }

        public override FrenchAdjective LookupAdjective(string frenchAdjectiveString) {
            if(Adjectives.TryGetValue(frenchAdjectiveString, out var frenchAdjective)) {
                return frenchAdjective;
            }
            Debug.LogWarningFormat("Couldn't find adjective {0}", frenchAdjectiveString);
            return EmptyFrenchAdjective;
        }
    }
}
