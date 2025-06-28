// Project:         French grammar processor for Daggerfall Unity
// Copyright:       Copyright (C) 2025 Daneel53
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Source Code:     
// Author: Daneel53

using DaggerfallWorkshop.Game.Utility.ModSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DaggerfallWorkshop.Game.Entity;

namespace DaggerfallWorkshop.Localization.LanguageRules
{
    public class FrenchGrammarRules : GrammarRules
    {
        // List of possible genders and numbers in French.
        // M: Masculine, F: Feminine, S: Singular, P: Plural
        // Change this if needed for other languages.
        static readonly List<string> GenderNums = new List<String> { "MS", "MP", "FS", "FP" };

        static string curGenderNum = "MS";   // Current genderNum, default value
        static bool isMale;
        static bool isSingular;
        static bool genderDefined;
        static bool hAspiré;
        static bool adjectiveBeforeWord;
        static bool genderNumFound;
        public enum TokenType
        {
            Unknown, NotFound,
            Article, GenderNum, Adjective, HeroGender, HAspiré, IsPlural, Number, NPCGender,
            DFUToken
        }
        public static bool checkAArticle;
        public static bool checkDeArticle;

        public static Func<Genders> MyNPCGenderGetter;
        public static Func<Genders> MyHeroGenderGetter;

        public override string ProcessGrammar(string sourceText)
        {
            int cursorPos;          // Pos of char just after }
            string token;           // Token without {} (ex : ".de")
            string tokenContent;    // Complete string inside {}, but without "."
            int bPos;               // Pos of {
            string processedText;   // 
            TokenType tokenType;
            string adjective;
            string wordAfterGender;
            bool genderFind;
            string lowerToken;

            //-------------------------------------------------------
            // If no grammar token in the source text, output = input
            //-------------------------------------------------------

            if (sourceText.IndexOf("{", 0) == -1) return sourceText;

            //-----------
            // Init bools
            //-----------

			hAspiré = false;
			genderDefined = false;
            genderNumFound = false;
			isMale = true;
			isSingular = true;

            //-----------------------------------
            // Analyze source text token by token
            //-----------------------------------

            int startIndex = 0;
            processedText = "";
            tokenContent = "";
            wordAfterGender = "";
            bPos = 0;
            cursorPos = 0;

            tokenType = GetNextToken(sourceText, startIndex, ref bPos, ref cursorPos, ref tokenContent, ref wordAfterGender);
            while (tokenType != TokenType.NotFound)
            {
                // Prepare processedText
                processedText += sourceText.Substring(startIndex, bPos - startIndex);

                switch (tokenType)
                {
                    case TokenType.HeroGender:
                        Handle_ManWoman_Hero(tokenContent, ref processedText);
                        break;

                    case TokenType.NPCGender:
                        Handle_NPCGender(tokenContent, ref processedText);
                        break;

                    case TokenType.IsPlural:
                        Handle_IsPlural(tokenContent, ref processedText);
                        break;

                    case TokenType.Number:
                        Handle_Number(tokenContent, ref processedText);
                        break;

                    case TokenType.Unknown:
                        //processedText += " -Unknown token: " + tokenContent + " - ";
                        processedText += " -UT: " + sourceText + " - ";
                        break;

                    case TokenType.Adjective:
                        adjective = tokenContent;
                        if (genderNumFound == false)
                        {
                            // Adjective is before the related word.
                            // We must find the next gender token.
                            GetNextGenderNum(sourceText, cursorPos, ref wordAfterGender);
                        }
                        Handle_adjective(wordAfterGender, adjectiveBeforeWord, adjective, ref processedText);
                        break;

                    case TokenType.GenderNum:
                        curGenderNum = tokenContent;
                        Handle_Gender_Prefix();
                        processedText += wordAfterGender;
                        cursorPos += wordAfterGender.Length;
                        break;

                    case TokenType.HAspiré:
                        hAspiré = true;
                        break;

                    case TokenType.Article:
                        // New article, search for related gender
                        genderFind = GetNextGenderNum(sourceText, cursorPos, ref wordAfterGender);
                        if (!genderFind)
                        {
                            // No gender found (should not happen)
                            // Should not happen, apart token {.le} after the related word
                            // Ex: Prend {.le}%item et ramène {.le}
							// Gender and number stay as last defined.
							wordAfterGender = "";
                        }

                        token = tokenContent;
                        lowerToken = token.ToLower();
                        checkAArticle = false;
                        checkDeArticle = false;

                        switch (lowerToken)
                        {
                            //---------
                            // Prefixes
                            //---------

                            case "le":
                                //Debug.Log("PGrammar - Token le, " + "sourceText : " + sourceText + " word : " + wordAfterGender);
                                Handle_le_Prefix(wordAfterGender, token, ref processedText);
                                break;

                            case "un":
                                Handle_un_Prefix(token, ref processedText);
                                break;

                            case "ce":
                                Handle_ce_Prefix(wordAfterGender, token, ref processedText);
                                break;

                            case "de":
                                Handle_de_Prefix(wordAfterGender, token, ref processedText);
                                break;

                            case "deit":
                                Handle_deIt_Prefix(wordAfterGender, token, ref processedText);
                                break;

                            case "du":
                                Handle_du_Prefix(wordAfterGender, token, ref processedText);
                                break;

                            case "à":
                                Handle_a_Prefix(wordAfterGender, token, ref processedText);
                                break;

                            case "mon":
                                Handle_mon_Prefix(wordAfterGender, token, ref processedText);
                                break;

                            case "ton":
                                Handle_ton_Prefix(wordAfterGender, token, ref processedText);
                                break;

                            case "son":
                                Handle_son_Prefix(wordAfterGender, token, ref processedText);
                                break;

                            //---------
                            // Suffixes
                            //---------

                            case "min":
                                Handle_min_Suffix(ref processedText, token);
                                break;

                            case "maj":
                                Handle_Maj_Suffix(ref processedText);
                                break;								
                        }
                        break;
                }

				// Search next token
				//------------------
				startIndex = cursorPos;
				tokenType = GetNextToken(sourceText, startIndex, ref bPos, ref cursorPos, ref tokenContent, ref wordAfterGender);
            }
            
            // Add the end of sourceText after the last token
            processedText += sourceText.Substring(startIndex);
			
			// Special cases in French where some double articles must be condensed:
			// Je bois de le vin -> Je bois du vin
			// Etc.
			// Better to do that when the ProcessedText is complete.
            if (checkAArticle ==true)
            {
                processedText = processedText.Replace("à le ", "au ");
                processedText = processedText.Replace("à Le ", "au ");
                processedText = processedText.Replace("à les ", "aux ");
                processedText = processedText.Replace("à Les ", "aux ");
                checkAArticle = false;
            }
            if (checkDeArticle == true)
            {
                processedText = processedText.Replace("de le ", "du ");
                processedText = processedText.Replace("de Le ", "du ");
                processedText = processedText.Replace("de les ", "des ");
                processedText = processedText.Replace("de Les ", "des ");
                checkDeArticle = false;
            }
            return processedText;
        }

        public override void SetHeroGenderGetter(Func<Genders> HeroGenderGetter)
        {
            // Store the way to get hero's gender

            MyHeroGenderGetter = HeroGenderGetter;

        }

        public override void SetNPCGenderGetter(Func<Genders> NPCGenderGetter)
        {
            // Store the way to get NPC's gender

            MyNPCGenderGetter = NPCGenderGetter;

        }

        private static TokenType GetNextToken(in string sourceText,
            int startIndex,             // Pos from which to search
            ref int bPos,               // Pos of {
            ref int cursorPos,          // Pos of char just after }
            ref string tokenContent,    // Token without { . }    
            ref string wordAfter)       // If gender token, word behind the token
        {
            int nbc;    // Nb char inside brackets
            char ch;
            int i;
            bool stop;

            stop = false;
            while (!stop)
            {
                bPos = sourceText.IndexOf("{", startIndex);
                if (bPos != -1)
                {
                    cursorPos = sourceText.IndexOf("}", bPos) + 1;
                    nbc = cursorPos - bPos - 2;
                    tokenContent = sourceText.Substring(bPos + 1, nbc);
                    ch = tokenContent[0];
                    // Check if first char is a number or not
                    if (byte.TryParse(tokenContent.Substring(0, 1), out _) == false)
                    {
                        if (tokenContent.Contains("/"))
                        {
                            return TokenType.HeroGender;
                        }
                        else if (tokenContent.Contains("?"))
                        {
                            string[] Values = tokenContent.Split('?');
                            if (Values[0] == "IsPlural") return TokenType.IsPlural;
                            else if (Values[0] == "NPCGender") return TokenType.NPCGender;
                            else return TokenType.Number;
                        }
                        else if (ch == '#')
                        {
                            return TokenType.Adjective;
                        }
                        else if (ch == '.')
                        {
                            tokenContent = tokenContent.Substring(1, nbc - 1);
                            if (GenderNums.Contains(tokenContent))
                            {
                                // We take the word behind the token, lowercase.
                                wordAfter = "";
                                for (i = cursorPos; i < sourceText.Length; i++)
                                {
                                    ch = sourceText[i];
                                    if (!" .,{".Contains<char>(ch))
                                        wordAfter += ch.ToString();
                                    else
                                        break;
                                }
                                return TokenType.GenderNum;
                            }
                            //else if (tokenContent[1] == 'h')
                            //    return HAspiré;
                            else
                            {
                                return TokenType.Article;
                            }
                        }
                        else return TokenType.Unknown;  // Something as {xyz}
                    }
                    startIndex = cursorPos;   // May be a DFU token as {0}, let it in place
                }
                else return TokenType.NotFound;   // No token up to the end of sourceText
            }
            return TokenType.NotFound;
        }

        private static bool GetNextGenderNum(in string sourceText, in int startIndex, ref string wordAfter)
        {
            // Find next GenderNum token and process it.
            // The search must stop after the final point of a sentence if any.

            int cp;
            string sentence;
            string token;
            int dotPos;
            int i;
            string nextChars;
            char ch;

            dotPos = sourceText.IndexOf(". ", startIndex);
            if (sourceText.IndexOf(". ", startIndex) != -1)
            {
                // There is an end of sentence
                sentence = sourceText.Substring(0, dotPos + 1);
            }
            else sentence = sourceText;

            cp = sentence.IndexOf("{.", startIndex);
            while (cp != -1)
            {
                token = sentence.Substring(cp + 2, 2);
                if (GenderNums.Contains(token))
                {
                    // A gender token has been found
                    curGenderNum = token;
                    Handle_Gender_Prefix();
                    genderNumFound = true;

                    if (cp == startIndex)
                    {
                        // GenderNums token just behind article

                        adjectiveBeforeWord = false;

                        // Check if there is a token {.h} behind the gender token
                        if (sourceText.Length >= cp + 9)
                        {
                            nextChars = sourceText.Substring(cp + 5, 4);
                            if (nextChars == "{.h}")
                            {
                                hAspiré = true;
                                cp += 4;
                            }
                        }
                    }
                    else adjectiveBeforeWord = true;

                    // Get the word after the gender token
                    wordAfter = "";
                    for (i = cp+5; i < sentence.Length; i++)
                    {
                        ch = sourceText[i];
                        if (!" .,{".Contains<char>(ch))
                            wordAfter += ch.ToString();
                        else
                            break;
                    }
                    wordAfter = wordAfter.ToLower();
                    return true;
                }
                else
                {
                    // Let's search further
                    cp = sentence.IndexOf("{.", cp+1);
                }
            }
            return false;
        }

        private static void Handle_Gender_Prefix()
        {
            if (curGenderNum == "MS")
            {
                isMale = true;
                isSingular = true;
            }
            else if (curGenderNum == "MP")
            {
                isMale = true;
                isSingular = false;
            }
            else if (curGenderNum == "FS")
            {
                isMale = false;
                isSingular = true;
            }
            else
            {
                isMale = false;
                isSingular = false;
            }
            genderDefined = true;
        }

        private static void Handle_le_Prefix(
            string word,                // Next word in lowercase
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            //Debug.Log("PGrammar Article le - word = " + word + " genderDefined = " + genderDefined.ToString());

            if ((word == "le") || (word == "la") || (word == "les") || (word.StartsWith("l'") == true))
            {
                // Let in place the article already there
                prefix = "";
            }
            else if (genderDefined == false)  // Aller vers Paris
                prefix = "";
            else if (isSingular == false)
                prefix = "les ";
            else if ((adjectiveBeforeWord == false) && NextCharIsVowel(word))
                prefix = "l'";
            else if (isMale == false)
                prefix = "la ";
            else
                prefix = "le ";

            // Special case when the article is after the related item.
            // Example: "Trouver {.le}{.FP}bottes et {.le} ramener" (Find the boots and bring them back)
            // -> Trouver les bottes et les ramener
            // As there is already a space after {.le}, suppress the space after the prefix.
            if (word == "")
            {
                if (prefix.EndsWith(" ")) prefix = prefix.TrimEnd();
            }

            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }

        private static void Handle_un_Prefix(
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            if (isSingular == false)
                prefix = "des ";
            else if (isMale == false)
                prefix = "une ";
            else
                prefix = "un ";

            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }

        private static void Handle_ce_Prefix(
            string word,                // Next word in lowercase
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            if (isSingular == false)
                prefix = "ces ";
            else if (isMale == false)
                prefix = "cette ";
            else if (NextCharIsVowel(word))
                prefix = "cet ";
            else
                prefix = "ce ";

            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }

        private static void Handle_de_Prefix(
            string word,                // Next word in lowercase
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            if ((word == "la") || (word.StartsWith("l'") == true))
                prefix = "de ";
            else if ((word == "le") || (word == "les"))
            {
                prefix = "de ";
                checkDeArticle = true;
            }
            else if (isSingular == false)
                prefix = "des ";
            else if (genderDefined == false) // First name, town name
            {
                if (NextCharIsVowel(word))
                    prefix = "d'";
                else
                    prefix = "de ";
                    checkDeArticle = true;
            }
            else if (NextCharIsVowel(word))
            {
                if (genderDefined == false)
                    prefix = "d'";
                else
                    prefix = "de l'";
            }
            else if (isMale == true)
                prefix = "du ";
            else if (isMale == false)
                prefix = "de la ";
            else
                prefix = "de ";


            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }

        private static void Handle_deIt_Prefix(
            string word,                // Next word in lowercase
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            if (NextCharIsVowel(word))
                prefix = "d'";
            else
                prefix = "de ";

            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }
        private static void Handle_du_Prefix(
            string word,                // Next word in lowercase
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            if (isSingular == false)
                prefix = "des ";
            else if (NextCharIsVowel(word))
                prefix = "de l'";
            else if (isMale == false)
                prefix = "de la ";
            else
                prefix = token + " ";

            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }

        private static void Handle_a_Prefix(
            string word,                // Next word in lowercase
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            if ((word == "la") || (word.StartsWith("l'") == true))
                prefix = "à ";
            else if ((word == "le") || (word == "les"))
            {
                prefix = "à ";
                checkAArticle = true;
            }
            else if (genderDefined == false)  // Town name
            {
                prefix = "à ";
                checkAArticle = true;
            }
            else {
                if (isSingular == false)
                    prefix = "aux ";
                else if (NextCharIsVowel(word))
                    prefix = "à l'";
                else if (isMale == true)
                    prefix = "au ";
                else
                    prefix = "à la ";
            }

            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }

        private static void Handle_ton_Prefix(
            string word,                // Next word in lowercase
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            if (isSingular == false)
                prefix = "tes ";
            else if (NextCharIsVowel(word))
                prefix = "ton ";
            else if (isMale == true)
                prefix = "ton ";
            else
                prefix = "ta ";

            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }

        private static void Handle_son_Prefix(
            string word,                // Next word in lowercase
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            if (isSingular == false)
                prefix = "ses ";
            else if (NextCharIsVowel(word))
                prefix = "son ";
            else if (isMale == true)
                prefix = "son ";
            else
                prefix = "sa ";

            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }

        private static void Handle_mon_Prefix(
            string word,                // Next word in lowercase
            string token,               // The token without {.}
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            bool tokenUpper = char.IsUpper(token[0]);
            string prefix;

            if (isSingular == false)
                prefix = "mes ";
            else if (NextCharIsVowel(word))
                prefix = "mon ";
            else if (isMale == true)
                prefix = "mon ";
            else
                prefix = "ma ";

            if (tokenUpper) prefix = char.ToUpper(prefix[0]) + prefix.Substring(1);
            processedText += prefix;
        }

        private static void Handle_adjective(
            string word,                // Related word in lowercase
            bool BeforeWord,            // The adjective is written before the related word
            string expression,          // The token with the different values
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            // Choose the right token depending current gender and number.
            // Order: MS, MP, FS, FP
            // Ex: #ajusté#ajustés#ajustée#ajustées
            // Special case when the four adjectives beau, vieux, nouveau and fou are before the related word,
            // if the related word is MS and begins with a vowel: fifth values bel, vieil, nouvel and fol.
            // Ex: beau#beaux#belle#belles#bel -> le bel arbre
			// Here again, Grench grammar singularity.
			// Other languages may need more than four values for adjectives.

            string Value;
            string[] Values = expression.Split('#');

            if (curGenderNum == "MS")
            {
                if ((Values.Length == 6) && (BeforeWord == true) && NextCharIsVowel(word))
                    Value = Values[5];
                else
                    Value = Values[1];
            }
            else if (curGenderNum == "MP") Value = Values[2];
            else if (curGenderNum == "FS") Value = Values[3];
            else Value = Values[4];

            processedText += Value;
        }

        private static void Handle_IsPlural(
            string token,               // The token with the different values
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            // Choose the right token depending current number.
            // Order: singular#plural
            // Ex: est#sont

            // Remove "IsPlural?"
            token = token.Substring(9);

            string Value;
            string[] Values = token.Split('#');

            if (isSingular) Value = Values[0];
            else Value = Values[1];

            processedText += Value;
        }

        private static void Handle_Number(
            string token,               // The token with the different values
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            // Add plural or not, depending the number before is 0 or 1, or more than 1.
            // This is done to prevents things like "Increase lasts %bdr round(s)".
            // Order: singular#plural
            // Ex: Increase lasts %bdr {Number?round#rounds}    -> Increase lasts 1 round
            //                                                  -> Increase lasts 3 rounds
            
            string Value;
            string number;

            // Remove "Number?" and get both words from token
            token = token.Substring(7);
            string[] Values = token.Split('#');

            // Get the number before the token
            string[] words = processedText.Split(' ');
            number = words[words.Length - 2];

            // If the last word is not numeric, TryParse is false and sends back 0 into nb
            if (Int32.TryParse(number, out int nb))
            {
                // Get the right word depending the number
                if (nb < 2) Value = Values[0];
                else Value = Values[1];
            }
            else Value = Values[0]; // The else is there if you want to do something else if number is not numeric

            processedText += Value;
        }

        private static void Handle_NPCGender(
            string token,               // The token with the different values
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            // Get NPC's gender
            Genders gender = MyNPCGenderGetter();
            //Debug.Log("PGrammar: NPC gender = " + gender);

            // Select masculine or feminine expression depending the gender of current NPC.
            // Ex: NPCGender?cousin#cousine

            // Remove "NPCGender?" and get both words from token
            token = token.Substring(10);
            string[] Values = token.Split('#');
            if (gender == Genders.Male) processedText += Values[0];
            else processedText += Values[1];
        }


        private static void Handle_ManWoman_Hero(
            string expression,          // The content of { }
            ref string processedText)   // In: Beginning of line just before the token
                                        // Out: Beginning of line up to after the token result
        {
            // Get hero's gender
            Genders gender = MyHeroGenderGetter();
            //Debug.Log("PGrammar: Hero gender = " + gender);

            // Select masculine or feminine expression depending the gender of the hero.
            // Ex : monsieur/madame

            string[] Values = expression.Split('/');
            if (gender == Genders.Male) processedText += Values[0];
            else processedText += Values[1];
        }


        private static void Handle_min_Suffix(ref string processedText, string token)
        {
            // Suppress uppercase for one word or the complete sentence

            string word;
            string lowerWord;
            string[] words;
            int nbWordsInTxt;
            int i, nbWords;
            bool finished;
            int index;
            string textBegin, textEnd;

            if (token == "min")
            {
                // We look to the three last words and not only the very last one,
                // in case of the token that must stay in lowercase looks like
                // "Minerai de fer".
                // The lowercase is not done if the word is the first one of a sentence.

                words = processedText.ToString().Split(' ', '.', '\'');
                nbWordsInTxt = words.Length;
                finished = false;
                i = 1;
                nbWords = nbWordsInTxt - 1;
                // In case token was put behind a dot
                if (words[nbWords] == "")
                {
                    if (nbWords != 0) nbWords -= 1;
                    else return;
                }
                while (!finished && i < 4)
                {
                    word = words[nbWords];
                    if (char.IsUpper(word[0]))
                    {
                        if ((nbWords != 0) && (words[nbWords - 1] != "")) // word = "" if a dot was filtered by the Split
                        {
                            lowerWord = word.ToLower();
                            processedText = processedText.Replace(word, lowerWord);
                        }
                        finished = true;    // Stop to the first word that has an uppercase
                    }
                    i += 1;
                    nbWords -= 1;
                    if ((nbWords < 0) || (words[nbWords] == "")) finished = true;
                }
            }
            else   // token "Min"
            {
                // The complete sentence is lowercased, except the first char.
                // If the text contains several sentences, process only the sentence before {.Min}.

                words = processedText.ToString().Split(' ', '.', '\'');
                nbWordsInTxt = words.Length;
                finished = false;
                nbWords = nbWordsInTxt - 1;
                // In case the token is behind a dot
                if (words[nbWords] == "")
                {
                    if (nbWords != 0) nbWords -= 1;
                    else return;
                }
                while (!finished)
                {
                    word = words[nbWords];
                    if (char.IsUpper(word[0]))
                    {
                        if ((nbWords != 0) && (words[nbWords - 1] != "")) // word = "" if a dot is filtered by Split
                        {
                            lowerWord = word.ToLower();
                            index = processedText.LastIndexOf(word);
                            textBegin = processedText.Substring(0, index);
                            textEnd = processedText.Substring(index + word.Length);
                            processedText = textBegin + lowerWord + textEnd;
                        }
                        else
                        {
                            finished = true;
                        }
                    }
                    nbWords -= 1;
                    if ((nbWords < 0) || (words[nbWords] == "")) finished = true;
                }
            }
        }

        private static void Handle_Maj_Suffix(ref string processedText)
        {
            // Force the first char of the sentence to be uppercase.
            // If several sentences, do this only for the one just before {.Maj}.

            string beginText, endText;
            int lastDotPos;
            string puncToAdd;
            char[] charsToTrim = {'.','?','!'};

            // Suppress possible ending punctuation
            puncToAdd = "";
            if (processedText.EndsWith(".")) puncToAdd = ".";
            else if (processedText.EndsWith("?")) puncToAdd = "?";
            else if (processedText.EndsWith("!")) puncToAdd = "!";
            if (puncToAdd != "") processedText = processedText.TrimEnd(charsToTrim);

            // Now we can search for a possible previous sentence that finish by a ponctuation
            lastPuncPos = processedText.LastIndexOf(".");
            if (processedText.LastIndexOf("?") > lastPuncPos) lastPuncPos = processedText.LastIndexOf("?");
            if (processedText.LastIndexOf("!") > lastPuncPos) lastPuncPos = processedText.LastIndexOf("!");

            if (lastPuncPos == -1)
            {
                // Only one sentence
                processedText = char.ToUpper(processedText[0]) + processedText.Substring(1);
            }
            else
            {
                beginText = processedText.Substring(0, lastPuncPos+2);
                endText = char.ToUpper(processedText[lastPuncPos+2]) + processedText.Substring(lastPuncPos+3);
                processedText = beginText + endText;
            }

            // Restore possible suppressed ending punctuation
            if (puncToAdd != "") processedText += puncToAdd;
        }

        private static bool NextCharIsVowel(string word)
        {
            if (word != "")
            {
                char ch = word[0];
                if ("aeiouyàâéèêîAEIOUYÀÂÉÈÊÎ".Contains<char>(ch))
                    return true;
                if ("bcdfgjklmnpqrstvwxzBCDFGJKLMNPQRSTVWXZ".Contains<char>(ch))
                    return false;
                if ("hH".Contains<char>(ch))
                {
                    // If h aspiré, the h acts as a consonant -> besoin de hache, je vais au harem
                    if (hAspiré == true) return false;
                    // If not, it's a h muet, acts as a vowel -> besoin d'habits, je vais à l'hôpital
                    else return true;
                }
                return false;
            }
            return false;
        }
    }
}
