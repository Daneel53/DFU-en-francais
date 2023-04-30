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

namespace PFDMainMod
{
    public class PFDMain : MonoBehaviour
    {
        private static Mod mod;

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
            string a = string.Empty, b = string.Empty;
            string result = string.Empty;

            bool singleton = false;
            FactionFile.FactionData factionData;
            DFRandom.srand(seed);
            string[] StoresA = TextManager.Instance.GetLocalizedTextList("StoresA");
            switch (type)
            {
                case DFLocation.BuildingTypes.HouseForSale:
                    return TextManager.Instance.GetLocalizedText("houseForSale");

                case DFLocation.BuildingTypes.Tavern:
                    string[] TavernsB = TextManager.Instance.GetLocalizedTextList("TavernsB");
                    string[] TavernsA = TextManager.Instance.GetLocalizedTextList("TavernsA");
                    b = TavernsB[DFRandom.random_range(0, TavernsB.Length)];
                    a = TavernsA[DFRandom.random_range(0, TavernsA.Length)];
                    break;

                case DFLocation.BuildingTypes.GeneralStore:
                    string[] GeneralStoresB = TextManager.Instance.GetLocalizedTextList("GeneralStoresB");
                    b = GeneralStoresB[DFRandom.random_range(0, GeneralStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.WeaponSmith:
                    string[] WeaponStoresB = TextManager.Instance.GetLocalizedTextList("WeaponStoresB");
                    b = WeaponStoresB[DFRandom.random_range(0, WeaponStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.Armorer:
                    string[] ArmorStoresB = TextManager.Instance.GetLocalizedTextList("ArmorStoresB");
                    b = ArmorStoresB[DFRandom.random_range(0, ArmorStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.Bookseller:
                    string[] BookStoresB = TextManager.Instance.GetLocalizedTextList("BookStoresB");
                    b = BookStoresB[DFRandom.random_range(0, BookStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.ClothingStore:
                    string[] ClothingStoresB = TextManager.Instance.GetLocalizedTextList("ClothingStoresB");
                    b = ClothingStoresB[DFRandom.random_range(0, ClothingStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.Alchemist:
                    string[] AlchemyStoresB = TextManager.Instance.GetLocalizedTextList("AlchemyStoresB");
                    b = AlchemyStoresB[DFRandom.random_range(0, AlchemyStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.GemStore:
                    string[] GemStoresB = TextManager.Instance.GetLocalizedTextList("GemStoresB");
                    b = GemStoresB[DFRandom.random_range(0, GemStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.PawnShop:
                    string[] PawnStoresB = TextManager.Instance.GetLocalizedTextList("PawnStoresB");
                    b = PawnStoresB[DFRandom.random_range(0, PawnStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.FurnitureStore:
                    string[] FurnitureStoresB = TextManager.Instance.GetLocalizedTextList("FurnitureStoresB");
                    b = FurnitureStoresB[DFRandom.random_range(0, FurnitureStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.Library:
                    string[] LibraryStoresB = TextManager.Instance.GetLocalizedTextList("LibraryStoresB");
                    b = LibraryStoresB[DFRandom.random_range(0, LibraryStoresB.Length)];
                    a = StoresA[DFRandom.random_range(0, StoresA.Length)];
                    break;

                case DFLocation.BuildingTypes.Bank:
                    // Banks always appear to be named "The Bank of RegionName"
                    b = regionName;
                    a = TextManager.Instance.GetLocalizedText("theBankOf");
                    break;

                case DFLocation.BuildingTypes.GuildHall:
                    // Guild halls get the name from faction data
                    if (GameManager.Instance.PlayerEntity.FactionData.GetFactionData(factionID, out factionData))
                    {
                        a = factionData.name;
                        singleton = true;
                    }
                    break;

                case DFLocation.BuildingTypes.Temple:
                    // Temples get name from faction data - always seem to be first child of factionID
                    if (GameManager.Instance.PlayerEntity.FactionData.GetFactionData(factionID, out factionData))
                    {
                        if (factionData.children.Count > 0)
                        {
                            FactionFile.FactionData firstChild;
                            if (GameManager.Instance.PlayerEntity.FactionData.GetFactionData(factionData.children[0], out firstChild))
                            {
                                a = firstChild.name;
                                singleton = true;
                            }
                        }
                    }
                    break;

                case DFLocation.BuildingTypes.Palace:
                    // Main palace names come from TEXT.RSC (e.g. "Castle Daggerfall")
                    // Other palaces are just named "Palace"
                    int textId = 0;
                    if (locationName == TextManager.Instance.GetLocalizedText("daggerfall"))
                        textId = 475;
                    else if (locationName == TextManager.Instance.GetLocalizedText("wayrest"))
                        textId = 476;
                    else if (locationName == TextManager.Instance.GetLocalizedText("sentinel"))
                        textId = 477;

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
                    singleton = true;
                    break;

                default:
                    // Do nothing for unknown/unsupported building type
                    // Houses can actually change names based on active quests
                    return string.Empty;
            }

            a = ExpandMacros(a, locationName);

            // Final text is "{a} {b}" for two-part names or just "{a}" for singleton names
            if (!singleton)
                result = string.Format("(French) {0} {1}", a, b);
            else
                result = string.Format("(French) {0}", a);

            return result;
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
