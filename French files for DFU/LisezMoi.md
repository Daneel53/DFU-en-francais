# Projet French Daggerfall Unity
Version française 1.1.1a du 25 juillet 2024

## Introduction

Le contenu de cette archive permet de jouer en français à Daggerfall Unity (DFU).
La version concernée de DFU est la version 1.1.1 mise en ligne sur le Github de Daggerfall Unity le 14 mai 2024.
Compte tenu des évolutions des versions 1.1.x de DFU par rapport aux versions précédentes jusqu'à la 1.0.0, la VF n'est compatible que de la version 1.1.1 de DFU (et des versions de test 1.1.0 RC et 1.1.1-test qui l'ont précédée).
La VF est compatible des plateformes Windows et Linux.

## Limitations connues

Les sauvegardes de jeu de Daggerfall Unity contiennent du texte déjà évalué et traduit tout au long de la partie (messages de quêtes, rumeurs, noms de lieux,...) Il est recommandé d'utiliser systématiquement la même langue pour un personnage depuis sa création, sous peine de voir apparaître des mélanges de langues. Pour la même raison, il faut commencer une nouvelle partie après installation de cette localisation pour en profiter pleinement si votre partie précédente n'a pas été démarrée en français.

La présente traduction ne traite que du Daggerfall Unity de base, les modules qui amèneront des textes supplémentaires (quêtes additionnelles par exemple) devront fournir leurs propres fichiers de traduction.

Les noms des commerces sont en français grâce à une API mise en place par Interkarma et surtout une procédure développée par Pango. Si vous trouvez des noms qui vont paraissent incorrects, merci de nous en informer.

## Instructions d'installation

### Daggerfall Unity

Daggerfall Unity 1.1.x est nécessaire.
Si vous ne l'avez pas installé ou possédez une version antérieure, vous pouvez :
- soit utiliser les instructions d'installation officielles (en anglais),
https://forums.dfworkshop.net/viewtopic.php?t=2360 
- soit vous reporter vers le fichier `Installation Daggerfall Unity.md`

On rappelle que toute nouvelle version de DFU doit être installée dans un nouveau dossier et non par superposition à une version précédente.

### Project French Daggerfall Unity

La localisation française est constituée de fichiers à installer dans le dossier `StreamingAssets` de DFU (voir ci-dessous la section Contenu).

ATTENTION : L'installation de cette localisation française va écraser des fichiers ressources de Daggerfall Unity préalablement présents dans le dossier StreamingAssets. Si vous souhaitez pouvoir le désinstaller facilement plus tard et restaurer DFU dans son état initial, vous devez au préalable effectuer une sauvegarde du contenu du sous-répertoire `DaggerfallUnity_Data\StreamingAssets`.

### Installation

Désarchivez tout le contenu de l'archive dans le sous-répertoire `DaggerfallUnity_Data\StreamingAssets` de DFU, acceptez tous les écrasements de fichiers.

Comme la VF contient un mod nommé "Project French Daggerfall pour Unity", il faut penser à aller dans l'écran des mods pour l'activer. Si vous ne l'activez pas, DFU sera quand même en français mais les noms des commerces dans les villes et villages resteront en anglais.

## Support / Retours

Il reste probablement des erreurs parmi les dizaines de milliers de lignes qui constituent cette version française.
Vos retours sont primordiaux pour améliorer la qualité de ce logiciel.
Si vous avez des questions, ou avez détecté un problème, vous pouvez en discuter dans le canal #daggerfall-unity sur le serveur Discord "Daggerfall FR".

https://discord.gg/Sp73DqD

Vous pouvez aussi le faire dans la page Nexus de distribution de cette VF :

https://nexusmods.com/daggerfallunity/mods/456

## Releases
* 1.1.1a du 25 juillet 2024
- Il y avait deux classes Voleur lors de la création de personnage. L'une des deux s'appelle désormais Cambrioleur.
- Correction d'un bug lors de la création de personnage qui pouvait renvoyer sur la page de sélection de race, soit quand on choisissait la classe Voleur, soit pour certaines combinaisons d'aptitudes lors de la création d'une nouvelle classe.
- La classe Voyou est remplacée par la classe Canaille pour être mieux adaptée aux personnages féminins.
- Correction du nom de quelques aptitudes dans la description des classes.
- Corrections diverses dans les textes de la traduction.

* 1.1.1 du 14 mai 2024
- Prise en compte des modifications dans les textes anglais de DFU faites après la 1.0.0. Le déroulement de certaines quêtes a évolué et le tutoriel a été totalement réécrit, ce qui rend la VF incompatible des versions précédentes de DFU.
- Prise en compte des remarques déposées par Menzagitat et Adlez8475 dans la page Nexus de la VF. Beaucoup de ces remarques étaient justifiées, qu'ils soient remerciés pour avoir pris le temps de nous les remonter.
- Grosse session de nettoyage des majuscules inutiles issues des textes anglais, majuscules qui plombaient la lecture en français.
- Au passage, les Redguards sont devenus des Rougegardes, comme dans les VF des TES suivants.
- Corrections diverses de petites choses trouvées dans les livres et les quêtes pendant la session de nettoyage des majuscules.
- Petite amélioration des conversations avec les PNJ pour les rendre plus fluides en français.

* 1.0.0a du 8 janvier 2024
Nous nous sommes rendus compte que les vidéos MP4 avec un codec H.265 ne sont pas affichées sur les PC n'ayant pas ce codec installé. Nous avons modifié la façon de fabriquer les vidéos sous-titrées, aussi toutes les vidéos MP4 et WEBM ont été refaites, les vidéos MP4 étant désormais encodées en H.264.

* 1.0.0 du 31 décembre 2023
Il n'y a aucune modification dans les fichiers à localiser depuis la version 0.16.2 de DFU.
Nous avons juste décidé d'éditer une version numérotée 1.0.0 pour honorer la sortie officielle de Daggerfall Unity en ce 31 décembre 2023, un évènement attendu depuis des années par les fans de Daggerfall.

* 0.16.2 Version adaptée à DFU 0.16.2 RC et 0.16.3 RC
Par rapport à la VF 0.16.1 :
  - Localisation des nouvelles chaînes de formatage ajoutées dans DFU 0.16.2 à la fin du fichier Internal_Strings.csv et dans le fichier GameSettings.txt pour la page des contrôles du joystick.
  - Les vidéos MP4 nécessaires à DFU ont été refaites : la taille en a été agrandie (960x600 au lieu de 320x200), les sous-titres du PFD historique ont été revus et réincrustés dans les nouveaux fichiers MP4.
  - Les vidéos sous-titrées au format WEBM ont été ajoutées pour que la VF devienne totalement compatible de Windows et Linux.
  - Les fichiers français de quêtes dans Text/Quests ont été revus pour être totalement en adéquation avec les fichiers anglais fournis avec DFU qui se trouvent dans StreamingAssets/Quests.
  - Le dossier FACTION et son fichier FACTION.TXT ne sont plus fournis car la traduction de la partie utile se trouve dans Text/Internal_Factions.csv.
  - Le numéro de version du mod "Project French Daggerfall pour Unity" a été changé en 1.0.0 (au lieu de 0.15.3.1) pour ne plus être lié aux versions de DFU. Ce changement provoquera un message d'erreur qui finit par la question "Proceed?" lors du chargement d'une sauvegarde faite depuis une version précédente. Acceptez par OUI sans avoir peur car le code du mod est inchangé. Après vos prochaines sauvegardes, ce message n’apparaîtra plus.

* 0.16.1 Version adaptée à DFU 0.16.1 RC
Par rapport à la VF 0.16.0 :
  - Localisation des nouvelles chaînes de formatage ajoutées dans DFU 0.16.1 à la fin du fichier Internal_Strings.csv.
  - Les autres modifs de texte citées dans les General fixes & Improvements de la version 0.16.1 étaient déjà correctes dans la VF.
  - Ajout dans Text du nouveau fichier NameGen.txt qui permet de localiser la génération des noms des PNJ. Surtout utile pour les langues qui n'utilisent pas les caractères latins, nous avons tout laissé en l'état sauf quatre titres traduits à la fin du fichier.

* 0.16.0 Version adaptée à DFU 0.16.0 RC
Par rapport à la VF 0.15.4 :
  - Localisation de deux nouvelles chaînes de formatage ajoutées dans DFU 0.16.0 à la fin du fichier Internal_Strings.csv.
  - Une nouvelle image dans Textures pour remplacer, dans l'écran des contrôles, le bouton en anglais ADVANCED par un bouton AVANCÉ.
  - Correction d'une erreur de formatage dans 176 quêtes qui pouvait faire afficher des débuts de quête dans le journal avec un contenu en anglais malgré la traduction réalisée.

* 0.15.4 Version adaptée à DFU 0.15.4a
La mise à jour a consisté à traduire les nouveautés de cette version de DFU :
  - Localisation des rangs des classes lors de la création du personnage.
  - Localisation des niveaux du joueur dans les guildes.
  - Si on active l'option DFU permettant de choisir une quête dans les guildes, les noms des quêtes sont désormais en français.
  - Deux nouveaux livres, qui sont une autobiographie en deux tomes de Sire Woodborne.
  - Petites chaînes qui n'étaient pas localisées dans DFU avant la 0.15.4.
  - Petites corrections de la traduction comme Spellsword -> Magelame, Nighblade -> Lame-noire, etc.

* 0.15.3-2 Version adaptée à DFU 0.15.3
Quoi de neuf dans cette version par rapport à la VF 0.15.2 ?
  - Grâce à l'ajout par Interkarma d'une interface dédiée dans DFU et au développement d'une procédure par Pango, tous les noms des commerces générés en début de partie sont désormais en français.
  - Tous les livres ont été revus et sont formatés correctement.
  - Toutes les quêtes contenues dans le précédent fichier Internal_Quests.csv ont été éclatées dans autant de fichiers XXXXXXXX-LOC.txt que de quêtes, conformément à la nouvelle structure attendue par DFU 0.15.3. Toutes les quêtes ont été relues et ont désormais un titre en français. Les noms de lieux dans certaines quêtes sont désormais en adéquation avec la traduction française des lieux.
  - L'écran de Configuration des Contrôles dans Daggerfall a été mis à jour pour faire apparaître l'option "Se faufiler".
  - Quelques petites coquilles ont été corrigées.

* 0.15.2-1 Release initiale

## Contenu

Les fichiers de localisation sont rangés dans sept sous-dossiers du dossier DaggerfallUnity_Data/StreamingAssets de Daggerfall Unity.

- BIOGs
  * 18 fichiers BIOGxxxx.TXT - Chaque fichier contient les questions posées dans l'écran de biographie lors de la création de personnage pour chacune des 18 classes possibles.

- Mods
  * 1 fichier project french daggerfall pour unity.dfmod - Ce module contient la procédure qui permet de nommer en français tous les commerces du jeu.
  
- Movies
  * 17 vidéos au format MP4 - Les vidéos du jeu avec les sous-titres français pour Windows.
  * Les mêmes 17 vidéos mais au format WEBM pour Linux.

- Text
  * DialogShortcuts.txt - Les touches de raccourci clavier dans les écrans de DFU.
  * FrenchNames.txt et FrenchAdjectives.txt - Deux fichiers servant à générer les noms français des commerces.
  * GameSettings.txt - Paramètres des écrans de configuration de DFU.
  * Internal_factions.csv - Les noms des factions.
  * Internal_Flats.csv - Les différents types de PNJ.
  * Internal_Items.csv - Les noms des objets dans l'inventaire.
  * Internal_Locations.csv - Les noms des 15251 lieux sur la carte de Tamriel.
  * Internal_MagicItems.csv - Les noms des objets magiques.
  * Internal_RSC.csv - Les textes des dialogues du jeu.
  * Internal_Settings.csv - Complément de paramètres pour les écrans de DFU.
  * Internal_Spells.csv - Noms des sorts.
  * Internal_Strings.csv - Listes et messages divers.
  * MainMenu.txt - Paramètres de l'écran d’accueil de DFU.
  * ModSystem.txt - Paramètres de l'écran de gestion des mods de DFU.
  * NameGen.txt - Fichier permettant de générer les noms des PNJ.
 
- Text/Books
  * 93 fichiers BOKxxxxx-LOC.txt - Tous les livres à lire dans le jeu.

- Text/Quests
  * 243 fichiers xxxxxxxx-LOC.txt - Tous les textes de la partie QRC des quêtes gérées par DFU.

- Textures
  * 1 fichier advanced_controls_button.png - Le bouton AVANCÉ de l'écran de configuration des contrôles dans le jeu.

- Textures/CifRci
  * 21 fichiers BUTTONS.RCI_xxx.png - Images des boutons gris figurant dans le bas de certaines boites de dialogue du jeu (OUI, NON, ACCEPTER...).

- Textures/Img
  * 112 fichiers xxx.IMG.png - Images de fond des écrans du jeu (inventaire, carte...).

## Historique

La quasi-totalité de ce qui figure dans les fichiers de la VF provient du Projet French Daggerfall (PFD) qui a débuté dans les années 2000 et a trouvé son aboutissement dans le milieu des années 2010. C'est grâce au PFD que le Daggerfall classique peut être joué en français quasi intégral depuis plus de dix ans.

La seule exception est le contenu du fichier Internal_Locations.csv car les 15251 lieux de la carte de Daggerfall n'avaient pas été traduits en français dans le PFD. Ceci a été fait pour DFU grâce à une procédure développée par Pango car nous nous sommes rendu compte que les noms de lieux anglais avaient eux-mêmes été constitués de façon procédurale à partir d'un nombre limité de mots et d'expressions.

Bien entendu, les fichiers nécessaires pour la localisation de DFU ne sont pas la simple copie des fichiers du PFD car dans le Daggerfall classique tous les textes sont enfermés dans des fichiers encodés chacun à leur manière et ne sont pas lisibles en clair. Il a donc fallu développer des programmes spécifiques pour réussir à transférer les textes français encodés dans les fichiers du PFD vers les fichiers et dans le formatage attendu par DFU.

Ceci pour dire que tous les textes français que vous verrez dans DFU ont une très vieille histoire et sont le résultat du travail de beaucoup de traducteurs bénévoles qui ont participé à ce projet pendant vingt ans. Et cela explique comment il a été possible de sortir une localisation intégrale en français de DFU si peu de temps après la sortie de la première version de DFU localisable, traduction qui contient des textes déjà joués pendant de nombreuses années et qui ne doit rien à une utilisation récente et forcenée de DeepL ou Google Traduction.

Le travail de développement logiciel et de transcription des données du PFD vers DFU a débuté en 2021 à la suite des premiers travaux sur la localisation partielle de DFU réalisés par Interkarma. Ces travaux sur le moteur de DFU, incomplets, ont été mis en suspend pendant environ deux ans, Interkarma n'ayant plus trop de temps à y consacrer et ayant compris que ce qu'il mettait en place était trop compliqué pour les futurs traducteurs. Le 20 mars 2023 Interkarma a sorti un nouveau blog dans lequel il présentait les structures détaillées de tous les fichiers qui seraient nécessaires à une localisation complète de DFU, structures différentes de celles présentées deux ans plus tôt. Suite à ce blog, les travaux sur la localisation française de DFU ont pu reprendre. Les outils nécessaires ont été développés et des fichiers français pour DFU ont été générés depuis les fichiers du PFD ou depuis les deux tables traduites de DFU élaborées en 2021.

Suite à cela, les outils logiciels ne permettant pas toujours de générer des fichiers DFU parfaits, il y a eu environ trois semaines de mise au point de la structure des fichiers texte, relecture, accentuation de ce qui ne l'avait pas été dans le PFD (notamment les livres), correction des fautes d'orthographe résiduelles et test en jeu grâce à une version 0.15.1 bêta que Interkarma nous avait faite parvenir avant la sortie officielle du 17 avril 2023. Durant ce temps, de nombreux mails ont été échangés avec Interkarma pour traiter certains problèmes ou manques dans l'externalisation des textes par DFU. De fait, la VF a servi de bêta test pour la localisation de DFU.

Le Projet French Daggerfall a été mis sur les rails dans les années 2000 par Aggelon, ELOdry et Ferital.

L'ensemble des noms des contributeurs au PFD peut être consulté sur la page officielle du PFD, section Remerciements :

https://wiwiki.wiwiland.net/index.php?title=Daggerfall_:_Le_Projet_French_Daggerfall

Les travaux préliminaires de localisation française de DFU 0.13.x en 2021 ont été faits par Daneel53.

Le travail final commencé en mars 2023, qui a abouti à la localisation française intégrale de DFU 0.15.2 et des versions suivantes, a été fait par Pango et Daneel53.
