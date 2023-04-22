# Projet French Daggerfall Unity
version 0.15.1-1

## Introduction

Ce module permet de jouer à Daggerfall Unity en français.
Son status est expérimental.

## Limitations connues

Les sauvegardes de jeu de Daggerfall Unity contiennent du texte déjà évalué et 
traduit tout au long de la partie (messages de quêtes, rumeurs, noms de
lieux,...) Il est recommandé d'utiliser systématiquement la même langue pour
un personnage, depuis sa création, sous peine de voir apparaître des mélanges.

Les modules doivent fournir leurs propres traductions ; Il se peut que le
contenu apporté par des modules ne soit pas traduit (en fait pour l'instant
aucun module n'est traduit).

Dans la 0.15.1 quelques petites choses n'ont pas été externalisées et
ne sont donc pas localisables. On peut citer notamment :

- Le nom des objets dans l'écran d'inventaire
- Le nom des sorts dans le livre des sorts
- La qualité des compétences dans les boites de description ("above average",…)
- Certains paramètres des écrans de DFU.

Normalement tous ces manques devraient être gommés dans la future version
0.15.2 de DFU.

Les noms de auberges et des ateliers sont eux aussi en anglais, l'algorithme
de génération de noms n'étant pas aujourd'hui assez souple pour être
traduit en français.

## Instructions d'installation

### Daggerfall Unity

Daggerfall Unity 0.15.1 ou supérieur est nécessaire.
Si vous ne l'avez pas installé, ou possédez une version antérieure, vous
pouvez soit utiliser les instructions d'installation officielles (en anglais)

https://forums.dfworkshop.net/viewtopic.php?t=2360 

soit vous reporter vers le fichier `Installation Daggerfall Unity.md`

### Project French Daggerfall Unity

L'URL officielle de ce projet est : https://...

Téléchargez l'archive `machin.zip`

L'installation de ce module va écraser des fichiers resources de Daggerfall
Unity. Si vous souhaitez pouvoir le désinstaller facilement plus tard, vous
pouvez au préalable effectuer une sauvegarde du contenu du sous-répertoire
`Daggerfall Unity_Data\StreamingAssets`.

Désactivez tous le contenu du fichier `machin.zip` dans le sous-répertoire
`Daggerfall Unity_Data\StreamingAssets`; Acceptez tous les écrasements de
fichiers.

## Support / Retours

Vos retours sont primordiaux pour améliorer la qualité de ce logiciel.
Si vous avez des questions, ou avez détecté un problème, vous pouvez en
discuter dans le canal #daggerfall-unity sur le serveur Discord 
"Daggerfall FR" 

https://discord.gg/Sp73DqD

Dans la page Nexus de distribution de cette VF:

https://nexusmods.com/daggerfallunity/mods/XXX

## Releases

* 0.15.1-1 Release initiale

## Contenu

Les fichiers de localisation sont rangés dans huit sous-dossiers du
dossier DaggerfallUnity_Data/StreamingAssets de Daggerfall Unity.

- BIOGs
  * 18 fichiers BIOGxxxx.TXT - Chaque fichier contient les questions posées
    dans l'écran de biographie lors de la création de personnage pour chacune
    des 18 classes possibles.

- Factions
  * 1 fichier FACTION.TXT - Définition détaillée des caractéristiques des
  factions et des personnages importants du jeu.

- Fonts
  * 2 fichiers FONT0003 - Ajout des caractères œ et Œ qui sont absents de
  la fonte par défaut de DFU.

- Movies
  * 15 fichiers *.mp4 - Les vidéos du jeu avec les sous-titres français.

- Text
  * Internal_Flats.csv - Les types de PNJ qu'il est possible de rencontrer
    dans le jeu.
  * Internal_Locations.csv - Les noms des 15251 lieux figurant sur la carte
    générale de Daggerfall.
  * Internal_Quests.csv - Les textes de toutes les quêtes du jeu.
  * Internal_RSC.csv - Les textes des dialogues du jeu.
  * Internal_Strings.csv - Listes et messages divers. 
  * 3 fichiers xxx.txt - Les textes des paramètres figurant dans les écrans
    de lancement de DFU.

- Text/Books
  * 91 fichiers BOKxxxxx-LOC.txt - Tous les livres à lire dans le jeu,
    traduits en français.

- Textures/CifRci
  * 21 fichiers BUTTONS.RCI_xxx.png - Images des boutons gris figurant
    dans le bas de certaines boites de dialogue (OUI, NON, ACCEPTER...).

- Textures/Img
  * 112 fichiers xxx.IMG.png - Images de fond des écrans du jeu en français
    (inventaire, carte...).

## Historique

La quasi-totalité de ce qui figure dans les fichiers de la VF provient du Projet French Daggerfall (PFD) qui a débuté dans les années 2000 et a trouvé son aboutissement dans le milieu des années 2010. C'est grâce au PFD que le Daggerfall classique peut être joué en français quasi intégral depuis plus de dix ans.

La seule exception est le contenu du fichier Internal_Locations.csv car les 15251 lieux de la carte de Daggerfall n'avaient pas été traduits en français dans le PFD. Ceci a été fait pour DFU grâce à une procédure développée par Pango car nous nous sommes rendu compte que les noms de lieux anglais avaient eux-mêmes été constitués de façon procédurale à partir d'un nombre limité de mots et d'expressions.

Bien entendu, les fichiers nécessaires pour la localisation de DFU ne sont pas la simple copie des fichiers du PFD car dans le Daggerfall classique tous les textes sont enfermés dans des fichiers encodés chacun à leur manière et ne sont pas lisibles en clair. Il a donc fallu développer des programmes spécifiques pour réussir à transférer les textes français encodés dans les fichiers du PFD vers les fichiers et dans le formatage attendu par DFU.

Ceci pour dire que tous les textes français que vous verrez dans DFU ont une très vieille histoire et sont le résultat du travail de beaucoup de traducteurs bénévoles qui ont participé à ce projet pendant vingt ans. Et cela explique comment il a été possible de sortir une localisation intégrale en français de DFU si peu de temps après la sortie de la première version de DFU localisable, traduction qui contient des textes déjà joués pendant de nombreuses années et qui ne doit rien à une utilisation récente et forcenée de DeepL ou Google Traduction.

Le travail de développement logiciel et de transcription des données du PFD vers DFU a débuté en 2021 à la suite des premiers travaux sur la localisation partielle de DFU réalisés par Interkarma. Ces travaux sur le moteur de DFU, incomplets, ont été mis en suspend pendant environ deux ans, Interkarma n'ayant plus trop de temps à y consacrer et ayant compris que ce qu'il mettait en place était trop compliqué pour les futurs traducteurs. Le 20 mars 2023 Interkarma a sorti un nouveau blog dans lequel il présentait la structure détaillée de tous les fichiers qui seraient nécessaires à une localisation complète de DFU, structure différente de celle présentée deux ans plus tôt. Suite à ce blog, les travaux sur la localisation française ont pu reprendre. Les outils nécessaires ont été développés et les fichiers français pour DFU générés depuis les fichiers du PFD ou depuis les deux tables traduites de DFU élaborées en 2021.

Suite à cela, les outils logiciels ne permettant pas toujours de générer des fichiers DFU parfaits, il y a eu environ trois semaines de mise au point de la structure des fichiers texte, relecture, accentuation de ce qui ne l'avait pas été dans le PFD (notamment les livres), correction des fautes d'orthographe résiduelles et test en jeu grâce à une version 0.15.1 bêta que Interkarma nous a faite parvenir avant la sortie officielle du 17 avril. Durant ce temps, de nombreux mails ont été échangés avec Interkarma pour traiter certains problèmes ou manques dans l'externalisation des textes par DFU. De fait, la présente VF a servi de bêta test pour la localisation de DFU.

Le Projet French Daggerfall a été mis sur les rails dans les années 2000 par Aggelon, ELOdry et Ferital.

L'ensemble des noms des contributeurs au PFD peut être consulté sur la page officielle du PFD, section Remerciements :

https://wiwiki.wiwiland.net/index.php?title=Daggerfall_:_Le_Projet_French_Daggerfall

Les travaux préliminaires de localisation française de DFU 0.13.x en 2021 ont été faits par Daneel53.

Le travail final en mars et avril 2023 qui a abouti à la localisation française intégrale de DFU 0.15.1 été fait par Pango et Daneel53.
