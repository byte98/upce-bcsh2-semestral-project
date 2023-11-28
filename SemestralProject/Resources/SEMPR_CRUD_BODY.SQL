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
    PROCEDURE proc_stavy_create(p_name IN stavy.nazev%TYPE) AS
    BEGIN
        INSERT INTO stavy(nazev) VALUES(p_name);
    END proc_stavy_create;
--
    PROCEDURE proc_stavy_update(p_id IN stavy.id_stav%TYPE, p_name IN stavy.nazev%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE stavy SET nazev=p_name WHERE id_stav=p_id;
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
    PROCEDURE proc_karty_create(p_number IN cipove_karty.cislo_karty%TYPE, p_issued IN cipove_karty.datum_vydani%TYPE, p_validity IN cipove_karty.datum_platnosti%TYPE, p_allowed in cipove_karty.povolena%TYPE, p_holder IN cipove_karty.drzitel%TYPE) AS
    BEGIN
        INSERT INTO cipove_karty(cislo_karty, datum_vydani, datum_platnosti, povolena, drzitel)
        VALUES (p_number, p_issued, p_validity, p_allowed, p_holder);
    END proc_karty_create;
--
    PROCEDURE proc_karty_update(p_id IN cipove_karty.id_cipova_karta%TYPE, p_number IN cipove_karty.cislo_karty%TYPE, p_issued IN cipove_karty.datum_vydani%TYPE, p_validity IN cipove_karty.datum_platnosti%TYPE, p_allowed in cipove_karty.povolena%TYPE, p_holder IN cipove_karty.drzitel%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        UPDATE cipove_karty
        SET cislo_karty=p_number, datum_vydani=p_issued,k datum_platnosti=p_validity, povolena=p_allowed, drzitel=p_holder
        WHERE id_cipova_karta=p_id;
        COMMIT;
    END proc_karty_update;
--
    PROCEDURE proc_karty_delete(p_id IN cipove_karty.id_cipova_karta%TYPE) AS
    BEGIN
        SET TRANSACTION READ WRITE;
        DELETE FROM cipove_karty WHERE id_cipova_karta=p_id;
        COMMIT;
    END proc_karty_delete;
--
    FUNCTION func_karty_read RETURN t_cipove_karty PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_karta  cipove_karty%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM cipove_karty;
        LOOP
            FETCH v_cursor INTO v_karta;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_karta);
        END LOOP;
        CLOSE v_cursor;
    END func_karty_read;
--
    FUNCTION func_karty_read(p_id IN cipove_karty.id_cipova_karta%TYPE) RETURN t_cipove_karty PIPELINED AS
        v_cursor SYS_REFCURSOR;
        v_karta  cipove_karty%ROWTYPE;
    BEGIN
        SET TRANSACTION READ ONLY;
        OPEN v_cursor FOR
            SELECT * FROM cipove_karty WHERE id_cipova_karta=p_id;
        LOOP
            FETCH v_cursor INTO v_karta;
            EXIT WHEN v_cursor%NOTFOUND;
            PIPE ROW (v_karta);
        END LOOP;
        CLOSE v_cursor;
    END func_karty_read;

END sempr_crud;
