using UnityEngine;
using System.Collections.Generic;
using System;

namespace PFDMainMod
{
    public class EnglishFrenchDictionary : FrenchGenerator
    {
        private readonly static Dictionary<string, FrenchName> NameTranslations = new Dictionary<string, FrenchName>
        {
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
