
CREATE TABLE adresy (
id_adresa        INTEGER DEFAULT adresy_seq.nextval NOT NULL,
ulice            VARCHAR2(64),
cislo_popisne    INTEGER NOT NULL,
cislo_orientacni INTEGER,
obec             INTEGER NOT NULL
)

ALTER TABLE adresy ADD CONSTRAINT adresy_pk PRIMARY KEY(id_adresa )

CREATE TABLE autobusy(
id_vozidlo INTEGER NOT NULL,
kloubovy NUMBER NOT NULL,
prevodovka INTEGER NOT NULL
)

ALTER TABLE autobusy ADD CONSTRAINT autobus_pk PRIMARY KEY(id_vozidlo )

CREATE TABLE cipove_karty(
id_cipova_karta INTEGER DEFAULT cipove_karty_seq.nextval NOT NULL,
cislo_karty INTEGER NOT NULL,
datum_vydani DATE NOT NULL,
datum_platnosti DATE NOT NULL,
povolena NUMBER NOT NULL,
drzitel INTEGER NOT NULL
)

ALTER TABLE cipove_karty ADD CONSTRAINT cipove_karty_pk PRIMARY KEY(id_cipova_karta )

ALTER TABLE cipove_karty ADD CONSTRAINT cipove_karty_cislo_karty_un UNIQUE(cislo_karty )

CREATE TABLE jizdni_rady(
id_jizdni_rad INTEGER DEFAULT jizdni_rady_seq.nextval NOT NULL,
cas_prijezdu DATE NOT NULL,
cas_odjezdu DATE NOT NULL,
poradove_cislo INTEGER NOT NULL,
varianta INTEGER NOT NULL,
linka INTEGER NOT NULL,
zastavka INTEGER NOT NULL
)

ALTER TABLE jizdni_rady ADD CONSTRAINT jizdni_rady_pk PRIMARY KEY(id_jizdni_rad )

CREATE TABLE linky(
id_linka INTEGER DEFAULT linky_seq.nextval NOT NULL,
kod CHAR(3) NOT NULL
)

ALTER TABLE linky ADD CONSTRAINT linky_pk PRIMARY KEY(id_linka )

ALTER TABLE linky ADD CONSTRAINT linky_kod_un UNIQUE(kod )

CREATE TABLE modely(
id_model INTEGER DEFAULT modely_seq.nextval NOT NULL,
nazev VARCHAR2(64) NOT NULL,
mista_sezeni  INTEGER NOT NULL,
mista_stani INTEGER NOT NULL,
klimatizace   NUMBER NOT NULL,
nizkopodlazni NUMBER NOT NULL,
palivo        VARCHAR2(16) NOT NULL,
vyrobce       INTEGER NOT NULL
)

ALTER TABLE modely ADD CONSTRAINT modely_pk PRIMARY KEY(id_model )

CREATE TABLE obce(
id_obec INTEGER DEFAULT obce_seq.nextval NOT NULL,
nazev VARCHAR2(64) NOT NULL,
cast_obce VARCHAR2(64),
psc VARCHAR(16) NOT NULL,
stat      INTEGER NOT NULL
)

ALTER TABLE obce ADD CONSTRAINT obce_pk PRIMARY KEY(id_obec )

CREATE TABLE osoby(
id_osoba INTEGER DEFAULT osoby_seq.nextval NOT NULL,
jmeno VARCHAR2(64) NOT NULL,
prijmeni VARCHAR2(64) NOT NULL,
e_mail   VARCHAR2(320) NOT NULL,
telefon  CHAR(14) NOT NULL
)

CREATE TABLE opravneni (
    id_opravneni    INTEGER DEFAULT opravneni_seq.nextval NOT NULL,
    nazev           VARCHAR2(64) NOT NULL,
    systemovy_nazev VARCHAR2(64) NOT NULL
)

ALTER TABLE opravneni ADD CONSTRAINT opravneni_pk PRIMARY KEY ( id_opravneni )

ALTER TABLE osoby ADD CONSTRAINT osoby_pk PRIMARY KEY(id_osoba )

CREATE TABLE plany_smen(
id_plan_smeny INTEGER DEFAULT plany_smen_seq.nextval NOT NULL,
smena INTEGER NOT NULL,
jizdni_rad INTEGER NOT NULL
)

ALTER TABLE plany_smen ADD CONSTRAINT rel_smena_jizdni_rad_pk PRIMARY KEY(id_plan_smeny )

CREATE TABLE prava (
    id_pravo  INTEGER DEFAULT prava_seq.nextval NOT NULL,
    role      INTEGER NOT NULL,
    opravneni INTEGER NOT NULL
)

ALTER TABLE prava ADD CONSTRAINT prava_pk PRIMARY KEY ( id_pravo )

CREATE TABLE prevodovky(
id_prevodovka INTEGER DEFAULT prevodovky_seq.nextval NOT NULL,
nazev VARCHAR2(16) NOT NULL
)

ALTER TABLE prevodovky ADD CONSTRAINT prevodovka_pk PRIMARY KEY(id_prevodovka )

CREATE TABLE provozy(
id_provoz INTEGER DEFAULT provozy_seq.nextval NOT NULL,
nazev VARCHAR2(64) NOT NULL,
servisni_stredisko NUMBER NOT NULL,
sidlo INTEGER NOT NULL,
vedouci            INTEGER NOT NULL
)

ALTER TABLE provozy ADD CONSTRAINT provoz_pk PRIMARY KEY(id_provoz )

CREATE TABLE role(
id_role INTEGER DEFAULT role_seq.nextval NOT NULL,
nazev VARCHAR2(16) NOT NULL
)

ALTER TABLE role ADD CONSTRAINT role_pk PRIMARY KEY(id_role )

CREATE TABLE skutecne_rady(
id_skutecny_rad INTEGER DEFAULT skutecne_rady_seq.nextval NOT NULL,
cas_prijezdu DATE,
cas_odjezdu DATE,
plan INTEGER NOT NULL
)

ALTER TABLE skutecne_rady ADD CONSTRAINT skutecny_rad_pk PRIMARY KEY(id_skutecny_rad )

CREATE TABLE smeny(
id_smena INTEGER DEFAULT smeny_seq.nextval NOT NULL,
vozidlo INTEGER NOT NULL,
zamestnanec INTEGER NOT NULL
)

ALTER TABLE smeny ADD CONSTRAINT smena_pk PRIMARY KEY(id_smena )

CREATE TABLE soupravy_metra(
id_vozidlo INTEGER NOT NULL,
pocet_vozu INTEGER NOT NULL,
zabezpecovac INTEGER NOT NULL
)

ALTER TABLE soupravy_metra ADD CONSTRAINT metro_pk PRIMARY KEY(id_vozidlo )

CREATE TABLE staty(
id_stat INTEGER DEFAULT staty_seq.nextval NOT NULL,
nazev VARCHAR2(128) NOT NULL
)

ALTER TABLE staty ADD CONSTRAINT stat_pk PRIMARY KEY(id_stat )

ALTER TABLE staty ADD CONSTRAINT stat_un UNIQUE(nazev )

CREATE TABLE stavy(
id_stav INTEGER DEFAULT stavy_seq.nextval NOT NULL,
nazev VARCHAR2(16) NOT NULL
)

ALTER TABLE stavy ADD CONSTRAINT stav_pk PRIMARY KEY(id_stav )

CREATE TABLE tramvaje(
id_vozidlo INTEGER NOT NULL,
pocet_clanku INTEGER NOT NULL,
rekuperace NUMBER NOT NULL
)

ALTER TABLE tramvaje ADD CONSTRAINT tramvaj_pk PRIMARY KEY(id_vozidlo )

CREATE TABLE trolejbusy(
id_vozidlo INTEGER NOT NULL,
trakcni_baterie NUMBER NOT NULL,
kloubovy NUMBER NOT NULL
)

ALTER TABLE trolejbusy ADD CONSTRAINT trolejbus_pk PRIMARY KEY(id_vozidlo )

CREATE TABLE uzivatele(
id_uzivatel INTEGER DEFAULT uzivatele_seq.nextval NOT NULL,
heslo VARCHAR2(256) NOT NULL,
datum_registrace TIMESTAMP NOT NULL,
obrazek CLOB NOT NULL,
role INTEGER,
stav             INTEGER,
zamestnanec INTEGER NOT NULL
)

ALTER TABLE uzivatele ADD CONSTRAINT uzivatel_pk PRIMARY KEY(id_uzivatel )

CREATE TABLE vozidla(
id_vozidlo INTEGER DEFAULT vozidla_seq.nextval NOT NULL,
evidencni_cislo INTEGER NOT NULL,
rok_vyroby DATE NOT NULL,
model INTEGER NOT NULL,
deponace INTEGER NOT NULL,
typ_vozidla CHAR(3) NOT NULL
)

ALTER TABLE vozidla ADD CHECK(evidencni_cislo BETWEEN 1000 AND 9999 )

ALTER TABLE vozidla ADD CONSTRAINT vozidlo_pk PRIMARY KEY(id_vozidlo )

ALTER TABLE vozidla ADD CONSTRAINT vozidlo_evidencni_cislo_un UNIQUE(evidencni_cislo )

CREATE TABLE vyrobci(
id_vyrobce INTEGER DEFAULT vyrobci_seq.nextval NOT NULL,
nazev VARCHAR2(64) NOT NULL,
sidlo      INTEGER NOT NULL,
kontakt INTEGER
)

ALTER TABLE vyrobci ADD CONSTRAINT vyrobce_pk PRIMARY KEY(id_vyrobce )

CREATE TABLE zabezpecovace(
id_zabezpecovac INTEGER DEFAULT zabezpecovace_seq.nextval NOT NULL,
nazev VARCHAR2(16) NOT NULL
)

ALTER TABLE zabezpecovace ADD CONSTRAINT zabezpecovac_pk PRIMARY KEY(id_zabezpecovac )

CREATE TABLE zamestnanci(
id_zamestnanec INTEGER DEFAULT zamestnanci_seq.nextval NOT NULL,
osobni_cislo INTEGER NOT NULL,
datum_nastupu DATE NOT NULL,
bydliste INTEGER NOT NULL,
osobni_udaje INTEGER NOT NULL,
nadrizeny INTEGER
)

ALTER TABLE zamestnanci ADD CONSTRAINT zamestnanec_pk PRIMARY KEY(id_zamestnanec )

ALTER TABLE zamestnanci ADD CONSTRAINT zamestnanec_osobni_cislo_un UNIQUE(osobni_cislo )

ALTER TABLE zamestnanci ADD CONSTRAINT zamestnanec_osoba_un UNIQUE(osobni_udaje )

ALTER TABLE zamestnanci
 ADD CONSTRAINT osobni_cislo_sestimistne CHECK(osobni_cislo BETWEEN 100000 AND 999999 )

CREATE TABLE zastavky(
id_zastavka INTEGER DEFAULT zastavky_seq.nextval NOT NULL,
nazev VARCHAR2(32) NOT NULL,
gps_severni_sirka  NUMBER NOT NULL,
gps_vychodni_delka NUMBER NOT NULL,
kod                VARCHAR2(5) NOT NULL,
bezbarierova       NUMBER NOT NULL,
na_znameni NUMBER NOT NULL
)

ALTER TABLE zastavky ADD CONSTRAINT zastavka_pk PRIMARY KEY(id_zastavka )

ALTER TABLE zastavky ADD CONSTRAINT zastavka_kod_un UNIQUE(kod )
