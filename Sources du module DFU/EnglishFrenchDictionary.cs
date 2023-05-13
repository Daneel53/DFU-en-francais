using UnityEngine;
using System.Collections.Generic;
using System;

namespace PFDMainMod
{
    public class EnglishFrenchDictionary : FrenchGenerator
    {
        private readonly static Dictionary<string, FrenchName> NameTranslations = new Dictionary<string, FrenchName>
        {
        };

        private readonly static Dictionary<string, FrenchAdjective> AdjectiveTranslations = new Dictionary<string, FrenchAdjective>
        {
        };

        public override FrenchName LookupName(string englishName) {
            if(NameTranslations.TryGetValue(englishName, out var frenchName)) {
                return frenchName;
            }
            Debug.LogWarningFormat("Couldn't find translation for name {0}", englishName);
            return MissingFrenchName(englishName);
        }

        public override FrenchAdjective LookupAdjective(string englishAdjective) {
            if(AdjectiveTranslations.TryGetValue(englishAdjective, out var frenchAdjective)) {
                return frenchAdjective;
            }
            Debug.LogWarningFormat("Couldn't find translation for adjective {0}", englishAdjective);
            return MissingFrenchAdjective(englishAdjective);
        }
    }
}
