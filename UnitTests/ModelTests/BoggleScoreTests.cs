using Boggle.Shared.Interfaces;
using Boggle.Shared.Models;
using Boggle.Shared.ViewModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests.ModelTests
{
    [TestFixture]
    public class BoggleScoreTests
    {
        public BoggleGameViewModel gameVM = new BoggleGameViewModel(new MainViewModel(), new Mock<IDataService>().Object);
        public BoggleGame BoggleGame;

        [SetUp]
        public void SetUp()
        {
            //Setup test game grid
            string[] r1 = new string[4] { "S", "E", "R", "S" };
            string[] r2 = new string[4] { "P", "A", "T", "G" };
            string[] r3 = new string[4] { "L", "I", "N", "E" };
            string[] r4 = new string[4] { "S", "E", "R", "S" };
            string[][] grid = new string[4][] { r1, r2, r3, r4 };
            BoggleGame = new BoggleGame("FakeUser");
            BoggleGame.GameBoard.GameGrid = grid;
            gameVM.TheGame = BoggleGame;
            BoggleGame.ListOfPossibleAnswers = possibleGuesses;
        }

        [TestCase("Hi", 0)]
        [TestCase("we", 0)]
        [TestCase(".-", 0)]
        public void Test2LetterScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            gameVM.TheGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, gameVM.TheGame.GetScore());
        }

        [TestCase("pal", 1)]
        [TestCase("ale", 1)]
        [TestCase("Hi!", 0)]
        public void Test3LetterScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            gameVM.TheGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, gameVM.TheGame.GetScore());
        }

        [TestCase("sang", 1)]
        [TestCase("line", 1)]
        [TestCase("lats", 1)]
        public void Test4LetterScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            gameVM.TheGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, gameVM.TheGame.GetScore());
        }

        [TestCase("getas", 2)]
        [TestCase("liter", 2)]

        public void Test5LetterScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            gameVM.TheGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, gameVM.TheGame.GetScore());
        }

        [TestCase("plaits", 3)]
        [TestCase("tenail", 3)]
        public void Test6LettersScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            gameVM.TheGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, gameVM.TheGame.GetScore());
        }

        [TestCase("sternal", 4)]
        [TestCase("ALIENER", 4)]
        public void Test7LettersScoreIsCalculatedCorrectly(string word, int expectedScore)
        {
            gameVM.TheGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, gameVM.TheGame.GetScore());
        }

        [TestCase("trailers", 11)]
        [TestCase("entrails", 11)]
        public void Test8LettersScoreIsCalulatedCorrectly(string word, int expectedScore)
        {
            gameVM.TheGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, gameVM.TheGame.GetScore());
        }

        [TestCase("elaterins", 11)]
        [TestCase("GRAPLINES", 11)]
        public void Test8PlusLettersScoreIsCalulatedCorrectly(string word, int expectedScore)
        {
            gameVM.TheGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, gameVM.TheGame.GetScore());
        }

        [TestCase("set", 1)]
        [TestCase("peal", 1)]
        [TestCase("snips", 2)]
        [TestCase("liners", 3)]
        [TestCase("granite", 4)]
        [TestCase("Integrals", 11)]
        public void TestThatNoPointsAreAddedForDuplicateWords(string word, int expectedScore)
        {
            gameVM.TheGame.SubmitGuess(word);
            gameVM.TheGame.SubmitGuess(word);
            Assert.AreEqual(expectedScore, gameVM.TheGame.GetScore());
        }

        public List<string> possibleGuesses = new List<string>() { "SIR", "SALIENT", "SPITE", "SIT", "SALIENTS", "SAILER", "ESPALIER", "SPITS", "RESINATES",
                "SIP", "ELANS", "LATEN", "SLINGERS", "SIN", "SLIPS", "ANGERS", "RETENES", "TAP", "RETE", "SEARS", "PAINTS", "PITS", "SEINE",
                "GRAILS", "PATENS", "RETS", "TAE", "TINE", "SERE", "PALES", "SLIPE", "PITA", "SPA", "TAN", "SAPLINGS", "LENSE", "SIPE",
                "LATER", "PLAINTS", "SATES", "RELINE", "REALISE", "SEGNI", "RETIE", "RENTES", "SPINETS", "RETIA", "PAILS", "SAINS", "LITER",
                "LIERNE", "SAINT", "SIPS", "NITERS", "ARGENT", "SEINER", "PANTS", "PLATE", "TAPS", "RASE", "STRANGER", "ESPIALS", "RESLATE",
                "PINES", "REPINS", "SEINES", "RAPINE", "LIANES", "TALIPES", "TAPE", "RESPITE", "RASP", "PLATS", "LAT", "ELINT", "LAP", "LAR",
                "LAS", "SANGERS", "GREAT", "PANTIE", "PINTAS", "SNIP", "RESPIRES", "SEAR", "RINGS", "SEAT", "STAINERS", "SEAL", "SANGER",
                "TENAILS", "TRAPS", "TANG", "PIAS", "LINTER", "LITS", "RETRAIN", "RESIN", "PIAN", "PIAL", "TRAINS", "PANTILES", "SERIN",
                "TANS", "PAINTER", "RATINGS", "GENIAL", "ENGRAIL", "SERIAL", "RELATING", "PARTIERS", "SPARGERS", "SINES", "GRATIN",
                "SLATINGS", "PETRALE", "LINERS", "TAPIR", "GENIPS", "PLIANT", "REPIN", "LITRES", "TREPANG", "ENTAILS", "ESPIAL", "LATENS",
                "TAR", "ERGS", "SAIN", "SAIL", "STAPLING", "INS", "SLAIN", "ENS", "RANTS", "TENS", "RITE", "REIN", "LINTERS", "SPARGES",
                "SPARGER", "RAISE", "REPAIRS", "RES", "REP", "RET", "STRAIN", "REI", "PEALS", "SILANES", "STINGER", "SLATES", "SLATER",
                "ENGS", "PINAS", "REG", "REAPS", "PLANTS", "TING", "SPARS", "TINS", "SETA", "ANTIS", "ENISLE", "NAPE", "TERAIS", "SERENATE",
                "TREPAN", "SPARE", "PANIER", "NIPAS", "STRAINS", "REGRATE", "RAPING", "LASE", "PLAITER", "RIEL", "GENTILES", "SPIT",
                "ENTIRES", "PLAIN", "SITE", "REALES", "RESPITES", "RIPES", "PEATIER", "PLAIT", "REPAINTS", "ATES", "SINTER", "SITS", "SPIN",
                "RETRAL", "AILS", "GENRES", "SARGE", "PATES", "SEALERS", "SPINALS", "SNIPS", "ALE", "STRAINERS", "SEATERS", "SITAR",
                "TRAPLINES", "PATERS", "GERENTS", "ENTAILERS", "REPAINT", "ALS", "ALP", "AISLE", "RETAPING", "ERS", "ELATERIN", "SINTERS",
                "RETINA", "LINES", "LINER", "SPIRES", "RETINE", "RIPS", "ERE", "STEP", "ERG", "ERA", "REAP", "GRANITE", "RENTERS", "ENTRAP",
                "ERN", "TINGES", "PATIN", "PANES", "SIAL", "SPAIT", "RETINAE", "STANES", "RENAILS", "NAILS", "RETINAL", "LINTS", "TIRES",
                "RETINAS", "RETAINERS", "RILE", "SPANIELS", "SPAIL", "RIALS", "PANEL", "ARETES", "NITE", "GREATENS", "REPLIERS", "PEART",
                "RAIL", "ANTS", "PINTS", "LAIN", "EATINGS", "ANTI", "GETS", "STEALING", "ANTE", "SNIPE", "TRAINER", "LAPINS", "ELATE",
                "PALINGS", "GENT", "SEPIA", "ETERNAL", "SALES", "STERNA", "SILENTS", "RAPIERS", "PLIE", "LINGERS", "RIELS", "GENE", "STERE",
                "SENATES", "RATINE", "LIE", "LAPSER", "SERIATE", "TARE", "LIN", "LINT", "LINS", "LIENS", "SLANTS", "LIT", "LIP", "LIS",
                "LING", "RESAILS", "LINE", "RELAPSER", "TENIAE", "PARTNERS", "RAISERS", "RETAILS", "RATING", "SAL", "RAN", "SAE", "TARGE",
                "PAINTERS", "RAT", "SEATINGS", "RAS", "RAP", "SEATS", "PANIERS", "GRAPLIN", "SAP", "LAPIS", "SAT", "SERIALS", "TREPANS",
                "SPINE", "RANI", "PALS", "TILER", "SEREIN", "LIPS", "SRIS", "REPLANT", "TRANS", "PALE", "PIES", "SPINS", "ETAPE", "TALI",
                "SPANG", "SAPLING", "PLATEN", "SNITS", "SPEAR", "RESALES", "AIRNS", "STEAL", "TRAIL", "RETAINER", "TRAIN", "PILE", "SPANS",
                "PLATER", "PLATES", "SPEAN", "STEALER", "ELITES", "APE", "LITRE", "PAIRS", "STAR", "REGRET", "GENIES", "INGRATE", "PEAT",
                "SPLINTER", "PEAR", "PEAS", "RETENE", "PEAN", "PEAL", "TEARS", "TRAILERS", "SENE", "RING", "PIRN", "SILENT", "SLING", "RATERS",
                "REPLATING", "SLANT", "PLATERS", "RELIT", "SLATING", "RAIN", "SNARE", "LENIS", "SLANG", "ELAPINE", "STRANGE", "TENIA", "TEPAS",
                "ENG", "ANISE", "LIEN", "LIER", "LIES", "RANGE", "SET", "LIANE", "PEARS", "LIANG", "TERNS", "TEPAL", "STARES", "SER", "LARS",
                "TEN", "SATING", "EATS", "PETERS", "NAPES", "LITAS", "PEARTER", "RETIES", "PANG", "RALE", "STERILE", "SATINS", "EATERIES",
                "ATE", "PILES", "PERTAIN", "SLIPES", "REPLANTS", "ESPALIERS", "LIARS", "LAPIN", "RAPES", "RATS", "RENTALS", "STAPLE", "SERGE",
                "LANG", "TAILERS", "LANE", "ASP", "REPINERS", "SPLITS", "SALINES", "TINGE", "ENTERAL", "PLANET", "STILE", "SEPALS", "ARES",
                "PLANER", "PLANES", "SEN", "NILS", "PINGERS", "SPALES", "SEI", "PALIER", "SEA", "STAINER", "GETA", "PARGE", "SPINAL", "SETAE",
                "RAISER", "NEREIS", "PLIERS", "RETINES", "TARGES", "SATIS", "ARETE", "SEL", "SPAN", "RELAPSERS", "ETAS", "LITERS", "LIANGS",
                "SPAE", "GNARS", "ANES", "RETIRES", "PARTIER", "PARTIES", "SPAR", "PIRNS", "SATIN", "SETAL", "SPAT", "ENTRAPS", "PATS",
                "RETIAL", "GRATIS", "RAINS", "ALIENS", "STIRS", "SINS", "SEPAL", "GENS", "TIER", "PATE", "NIPA", "GESNERIA", "SALPINGES",
                "SERGES", "GRANTER", "PLANTERS", "ENTAIL", "GENITALS", "PLATING", "TAPING", "SANS", "GRAINS", "TEAR", "TEAS", "SEPALINE",
                "SANG", "SANE", "RESINS", "STRAPS", "TEAL", "STALER", "ASPIRE", "TIPS", "NETS", "SLAT", "SATE", "TEALS", "RETIRE", "LIAR",
                "SITARS", "STERN", "PLAITERS", "SPLENIA", "LENS", "PAINT", "SIRES", "SERINES", "STIPES", "RANIS", "PAINS", "PALING", "REINTER",
                "STAPES", "STRANG", "RINSE", "SEALER", "TAILER", "PLATIER", "PLATIES", "SLAINTE", "NIPS", "TERNES", "SAINTS", "LIERNES",
                "AIRN", "SPINATE", "PLATENS", "AIRS", "GREATEN", "TARS", "PINT", "RIAL", "STRAINER", "PERTER", "GRANITES", "PAR", "PAS",
                "PAT", "REPAIR", "SLAPS", "TRAILS", "PILAR", "ANIL", "SEGS", "RANGES", "RANGER", "REPINER", "REPINES", "SNIT", "TILS",
                "EGRETS", "INTER", "PAL", "PAN", "RESPIRE", "ASPERGES", "ALINERS", "REAPING", "LAPSERS", "RALES", "RIP", "SEALS", "ALIEN",
                "PERT", "REINS", "TAINS", "SNAP", "RIA", "PASE", "GRATINS", "SANIES", "SPIELS", "RISE", "TANGS", "ELAPSE", "SALP", "NAIL",
                "LITE", "GRATINE", "SINGE", "SPLENT", "SIPES", "REALS", "RATINES", "SPIER", "RINS", "RENTS", "NIL", "RETILE", "SPINEL",
                "SARGES", "TAIN", "TIS", "SPINES", "SPLINTERS", "SPINET", "REALISER", "ANTRES", "NIP", "REGNAL", "SENT", "TIERS", "TENAIL",
                "REPLAN", "SPIRE", "PEALING", "STEPS", "LARGE", "RATE", "GRAIN", "GRAIL", "APING", "TIES", "SERIES", "PANTIES", "GENTIL",
                "SALINE", "SLANGS", "GET", "STILES", "LARGES", "LARGER", "NARES", "SPATE", "ELINTS", "SEG", "SPATS", "STIR", "GEN", "NAPS",
                "APLITE", "ANTES", "PLANETS", "STAIR", "SIRE", "GENIP", "TALES", "TALER", "RESPLIT", "REPLATE", "SIRS", "APES", "SPLENTS",
                "GRAPES", "RASPING", "ELATERINS", "SAILS", "RANTER", "LIPASE", "ALPINE", "SAPIENS", "ANE", "SNAIL", "ALINE", "AINS", "LEIS",
                "PEANS", "ANI", "ITS", "ANT", "TEGS", "SLATS", "LAIRS", "PIA", "STAIN", "PARTNER", "STEALS", "SNIPES", "SNIPER", "NITES",
                "NITER", "LINGS", "GRAPE", "RANGERS", "ELATERS", "PET", "SNAPS", "PER", "PES", "ENTRAILS", "ETA", "GENIE", "ALIENER", "GENTS",
                "PEA", "ISLE", "RANTERS", "SINGER", "SINGES", "SANTIR", "PANGS", "LINGER", "LIERS", "NITRES", "SATIRE", "TRAINERS", "TALE",
                "ENTERA", "STREPS", "TRAILER", "RELATER", "TEPA", "ALINES", "ALINER", "SPAILS", "NAILER", "GNAT", "SIREN", "TRAIPSE", "TAIL",
                "ERNE", "SRI", "IRES", "LARES", "GENTILE", "RESINATE", "SLIT", "SLITS", "SLIP", "PAISE", "ETNA", "REPLIER", "ERNS", "ETAPES",
                "PIERS", "PALER", "STRANGERS", "TILES", "PINGER", "PANTILE", "STINGERS", "SPEANS", "PIT", "SAPIENT", "RENTE", "SPANIEL",
                "SPILES", "TRAP", "RESITES", "RIPE", "GENITAL", "ALIT", "EARS", "PILSENERS", "RAPIER", "REPANEL", "TAPIS", "ARGENTS", "RAPS",
                "AIT", "LAPSE", "SPLINT", "AIS", "AIR", "ENGRAILS", "AIL", "AIN", "STIPE", "LASERS", "SING", "RESLATES", "RETINALS", "PARGETS",
                "RENTAL", "SPLINE", "RAPE", "STAPLES", "TERN", "SINE", "TAPIRS", "SNARES", "SATIRES", "RENTER", "PARTINGS", "RISEN", "PATINES",
                "RETAIN", "RETAIL", "SPEARS", "RETRAINS", "TALERS", "PANS", "PLANERS", "SPLINES", "PANT", "TINGS", "GRAINER", "REGNA", "SPIERS",
                "STERNAL", "PANE", "PLAITS", "ERST", "IRE", "EGRET", "RETAPES", "ALPS", "RETEAR", "PLANT", "ARS", "ART", "PLANS", "TILERS",
                "PINA", "PING", "REPLANS", "PINE", "PLANE", "RESPLITS", "ARE", "PINS", "SATI", "ELITE", "SPLATS", "APSE", "PLIES", "PLIER",
                "PARE", "STERNS", "REALISERS", "NAE", "SENATE", "TIP", "RESAIL", "GREATS", "ALIENERS", "TIL", "SLATIER", "TIN", "PART", "PARS",
                "ERAS", "PILSENER", "RELINES", "TIE", "SPARGE", "ANIS", "APER", "ARTERIES", "TAPES", "PIN", "SENILE", "PIER", "TAPER", "RITES",
                "PIE", "SERES", "SENILES", "PETALINE", "RAPINES", "PIS", "PERTAINS", "RIANT", "GRANS", "APLITES", "STAPLER", "ELATES",
                "PIANS", "GRANT", "PARGET", "ELATER", "ENATES", "SEATING", "PARGES", "GRATE", "RETILES", "REPANELS", "PARTS", "SPINELS",
                "TRAPES", "SEALING", "ELATING", "REGRETS", "ANTRE", "ASPERS", "PETER", "LATS", "GETAS", "REPLATES", "STAINS", "ALES",
                "LATE", "TARES", "ENTAILER", "PLATINGS", "PLAINER", "REPLIES", "TERNE", "RILES", "LATI", "SANTIRS", "STERES", "SERIATES",
                "STARE", "PAIN", "RENAL", "PAIL", "RIN", "RELATE", "REGS", "SERAL", "NAP", "SPATES", "SERAI", "RETAILERS", "PAIR", "PARES",
                "GENTES", "SPITES", "ALPINES", "SERAILS", "GRATES", "GRATER", "LANES", "SERS", "PETAL", "STALE", "SITES", "NIT", "STING",
                "PLAINS", "SANER", "SANES", "TAILS", "PLAINT", "SERA", "STAIRS", "TINES", "TILE", "ELAIN", "PETRALES", "RAILER", "ENATE",
                "RETEARS", "SAILERS", "ARTS", "SPILE", "ETERNE", "NATES", "ENTERS", "RESLATING", "EATERS", "ETERNISE", "ETERNALS", "RASPIER",
                "RETAPE", "NITS", "INSETS", "GRAPIER", "LAIR", "RELATERS", "SPALE", "PATER", "EATER", "ASPIRES", "SPIES", "SPIEL", "TAPERS",
                "TREPANGS", "PINTA", "EATEN", "SENSE", "ASPER", "SNAILS", "PATEN", "SLINGS", "SLATE", "PLAN", "RANG", "EATING", "PETERING",
                "LENT", "REPS", "PATINE", "RAILS", "TENIAS", "RANT", "TAS", "GRANTS", "RATES", "RATER", "GRASP", "LASER", "NET", "PATINS",
                "RELATES", "RENAIL", "RESITE", "ELAINS", "RAILERS", "TIRE", "TEA", "GRAT", "SALE", "TEG", "RESALE", "TERAI", "GRAN", "SEATER",
                "REGRATES", "SALS", "ERNES", "PARTING", "ETNAS", "GRAINERS", "RELAPSE", "ARTIER", "STALES", "AITS", "SPLINTS", "SETS",
                "RETAILER", "REGRANTS", "SLAP", "PETALS", "RIAS", "RENT", "SINGERS", "ELS", "SEINERS", "SPITALS", "ENTIA", "SILANE", "STREP",
                "GREATER", "REINTERS", "REIS", "LEI", "LAPS", "INSET", "SPLAT", "INGRATES", "STEALERS", "LIRE", "SPAITS", "STANE", "REAL",
                "GRATERS", "PEATS", "SNIPERS", "GENES", "STANG", "SINGS", "STRAP", "INTEGRAL", "INTERS", "LENES", "SLINGER", "ELAN", "PINGS",
                "ENTER", "STIES", "REGRANT", "SILENTER", "SPITAL", "ENTIRE", "SENTI", "TRAPLINE", "APERS", "GERENT", "SERINS", "GNAR", "REPINE",
                "GRAPLINS", "SENTE", "NITRE", "RELIANT", "LISENTE", "PETS", "SLATERS", "ANGER", "GRAPLINE", "EAR", "SERING", "EAT", "SERINE",
                "NAILERS", "SIRENS", "TEPALS", "SLIER", "ANILS", "PLANTER", "ANGST", "GRANTERS", "ESPIES", "GRAPLINES", "PLAT", "ANILE",
                "SPLIT", "INTEGRALS", "REALER", "GNATS", "STALING", "PITAS", "SERAIS", "RIPER", "PLENA", "ASPIS", "STAPLERS", "RETAINS",
                "GENRE", "PINETA", "SERAIL", "PANELS" };
    }
}
