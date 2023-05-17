using UnityEngine;
using System.Collections.Generic;
using DaggerfallWorkshop.Utility;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using System.IO;

namespace PFDMainMod
{
    public class FrenchDictionary : FrenchGenerator
    {
        private readonly Dictionary<string, FrenchName> Names;

        private readonly Dictionary<string, FrenchAdjective> Adjectives;
        private readonly string frenchNamesTableFilename = "FrenchNames.txt";
        private readonly string frenchAdjectivesTableFilename = "FrenchAdjectives.txt";
        const string csvExt = ".txt";
        const string textString = "Text";

        public FrenchDictionary()
        {
            Names = new Dictionary<string, FrenchName>();
            string frenchNamesTableText = GetTextAsset(frenchNamesTableFilename);
            if (frenchNamesTableText != null)
            {
                Table frenchNamesTable = new Table(frenchNamesTableText);
                for (int i = 0; i <frenchNamesTable.RowCount; i++)
                {
                    string[] row = frenchNamesTable.GetRow(i);
                    FrenchGenderNumber gender = default;
                    switch (row[1].Substring(0, 2)) {
                        case "MS":
                            gender = FrenchGenderNumber.MasculinSingulier;
                            break;
                        case "FS":
                            gender = FrenchGenderNumber.FemininSingulier;
                            break;
                        case "MP":
                            gender = FrenchGenderNumber.MasculinPluriel;
                            break;
                        case "FP":
                            gender = FrenchGenderNumber.FemininPluriel;
                            break;
                        default:
                            Debug.LogWarningFormat("{0}: unrecognized gender for {1}: {2}", frenchNamesTableFilename, row[0], row[1]);
                            break;
                    }

                    bool isArticleOmitted = row[1].Substring(2).Contains("O");
                    bool isArticleElided = row[1].Substring(2).Contains("E");
                    ArticleMode articleMode = isArticleOmitted ? ArticleMode.Omitted : (isArticleElided ? ArticleMode.Elided : ArticleMode.Normal);
                    FrenchName name = new FrenchName(row[0], gender, articleMode);
                    Names.Add(row[0], name);
                }
            }
            Debug.LogFormat("Read {0} french names", Names.Count);

            Adjectives = new Dictionary<string, FrenchAdjective>();
            string frenchAdjectivesTableText = GetTextAsset(frenchAdjectivesTableFilename);
            if (frenchAdjectivesTableText != null)
            {
                Table frenchAdjectivesTable = new Table(frenchAdjectivesTableText);
                for (int i = 0; i <frenchAdjectivesTable.RowCount; i++)
                {
                    string[] row = frenchAdjectivesTable.GetRow(i);
                    FrenchAdjective adjective = new FrenchAdjective(row[0], row[1], row[2], row[3], row[4] == "true");
                    Adjectives.Add(row[0], adjective);
                }
            }
            Debug.LogFormat("Read {0} french adjectives", Adjectives.Count);
        }

        private static string GetTextAsset(string filename)
        {
            if (ModManager.Instance != null && ModManager.Instance.TryGetAsset(filename, false, out TextAsset csvTextAsset))
            {
                return csvTextAsset.text;
            }
            else
            {
                if (!filename.EndsWith(csvExt))
                    filename += csvExt;

                // Load patch file if present
                string path = Path.Combine(Application.streamingAssetsPath, textString, filename);
                if (File.Exists(path))
                    return ReadAllText(path);
                else
                    return null;
            }
        }

        static string ReadAllText(string file)
        {
            using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var textReader = new StreamReader(fileStream))
                return textReader.ReadToEnd();
        }

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
