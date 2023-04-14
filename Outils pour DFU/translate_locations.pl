#!/usr/bin/perl
use strict;
use warnings;

# M masculin   ME masculin élidé ("l'oiseau")
# F féminin    FE féminin élidé ("l'otarie")
my (%name) = (
    'Altar' => [qw(ME autel)],
    'Ascencion' => [qw(ME ascension)],
    'Badger' => [qw(M blaireau)],
    'Barbarian' => [qw(M barbare)],
    'Bat' => [qw(F chauve-souris)],
    'Beaver' => [qw(M castor)],
    'Bird' => [qw(ME oiseau)],
    'Castle' => [qw(M château)],
    'Cat' => [qw(M chat)],
    'Chasm' => [qw(M gouffre)],
    'Dagger' => [qw(F Dague)],
    'Djinn' => [qw(M djinn)],
    'Dog' => [qw(M chien)],
    'Dragon' => [qw(M dragon)],
    'Dungeon' => [qw(M donjon)],
    'Dwarf' => [qw(M nain)],
    'Fairy' => [qw(F fée)],
    'Fawn' => [qw(M faon)],
    'Feather' => [qw(F plume)],
    'Fox' => [qw(M renard)],
    'Giant' => [qw(M géant)],
    'Gnome' => [qw(M gnome)],
    'Goat' => [qw(F chèvre)],
    'Goblin' => [qw(M gobelin)],
    'Griffin' => [qw(M griffon)],
    'Guard' => [qw(M garde)],
    'Hedgehog' => [qw(M hérisson)],
    'Helm' => [qw(M casque)],
    'Huntsman' => [qw(M chasseur)],
    'Idol' => [qw(FE idole)],
    'Jug' => [qw(F cruche)],
    'Knave' => [qw(M valet)],
    'Light' => [qw(F lumière)],
    'Lion' => [qw(M lion)],
    'Lynx' => [qw(M lynx)],
    'Martyr' => [qw(M martyre)],
    'Mole' => [qw(F taupe)],
    'Mouse' => [qw(F souris)],
    'Mug' => [qw(F tasse)],
    'Muskrat' => ["M", "rat musqué"],
    'Ogre' => [qw(ME ogre)],
    'Omen' => [qw(M présage)],
    'Oracle' => [qw(ME oracle)],
    'Pig' => [qw(M cochon)],
    'Pit' => [qw(M puits)],
    'Porcupine' => [qw(M porc-épic)],
    'Priest' => [qw(M prêtre)],
    'Prophet' => [qw(M prophète)],
    'Rascal' => [qw(M vaurien)],
    'Rat' => [qw(M rat)],
    'Rebirth' => [qw(F renaissance)],
    'Redeemer' => [qw(M rédempteur)],
    'Relic' => [qw(F relique)],
    'Scorpion' => [qw(M scorpion)],
    'Seer' => [qw(M devin)],
    'Skull' => [qw(M crâne)],
    'Soul' => [qw(FE âme)],
    'Stag' => [qw(M cerf)],
    'Star' => [qw(FE étoile)],
    'Sunrise' => ["M", "lever de soleil"],
    'Sword' => [qw(FE épée)],
    'Toad' => [qw(M crapaud)],
    'Tree' => [qw(ME arbre)],
    'Wolf' => [qw(M loup)],
    'Woodchuck' => [qw(F marmotte)],
    );
# Adjectif masculin, adjectif féminin
my (%adjectif) = (
    'Black' => [qw(noir noire)],
    'Bleeding' => [qw(saignant saignante)],
    'Blessed' => [qw(béni bénie)],
    'Burning' => [qw(brûlant brûlante)],
    'Crimson' => [qw(cramoisi cramoisie)],
    'Dancing' => [qw(dansant dansante)],
    'Dead' => [qw(mort morte)],
    'Dirty' => [qw(sale sale)],
    "Devil's" => ["du diable", "du diable"],
    'Eternal' => [qw(éternel éternelle)],
    'Fearful' => [qw(craintif craintive)],
    'Flying' => [qw(volant volante)],
    'Gentle' => [qw(doux douce)],
    'Gold' => [qw(doré dorée)],
    'Green' => [qw(vert verte)],
    'Holy' => [qw(saint sainte)],
    'Howling' => [qw(hurlant hurlante)],
    'Infinite' => [qw(infini infinie)],
    'Inner' => [qw(intérieur intérieure)],
    'Joyous' => [qw(joyeux joyeuse)],
    "King's" => ["du roi", "du roi"],
    'Laughing' => [qw(riant riante)],
    'Lucky' => [qw(chanceux chanceuse)],
    'Old' => [qw(vieux vieille)],
    'Perpetual' => [qw(perpétuel perpétuelle)],
    "Queen's" => ["de la reine", "de la reine"],
    'Red' => [qw(rouge rouge)],
    'Restless' => [qw(agité agitée)],
    'Rusty' => [qw(rouillé rouillée)],
    'Sacred' => [qw(sacré sacrée)],
    'Savage' => [qw(sauvage sauvage)],
    'Screaming' => [qw(criant criante)],
    'Silent' => [qw(silencieux silencieuse)],
    'Silver' => [qw(argenté argentée)],
    'Singing' => [qw(chantant chantante)],
    'Thirsty' => [qw(assoiffé assoiffée)],
    'Unfortunate' => [qw(regrettable regrettable)],
    'Wailing' => [qw(gémissant gémissante)],
    'Weeping' => [qw(larmoyant larmoyante)],
    'White' => [qw(blanc blanche)],
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
    $art = article_nom($name);
    $a = $adj->[0] if $name->[0] eq 'M';
    $a = $adj->[0] if $name->[0] eq 'ME';
    $a = $adj->[1] if $name->[0] eq 'F';
    $a = $adj->[1] if $name->[0] eq 'FE';
    $a = $adj->[0] if $name->[0] eq 'U';
    die "Don't know genre $name->[0]" unless defined $a;
    return "$art$a $name->[1]" if $adj->[0] =~ /^(doux|vieux)$/;
    return "$art$name->[1] $a";
}

my $header = <$LOCATIONS>;
print $header;

my $line_number = 1;
while(my $line = <$LOCATIONS>) {
    $line_number++;
    chomp $line;
    my ($id, $name) = split(/,\s*/, $line);
    my $translation;
    $translation = "manoir $1" if $name =~ /^([A-Za-z']+) Manor$/;
    $translation = "l'hôtel de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Hostel$/;
    $translation = "l'hôtel de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Hostel$/;
    $translation = "l'auberge de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Inn$/;
    $translation = "la cabane de ".accord_adj($2, $1) if $name =~ /^The (\w+) ([A-Za-z']+) Shack$/;
    $translation = "ruines de la cour de ferme $1" if $name =~ /^Ruins of The ([A-Za-z']+) Farmstead$/;
    $translation = accord_adj($2, $1)." de $3" if $name =~ /^(\w+) (\w+) of (Akatosh|Arkay|Dibella|Julianos|Kynareth|Mara|Stendarr|Zenithar)$/;
    $translation = "la garde de $1" if $name =~ /^([A-Za-z']+?)('s)? Guard$/;
    $translation = "lieu de ".accord_adj($2, $1) if $name =~ /^(\w+) ([A-Za-z'-]+?)('s)? Place$/;
    $translation = "le lieu de ".accord_adj($2, $1) if $name =~ /^The (\w+) ([A-Za-z']+?)('s)? Place$/;
    $translation = $name if $name =~ /^([A-Za-z'-]+)\s*$/;
    $translation = "les tombeaux de $1" if $name =~ /^The Tombs of ([A-Za-z']+)$/;
    $translation = "les cryptes de $1" if $name =~ /^THe Crypts of ([A-Za-z']+)$/;
    $translation = "ruines du lieu de ".accord_adj($2, $1) if $name =~ /^Ruins of (\w+) ([A-Za-z'-]+)('s)? Place$/;
    $translation = "les ruines du lieu de ".accord_adj($2, $1) if $name =~ /^Ruins of The (\w+) ([A-Za-z']+)('s)? Place$/;
    $translation = "la cour de ferme de $1" if $name =~ /^The ([A-Za-z']+) Farmstead$/;
    $translation = "château de $1" if $name =~ /^Castle ((Count|Duke|Lord|Viscount) [A-Za-z']+)$/;
    $translation = "château $1" if $name =~ /^Castle ([A-Za-z']+)$/;
    $translation = "les caveaux $1" if $name =~ /^The ([A-Za-z']+) Vaults$/;
    $translation = "ruines du palace $1" if $name =~ /^Ruins of ([A-Za-z']+) Palace$/;
    $translation = "ruines du verger $1" if $name =~ /^Ruins of ([A-Za-z']+) Orchard$/;
    $translation = "la toile de $2" if $name =~ /^(The )?([A-Za-z']+) Web$/;
    $translation = "la tour de $1" if $name =~ /^The Tower of ([A-Za-z']+)$/;
    $translation = "ruines du manoir de $1" if $name =~ /^Ruins of ([A-Za-z']+) Manor$/;
    $translation = "ruines de la grange de $1" if $name =~ /^Ruins of ([A-Za-z']+) Grange$/;
    $translation = "ruines de la garde de $1" if $name =~ /^Ruins of ([A-Za-z']+) Guard$/;
    $translation = "la taverne de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Tavern$/;
    $translation = "grange $1" if $name =~ /^(\w+) Grange$/;
    $translation = "ruines de la cabane de ".accord_adj($2, $1) if $name =~ /^Ruins of (\w+) ([A-Za-z'-]+)'s Shack$/;
    $translation = "ruines de la cabane de ".accord_adj($2, $1) if $name =~ /^Ruins of The (\w+) ([A-Za-z'-]+) Shack$/;
    $translation = "ruines de la cour de $1" if $name =~ /^Ruins of ([A-Za-z']+) Court$/;
    $translation = "ruines du castel $1" if $name =~ /^Ruins of ([A-Za-z']+) Hall$/;
    $translation = "palace $1" if $name =~ /^([A-Za-z']+) Palace$/;
    $translation = "la taverne de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Tavern$/;
    $translation = "ruines de la ferme de ".accord_adj($2, $1) if $name =~ /^Ruins of (\w+) ([A-Za-z'-]+)'s Farm$/;
    $translation = "la nécropole $1" if $name =~ /^The (\w+) Graveyard$/;
    $translation = "le presbytère $1" if $name =~ /^The (\w+) Manse$/;
    $translation = "le cairn de $1" if $name =~ /^The Cairn of (Marquis \w+)$/;
    $translation = "le cairn de $1" if $name =~ /^The Cairn of (\w+)$/;
    $translation = "le sépulcre de $1" if $name =~ /^The Sepulcher of (\w+)$/;
    $translation = "castel de $1" if $name =~ /^(Baron [A-Za-z']+) Hall$/;
    $translation = "castel $1" if $name =~ /^([A-Za-z']+) Hall$/;
    $translation = "la citadelle de $1" if $name =~ /^The Citadel of ([A-Za-z']+)$/;
    $translation = "la tour $1" if $name =~ /^Tower ([A-Za-z']+)$/;
    $translation = "la cabane de ".accord_adj($2, $1) if $name =~ /^(\w+) ([A-Za-z'-]+)'s Shack$/;
    $translation = "cour $1" if $name =~ /^([A-Za-z']+) Court$/;
    $translation = "le puits $1" if $name =~ /^The (\w+) Pit$/;
    $translation = "l'ermitage $1" if $name =~ /^The (\w+) Hermitage$/;
    $translation = "tour $1" if $name =~ /^([A-Za-z']+) Tower$/;
    $translation = "ruines de la tour $1" if $name =~ /^Ruins of ([A-Za-z']+) Tower$/;
    $translation = "le monastère de $1" if $name =~ /^The Friary of (\w+)$/;
    $translation = "le cimetière $1" if $name =~ /^The ([A-Za-z']+) Cemetery$/;
    $translation = "ruines de la plantation $1" if $name =~ /^Ruins of The ([A-Za-z']+) Plantation$/;
    $translation = "communauté des marécages" if $name =~ /^Coven in the Marsh$/;
    $translation = "la toile de $1" if $name =~ /^The Web of (\w+)$/;
    $translation = "la caverne $1" if $name =~ /^The (\w+) Cave$/;
    $translation = "taudis de ".accord_adj($2, $1) if $name =~ /^(\w+) ([A-Za-z'-]+)'s Hovel$/;
    $translation = "le fort de $1" if $name =~ /^The Hold of ([A-Za-z']+)$/;
    $translation = "la loge de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Lodge$/;
    $translation = "ruines de la tour de $1" if $name =~ /^Ruins of The Tower of ([A-Za-z']+)$/;
    $translation = "le tunnel $1" if $name =~ /^The ([A-Za-z']+) Tunnel$/;
    $translation = "la cabine $1" if $name =~ /^The ([A-Za-z']+) Cabin$/;
    $translation = "le tombeau de $1" if $name =~ /^The Tomb of (\w+)$/;
    $translation = "ruines du château de $1" if $name =~ /^Ruins of Castle ([A-Za-z']+)$/;
    $translation = "le bistrot de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Pub$/;
    $translation = "la loge de $1" if $name =~ /^(\w+) Lodge$/;
    $translation = "la forteresse de $1" if $name =~ /^The Fortress of ([A-Za-z']+)$/;
    $translation = "ruines de la tour $1" if $name =~ /^Ruins of Tower ([A-Za-z']+)$/;
    $translation = "la caverne de $1" if $name =~ /^The (\w+) Cavern$/;
    $translation = "le bistrot de ".accord_adj($2, $1) if $name =~ /^The ([A-Za-z']+) (\w+) Pub$/;
    $translation = "ruines de la cabine de $1" if $name =~ /^Ruins of The ([A-Za-z']+) Cabin$/;
    $translation = "ruines du taudis de ".accord_adj($3, $2) if $name =~ /^Ruins of (The )?(\w+) ([A-Za-z'-]+?)('s)? Hovel$/;
    $translation = "sanctuaire de $1" if $name =~ /^(\w+( \w+)?) Shrine$/;
    $translation = "refuge de $1" if $name =~ /^Shelter of (\w+)$/;
    $translation = "l'église de $1" if $name =~ /^(\w+) Minster$/;
    $translation = "le taudis de ".accord_adj($2, $1) if $name =~ /^The (\w+) ([A-Za-z'-]+) Hovel$/;
    $translation = "ferme de ".accord_adj($2, $1) if $name =~ /^(\w+) ([A-Za-z'-]+)'s Farm$/;
    $translation = "fort de $1" if $name =~ /^([A-Za-z']+)'s Hold$/;
    $translation = "sanctuaire de $1" if $name =~ /^Shrine of ([A-Za-z']+)$/;
    $translation = "le sanctuaire de $1" if $name =~ /^The Shrine of ([A-Za-z']+)$/;
    $translation = "la tanière de $1" if $name =~ /^The Den of ([A-Za-z']+)$/;
    $translation = "la plantation de $1" if $name =~ /^The ([A-Za-z']+) Plantation$/;
    $translation = "ruines du fort de $1" if $name =~ /^Ruins of The Hold of ([A-Za-z']+)$/;
    $translation = "les cryptes $1" if $name =~ /^The ([A-Za-z']+) Crypts$/;
    $translation = "laboratoire $1" if $name =~ /^([A-Za-z']+) Laboratory$/;
    $translation = "le bastion de $1" if $name =~ /^The Stronghold of ([A-Za-z']+)$/;
    $translation = "la crypte de $1" if $name =~ /^The Crypt of (Count [A-Za-z']+)$/;
    $translation = "la crypte de $1" if $name =~ /^The Crypt of ([A-Za-z']+)$/;
    $translation = "la carrière de $1" if $name =~ /^The Quarry of ([A-Za-z']+)$/;
    $translation = "nid de $1" if $name =~ /^(\w+)'s Nest$/;
    $translation = "le nid $1" if $name =~ /^The (\w+) Nest$/;
    $translation = "la paroisse $1" if $name =~ /^The (\w+) Rectory$/;
    $translation = "le mausolée de $1" if $name =~ /^The Masoleum of ([A-Za-z']+)$/; # typo!
    $translation = "le tertre de $1" if $name =~ /^The Barrow of ([A-Za-z']+)$/;
    $translation = "le filon $1" if $name =~ /^The (\w+) Lode$/;
    $translation = "ruines de la citadelle de $1" if $name =~ /^Ruins of The Citadel of ([A-Za-z']+)$/;
    $translation = "la loge de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Lodge$/;
    $translation = "reliquaire de $1" if $name =~ /^Reliquary of ([A-Za-z']+)$/;
    $translation = "le repaire de $1" if $name =~ /^The Lair of ([A-Za-z']+)$/;
    $translation = "verger de $1" if $name =~ /^([A-Za-z']+) Orchard$/;
    $translation = "l'auberge de ".accord_nom($1)." et de ".accord_nom($2) if $name =~ /^The (\w+) and (\w+) Inn$/;
    $translation = "grange de $1" if $name =~ /^([A-Za-z']+) Grange$/;
    $translation = "l'abbaye de $1" if $name =~ /^The Abbey of ([A-Za-z']+)$/;
    $translation = "tombeau de $1" if $name =~ /^((Baron|Lord) \w+)'s Tomb$/;
    $translation = "tombeau de $1" if $name =~ /^(\w+)'s Tomb$/;
    $translation = "communauté de $1" if $name =~ /^([A-Za-z-]+) Coven$/;
    $translation = "la communauté de $1" if $name =~ /^The ([A-Za-z-]+) Coven$/;
    $translation = "les mines de $1" if $name =~ /^The Mines of ([A-Za-z']+)$/;
    $translation = "monument de $1" if $name =~ /^(\w+) Monument$/;
    $translation = "ruines du fort de $1" if $name =~ /^Ruins of ([A-Za-z']+)'s Hold$/;
    $translation = "tertre de $1" if $name =~ /^((Lord|Marquis) \w+)'s Barrow$/;
    $translation = "tertre de $1" if $name =~ /^(\w+)'s Barrow$/;
    $translation = "la nécropole de $1" if $name =~ /^The ([A-Za-z']+) Graveyard$/;
    $translation = "la demeure du $1" if $name =~ /^The House of ((Baron|Duke) [A-Za-z']+)$/;
    $translation = "la demeure de $1" if $name =~ /^The House of ([A-Za-z']+)$/;
    $translation = "les mines de $1" if $name =~ /^The ([A-Za-z']+) Mines$/;
    $translation = "les tombes de $1" if $name =~ /^The Graves of ([A-Za-z']+)$/;
    $translation = "l'aire $1" if $name =~ /^The (\w+) Aerie$/;
    $translation = "la grotte de $1" if $name =~ /^The (\w+) Grotto$/;
    $translation = "la carrière de $1" if $name =~ /^The ([A-Za-z']+) Quarry$/;
    $translation = "les fouilles de $1" if $name =~ /^The ([A-Za-z']+) Excavation$/;
    $translation = "les ruines de $1" if $name =~ /^The ([A-Za-z']+) Ruins$/;
    $translation = "la cabale de $1" if $name =~ /^The ([A-Za-z'-]+) Cabal$/;
    $translation = "le trou de $1" if $name =~ /^The Hole of ([A-Za-z']+)$/;
    $translation = "hâvre de $1" if $name =~ /^(\w+) Haven$/;
    $translation = "le trou de $1" if $name =~ /^The (\w+) Hole$/;
    $translation = "les tombeaux de $1" if $name =~ /^The ([A-Za-z']+) Tombs$/;
    $translation = "le puits de $1" if $name =~ /^The Pit of ([A-Za-z']+)$/;
    $translation = "théâtre de $1" if $name =~ /^([A-Za-z']+) Theatre$/;
    $translation = "creux de $1" if $name =~ /^(\w+) Hollow$/;
    $translation = "la caverne de $1" if $name =~ /^The Cavern of ([A-Za-z']+)$/;
    $translation = "la volière de $1" if $name =~ /^The ([A-Za-z']+) Aviary$/;
    $translation = "le cimetière de $1" if $name =~ /^The ([A-Za-z']+) Burial Ground$/;
    $translation = "tanière de $1" if $name =~ /^([A-Za-z']+)'s Den$/;
    $translation = "taverne de $1" if $name =~ /^([A-Za-z']+)'s Tavern$/;
    $translation = "scourg barrow" if $name =~ /^Scourg Barrow$/;
    $translation = "la tombe du $1" if $name =~ /^The Grave of (Marquis [A-Za-z']+)$/;
    $translation = "la tombe de $1" if $name =~ /^The Grave of ((Lord )?[A-Za-z']+)$/;
    $translation = "auberge de $1" if $name =~ /^([A-Za-z']+)'s Inn$/;
    $translation = "l'assemblée de $1" if $name =~ /^The ([A-Za-z'-]+) Assembly$/;
    $translation = "autel de $1" if $name =~ /^Altar of ([A-Za-z']+)$/;
    $translation = "l'académie de $1" if $name =~ /^The ([A-Za-z']+) Academy$/;
    $translation = "communauté des pics" if $name =~ /^Coven of the Peaks$/;
    $translation = "communauté de la marée" if $name =~ /^Coven of the Tide$/;
    $translation = "communauté du promontoire" if $name =~ /^Coven on the Bluff$/;
    $translation = "communauté de la poussière" if $name =~ /^Coven of Dust$/;
    $translation = "ruines de la forteresse de $1" if $name =~ /^Ruins of The Fortress of ([A-Za-z']+)$/;
    $translation = "colline de $1" if $name =~ /^([A-Za-z']+) Hill$/;
    $translation = "bruyère de $1" if $name =~ /^([A-Za-z']+) Heath$/;
    $translation = "la geôle de $1" if $name =~ /^The Gaol of ([A-Za-z']+)$/;
    $translation = "la grotte de $1" if $name =~ /^The Grotto of (\w+)$/;
    $translation = "chênaie de $1" if $name =~ /^([A-Za-z']+) Derry$/;
    $translation = "la tradition de $1" if $name =~ /^The ([A-Za-z']+) Tradition$/;
    $translation = "la cabale de $1" if $name =~ /^The Cabal of ([A-Za-z']+)$/;
    $translation = "rocher de $1" if $name =~ /^([A-Za-z']+) Rock$/;
    $translation = "hameau de $1" if $name =~ /^([A-Za-z']+) Hamlet$/;
    $translation = "le couvent de $1" if $name =~ /^The Convent of ([A-Za-z']+)$/;
    $translation = "lande de $1" if $name =~ /^([A-Za-z']+) Moor$/;
    $translation = "la prison de $1" if $name =~ /^The Prison of ([A-Za-z']+)$/;
    $translation = "quartier de $1" if $name =~ /^([A-Za-z']+) Borough$/;
    $translation = "la convocation de $1" if $name =~ /^The Convocation of ([A-Za-z']+)$/;
    $translation = "la hantise de $1" if $name =~ /^The Haunt of ((Baron|Lord|Viscount) [A-Za-z']+)$/;
    $translation = "la hantise de $1" if $name =~ /^The Haunt of ([A-Za-z']+)$/;
    $translation = "bois de $1" if $name =~ /^([A-Za-z']+) Wood$/;
    $translation = "terrain de $1" if $name =~ /^([A-Za-z']+) Commons$/;
    $translation = "le nid $1" if $name =~ /^The Nest of (\w+)$/;
    $translation = "le temple de $1" if $name =~ /^The Temple of ([A-Za-z']+)$/;
    $translation = "geôle de $1" if $name =~ /^([A-Za-z']+)'s Gaol$/;
    $translation = "le pénitencier de $1" if $name =~ /^The ([A-Za-z']+) Reformatory$/;
    $translation = "pointe de $1" if $name =~ /^([A-Za-z']+) End$/;
    $translation = "culte de $1" if $name =~ /^([A-Za-z'-]+) Cultus$/;
    $translation = "l'enclume d'Ebonarm" if $name =~ /^Anvil of Ebonarm$/;
    $translation = "la cathédrale de $1" if $name =~ /^The Cathedral of ([A-Za-z']+)$/;
    $translation = "le donjon de $1" if $name =~ /^The Dungeon of ([A-Za-z']+)$/;
    $translation = "le caveau de $1" if $name =~ /^The Vault of (Lord [A-Za-z']+)$/;
    $translation = "le caveau de $1" if $name =~ /^The Vault of ([A-Za-z']+)$/;
    $translation = "la cloître de $1" if $name =~ /^The ([A-Za-z']+) Cloister$/;
    $translation = "le passage de $1" if $name =~ /^The ([A-Za-z']+) Mews$/;
    $translation = "la caverne $1" if $name =~ /^The Cave of (\w+)$/;
    $translation = "la conclave de $1" if $name =~ /^The Conclave of ([A-Za-z'-]+)$/;
    $translation = "champ de $1" if $name =~ /^([A-Za-z'-]+) Field$/;
    $translation = "jardin de $1" if $name =~ /^([A-Za-z'-]+) Garden$/;
    $translation = "le culte de $1" if $name =~ /^The Cult of ([A-Za-z']+)$/;
    $translation = "la volière de $1" if $name =~ /^The Aviary of ([A-Za-z']+)$/;
    $translation = "le cercle de $1" if $name =~ /^The Circle of ([A-Za-z']+)$/;
    $translation = "la convergence de $1" if $name =~ /^The ([A-Za-z']+) Convergence$/;
    $translation = "le laboratoire de $1" if $name =~ /^The Laboratory of (\w+)$/;
    $translation = "l'assemblée de $1" if $name =~ /^The Assembly of ([A-Za-z']+)$/;
    $translation = "la prison de $1" if $name =~ /^The ([A-Za-z']+) Prison$/;
    $translation = "la maison de correction de $1" if $name =~ /^The ([A-Za-z']+) House of Correction$/;
    $translation = "le château de $1" if $name =~ /^The Castle of (\w+)$/;
    $translation = "la communauté de $1" if $name =~ /^The Coven of ([A-Za-z'-]+)$/;
    $translation = "hauteurs de $1" if $name =~ /^([A-Za-z'-]+) Heights$/;
    $translation = "la communauté de $1" if $name =~ /^The Community of ([A-Za-z-]+)$/;
    $translation = "la retraite de $1" if $name =~ /^The ([A-Za-z']+) Asylum$/;
    $translation = "la pénitencier de $1" if $name =~ /^The Penitentiary of ([A-Za-z-]+)$/;
    $translation = "le rassemblement de $1" if $name =~ /^The Gathering of ([A-Za-z'-]+)$/;
    $translation = "le conseil de $1" if $name =~ /^The ([A-Za-z']+) Council$/;
    $translation = "le monastère de $1" if $name =~ /^The ([A-Za-z']+) Monastery$/;
    $translation = "le monastère de $1" if $name =~ /^The Monastery of ([A-Za-z']+)$/;
    $translation = "le perchoir de $1" if $name =~ /^The Roost of ([A-Za-z']+)$/;
    $translation = "le poulailler de $1" if $name =~ /^The ([A-Za-z']+) Coop$/;
    $translation = "Mantellan Crux" if $name =~ /^Mantellan Crux$/;
    $translation = "votre vaisseau" if $name =~ /^Your Ship$/;
    $translation = "le tombeau de Lysandus" if $name =~ /^Lysandus' Tomb$/;
    $translation = "collines d'Ilessan" if $name =~ /^Ilessan Hills$/;
    
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
