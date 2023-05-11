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
        };

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
