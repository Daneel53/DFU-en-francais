using UnityEngine;
using System.Collections.Generic;

namespace PFDMainMod
{
    public static class EnglishFrenchDictionary
    {
        public enum FrenchGender {
            Masculin,
            Feminin
        }

        public class FrenchName {
            public readonly string name;
            public readonly FrenchGender gender;
            public readonly bool elidedArticle;

            public FrenchName(string name, FrenchGender gender, bool elidedArticle)
            {
                this.name = name;
                this.gender = gender;
                this.elidedArticle = elidedArticle;
            }
        }

        private readonly static FrenchName EmptyFrenchName = new FrenchName(string.Empty, FrenchGender.Masculin, false);
        private readonly static FrenchAdjective EmptyFrenchAdjective = new FrenchAdjective(string.Empty, string.Empty);

        public class FrenchAdjective {
            public readonly Dictionary<FrenchGender, string> variants;
            public readonly bool comesBeforeName;
            public FrenchAdjective(string masculine, string feminine, bool comesBeforeName = false)
            {
                this.variants = new Dictionary<FrenchGender, string> {
                    [FrenchGender.Masculin] = masculine,
                    [FrenchGender.Feminin] = feminine
                };
                this.comesBeforeName = comesBeforeName;
            }
        }

        public static FrenchName TranslateEnglishName(string englishName) {
            if(NameTranslations.TryGetValue(englishName, out var frenchName)) {
                return frenchName;
            }
            Debug.LogWarningFormat("Couldn't find translation for name {0}", englishName);
            return EmptyFrenchName;
        }

        public static FrenchAdjective TranslateEnglishAdjective(string englishAdjective) {
            if(AdjectiveTranslations.TryGetValue(englishAdjective, out var frenchAdjective)) {
                return frenchAdjective;
            }
            Debug.LogWarningFormat("Couldn't find translation for adjective {0}", englishAdjective);
            return EmptyFrenchAdjective;
        }

        private readonly static Dictionary<string, FrenchName> NameTranslations = new Dictionary<string, FrenchName>
        {
            ["Badger"] = new FrenchName("Blaireau", FrenchGender.Masculin, false),
            ["Barbarian"] = new FrenchName("Barbare", FrenchGender.Masculin, false),
            ["Bat"] = new FrenchName("Chauve-Souris", FrenchGender.Feminin, false),
            ["Beaver"] = new FrenchName("Castor", FrenchGender.Masculin, false),
            ["Bird"] = new FrenchName("Oiseau", FrenchGender.Masculin, true),
            ["Castle"] = new FrenchName("Château", FrenchGender.Masculin, false),
            ["Cat"] = new FrenchName("Chat", FrenchGender.Masculin, false),
            ["Chasm"] = new FrenchName("Gouffre", FrenchGender.Masculin, false),
            ["Dagger"] = new FrenchName("Dague", FrenchGender.Feminin, false),
            ["Devil"] = new FrenchName("Diable", FrenchGender.Masculin, false),
            ["Djinn"] = new FrenchName("Djinn", FrenchGender.Masculin, false),
            ["Dog"] = new FrenchName("Chien", FrenchGender.Masculin, false),
            ["Dragon"] = new FrenchName("Dragon", FrenchGender.Masculin, false),
            ["Dungeon"] = new FrenchName("Donjon", FrenchGender.Masculin, false),
            ["Dwarf"] = new FrenchName("Nain", FrenchGender.Masculin, false),
            ["Fairy"] = new FrenchName("Fée", FrenchGender.Feminin, false),
            ["Fawn"] = new FrenchName("Faon", FrenchGender.Masculin, false),
            ["Feather"] = new FrenchName("Plume", FrenchGender.Feminin, false),
            ["Fox"] = new FrenchName("Renard", FrenchGender.Masculin, false),
            ["Giant"] = new FrenchName("Géant", FrenchGender.Masculin, false),
            ["Gnome"] = new FrenchName("Gnome", FrenchGender.Masculin, false),
            ["Goat"] = new FrenchName("Chèvre", FrenchGender.Feminin, false),
            ["Goblin"] = new FrenchName("Gobelin", FrenchGender.Masculin, false),
            ["Griffin"] = new FrenchName("Griffon", FrenchGender.Masculin, false),
            ["Guard"] = new FrenchName("Garde", FrenchGender.Masculin, false),
            ["Hedgehog"] = new FrenchName("Hérisson", FrenchGender.Masculin, false),
            ["Helm"] = new FrenchName("Casque", FrenchGender.Masculin, false),
            ["Huntsman"] = new FrenchName("Chasseur", FrenchGender.Masculin, false),
            ["Jug"] = new FrenchName("Cruche", FrenchGender.Feminin, false),
            ["King"] = new FrenchName("Roi", FrenchGender.Masculin, false),
            ["Knave"] = new FrenchName("Valet", FrenchGender.Masculin, false),
            ["Lion"] = new FrenchName("Lion", FrenchGender.Masculin, false),
            ["Lynx"] = new FrenchName("Lynx", FrenchGender.Masculin, false),
            ["Mole"] = new FrenchName("Taupe", FrenchGender.Feminin, false),
            ["Mouse"] = new FrenchName("Souris", FrenchGender.Feminin, false),
            ["Muskrat"] = new FrenchName("Rat Musqué", FrenchGender.Masculin, false),
            ["Mug"] = new FrenchName("Chope", FrenchGender.Feminin, false),
            ["Ogre"] = new FrenchName("Ogre", FrenchGender.Masculin, true),
            ["Pig"] = new FrenchName("Cochon", FrenchGender.Masculin, false),
            ["Pit"] = new FrenchName("Puits", FrenchGender.Masculin, false),
            ["Porcupine"] = new FrenchName("Porc-Épic", FrenchGender.Masculin, false),
            ["Priest"] = new FrenchName("Prêtre", FrenchGender.Masculin, false),
            ["Rascal"] = new FrenchName("Vaurien", FrenchGender.Masculin, false),
            ["Rat"] = new FrenchName("Rat", FrenchGender.Masculin, false),
            ["Scorpion"] = new FrenchName("Scorpion", FrenchGender.Masculin, false),
            ["Skull"] = new FrenchName("Crâne", FrenchGender.Masculin, false),
            ["Stag"] = new FrenchName("Cerf", FrenchGender.Masculin, false),
            ["Sword"] = new FrenchName("Épée", FrenchGender.Feminin, true),
            ["Toad"] = new FrenchName("Crapaud", FrenchGender.Masculin, false),
            ["Wolf"] = new FrenchName("Loup", FrenchGender.Masculin, false),
            ["Woodchuck"] = new FrenchName("Marmotte", FrenchGender.Feminin, false)
        };

        private readonly static Dictionary<string, FrenchAdjective> AdjectiveTranslations = new Dictionary<string, FrenchAdjective>
        {
            ["Black"] = new FrenchAdjective("Noir", "Noire"),
            ["Crimson"] = new FrenchAdjective("Cramoisi", "Cramoisie"),
            ["Dancing"] = new FrenchAdjective("Dansant", "Dansante"),
            ["Dead"] = new FrenchAdjective("Mort", "Morte"),
            ["Devil's"] = new FrenchAdjective("du Diable", "du Diable"),
            ["Dirty"] = new FrenchAdjective("Sale", "Sale"),
            ["Flying"] = new FrenchAdjective("Volant", "Volante"),
            ["Gold"] = new FrenchAdjective("Doré", "Dorée"),
            ["Green"] = new FrenchAdjective("Vert", "Verte"),
            ["Howling"] = new FrenchAdjective("Hurlant", "Hurlante"),
            ["Laughing"] = new FrenchAdjective("Riant", "Riante"),
            ["Lucky"] = new FrenchAdjective("Chanceux", "Chanceuse"),
            ["King's"] = new FrenchAdjective("du Roi", "du Roi"),
            ["Queen's"] = new FrenchAdjective("de la Reine", "de la Reine"),
            ["Red"] = new FrenchAdjective("Rouge", "Rouge"),
            ["Restless"] = new FrenchAdjective("Agité", "Agitée"),
            ["Rusty"] = new FrenchAdjective("Rouillé", "Rouillée"),
            ["Savage"] = new FrenchAdjective("Sauvage", "Sauvage"),
            ["Screaming"] = new FrenchAdjective("Criant", "Criante"),
            ["Silver"] = new FrenchAdjective("Argenté", "Argentée"),
            ["Thirsty"] = new FrenchAdjective("Assoiffé", "Assoiffée"),
            ["Unfortunate"] = new FrenchAdjective("Malchanceux", "Malchanceuse"),
            ["White"] = new FrenchAdjective("Blanc", "Blanche")
        };
    }
}