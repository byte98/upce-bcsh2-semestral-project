﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SemestralProject.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Installer {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Installer() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SemestralProject.Resources.Installer", typeof(Installer).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to  INSERT INTO staty(nazev) VALUES (&apos;Afghánská islámská republika&apos;)
        /// INSERT INTO staty(nazev) VALUES (&apos;Provincie Alandy&apos;)
        /// INSERT INTO staty(nazev) VALUES (&apos;Albánská republika&apos;)
        /// INSERT INTO staty(nazev) VALUES (&apos;Alžírská demokratická a lidová republika&apos;)
        /// INSERT INTO staty(nazev) VALUES (&apos;Území Americká Samoa&apos;)
        /// INSERT INTO staty(nazev) VALUES (&apos;Americké Panenské ostrovy&apos;)
        /// INSERT INTO staty(nazev) VALUES (&apos;Andorrské knížectví&apos;)
        /// INSERT INTO staty(nazev) VALUES (&apos;Angolská republika&apos;)
        /// INSERT INTO sta [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string COUNTRIES {
            get {
                return ResourceManager.GetString("COUNTRIES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO opravneni(nazev, systemovy_nazev) VALUES (&apos;Měnit svoji roli za běhu&apos;, &apos;role.modify.runtime&apos;)
        ///INSERT INTO opravneni(nazev, systemovy_nazev) VALUES (&apos;Měnit svoji roli&apos;, &apos;role.modify.own&apos;)
        ///INSERT INTO opravneni(nazev, systemovy_nazev) VALUES (&apos;Měnit své údaje&apos;, &apos;user.modify.own&apos;)
        ///INSERT INTO opravneni(nazev, systemovy_nazev) VALUES (&apos;Měnit své osobní číslo&apos;, &apos;employee.personal_number.modify.own&apos;)
        ///INSERT INTO opravneni(nazev, systemovy_nazev) VALUES (&apos;Měnit svůj datum nástupu&apos;, &apos;employee.date.mo [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string PERMISSIONS {
            get {
                return ResourceManager.GetString("PERMISSIONS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALTER TABLE adresy
        ///    ADD CONSTRAINT adresy_obce_fk FOREIGN KEY ( obec )
        ///        REFERENCES obce ( id_obec )
        ///
        ///ALTER TABLE jizdni_rady
        ///    ADD CONSTRAINT jizdni_rady_linky_fk FOREIGN KEY ( linka )
        ///        REFERENCES linky ( id_linka )
        ///
        ///ALTER TABLE jizdni_rady
        ///    ADD CONSTRAINT jizdni_rady_zastavka_fk FOREIGN KEY ( zastavka )
        ///        REFERENCES zastavky ( id_zastavka )
        ///
        ///ALTER TABLE obce
        ///    ADD CONSTRAINT obce_stat_fk FOREIGN KEY ( stat )
        ///        REFERENCES staty ( id_stat )
        ///
        ///ALTER TABLE pra [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RELATIONS {
            get {
                return ResourceManager.GetString("RELATIONS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALTER SEQUENCE adresy_seq RESTART
        ///ALTER SEQUENCE cipove_karty_seq RESTART
        ///ALTER SEQUENCE jizdni_rady_seq RESTART
        ///ALTER SEQUENCE linky_seq RESTART
        ///ALTER SEQUENCE modely_seq RESTART
        ///ALTER SEQUENCE obce_seq RESTART
        ///ALTER SEQUENCE osoby_seq RESTART
        ///ALTER SEQUENCE osobni_cisla_seq RESTART
        ///ALTER SEQUENCE plany_smen_seq RESTART
        ///ALTER SEQUENCE prevodovky_seq RESTART
        ///ALTER SEQUENCE provozy_seq RESTART
        ///ALTER SEQUENCE role_seq RESTART
        ///ALTER SEQUENCE skutecne_rady_seq RESTART
        ///ALTER SEQUENCE smeny_seq RESTA [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string RESTART {
            get {
                return ResourceManager.GetString("RESTART", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO role (id_role, nazev) VALUES (0, &apos;SUPERUŽIVATEL&apos;)
        ///INSERT INTO role (id_role, nazev) VALUES (1, &apos;Uživatel&apos;)
        ///.
        /// </summary>
        internal static string ROLES {
            get {
                return ResourceManager.GetString("ROLES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE OR REPLACE
        ////*
        /// * Body of package with some API functions.
        /// * :author: David Schwam &lt;david.schwam@student.upce.cz&gt;
        /// *          Jiri Skoda &lt;jiri.skoda@student.upce.cz&gt;
        /// */
        ///PACKAGE BODY sempr_api AS
        ///
        ///--
        ///    FUNCTION func_users_login(p_personal_nr IN zamestnanci.osobni_cislo%TYPE, p_password IN uzivatele.heslo%TYPE) RETURN uzivatele.id_uzivatel%TYPE AS
        ///        v_reti uzivatele.id_uzivatel%TYPE      := -2147483648;
        ///        v_loggable stavy.prihlasitelny%TYPE    := 1;
        ///    BEGIN
        ///        FOR use [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SEMPR_API_BODY {
            get {
                return ResourceManager.GetString("SEMPR_API_BODY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE OR REPLACE
        ////*
        /// * Package with some API functions.
        /// * :author: David Schwam &lt;david.schwam@student.upce.cz&gt;
        /// *          Jiri Skoda &lt;jiri.skoda@student.upce.cz&gt;
        /// */
        ///PACKAGE sempr_api AS
        ///
        ///--
        ///    FUNCTION func_users_login(p_personal_nr IN zamestnanci.osobni_cislo%TYPE, p_password IN uzivatele.heslo%TYPE) RETURN uzivatele.id_uzivatel%TYPE;
        ///
        ///END sempr_api;
        ///.
        /// </summary>
        internal static string SEMPR_API_HEADER {
            get {
                return ResourceManager.GetString("SEMPR_API_HEADER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE OR REPLACE
        ////*
        /// * Body of package with procedures and functions to
        /// * perform CRUD operations over all tables.
        /// *
        /// * :author: David Schwam &lt;david.schwam@student.upce.cz&gt;
        /// *          Jiri Skoda &lt;jiri.skoda@student.upce.cz&gt;
        /// */
        ///PACKAGE BODY sempr_crud AS
        ///--
        ///    PROCEDURE proc_staty_create(p_name IN staty.nazev%TYPE) AS
        ///    BEGIN
        ///            SET TRANSACTION READ WRITE;
        ///            INSERT INTO staty(nazev) VALUES (p_name);
        ///            COMMIT;
        ///    END proc_staty_create;
        ///--
        ///    PROCEDURE pr [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SEMPR_CRUD_BODY {
            get {
                return ResourceManager.GetString("SEMPR_CRUD_BODY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE OR REPLACE
        ///
        ////*
        /// * Package which defines all necessary procedures
        /// * and functions to perform CRUD operations over
        /// * all available tables.
        /// *
        /// * :author: David Schwam &lt;david.schwam@student.upce.cz&gt;
        /// *          Jiri Skoda &lt;jiri.skoda@student.upce.cz&gt;
        /// */
        ///PACKAGE sempr_crud AS 
        ///
        ///
        ///    TYPE t_staty IS TABLE OF staty%ROWTYPE;
        ///
        ///    PROCEDURE proc_staty_create(p_name IN staty.nazev%TYPE);
        ///
        ///    PROCEDURE proc_staty_update(p_id IN staty.id_stat%TYPE, p_name IN staty.nazev%TYPE);
        ///
        ///    PROCED [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SEMPR_CRUD_HEADER {
            get {
                return ResourceManager.GetString("SEMPR_CRUD_HEADER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE OR REPLACE
        ////*
        /// * Body of package with utility functions.
        /// *
        /// * :author: David Schwam &lt;david.schwam@student.upce.cz&gt;
        /// *          Jiri Skoda &lt;jiri.skoda@student.upce.cz&gt;
        /// */
        ///PACKAGE BODY sempr_utils AS
        ///
        ///--
        ///    FUNCTION func_last_seq(p_seq VARCHAR2) RETURN NUMBER AS
        ///        v_reti NUMBER := -2147483648;
        ///        v_sequence_exists NUMBER;
        ///        sequence_not_found EXCEPTION;
        ///        PRAGMA EXCEPTION_INIT(sequence_not_found, -10000);
        ///    BEGIN
        ///        SELECT COUNT(*)
        ///        INTO v_sequen [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SEMPR_UTILS_BODY {
            get {
                return ResourceManager.GetString("SEMPR_UTILS_BODY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE OR REPLACE
        ///
        ////*
        /// * Package with some usefull utility functions.
        /// *
        /// * :author: David Schwam &lt;david.schwam@student.upce.cz&gt;
        /// *          Jiri Skoda &lt;jiri.skoda@student.upce.cz&gt;
        /// */
        ///PACKAGE sempr_utils AS
        ///
        ///--
        ///    FUNCTION func_last_seq(p_seq VARCHAR2) RETURN NUMBER;
        ///--
        ///    FUNCTION func_next_seq(p_seq VARCHAR2) RETURN NUMBER;
        ///
        ///END sempr_utils;
        ///.
        /// </summary>
        internal static string SEMPR_UTILS_HEADER {
            get {
                return ResourceManager.GetString("SEMPR_UTILS_HEADER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE SEQUENCE adresy_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE jizdni_rady_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE linky_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE obce_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE opravneni_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE osoby_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE osobni_cisla_seq START WITH 100005 NOCACHE ORDER
        ///CREATE SEQUENCE plany_smen_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE prava_seq START WITH 1 NOCACHE ORDER        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SEQUENCES {
            get {
                return ResourceManager.GetString("SEQUENCES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO stavy(id_stav, nazev, prihlasitelny) VALUES (0, &apos;Aktivní&apos;, 0)
        ///INSERT INTO stavy(id_stav, nazev, prihlasitelny) VALUES (1, &apos;Blokovaný&apos;, 1)
        ///INSERT INTO stavy(id_stav, nazev, prihlasitelny) VALUES (2, &apos;Smazaný&apos;, 1)
        ///.
        /// </summary>
        internal static string STATES {
            get {
                return ResourceManager.GetString("STATES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO prava (role, opravneni)
        ///SELECT 0 AS role_id, o.id_opravneni AS opravneni_id
        ///FROM opravneni o
        ///.
        /// </summary>
        internal static string SUPERUSER {
            get {
                return ResourceManager.GetString("SUPERUSER", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE adresy (
        ///    id_adresa        INTEGER DEFAULT adresy_seq.nextval NOT NULL,
        ///    ulice            VARCHAR2(64),
        ///    cislo_popisne    INTEGER NOT NULL,
        ///    cislo_orientacni INTEGER,
        ///    obec             INTEGER NOT NULL
        ///)
        ///
        ///ALTER TABLE adresy ADD CONSTRAINT adresy_pk PRIMARY KEY ( id_adresa )
        ///
        ///CREATE TABLE jizdni_rady (
        ///    id_jizdni_rad  INTEGER DEFAULT jizdni_rady_seq.nextval NOT NULL,
        ///    cas_prijezdu   DATE NOT NULL,
        ///    cas_odjezdu    DATE NOT NULL,
        ///    poradove_cislo INTEGER NOT [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TABLES {
            get {
                return ResourceManager.GetString("TABLES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to TRUNCATE TABLE soupravy_metra CASCADE
        ///TRUNCATE TABLE zabezpecovace CASCADE
        ///TRUNCATE TABLE trolejbusy CASCADE
        ///TRUNCATE TABLE tramvaje CASCADE
        ///TRUNCATE TABLE autobusy CASCADE
        ///TRUNCATE TABLE prevodovky CASCADE
        ///TRUNCATE TABLE skutecne_rady CASCADE
        ///TRUNCATE TABLE plany_smen CASCADE
        ///TRUNCATE TABLE jizdni_rady CASCADE
        ///TRUNCATE TABLE zastavky CASCADE
        ///TRUNCATE TABLE linky CASCADE
        ///TRUNCATE TABLE smeny CASCADE
        ///TRUNCATE TABLE vozidla CASCADE
        ///TRUNCATE TABLE modely CASCADE
        ///TRUNCATE TABLE vyrobci CASCADE
        ///TR [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string TRUNCATE {
            get {
                return ResourceManager.GetString("TRUNCATE", resourceCulture);
            }
        }
    }
}
