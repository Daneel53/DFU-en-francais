using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Game.Formulas;
using DaggerfallConnect;
using DaggerfallConnect.Arena2;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game.Utility;
using DaggerfallWorkshop.Utility;
using System;
using System.Text.RegularExpressions;
using System.Globalization;

namespace PFDMainMod
{
    public class PFDMain : MonoBehaviour
    {
        private static Mod mod;

        private static readonly CultureInfo frenchCulture = CultureInfo.GetCultureInfo("fr-FR");

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;

            var go = new GameObject(mod.Title);
            go.AddComponent<PFDMain>();
        }

        private void Awake()
        {
            Debug.Log("Begin mod init: ProjectFrenchDaggerfall");
            FormulaHelper.RegisterOverride(mod, "GenerateBuildingName", (Func<int, DFLocation.BuildingTypes, int, string, string, string>) PFDGenerateBuildingName);
            Debug.Log("Finished mod init: ProjectFrenchDaggerfall");
            mod.IsReady = true;
        }

                /// <summary>
        /// Construct a procedural building name from parts. See link below for more details how Daggerfall does this.
        /// https://www.dfworkshop.net/building-names/
        /// Unfortunately the default process does not translate well into other languages.
        /// This overridable formula allows a translation mod to supply a whole new method that works for their specific language.
        /// Replacement process can operate using whatever rules and string inputs it needs to produce valid results.
        /// NOTES:
        ///  * Discovered building names are cached to DiscoveryData.txt in user saves. Old names may appear while testing.
        ///  * Use "refresh_buildingnames" from console to regenerate discovered building names in current location only.
        ///  * Delete DiscoveryData.txt from save to erase all discovered building names.
        ///  * Use "map_revealbuildings" from console to temporarily reveal undiscovered building names (not added to DiscoveryData.txt).
        ///  * While testing, you may need to reload a save or close and restart game for some changes to appear.
        /// </summary>
        /// <param name="seed">Seed value from source building.</param>
        /// <param name="type">Source building type (e.g. GeneralStore, WeaponSmith).</param>
        /// <param name="factionID">Associated faction ID of source building.</param>
        /// <param name="locationName">Location containing source building. Used for some names, e.g. "Penbrugh Alchemistry".</param>
        /// <param name="regionName">Region containing source building. Used for some names, e.g. "Bank of Daggerfall".</param>
        /// <returns></returns>
        public static string PFDGenerateBuildingName(int seed, DFLocation.BuildingTypes type, int factionID, string locationName, string regionName)
        {
            DFRandom.srand(seed);
            switch (type)
            {
                case DFLocation.BuildingTypes.HouseForSale:
                    return HouseForSaleName();
                case DFLocation.BuildingTypes.Tavern:
                    return TavernName(locationName);
                case DFLocation.BuildingTypes.GeneralStore:
                    return GeneralStoreName(locationName);
                case DFLocation.BuildingTypes.WeaponSmith:
                    return WeaponSmithName(locationName);
                case DFLocation.BuildingTypes.Armorer:
                    return ArmorerName(locationName);
                case DFLocation.BuildingTypes.Bookseller:
                    return BooksellerName(locationName);
                case DFLocation.BuildingTypes.ClothingStore:
                    return ClothingStoreName(locationName);
                case DFLocation.BuildingTypes.Alchemist:
                    return AlchemistName(locationName);
                case DFLocation.BuildingTypes.GemStore:
                    return GemStoreName(locationName);
                case DFLocation.BuildingTypes.PawnShop:
                    return PawnShopName(locationName);
                case DFLocation.BuildingTypes.FurnitureStore:
                    return FurnitureStoreName(locationName);
                case DFLocation.BuildingTypes.Library:
                    return LibraryName(locationName);
                case DFLocation.BuildingTypes.Bank:
                    return BankName(locationName, regionName);
                case DFLocation.BuildingTypes.GuildHall:
                    return GuildHallName(factionID, locationName);
                case DFLocation.BuildingTypes.Temple:
                    return TempleName(factionID, locationName);
                case DFLocation.BuildingTypes.Palace:
                    return PalaceName(locationName);
                default:
                    return string.Empty;// Do nothing for unknown/unsupported building type
                                        // Houses can actually change names based on active quests
            }
        }

        private static string HouseForSaleName()
        {
            return TextManager.Instance.GetLocalizedText("houseForSale");
        }

        private static string TavernName(string locationName)
        {
            string[] TavernsB = TextManager.Instance.GetLocalizedTextList("TavernsB");
            string[] TavernsA = TextManager.Instance.GetLocalizedTextList("TavernsA");
            string b = RandomAmong(TavernsB);
            string a = RandomAmong(TavernsA);
            Match matchTwoNames = Regex.Match(a, "^The (.*) and$");
            if (matchTwoNames.Success)
                return PostProcess(string.Format("{0} et {1}", FrenchNameWithArticle(matchTwoNames.Groups[1].Value), FrenchNameWithArticle(b)));
            Match matchAdjectiveName = Regex.Match(a, "The (.*)$");
            if (matchAdjectiveName.Success)
                return PostProcess(ExpandMacros(FrenchNameWithArticleAndAdjective(matchAdjectiveName.Groups[1].Value, b), locationName));
            throw new ArgumentException(string.Format("Unexpected tavern name pattern {0}", a));
        }
        private static string GeneralStoreName(string locationName)
        {
            string[] GeneralStoresB = TextManager.Instance.GetLocalizedTextList("GeneralStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(GeneralStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string WeaponSmithName(string locationName)
        {
            string[] WeaponStoresB = TextManager.Instance.GetLocalizedTextList("WeaponStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(WeaponStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string ArmorerName(string locationName)
        {
            string[] ArmorStoresB = TextManager.Instance.GetLocalizedTextList("ArmorStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(ArmorStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string BooksellerName(string locationName)
        {
            string[] BookStoresB = TextManager.Instance.GetLocalizedTextList("BookStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(BookStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string ClothingStoreName(string locationName)
        {
            string[] ClothingStoresB = TextManager.Instance.GetLocalizedTextList("ClothingStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(ClothingStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string AlchemistName(string locationName)
        {
            string[] AlchemyStoresB = TextManager.Instance.GetLocalizedTextList("AlchemyStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(AlchemyStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string GemStoreName(string locationName)
        {
            string[] GemStoresB = TextManager.Instance.GetLocalizedTextList("GemStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(GemStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string PawnShopName(string locationName)
        {
            string[] PawnStoresB = TextManager.Instance.GetLocalizedTextList("PawnStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(PawnStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string FurnitureStoreName(string locationName)
        {
            string[] FurnitureStoresB = TextManager.Instance.GetLocalizedTextList("FurnitureStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(FurnitureStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string LibraryName(string locationName)
        {
            string[] LibraryStoresB = TextManager.Instance.GetLocalizedTextList("LibraryStoresB");
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            string b = RandomAmong(LibraryStoresB);
            string a = RandomAmong(StoresA);
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string BankName(string locationName, string regionName)
        {
            // Banks always appear to be named "The Bank of RegionName"
            string b = regionName;
            string a = TextManager.Instance.GetLocalizedText("theBankOf");
            return string.Format("(French) {0} {1}", ExpandMacros(a, locationName), b);
        }

        private static string GuildHallName(int factionID, string locationName)
        {
            // Guild halls get the name from faction data
            if (GameManager.Instance.PlayerEntity.FactionData.GetFactionData(factionID, out FactionFile.FactionData factionData))
            {
                string a = factionData.name;
                return string.Format("(French) {0}", ExpandMacros(a, locationName));
            }
            return string.Empty;
        }

        private static string TempleName(int factionID, string locationName)
        {
            // Temples get name from faction data - always seem to be first child of factionID
            if (GameManager.Instance.PlayerEntity.FactionData.GetFactionData(factionID, out FactionFile.FactionData factionData))
            {
                if (factionData.children.Count > 0)
                {
                    if (GameManager.Instance.PlayerEntity.FactionData.GetFactionData(factionData.children[0], out FactionFile.FactionData firstChild))
                    {
                        string a = firstChild.name;
                        return string.Format("(French) {0}", ExpandMacros(a, locationName));
                    }
                }
            }
            return string.Empty;
        }

        private static string PalaceName(string locationName)
        {
            // Main palace names come from TEXT.RSC (e.g. "Castle Daggerfall")
            // Other palaces are just named "Palace"
            int textId = 0;
            if (locationName == TextManager.Instance.GetLocalizedText("daggerfall"))
                textId = 475;
            else if (locationName == TextManager.Instance.GetLocalizedText("wayrest"))
                textId = 476;
            else if (locationName == TextManager.Instance.GetLocalizedText("sentinel"))
                textId = 477;

            string a = string.Empty;
            if (textId > 0)
            {
                TextFile.Token[] nameTokens = DaggerfallUnity.Instance.TextProvider.GetRSCTokens(textId);
                foreach (TextFile.Token token in nameTokens)
                {
                    if (token.formatting == TextFile.Formatting.Text)
                    {
                        a = token.text;
                        break;
                    }
                }
                a = a.TrimEnd('.'); // remove character '.' from castle text record entry if it is last character
            }
            else
            {
                a = TextManager.Instance.GetLocalizedText("palace");
            }
            return string.Format("(French) {0}", ExpandMacros(a, locationName));
        }

        private static string RandomAmong(string[] alternatives) {
            return alternatives[DFRandom.random_range(0, alternatives.Length)];
        }

        private static string FrenchNameWithArticle(string englishName)
        {
            var frenchName = EnglishFrenchDictionary.NameTranslations[englishName];
            string article = FrenchArticle(frenchName);
            return string.Format("{0}{1}", article, frenchName.name);
        }

        private static string FrenchNameWithArticleAndAdjective(string englishAdjective, string englishName)
        {
            var frenchName = EnglishFrenchDictionary.NameTranslations[englishName];
            var adjective = EnglishFrenchDictionary.AdjectiveTranslations[englishAdjective];
            string article = FrenchArticle(frenchName);
            return string.Format("{0}{1} {2}", article, frenchName.name, adjective.variants[frenchName.gender]);
        }

        private static string FrenchArticle(EnglishFrenchDictionary.FrenchName frenchName)
        {
            switch (frenchName.gender)
            {
                case EnglishFrenchDictionary.FrenchGender.Masculin:
                    return frenchName.elidedArticle ? "l'" : "le ";
                case EnglishFrenchDictionary.FrenchGender.Feminin:
                    return frenchName.elidedArticle ? "l'" : "la ";
                default:
                    throw new ArgumentException("Unhandled FrenchGender");
            }
        }

        private static string PostProcess(string v)
        {
            string elidedDeLe = Regex.Replace(v, "de le", "du");
            return CapitalLetter(elidedDeLe);
        }

        private static string CapitalLetter(string v)
        {
            return string.IsNullOrEmpty(v) ? v : v.Substring(0, 1).ToUpper(frenchCulture) + v.Substring(1);
        }

        private static string ExpandMacros(string name, string locationName)
        {
            const string firstNameTitleVar = "%ef";
            const string cityNameTitleVar = "%cn";
            const string royalTitleVar = "%rt";

            // Replace %cn
            name = name.Replace(cityNameTitleVar, locationName);

            // Replace %ef
            if (name.Contains(firstNameTitleVar))
            {
                // Need to burn a rand() for %ef roll to be correct.
                // Classic is always doing this when expanding a macro.
                DFRandom.rand();

                // In classic, the function expanding the %ef macro uses a global variable containing the current
                // region race. However, this variable is never updated when the character travels
                // and remains at 0. This explains why the Breton name bank is always used for shops.
                // This global variable is probably a leftover from Daggerfall early development as,
                // with the exception of %lp, which presents a similar issue and always returns
                // "High Rock", all naming functions use a global array of 62 fixed race values, one for each region.
                // As with %lp, we choose to fix the original bug in DFU and use this array, meaning that
                // all shops in Hammerfell now use Redguard names.
                NameHelper.BankTypes nameBank = (NameHelper.BankTypes)MapsFile.RegionRaces[GameManager.Instance.PlayerGPS.CurrentRegionIndex];
                string firstName = DaggerfallUnity.Instance.NameHelper.FirstName(nameBank, DaggerfallWorkshop.Game.Entity.Genders.Male);
                name = name.Replace(firstNameTitleVar, firstName);
            }

            // Replace %rt based on faction ruler
            if (name.Contains(royalTitleVar))
            {
                name = name.Replace(royalTitleVar, MacroHelper.RegentTitle(null));
            }

            return name;
        }
    }
}
