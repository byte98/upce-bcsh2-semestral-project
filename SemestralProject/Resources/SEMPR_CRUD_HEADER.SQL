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
--
    TYPE t_staty IS TABLE OF staty%ROWTYPE;
--
    PROCEDURE proc_staty_create(p_name IN staty.nazev%TYPE);
--
    PROCEDURE proc_staty_update(p_id IN staty.id_stat%TYPE, p_name IN staty.nazev%TYPE);
--
    PROCEDURE proc_staty_delete(p_id IN staty.id_stat%TYPE);
--
    FUNCTION  func_staty_read RETURN t_staty PIPELINED;
--
    FUNCTION  func_staty_read(p_id IN staty.id_stat%TYPE) RETURN t_staty PIPELINED;
--
    FUNCTION  func_staty_read(p_name IN staty.nazev%TYPE) RETURN t_staty PIPELINED;
--
    TYPE t_obce IS TABLE OF obce%ROWTYPE;
--
    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE);
--
    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE);
--
    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE);
--
    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country IN obce.stat%TYPE);
--
    PROCEDURE proc_obce_delete(p_id IN obce.id_obec%TYPE);
--
    FUNCTION func_obce_read RETURN t_obce PIPELINED;
--
    FUNCTION func_obce_read(p_id IN obce.id_obec%TYPE) RETURN t_obce PIPELINED;
--
    TYPE t_adresy IS TABLE OF adresy%ROWTYPE;    
--
    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);
--
    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);
--
    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);
--
    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);
--
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);
--
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);
--
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);
--
    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);
--
    PROCEDURE proc_adresy_delete(p_id IN adresy.id_adresa%TYPE);
--
    FUNCTION func_adresy_read RETURN t_adresy PIPELINED;
--
    FUNCTION func_adresy_read(p_id IN adresy.id_adresa%TYPE) RETURN t_adresy PIPELINED;
--
    TYPE t_osoby IS TABLE OF osoby%ROWTYPE;
--
    PROCEDURE proc_osoby_create(p_name IN osoby.jmeno%TYPE, p_surname IN osoby.prijmeni%TYPE, p_email IN osoby.e_mail%TYPE, p_phone IN osoby.telefon%TYPE);
--
    PROCEDURE proc_osoby_update(p_id IN osoby.id_osoba%TYPE, p_name IN osoby.jmeno%TYPE, p_surname IN osoby.prijmeni%TYPE, p_email IN osoby.e_mail%TYPE, p_phone IN osoby.telefon%TYPE);
--
    PROCEDURE proc_osoby_delete(p_id IN osoby.id_osoba%TYPE);
--
    FUNCTION  func_osoby_read RETURN t_osoby PIPELINED;
--
    FUNCTION  func_osoby_read(p_id IN osoby.id_osoba%TYPE) RETURN t_osoby PIPELINED;
--
    TYPE t_zamestnanci IS TABLE OF zamestnanci%ROWTYPE;
--
    PROCEDURE proc_zamestnanci_create(p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE);
--
    PROCEDURE proc_zamestnanci_create(p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE, p_superior IN zamestnanci.nadrizeny%TYPE);
--
    PROCEDURE proc_zamestnanci_update(p_id IN zamestnanci.id_zamestnanec%TYPE, p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE);
--
    PROCEDURE proc_zamestnanci_update(p_id IN zamestnanci.id_zamestnanec%TYPE, p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE, p_superior IN zamestnanci.nadrizeny%TYPE);
--
    PROCEDURE proc_zamestnanci_delete(p_id IN zamestnanci.id_zamestnanec%TYPE);
--
    FUNCTION  func_zamestnanci_read RETURN t_zamestnanci PIPELINED;
--
    FUNCTION  func_zamestnanci_read(p_id IN zamestnanci.id_zamestnanec%TYPE) RETURN t_zamestnanci PIPELINED;
--
    TYPE t_role IS TABLE OF role%ROWTYPE;
--
    PROCEDURE proc_role_create(p_name IN role.nazev%TYPE);
--
    PROCEDURE proc_role_update(p_id IN role.id_role%TYPE, p_name IN role.nazev%TYPE);
--
    PROCEDURE proc_role_delete(p_id IN role.id_role%TYPE);
--
    FUNCTION  func_role_read RETURN t_role PIPELINED;
--
    FUNCTION  func_role_read(p_id IN role.id_role%TYPE) RETURN t_role PIPELINED;
--
    TYPE t_stavy IS TABLE OF stavy%ROWTYPE;
--
    PROCEDURE proc_stavy_create(p_name IN stavy.nazev%TYPE);
--
    PROCEDURE proc_stavy_update(p_id IN stavy.id_stav%TYPE, p_name IN stavy.nazev%TYPE);
--
    PROCEDURE proc_stavy_delete(p_id IN stavy.id_stav%TYPE);
--
    FUNCTION  func_stavy_read RETURN t_stavy PIPELINED;
--
    FUNCTION  func_stavy_read(p_id IN stavy.id_stav%TYPE) RETURN t_stavy PIPELINED;
--
    TYPE t_uzivatele IS TABLE OF uzivatele%ROWTYPE;
--
    PROCEDURE proc_uzivatele_create(p_pwd IN uzivatele.heslo%TYPE, p_reg IN uzivatele.datum_registrace%TYPE, p_pict IN uzivatele.obrazek%TYPE, p_role IN uzivatele.role%TYPE, p_state IN uzivatele.stav%TYPE, p_empl IN uzivatele.zamestnanec%TYPE);
--
    PROCEDURE proc_uzivatele_update(p_id IN uzivatele.id_uzivatel%TYPE, p_pwd IN uzivatele.heslo%TYPE, p_reg IN uzivatele.datum_registrace%TYPE, p_pict IN uzivatele.obrazek%TYPE, p_role IN uzivatele.role%TYPE, p_state IN uzivatele.stav%TYPE, p_empl IN uzivatele.zamestnanec%TYPE);
--
    PROCEDURE proc_uzivatele_delete(p_id IN uzivatele.id_uzivatel%TYPE);
--
    FUNCTION  func_uzivatele_read RETURN t_uzivatele PIPELINED;
--
    FUNCTION  func_uzivatele_read(p_id IN uzivatele.id_uzivatel%TYPE) RETURN t_uzivatele PIPELINED;
--
END sempr_crud;
