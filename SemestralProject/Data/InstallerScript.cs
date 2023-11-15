using SemestralProject.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SemestralProject.Data
{
    /// <summary>
    /// Class which holds all installation SQL statements.
    /// </summary>
    public abstract class InstallerScript
    {
        /// <summary>
        /// Dictionary with all kind of drops.
        /// </summary>
        public static readonly IDictionary<IConnection.DatabaseObject, IDictionary<string, string>> Drops = new Dictionary<IConnection.DatabaseObject, IDictionary<string, string>>()
        {
            {
                IConnection.DatabaseObject.Trigger, new Dictionary<string, string>()
                {
                    {"ARC_VOZIDLA_ARC_TRAMVAJE", "DROP TRIGGER arc_vozidla_arc_tramvaje"},
                    {"ARC_VOZIDLA_ARC_AUTOBUSY", "DROP TRIGGER arc_vozidla_arc_autobusy"},
                    {"ARC_VOZIDLA_ARC_TROLEJBUSY", "DROP TRIGGER arc_vozidla_arc_trolejbusy"},
                    {"ARC_VOZIDLA_ARC_SOUPRAVY_METRA", "DROP TRIGGER arc_vozidla_arc_soupravy_metra"}
                }
            },
            {
                IConnection.DatabaseObject.Table, new Dictionary<string, string>()
                {
                    {"ADRESY", "DROP TABLE adresy CASCADE CONSTRAINTS PURGE"},
                    {"AUTOBUSY", "DROP TABLE autobusy CASCADE CONSTRAINTS PURGE"},
                    {"CIPOVE_KARTY", "DROP TABLE cipove_karty CASCADE CONSTRAINTS PURGE"},
                    {"JIZDNI_RADY", "DROP TABLE jizdni_rady CASCADE CONSTRAINTS PURGE"},
                    {"LINKY", "DROP TABLE linky CASCADE CONSTRAINTS PURGE"},
                    {"MODELY", "DROP TABLE modely CASCADE CONSTRAINTS PURGE"},
                    {"OBCE", "DROP TABLE obce CASCADE CONSTRAINTS PURGE"},
                    {"OSOBY", "DROP TABLE osoby CASCADE CONSTRAINTS PURGE"},
                    {"PLANY_SMEN", "DROP TABLE plany_smen CASCADE CONSTRAINTS PURGE"},
                    {"PREVODOVKY", "DROP TABLE prevodovky CASCADE CONSTRAINTS PURGE"},
                    {"PROVOZY", "DROP TABLE provozy CASCADE CONSTRAINTS PURGE"},
                    {"ROLE", "DROP TABLE role CASCADE CONSTRAINTS PURGE"},
                    {"SKUTECNE_RADY", "DROP TABLE skutecne_rady CASCADE CONSTRAINTS PURGE"},
                    {"SMENY", "DROP TABLE smeny CASCADE CONSTRAINTS PURGE"},
                    {"SOUPRAVY_METRA", "DROP TABLE soupravy_metra CASCADE CONSTRAINTS PURGE"},
                    {"STATY", "DROP TABLE staty CASCADE CONSTRAINTS PURGE"},
                    {"STAVY", "DROP TABLE stavy CASCADE CONSTRAINTS PURGE"},
                    {"TRAMVAJE", "DROP TABLE tramvaje CASCADE CONSTRAINTS PURGE"},
                    {"TROLEJBUSY", "DROP TABLE trolejbusy CASCADE CONSTRAINTS PURGE"},
                    {"UZIVATELE", "DROP TABLE uzivatele CASCADE CONSTRAINTS PURGE"},
                    {"VOZIDLA", "DROP TABLE vozidla CASCADE CONSTRAINTS PURGE"},
                    {"VYROBCI", "DROP TABLE vyrobci CASCADE CONSTRAINTS PURGE"},
                    {"ZABEZPECOVACE", "DROP TABLE zabezpecovace CASCADE CONSTRAINTS PURGE"},
                    {"ZAMESTNANCI", "DROP TABLE zamestnanci CASCADE CONSTRAINTS PURGE"},
                    {"ZASTAVKY", "DROP TABLE zastavky CASCADE CONSTRAINTS PURGE"}
                }
            },
            {
                IConnection.DatabaseObject.Sequence, new Dictionary<string, string>()
                {
                    {"ADRESY_SEQ", "DROP SEQUENCE adresy_seq"},
                    {"CIPOVE_KARTY_SEQ", "DROP SEQUENCE cipove_karty_seq"},
                    {"JIZDNI_RADY_SEQ", "DROP SEQUENCE jizdni_rady_seq"},
                    {"LINKY_SEQ", "DROP SEQUENCE linky_seq"},
                    {"MODELY_SEQ", "DROP SEQUENCE modely_seq"},
                    {"OBCE_SEQ", "DROP SEQUENCE obce_seq"},
                    {"OSOBY_SEQ", "DROP SEQUENCE osoby_seq"},
                    {"OSOBNI_CISLA_SEQ", "DROP SEQUENCE osobni_cisla_seq"},
                    {"PLANY_SMEN_SEQ", "DROP SEQUENCE plany_smen_seq"},
                    {"PREVODOVKY_SEQ", "DROP SEQUENCE prevodovky_seq"},
                    {"PROVOZY_SEQ", "DROP SEQUENCE provozy_seq"},
                    {"ROLE_SEQ", "DROP SEQUENCE role_seq"},
                    {"SKUTECNE_RADY_SEQ", "DROP SEQUENCE skutecne_rady_seq"},
                    {"SMENY_SEQ", "DROP SEQUENCE smeny_seq"},
                    {"STATY_SEQ", "DROP SEQUENCE staty_seq"},
                    {"STAVY_SEQ", "DROP SEQUENCE stavy_seq"},
                    {"TYPY_VOZIDEL_SEQ", "DROP SEQUENCE typy_vozidel_seq"},
                    {"UZIVATELE_SEQ", "DROP SEQUENCE uzivatele_seq"},
                    {"VOZIDLA_SEQ", "DROP SEQUENCE vozidla_seq"},
                    {"VYROBCI_SEQ", "DROP SEQUENCE vyrobci_seq"},
                    {"ZABEZPECOVACE_SEQ", "DROP SEQUENCE zabezpecovace_seq"},
                    {"ZASTAVKY_SEQ", "DROP SEQUENCE zastavky_seq"},
                    {"ZAMESTNANCI_SEQ", "DROP SEQUENCE zamestnanci_seq"}
                }
            },
            {
                IConnection.DatabaseObject.View, new Dictionary<string, string>()
            },
            {
                IConnection.DatabaseObject.Function, new Dictionary<string, string>()
            },
            {
                IConnection.DatabaseObject.Procedure, new Dictionary<string, string>()
            },
            {
                IConnection.DatabaseObject.Package, new Dictionary<string, string>()
                {
                    {"SEMPR_CRUD", "DROP PACKAGE sempr_crud"},
                    {"SEMPR_UTILS", "DROP PACKAGE sempr_utils"}
                }
            }
        };

        /// <summary>
        /// Array with statements which creates all sequences.
        /// </summary>
        public static readonly string[] Sequences = new string[]
        {
            "CREATE SEQUENCE adresy_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE cipove_karty_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE jizdni_rady_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE linky_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE modely_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE obce_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE osoby_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE osobni_cisla_seq START WITH 100000 NOCACHE ORDER",
            "CREATE SEQUENCE plany_smen_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE prevodovky_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE provozy_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE role_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE skutecne_rady_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE smeny_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE staty_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE stavy_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE typy_vozidel_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE uzivatele_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE vozidla_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE vyrobci_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE zabezpecovace_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE zastavky_seq START WITH 1 NOCACHE ORDER",
            "CREATE SEQUENCE zamestnanci_seq START WITH 1 NOCACHE ORDER"
        };

        /// <summary>
        /// Array with all SQL statements which creates all necessary tables.
        /// </summary>
        public static readonly string[] Tables = new string[]
        {
            @"CREATE TABLE adresy (
            id_adresa        INTEGER DEFAULT adresy_seq.nextval NOT NULL,
            ulice            VARCHAR2(64),
            cislo_popisne    INTEGER NOT NULL,
            cislo_orientacni INTEGER,
            obec             INTEGER NOT NULL
            )",

            @"ALTER TABLE adresy ADD CONSTRAINT adresy_pk PRIMARY KEY(id_adresa )",
            @"CREATE TABLE autobusy(
            id_vozidlo INTEGER NOT NULL,
            kloubovy NUMBER NOT NULL,
            prevodovka INTEGER NOT NULL
            )",

            @"ALTER TABLE autobusy ADD CONSTRAINT autobus_pk PRIMARY KEY(id_vozidlo )",

            @"CREATE TABLE cipove_karty(
            id_cipova_karta INTEGER DEFAULT cipove_karty_seq.nextval NOT NULL,
            cislo_karty INTEGER NOT NULL,
            datum_vydani DATE NOT NULL,
            datum_platnosti DATE NOT NULL,
            povolena NUMBER NOT NULL,
            drzitel INTEGER NOT NULL
            )",

            @"ALTER TABLE cipove_karty ADD CONSTRAINT cipove_karty_pk PRIMARY KEY(id_cipova_karta )",

            @"ALTER TABLE cipove_karty ADD CONSTRAINT cipove_karty_cislo_karty_un UNIQUE(cislo_karty )",

            @"CREATE TABLE jizdni_rady(
            id_jizdni_rad INTEGER DEFAULT jizdni_rady_seq.nextval NOT NULL,
            cas_prijezdu DATE NOT NULL,
            cas_odjezdu DATE NOT NULL,
            poradove_cislo INTEGER NOT NULL,
            varianta INTEGER NOT NULL,
            linka INTEGER NOT NULL,
            zastavka INTEGER NOT NULL
            )",

            @"ALTER TABLE jizdni_rady ADD CONSTRAINT jizdni_rady_pk PRIMARY KEY(id_jizdni_rad )",
            @"CREATE TABLE linky(
            id_linka INTEGER DEFAULT linky_seq.nextval NOT NULL,
            kod CHAR(3) NOT NULL
            )",

            @"ALTER TABLE linky ADD CONSTRAINT linky_pk PRIMARY KEY(id_linka )",

            @"ALTER TABLE linky ADD CONSTRAINT linky_kod_un UNIQUE(kod )",

            @"CREATE TABLE modely(
            id_model INTEGER DEFAULT modely_seq.nextval NOT NULL,
            nazev VARCHAR2(64) NOT NULL,
            mista_sezeni  INTEGER NOT NULL,
            mista_stani INTEGER NOT NULL,
            klimatizace   NUMBER NOT NULL,
            nizkopodlazni NUMBER NOT NULL,
            palivo        VARCHAR2(16) NOT NULL,
            vyrobce       INTEGER NOT NULL
            )",

            @"ALTER TABLE modely ADD CONSTRAINT modely_pk PRIMARY KEY(id_model )",

            @"CREATE TABLE obce(
            id_obec INTEGER DEFAULT obce_seq.nextval NOT NULL,
            nazev VARCHAR2(64) NOT NULL,
            cast_obce VARCHAR2(64),
            psc VARCHAR(16) NOT NULL,
            stat      INTEGER NOT NULL
            )",

            @"ALTER TABLE obce ADD CONSTRAINT obce_pk PRIMARY KEY(id_obec )",

            @"CREATE TABLE osoby(
            id_osoba INTEGER DEFAULT osoby_seq.nextval NOT NULL,
            jmeno VARCHAR2(64) NOT NULL,
            prijmeni VARCHAR2(64) NOT NULL,
            e_mail   VARCHAR2(320) NOT NULL,
            telefon  CHAR(14) NOT NULL
            )",

            @"ALTER TABLE osoby ADD CONSTRAINT osoby_pk PRIMARY KEY(id_osoba )",

            @"CREATE TABLE plany_smen(
            id_plan_smeny INTEGER DEFAULT plany_smen_seq.nextval NOT NULL,
            smena INTEGER NOT NULL,
            jizdni_rad INTEGER NOT NULL
            )",

            @"ALTER TABLE plany_smen ADD CONSTRAINT rel_smena_jizdni_rad_pk PRIMARY KEY(id_plan_smeny )",

            @"CREATE TABLE prevodovky(
            id_prevodovka INTEGER DEFAULT prevodovky_seq.nextval NOT NULL,
            nazev VARCHAR2(16) NOT NULL
            )",

            @"ALTER TABLE prevodovky ADD CONSTRAINT prevodovka_pk PRIMARY KEY(id_prevodovka )",

            @"CREATE TABLE provozy(
            id_provoz INTEGER DEFAULT provozy_seq.nextval NOT NULL,
            nazev VARCHAR2(64) NOT NULL,
            servisni_stredisko NUMBER NOT NULL,
            sidlo INTEGER NOT NULL,
            vedouci            INTEGER NOT NULL
            )",

            @"ALTER TABLE provozy ADD CONSTRAINT provoz_pk PRIMARY KEY(id_provoz )",

            @"CREATE TABLE role(
            id_role INTEGER DEFAULT role_seq.nextval NOT NULL,
            nazev VARCHAR2(16) NOT NULL
            )",

            @"ALTER TABLE role ADD CONSTRAINT role_pk PRIMARY KEY(id_role )",

            @"CREATE TABLE skutecne_rady(
            id_skutecny_rad INTEGER DEFAULT skutecne_rady_seq.nextval NOT NULL,
            cas_prijezdu DATE,
            cas_odjezdu DATE,
            plan INTEGER NOT NULL
            )",

            @"ALTER TABLE skutecne_rady ADD CONSTRAINT skutecny_rad_pk PRIMARY KEY(id_skutecny_rad )",

            @"CREATE TABLE smeny(
            id_smena INTEGER DEFAULT smeny_seq.nextval NOT NULL,
            vozidlo INTEGER NOT NULL,
            zamestnanec INTEGER NOT NULL
            )",

            @"ALTER TABLE smeny ADD CONSTRAINT smena_pk PRIMARY KEY(id_smena )",

            @"CREATE TABLE soupravy_metra(
            id_vozidlo INTEGER NOT NULL,
            pocet_vozu INTEGER NOT NULL,
            zabezpecovac INTEGER NOT NULL
            )",

            @"ALTER TABLE soupravy_metra ADD CONSTRAINT metro_pk PRIMARY KEY(id_vozidlo )",

            @"CREATE TABLE staty(
            id_stat INTEGER DEFAULT staty_seq.nextval NOT NULL,
            nazev VARCHAR2(128) NOT NULL
            )",

            @"ALTER TABLE staty ADD CONSTRAINT stat_pk PRIMARY KEY(id_stat )",

            @"ALTER TABLE staty ADD CONSTRAINT stat_un UNIQUE(nazev )",

            @"CREATE TABLE stavy(
            id_stav INTEGER DEFAULT stavy_seq.nextval NOT NULL,
            nazev VARCHAR2(16) NOT NULL
            )",

            @"ALTER TABLE stavy ADD CONSTRAINT stav_pk PRIMARY KEY(id_stav )",

            @"CREATE TABLE tramvaje(
            id_vozidlo INTEGER NOT NULL,
            pocet_clanku INTEGER NOT NULL,
            rekuperace NUMBER NOT NULL
            )",

            @"ALTER TABLE tramvaje ADD CONSTRAINT tramvaj_pk PRIMARY KEY(id_vozidlo )",

            @"CREATE TABLE trolejbusy(
            id_vozidlo INTEGER NOT NULL,
            trakcni_baterie NUMBER NOT NULL,
            kloubovy NUMBER NOT NULL
            )",

            @"ALTER TABLE trolejbusy ADD CONSTRAINT trolejbus_pk PRIMARY KEY(id_vozidlo )",

            @"CREATE TABLE uzivatele(
            id_uzivatel INTEGER DEFAULT uzivatele_seq.nextval NOT NULL,
            heslo VARCHAR2(256) NOT NULL,
            datum_registrace TIMESTAMP NOT NULL,
            obrazek CLOB NOT NULL,
            role INTEGER,
            stav             INTEGER,
            zamestnanec INTEGER NOT NULL
            )",

            @"ALTER TABLE uzivatele ADD CONSTRAINT uzivatel_pk PRIMARY KEY(id_uzivatel )",

            @"CREATE TABLE vozidla(
            id_vozidlo INTEGER DEFAULT vozidla_seq.nextval NOT NULL,
            evidencni_cislo INTEGER NOT NULL,
            rok_vyroby DATE NOT NULL,
            model INTEGER NOT NULL,
            deponace INTEGER NOT NULL,
            typ_vozidla CHAR(3) NOT NULL
            )",

            @"ALTER TABLE vozidla ADD CHECK(evidencni_cislo BETWEEN 1000 AND 9999 )",
            @"ALTER TABLE vozidla ADD CONSTRAINT vozidlo_pk PRIMARY KEY(id_vozidlo )",

            @"ALTER TABLE vozidla ADD CONSTRAINT vozidlo_evidencni_cislo_un UNIQUE(evidencni_cislo )",

            @"CREATE TABLE vyrobci(
            id_vyrobce INTEGER DEFAULT vyrobci_seq.nextval NOT NULL,
            nazev VARCHAR2(64) NOT NULL,
            sidlo      INTEGER NOT NULL,
            kontakt INTEGER
            )",

            @"ALTER TABLE vyrobci ADD CONSTRAINT vyrobce_pk PRIMARY KEY(id_vyrobce )",

            @"CREATE TABLE zabezpecovace(
            id_zabezpecovac INTEGER DEFAULT zabezpecovace_seq.nextval NOT NULL,
            nazev VARCHAR2(16) NOT NULL
            )",

            @"ALTER TABLE zabezpecovace ADD CONSTRAINT zabezpecovac_pk PRIMARY KEY(id_zabezpecovac )",

            @"CREATE TABLE zamestnanci(
            id_zamestnanec INTEGER DEFAULT zamestnanci_seq.nextval NOT NULL,
            osobni_cislo INTEGER NOT NULL,
            datum_nastupu DATE NOT NULL,
            bydliste INTEGER NOT NULL,
            osobni_udaje INTEGER NOT NULL,
            nadrizeny INTEGER
            )",

            @"ALTER TABLE zamestnanci ADD CONSTRAINT zamestnanec_pk PRIMARY KEY(id_zamestnanec )",

            @"ALTER TABLE zamestnanci ADD CONSTRAINT zamestnanec_osobni_cislo_un UNIQUE(osobni_cislo )",

            @"ALTER TABLE zamestnanci ADD CONSTRAINT zamestnanec_osoba_un UNIQUE(osobni_udaje )",

            @"ALTER TABLE zamestnanci
            ADD CONSTRAINT osobni_cislo_sestimistne CHECK(osobni_cislo BETWEEN 100000 AND 999999 )",

            @"CREATE TABLE zastavky(
            id_zastavka INTEGER DEFAULT zastavky_seq.nextval NOT NULL,
            nazev VARCHAR2(32) NOT NULL,
            gps_severni_sirka  NUMBER NOT NULL,
            gps_vychodni_delka NUMBER NOT NULL,
            kod                VARCHAR2(5) NOT NULL,
            bezbarierova       NUMBER NOT NULL,
            na_znameni NUMBER NOT NULL
            )",

            @"ALTER TABLE zastavky ADD CONSTRAINT zastavka_pk PRIMARY KEY(id_zastavka )",

            @"ALTER TABLE zastavky ADD CONSTRAINT zastavka_kod_un UNIQUE(kod )"
        
        };

        /// <summary>
        /// Array with SQL statements which establish all necessary relations.
        /// </summary>
        public static readonly string[] Relations = new string[]
        {
            @"ALTER TABLE adresy
            ADD CONSTRAINT adresy_obce_fk FOREIGN KEY ( obec )
                REFERENCES obce ( id_obec )",

                @"ALTER TABLE autobusy
                    ADD CONSTRAINT autobus_prevodovka_fk FOREIGN KEY(prevodovka )
                REFERENCES prevodovky(id_prevodovka )",

                @"ALTER TABLE autobusy
                    ADD CONSTRAINT autobus_vozidlo_fk FOREIGN KEY(id_vozidlo )
                REFERENCES vozidla(id_vozidlo )
                    ON DELETE CASCADE",

        @"ALTER TABLE cipove_karty
            ADD CONSTRAINT cipove_karty_zamestnanec_fk FOREIGN KEY(drzitel )
                REFERENCES zamestnanci(id_zamestnanec )",

                @"ALTER TABLE jizdni_rady
                    ADD CONSTRAINT jizdni_rady_linky_fk FOREIGN KEY(linka )
                REFERENCES linky(id_linka )",

                @"ALTER TABLE jizdni_rady
                    ADD CONSTRAINT jizdni_rady_zastavka_fk FOREIGN KEY(zastavka )
                REFERENCES zastavky(id_zastavka )",

                @"ALTER TABLE soupravy_metra
                    ADD CONSTRAINT metro_vozidlo_fk FOREIGN KEY(id_vozidlo )
                REFERENCES vozidla(id_vozidlo )
                    ON DELETE CASCADE",

        @"ALTER TABLE soupravy_metra
            ADD CONSTRAINT metro_zabezpecovac_fk FOREIGN KEY(zabezpecovac )
                REFERENCES zabezpecovace(id_zabezpecovac )",

                @"ALTER TABLE modely
                    ADD CONSTRAINT modely_vyrobce_fk FOREIGN KEY(vyrobce )
                REFERENCES vyrobci(id_vyrobce )",

                @"ALTER TABLE obce
                    ADD CONSTRAINT obce_stat_fk FOREIGN KEY(stat )
                REFERENCES staty(id_stat )",

                @"ALTER TABLE provozy
                    ADD CONSTRAINT provoz_adresy_fk FOREIGN KEY(sidlo )
                REFERENCES adresy(id_adresa )",

                @"ALTER TABLE provozy
                    ADD CONSTRAINT provozy_zamestnanec_fk FOREIGN KEY(vedouci )
                REFERENCES zamestnanci(id_zamestnanec )",

                @"ALTER TABLE plany_smen
                    ADD CONSTRAINT rel_smena_jizdni_rad_jizdni_rad_fk FOREIGN KEY(jizdni_rad )
                REFERENCES jizdni_rady(id_jizdni_rad )",

                @"ALTER TABLE plany_smen
                    ADD CONSTRAINT rel_smena_jizdni_rad_smena_fk FOREIGN KEY(smena )
                REFERENCES smeny(id_smena )",

                @"ALTER TABLE skutecne_rady
                    ADD CONSTRAINT skutecne_rady_plany_smen_fk FOREIGN KEY(plan )
                REFERENCES plany_smen(id_plan_smeny )",

                @"ALTER TABLE smeny
                    ADD CONSTRAINT smena_vozidlo_fk FOREIGN KEY(vozidlo )
                REFERENCES vozidla(id_vozidlo )",

                @"ALTER TABLE smeny
                    ADD CONSTRAINT smeny_zamestnanec_fk FOREIGN KEY(zamestnanec )
                REFERENCES zamestnanci(id_zamestnanec )",

                @"ALTER TABLE tramvaje
                    ADD CONSTRAINT tramvaj_vozidlo_fk FOREIGN KEY(id_vozidlo )
                REFERENCES vozidla(id_vozidlo )
                    ON DELETE CASCADE",

                @"ALTER TABLE trolejbusy
                    ADD CONSTRAINT trolejbus_vozidlo_fk FOREIGN KEY(id_vozidlo )
                        REFERENCES vozidla(id_vozidlo )
                            ON DELETE CASCADE",

                @"ALTER TABLE uzivatele
                    ADD CONSTRAINT uzivatel_role_fk FOREIGN KEY(role )
                        REFERENCES role(id_role )",

                @"ALTER TABLE uzivatele
                    ADD CONSTRAINT uzivatel_stav_fk FOREIGN KEY(stav )
                REFERENCES stavy(id_stav )",

                @"ALTER TABLE uzivatele
                    ADD CONSTRAINT uzivatel_zamestnanec_fk FOREIGN KEY(zamestnanec )
                REFERENCES zamestnanci(id_zamestnanec )",
                @"ALTER TABLE vozidla
                    ADD CONSTRAINT vozidlo_model_fk FOREIGN KEY(model )
                REFERENCES modely(id_model )",

                @"ALTER TABLE vozidla
                    ADD CONSTRAINT vozidlo_provoz_fk FOREIGN KEY(deponace )
                REFERENCES provozy(id_provoz )",

                @"ALTER TABLE vyrobci
                    ADD CONSTRAINT vyrobce_adresy_fk FOREIGN KEY(sidlo )
                REFERENCES adresy(id_adresa )",

                @"ALTER TABLE vyrobci
                    ADD CONSTRAINT vyrobce_osoba_fk FOREIGN KEY(kontakt )
                REFERENCES osoby(id_osoba )",

                @"ALTER TABLE zamestnanci
                    ADD CONSTRAINT zamestnanci_zamestnanci_fk FOREIGN KEY(nadrizeny )
                REFERENCES zamestnanci(id_zamestnanec )",

                @"ALTER TABLE zamestnanci
                    ADD CONSTRAINT zamestnanec_adresa_fk FOREIGN KEY(bydliste )
                REFERENCES adresy(id_adresa )",

                @"ALTER TABLE zamestnanci
                    ADD CONSTRAINT zamestnanec_osoby_fk FOREIGN KEY(osobni_udaje )
                REFERENCES osoby(id_osoba )"
        };

        /// <summary>
        /// Array with SQL statements which creates all views.
        /// </summary>
        public static readonly string[] Views = new string[0];

        /// <summary>
        /// Array with SQL statements which creates all triggers.
        /// </summary>
        public static readonly string[] Triggers = new string[0];

        /// <summary>
        /// Array with SQL statements which inserts all data into database.
        /// </summary>
        public static readonly string[] Data = new string[]
        {
            "SET TRANSACTION READ WRITE",
            "INSERT INTO role (id_role, nazev) VALUES (0, 'SUPERUŽIVATEL')",
            "INSERT INTO staty(nazev) VALUES ('Afghánská islámská republika')",
            "INSERT INTO staty(nazev) VALUES ('Provincie Alandy')",
            "INSERT INTO staty(nazev) VALUES ('Albánská republika')",
            "INSERT INTO staty(nazev) VALUES ('Alžírská demokratická a lidová republika')",
            "INSERT INTO staty(nazev) VALUES ('Území Americká Samoa')",
            "INSERT INTO staty(nazev) VALUES ('Americké Panenské ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Andorrské knížectví')",
            "INSERT INTO staty(nazev) VALUES ('Angolská republika')",
            "INSERT INTO staty(nazev) VALUES ('Anguilla')",
            "INSERT INTO staty(nazev) VALUES ('Antarktida')",
            "INSERT INTO staty(nazev) VALUES ('Antigua a Barbuda')",
            "INSERT INTO staty(nazev) VALUES ('Argentinská republika')",
            "INSERT INTO staty(nazev) VALUES ('Arménská republika')",
            "INSERT INTO staty(nazev) VALUES ('Aruba')",
            "INSERT INTO staty(nazev) VALUES ('Australské společenství')",
            "INSERT INTO staty(nazev) VALUES ('Ázerbájdžánská republika')",
            "INSERT INTO staty(nazev) VALUES ('Bahamské společenství')",
            "INSERT INTO staty(nazev) VALUES ('Království Bahrajn')",
            "INSERT INTO staty(nazev) VALUES ('Bangladéšská lidová republika')",
            "INSERT INTO staty(nazev) VALUES ('Barbados')",
            "INSERT INTO staty(nazev) VALUES ('Belgické království')",
            "INSERT INTO staty(nazev) VALUES ('Belize')",
            "INSERT INTO staty(nazev) VALUES ('Běloruská republika')",
            "INSERT INTO staty(nazev) VALUES ('Beninská republika')",
            "INSERT INTO staty(nazev) VALUES ('Bermudy')",
            "INSERT INTO staty(nazev) VALUES ('Bhútánské království')",
            "INSERT INTO staty(nazev) VALUES ('Mnohonárodní stát Bolívie')",
            "INSERT INTO staty(nazev) VALUES ('Bonaire, Svatý Eustach a Saba')",
            "INSERT INTO staty(nazev) VALUES ('Bosna a Hercegovina')",
            "INSERT INTO staty(nazev) VALUES ('Botswanská republika')",
            "INSERT INTO staty(nazev) VALUES ('Bouvetův ostrov')",
            "INSERT INTO staty(nazev) VALUES ('Brazilská federativní republika')",
            "INSERT INTO staty(nazev) VALUES ('Britské území v Indickém oceánu')",
            "INSERT INTO staty(nazev) VALUES ('Britské Panenské ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Stát Brunej Darussalam')",
            "INSERT INTO staty(nazev) VALUES ('Bulharská republika')",
            "INSERT INTO staty(nazev) VALUES ('Burkina Faso')",
            "INSERT INTO staty(nazev) VALUES ('Burundská republika')",
            "INSERT INTO staty(nazev) VALUES ('Cookovy ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Země Curaçao')",
            "INSERT INTO staty(nazev) VALUES ('Čadská republika')",
            "INSERT INTO staty(nazev) VALUES ('Černá Hora')",
            "INSERT INTO staty(nazev) VALUES ('Česká republika')",
            "INSERT INTO staty(nazev) VALUES ('Čínská lidová republika')",
            "INSERT INTO staty(nazev) VALUES ('Dánské království')",
            "INSERT INTO staty(nazev) VALUES ('Dominické společenství')",
            "INSERT INTO staty(nazev) VALUES ('Dominikánská republika')",
            "INSERT INTO staty(nazev) VALUES ('Džibutská republika')",
            "INSERT INTO staty(nazev) VALUES ('Egyptská arabská republika')",
            "INSERT INTO staty(nazev) VALUES ('Ekvádorská republika')",
            "INSERT INTO staty(nazev) VALUES ('Stát Eritrea')",
            "INSERT INTO staty(nazev) VALUES ('Estonská republika')",
            "INSERT INTO staty(nazev) VALUES ('Etiopská federativní demokratická republika')",
            "INSERT INTO staty(nazev) VALUES ('Faerské ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Falklandy (Malvíny)')",
            "INSERT INTO staty(nazev) VALUES ('Fidžijská republika')",
            "INSERT INTO staty(nazev) VALUES ('Filipínská republika')",
            "INSERT INTO staty(nazev) VALUES ('Finská republika')",
            "INSERT INTO staty(nazev) VALUES ('Francouzská republika')",
            "INSERT INTO staty(nazev) VALUES ('Francouzská Guyana')",
            "INSERT INTO staty(nazev) VALUES ('Francouzská jižní a antarktická území')",
            "INSERT INTO staty(nazev) VALUES ('Francouzská Polynésie')",
            "INSERT INTO staty(nazev) VALUES ('Gabonská republika')",
            "INSERT INTO staty(nazev) VALUES ('Gambijská republika')",
            "INSERT INTO staty(nazev) VALUES ('Ghanská republika')",
            "INSERT INTO staty(nazev) VALUES ('Gibraltar')",
            "INSERT INTO staty(nazev) VALUES ('Grenada')",
            "INSERT INTO staty(nazev) VALUES ('Grónsko')",
            "INSERT INTO staty(nazev) VALUES ('Gruzie')",
            "INSERT INTO staty(nazev) VALUES ('Region Guadeloupe')",
            "INSERT INTO staty(nazev) VALUES ('Teritorium Guam')",
            "INSERT INTO staty(nazev) VALUES ('Guatemalská republika')",
            "INSERT INTO staty(nazev) VALUES ('Bailiwick Guernsey')",
            "INSERT INTO staty(nazev) VALUES ('Guinejská republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Guinea-Bissau')",
            "INSERT INTO staty(nazev) VALUES ('Guyanská kooperativní republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Haiti')",
            "INSERT INTO staty(nazev) VALUES ('Heardův ostrov a MacDonaldovy ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Honduraská republika')",
            "INSERT INTO staty(nazev) VALUES ('Zvláštní administrativní oblast Čínské lidové republiky Hongkong')",
            "INSERT INTO staty(nazev) VALUES ('Chilská republika')",
            "INSERT INTO staty(nazev) VALUES ('Chorvatská republika')",
            "INSERT INTO staty(nazev) VALUES ('Indická republika')",
            "INSERT INTO staty(nazev) VALUES ('Indonéská republika')",
            "INSERT INTO staty(nazev) VALUES ('Irácká republika')",
            "INSERT INTO staty(nazev) VALUES ('Íránská islámská republika')",
            "INSERT INTO staty(nazev) VALUES ('Irsko')",
            "INSERT INTO staty(nazev) VALUES ('Islandská republika')",
            "INSERT INTO staty(nazev) VALUES ('Italská republika')",
            "INSERT INTO staty(nazev) VALUES ('Stát Izrael')",
            "INSERT INTO staty(nazev) VALUES ('Jamajka')",
            "INSERT INTO staty(nazev) VALUES ('Japonsko')",
            "INSERT INTO staty(nazev) VALUES ('Jemenská republika')",
            "INSERT INTO staty(nazev) VALUES ('Bailiwick Jersey')",
            "INSERT INTO staty(nazev) VALUES ('Jihoafrická republika')",
            "INSERT INTO staty(nazev) VALUES ('Jižní Georgie a Jižní Sandwichovy ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Jihosúdánská republika')",
            "INSERT INTO staty(nazev) VALUES ('Jordánské hášimovské království')",
            "INSERT INTO staty(nazev) VALUES ('Kajmanské ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Kambodžské království')",
            "INSERT INTO staty(nazev) VALUES ('Kamerunská republika')",
            "INSERT INTO staty(nazev) VALUES ('Kanada')",
            "INSERT INTO staty(nazev) VALUES ('Kapverdská republika')",
            "INSERT INTO staty(nazev) VALUES ('Stát Katar')",
            "INSERT INTO staty(nazev) VALUES ('Republika Kazachstán')",
            "INSERT INTO staty(nazev) VALUES ('Keňská republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Kiribati')",
            "INSERT INTO staty(nazev) VALUES ('Území Kokosové (Keelingovy) ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Kolumbijská republika')",
            "INSERT INTO staty(nazev) VALUES ('Komorský svaz')",
            "INSERT INTO staty(nazev) VALUES ('Konžská demokratická republika')",
            "INSERT INTO staty(nazev) VALUES ('Konžská republika')",
            "INSERT INTO staty(nazev) VALUES ('Korejská lidově demokratická republika')",
            "INSERT INTO staty(nazev) VALUES ('Korejská republika')",
            "INSERT INTO staty(nazev) VALUES ('Kosovská republika')",
            "INSERT INTO staty(nazev) VALUES ('Kostarická republika')",
            "INSERT INTO staty(nazev) VALUES ('Kubánská republika')",
            "INSERT INTO staty(nazev) VALUES ('Kuvajtský stát')",
            "INSERT INTO staty(nazev) VALUES ('Kyperská republika')",
            "INSERT INTO staty(nazev) VALUES ('Kyrgyzská republika')",
            "INSERT INTO staty(nazev) VALUES ('Laoská lidově demokratická republika')",
            "INSERT INTO staty(nazev) VALUES ('Lesothské království')",
            "INSERT INTO staty(nazev) VALUES ('Libanonská republika')",
            "INSERT INTO staty(nazev) VALUES ('Liberijská republika')",
            "INSERT INTO staty(nazev) VALUES ('Libyjský stát')",
            "INSERT INTO staty(nazev) VALUES ('Lichtenštejnské knížectví')",
            "INSERT INTO staty(nazev) VALUES ('Litevská republika')",
            "INSERT INTO staty(nazev) VALUES ('Lotyšská republika')",
            "INSERT INTO staty(nazev) VALUES ('Lucemburské velkovévodství')",
            "INSERT INTO staty(nazev) VALUES ('Zvláštní administrativní oblast Čínské lidové republiky Macao')",
            "INSERT INTO staty(nazev) VALUES ('Madagaskarská republika')",
            "INSERT INTO staty(nazev) VALUES ('Maďarsko')",
            "INSERT INTO staty(nazev) VALUES ('Malajsie')",
            "INSERT INTO staty(nazev) VALUES ('Malawiská republika')",
            "INSERT INTO staty(nazev) VALUES ('Maledivská republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Mali')",
            "INSERT INTO staty(nazev) VALUES ('Maltská republika')",
            "INSERT INTO staty(nazev) VALUES ('Ostrov Man')",
            "INSERT INTO staty(nazev) VALUES ('Marocké království')",
            "INSERT INTO staty(nazev) VALUES ('Republika Marshallovy ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Martinik')",
            "INSERT INTO staty(nazev) VALUES ('Mauricijská republika')",
            "INSERT INTO staty(nazev) VALUES ('Mauritánská islámská republika')",
            "INSERT INTO staty(nazev) VALUES ('Departement Mayotte')",
            "INSERT INTO staty(nazev) VALUES ('Menší odlehlé ostrovy USA')",
            "INSERT INTO staty(nazev) VALUES ('Spojené státy mexické')",
            "INSERT INTO staty(nazev) VALUES ('Federativní státy Mikronésie')",
            "INSERT INTO staty(nazev) VALUES ('Moldavská republika')",
            "INSERT INTO staty(nazev) VALUES ('Monacké knížectví')",
            "INSERT INTO staty(nazev) VALUES ('Mongolsko')",
            "INSERT INTO staty(nazev) VALUES ('Montserrat')",
            "INSERT INTO staty(nazev) VALUES ('Mosambická republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Myanmarský svaz')",
            "INSERT INTO staty(nazev) VALUES ('Namibijská republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Nauru')",
            "INSERT INTO staty(nazev) VALUES ('Spolková republika Německo')",
            "INSERT INTO staty(nazev) VALUES ('Nepálská federativní demokratická republika')",
            "INSERT INTO staty(nazev) VALUES ('Nigerská republika')",
            "INSERT INTO staty(nazev) VALUES ('Nigerijská federativní republika')",
            "INSERT INTO staty(nazev) VALUES ('Nikaragujská republika')",
            "INSERT INTO staty(nazev) VALUES ('Niue')",
            "INSERT INTO staty(nazev) VALUES ('Nizozemsko')",
            "INSERT INTO staty(nazev) VALUES ('Území Norfolk')",
            "INSERT INTO staty(nazev) VALUES ('Norské království')",
            "INSERT INTO staty(nazev) VALUES ('Nová Kaledonie')",
            "INSERT INTO staty(nazev) VALUES ('Nový Zéland')",
            "INSERT INTO staty(nazev) VALUES ('Sultanát Omán')",
            "INSERT INTO staty(nazev) VALUES ('Pákistánská islámská republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Palau')",
            "INSERT INTO staty(nazev) VALUES ('Palestinská autonomní území')",
            "INSERT INTO staty(nazev) VALUES ('Panamská republika')",
            "INSERT INTO staty(nazev) VALUES ('Nezávislý stát Papua Nová Guinea')",
            "INSERT INTO staty(nazev) VALUES ('Paraguayská republika')",
            "INSERT INTO staty(nazev) VALUES ('Peruánská republika')",
            "INSERT INTO staty(nazev) VALUES ('Pitcairnovy ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Republika Pobřeží slonoviny')",
            "INSERT INTO staty(nazev) VALUES ('Polská republika')",
            "INSERT INTO staty(nazev) VALUES ('Portorické společenství')",
            "INSERT INTO staty(nazev) VALUES ('Portugalská republika')",
            "INSERT INTO staty(nazev) VALUES ('Rakouská republika')",
            "INSERT INTO staty(nazev) VALUES ('Region Réunion')",
            "INSERT INTO staty(nazev) VALUES ('Republika Rovníková Guinea')",
            "INSERT INTO staty(nazev) VALUES ('Rumunsko')",
            "INSERT INTO staty(nazev) VALUES ('Ruská federace')",
            "INSERT INTO staty(nazev) VALUES ('Rwandská republika')",
            "INSERT INTO staty(nazev) VALUES ('Řecká republika')",
            "INSERT INTO staty(nazev) VALUES ('Územní společenství Saint Pierre a Miquelon')",
            "INSERT INTO staty(nazev) VALUES ('Salvadorská republika')",
            "INSERT INTO staty(nazev) VALUES ('Nezávislý stát Samoa')",
            "INSERT INTO staty(nazev) VALUES ('Republika San Marino')",
            "INSERT INTO staty(nazev) VALUES ('Království Saúdská Arábie')",
            "INSERT INTO staty(nazev) VALUES ('Senegalská republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Severní Makedonie')",
            "INSERT INTO staty(nazev) VALUES ('Společenství Severní Mariany')",
            "INSERT INTO staty(nazev) VALUES ('Seychelská republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Sierra Leone')",
            "INSERT INTO staty(nazev) VALUES ('Singapurská republika')",
            "INSERT INTO staty(nazev) VALUES ('Slovenská republika')",
            "INSERT INTO staty(nazev) VALUES ('Slovinská republika')",
            "INSERT INTO staty(nazev) VALUES ('Somálská federativní republika')",
            "INSERT INTO staty(nazev) VALUES ('Stát Spojené arabské emiráty')",
            "INSERT INTO staty(nazev) VALUES ('Spojené státy americké')",
            "INSERT INTO staty(nazev) VALUES ('Srbská republika')",
            "INSERT INTO staty(nazev) VALUES ('Středoafrická republika')",
            "INSERT INTO staty(nazev) VALUES ('Súdánská republika')",
            "INSERT INTO staty(nazev) VALUES ('Surinamská republika')",
            "INSERT INTO staty(nazev) VALUES ('Svatá Helena, Ascension a Tristan da Cunha')",
            "INSERT INTO staty(nazev) VALUES ('Svatá Lucie')",
            "INSERT INTO staty(nazev) VALUES ('Společenství Svatý Bartoloměj')",
            "INSERT INTO staty(nazev) VALUES ('Federace Svatý Kryštof a Nevis')",
            "INSERT INTO staty(nazev) VALUES ('Společenství Svatý Martin')",
            "INSERT INTO staty(nazev) VALUES ('Svatý Martin (NL)')",
            "INSERT INTO staty(nazev) VALUES ('Demokratická republika Svatý Tomáš a Princův ostrov')",
            "INSERT INTO staty(nazev) VALUES ('Svatý Vincenc a Grenadiny')",
            "INSERT INTO staty(nazev) VALUES ('Svazijské království')",
            "INSERT INTO staty(nazev) VALUES ('Syrská arabská republika')",
            "INSERT INTO staty(nazev) VALUES ('Šalomounovy ostrovy')",
            "INSERT INTO staty(nazev) VALUES ('Španělské království')",
            "INSERT INTO staty(nazev) VALUES ('Špicberky a Jan Mayen')",
            "INSERT INTO staty(nazev) VALUES ('Šrílanská demokratická socialistická republika')",
            "INSERT INTO staty(nazev) VALUES ('Švédské království')",
            "INSERT INTO staty(nazev) VALUES ('Švýcarská konfederace')",
            "INSERT INTO staty(nazev) VALUES ('Republika Tádžikistán')",
            "INSERT INTO staty(nazev) VALUES ('Tanzanská sjednocená republika')",
            "INSERT INTO staty(nazev) VALUES ('Thajské království')",
            "INSERT INTO staty(nazev) VALUES ('Tchaj-wan')",
            "INSERT INTO staty(nazev) VALUES ('Tožská republika')",
            "INSERT INTO staty(nazev) VALUES ('Tokelau')",
            "INSERT INTO staty(nazev) VALUES ('Království Tonga')",
            "INSERT INTO staty(nazev) VALUES ('Republika Trinidad a Tobago')",
            "INSERT INTO staty(nazev) VALUES ('Tuniská republika')",
            "INSERT INTO staty(nazev) VALUES ('Turecká republika')",
            "INSERT INTO staty(nazev) VALUES ('Turkmenistán')",
            "INSERT INTO staty(nazev) VALUES ('Ostrovy Turks a Caicos')",
            "INSERT INTO staty(nazev) VALUES ('Tuvalu')",
            "INSERT INTO staty(nazev) VALUES ('Ugandská republika')",
            "INSERT INTO staty(nazev) VALUES ('Ukrajina')",
            "INSERT INTO staty(nazev) VALUES ('Uruguayská východní republika')",
            "INSERT INTO staty(nazev) VALUES ('Republika Uzbekistán')",
            "INSERT INTO staty(nazev) VALUES ('Území Vánoční ostrov')",
            "INSERT INTO staty(nazev) VALUES ('Republika Vanuatu')",
            "INSERT INTO staty(nazev) VALUES ('Vatikánský městský stát')",
            "INSERT INTO staty(nazev) VALUES ('Spojené království Velké Británie a Severního Irska')",
            "INSERT INTO staty(nazev) VALUES ('Bolívarovská republika Venezuela')",
            "INSERT INTO staty(nazev) VALUES ('Vietnamská socialistická republika')",
            "INSERT INTO staty(nazev) VALUES ('Demokratická republika Východní Timor')",
            "INSERT INTO staty(nazev) VALUES ('Teritorium Wallisovy ostrovy a Futuna')",
            "INSERT INTO staty(nazev) VALUES ('Zambijská republika')",
            "INSERT INTO staty(nazev) VALUES ('Saharská arabská demokratická republika')",
            "INSERT INTO staty(nazev) VALUES ('Zimbabwská republika')",
            "COMMIT"
                    };

        /// <summary>
        /// Array with SQL statements which creates all used packages.
        /// </summary>
        public static readonly string[] Packages = new string[]
        {
            @"
CREATE OR REPLACE

/*
 * Package which defines all necessary procedures
 * and functions to perform CRUD operations over
 * all available tables.
 *
 * :author: David Schwam <david.schwam@student.upce.cz>
 *          Jiri Skoda <jiri.skoda@student.upce.cz>
 */
PACKAGE sempr_crud AS 





    -- CRUD operations over 'staty' table
                    
    /*
     * Type definition of data stored in 'staty' table
     */
    TYPE t_staty IS TABLE OF staty%ROWTYPE;

    /*
     * Creates new 'staty' object.
     * :param p_name: Name of new 'staty' object.
     */
    PROCEDURE proc_staty_create(p_name IN staty.nazev%TYPE);

    /*
     * Updates 'staty' object.
     * :param p_id:   Identifier of object which will be updated.
     * :param p_name: New name of object.
     */
    PROCEDURE proc_staty_update(p_id IN staty.id_stat%TYPE, p_name IN staty.nazev%TYPE);

    /*
     * Deletes 'staty' object.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_staty_delete(p_id IN staty.id_stat%TYPE);

    /*
     * Reads all data from 'staty'.
     * :returns: Table with all data from 'staty'.
     */
    FUNCTION  func_staty_read RETURN t_staty PIPELINED;

    /*
     * Reads searched data from 'staty'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with data from 'staty' with searched identifier.
     */
    FUNCTION  func_staty_read(p_id IN staty.id_stat%TYPE) RETURN t_staty PIPELINED;

    /*
     * Reads searched data from 'staty'.
     * :param p_name: Name of searched data.
     * :returns:      Table with data from 'staty' with searched name.
     */
    FUNCTION  func_staty_read(p_name IN staty.nazev%TYPE) RETURN t_staty PIPELINED;





    -- CRUD operations over 'obce' table

    /*
     * Type definition of data stored in 'obce' table.
     */
    TYPE t_obce IS TABLE OF obce%ROWTYPE;

    /*
     * Creates new 'obce' object.
     * :param p_name:    Name of new object.
     * :param p_zip:     ZIP code of new object.
     * :param p_country: Identifier of country in which is 'obce' object located.
     */
    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE);

    /*
     * Creates new 'obce' object.
     * :param p_name:    Name of new object.
     * :param p_part:    Name of part of new object.
     * :param p_zip:     ZIP code of new object.
     * :param p_country: Identifier of country in which is 'obce' object located.
     */
    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE);
                    
    /*
     * Updates 'obce' object.
     * :param p_id:      Identifier of object which will be updated.
     * :param p_name:    New name of object.
     * :param p_zip:     New ZIP code of object.
     * :param p_country: New identifier of country in which is 'obce' object located.
     */
    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE);
                    
    /*
     * Updates 'obce' object.
     * :param p_id:      Identifier of object which will be updated.
     * :param p_name:    New name of object.
     * :param p_zip:     New ZIP code of object.
     * :param p_country: New identifier of country in which is 'obce' object located.
     */
    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country IN obce.stat%TYPE);
    
    /*
     * Deletes 'obce' object.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_obce_delete(p_id IN obce.id_obec%TYPE);

    /*
     * Reads all data from table 'obce'.
     * :returns: Table with all data from table 'obce'.
     */
    FUNCTION func_obce_read RETURN t_obce PIPELINED;

    /*
     * Reads searched data from 'obce'.
     * :param p_id: Identifier of searched object.
     * :returns:    Table with all searched data from table 'obce'.
     */
    FUNCTION func_obce_read(p_id IN obce.id_obec%TYPE) RETURN t_obce PIPELINED;





    -- CRUD operations over 'adresy' table

    /*
     * Type definition of data stored in 'adresy' table.
     */
    TYPE t_adresy IS TABLE OF adresy%ROWTYPE;    

    /*
     * Creates new object 'adresy'.
     * :param p_street:       Name of street.
     * :param p_home:         Number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.*
     */
    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);
    
    /*
     * Creates new object 'adresy'.
     * :param p_street:       Name of street.
     * :param p_home:         Number of home.
     * :param p_orientation:  Orientational number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.*
     */
    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);
    
    /*
     * Creates new object 'adresy'
     * :param p_home:         Number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);
    
    /*
     * Creates new object 'adresy'
     * :param p_home:         Number of home.
     * :param p_orientation:  Orientational number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);
    
    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_street:       New street of object.
     * :param p_home:         New number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);
    
    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_street:       New street of object.
     * :param p_home:         New number of home of object.
     * :param p_orientation:  New orientational number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);
    
    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_home:         New number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);
    
    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_home:         New number of home of object.
     * :param p_orientation:  New orientational number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);
    
    /*
     * Deletes 'adresy' object.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_adresy_delete(p_id IN adresy.id_adresa%TYPE);

    /*
     * Reads all data from 'adresy' table.
     * :returns: Table with data from 'adresy' table.
     */
    FUNCTION func_adresy_read RETURN t_adresy PIPELINED;

    /*
     * Reads searched data from 'adresy' table.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with searched data from 'adresy' table.
     */
    FUNCTION func_adresy_read(p_id IN adresy.id_adresa%TYPE) RETURN t_adresy PIPELINED;




    -- CRUD operations over 'osoby' table

    /*
     * Type definition of data stored in 'osoby' table.
     */
    TYPE t_osoby IS TABLE OF osoby%ROWTYPE;
    
    /*
     * Creates new 'osoby' object.
     * :param p_name:    Name of new 'osoby'.
     * :param p_surname: Surname of new 'osoby'.
     * :param p_email:   E-mail of new 'osoby'.
     * :param p_phone:   Phone number of new 'osoby'.
     */
    PROCEDURE proc_osoby_create(p_name IN osoby.jmeno%TYPE, p_surname IN osoby.prijmeni%TYPE, p_email IN osoby.e_mail%TYPE, p_phone IN osoby.telefon%TYPE);

    /*
     * Updates 'osoby' object.
     * :param p_id:      Identifier of 'osoby' which will be updated.
     * :param p_name:    New name of 'osoby'.
     * :param p_surname: New surname of 'osoby'.
     * :param p_email:   New e-mail of 'osoby'.
     * :param p_phone:   New phone number of 'osoby'.
     */
    PROCEDURE proc_osoby_update(p_id IN osoby.id_osoba%TYPE, p_name IN osoby.jmeno%TYPE, p_surname IN osoby.prijmeni%TYPE, p_email IN osoby.e_mail%TYPE, p_phone IN osoby.telefon%TYPE);

    /*
     * Deletes data from 'osoby'.
     * :param p_id: Identifier of 'osoby' which will be deleted.
     */
    PROCEDURE proc_osoby_delete(p_id IN osoby.id_osoba%TYPE);

    /*
     * Reads all data from 'osoby'.
     * :returns: Table with data from 'osoby'.
     */
    FUNCTION  func_osoby_read RETURN t_osoby PIPELINED;

    /*
     * Reads specified data from 'osoby'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with data from 'osoby' which has specified identifier.
     */
    FUNCTION  func_osoby_read(p_id IN osoby.id_osoba%TYPE) RETURN t_osoby PIPELINED;
    
    
     
    
    
    -- CRUD operations over 'zamestnanci' table.

    /*
     * Type definition of table 'zamestnanci'.
     */
    TYPE t_zamestnanci IS TABLE OF zamestnanci%ROWTYPE;
    
    /*
     * Creates new object 'zamestnanci'.
     * :param p_personal_number: Personal number of new 'zamestnanci' object.
     * :param p_date:            Start of employment of new 'zamestnanci' object.
     * :param p_residence:       Identifier of address from 'adresy' of residence of new 'zamestnanci' object.
     * :param p_personal_data:   Identifier of personal data from 'osoby' of new 'zamestnanci' object.
     */
    PROCEDURE proc_zamestnanci_create(p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE);

    /*
     * Creates new object 'zamestnanci'.
     * :param p_personal_number: Personal number of new 'zamestnanci' object.
     * :param p_date:            Start of employment of new 'zamestnanci' object.
     * :param p_residence:       Identifier of address from 'adresy' of residence of new 'zamestnanci' object.
     * :param p_personal_data:   Identifier of personal data from 'osoby' of new 'zamestnanci' object.
     * :param p_superior:        Identifier of superior employee from 'zamestnanci' of new 'zamestnanci' object.
     */
    PROCEDURE proc_zamestnanci_create(p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE, p_superior IN zamestnanci.nadrizeny%TYPE);

    /*
     * Updates 'zamestnanci'.
     * :param p_id:              Identifier of 'zamestanci' object which will be updated.
     * :param p_personal_number: New personal number of 'zamestnanci' object.
     * :param p_date:            New sart of employment of 'zamestnanci' object.
     * :param p_residence:       New identifier of address from 'adresy' of residence of 'zamestnanci' object.
     * :param p_personal_data:   New identifier of personal data from 'osoby' of 'zamestnanci' object.
     */
    PROCEDURE proc_zamestnanci_update(p_id IN zamestnanci.id_zamestnanec%TYPE, p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE);

    /*
     * Updates 'zamestnanci'.
     * :param p_id:              Identifier of 'zamestanci' object which will be updated.
     * :param p_personal_number: New personal number of 'zamestnanci' object.
     * :param p_date:            New sart of employment of 'zamestnanci' object.
     * :param p_residence:       New identifier of address from 'adresy' of residence of 'zamestnanci' object.
     * :param p_personal_data:   New identifier of personal data from 'osoby' of 'zamestnanci' object.
     * :param p_superior:        New identifier of superior employee from 'zamestnanci' of 'zamestnanci' object.
     */
    PROCEDURE proc_zamestnanci_update(p_id IN zamestnanci.id_zamestnanec%TYPE, p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE, p_superior IN zamestnanci.nadrizeny%TYPE);

    /*
     * Deletes data from 'zamestnanci'.
     * :param p_id: Identifier of 'zamestnanci' which will be deleted.
     */
    PROCEDURE proc_zamestnanci_delete(p_id IN zamestnanci.id_zamestnanec%TYPE);

    /*
     * Function which reads all available data from 'zamestnanci'.
     * :returns: Table with data from 'zamestnanci'.
     */
    FUNCTION  func_zamestnanci_read RETURN t_zamestnanci PIPELINED;

    /*
     * Function which reads data from 'zamestnanci' defined by its identifier.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with data from 'zamestnanci' with searched identifier.
     */
    FUNCTION  func_zamestnanci_read(p_id IN zamestnanci.id_zamestnanec%TYPE) RETURN t_zamestnanci PIPELINED;





    -- CRUD operations over 'role' table.
    
    /*
     * Type definition of table with data from 'role'.
     */
    TYPE t_role IS TABLE OF role%ROWTYPE;

    /*
     * Creates object 'role'.
     * :param p_name: Name of new 'role' object.
     */
    PROCEDURE proc_role_create(p_name IN role.nazev%TYPE);

    /*
     * Updates object 'role'.
     * :param p_id:   Identifier of object which will be updated.
     * :param p_name: New name of 'role'.
     */
    PROCEDURE proc_role_update(p_id IN role.id_role%TYPE, p_name IN role.nazev%TYPE);

    /*
     * Deletes object from 'role'.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_role_delete(p_id IN role.id_role%TYPE);

    /*
     * Reads all available data from 'role'.
     * :returs: Table with all data from 'role'.
     */
    FUNCTION  func_role_read RETURN t_role PIPELINED;

        
    /*
     * Reads searched data from 'role'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with searched data from 'role'.
     */
    FUNCTION  func_role_read(p_id IN role.id_role%TYPE) RETURN t_role PIPELINED;

    



    -- CRUD operations over 'stavy' table.

    /*
     * Type definition of table with data from 'stavy'.
     */
    TYPE t_stavy IS TABLE OF stavy%ROWTYPE;

    /*
     * Creates new 'stavy' object.
     * :param p_name: Name of new 'stavy' object.
     */
    PROCEDURE proc_stavy_create(p_name IN stavy.nazev%TYPE);

    /*
     * Updates 'stavy' object.
     * :param p_id:   Identifier of object which will be updated.
     * :param p_name: New name of 'stavy' object.
     */
    PROCEDURE proc_stavy_update(p_id IN stavy.id_stav%TYPE, p_name IN stavy.nazev%TYPE);
    
    /*
     * Deletes object 'stavy'.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_stavy_delete(p_id IN stavy.id_stav%TYPE);

    /*
     * Reads all data from 'stavy'.
     * :returns: Table with all data from 'stavy'.
     */
    FUNCTION  func_stavy_read RETURN t_stavy PIPELINED;

    /*
     * Reads searched data from 'stavy'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with searched data from 'stavy'.
     */
    FUNCTION  func_stavy_read(p_id IN stavy.id_stav%TYPE) RETURN t_stavy PIPELINED;





    -- CRUD operations over 'uzivatele' table.

    /*
     * Type definition of table of 'uzivatele'.
     */
    TYPE t_uzivatele IS TABLE OF uzivatele%ROWTYPE;
    
    /*
     * Creates new 'uzivatele' object.
     * :param p_pwd:   Password of new 'uzivatele'.
     * :param p_reg:   Date and time of registration of new 'uzivatele'.
     * :param p_pict:  Picture of new 'uzivatele'.
     * :param p_role:  Identifier of 'role' of new 'uzivatele'.
     * :param p_state: Identifier of 'stavy' of new 'uzivatele'.
     * :param p_empl:  Identifier of 'zamestnanci' to which is new 'uzivatele' assigned to.
     */
    PROCEDURE proc_uzivatele_create(p_pwd IN uzivatele.heslo%TYPE, p_reg IN uzivatele.datum_registrace%TYPE, p_pict IN uzivatele.obrazek%TYPE, p_role IN uzivatele.role%TYPE, p_state IN uzivatele.stav%TYPE, p_empl IN uzivatele.zamestnanec%TYPE);

    /*
     * Updates 'uzivatele' object.
     * :param p_id:    Identifier of 'uzivatele' which will be updated.
     * :param p_pwd:   New password of 'uzivatele'.
     * :param p_reg:   New date and time of registration of 'uzivatele'.
     * :param p_pict:  New picture of 'uzivatele'.
     * :param p_role:  New identifier of 'role' of 'uzivatele'.
     * :param p_state: New identifier of 'stavy' of 'uzivatele'.
     * :param p_empl:  New identifier of 'zamestnanci' to which is 'uzivatele' assigned to.
     */
    PROCEDURE proc_uzivatele_update(p_id IN uzivatele.id_uzivatel%TYPE, p_pwd IN uzivatele.heslo%TYPE, p_reg IN uzivatele.datum_registrace%TYPE, p_pict IN uzivatele.obrazek%TYPE, p_role IN uzivatele.role%TYPE, p_state IN uzivatele.stav%TYPE, p_empl IN uzivatele.zamestnanec%TYPE);

    /*
     * Deletes object from 'uzivatele'.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_uzivatele_delete(p_id IN uzivatele.id_uzivatel%TYPE);

    /*
     * Reads all available data from 'uzivatele'.
     * :returns: Table with all data from 'uzivatele'.
     */
    FUNCTION  func_uzivatele_read RETURN t_uzivatele PIPELINED;

    /*
     * Reads all searched data from 'uzivatele'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with all searched from 'uzivatele'.
     */
    FUNCTION  func_uzivatele_read(p_id IN uzivatele.id_uzivatel%TYPE) RETURN t_uzivatele PIPELINED;
    

END sempr_crud;",
@"CREATE OR REPLACE
/*
 * Body of package with procedures and functions to
 * perform CRUD operations over all tables.
 *
 * :author: David Schwam <david.schwam@student.upce.cz>
 *          Jiri Skoda <jiri.skoda@student.upce.cz>
 */
PACKAGE BODY sempr_crud AS





    --- Definition of CRUD operations over 'staty' table

    /*
     * Creates new 'staty' object.
     * :param p_name: Name of new 'staty' object.
     */
    PROCEDURE proc_staty_create(p_name IN staty.nazev%TYPE) AS
    BEGIN
            SET TRANSACTION READ WRITE;
            INSERT INTO staty(nazev) VALUES (p_name);
            COMMIT;
    END proc_staty_create;

    /*
     * Updates 'staty' object.
     * :param p_id:   Identifier of object which will be updated.
     * :param p_name: New name of object.
     */
    PROCEDURE proc_staty_update(p_id IN staty.id_stat%TYPE, p_name IN staty.nazev%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE staty SET nazev=p_name WHERE id_stat=p_id;
        COMMIT;
    END proc_staty_update;

    /*
     * Deletes 'staty' object.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_staty_delete(p_id IN staty.id_stat%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM staty WHERE id_stat=p_id;
        COMMIT;
    END proc_staty_delete;

    /*
     * Reads all data from 'staty'.
     * :returns: Table with all data from 'staty'.
     */
    FUNCTION func_staty_read RETURN t_staty PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_stat   staty%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM staty;
        LOOP
            FETCH v_cursor INTO v_stat;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_stat);
        END LOOP;
        CLOSE v_cursor;
    END func_staty_read;

    /*
     * Reads searched data from 'staty'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with data from 'staty' with searched identifier.
     */
    FUNCTION func_staty_read(p_id IN staty.id_stat%TYPE) RETURN t_staty PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_stat   staty%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM staty WHERE id_stat=p_id;
        LOOP
            FETCH v_cursor INTO v_stat;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_stat);
        END LOOP;
        CLOSE v_cursor;
    END func_staty_read;

    /*
     * Reads searched data from 'staty'.
     * :param p_name: Name of searched data.
     * :returns:      Table with data from 'staty' with searched name.
     */
    FUNCTION func_staty_read(p_name IN staty.nazev%TYPE) RETURN t_staty PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_stat   staty%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM staty WHERE nazev=p_name;
        LOOP
            FETCH v_cursor INTO v_stat;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_stat);
        END LOOP;
        CLOSE v_cursor;
    END func_staty_read;





    -- Definition of CRUD operations over 'obce' table

    /*
     * Creates new 'obce' object.
     * :param p_name:    Name of new object.
     * :param p_zip:     ZIP code of new object.
     * :param p_country: Identifier of country in which is 'obce' object located.
     */
    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE) AS
    BEGIN
        INSERT INTO obce(nazev, psc, stat) VALUES (p_name, p_zip, p_country);
    END proc_obce_create;

    /*
     * Creates new 'obce' object.
     * :param p_name:    Name of new object.
     * :param p_part:    Name of part of new object.
     * :param p_zip:     ZIP code of new object.
     * :param p_country: Identifier of country in which is 'obce' object located.
     */
    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE) AS
    BEGIN
        INSERT INTO obce(nazev, cast_obce, psc, stat) VALUES (p_name, p_part, p_zip, p_country);
    END proc_obce_create;

    /*
     * Updates 'obce' object.
     * :param p_id:      Identifier of object which will be updated.
     * :param p_name:    New name of object.
     * :param p_zip:     New ZIP code of object.
     * :param p_country: New identifier of country in which is 'obce' object located.
     */
    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE obce SET nazev=p_name, psc=p_zip, stat=p_country WHERE id_obec=p_id;
        COMMIT;
    END proc_obce_update;
         
    /*
     * Updates 'obce' object.
     * :param p_id:      Identifier of object which will be updated.
     * :param p_name:    New name of object.
     * :param p_zip:     New ZIP code of object.
     * :param p_country: New identifier of country in which is 'obce' object located.
     */
    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE obce SET nazev=p_name, cast_obce=p_part, psc=p_zip, stat=p_country WHERE id_obec=p_id;
        COMMIT;
    END proc_obce_update;

    /*
     * Deletes 'obce' object.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_obce_delete(p_id IN obce.id_obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM obce WHERE id_obec=p_id;
        COMMIT;
    END proc_obce_delete;

    /*
     * Reads all data from table 'obce'.
     * :returns: Table with all data from table 'obce'.
     */
    FUNCTION func_obce_read RETURN t_obce PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_obec   obce%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM obce;
        LOOP
            FETCH v_cursor INTO v_obec;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_obec);
        END LOOP;
        CLOSE v_cursor;
    END func_obce_read;

    /*
     * Reads searched data from 'obce'.
     * :param p_id: Identifier of searched object.
     * :returns:    Table with all searched data from table 'obce'.
     */
    FUNCTION func_obce_read(p_id IN obce.id_obec%TYPE) RETURN t_obce PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_obec   obce%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM obce WHERE id_obec=p_id;
        LOOP
            FETCH v_cursor INTO v_obec;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_obec);
        END LOOP;
        CLOSE v_cursor;
    END func_obce_read;





    -- Definitions of CRUD operations over 'adresy' table

    /*
     * Creates new object 'adresy'.
     * :param p_street:       Name of street.
     * :param p_home:         Number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.*
     */
    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        INSERT INTO adresy(ulice, cislo_popisne, obec) VALUES (p_street, p_home, p_municipality);
    END proc_adresy_create;

    /*
     * Creates new object 'adresy'.
     * :param p_street:       Name of street.
     * :param p_home:         Number of home.
     * :param p_orientation:  Orientational number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.*
     */
    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        INSERT INTO adresy(ulice, cislo_popisne, cislo_orientacni, obec) VALUES (p_street, p_home, p_orientation, p_municipality);
    END proc_adresy_create;

    /*
     * Creates new object 'adresy'
     * :param p_home:         Number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.*
     */
    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        INSERT INTO adresy(cislo_popisne, obec) VALUES (p_home, p_municipality);
    END proc_adresy_create;

    /*
     * Creates new object 'adresy'
     * :param p_home:         Number of home.
     * :param p_orientation:  Orientational number of home.
     * :param p_municipality: Identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        INSERT INTO adresy(cislo_popisne, cislo_orientacni, obec) VALUES (p_home, p_orientation, p_municipality);
    END proc_adresy_create;

    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_street:       New street of object.
     * :param p_home:         New number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE adresy SET ulice=p_street, cislo_popisne=p_home, obec=p_municipality WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_update;

    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_street:       New street of object.
     * :param p_home:         New number of home of object.
     * :param p_orientation:  New orientational number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE adresy SET ulice=p_street, cislo_popisne=p_home, cislo_orientacni=p_orientation, obec=p_municipality WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_update;

    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_home:         New number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE adresy SET cislo_popisne=p_home, obec=p_municipality WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_update;

    /* Updates 'adresy' object.
     * :param p_id:           Identifier of object which will be updated.
     * :param p_home:         New number of home of object.
     * :param p_orientation:  New orientational number of home of object.
     * :param p_municipality: New identifier of 'obce' in which is 'adresy' located.
     */
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE adresy SET cislo_popisne=p_home, cislo_orientacni=p_orientation, obec=p_municipality WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_update;

    /*
     * Deletes 'adresy' object.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_adresy_delete(p_id IN adresy.id_adresa%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM adresy WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_delete;

    /*
     * Reads all data from 'adresy' table.
     * :returns: Table with data from 'adresy' table.
     */
    FUNCTION  func_adresy_read RETURN t_adresy PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_adresa adresy%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM adresy;
        LOOP
            FETCH v_cursor INTO v_adresa;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_adresa);
        END LOOP;
        CLOSE v_cursor;
    END func_adresy_read;

    /*
     * Reads searched data from 'adresy' table.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with searched data from 'adresy' table.
     */
    FUNCTION func_adresy_read(p_id IN adresy.id_adresa%TYPE) RETURN t_adresy PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_adresa adresy%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM adresy WHERE id_adresa=p_id;
        LOOP
            FETCH v_cursor INTO v_adresa;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_adresa);
        END LOOP;
        CLOSE v_cursor;
    END func_adresy_read;





    -- Definition of CRUD operations over 'osoby' table

    /*
     * Creates new 'osoby' object.
     * :param p_name:    Name of new 'osoby'.
     * :param p_surname: Surname of new 'osoby'.
     * :param p_email:   E-mail of new 'osoby'.
     * :param p_phone:   Phone number of new 'osoby'.
     */
    PROCEDURE proc_osoby_create(p_name IN osoby.jmeno%TYPE, p_surname IN osoby.prijmeni%TYPE, p_email IN osoby.e_mail%TYPE, p_phone IN osoby.telefon%TYPE) AS
    BEGIN
        INSERT INTO osoby(jmeno, prijmeni, e_mail, telefon) VALUES (p_name, p_surname, p_email, p_phone);
    END proc_osoby_create;

    /*
     * Updates 'osoby' object.
     * :param p_id:      Identifier of 'osoby' which will be updated.
     * :param p_name:    New name of 'osoby'.
     * :param p_surname: New surname of 'osoby'.
     * :param p_email:   New e-mail of 'osoby'.
     * :param p_phone:   New phone number of 'osoby'.
     */
    PROCEDURE proc_osoby_update(p_id IN osoby.id_osoba%TYPE, p_name IN osoby.jmeno%TYPE, p_surname IN osoby.prijmeni%TYPE, p_email IN osoby.e_mail%TYPE, p_phone IN osoby.telefon%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE osoby
        SET
            jmeno=p_name,
            prijmeni=p_surname,
            e_mail=p_email,
            telefon=p_phone
        WHERE id_osoba=p_id;
        COMMIT;
    END proc_osoby_update;

    /*
     * Deletes data from 'osoby'.
     * :param p_id: Identifier of 'osoby' which will be deleted.
     */
    PROCEDURE proc_osoby_delete(p_id IN osoby.id_osoba%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM osoby WHERE id_osoba=p_id;
        COMMIT;
    END proc_osoby_delete;

    /*
     * Reads all data from 'osoby'.
     * :returns: Table with data from 'osoby'.
     */
    FUNCTION  func_osoby_read RETURN t_osoby PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_osoba  osoby%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM osoby;
        LOOP
            FETCH v_cursor INTO v_osoba;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_osoba);
        END LOOP;
        CLOSE v_cursor;
    END func_osoby_read;

    /*
     * Reads specified data from 'osoby'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with data from 'osoby' which has specified identifier.
     */
    FUNCTION  func_osoby_read(p_id IN osoby.id_osoba%TYPE) RETURN t_osoby PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_osoba  osoby%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM osoby WHERE id_osoba=p_id;
        LOOP
            FETCH v_cursor INTO v_osoba;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_osoba);
        END LOOP;
        CLOSE v_cursor;
    END func_osoby_read;





    -- Definition of CRUD operations over 'zamestnanci' table.
    /*
     * Creates new object 'zamestnanci'.
     * :param p_personal_number: Personal number of new 'zamestnanci' object.
     * :param p_date:            Start of employment of new 'zamestnanci' object.
     * :param p_residence:       Identifier of address from 'adresy' of residence of new 'zamestnanci' object.
     * :param p_personal_data:   Identifier of personal data from 'osoby' of new 'zamestnanci' object.
     */
    PROCEDURE proc_zamestnanci_create(p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE) AS
    BEGIN
        INSERT INTO zamestnanci(
            osobni_cislo,
            datum_nastupu,
            bydliste,
            osobni_udaje)
        VALUES (
            p_personal_number,
            p_date,
            p_residence,
            p_personal_data
        );
    END proc_zamestnanci_create;

    /*
     * Creates new object 'zamestnanci'.
     * :param p_personal_number: Personal number of new 'zamestnanci' object.
     * :param p_date:            Start of employment of new 'zamestnanci' object.
     * :param p_residence:       Identifier of address from 'adresy' of residence of new 'zamestnanci' object.
     * :param p_personal_data:   Identifier of personal data from 'osoby' of new 'zamestnanci' object.
     * :param p_superior:        Identifier of superior employee from 'zamestnanci' of new 'zamestnanci' object.
     */
    PROCEDURE proc_zamestnanci_create(p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE, p_superior IN zamestnanci.nadrizeny%TYPE) AS
    BEGIN
        INSERT INTO zamestnanci(
            osobni_cislo,
            datum_nastupu,
            bydliste,
            osobni_udaje,
            nadrizeny)
        VALUES (
            p_personal_number,
            p_date,
            p_residence,
            p_personal_data,
            p_superior
        );
    END proc_zamestnanci_create;

    /*
     * Updates 'zamestnanci'.
     * :param p_id:              Identifier of 'zamestanci' object which will be updated.
     * :param p_personal_number: New personal number of 'zamestnanci' object.
     * :param p_date:            New sart of employment of 'zamestnanci' object.
     * :param p_residence:       New identifier of address from 'adresy' of residence of 'zamestnanci' object.
     * :param p_personal_data:   New identifier of personal data from 'osoby' of 'zamestnanci' object.
     */
    PROCEDURE proc_zamestnanci_update(p_id IN zamestnanci.id_zamestnanec%TYPE, p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE zamestnanci
        SET
            osobni_cislo=p_personal_number,
            datum_nastupu=p_date,
            bydliste=p_residence,
            osobni_udaje=p_personal_data
        WHERE id_zamestnanec=p_id;
        COMMIT;
    END proc_zamestnanci_update;

    /*
     * Updates 'zamestnanci'.
     * :param p_id:              Identifier of 'zamestanci' object which will be updated.
     * :param p_personal_number: New personal number of 'zamestnanci' object.
     * :param p_date:            New sart of employment of 'zamestnanci' object.
     * :param p_residence:       New identifier of address from 'adresy' of residence of 'zamestnanci' object.
     * :param p_personal_data:   New identifier of personal data from 'osoby' of 'zamestnanci' object.
     * :param p_superior:        New identifier of superior employee from 'zamestnanci' of 'zamestnanci' object.
     */
    PROCEDURE proc_zamestnanci_update(p_id IN zamestnanci.id_zamestnanec%TYPE, p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE, p_superior IN zamestnanci.nadrizeny%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE zamestnanci
        SET
            osobni_cislo=p_personal_number,
            datum_nastupu=p_date,
            bydliste=p_residence,
            osobni_udaje=p_personal_data,
            nadrizeny=p_superior
        WHERE id_zamestnanec=p_id;
        COMMIT;
    END proc_zamestnanci_update;

    /*
     * Deletes data from 'zamestnanci'.
     * :param p_id: Identifier of 'zamestnanci' which will be deleted.
     */
    PROCEDURE proc_zamestnanci_delete(p_id IN zamestnanci.id_zamestnanec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM zamestnanci WHERE id_zamestnanec=p_id;
        COMMIT;
    END proc_zamestnanci_delete;

    /*
     * Function which reads all available data from 'zamestnanci'.
     * :returns: Table with data from 'zamestnanci'.
     */
    FUNCTION  func_zamestnanci_read RETURN t_zamestnanci PIPELINED AS
        v_cursor       SYS_REFCURSOR;
        v_zamestnanec  zamestnanci%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM zamestnanci;
        LOOP
            FETCH v_cursor INTO v_zamestnanec;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_zamestnanec);
        END LOOP;
        CLOSE v_cursor;
    END func_zamestnanci_read;


    /*
     * Function which reads data from 'zamestnanci' defined by its identifier.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with data from 'zamestnanci' with searched identifier.
     */
    FUNCTION  func_zamestnanci_read(p_id IN zamestnanci.id_zamestnanec%TYPE) RETURN t_zamestnanci PIPELINED AS
        v_cursor       SYS_REFCURSOR;
        v_zamestnanec  zamestnanci%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM zamestnanci WHERE id_zamestnanec=p_id;
        LOOP
            FETCH v_cursor INTO v_zamestnanec;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_zamestnanec);
        END LOOP;
        CLOSE v_cursor;
    END func_zamestnanci_read;




    
    -- Definition of CRUD operations over 'role' table.

    /*
     * Creates object 'role'.
     * :param p_name: Name of new 'role' object.
     */
    PROCEDURE proc_role_create(p_name IN role.nazev%TYPE) AS
    BEGIN
        INSERT INTO role(nazev) VALUES (p_name);
    END proc_role_create;

    /*
     * Updates object 'role'.
     * :param p_id:   Identifier of object which will be updated.
     * :param p_name: New name of 'role'.
     */
    PROCEDURE proc_role_update(p_id IN role.id_role%TYPE, p_name IN role.nazev%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE role SET nazev=p_name WHERE id_role=p_id;
        COMMIT;
    END proc_role_update;

    /*
     * Deletes object from 'role'.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_role_delete(p_id IN role.id_role%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM role WHERE id_role=p_id;
        COMMIT;
    END proc_role_delete;

    /*
     * Reads all available data from 'role'.
     * :returs: Table with all data from 'role'.
     */
    FUNCTION  func_role_read RETURN t_role PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_role   role%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM role;
        LOOP
            FETCH v_cursor INTO v_role;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_role);
        END LOOP;
        CLOSE v_cursor;
    END func_role_read;

        
    /*
     * Reads searched data from 'role'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with searched data from 'role'.
     */
    FUNCTION  func_role_read(p_id IN role.id_role%TYPE) RETURN t_role PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_role   role%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM role WHERE id_role=p_id;
        LOOP
            FETCH v_cursor INTO v_role;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_role);
        END LOOP;
        CLOSE v_cursor;
    END func_role_read;





    -- Definition of CRUD operations over 'stavy' table.
    /*
     * Creates new 'stavy' object.
     * :param p_name: Name of new 'stavy' object.
     */
    PROCEDURE proc_stavy_create(p_name IN stavy.nazev%TYPE) AS
    BEGIN
        INSERT INTO stavy(nazev) VALUES(p_name);
    END proc_stavy_create;

    /*
     * Updates 'stavy' object.
     * :param p_id:   Identifier of object which will be updated.
     * :param p_name: New name of 'stavy' object.
     */
    PROCEDURE proc_stavy_update(p_id IN stavy.id_stav%TYPE, p_name IN stavy.nazev%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE stavy SET nazev=p_name WHERE id_stav=p_id;
        COMMIT;
    END proc_stavy_update;
    
    /*
     * Deletes object 'stavy'.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_stavy_delete(p_id IN stavy.id_stav%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;  
        DELETE FROM stavy WHERE id_stav=p_id;
        COMMIT;
    END proc_stavy_delete;

    /*
     * Reads all data from 'stavy'.
     * :returns: Table with all data from 'stavy'.
     */
    FUNCTION  func_stavy_read RETURN t_stavy PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_stav   stavy%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM stavy;
        LOOP
            FETCH v_cursor INTO v_stav;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_stav);
        END LOOP;
        CLOSE v_cursor;
    END func_stavy_read;

    /*
     * Reads searched data from 'stavy'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with searched data from 'stavy'.
     */
    FUNCTION  func_stavy_read(p_id IN stavy.id_stav%TYPE) RETURN t_stavy PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_stav   stavy%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM stavy WHERE id_stav=p_id;
        LOOP
            FETCH v_cursor INTO v_stav;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_stav);
        END LOOP;
        CLOSE v_cursor;
    END func_stavy_read;





    -- Definition of CRUD operations over 'uzivatele' table.
    /*
     * Creates new 'uzivatele' object.
     * :param p_pwd:   Password of new 'uzivatele'.
     * :param p_reg:   Date and time of registration of new 'uzivatele'.
     * :param p_pict:  Picture of new 'uzivatele'.
     * :param p_role:  Role of new 'uzivatele'.
     * :param p_state: State of new 'uzivatele'.
     * :param p_empl:  Employee to which is new 'uzivatele' assigned to.
     */
    PROCEDURE proc_uzivatele_create(p_pwd IN uzivatele.heslo%TYPE, p_reg IN uzivatele.datum_registrace%TYPE, p_pict IN uzivatele.obrazek%TYPE, p_role IN uzivatele.role%TYPE, p_state IN uzivatele.stav%TYPE, p_empl IN uzivatele.zamestnanec%TYPE) AS
    BEGIN
        INSERT INTO uzivatele(heslo, datum_registrace, obrazek, role, stav, zamestnanec)
        VALUES (p_pwd, p_reg, p_pict, p_role, p_state, p_empl);
    END proc_uzivatele_create;

    /*
     * Updates 'uzivatele' object.
     * :param p_id:    Identifier of 'uzivatele' which will be updated.
     * :param p_pwd:   New password of 'uzivatele'.
     * :param p_reg:   New date and time of registration of 'uzivatele'.
     * :param p_pict:  New picture of 'uzivatele'.
     * :param p_role:  New identifier of 'role' of 'uzivatele'.
     * :param p_state: New identifier of 'stavy' of 'uzivatele'.
     * :param p_empl:  New identifier of 'zamestnanci' to which is 'uzivatele' assigned to.
     */
    PROCEDURE proc_uzivatele_update(p_id IN uzivatele.id_uzivatel%TYPE, p_pwd IN uzivatele.heslo%TYPE, p_reg IN uzivatele.datum_registrace%TYPE, p_pict IN uzivatele.obrazek%TYPE, p_role IN uzivatele.role%TYPE, p_state IN uzivatele.stav%TYPE, p_empl IN uzivatele.zamestnanec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE uzivatele
        SET
            heslo=p_pwd,
            datum_registrace=p_reg,
            obrazek=p_pict,
            role=p_role,
            stav=p_state,
            zamestnanec=p_empl
        WHERE id_uzivatel=p_id;
        COMMIT;
    END proc_uzivatele_update;

    /*
     * Deletes object from 'uzivatele'.
     * :param p_id: Identifier of object which will be deleted.
     */
    PROCEDURE proc_uzivatele_delete(p_id IN uzivatele.id_uzivatel%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM uzivatele WHERE id_uzivatel=p_id;
        COMMIT;
    END proc_uzivatele_delete;

    /*
     * Reads all available data from 'uzivatele'.
     * :returns: Table with all data from 'uzivatele'.
     */
    FUNCTION  func_uzivatele_read RETURN t_uzivatele PIPELINED AS
        v_cursor   SYS_REFCURSOR;
        v_uzivatel uzivatele%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM uzivatele;
        LOOP
            FETCH v_cursor INTO v_uzivatel;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_uzivatel);
        END LOOP;
        CLOSE v_cursor;
    END func_uzivatele_read;

    /*
     * Reads all searched data from 'uzivatele'.
     * :param p_id: Identifier of searched data.
     * :returns:    Table with all searched from 'uzivatele'.
     */
    FUNCTION  func_uzivatele_read(p_id IN uzivatele.id_uzivatel%TYPE) RETURN t_uzivatele PIPELINED AS
        v_cursor   SYS_REFCURSOR;
        v_uzivatel uzivatele%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM uzivatele WHERE id_uzivatel=p_id;
        LOOP
            FETCH v_cursor INTO v_uzivatel;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_uzivatel);
        END LOOP;
        CLOSE v_cursor;
    END func_uzivatele_read;

END sempr_crud;",
@"CREATE OR REPLACE

/*
 * Package with some usefull utility functions.
 *
 * :author: David Schwam <david.schwam@student.upce.cz>
 *          Jiri Skoda <jiri.skoda@student.upce.cz>
 */
PACKAGE sempr_utils AS

    /*
     * Gets last generated number of sequence
     * :param p_seq: Name of sequence.
     * :returns:     Last generated number of sequence,
     *               or -2147483648 if any error occurs.
     */
    FUNCTION func_last_seq(p_seq VARCHAR2) RETURN NUMBER;
END sempr_utils;",
@"CREATE OR REPLACE
/*
 * Body of package with utility functions.
 *
 * :author: David Schwam <david.schwam@student.upce.cz>
 *          Jiri Skoda <jiri.skoda@student.upce.cz>
 */
PACKAGE BODY sempr_utils AS
    
    /*
     * Gets last generated number of sequence
     * :param p_seq: Name of sequence.
     * :returns:     Last generated number of sequence,
     *               or -2147483648 if any error occurs.
     */
    FUNCTION func_last_seq(p_seq VARCHAR2) RETURN NUMBER AS
        v_reti NUMBER := -2147483648;
        v_sequence_exists NUMBER;
    BEGIN
        SELECT COUNT(*)
        INTO v_sequence_exists
        FROM all_sequences
        WHERE sequence_name=p_seq;
        IF v_sequence_exists = 0 THEN
            RETURN v_reti;
        END IF;
        EXECUTE IMMEDIATE 'SELECT' || p_seq || '.CURRVAL FROM DUAL' INTO v_reti;
        RETURN v_reti;
    EXCEPTION
        WHEN OTHERS THEN
            RETURN v_reti;
    END func_last_seq;

END sempr_utils;"
        };
    }
}
