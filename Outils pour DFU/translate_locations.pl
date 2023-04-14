#!/usr/bin/perl
use strict;
use warnings;

# M masculin   ME masculin élidé ("l'oiseau")
# F féminin    FE féminin élidé ("l'otarie")
my (%name) = (
    'Altar' => [qw(ME Autel)],
    'Ascencion' => [qw(FE Ascension)],
    'Badger' => [qw(M Blaireau)],
    'Barbarian' => [qw(M Barbare)],
    'Bat' => [qw(F Chauve-Souris)],
    'Beaver' => [qw(M Castor)],
    'Bird' => [qw(ME Oiseau)],
    'Castle' => [qw(M Château)],
    'Cat' => [qw(M Chat)],
    'Chasm' => [qw(M Gouffre)],
    'Dagger' => [qw(F Dague)],
    'Djinn' => [qw(M Djinn)],
    'Dog' => [qw(M Chien)],
    'Dragon' => [qw(M Dragon)],
    'Dungeon' => [qw(M Donjon)],
    'Dwarf' => [qw(M Nain)],
    'Fairy' => [qw(F Fée)],
    'Fawn' => [qw(M Faon)],
    'Feather' => [qw(F Plume)],
    'Fox' => [qw(M Renard)],
    'Giant' => [qw(M Géant)],
    'Gnome' => [qw(M Gnome)],
    'Goat' => [qw(F Chèvre)],
    'Goblin' => [qw(M Gobelin)],
    'Griffin' => [qw(M Griffon)],
    'Guard' => [qw(M Garde)],
    'Hedgehog' => [qw(M Hérisson)],
    'Helm' => [qw(M Casque)],
    'Huntsman' => [qw(M Chasseur)],
    'Idol' => [qw(FE Idole)],
    'Jug' => [qw(F Cruche)],
    'Knave' => [qw(M Valet)],
    'Light' => [qw(F Lumière)],
    'Lion' => [qw(M Lion)],
    'Lynx' => [qw(M Lynx)],
    'Martyr' => [qw(M Martyre)],
    'Mole' => [qw(F Taupe)],
    'Mouse' => [qw(F Souris)],
    'Mug' => [qw(F Tasse)],
    'Muskrat' => ["M", "Rat Musqué"],
    'Ogre' => [qw(ME Ogre)],
    'Omen' => [qw(M Présage)],
    'Oracle' => [qw(ME Oracle)],
    'Pig' => [qw(M Cochon)],
    'Pit' => [qw(M Puits)],
    'Porcupine' => [qw(M Porc-Épic)],
    'Priest' => [qw(M Prêtre)],
    'Prophet' => [qw(M Prophète)],
    'Rascal' => [qw(M Vaurien)],
    'Rat' => [qw(M Rat)],
    'Rebirth' => [qw(F Renaissance)],
    'Redeemer' => [qw(M Rédempteur)],
    'Relic' => [qw(F Relique)],
    'Scorpion' => [qw(M Scorpion)],
    'Seer' => [qw(M Devin)],
    'Skull' => [qw(M Crâne)],
    'Soul' => [qw(FE Âme)],
    'Stag' => [qw(M Cerf)],
    'Star' => [qw(FE Étoile)],
    'Sunrise' => [qw(FE Aube)],
    'Sword' => [qw(FE Épée)],
    'Toad' => [qw(M Crapaud)],
    'Tree' => [qw(ME Arbre)],
    'Wolf' => [qw(M Loup)],
    'Woodchuck' => [qw(F Marmotte)],
    );
# Adjectif masculin, adjectif féminin
my (%adjectif) = (
    'Black' => [qw(Noir Noire)],
    'Bleeding' => [qw(Sanglant Sanglante)],
    'Blessed' => [qw(Béni Bénie)],
    'Burning' => [qw(Brûlant Brûlante)],
    'Crimson' => [qw(Cramoisi Cramoisie)],
    'Dancing' => [qw(Dansant Dansante)],
    'Dead' => [qw(Mort Morte)],
    'Dirty' => [qw(Sale Sale)],
    "Devil's" => ["du Diable", "du Diable"],
    'Eternal' => [qw(Éternel Éternelle)],
    'Fearful' => [qw(Craintif Craintive)],
    'Flying' => [qw(Volant Volante)],
    'Gentle' => [qw(Doux Douce)],
    'Gold' => [qw(Doré Dorée)],
    'Green' => [qw(Vert Verte)],
    'Holy' => [qw(Saint Sainte)],
    'Howling' => [qw(Hurlant Hurlante)],
    'Infinite' => [qw(Infini Infinie)],
    'Inner' => [qw(Intérieur Intérieure)],
    'Joyous' => [qw(Joyeux Joyeuse)],
    "King's" => ["du Roi", "du Roi"],
    'Laughing' => [qw(Riant Riante)],
    'Lucky' => [qw(Chanceux Chanceuse)],
    'Old' => [qw(Vieux Vieille)],
    'Perpetual' => [qw(Perpétuel Perpétuelle)],
    "Queen's" => ["de la Reine", "de la Reine"],
    'Red' => [qw(Rouge Rouge)],
    'Restless' => [qw(Agité Agitée)],
    'Rusty' => [qw(Rouillé Rouillée)],
    'Sacred' => [qw(Sacré Sacrée)],
    'Savage' => [qw(Sauvage Sauvage)],
    'Screaming' => [qw(Criant Criante)],
    'Silent' => [qw(Silencieux Silencieuse)],
    'Silver' => [qw(Argenté Argentée)],
    'Singing' => [qw(Chantant Chantante)],
    'Thirsty' => [qw(Assoiffé Assoiffée)],
    'Unfortunate' => [qw(Regrettable Regrettable)],
    'Wailing' => [qw(Gémissant Gémissante)],
    'Weeping' => [qw(Larmoyant Larmoyante)],
    'White' => [qw(Blanc Blanche)],
    );

my (%inconnus) = ();
my (%trads_inverses) = ();

open my $LOCATIONS, '<', 'Internal_Locations.csv' or die 'Could not open file';

sub article_nom($) {
    my ($name) = @_;
    return 'le ' if $name->[0] eq 'M';
    return "l'" if $name->[0] eq 'ME';
    return 'la ' if $name->[0] eq 'F';
    return "l'" if $name->[0] eq 'FE';
    return '' if $name->[0] eq 'U';
    die "Don't know genre $name->[0]";
}

sub translate_name($) {
    my ($nameeng) = @_;
    if (exists $name{$nameeng}) {
        return $name{$nameeng};
    }
    else {
        $inconnus{$nameeng}++;
        return ["M", $nameeng];
    }
}

sub accord_nom($) {
    my ($nameeng) = @_;
    my $name = translate_name($nameeng);
    my($art);
    $art = article_nom($name);
    return "$art$name->[1]";
}

sub accord_adj($$) {
    my ($nameeng, $adjeng) = @_;
    my $name = translate_name($nameeng);
    my $adj = $adjectif{$adjeng} or die "Can't find adjective for $adjeng";
    my($art, $a);
    $a = $adj->[0] if $name->[0] eq 'M';
    $a = $adj->[0] if $name->[0] eq 'ME';
    $a = $adj->[1] if $name->[0] eq 'F';
    $a = $adj->[1] if $name->[0] eq 'FE';
    die "Don't know genre $name->[0]" unless defined $a;
    if ($adj->[0] =~ /^(Doux|Vieux)$/) {
        my $noe = $name->[0];
        $noe =~ s/E$//;
        $art = article_nom([$noe, $name->[1]]);
        return "$art$a $name->[1]";
    }
    else {
        $art = article_nom($name);
        return "$art$name->[1] $a";
    }
}

my $header = <$LOCATIONS>;
print $header;

my $line_number = 1;
while(my $line = <$LOCATIONS>) {
    $line_number++;
    chomp $line;
    my ($id, $name) = split(/,\s*/, $line);
    my $translation;
    $translation = "Manoir $1" if $name =~ /^([A-Za-z']+) Manor$/;
    $translation = "l'Hôtel de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Hostel$/;
    $translation = "l'Hôtel de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Hostel$/;
    $translation = "l'Auberge de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Inn$/;
    $translation = "la Cabane de ".accord_adj($2, $1) if $name =~ /^The (\w+) ([A-Za-z']+) Shack$/;
    $translation = "Ruines de la Ferme $1" if $name =~ /^Ruins of The ([A-Za-z']+) Farmstead$/;
    $translation = accord_adj($2, $1)." de $3" if $name =~ /^(\w+) (\w+) of (Akatosh|Arkay|Dibella|Julianos|Kynareth|Mara|Stendarr|Zenithar)$/;
    $translation = "la Garde de $1" if $name =~ /^([A-Za-z']+?)('s)? Guard$/;
    $translation = "Lieu de ".accord_adj($2, $1) if $name =~ /^(\w+) ([A-Za-z'-]+?)('s)? Place$/;
    $translation = "le Lieu de ".accord_adj($2, $1) if $name =~ /^The (\w+) ([A-Za-z']+?)('s)? Place$/;
    $translation = $name if $name =~ /^([A-Za-z'-]+)\s*$/;
    $translation = "les Tombeaux de $1" if $name =~ /^The Tombs of ([A-Za-z']+)$/;
    $translation = "les Cryptes de $1" if $name =~ /^THe Crypts of ([A-Za-z']+)$/;
    $translation = "Ruines du Lieu de ".accord_adj($2, $1) if $name =~ /^Ruins of (\w+) ([A-Za-z'-]+?)('s)? Place$/;
    $translation = "les Ruines du Lieu de ".accord_adj($2, $1) if $name =~ /^Ruins of The (\w+) ([A-Za-z']+)('s)? Place$/;
    $translation = "la Ferme de $1" if $name =~ /^The ([A-Za-z']+) Farmstead$/;
    $translation = "Château de $1" if $name =~ /^Castle ((Count|Duke|Lord|Viscount) [A-Za-z']+)$/;
    $translation = "Château $1" if $name =~ /^Castle ([A-Za-z']+)$/;
    $translation = "les Caveaux $1" if $name =~ /^The ([A-Za-z']+) Vaults$/;
    $translation = "Ruines du Palace $1" if $name =~ /^Ruins of ([A-Za-z']+) Palace$/;
    $translation = "Ruines du Verger $1" if $name =~ /^Ruins of ([A-Za-z']+) Orchard$/;
    $translation = "la Toile de $2" if $name =~ /^(The )?([A-Za-z']+?)('s)? Web$/;
    $translation = "la Tour de $1" if $name =~ /^The Tower of ([A-Za-z']+)$/;
    $translation = "Ruines du Manoir de $1" if $name =~ /^Ruins of ([A-Za-z']+) Manor$/;
    $translation = "Ruines de la Grange de $1" if $name =~ /^Ruins of ([A-Za-z']+?)('s)? Grange$/;
    $translation = "Ruines de la Garde de $1" if $name =~ /^Ruins of ([A-Za-z']+?)('s)? Guard$/;
    $translation = "la Taverne de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Tavern$/;
    $translation = "Grange $1" if $name =~ /^(\w+) Grange$/;
    $translation = "Ruines de la Cabane de ".accord_adj($2, $1) if $name =~ /^Ruins of (\w+) ([A-Za-z'-]+)'s Shack$/;
    $translation = "Ruines de la Cabane de ".accord_adj($2, $1) if $name =~ /^Ruins of The (\w+) ([A-Za-z'-]+) Shack$/;
    $translation = "Ruines de la Cour de $1" if $name =~ /^Ruins of ([A-Za-z']+) Court$/;
    $translation = "Ruines du Castel $1" if $name =~ /^Ruins of ([A-Za-z']+) Hall$/;
    $translation = "Palace $1" if $name =~ /^([A-Za-z']+) Palace$/;
    $translation = "la Taverne de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Tavern$/;
    $translation = "Ruines de la Ferme de ".accord_adj($2, $1) if $name =~ /^Ruins of (\w+) ([A-Za-z'-]+)'s Farm$/;
    $translation = "la Nécropole $1" if $name =~ /^The (\w+) Graveyard$/;
    $translation = "le Presbytère $1" if $name =~ /^The (\w+) Manse$/;
    $translation = "le Cairn de $1" if $name =~ /^The Cairn of (Marquis \w+)$/;
    $translation = "le Cairn de $1" if $name =~ /^The Cairn of (\w+)$/;
    $translation = "le Sépulcre de $1" if $name =~ /^The Sepulcher of (\w+)$/;
    $translation = "Castel de $1" if $name =~ /^(Baron [A-Za-z']+) Hall$/;
    $translation = "Castel $1" if $name =~ /^([A-Za-z']+) Hall$/;
    $translation = "la Citadelle de $1" if $name =~ /^The Citadel of ([A-Za-z']+)$/;
    $translation = "la Tour $1" if $name =~ /^Tower ([A-Za-z']+)$/;
    $translation = "la Cabane de ".accord_adj($2, $1) if $name =~ /^(\w+) ([A-Za-z'-]+)'s Shack$/;
    $translation = "Cour $1" if $name =~ /^([A-Za-z']+) Court$/;
    $translation = "le Puits $1" if $name =~ /^The (\w+) Pit$/;
    $translation = "l'Ermitage $1" if $name =~ /^The (\w+) Hermitage$/;
    $translation = "Tour $1" if $name =~ /^([A-Za-z']+) Tower$/;
    $translation = "Ruines de la Tour $1" if $name =~ /^Ruins of ([A-Za-z']+) Tower$/;
    $translation = "le Monastère de $1" if $name =~ /^The Friary of (\w+)$/;
    $translation = "le Cimetière $1" if $name =~ /^The ([A-Za-z']+) Cemetery$/;
    $translation = "Ruines de la Plantation $1" if $name =~ /^Ruins of The ([A-Za-z']+) Plantation$/;
    $translation = "Communauté des Marécages" if $name =~ /^Coven in the Marsh$/;
    $translation = "la Toile de $1" if $name =~ /^The Web of (\w+)$/;
    $translation = "la Caverne $1" if $name =~ /^The (\w+) Cave$/;
    $translation = "Taudis de ".accord_adj($2, $1) if $name =~ /^(\w+) ([A-Za-z'-]+)'s Hovel$/;
    $translation = "le Fort de $1" if $name =~ /^The Hold of ([A-Za-z']+)$/;
    $translation = "la Loge de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Lodge$/;
    $translation = "Ruines de la Tour de $1" if $name =~ /^Ruins of The Tower of ([A-Za-z']+)$/;
    $translation = "le Tunnel $1" if $name =~ /^The ([A-Za-z']+) Tunnel$/;
    $translation = "la Cabine $1" if $name =~ /^The ([A-Za-z']+) Cabin$/;
    $translation = "le Tombeau de $1" if $name =~ /^The Tomb of (\w+)$/;
    $translation = "Ruines du Château de $1" if $name =~ /^Ruins of Castle ([A-Za-z']+)$/;
    $translation = "le Pub de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Pub$/;
    $translation = "la Loge de $1" if $name =~ /^(\w+) Lodge$/;
    $translation = "la Forteresse de $1" if $name =~ /^The Fortress of ([A-Za-z']+)$/;
    $translation = "Ruines de la Tour $1" if $name =~ /^Ruins of Tower ([A-Za-z']+)$/;
    $translation = "la Caverne de $1" if $name =~ /^The (\w+) Cavern$/;
    $translation = "le Pub de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Pub$/;
    $translation = "Ruines de la Cabine de $1" if $name =~ /^Ruins of The ([A-Za-z']+) Cabin$/;
    $translation = "Ruines du Taudis de ".accord_adj($3, $2) if $name =~ /^Ruins of (The )?(\w+) ([A-Za-z'-]+?)('s)? Hovel$/;
    $translation = "Sanctuaire de $1" if $name =~ /^(\w+( \w+)?) Shrine$/;
    $translation = "Refuge de $1" if $name =~ /^Shelter of (\w+)$/;
    $translation = "l'Abbatiale de $1" if $name =~ /^(\w+) Minster$/;
    $translation = "le Taudis de ".accord_adj($2, $1) if $name =~ /^The (\w+) ([A-Za-z'-]+) Hovel$/;
    $translation = "Ferme de ".accord_adj($2, $1) if $name =~ /^(\w+) ([A-Za-z'-]+)'s Farm$/;
    $translation = "Fort de $1" if $name =~ /^([A-Za-z']+)'s Hold$/;
    $translation = "Sanctuaire de $1" if $name =~ /^Shrine of ([A-Za-z']+)$/;
    $translation = "le Sanctuaire de $1" if $name =~ /^The Shrine of ([A-Za-z']+)$/;
    $translation = "la Tanière de $1" if $name =~ /^The Den of ([A-Za-z']+)$/;
    $translation = "la Plantation de $1" if $name =~ /^The ([A-Za-z']+) Plantation$/;
    $translation = "Ruines du Fort de $1" if $name =~ /^Ruins of The Hold of ([A-Za-z']+)$/;
    $translation = "les Cryptes $1" if $name =~ /^The ([A-Za-z']+) Crypts$/;
    $translation = "Laboratoire $1" if $name =~ /^([A-Za-z']+) Laboratory$/;
    $translation = "le Bastion de $1" if $name =~ /^The Stronghold of ([A-Za-z']+)$/;
    $translation = "la Crypte de $1" if $name =~ /^The Crypt of (Count [A-Za-z']+)$/;
    $translation = "la Crypte de $1" if $name =~ /^The Crypt of ([A-Za-z']+)$/;
    $translation = "la Carrière de $1" if $name =~ /^The Quarry of ([A-Za-z']+)$/;
    $translation = "Nid de $1" if $name =~ /^(\w+)'s Nest$/;
    $translation = "le Nid $1" if $name =~ /^The (\w+) Nest$/;
    $translation = "la Paroisse $1" if $name =~ /^The (\w+) Rectory$/;
    $translation = "le Mausolée de $1" if $name =~ /^The Masoleum of ([A-Za-z']+)$/; # typo!
    $translation = "le Tertre de $1" if $name =~ /^The Barrow of ([A-Za-z']+)$/;
    $translation = "le Filon $1" if $name =~ /^The (\w+) Lode$/;
    $translation = "Ruines de la Citadelle de $1" if $name =~ /^Ruins of The Citadel of ([A-Za-z']+)$/;
    $translation = "la Loge de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Lodge$/;
    $translation = "Reliquaire de $1" if $name =~ /^Reliquary of ([A-Za-z']+)$/;
    $translation = "le Repaire de $1" if $name =~ /^The Lair of ([A-Za-z']+)$/;
    $translation = "Verger de $1" if $name =~ /^([A-Za-z']+) Orchard$/;
    $translation = "l'Auberge de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Inn$/;
    $translation = "Grange de $1" if $name =~ /^([A-Za-z']+) Grange$/;
    $translation = "l'Abbaye de $1" if $name =~ /^The Abbey of ([A-Za-z']+)$/;
    $translation = "Tombeau de $1" if $name =~ /^((Baron|Lord) \w+)'s Tomb$/;
    $translation = "Tombeau de $1" if $name =~ /^(\w+)'s Tomb$/;
    $translation = "Communauté de $1" if $name =~ /^([A-Za-z-]+) Coven$/;
    $translation = "la Communauté de $1" if $name =~ /^The ([A-Za-z-]+) Coven$/;
    $translation = "les Mines de $1" if $name =~ /^The Mines of ([A-Za-z']+)$/;
    $translation = "Monument de $1" if $name =~ /^(\w+) Monument$/;
    $translation = "Ruines du Fort de $1" if $name =~ /^Ruins of ([A-Za-z']+)'s Hold$/;
    $translation = "Tertre de $1" if $name =~ /^((Lord|Marquis) \w+)'s Barrow$/;
    $translation = "Tertre de $1" if $name =~ /^(\w+)'s Barrow$/;
    $translation = "la Nécropole de $1" if $name =~ /^The ([A-Za-z']+) Graveyard$/;
    $translation = "la Demeure du $1" if $name =~ /^The House of ((Baron|Duke) [A-Za-z']+)$/;
    $translation = "la Demeure de $1" if $name =~ /^The House of ([A-Za-z']+)$/;
    $translation = "les Mines de $1" if $name =~ /^The ([A-Za-z']+) Mines$/;
    $translation = "les Tombes de $1" if $name =~ /^The Graves of ([A-Za-z']+)$/;
    $translation = "l'Aire $1" if $name =~ /^The (\w+) Aerie$/;
    $translation = "la Grotte de $1" if $name =~ /^The (\w+) Grotto$/;
    $translation = "la Carrière de $1" if $name =~ /^The ([A-Za-z']+) Quarry$/;
    $translation = "les Fouilles de $1" if $name =~ /^The ([A-Za-z']+) Excavation$/;
    $translation = "les Ruines de $1" if $name =~ /^The ([A-Za-z']+) Ruins$/;
    $translation = "la Cabale de $1" if $name =~ /^The ([A-Za-z'-]+) Cabal$/;
    $translation = "le Trou de $1" if $name =~ /^The Hole of ([A-Za-z']+)$/;
    $translation = "Hâvre de $1" if $name =~ /^(\w+) Haven$/;
    $translation = "le Trou de $1" if $name =~ /^The (\w+) Hole$/;
    $translation = "Tombes de $1" if $name =~ /^The ([A-Za-z']+) Tombs$/;
    $translation = "le Puits de $1" if $name =~ /^The Pit of ([A-Za-z']+)$/;
    $translation = "Théâtre de $1" if $name =~ /^([A-Za-z']+) Theatre$/;
    $translation = "Creux de $1" if $name =~ /^(\w+) Hollow$/;
    $translation = "la Caverne de $1" if $name =~ /^The Cavern of ([A-Za-z']+)$/;
    $translation = "la Volière de $1" if $name =~ /^The ([A-Za-z']+) Aviary$/;
    $translation = "le Cimetière de $1" if $name =~ /^The ([A-Za-z']+) Burial Ground$/;
    $translation = "Tanière de $1" if $name =~ /^([A-Za-z']+)'s Den$/;
    $translation = "Taverne de $1" if $name =~ /^([A-Za-z']+)'s Tavern$/;
    $translation = "Scourg Barrow" if $name =~ /^Scourg Barrow$/;
    $translation = "la Tombe du $1" if $name =~ /^The Grave of (Marquis [A-Za-z']+)$/;
    $translation = "la Tombe de $1" if $name =~ /^The Grave of ((Lord )?[A-Za-z']+)$/;
    $translation = "Auberge de $1" if $name =~ /^([A-Za-z']+)'s Inn$/;
    $translation = "l'Assemblée de $1" if $name =~ /^The ([A-Za-z'-]+) Assembly$/;
    $translation = "Autel de $1" if $name =~ /^Altar of ([A-Za-z']+)$/;
    $translation = "l'Académie de $1" if $name =~ /^The ([A-Za-z']+) Academy$/;
    $translation = "Communauté des Pics" if $name =~ /^Coven of the Peaks$/;
    $translation = "Communauté de la Marée" if $name =~ /^Coven of the Tide$/;
    $translation = "Communauté du Promontoire" if $name =~ /^Coven on the Bluff$/;
    $translation = "Communauté de la Poussière" if $name =~ /^Coven of Dust$/;
    $translation = "Ruines de la Forteresse de $1" if $name =~ /^Ruins of The Fortress of ([A-Za-z']+)$/;
    $translation = "Colline de $1" if $name =~ /^([A-Za-z']+) Hill$/;
    $translation = "Bruyère de $1" if $name =~ /^([A-Za-z']+) Heath$/;
    $translation = "la Geôle de $1" if $name =~ /^The Gaol of ([A-Za-z']+)$/;
    $translation = "la Grotte de $1" if $name =~ /^The Grotto of (\w+)$/;
    $translation = "Chênaie de $1" if $name =~ /^([A-Za-z']+) Derry$/;
    $translation = "la Tradition de $1" if $name =~ /^The ([A-Za-z']+) Tradition$/;
    $translation = "la Cabale de $1" if $name =~ /^The Cabal of ([A-Za-z']+)$/;
    $translation = "Rocher de $1" if $name =~ /^([A-Za-z']+) Rock$/;
    $translation = "Hameau de $1" if $name =~ /^([A-Za-z']+) Hamlet$/;
    $translation = "le Couvent de $1" if $name =~ /^The Convent of ([A-Za-z']+)$/;
    $translation = "Lande de $1" if $name =~ /^([A-Za-z']+) Moor$/;
    $translation = "la Prison de $1" if $name =~ /^The Prison of ([A-Za-z']+)$/;
    $translation = "Quartier de $1" if $name =~ /^([A-Za-z']+) Borough$/;
    $translation = "la Convocation de $1" if $name =~ /^The Convocation of ([A-Za-z']+)$/;
    $translation = "la Hantise de $1" if $name =~ /^The Haunt of ((Baron|Lord|Viscount) [A-Za-z']+)$/;
    $translation = "la Hantise de $1" if $name =~ /^The Haunt of ([A-Za-z']+)$/;
    $translation = "Bois de $1" if $name =~ /^([A-Za-z']+) Wood$/;
    $translation = "Terrain de $1" if $name =~ /^([A-Za-z']+) Commons$/;
    $translation = "le Nid $1" if $name =~ /^The Nest of (\w+)$/;
    $translation = "le Temple de $1" if $name =~ /^The Temple of ([A-Za-z']+)$/;
    $translation = "Geôle de $1" if $name =~ /^([A-Za-z']+)'s Gaol$/;
    $translation = "le Pénitencier de $1" if $name =~ /^The ([A-Za-z']+) Reformatory$/;
    $translation = "Pointe de $1" if $name =~ /^([A-Za-z']+) End$/;
    $translation = "Culte de $1" if $name =~ /^([A-Za-z'-]+) Cultus$/;
    $translation = "l'Enclume d'Ebonarm" if $name =~ /^Anvil of Ebonarm$/;
    $translation = "la Cathédrale de $1" if $name =~ /^The Cathedral of ([A-Za-z']+)$/;
    $translation = "le Donjon de $1" if $name =~ /^The Dungeon of ([A-Za-z']+)$/;
    $translation = "le Caveau de $1" if $name =~ /^The Vault of (Lord [A-Za-z']+)$/;
    $translation = "le Caveau de $1" if $name =~ /^The Vault of ([A-Za-z']+)$/;
    $translation = "la Cloître de $1" if $name =~ /^The ([A-Za-z']+) Cloister$/;
    $translation = "le Passage de $1" if $name =~ /^The ([A-Za-z']+) Mews$/;
    $translation = "la Caverne $1" if $name =~ /^The Cave of (\w+)$/;
    $translation = "la Conclave de $1" if $name =~ /^The Conclave of ([A-Za-z'-]+)$/;
    $translation = "Champ de $1" if $name =~ /^([A-Za-z'-]+) Field$/;
    $translation = "Jardin de $1" if $name =~ /^([A-Za-z'-]+) Garden$/;
    $translation = "le Culte de $1" if $name =~ /^The Cult of ([A-Za-z']+)$/;
    $translation = "la Volière de $1" if $name =~ /^The Aviary of ([A-Za-z']+)$/;
    $translation = "le Cercle de $1" if $name =~ /^The Circle of ([A-Za-z']+)$/;
    $translation = "la Convergence de $1" if $name =~ /^The ([A-Za-z']+) Convergence$/;
    $translation = "le Laboratoire de $1" if $name =~ /^The Laboratory of (\w+)$/;
    $translation = "l'Assemblée de $1" if $name =~ /^The Assembly of ([A-Za-z']+)$/;
    $translation = "la Prison de $1" if $name =~ /^The ([A-Za-z']+) Prison$/;
    $translation = "la Maison de Correction de $1" if $name =~ /^The ([A-Za-z']+) House of Correction$/;
    $translation = "le Château de $1" if $name =~ /^The Castle of (\w+)$/;
    $translation = "la Communauté de $1" if $name =~ /^The Coven of ([A-Za-z'-]+)$/;
    $translation = "Hauteurs de $1" if $name =~ /^([A-Za-z'-]+) Heights$/;
    $translation = "la Communauté de $1" if $name =~ /^The Community of ([A-Za-z-]+)$/;
    $translation = "la Retraite de $1" if $name =~ /^The ([A-Za-z']+) Asylum$/;
    $translation = "le Pénitencier de $1" if $name =~ /^The Penitentiary of ([A-Za-z-]+)$/;
    $translation = "le Rassemblement de $1" if $name =~ /^The Gathering of ([A-Za-z'-]+)$/;
    $translation = "le Conseil de $1" if $name =~ /^The ([A-Za-z']+) Council$/;
    $translation = "le Monastère de $1" if $name =~ /^The ([A-Za-z']+) Monastery$/;
    $translation = "le Monastère de $1" if $name =~ /^The Monastery of ([A-Za-z']+)$/;
    $translation = "le Perchoir de $1" if $name =~ /^The Roost of ([A-Za-z']+)$/;
    $translation = "le Poulailler de $1" if $name =~ /^The ([A-Za-z']+) Coop$/;
    $translation = "Mantellan Crux" if $name =~ /^Mantellan Crux$/;
    $translation = "Votre Vaisseau" if $name =~ /^Your Ship$/;
    $translation = "le Tombeau de Lysandus" if $name =~ /^Lysandus' Tomb$/;
    $translation = "Collines d'Ilessan" if $name =~ /^Ilessan Hills$/;
    
    die "No case matches <$name>" unless defined $translation;

    $translation =~ s/\bde le /du /g;
    $translation =~ s/^(.)/\U$1/;
    print "$id,$translation\n";
    
    $trads_inverses{$translation} = {} unless exists $trads_inverses{$translation};
    $trads_inverses{$translation}{$name} = 1;
}
close $LOCATIONS;

# Dump unknown names
if (0) {
    open my $UNKNOWN, '>', 'unknown_names.txt' or die 'Could not open unknown_names.txt';
    
    foreach my $name (sort { $inconnus{$b} <=> $inconnus{$a} } keys %inconnus) {
        print $UNKNOWN "$inconnus{$name}\t$name\n";
    }
    close $UNKNOWN;
}

my $collisions=0;
foreach my $trad (keys %trads_inverses) {
    if (scalar keys %{$trads_inverses{$trad}} > 1) {
        print STDERR "Perte d'unicité:\n" unless $collisions;
        print STDERR join(" | ", keys %{$trads_inverses{$trad}}). " => $trad\n";
        $collisions++;
    }
}
if ($collisions) {
    print STDERR "$collisions collision(s)\n";
}
