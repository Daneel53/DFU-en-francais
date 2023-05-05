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

            // %rt
            // ["Queen"] = new FrenchName("Reine", FrenchGenderNumber.FemininSingulier, false),
            // ["Duke"] = new FrenchName("Duc", FrenchGenderNumber.MasculinSingulier, false),
            // ["Duchess"] = new FrenchName("Duchesse", FrenchGenderNumber.FemininSingulier, false),
            // ["Marquis"] = new FrenchName("Marquis", FrenchGenderNumber.MasculinSingulier, false),
            // ["Marquise"] = new FrenchName("Marquise", FrenchGenderNumber.FemininSingulier, false),
            // ["Count"] = new FrenchName("Comte", FrenchGenderNumber.MasculinSingulier, false),
            // ["Countess"] = new FrenchName("Comtesse", FrenchGenderNumber.FemininSingulier, false),
            // ["Baron"] = new FrenchName("Baron", FrenchGenderNumber.MasculinSingulier, false),
            // ["Baroness"] = new FrenchName("Baronne", FrenchGenderNumber.FemininSingulier, false),
            // ["Lord"] = new FrenchName("Seigneur", FrenchGenderNumber.MasculinSingulier, false),
            // ["Lady"] = new FrenchName("Dame", FrenchGenderNumber.FemininSingulier, false),

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
            ["Armorer"] = new FrenchName("Armurier", FrenchGenderNumber.MasculinSingulier, true),
            ["Armory"] = new FrenchName("Armurerie", FrenchGenderNumber.FemininSingulier, true),
            ["Shielding"] = new FrenchName("Protections", FrenchGenderNumber.FemininPluriel, false),
            ["Shields"] = new FrenchName("Boucliers", FrenchGenderNumber.MasculinPluriel, false),
            ["Mail"] = new FrenchName("Mailles", FrenchGenderNumber.FemininPluriel, false),
            ["Metalworks"] = new FrenchName("Ferronnerie", FrenchGenderNumber.FemininSingulier, false),
            ["Smith"] = new FrenchName("Forge", FrenchGenderNumber.FemininSingulier, false),
            ["Smithy"] = new FrenchName("Chaudronnerie", FrenchGenderNumber.FemininSingulier, false),

            // Book Stores
            ["Book Center"] = new FrenchName("Centre de Documentation", FrenchGenderNumber.MasculinSingulier, false), // should be a library instead?
            ["Book Dealer"] = new FrenchName("Marchand de Livres", FrenchGenderNumber.MasculinSingulier, false),
            ["Books"] = new FrenchName("Livres", FrenchGenderNumber.MasculinPluriel, false),
            ["Bookseller"] = new FrenchName("Presse", FrenchGenderNumber.MasculinSingulier, false),
            ["Bookshop"] = new FrenchName("Bouquiniste", FrenchGenderNumber.FemininSingulier, false),
            ["Bookstall"] = new FrenchName("Étal de Livres", FrenchGenderNumber.MasculinSingulier, true),
            ["Bookstore"] = new FrenchName("Librairie", FrenchGenderNumber.FemininSingulier, false),
            ["Incunabula"] = new FrenchName("Incunables", FrenchGenderNumber.MasculinPluriel, false),

            // Clothing Stores
            ["Apparel"] = new FrenchName("Uniformes", FrenchGenderNumber.MasculinPluriel, true),
            ["Attire"] = new FrenchName("Tenues", FrenchGenderNumber.FemininPluriel, false),
            ["Clothing"] = new FrenchName("Habillement", FrenchGenderNumber.MasculinSingulier, true),
            ["Clothes"] = new FrenchName("Vêtements", FrenchGenderNumber.MasculinSingulier, false),
            ["Costumes"] = new FrenchName("Costumes", FrenchGenderNumber.MasculinPluriel, false),
            ["Fashion"] = new FrenchName("Mode", FrenchGenderNumber.FemininSingulier, false),
            ["Finery"] = new FrenchName("Parures", FrenchGenderNumber.FemininPluriel, false),
            ["Garments"] = new FrenchName("Habits", FrenchGenderNumber.MasculinSingulier, true),
            ["Outfits"] = new FrenchName("Ensembles", FrenchGenderNumber.MasculinPluriel, true),
            ["Tailoring"] = new FrenchName("Couturier", FrenchGenderNumber.MasculinSingulier, false),
            ["Vestments"] = new FrenchName("Robes", FrenchGenderNumber.MasculinPluriel, false),

            // Alchemy Stores
            ["Alchemical Solutions"] = new FrenchName("Solutions Alchimiques", FrenchGenderNumber.FemininPluriel, false),
            ["Alchemistry"] = new FrenchName("Alchimie", FrenchGenderNumber.FemininSingulier, true),
            ["Antidotes"] = new FrenchName("Antidotes", FrenchGenderNumber.MasculinPluriel, true),
            ["Apothecary"] = new FrenchName("Apothicaire", FrenchGenderNumber.MasculinSingulier, true),
            ["Chemicals"] = new FrenchName("Produits Chimiques", FrenchGenderNumber.MasculinPluriel, false),
            ["Chemistry"] = new FrenchName("Chimie", FrenchGenderNumber.FemininSingulier, false),
            ["Elixirs"] = new FrenchName("Élixirs", FrenchGenderNumber.MasculinPluriel, true),
            ["Experiental Products"] = new FrenchName("Cornue", FrenchGenderNumber.FemininSingulier, false),
            ["Herb Garden"] = new FrenchName("Jardin Médicinal", FrenchGenderNumber.MasculinSingulier, false),
            ["Herbs"] = new FrenchName("Herbes", FrenchGenderNumber.FemininPluriel, true),
            ["Medicaments"] = new FrenchName("Médicaments", FrenchGenderNumber.MasculinPluriel, false),
            ["Medicinal Agents"] = new FrenchName("Agents Médicinaux", FrenchGenderNumber.MasculinPluriel, true),
            ["Medicines"] = new FrenchName("Médecines", FrenchGenderNumber.FemininPluriel, false),
            ["Metallurgy"] = new FrenchName("Métallurgie", FrenchGenderNumber.FemininSingulier, false),
            ["Pharmaceuticals"] = new FrenchName("Pharmacopée", FrenchGenderNumber.FemininPluriel, false),
            ["Pharmacy"] = new FrenchName("Pharmacie", FrenchGenderNumber.FemininSingulier, false),
            ["Physics"] = new FrenchName("Physique", FrenchGenderNumber.FemininSingulier, false),
            ["Potherbs"] = new FrenchName("Herbes Médicinales", FrenchGenderNumber.FemininPluriel, true),
            ["Potions"] = new FrenchName("Potions", FrenchGenderNumber.FemininPluriel, false),
            ["Remedies"] = new FrenchName("Remèdes", FrenchGenderNumber.MasculinPluriel, false),
            ["Spices"] = new FrenchName("Épices", FrenchGenderNumber.FemininPluriel, true),
            ["Tinctures"] = new FrenchName("Teintures", FrenchGenderNumber.FemininPluriel, false),
            ["Unguents"] = new FrenchName("Onguents", FrenchGenderNumber.MasculinPluriel, true),

            // Gems Stores
            ["Bijoutry"] = new FrenchName("Bijouterie", FrenchGenderNumber.FemininSingulier, false),
            ["Gemcutter"] = new FrenchName("Tailleur de Gemmes", FrenchGenderNumber.MasculinSingulier, false),
            ["Gems"] = new FrenchName("Gemmes", FrenchGenderNumber.FemininPluriel, false),
            ["Gemstones"] = new FrenchName("Pierres Précieuses", FrenchGenderNumber.FemininPluriel, false),
            ["Jewel Box"] = new FrenchName("Boîte à Bijoux", FrenchGenderNumber.FemininSingulier, false),
            ["Jewelers"] = new FrenchName("Joaillers", FrenchGenderNumber.MasculinPluriel, false),
            ["Jewelry"] = new FrenchName("Joaillerie", FrenchGenderNumber.FemininSingulier, false),
            ["Jewelry Shop"] = new FrenchName("Boutique de Bijoux", FrenchGenderNumber.FemininSingulier, false),
            ["Jewels"] = new FrenchName("Bijoux", FrenchGenderNumber.MasculinPluriel, false),
            ["Precious Stones"] = new FrenchName("Pierres Fines", FrenchGenderNumber.FemininPluriel, false),

            // Pawn Shops
            ["Antiquities"] = new FrenchName("Antiquités", FrenchGenderNumber.FemininPluriel, true),
            ["Hockshop"] = new FrenchName("Crédit sur Gages", FrenchGenderNumber.MasculinSingulier, false),
            ["Pawnbrokers"] = new FrenchName("Mont-de-Piété", FrenchGenderNumber.MasculinSingulier, false),
            ["Pawnshop"] = new FrenchName("Prêteur sur Gages", FrenchGenderNumber.MasculinSingulier, false),
            ["Used Gear"] = new FrenchName("Occasions", FrenchGenderNumber.FemininPluriel, true),
            ["Used Merchandise"] = new FrenchName("Secondes Mains", FrenchGenderNumber.FemininPluriel, false),
            ["Used Supplies"] = new FrenchName("Fournitures Usagées", FrenchGenderNumber.FemininPluriel, false),

            // Furniture Stores
            ["Carpentry"] = new FrenchName("Charpentier", FrenchGenderNumber.MasculinSingulier, false),
            ["Crafts"] = new FrenchName("Artisan", FrenchGenderNumber.MasculinSingulier, true),
            ["Decor"] = new FrenchName("Décoration", FrenchGenderNumber.FemininSingulier, false),
            ["Furnishings"] = new FrenchName("Mobilier", FrenchGenderNumber.MasculinSingulier, false),
            ["Furniture"] = new FrenchName("Meubles", FrenchGenderNumber.MasculinPluriel, false),
            ["Furniture Shop"] = new FrenchName("Ameublement", FrenchGenderNumber.MasculinSingulier, true),
            ["Interior Design"] = new FrenchName("Décoration d'intérieur", FrenchGenderNumber.FemininSingulier, false),
            ["Woodwork"] = new FrenchName("Marqueterie", FrenchGenderNumber.FemininSingulier, false),
            ["Woodworking"] = new FrenchName("Menuiserie", FrenchGenderNumber.FemininSingulier, false),

            // Libraries
            ["Athenaeum"] = new FrenchName("Athénée", FrenchGenderNumber.FemininSingulier, true),
            ["Bookroom"] = new FrenchName("Salle de Lecture", FrenchGenderNumber.FemininSingulier, false),
            ["Historians"] = new FrenchName("Archives", FrenchGenderNumber.FemininPluriel, true),
            ["Library"] = new FrenchName("Bibliothèque", FrenchGenderNumber.FemininSingulier, false),
            ["Lyceum"] = new FrenchName("Lycée", FrenchGenderNumber.MasculinSingulier, false),
            ["Public Library"] = new FrenchName("Bibliothèque Publique", FrenchGenderNumber.FemininSingulier, false),
            ["Seminary"] = new FrenchName("Séminaire", FrenchGenderNumber.MasculinSingulier, false)
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
            ["General"] = new FrenchAdjective("Général", "Générale", "Généraux", "Généraux"),
            ["Odd"] = new FrenchAdjective("Singulier", "Singulière", "Singuliers", "Singulières"),
            ["Quality"] = new FrenchAdjective("de Qualité", "de Qualité", "de Qualité", "de Qualité"),
            ["Superior"] = new FrenchAdjective("Supérieur", "Supérieure", "Supérieurs", "Supérieures"),
            ["Vintage"] = new FrenchAdjective("Traditionnel", "Traditionnelle", "Traditionnels", "Traditionnelles")
        };
    }
}