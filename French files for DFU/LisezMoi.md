# Projet French Daggerfall Unity
Version française 0.16.0

## Introduction

Le contenu de cette archive permet de jouer à Daggerfall Unity 0.16.0 en français.
La version concernée de DFU est la version 0.16.0 Release Candidate mise en ligne par Interkarma le 20 septembre 2023.
Cette VF est également compatible de DFU 0.15.4.

## Limitations connues

Les sauvegardes de jeu de Daggerfall Unity contiennent du texte déjà évalué et traduit tout au long de la partie (messages de quêtes, rumeurs, noms de lieux,...) Il est recommandé d'utiliser systématiquement la même langue pour un personnage depuis sa création, sous peine de voir apparaître des mélanges.

Pour la même raison, il faut commencer une nouvelle partie après installation de cette localisation pour en profiter pleinement si votre partie précédente n'a pas été démarrée en français.

La présente traduction ne traite que du Daggerfall Unity de base, les modules qui amèneront des textes supplémentaires (quêtes additionnelles par exemple) devront fournir leurs propres fichiers de traduction.

Les noms des commerces sont en français grâce à une API mise en place par Interkarma et surtout une procédure développée par Pango. Si vous trouvez des noms qui vont paraissent incorrects, merci de nous en informer.

## Instructions d'installation

### Daggerfall Unity

Daggerfall Unity 0.15.4 ou supérieur est nécessaire.
Si vous ne l'avez pas installé, ou possédez une version antérieure, vous pouvez soit utiliser les instructions d'installation officielles (en anglais),

https://forums.dfworkshop.net/viewtopic.php?t=2360 

soit vous reporter vers le fichier `Installation Daggerfall Unity.md`

### Project French Daggerfall Unity

La localisation française est constituée de fichiers à installer dans le dossier `StreamingAssets` de DFU (voir ci-dessous la section Contenu).

ATTENTION : L'installation de cette localisation française va écraser des fichiers ressources de Daggerfall Unity préalablement présents dans le dossier StreamingAssets. Si vous souhaitez pouvoir le désinstaller facilement plus tard et restaurer DFU dans son état initial, vous devez au préalable effectuer une sauvegarde du contenu du sous-répertoire `DaggerfallUnity_Data\StreamingAssets`.

### Installation

Désarchivez tout le contenu de l'archive dans le sous-répertoire `DaggerfallUnity_Data\StreamingAssets` de la version 0.16.0 de DFU, acceptez tous les écrasements de fichiers.

Comme la VF contient un mod nommé "Project French Daggerfall pour Unity", il faut penser à aller dans l'écran des mods pour l'activer. Si vous ne l'activez pas, DFU sera toujours en français mais les noms des commerces dans les villes et villages resteront en anglais.

## Support / Retours

Bien que nous n'ayons plus détecté d'erreurs lors de nos essais, il est probable qu'il en reste parmi les dizaines de milliers de lignes qui constituent cette version française.
Vos retours sont primordiaux pour améliorer la qualité de ce logiciel.
Si vous avez des questions, ou avez détecté un problème, vous pouvez en discuter dans le canal #daggerfall-unity sur le serveur Discord "Daggerfall FR".

https://discord.gg/Sp73DqD

Dans la page Nexus de distribution de cette VF :

https://nexusmods.com/daggerfallunity/mods/456

## Releases

* 0.16.0 Version adaptée à DFU 0.16.0 RC
Cette VF ne contient que deux différences par rapport à la VF 0.15.4 :
  - Localisation de deux nouvelles chaînes de formatage ajoutées dans la 0.16.0 à la fin du fichier Internal_Strings.csv.
  - Une nouvelle image dans Textures pour remplacer, dans l'écran des contrôles, le bouton en anglais ADVANCED par un bouton AVANCÉ.

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

- Factions
  * 1 fichier FACTION.TXT - Définition détaillée des caractéristiques des factions et des personnages importants du jeu.

- Mods
  * 1 fichier project french daggerfall pour unity.dfmod - Ce module contient la procédure qui permet de nommer en français tous les commerces du jeu.
  
- Movies
  * 15 fichiers .mp4 - Les vidéos du jeu avec les sous-titres français.

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
 
- Text/Books
  * 93 fichiers BOKxxxxx-LOC.txt - Tous les livres à lire dans le jeu.

- Text/Quests
  * 242 fichiers xxxxxxxx-LOC.txt - Touts les textes de la partie QRC des quêtes gérées par DFU.

- Textures
  * 1 fichier advanced_controls_button.csv

- Textures/CifRci
  * 21 fichiers BUTTONS.RCI_xxx.png - Images des boutons gris figurant dans le bas de certaines boites de dialogue (OUI, NON, ACCEPTER...).

- Textures/Img
  * 112 fichiers xxx.IMG.png - Images de fond des écrans du jeu (inventaire, carte...).

## Historique

La quasi-totalité de ce qui figure dans les fichiers de la VF provient du Projet French Daggerfall (PFD) qui a débuté dans les années 2000 et a trouvé son aboutissement dans le milieu des années 2010. C'est grâce au PFD que le Daggerfall classique peut être joué en français quasi intégral depuis plus de dix ans.

La seule exception est le contenu du fichier Internal_Locations.csv car les 15251 lieux de la carte de Daggerfall n'avaient pas été traduits en français dans le PFD. Ceci a été fait pour DFU grâce à une procédure développée par Pango car nous nous sommes rendu compte que les noms de lieux anglais avaient eux-mêmes été constitués de façon procédurale à partir d'un nombre limité de mots et d'expressions.

Bien entendu, les fichiers nécessaires pour la localisation de DFU ne sont pas la simple copie des fichiers du PFD car dans le Daggerfall classique tous les textes sont enfermés dans des fichiers encodés chacun à leur manière et ne sont pas lisibles en clair. Il a donc fallu développer des programmes spécifiques pour réussir à transférer les textes français encodés dans les fichiers du PFD vers les fichiers et dans le formatage attendu par DFU.

Ceci pour dire que tous les textes français que vous verrez dans DFU ont une très vieille histoire et sont le résultat du travail de beaucoup de traducteurs bénévoles qui ont participé à ce projet pendant vingt ans. Et cela explique comment il a été possible de sortir une localisation intégrale en français de DFU si peu de temps après la sortie de la première version de DFU localisable, traduction qui contient des textes déjà joués pendant de nombreuses années et qui ne doit rien à une utilisation récente et forcenée de DeepL ou Google Traduction.

Le travail de développement logiciel et de transcription des données du PFD vers DFU a débuté en 2021 à la suite des premiers travaux sur la localisation partielle de DFU réalisés par Interkarma. Ces travaux sur le moteur de DFU, incomplets, ont été mis en suspend pendant environ deux ans, Interkarma n'ayant plus trop de temps à y consacrer et ayant compris que ce qu'il mettait en place était trop compliqué pour les futurs traducteurs. Le 20 mars 2023 Interkarma a sorti un nouveau blog dans lequel il présentait la structure détaillée de tous les fichiers qui seraient nécessaires à une localisation complète de DFU, structure différente de celle présentée deux ans plus tôt. Suite à ce blog, les travaux sur la localisation française de DFU ont pu reprendre. Les outils nécessaires ont été développés et les fichiers français pour DFU générés depuis les fichiers du PFD ou depuis les deux tables traduites de DFU élaborées en 2021.

Suite à cela, les outils logiciels ne permettant pas toujours de générer des fichiers DFU parfaits, il y a eu environ trois semaines de mise au point de la structure des fichiers texte, relecture, accentuation de ce qui ne l'avait pas été dans le PFD (notamment les livres), correction des fautes d'orthographe résiduelles et test en jeu grâce à une version 0.15.1 bêta que Interkarma nous a faite parvenir avant la sortie officielle du 17 avril 2023. Durant ce temps, de nombreux mails ont été échangés avec Interkarma pour traiter certains problèmes ou manques dans l'externalisation des textes par DFU. De fait, la présente VF a servi de bêta test pour la localisation de DFU.

Le Projet French Daggerfall a été mis sur les rails dans les années 2000 par Aggelon, ELOdry et Ferital.

L'ensemble des noms des contributeurs au PFD peut être consulté sur la page officielle du PFD, section Remerciements :

https://wiwiki.wiwiland.net/index.php?title=Daggerfall_:_Le_Projet_French_Daggerfall

Les travaux préliminaires de localisation française de DFU 0.13.x en 2021 ont été faits par Daneel53.

Le travail final commencé en mars 2023, qui a abouti à la localisation française intégrale de DFU 0.15.2 et des versions suivantes, a été fait par Pango et Daneel53.
