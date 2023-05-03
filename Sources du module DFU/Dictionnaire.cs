using UnityEngine;
using System.Collections.Generic;

namespace PFDMainMod
{
    public static class EnglishFrenchDictionary
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

        private readonly static FrenchName EmptyFrenchName = new FrenchName(string.Empty, FrenchGenderNumber.MasculinSingulier, false);
        private readonly static FrenchAdjective EmptyFrenchAdjective = new FrenchAdjective(string.Empty, string.Empty, string.Empty, string.Empty);

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
            // Taverns
            ["Badger"] = new FrenchName("Blaireau", FrenchGenderNumber.MasculinSingulier, false),
            ["Barbarian"] = new FrenchName("Barbare", FrenchGenderNumber.MasculinSingulier, false),
            ["Bat"] = new FrenchName("Chauve-Souris", FrenchGenderNumber.FemininSingulier, false),
            ["Beaver"] = new FrenchName("Castor", FrenchGenderNumber.MasculinSingulier, false),
            ["Bird"] = new FrenchName("Oiseau", FrenchGenderNumber.MasculinSingulier, true),
            ["Castle"] = new FrenchName("Château", FrenchGenderNumber.MasculinSingulier, false),
            ["Cat"] = new FrenchName("Chat", FrenchGenderNumber.MasculinSingulier, false),
            ["Chasm"] = new FrenchName("Gouffre", FrenchGenderNumber.MasculinSingulier, false),
            ["Dagger"] = new FrenchName("Dague", FrenchGenderNumber.FemininSingulier, false),
            ["Devil"] = new FrenchName("Diable", FrenchGenderNumber.MasculinSingulier, false),
            ["Djinn"] = new FrenchName("Djinn", FrenchGenderNumber.MasculinSingulier, false),
            ["Dog"] = new FrenchName("Chien", FrenchGenderNumber.MasculinSingulier, false),
            ["Dragon"] = new FrenchName("Dragon", FrenchGenderNumber.MasculinSingulier, false),
            ["Dungeon"] = new FrenchName("Donjon", FrenchGenderNumber.MasculinSingulier, false),
            ["Dwarf"] = new FrenchName("Nain", FrenchGenderNumber.MasculinSingulier, false),
            ["Fairy"] = new FrenchName("Fée", FrenchGenderNumber.FemininSingulier, false),
            ["Fawn"] = new FrenchName("Faon", FrenchGenderNumber.MasculinSingulier, false),
            ["Feather"] = new FrenchName("Plume", FrenchGenderNumber.FemininSingulier, false),
            ["Fox"] = new FrenchName("Renard", FrenchGenderNumber.MasculinSingulier, false),
            ["Giant"] = new FrenchName("Géant", FrenchGenderNumber.MasculinSingulier, false),
            ["Gnome"] = new FrenchName("Gnome", FrenchGenderNumber.MasculinSingulier, false),
            ["Goat"] = new FrenchName("Chèvre", FrenchGenderNumber.FemininSingulier, false),
            ["Goblin"] = new FrenchName("Gobelin", FrenchGenderNumber.MasculinSingulier, false),
            ["Griffin"] = new FrenchName("Griffon", FrenchGenderNumber.MasculinSingulier, false),
            ["Guard"] = new FrenchName("Garde", FrenchGenderNumber.MasculinSingulier, false),
            ["Hedgehog"] = new FrenchName("Hérisson", FrenchGenderNumber.MasculinSingulier, false),
            ["Helm"] = new FrenchName("Casque", FrenchGenderNumber.MasculinSingulier, false),
            ["Huntsman"] = new FrenchName("Chasseur", FrenchGenderNumber.MasculinSingulier, false),
            ["Jug"] = new FrenchName("Cruche", FrenchGenderNumber.FemininSingulier, false),
            ["King"] = new FrenchName("Roi", FrenchGenderNumber.MasculinSingulier, false),
            ["Knave"] = new FrenchName("Valet", FrenchGenderNumber.MasculinSingulier, false),
            ["Lion"] = new FrenchName("Lion", FrenchGenderNumber.MasculinSingulier, false),
            ["Lynx"] = new FrenchName("Lynx", FrenchGenderNumber.MasculinSingulier, false),
            ["Mole"] = new FrenchName("Taupe", FrenchGenderNumber.FemininSingulier, false),
            ["Mouse"] = new FrenchName("Souris", FrenchGenderNumber.FemininSingulier, false),
            ["Muskrat"] = new FrenchName("Rat Musqué", FrenchGenderNumber.MasculinSingulier, false),
            ["Mug"] = new FrenchName("Chope", FrenchGenderNumber.FemininSingulier, false),
            ["Ogre"] = new FrenchName("Ogre", FrenchGenderNumber.MasculinSingulier, true),
            ["Pig"] = new FrenchName("Cochon", FrenchGenderNumber.MasculinSingulier, false),
            ["Pit"] = new FrenchName("Puits", FrenchGenderNumber.MasculinSingulier, false),
            ["Porcupine"] = new FrenchName("Porc-Épic", FrenchGenderNumber.MasculinSingulier, false),
            ["Priest"] = new FrenchName("Prêtre", FrenchGenderNumber.MasculinSingulier, false),
            ["Rascal"] = new FrenchName("Vaurien", FrenchGenderNumber.MasculinSingulier, false),
            ["Rat"] = new FrenchName("Rat", FrenchGenderNumber.MasculinSingulier, false),
            ["Scorpion"] = new FrenchName("Scorpion", FrenchGenderNumber.MasculinSingulier, false),
            ["Skull"] = new FrenchName("Crâne", FrenchGenderNumber.MasculinSingulier, false),
            ["Stag"] = new FrenchName("Cerf", FrenchGenderNumber.MasculinSingulier, false),
            ["Sword"] = new FrenchName("Épée", FrenchGenderNumber.FemininSingulier, true),
            ["Toad"] = new FrenchName("Crapaud", FrenchGenderNumber.MasculinSingulier, false),
            ["Wolf"] = new FrenchName("Loup", FrenchGenderNumber.MasculinSingulier, false),
            ["Woodchuck"] = new FrenchName("Marmotte", FrenchGenderNumber.FemininSingulier, false),

            // Stores
            ["Doctor"] = new FrenchName("Docteur", FrenchGenderNumber.MasculinSingulier, false),
            ["Lady"] = new FrenchName("Dame", FrenchGenderNumber.FemininSingulier, false),
            ["Lord"] = new FrenchName("Seigneur", FrenchGenderNumber.MasculinSingulier, false),

            // General Stores
            ["Equipment"] = new FrenchName("Équipement", FrenchGenderNumber.MasculinSingulier, true),
            ["Equipment Store"] = new FrenchName("Magasin d'Équipement", FrenchGenderNumber.MasculinSingulier, false),
            ["Gear"] = new FrenchName("Outils", FrenchGenderNumber.MasculinPluriel, false),
            ["Gear Store"] = new FrenchName("Outillage", FrenchGenderNumber.MasculinSingulier, true),
            ["General Store"] = new FrenchName("Bazar", FrenchGenderNumber.MasculinSingulier, false),
            ["Market"] = new FrenchName("Marché", FrenchGenderNumber.MasculinSingulier, false),
            ["Merchandise"] = new FrenchName("Commerce", FrenchGenderNumber.MasculinSingulier, false),
            ["Provisions"] = new FrenchName("Provisions", FrenchGenderNumber.FemininPluriel, false),
            ["Retail Store"] = new FrenchName("Dépôt", FrenchGenderNumber.MasculinSingulier, false),
            ["Sundries"] = new FrenchName("Droguerie", FrenchGenderNumber.FemininSingulier, false),
            ["Supplies"] = new FrenchName("Vivres", FrenchGenderNumber.MasculinPluriel, false),
            ["Supply Store"] = new FrenchName("Épicerie", FrenchGenderNumber.FemininSingulier, true),
            ["Trading Post"] = new FrenchName("Comptoir", FrenchGenderNumber.MasculinSingulier, false),
            ["Wares"] = new FrenchName("Quincaillerie", FrenchGenderNumber.FemininSingulier, false),
            ["Warehouse"] = new FrenchName("Entrepôt", FrenchGenderNumber.MasculinSingulier, true),

            // Weapon Stores
            ["Armaments"] = new FrenchName("Armement", FrenchGenderNumber.MasculinSingulier, true), // same as Weaponry
            ["Arms"] = new FrenchName("Armes", FrenchGenderNumber.MasculinPluriel, false),         // same as Weapons
            ["Armsmaker"] = new FrenchName("Armurier", FrenchGenderNumber.MasculinSingulier, true),
            ["Arsenal"] = new FrenchName("Arsenal", FrenchGenderNumber.MasculinSingulier, true),
            ["Blacksmith"] = new FrenchName("Forgeron", FrenchGenderNumber.MasculinSingulier, false), // also used for Armor Stores
            ["Blades"] = new FrenchName("Épées", FrenchGenderNumber.FemininPluriel, true),
            ["Metalsmith"] = new FrenchName("Métallurgie", FrenchGenderNumber.MasculinSingulier, false), // also used for Armor Stores
            ["Weaponry"] = new FrenchName("Armement", FrenchGenderNumber.MasculinSingulier, true),
            ["Weapons"] = new FrenchName("Armes", FrenchGenderNumber.MasculinPluriel, false),
            ["Weaponsmith"] = new FrenchName("Fourbisseur", FrenchGenderNumber.MasculinSingulier, false),

            // Armor Stores
            ["Aegis"] = new FrenchName("Égide", FrenchGenderNumber.FemininSingulier, true),
            ["Armor"] = new FrenchName("Armure", FrenchGenderNumber.FemininSingulier, true),
            ["Armory"] = new FrenchName("Armurerie", FrenchGenderNumber.FemininSingulier, true),
            ["Shielding"] = new FrenchName("Protections", FrenchGenderNumber.FemininPluriel, false),
            ["Shields"] = new FrenchName("Boucliers", FrenchGenderNumber.MasculinPluriel, false),
            ["Mail"] = new FrenchName("Haubergeonnerie", FrenchGenderNumber.FemininSingulier, true),
            ["Metalworks"] = new FrenchName("Ferronerie", FrenchGenderNumber.FemininSingulier, false),
            ["Smith"] = new FrenchName("Forge", FrenchGenderNumber.FemininSingulier, false),
            ["Smithy"] = new FrenchName("Chaudronnerie", FrenchGenderNumber.FemininSingulier, false)
        };

        private readonly static Dictionary<string, FrenchAdjective> AdjectiveTranslations = new Dictionary<string, FrenchAdjective>
        {
            // Taverns
            ["Black"] = new FrenchAdjective("Noir", "Noire", "Noirs", "Noires"),
            ["Crimson"] = new FrenchAdjective("Cramoisi", "Cramoisie", "Cramoisis", "Cramoisies"),
            ["Dancing"] = new FrenchAdjective("Dansant", "Dansante", "Dansants", "Dansantes"),
            ["Dead"] = new FrenchAdjective("Mort", "Morte", "Morts", "Mortes"),
            ["Devil's"] = new FrenchAdjective("du Diable", "du Diable", "du Diable", "du Diable"),
            ["Dirty"] = new FrenchAdjective("Sale", "Sale", "Sales", "Sales"),
            ["Flying"] = new FrenchAdjective("Volant", "Volante", "Volants", "Volantes"),
            ["Gold"] = new FrenchAdjective("Doré", "Dorée", "Dorés", "Dorées"),
            ["Green"] = new FrenchAdjective("Vert", "Verte", "Verts", "Vertes"),
            ["Howling"] = new FrenchAdjective("Hurlant", "Hurlante", "Hurlants", "Hurlantes"),
            ["Laughing"] = new FrenchAdjective("Riant", "Riante", "Riants", "Riantes"),
            ["Lucky"] = new FrenchAdjective("Chanceux", "Chanceuse", "Chanceux", "Chanceuses"),
            ["King's"] = new FrenchAdjective("du Roi", "du Roi", "du Roi", "du Roi"),
            ["Queen's"] = new FrenchAdjective("de la Reine", "de la Reine", "de la Reine", "de la Reine"),
            ["Red"] = new FrenchAdjective("Rouge", "Rouge", "Rouges", "Rouges"),
            ["Restless"] = new FrenchAdjective("Agité", "Agitée", "Agités", "Agitées"),
            ["Rusty"] = new FrenchAdjective("Rouillé", "Rouillée", "Rouillés", "Rouillées"),
            ["Savage"] = new FrenchAdjective("Sauvage", "Sauvage", "Sauvages", "Sauvages"),
            ["Screaming"] = new FrenchAdjective("Criant", "Criante", "Criants", "Criantes"),
            ["Silver"] = new FrenchAdjective("Argenté", "Argentée", "Argentés", "Argentées"),
            ["Thirsty"] = new FrenchAdjective("Assoiffé", "Assoiffée", "Assoiffés", "Assoiffées"),
            ["Unfortunate"] = new FrenchAdjective("Malchanceux", "Malchanceuse", "Malchanceux", "Malchanceuses"),
            ["White"] = new FrenchAdjective("Blanc", "Blanche", "Blancs", "Blanches"),

            // Stores
            ["Bargain"] = new FrenchAdjective("Négocié", "Négociée", "Négociés", "Négociées"),
            ["Best"] = new FrenchAdjective("Meilleur", "Meilleure", "Meilleurs", "Meilleures", true),
            ["Champion"] = new FrenchAdjective("Inégalé", "Inégalée", "Inégalés", "Inégalées"),
            ["Essential"] = new FrenchAdjective("Indispensable", "Indispensable", "Indispensables", "Indispensables"),
            ["Finest"] = new FrenchAdjective("Raffiné", "Raffinée", "Raffinés", "Raffinées"),
            ["First Class"] = new FrenchAdjective("de Première Classe", "de Première Classe", "de Première Classe", "de Première Classe"),
            ["General"] = new FrenchAdjective("Général", "Générale", "Générals", "Générales"),
            ["Odd"] = new FrenchAdjective("Singulier", "Singulière", "Singuliers", "Singulières"),
            ["Quality"] = new FrenchAdjective("de Qualité", "de Qualité", "de Qualité", "de Qualité"),
            ["Superior"] = new FrenchAdjective("Supérieur", "Supérieure", "Supérieurs", "Supérieures"),
            ["Vintage"] = new FrenchAdjective("Traditionnel", "Traditionnelle", "Traditionnels", "Traditionnelles")
        };
    }
}