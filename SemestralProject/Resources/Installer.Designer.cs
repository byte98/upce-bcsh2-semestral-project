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
        ///   Looks up a localized string similar to ALTER TABLE adresy
        ///    ADD CONSTRAINT adresy_obce_fk FOREIGN KEY ( obec )
        ///    REFERENCES obce ( id_obec )
        ///
        ///ALTER TABLE autobusy
        ///    ADD CONSTRAINT autobus_prevodovka_fk FOREIGN KEY(prevodovka )
        ///    REFERENCES prevodovky(id_prevodovka )
        ///
        ///ALTER TABLE autobusy
        ///    ADD CONSTRAINT autobus_vozidlo_fk FOREIGN KEY(id_vozidlo )
        ///    REFERENCES vozidla(id_vozidlo )
        ///    ON DELETE CASCADE
        ///
        ///ALTER TABLE cipove_karty
        ///    ADD CONSTRAINT cipove_karty_zamestnanec_fk FOREIGN KEY(drzitel )
        ///    REFERENCES zamestna [rest of string was truncated]&quot;;.
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
        ///    BEGIN
        ///        SELECT id_uzivatel INTO v_reti
        ///        FROM uzivatele
        ///      [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SEMPR_API_BODY {
            get {
                return ResourceManager.GetString("SEMPR_API_BODY", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to     /*
        ///     * Logins user to the system.
        ///     * :param p_personal_nr: Personal number of user.
        ///     * :param p_password:    Entered password.
        ///     * :returns:             Identifier of user with matching personal number and password
        ///     *                       or -2147483648 if there is no such user.
        ///     */
        ///--
        ///.
        /// </summary>
        internal static string SEMPR_API_DOCS {
            get {
                return ResourceManager.GetString("SEMPR_API_DOCS", resourceCulture);
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
        ///   Looks up a localized string similar to      
        ///     
        ///     
        ///     
        ///     
        ///     /* CRUD operations over &apos;staty&apos; table */
        ///        
        ///    /*
        ///     * Creates new &apos;staty&apos; object.
        ///     * :param p_name: Name of new &apos;staty&apos; object.
        ///     */
        ///--
        ///
        ///    /*
        ///     * Updates &apos;staty&apos; object.
        ///     * :param p_id:   Identifier of object which will be updated.
        ///     * :param p_name: New name of object.
        ///     */
        ///--
        ///
        ///    /*
        ///     * Deletes &apos;staty&apos; object.
        ///     * :param p_id: Identifier of object which will be deleted.
        ///     */
        ///--
        ///
        ///    /*
        ///     * Reads all  [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SEMPR_CRUD_DOCS {
            get {
                return ResourceManager.GetString("SEMPR_CRUD_DOCS", resourceCulture);
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
        ///--
        ///    /*
        ///     * Type definition of data stored in &apos;staty&apos; table
        ///     */
        ///    TYPE t_staty IS TABLE OF staty%ROWTYPE;
        ///--
        ///    PROCEDURE proc_staty_create(p_name IN staty.nazev%TYPE);
        ///--
        ///    PROCEDURE proc_staty_ [rest of string was truncated]&quot;;.
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
        ///   Looks up a localized string similar to     /*
        ///     * Gets last generated number of sequence.
        ///     * :param p_seq: Name of sequence.
        ///     * :returns:     Last generated number of sequence,
        ///     *               or -2147483648 if any error occurs.
        ///     */
        ///--
        ///    /*
        ///     * Gets next number from sequence.
        ///     * :param p_seq: Name of sequence.
        ///     * :returns:     Next number from sequence, 
        ///     *               or -2147483648 if any error occurs.
        ///     */
        ///--
        ///.
        /// </summary>
        internal static string SEMPR_UTILS_DOCS {
            get {
                return ResourceManager.GetString("SEMPR_UTILS_DOCS", resourceCulture);
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
        ///CREATE SEQUENCE cipove_karty_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE jizdni_rady_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE linky_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE modely_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE obce_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE osoby_seq START WITH 1 NOCACHE ORDER
        ///CREATE SEQUENCE osobni_cisla_seq START WITH 100000 NOCACHE ORDER
        ///CREATE SEQUENCE plany_smen_seq START WITH 1 NOCACHE OR [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SEQUENCES {
            get {
                return ResourceManager.GetString("SEQUENCES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO stavy(id_stav, nazev) VALUES (0, &apos;Aktivní&apos;)
        ///INSERT INTO stavy(id_stav, nazev) VALUES (1, &apos;Blokovaný&apos;)
        ///INSERT INTO stavy(id_stav, nazev) VALUES (2, &apos;Smazaný&apos;)
        ///.
        /// </summary>
        internal static string STATES {
            get {
                return ResourceManager.GetString("STATES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///CREATE TABLE adresy (
        ///id_adresa        INTEGER DEFAULT adresy_seq.nextval NOT NULL,
        ///ulice            VARCHAR2(64),
        ///cislo_popisne    INTEGER NOT NULL,
        ///cislo_orientacni INTEGER,
        ///obec             INTEGER NOT NULL
        ///)
        ///
        ///ALTER TABLE adresy ADD CONSTRAINT adresy_pk PRIMARY KEY(id_adresa )
        ///
        ///CREATE TABLE autobusy(
        ///id_vozidlo INTEGER NOT NULL,
        ///kloubovy NUMBER NOT NULL,
        ///prevodovka INTEGER NOT NULL
        ///)
        ///
        ///ALTER TABLE autobusy ADD CONSTRAINT autobus_pk PRIMARY KEY(id_vozidlo )
        ///
        ///CREATE TABLE cipove_karty(
        /// [rest of string was truncated]&quot;;.
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
