CREATE OR REPLACE
/*
 * Body of package with procedures and functions to
 * perform CRUD operations over all tables.
 *
 * :author: David Schwam <david.schwam@student.upce.cz>
 *          Jiri Skoda <jiri.skoda@student.upce.cz>
 */
PACKAGE BODY sempr_crud AS
--
    PROCEDURE proc_staty_create(p_name IN staty.nazev%TYPE) AS
    BEGIN
            SET TRANSACTION READ WRITE;
            INSERT INTO staty(nazev) VALUES (p_name);
            COMMIT;
    END proc_staty_create;
--
    PROCEDURE proc_staty_update(p_id IN staty.id_stat%TYPE, p_name IN staty.nazev%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE staty SET nazev=p_name WHERE id_stat=p_id;
        COMMIT;
    END proc_staty_update;
--
    PROCEDURE proc_staty_delete(p_id IN staty.id_stat%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM staty WHERE id_stat=p_id;
        COMMIT;
    END proc_staty_delete;
--
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
--
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
--
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
--
    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE) AS
    BEGIN
        INSERT INTO obce(nazev, psc, stat) VALUES (p_name, p_zip, p_country);
    END proc_obce_create;
--
    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE) AS
    BEGIN
        INSERT INTO obce(nazev, cast_obce, psc, stat) VALUES (p_name, p_part, p_zip, p_country);
    END proc_obce_create;
--
    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE obce SET nazev=p_name, psc=p_zip, stat=p_country WHERE id_obec=p_id;
        COMMIT;
    END proc_obce_update;
--
    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE obce SET nazev=p_name, cast_obce=p_part, psc=p_zip, stat=p_country WHERE id_obec=p_id;
        COMMIT;
    END proc_obce_update;
--
    PROCEDURE proc_obce_delete(p_id IN obce.id_obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM obce WHERE id_obec=p_id;
        COMMIT;
    END proc_obce_delete;
--
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
--
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
--
    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        INSERT INTO adresy(ulice, cislo_popisne, obec) VALUES (p_street, p_home, p_municipality);
    END proc_adresy_create;
--
    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        INSERT INTO adresy(ulice, cislo_popisne, cislo_orientacni, obec) VALUES (p_street, p_home, p_orientation, p_municipality);
    END proc_adresy_create;
--
    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        INSERT INTO adresy(cislo_popisne, obec) VALUES (p_home, p_municipality);
    END proc_adresy_create;
--
    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        INSERT INTO adresy(cislo_popisne, cislo_orientacni, obec) VALUES (p_home, p_orientation, p_municipality);
    END proc_adresy_create;
--
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE adresy SET ulice=p_street, cislo_popisne=p_home, obec=p_municipality WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_update;
--
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE adresy SET ulice=p_street, cislo_popisne=p_home, cislo_orientacni=p_orientation, obec=p_municipality WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_update;
--
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE adresy SET cislo_popisne=p_home, obec=p_municipality WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_update;
--
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE adresy SET cislo_popisne=p_home, cislo_orientacni=p_orientation, obec=p_municipality WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_update;
--
    PROCEDURE proc_adresy_delete(p_id IN adresy.id_adresa%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM adresy WHERE id_adresa=p_id;
        COMMIT;
    END proc_adresy_delete;
--
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
--
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
--
    PROCEDURE proc_osoby_create(p_name IN osoby.jmeno%TYPE, p_surname IN osoby.prijmeni%TYPE, p_email IN osoby.e_mail%TYPE, p_phone IN osoby.telefon%TYPE) AS
    BEGIN
        INSERT INTO osoby(jmeno, prijmeni, e_mail, telefon) VALUES (p_name, p_surname, p_email, p_phone);
    END proc_osoby_create;
--
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
--
    PROCEDURE proc_osoby_delete(p_id IN osoby.id_osoba%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM osoby WHERE id_osoba=p_id;
        COMMIT;
    END proc_osoby_delete;
--
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
--
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
--
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
--
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
--
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
--
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
--
    PROCEDURE proc_zamestnanci_delete(p_id IN zamestnanci.id_zamestnanec%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM zamestnanci WHERE id_zamestnanec=p_id;
        COMMIT;
    END proc_zamestnanci_delete;
--
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
--
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
--
    PROCEDURE proc_role_create(p_name IN role.nazev%TYPE) AS
    BEGIN
        INSERT INTO role(nazev) VALUES (p_name);
    END proc_role_create;
--
    PROCEDURE proc_role_update(p_id IN role.id_role%TYPE, p_name IN role.nazev%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE role SET nazev=p_name WHERE id_role=p_id;
        COMMIT;
    END proc_role_update;
--
    PROCEDURE proc_role_delete(p_id IN role.id_role%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM role WHERE id_role=p_id;
        COMMIT;
    END proc_role_delete;
--
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
--
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
--
    PROCEDURE proc_stavy_create(p_name IN stavy.nazev%TYPE, p_loginable IN stavy.prihlasitelny%TYPE) AS
    BEGIN
        INSERT INTO stavy(nazev, prihlasitelny) VALUES(p_name, p_loginable);
    END proc_stavy_create;
--
    PROCEDURE proc_stavy_update(p_id IN stavy.id_stav%TYPE, p_name IN stavy.nazev%TYPE, p_loginable IN stavy.prihlasitelny%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE stavy SET nazev=p_name, prihlasitelny=p_loginable WHERE id_stav=p_id;
        COMMIT;
    END proc_stavy_update;
--
    PROCEDURE proc_stavy_delete(p_id IN stavy.id_stav%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;  
        DELETE FROM stavy WHERE id_stav=p_id;
        COMMIT;
    END proc_stavy_delete;
--
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
--
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
--
    PROCEDURE proc_uzivatele_create(p_pwd IN uzivatele.heslo%TYPE, p_reg IN uzivatele.datum_registrace%TYPE, p_pict IN uzivatele.obrazek%TYPE, p_role IN uzivatele.role%TYPE, p_state IN uzivatele.stav%TYPE, p_empl IN uzivatele.zamestnanec%TYPE) AS
    BEGIN
        INSERT INTO uzivatele(heslo, datum_registrace, obrazek, role, stav, zamestnanec)
        VALUES (p_pwd, p_reg, p_pict, p_role, p_state, p_empl);
    END proc_uzivatele_create;
--
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
--
    PROCEDURE proc_uzivatele_delete(p_id IN uzivatele.id_uzivatel%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM uzivatele WHERE id_uzivatel=p_id;
        COMMIT;
    END proc_uzivatele_delete;
--
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
--
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
--
    PROCEDURE proc_opravneni_create(p_name IN opravneni.nazev%TYPE, p_sysname IN opravneni.systemovy_nazev%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        INSERT INTO opravneni(nazev, systemovy_nazev) VALUES (p_name, p_sysname);
        COMMIT;
    END proc_opravneni_create;
--
    PROCEDURE proc_opravneni_update(p_id IN opravneni.id_opravneni%TYPE, p_name IN opravneni.nazev%TYPE, p_sysname IN opravneni.systemovy_nazev%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE opravneni SET nazev=p_name, systemovy_nazev=p_sysname
        WHERE id_opravneni=p_id;
        COMMIT;
    END proc_opravneni_update;
--
    PROCEDURE proc_opravneni_delete(p_id IN opravneni.id_opravneni%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM opravneni WHERE id_opravneni=p_id;
        COMMIT;
    END proc_opravneni_delete;
--
    FUNCTION func_opravneni_read RETURN t_opravneni PIPELINED AS
        v_cursor    SYS_REFCURSOR;
        v_opravneni opravneni%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM opravneni;
        LOOP
            FETCH v_cursor INTO v_opravneni;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_opravneni);
        END LOOP;
        CLOSE v_cursor;
    END func_opravneni_read;
--
    FUNCTION  func_opravneni_read(p_id IN opravneni.id_opravneni%TYPE) RETURN t_opravneni PIPELINED AS
        v_cursor    SYS_REFCURSOR;
        v_opravneni opravneni%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM opravneni WHERE id_opravneni=p_id;
        LOOP
            FETCH v_cursor INTO v_opravneni;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_opravneni);
        END LOOP;
        CLOSE v_cursor;
    END func_opravneni_read;
--
    PROCEDURE proc_prava_create(p_role IN prava.role%TYPE, p_perm IN prava.opravneni%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        INSERT INTO prava(role,opravneni) VALUES(p_role, p_perm);
        COMMIT;
    END proc_prava_create;
--
    PROCEDURE proc_prava_delete(p_id IN prava.id_pravo%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM prava WHERE id_pravo=p_id;
        COMMIT;
    END proc_prava_delete;
--
    FUNCTION  func_prava_read(p_role IN prava.role%TYPE) RETURN t_prava PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_pravo   prava%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM prava WHERE role=p_role;
        LOOP
            FETCH v_cursor INTO v_pravo;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_pravo);
        END LOOP;
        CLOSE v_cursor;
    END func_prava_read;
--

    PROCEDURE proc_linky_create(p_code IN linky.kod%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        INSERT INTO linky(kod) VALUES (p_code);
        COMMIT;
    END proc_linky_create;
--
    PROCEDURE proc_linky_update(p_id IN linky.id_linka%TYPE, p_code IN linky.kod%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE linky SET kod=p_code
        WHERE id_linka=p_id;
        COMMIT;
    END proc_linky_update;
--
    PROCEDURE proc_linky_delete(p_id IN linky.id_linka%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM linky
        WHERE id_linka=p_id;
        COMMIT;
    END proc_linky_delete;
--

    FUNCTION func_linky_read RETURN t_linky PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_linka   linky%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM linky;
        LOOP
            FETCH v_cursor INTO v_linka;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_linka);
        END LOOP;
        CLOSE v_cursor;
    END func_linky_read;
--
    FUNCTION func_linky_read(p_id IN linky.id_linka%TYPE) RETURN t_linky PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_linka   linky%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM linky WHERE id_linka=p_id;
        LOOP
            FETCH v_cursor INTO v_linka;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_linka);
        END LOOP;
        CLOSE v_cursor;
    END func_linky_read;
--
--

    PROCEDURE proc_zastavky_create(p_code IN zastavky.kod%TYPE, p_name IN zastavky.nazev%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        INSERT INTO zastavky(nazev, kod) VALUES (p_name, p_code);
        COMMIT;
    END proc_zastavky_create;
--
    PROCEDURE proc_zastavky_update(p_id IN zastavky.id_zastavka%TYPE, p_name IN zastavky.nazev%TYPE, p_code IN zastavky.kod%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE zastavky SET nazev=p_name, kod=p_code
        WHERE id_zastavka=p_id;
        COMMIT;
    END proc_zastavky_update;
--
    PROCEDURE proc_zastavky_delete(p_id IN zastavky.id_zastavka%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM zastavky
        WHERE id_zastavka=p_id;
        COMMIT;
    END proc_zastavky_delete;
--

    FUNCTION func_zastavky_read RETURN t_zastavky PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_zastavka   zastavky%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM zastavky;
        LOOP
            FETCH v_cursor INTO v_zastavka;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_zastavka);
        END LOOP;
        CLOSE v_cursor;
    END func_zastavky_read;
--
    FUNCTION func_zastavky_read(p_id IN zastavky.id_zastavka%TYPE) RETURN t_zastavky PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_zastavka   zastavky%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM zastavky WHERE id_zastavka=p_id;
        LOOP
            FETCH v_cursor INTO v_zastavka;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_zastavka);
        END LOOP;
        CLOSE v_cursor;
    END func_zastavky_read;
--

   PROCEDURE proc_vozidla_create(p_evidence_number IN vozidla.evidencni_cislo%TYPE, p_type IN vozidla.typ_vozidla%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        INSERT INTO vozidla(evidencni_cislo, typ_vozidla)
        VALUES (p_evidence_number, p_type);
        COMMIT;
    END proc_vozidla_create;

    PROCEDURE proc_vozidla_update(p_id IN vozidla.id_vozidlo%TYPE, p_evidence_number IN vozidla.evidencni_cislo%TYPE, p_type IN vozidla.typ_vozidla%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE vozidla
        SET evidencni_cislo=p_evidence_number, typ_vozidla=p_type
        WHERE id_vozidlo=p_id;
        COMMIT;
    END proc_vozidla_update;

    PROCEDURE proc_vozidla_delete(p_id IN vozidla.id_vozidlo%TYPE) AS
    BEGIN
        DELETE FROM vozidla WHERE id_vozidlo=p_id;
    END proc_vozidla_delete;

    FUNCTION func_vozidla_read RETURN t_vozidla PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_vozidlo   vozidla%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM vozidla;
        LOOP
            FETCH v_cursor INTO v_vozidlo;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_vozidlo);
        END LOOP;
        CLOSE v_cursor;
    END func_vozidla_read;

     FUNCTION func_vozidla_read(p_id IN vozidla.id_vozidlo%TYPE) RETURN t_vozidla PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_vozidlo   vozidla%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM vozidla WHERE id_vozidlo=p_id;
        LOOP
            FETCH v_cursor INTO v_vozidlo;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_vozidlo);
        END LOOP;
        CLOSE v_cursor;
    END func_vozidla_read;
--

    PROCEDURE proc_smeny_create(id_vozidlo IN smeny.id_vozidlo%TYPE, id_zamestnanec IN smeny.id_zamestnanec%TYPE, id_jizdni_rad IN smeny.id_jizdni_rad%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        INSERT INTO smeny(id_vozidlo, id_zamestnanec, id_jizdni_rad)
        VALUES (id_vozidlo, id_zamestnanec, id_jizdni_rad);
        COMMIT;
    END proc_smeny_create;

    PROCEDURE proc_smeny_update(p_id IN smeny.id_smena%TYPE, id_vozidlo IN smeny.id_vozidlo%TYPE, id_zamestnanec IN smeny.id_zamestnanec%TYPE, id_jizdni_rad IN smeny.id_jizdni_rad%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE smeny
        SET id_vozidlo=id_vozidlo, id_zamestnanec=id_zamestnanec, id_jizdni_rad=id_jizdni_rad
        WHERE id_smena=p_id;
        COMMIT;
    END proc_smeny_update;

    PROCEDURE proc_smeny_delete(p_id IN smeny.id_smena%TYPE) AS
    BEGIN
        DELETE FROM smeny WHERE id_smena=p_id;
    END proc_smeny_delete;

    FUNCTION func_smeny_read RETURN t_smeny PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_smena smeny%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM smeny;
        LOOP
            FETCH v_cursor INTO v_smena;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_smena);
        END LOOP;
        CLOSE v_cursor;
    END func_smeny_read;

    FUNCTION func_smeny_read(p_id IN smeny.id_smena%TYPE) RETURN t_smeny PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_smena   smeny%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM smeny WHERE id_smena=p_id;
        LOOP
            FETCH v_cursor INTO v_smena;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_smena);
        END LOOP;
        CLOSE v_cursor;
    END func_smeny_read;
--
    PROCEDURE proc_jizdni_rady_create(p_arrival IN jizdni_rady.cas_prijezdu%TYPE, p_departure IN jizdni_rady.cas_odjezdu%TYPE, p_nr IN jizdni_rady.poradove_cislo%TYPE, p_variant IN jizdni_rady.varianta%TYPE, p_line IN jizdni_rady.linka%TYPE, p_stop IN jizdni_rady.zastavka%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        INSERT INTO jizdni_rady(cas_prijezdu, cas_odjezdu, poradove_cislo, varianta, linka, zastavka)
        VALUES (p_arrival, p_departure, p_nr, p_variant, p_line, p_stop);
        COMMIT;
    END proc_jizdni_rady_create;

    PROCEDURE proc_jizdni_rady_update(p_id IN jizdni_rady.id_jizdni_rad%TYPE, p_arrival IN jizdni_rady.cas_prijezdu%TYPE, p_departure IN jizdni_rady.cas_odjezdu%TYPE, p_nr IN jizdni_rady.poradove_cislo%TYPE, p_variant IN jizdni_rady.varianta%TYPE, p_line IN jizdni_rady.linka%TYPE, p_stop IN jizdni_rady.zastavka%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE jizdni_rady
        SET cas_prijezdu=p_arrival, cas_odjezdu=p_departure, poradove_cislo=p_nr, varianta=p_variant, linka=p_line, zastavka=p_stop
        WHERE id_jizdni_rad=p_id;
        COMMIT;
    END proc_jizdni_rady_update;

    PROCEDURE proc_jizdni_rady_delete(p_id IN jizdni_rady.id_jizdni_rad%TYPE) AS
    BEGIN
        DELETE FROM jizdni_rady WHERE id_jizdni_rad=p_id;
    END proc_jizdni_rady_delete;

    FUNCTION func_jizdni_rady_read RETURN t_jizdni_rady PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_jizdni_rad   jizdni_rady%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM jizdni_rady;
        LOOP
            FETCH v_cursor INTO v_jizdni_rad;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_jizdni_rad);
        END LOOP;
        CLOSE v_cursor;
    END func_jizdni_rady_read;

    FUNCTION func_jizdni_rady_read(p_id IN jizdni_rady.id_jizdni_rad%TYPE) RETURN t_jizdni_rady PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_jizdni_rad   jizdni_rady%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM jizdni_rady WHERE id_jizdni_rad=p_id;
        LOOP
            FETCH v_cursor INTO v_jizdni_rad;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_jizdni_rad);
        END LOOP;
        CLOSE v_cursor;
    END func_jizdni_rady_read;

    FUNCTION func_logy_read RETURN t_logy PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_log     logy%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM logy ORDER BY cas DESC;
        LOOP
            FETCH v_cursor INTO v_log;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_log);
        END LOOP;
        CLOSE v_cursor;
    END func_logy_read; 

    FUNCTION func_logy_read(p_id IN logy.id_log%TYPE) RETURN t_logy PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_log     logy%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM logy WHERE id_log=p_id ORDER BY cas DESC;
        LOOP
            FETCH v_cursor INTO v_log;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_log);
        END LOOP;
        CLOSE v_cursor;
    END func_logy_read;

    PROCEDURE proc_obrazky_create(p_content IN obrazky.obsah%TYPE, p_hash IN obrazky.hash%TYPE, p_name IN obrazky.nazev%TYPE, p_date IN obrazky.datum_nahrani%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        INSERT INTO obrazky (obsah, hash, nazev, datum_nahrani)
        VALUES (p_content, p_hash, p_name, p_date);
        COMMIT;
    END proc_obrazky_create;
    
    PROCEDURE proc_obrazky_delete(p_id in obrazky.id_obrazek%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM obrazky WHERE id_obrazek=p_id;
        COMMIT;
    END proc_obrazky_delete;
    
    FUNCTION func_obrazky_read RETURN t_obrazky PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_obrazek     obrazky%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM obrazky;
        LOOP
            FETCH v_cursor INTO v_obrazek;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_obrazek);
        END LOOP;
        CLOSE v_cursor;
    END func_obrazky_read;

    FUNCTION func_obrazky_read(p_id IN obrazky.id_obrazek%TYPE) RETURN t_obrazky PIPELINED AS
        v_cursor  SYS_REFCURSOR;
        v_obrazek     obrazky%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM obrazky WHERE id_obrazek=p_id;
        LOOP
            FETCH v_cursor INTO v_obrazek;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_obrazek);
        END LOOP;
        CLOSE v_cursor;
    END func_obrazky_read;

END sempr_crud;
