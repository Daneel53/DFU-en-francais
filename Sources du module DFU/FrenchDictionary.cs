using UnityEngine;
using System.Collections.Generic;

namespace PFDMainMod
{
    public class FrenchDictionary : FrenchGenerator
    {
        private readonly static Dictionary<string, FrenchName> Names = new Dictionary<string, FrenchName>
        {
            ["Barbare"] = new FrenchName("Barbare", FrenchGenderNumber.MasculinSingulier, false),
            ["Blaireau"] = new FrenchName("Blaireau", FrenchGenderNumber.MasculinSingulier, false),
            ["Casque"] = new FrenchName("Casque", FrenchGenderNumber.MasculinSingulier, false),
            ["Castor"] = new FrenchName("Castor", FrenchGenderNumber.MasculinSingulier, false),
            ["Cerf"] = new FrenchName("Cerf", FrenchGenderNumber.MasculinSingulier, false),
            ["Chasseur"] = new FrenchName("Chasseur", FrenchGenderNumber.MasculinSingulier, false),
            ["Château"] = new FrenchName("Château", FrenchGenderNumber.MasculinSingulier, false),
            ["Chat"] = new FrenchName("Chat", FrenchGenderNumber.MasculinSingulier, false),
            ["Chauve-Souris"] = new FrenchName("Chauve-Souris", FrenchGenderNumber.FemininSingulier, false),
            ["Chèvre"] = new FrenchName("Chèvre", FrenchGenderNumber.FemininSingulier, false),
            ["Chien"] = new FrenchName("Chien", FrenchGenderNumber.MasculinSingulier, false),
            ["Chope"] = new FrenchName("Chope", FrenchGenderNumber.FemininSingulier, false),
            ["Cochon"] = new FrenchName("Cochon", FrenchGenderNumber.MasculinSingulier, false),
            ["Crâne"] = new FrenchName("Crâne", FrenchGenderNumber.MasculinSingulier, false),
            ["Crapaud"] = new FrenchName("Crapaud", FrenchGenderNumber.MasculinSingulier, false),
            ["Cruche"] = new FrenchName("Cruche", FrenchGenderNumber.FemininSingulier, false),
            ["Dague"] = new FrenchName("Dague", FrenchGenderNumber.FemininSingulier, false),
            ["Diable"] = new FrenchName("Diable", FrenchGenderNumber.MasculinSingulier, false),
            ["Djinn"] = new FrenchName("Djinn", FrenchGenderNumber.MasculinSingulier, false),
            ["Donjon"] = new FrenchName("Donjon", FrenchGenderNumber.MasculinSingulier, false),
            ["Dragon"] = new FrenchName("Dragon", FrenchGenderNumber.MasculinSingulier, false),
            ["Épée"] = new FrenchName("Épée", FrenchGenderNumber.FemininSingulier, true),
            ["Faon"] = new FrenchName("Faon", FrenchGenderNumber.MasculinSingulier, false),
            ["Fée"] = new FrenchName("Fée", FrenchGenderNumber.FemininSingulier, false),
            ["Garde"] = new FrenchName("Garde", FrenchGenderNumber.MasculinSingulier, false),
            ["Géant"] = new FrenchName("Géant", FrenchGenderNumber.MasculinSingulier, false),
            ["Gnome"] = new FrenchName("Gnome", FrenchGenderNumber.MasculinSingulier, false),
            ["Gobelin"] = new FrenchName("Gobelin", FrenchGenderNumber.MasculinSingulier, false),
            ["Gouffre"] = new FrenchName("Gouffre", FrenchGenderNumber.MasculinSingulier, false),
            ["Griffon"] = new FrenchName("Griffon", FrenchGenderNumber.MasculinSingulier, false),
            ["Hérisson"] = new FrenchName("Hérisson", FrenchGenderNumber.MasculinSingulier, false),
            ["Lion"] = new FrenchName("Lion", FrenchGenderNumber.MasculinSingulier, false),
            ["Loup"] = new FrenchName("Loup", FrenchGenderNumber.MasculinSingulier, false),
            ["Lynx"] = new FrenchName("Lynx", FrenchGenderNumber.MasculinSingulier, false),
            ["Marmotte"] = new FrenchName("Marmotte", FrenchGenderNumber.FemininSingulier, false),
            ["Nain"] = new FrenchName("Nain", FrenchGenderNumber.MasculinSingulier, false),
            ["Ogre"] = new FrenchName("Ogre", FrenchGenderNumber.MasculinSingulier, true),
            ["Oiseau"] = new FrenchName("Oiseau", FrenchGenderNumber.MasculinSingulier, true),
            ["Plume"] = new FrenchName("Plume", FrenchGenderNumber.FemininSingulier, false),
            ["Porc-Épic"] = new FrenchName("Porc-Épic", FrenchGenderNumber.MasculinSingulier, false),
            ["Prêtre"] = new FrenchName("Prêtre", FrenchGenderNumber.MasculinSingulier, false),
            ["Puits"] = new FrenchName("Puits", FrenchGenderNumber.MasculinSingulier, false),
            ["Rat"] = new FrenchName("Rat", FrenchGenderNumber.MasculinSingulier, false),
            ["Rat Musqué"] = new FrenchName("Rat Musqué", FrenchGenderNumber.MasculinSingulier, false),
            ["Renard"] = new FrenchName("Renard", FrenchGenderNumber.MasculinSingulier, false),
            ["Scorpion"] = new FrenchName("Scorpion", FrenchGenderNumber.MasculinSingulier, false),
            ["Souris"] = new FrenchName("Souris", FrenchGenderNumber.FemininSingulier, false),
            ["Taupe"] = new FrenchName("Taupe", FrenchGenderNumber.FemininSingulier, false),
            ["Valet"] = new FrenchName("Valet", FrenchGenderNumber.MasculinSingulier, false),
            ["Vaurien"] = new FrenchName("Vaurien", FrenchGenderNumber.MasculinSingulier, false),

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

            // Stores
            ["Aventurier"] = new FrenchName("Aventurier", FrenchGenderNumber.MasculinSingulier, true),
            ["Dame"] = new FrenchName("Dame", FrenchGenderNumber.FemininSingulier, false),
            ["Docteur"] = new FrenchName("Docteur", FrenchGenderNumber.MasculinSingulier, false),
            ["Empereur"] = new FrenchName("Empereur", FrenchGenderNumber.MasculinSingulier, true),
            ["Seigneur"] = new FrenchName("Seigneur", FrenchGenderNumber.MasculinSingulier, false),

            // General Stores
            ["Bazar"] = new FrenchName("Bazar", FrenchGenderNumber.MasculinSingulier, false),
            ["Commerce"] = new FrenchName("Commerce", FrenchGenderNumber.MasculinSingulier, false),
            ["Comptoir"] = new FrenchName("Comptoir", FrenchGenderNumber.MasculinSingulier, false),
            ["Dépôt"] = new FrenchName("Dépôt", FrenchGenderNumber.MasculinSingulier, false),
            ["Droguerie"] = new FrenchName("Droguerie", FrenchGenderNumber.FemininSingulier, false),
            ["Entrepôt"] = new FrenchName("Entrepôt", FrenchGenderNumber.MasculinSingulier, true),
            ["Épicerie"] = new FrenchName("Épicerie", FrenchGenderNumber.FemininSingulier, true),
            ["Équipement"] = new FrenchName("Équipement", FrenchGenderNumber.MasculinSingulier, true),
            ["Magasin d'Équipement"] = new FrenchName("Magasin d'Équipement", FrenchGenderNumber.MasculinSingulier, false),
            ["Marché"] = new FrenchName("Marché", FrenchGenderNumber.MasculinSingulier, false),
            ["Outils"] = new FrenchName("Outils", FrenchGenderNumber.MasculinPluriel, false),
            ["Outillage"] = new FrenchName("Outillage", FrenchGenderNumber.MasculinSingulier, true),
            ["Quincaillerie"] = new FrenchName("Quincaillerie", FrenchGenderNumber.FemininSingulier, false),
            ["Provisions"] = new FrenchName("Provisions", FrenchGenderNumber.FemininPluriel, false),
            ["Vivres"] = new FrenchName("Vivres", FrenchGenderNumber.MasculinPluriel, false),

            // Weapon Stores
            ["Armement"] = new FrenchName("Armement", FrenchGenderNumber.MasculinSingulier, true), // same as Weaponry
            ["Armurier"] = new FrenchName("Armurier", FrenchGenderNumber.MasculinSingulier, true),
            ["Armes"] = new FrenchName("Armes", FrenchGenderNumber.MasculinPluriel, false),         // same as Weapons
            ["Arsenal"] = new FrenchName("Arsenal", FrenchGenderNumber.MasculinSingulier, true),
            ["Épées"] = new FrenchName("Épées", FrenchGenderNumber.FemininPluriel, true),
            ["Forgeron"] = new FrenchName("Forgeron", FrenchGenderNumber.MasculinSingulier, false), // also used for Armor Stores
            ["Fourbisseur"] = new FrenchName("Fourbisseur", FrenchGenderNumber.MasculinSingulier, false),
            ["Métallurgie"] = new FrenchName("Métallurgie", FrenchGenderNumber.MasculinSingulier, false), // also used for Armor Stores

            // Armor Stores
            ["Armures"] = new FrenchName("Armures", FrenchGenderNumber.FemininPluriel, true),
            ["Armurerie"] = new FrenchName("Armurerie", FrenchGenderNumber.FemininSingulier, true),
            ["Armurier"] = new FrenchName("Armurier", FrenchGenderNumber.MasculinSingulier, true),
            ["Boucliers"] = new FrenchName("Boucliers", FrenchGenderNumber.MasculinPluriel, false),
            ["Chaudronnerie"] = new FrenchName("Chaudronnerie", FrenchGenderNumber.FemininSingulier, false),
            ["Égide"] = new FrenchName("Égide", FrenchGenderNumber.FemininSingulier, true),
            ["Ferronnerie"] = new FrenchName("Ferronnerie", FrenchGenderNumber.FemininSingulier, false),
            ["Forge"] = new FrenchName("Forge", FrenchGenderNumber.FemininSingulier, false),
            ["Mailles"] = new FrenchName("Mailles", FrenchGenderNumber.FemininPluriel, false),
            ["Protections"] = new FrenchName("Protections", FrenchGenderNumber.FemininPluriel, false),

            // Book Stores
            ["Bouquiniste"] = new FrenchName("Bouquiniste", FrenchGenderNumber.FemininSingulier, false),
            ["Centre de Documentation"] = new FrenchName("Centre de Documentation", FrenchGenderNumber.MasculinSingulier, false), // should be a library instead?
            ["Étal de Livres"] = new FrenchName("Étal de Livres", FrenchGenderNumber.MasculinSingulier, true),
            ["Incunables"] = new FrenchName("Incunables", FrenchGenderNumber.MasculinPluriel, false),
            ["Librairie"] = new FrenchName("Librairie", FrenchGenderNumber.FemininSingulier, false),
            ["Livres"] = new FrenchName("Livres", FrenchGenderNumber.MasculinPluriel, false),
            ["Marchand de Livres"] = new FrenchName("Marchand de Livres", FrenchGenderNumber.MasculinSingulier, false),
            ["Presse"] = new FrenchName("Presse", FrenchGenderNumber.MasculinSingulier, false),

            // Clothing Stores
            ["Costumes"] = new FrenchName("Costumes", FrenchGenderNumber.MasculinPluriel, false),
            ["Couturier"] = new FrenchName("Couturier", FrenchGenderNumber.MasculinSingulier, false),
            ["Ensembles"] = new FrenchName("Ensembles", FrenchGenderNumber.MasculinPluriel, true),
            ["Habillement"] = new FrenchName("Habillement", FrenchGenderNumber.MasculinSingulier, true),
            ["Habits"] = new FrenchName("Habits", FrenchGenderNumber.MasculinSingulier, true),
            ["Mode"] = new FrenchName("Mode", FrenchGenderNumber.FemininSingulier, false),
            ["Parures"] = new FrenchName("Parures", FrenchGenderNumber.FemininPluriel, false),
            ["Robes"] = new FrenchName("Robes", FrenchGenderNumber.MasculinPluriel, false),
            ["Tenues"] = new FrenchName("Tenues", FrenchGenderNumber.FemininPluriel, false),
            ["Uniformes"] = new FrenchName("Uniformes", FrenchGenderNumber.MasculinPluriel, true),
            ["Vêtements"] = new FrenchName("Vêtements", FrenchGenderNumber.MasculinSingulier, false),

            // Alchemy Stores
            ["Agents Médicinaux"] = new FrenchName("Agents Médicinaux", FrenchGenderNumber.MasculinPluriel, true),
            ["Alchimie"] = new FrenchName("Alchimie", FrenchGenderNumber.FemininSingulier, true),
            ["Antidotes"] = new FrenchName("Antidotes", FrenchGenderNumber.MasculinPluriel, true),
            ["Apothicaire"] = new FrenchName("Apothicaire", FrenchGenderNumber.MasculinSingulier, true),
            ["Chimie"] = new FrenchName("Chimie", FrenchGenderNumber.FemininSingulier, false),
            ["Cornue"] = new FrenchName("Cornue", FrenchGenderNumber.FemininSingulier, false),
            ["Élixirs"] = new FrenchName("Élixirs", FrenchGenderNumber.MasculinPluriel, true),
            ["Épices"] = new FrenchName("Épices", FrenchGenderNumber.FemininPluriel, true),
            ["Herbes"] = new FrenchName("Herbes", FrenchGenderNumber.FemininPluriel, true),
            ["Herbes Médicinales"] = new FrenchName("Herbes Médicinales", FrenchGenderNumber.FemininPluriel, true),
            ["Jardin Médicinal"] = new FrenchName("Jardin Médicinal", FrenchGenderNumber.MasculinSingulier, false),
            ["Médecines"] = new FrenchName("Médecines", FrenchGenderNumber.FemininPluriel, false),
            ["Médicaments"] = new FrenchName("Médicaments", FrenchGenderNumber.MasculinPluriel, false),
            ["Métallurgie"] = new FrenchName("Métallurgie", FrenchGenderNumber.FemininSingulier, false),
            ["Onguents"] = new FrenchName("Onguents", FrenchGenderNumber.MasculinPluriel, true),
            ["Pharmacopée"] = new FrenchName("Pharmacopée", FrenchGenderNumber.FemininPluriel, false),
            ["Pharmacie"] = new FrenchName("Pharmacie", FrenchGenderNumber.FemininSingulier, false),
            ["Physique"] = new FrenchName("Physique", FrenchGenderNumber.FemininSingulier, false),
            ["Potions"] = new FrenchName("Potions", FrenchGenderNumber.FemininPluriel, false),
            ["Produits Chimiques"] = new FrenchName("Produits Chimiques", FrenchGenderNumber.MasculinPluriel, false),
            ["Remèdes"] = new FrenchName("Remèdes", FrenchGenderNumber.MasculinPluriel, false),
            ["Solutions Alchimiques"] = new FrenchName("Solutions Alchimiques", FrenchGenderNumber.FemininPluriel, false),
            ["Teintures"] = new FrenchName("Teintures", FrenchGenderNumber.FemininPluriel, false),

            // Gems Stores
            ["Bijouterie"] = new FrenchName("Bijouterie", FrenchGenderNumber.FemininSingulier, false),
            ["Bijoux"] = new FrenchName("Bijoux", FrenchGenderNumber.MasculinPluriel, false),
            ["Boîte à Bijoux"] = new FrenchName("Boîte à Bijoux", FrenchGenderNumber.FemininSingulier, false),
            ["Boutique de Bijoux"] = new FrenchName("Boutique de Bijoux", FrenchGenderNumber.FemininSingulier, false),
            ["Gemmes"] = new FrenchName("Gemmes", FrenchGenderNumber.FemininPluriel, false),
            ["Joaillerie"] = new FrenchName("Joaillerie", FrenchGenderNumber.FemininSingulier, false),
            ["Joaillers"] = new FrenchName("Joaillers", FrenchGenderNumber.MasculinPluriel, false),
            ["Pierres Fines"] = new FrenchName("Pierres Fines", FrenchGenderNumber.FemininPluriel, false),
            ["Pierres Précieuses"] = new FrenchName("Pierres Précieuses", FrenchGenderNumber.FemininPluriel, false),
            ["Tailleur de Gemmes"] = new FrenchName("Tailleur de Gemmes", FrenchGenderNumber.MasculinSingulier, false),

            // Pawn Shops
            ["Antiquités"] = new FrenchName("Antiquités", FrenchGenderNumber.FemininPluriel, true),
            ["Crédit sur Gages"] = new FrenchName("Crédit sur Gages", FrenchGenderNumber.MasculinSingulier, false),
            ["Équipement Usagé"] = new FrenchName("Équipement Usagé", FrenchGenderNumber.MasculinSingulier, true),
            ["Fournitures Usagées"] = new FrenchName("Fournitures Usagées", FrenchGenderNumber.FemininPluriel, false),
            ["Mont-de-Piété"] = new FrenchName("Mont-de-Piété", FrenchGenderNumber.MasculinSingulier, false),
            ["Occasions"] = new FrenchName("Occasions", FrenchGenderNumber.FemininPluriel, true),
            ["Prêteur sur Gages"] = new FrenchName("Prêteur sur Gages", FrenchGenderNumber.MasculinSingulier, false),
            ["Secondes Mains"] = new FrenchName("Secondes Mains", FrenchGenderNumber.FemininPluriel, false),

            // Furniture Stores
            ["Ameublement"] = new FrenchName("Ameublement", FrenchGenderNumber.MasculinSingulier, true),
            ["Artisan"] = new FrenchName("Artisan", FrenchGenderNumber.MasculinSingulier, true),
            ["Charpentier"] = new FrenchName("Charpentier", FrenchGenderNumber.MasculinSingulier, false),
            ["Décoration"] = new FrenchName("Décoration", FrenchGenderNumber.FemininSingulier, false),
            ["Décoration d'intérieur"] = new FrenchName("Décoration d'intérieur", FrenchGenderNumber.FemininSingulier, false),
            ["Marqueterie"] = new FrenchName("Marqueterie", FrenchGenderNumber.FemininSingulier, false),
            ["Menuiserie"] = new FrenchName("Menuiserie", FrenchGenderNumber.FemininSingulier, false),
            ["Meubles"] = new FrenchName("Meubles", FrenchGenderNumber.MasculinPluriel, false),
            ["Mobilier"] = new FrenchName("Mobilier", FrenchGenderNumber.MasculinSingulier, false),

            // Libraries
            ["Archives"] = new FrenchName("Archives", FrenchGenderNumber.FemininPluriel, true),
            ["Athénée"] = new FrenchName("Athénée", FrenchGenderNumber.FemininSingulier, true),
            ["Bibliothèque"] = new FrenchName("Bibliothèque", FrenchGenderNumber.FemininSingulier, false),
            ["Bibliothèque Publique"] = new FrenchName("Bibliothèque Publique", FrenchGenderNumber.FemininSingulier, false),
            ["Lycée"] = new FrenchName("Lycée", FrenchGenderNumber.MasculinSingulier, false),
            ["Salle de Lecture"] = new FrenchName("Salle de Lecture", FrenchGenderNumber.FemininSingulier, false),
            ["Séminaire"] = new FrenchName("Séminaire", FrenchGenderNumber.MasculinSingulier, false)
        };

        private readonly static Dictionary<string, FrenchAdjective> Adjectives = new Dictionary<string, FrenchAdjective>
        {
            // Taverns
            ["Agité"] = new FrenchAdjective("Agité", "Agitée", "Agités", "Agitées"),
            ["Argenté"] = new FrenchAdjective("Argenté", "Argentée", "Argentés", "Argentées"),
            ["Assoiffé"] = new FrenchAdjective("Assoiffé", "Assoiffée", "Assoiffés", "Assoiffées"),
            ["Blanc"] = new FrenchAdjective("Blanc", "Blanche", "Blancs", "Blanches"),
            ["Chanceux"] = new FrenchAdjective("Chanceux", "Chanceuse", "Chanceux", "Chanceuses"),
            ["Cramoisi"] = new FrenchAdjective("Cramoisi", "Cramoisie", "Cramoisis", "Cramoisies"),
            ["Criant"] = new FrenchAdjective("Criant", "Criante", "Criants", "Criantes"),
            ["Dansant"] = new FrenchAdjective("Dansant", "Dansante", "Dansants", "Dansantes"),
            ["Doré"] = new FrenchAdjective("Doré", "Dorée", "Dorés", "Dorées"),
            ["Hurlant"] = new FrenchAdjective("Hurlant", "Hurlante", "Hurlants", "Hurlantes"),
            ["Malchanceux"] = new FrenchAdjective("Malchanceux", "Malchanceuse", "Malchanceux", "Malchanceuses"),
            ["Mort"] = new FrenchAdjective("Mort", "Morte", "Morts", "Mortes"),
            ["Noir"] = new FrenchAdjective("Noir", "Noire", "Noirs", "Noires"),
            ["Riant"] = new FrenchAdjective("Riant", "Riante", "Riants", "Riantes"),
            ["Rouge"] = new FrenchAdjective("Rouge", "Rouge", "Rouges", "Rouges"),
            ["Rouillé"] = new FrenchAdjective("Rouillé", "Rouillée", "Rouillés", "Rouillées"),
            ["Sale"] = new FrenchAdjective("Sale", "Sale", "Sales", "Sales"),
            ["Sauvage"] = new FrenchAdjective("Sauvage", "Sauvage", "Sauvages", "Sauvages"),
            ["Vert"] = new FrenchAdjective("Vert", "Verte", "Verts", "Vertes"),
            ["Volant"] = new FrenchAdjective("Volant", "Volante", "Volants", "Volantes"),

            // Stores
            ["de Qualité"] = new FrenchAdjective("de Qualité", "de Qualité", "de Qualité", "de Qualité"),
            ["de Première Classe"] = new FrenchAdjective("de Première Classe", "de Première Classe", "de Première Classe", "de Première Classe"),
            ["Général"] = new FrenchAdjective("Général", "Générale", "Généraux", "Généraux"),
            ["Indispensable"] = new FrenchAdjective("Indispensable", "Indispensable", "Indispensables", "Indispensables"),
            ["Inégalé"] = new FrenchAdjective("Inégalé", "Inégalée", "Inégalés", "Inégalées"),
            ["Meilleur"] = new FrenchAdjective("Meilleur", "Meilleure", "Meilleurs", "Meilleures", true),
            ["Négocié"] = new FrenchAdjective("Négocié", "Négociée", "Négociés", "Négociées"),
            ["Raffiné"] = new FrenchAdjective("Raffiné", "Raffinée", "Raffinés", "Raffinées"),
            ["Singulier"] = new FrenchAdjective("Singulier", "Singulière", "Singuliers", "Singulières"),
            ["Supérieur"] = new FrenchAdjective("Supérieur", "Supérieure", "Supérieurs", "Supérieures"),
            ["Surprenant"] = new FrenchAdjective("Surprenant", "Surprenante", "Surprenants", "Surprenantes"),
            ["Traditionnel"] = new FrenchAdjective("Traditionnel", "Traditionnelle", "Traditionnels", "Traditionnelles")
        };

        public override FrenchName LookupMaybeName(string frenchNameString)
        {
            if(Names.TryGetValue(frenchNameString, out var frenchName)) {
                return frenchName;
            }
            return null;
        }

        public override FrenchAdjective LookupMaybeAdjective(string frenchAdjectiveString)
        {
            if(Adjectives.TryGetValue(frenchAdjectiveString, out var frenchAdjective)) {
                return frenchAdjective;
            }
            return null;
        }

        public override FrenchName LookupName(string frenchNameString) {
            if(Names.TryGetValue(frenchNameString, out var frenchName)) {
                return frenchName;
            }
            Debug.LogWarningFormat("Couldn't find name {0}", frenchNameString);
            return MissingFrenchName(frenchNameString);
        }

        public override FrenchAdjective LookupAdjective(string frenchAdjectiveString) {
            if(Adjectives.TryGetValue(frenchAdjectiveString, out var frenchAdjective)) {
                return frenchAdjective;
            }
            Debug.LogWarningFormat("Couldn't find adjective {0}", frenchAdjectiveString);
            return MissingFrenchAdjective(frenchAdjectiveString);
        }
    }
}
