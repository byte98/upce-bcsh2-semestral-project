CREATE TABLE adresy (
    id_adresa        INTEGER DEFAULT adresy_seq.nextval NOT NULL,
    ulice            VARCHAR2(64),
    cislo_popisne    INTEGER NOT NULL,
    cislo_orientacni INTEGER,
    obec             INTEGER NOT NULL
)

ALTER TABLE adresy ADD CONSTRAINT adresy_pk PRIMARY KEY ( id_adresa )

CREATE TABLE jizdni_rady (
    id_jizdni_rad  INTEGER DEFAULT jizdni_rady_seq.nextval NOT NULL,
    cas_prijezdu   DATE NOT NULL,
    cas_odjezdu    DATE NOT NULL,
    poradove_cislo INTEGER NOT NULL,
    varianta       INTEGER NOT NULL,
    linka          INTEGER NOT NULL,
    zastavka       INTEGER NOT NULL
)

ALTER TABLE jizdni_rady ADD CONSTRAINT jizdni_rady_pk PRIMARY KEY ( id_jizdni_rad )

CREATE TABLE linky (
    id_linka INTEGER DEFAULT linky_seq.nextval NOT NULL,
    kod      CHAR(3) NOT NULL
)

CREATE TABLE logy (
    id_log INTEGER DEFAULT logy_seq.nextval NOT NULL,
    cas TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    operace VARCHAR2(64) NOT NULL,
    tabulka VARCHAR2(64) NOT NULL,
    pocet_radku INTEGER NOT NULL,
    zprava CLOB
)

ALTER TABLE logy ADD CONSTRAINT logy_pk PRIMARY KEY ( id_log )

ALTER TABLE linky ADD CONSTRAINT linky_pk PRIMARY KEY ( id_linka )

ALTER TABLE linky ADD CONSTRAINT linky_kod_un UNIQUE ( kod )

CREATE TABLE obce (
    id_obec   INTEGER DEFAULT obce_seq.nextval NOT NULL,
    nazev     VARCHAR2(64) NOT NULL,
    cast_obce VARCHAR2(64),
    psc       VARCHAR2(16) NOT NULL,
    stat      INTEGER NOT NULL
)

ALTER TABLE obce ADD CONSTRAINT obce_pk PRIMARY KEY ( id_obec )

CREATE TABLE obrazky (
    id_obrazek    INTEGER DEFAULT obrazky_seq.nextval NOT NULL,
    obsah         CLOB NOT NULL,
    hash          VARCHAR2(2048) NOT NULL,
    nazev         VARCHAR2(256) NOT NULL,
    datum_nahrani DATE NOT NULL
)

ALTER TABLE obrazky ADD CONSTRAINT obrazky_pk PRIMARY KEY ( id_obrazek )


CREATE TABLE opravneni (
    id_opravneni    INTEGER DEFAULT opravneni_seq.nextval NOT NULL,
    nazev           VARCHAR2(64) NOT NULL,
    systemovy_nazev VARCHAR2(64) NOT NULL
)

ALTER TABLE opravneni ADD CONSTRAINT opravneni_pk PRIMARY KEY ( id_opravneni )

CREATE TABLE osoby (
    id_osoba INTEGER DEFAULT osoby_seq.nextval NOT NULL,
    jmeno    VARCHAR2(64) NOT NULL,
    prijmeni VARCHAR2(64) NOT NULL,
    e_mail   VARCHAR2(320) NOT NULL,
    telefon  CHAR(14) NOT NULL
)

ALTER TABLE osoby ADD CONSTRAINT osoby_pk PRIMARY KEY ( id_osoba )

CREATE TABLE prava (
    id_pravo  INTEGER DEFAULT prava_seq.nextval NOT NULL,
    role      INTEGER NOT NULL,
    opravneni INTEGER NOT NULL
)

ALTER TABLE prava ADD CONSTRAINT prava_pk PRIMARY KEY ( id_pravo )

CREATE TABLE role (
    id_role INTEGER DEFAULT role_seq.nextval NOT NULL,
    nazev   VARCHAR2(16) NOT NULL
)

ALTER TABLE role ADD CONSTRAINT role_pk PRIMARY KEY ( id_role )

CREATE TABLE skutecne_rady (
    id_skutecny_rad INTEGER DEFAULT skutecne_rady_seq.nextval NOT NULL,
    cas_prijezdu    DATE,
    cas_odjezdu     DATE,
    plan            INTEGER NOT NULL
)

ALTER TABLE skutecne_rady ADD CONSTRAINT skutecny_rad_pk PRIMARY KEY ( id_skutecny_rad )

CREATE TABLE staty (
    id_stat INTEGER DEFAULT staty_seq.nextval NOT NULL,
    nazev   VARCHAR2(128) NOT NULL
)

ALTER TABLE staty ADD CONSTRAINT stat_pk PRIMARY KEY ( id_stat )

ALTER TABLE staty ADD CONSTRAINT staty__un UNIQUE ( nazev )

CREATE TABLE stavy (
    id_stav       INTEGER DEFAULT stavy_seq.nextval NOT NULL,
    nazev         VARCHAR2(16) NOT NULL,
    prihlasitelny NUMBER NOT NULL
)

ALTER TABLE stavy ADD CONSTRAINT stav_pk PRIMARY KEY ( id_stav )

CREATE TABLE uzivatele (
    id_uzivatel      INTEGER DEFAULT uzivatele_seq.nextval NOT NULL,
    heslo            VARCHAR2(256) NOT NULL,
    datum_registrace TIMESTAMP NOT NULL,
    role             INTEGER NOT NULL,
    stav             INTEGER NOT NULL,
    zamestnanec      INTEGER NOT NULL,
    obrazek          INTEGER NOT NULL
)

ALTER TABLE uzivatele ADD CONSTRAINT uzivatel_pk PRIMARY KEY ( id_uzivatel )

CREATE TABLE zamestnanci (
    id_zamestnanec INTEGER DEFAULT zamestnanci_seq.nextval NOT NULL,
    osobni_cislo   INTEGER NOT NULL,
    datum_nastupu  DATE NOT NULL,
    bydliste       INTEGER NOT NULL,
    osobni_udaje   INTEGER NOT NULL,
    nadrizeny      INTEGER
)

ALTER TABLE zamestnanci
    ADD CONSTRAINT osobni_cislo_sestimistne CHECK ( osobni_cislo BETWEEN 100000 AND 999999 )

ALTER TABLE zamestnanci ADD CONSTRAINT zamestnanec_pk PRIMARY KEY ( id_zamestnanec )

ALTER TABLE zamestnanci ADD CONSTRAINT zamestnanec_osobni_cislo_un UNIQUE ( osobni_cislo )

ALTER TABLE zamestnanci ADD CONSTRAINT zamestnanec_osoba_un UNIQUE ( osobni_udaje )

CREATE TABLE zastavky (
    id_zastavka        INTEGER DEFAULT zastavky_seq.nextval NOT NULL,
    nazev              VARCHAR2(32) NOT NULL,
    kod                VARCHAR2(5) NOT NULL
)

ALTER TABLE zastavky ADD CONSTRAINT zastavka_pk PRIMARY KEY ( id_zastavka )

ALTER TABLE zastavky ADD CONSTRAINT zastavka_kod_un UNIQUE ( kod )


CREATE TABLE vozidla (
    id_vozidlo        INTEGER DEFAULT vozidla_seq.nextval NOT NULL,
    evidencni_cislo   VARCHAR2(32) NOT NULL,
    typ_vozidla       VARCHAR2(3) NOT NULL
)

ALTER TABLE vozidla ADD CONSTRAINT vozidlo_pk PRIMARY KEY ( id_vozidlo )

ALTER TABLE vozidla ADD CONSTRAINT vozidlo_evidencni_cislo_un UNIQUE ( evidencni_cislo )

