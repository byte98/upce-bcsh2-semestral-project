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
            psc INTEGER NOT NULL,
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
            nazev VARCHAR2(32) NOT NULL
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
            "INSERT INTO role (id_role, nazev) VALUES (0, 'SUPERUŽIVATEL')"
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
