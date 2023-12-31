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


    TYPE t_staty IS TABLE OF staty%ROWTYPE;

    PROCEDURE proc_staty_create(p_name IN staty.nazev%TYPE);

    PROCEDURE proc_staty_update(p_id IN staty.id_stat%TYPE, p_name IN staty.nazev%TYPE);

    PROCEDURE proc_staty_delete(p_id IN staty.id_stat%TYPE);

    FUNCTION  func_staty_read RETURN t_staty PIPELINED;

    FUNCTION  func_staty_read(p_id IN staty.id_stat%TYPE) RETURN t_staty PIPELINED;

    FUNCTION  func_staty_read(p_name IN staty.nazev%TYPE) RETURN t_staty PIPELINED;


    TYPE t_obce IS TABLE OF obce%ROWTYPE;

    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE);

    PROCEDURE proc_obce_create(p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE);

    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_zip IN obce.psc%TYPE, p_country in obce.stat%TYPE);

    PROCEDURE proc_obce_update(p_id IN obce.id_obec%TYPE, p_name IN obce.nazev%TYPE, p_part IN obce.cast_obce%TYPE, p_zip IN obce.psc%TYPE, p_country IN obce.stat%TYPE);

    PROCEDURE proc_obce_delete(p_id IN obce.id_obec%TYPE);

    FUNCTION func_obce_read RETURN t_obce PIPELINED;

    FUNCTION func_obce_read(p_id IN obce.id_obec%TYPE) RETURN t_obce PIPELINED;


    TYPE t_adresy IS TABLE OF adresy%ROWTYPE;    

    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);

    PROCEDURE proc_adresy_create(p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);

    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);

    PROCEDURE proc_adresy_create(p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);

    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);

    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_street IN adresy.ulice%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);

    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_municipality IN adresy.obec%TYPE);

    PROCEDURE proc_adresy_update(p_id IN adresy.id_adresa%TYPE, p_home IN adresy.cislo_popisne%TYPE, p_orientation IN adresy.cislo_orientacni%TYPE, p_municipality IN adresy.obec%TYPE);

    PROCEDURE proc_adresy_delete(p_id IN adresy.id_adresa%TYPE);

    FUNCTION func_adresy_read RETURN t_adresy PIPELINED;

    FUNCTION func_adresy_read(p_id IN adresy.id_adresa%TYPE) RETURN t_adresy PIPELINED;


    TYPE t_osoby IS TABLE OF osoby%ROWTYPE;

    PROCEDURE proc_osoby_create(p_name IN osoby.jmeno%TYPE, p_surname IN osoby.prijmeni%TYPE, p_email IN osoby.e_mail%TYPE, p_phone IN osoby.telefon%TYPE);

    PROCEDURE proc_osoby_update(p_id IN osoby.id_osoba%TYPE, p_name IN osoby.jmeno%TYPE, p_surname IN osoby.prijmeni%TYPE, p_email IN osoby.e_mail%TYPE, p_phone IN osoby.telefon%TYPE);

    PROCEDURE proc_osoby_delete(p_id IN osoby.id_osoba%TYPE);

    FUNCTION  func_osoby_read RETURN t_osoby PIPELINED;

    FUNCTION  func_osoby_read(p_id IN osoby.id_osoba%TYPE) RETURN t_osoby PIPELINED;


    TYPE t_zamestnanci IS TABLE OF zamestnanci%ROWTYPE;

    PROCEDURE proc_zamestnanci_create(p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE);

    PROCEDURE proc_zamestnanci_create(p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE, p_superior IN zamestnanci.nadrizeny%TYPE);

    PROCEDURE proc_zamestnanci_update(p_id IN zamestnanci.id_zamestnanec%TYPE, p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE);

    PROCEDURE proc_zamestnanci_update(p_id IN zamestnanci.id_zamestnanec%TYPE, p_personal_number IN zamestnanci.osobni_cislo%TYPE, p_date IN zamestnanci.datum_nastupu%TYPE, p_residence IN zamestnanci.bydliste%TYPE, p_personal_data IN zamestnanci.osobni_udaje%TYPE, p_superior IN zamestnanci.nadrizeny%TYPE);

    PROCEDURE proc_zamestnanci_delete(p_id IN zamestnanci.id_zamestnanec%TYPE);

    FUNCTION  func_zamestnanci_read RETURN t_zamestnanci PIPELINED;

    FUNCTION  func_zamestnanci_read(p_id IN zamestnanci.id_zamestnanec%TYPE) RETURN t_zamestnanci PIPELINED;


    TYPE t_role IS TABLE OF role%ROWTYPE;

    PROCEDURE proc_role_create(p_name IN role.nazev%TYPE);

    PROCEDURE proc_role_update(p_id IN role.id_role%TYPE, p_name IN role.nazev%TYPE);

    PROCEDURE proc_role_delete(p_id IN role.id_role%TYPE);

    FUNCTION  func_role_read RETURN t_role PIPELINED;

    FUNCTION  func_role_read(p_id IN role.id_role%TYPE) RETURN t_role PIPELINED;


    TYPE t_stavy IS TABLE OF stavy%ROWTYPE;

    PROCEDURE proc_stavy_create(p_name IN stavy.nazev%TYPE, p_loginable IN stavy.prihlasitelny%TYPE);

    PROCEDURE proc_stavy_update(p_id IN stavy.id_stav%TYPE, p_name IN stavy.nazev%TYPE, p_loginable IN stavy.prihlasitelny%TYPE);

    PROCEDURE proc_stavy_delete(p_id IN stavy.id_stav%TYPE);

    FUNCTION  func_stavy_read RETURN t_stavy PIPELINED;

    FUNCTION  func_stavy_read(p_id IN stavy.id_stav%TYPE) RETURN t_stavy PIPELINED;


    TYPE t_uzivatele IS TABLE OF uzivatele%ROWTYPE;

    PROCEDURE proc_uzivatele_create(p_pwd IN uzivatele.heslo%TYPE, p_reg IN uzivatele.datum_registrace%TYPE, p_pict IN uzivatele.obrazek%TYPE, p_role IN uzivatele.role%TYPE, p_state IN uzivatele.stav%TYPE, p_empl IN uzivatele.zamestnanec%TYPE);

    PROCEDURE proc_uzivatele_update(p_id IN uzivatele.id_uzivatel%TYPE, p_pwd IN uzivatele.heslo%TYPE, p_reg IN uzivatele.datum_registrace%TYPE, p_pict IN uzivatele.obrazek%TYPE, p_role IN uzivatele.role%TYPE, p_state IN uzivatele.stav%TYPE, p_empl IN uzivatele.zamestnanec%TYPE);

    PROCEDURE proc_uzivatele_delete(p_id IN uzivatele.id_uzivatel%TYPE);

    FUNCTION  func_uzivatele_read RETURN t_uzivatele PIPELINED;

    FUNCTION  func_uzivatele_read(p_id IN uzivatele.id_uzivatel%TYPE) RETURN t_uzivatele PIPELINED;


    TYPE t_opravneni IS TABLE OF opravneni%ROWTYPE;

    PROCEDURE proc_opravneni_create(p_name IN opravneni.nazev%TYPE, p_sysname IN opravneni.systemovy_nazev%TYPE);

    PROCEDURE proc_opravneni_update(p_id IN opravneni.id_opravneni%TYPE, p_name IN opravneni.nazev%TYPE, p_sysname IN opravneni.systemovy_nazev%TYPE);

    PROCEDURE proc_opravneni_delete(p_id IN opravneni.id_opravneni%TYPE);

    FUNCTION  func_opravneni_read RETURN t_opravneni PIPELINED;

    FUNCTION  func_opravneni_read(p_id IN opravneni.id_opravneni%TYPE) RETURN t_opravneni PIPELINED;


    TYPE t_prava IS TABLE OF prava%ROWTYPE;

    PROCEDURE proc_prava_create(p_role IN prava.role%TYPE, p_perm IN prava.opravneni%TYPE);

    PROCEDURE proc_prava_delete(p_id IN prava.id_pravo%TYPE);

    FUNCTION  func_prava_read(p_role IN prava.role%TYPE) RETURN t_prava PIPELINED;



    TYPE t_linky is TABLE of linky%ROWTYPE;

    PROCEDURE proc_linky_create(p_code IN linky.kod%TYPE);

    PROCEDURE proc_linky_update(p_id IN linky.id_linka%TYPE, p_code IN linky.kod%TYPE);

    PROCEDURE proc_linky_delete(p_id IN linky.id_linka%TYPE);

    FUNCTION func_linky_read RETURN t_linky PIPELINED;

    FUNCTIOn func_linky_read(p_id IN linky.id_linka%TYPE) RETURN t_linky PIPELINED;



    TYPE t_zastavky is TABLE of zastavky%ROWTYPE;

    PROCEDURE proc_zastavky_create(p_code IN zastavky.kod%TYPE, p_name IN zastavky.nazev%TYPE);

    PROCEDURE proc_zastavky_update(p_id IN zastavky.id_zastavka%TYPE, p_name IN zastavky.nazev%TYPE, p_code IN zastavky.kod%TYPE);

    PROCEDURE proc_zastavky_delete(p_id IN zastavky.id_zastavka%TYPE);

    FUNCTION func_zastavky_read RETURN t_zastavky PIPELINED;

    FUNCTION func_zastavky_read(p_id IN zastavky.id_zastavka%TYPE) RETURN t_zastavky PIPELINED;



    TYPE t_smeny is TABLE of smeny%ROWTYPE;

    PROCEDURE proc_smeny_create(id_vozidlo IN smeny.id_vozidlo%TYPE, id_zamestnanec IN smeny.id_zamestnanec%TYPE, id_jizdni_rad IN smeny.id_jizdni_rad%TYPE);

    PROCEDURE proc_smeny_update(p_id IN smeny.id_smena%TYPE, id_vozidlo IN smeny.id_vozidlo%TYPE, id_zamestnanec IN smeny.id_zamestnanec%TYPE, id_jizdni_rad IN smeny.id_jizdni_rad%TYPE);

    PROCEDURE proc_smeny_delete(p_id IN smeny.id_smena%TYPE);

    FUNCTION func_smeny_read RETURN t_smeny PIPELINED;

    FUNCTION func_smeny_read(p_id IN smeny.id_smena%TYPE) RETURN t_smeny PIPELINED;



    TYPE t_jizdni_rady is TABLE of jizdni_rady%ROWTYPE;

    PROCEDURE proc_jizdni_rady_create(p_arrival IN jizdni_rady.cas_prijezdu%TYPE, p_departure IN jizdni_rady.cas_odjezdu%TYPE, p_nr IN jizdni_rady.poradove_cislo%TYPE, p_variant IN jizdni_rady.varianta%TYPE, p_line IN jizdni_rady.linka%TYPE, p_stop IN jizdni_rady.zastavka%TYPE);

    PROCEDURE proc_jizdni_rady_update(p_id IN jizdni_rady.id_jizdni_rad%TYPE, p_arrival IN jizdni_rady.cas_prijezdu%TYPE, p_departure IN jizdni_rady.cas_odjezdu%TYPE, p_nr IN jizdni_rady.poradove_cislo%TYPE, p_variant IN jizdni_rady.varianta%TYPE, p_line IN jizdni_rady.linka%TYPE, p_stop IN jizdni_rady.zastavka%TYPE);

    PROCEDURE proc_jizdni_rady_delete(p_id IN jizdni_rady.id_jizdni_rad%TYPE);

    FUNCTION func_jizdni_rady_read RETURN t_jizdni_rady PIPELINED;

    FUNCTION func_jizdni_rady_read(p_id IN jizdni_rady.id_jizdni_rad%TYPE) RETURN t_jizdni_rady PIPELINED;



    TYPE t_vozidla is TABLE of vozidla%ROWTYPE;

    PROCEDURE proc_vozidla_create(p_evidence_number IN vozidla.evidencni_cislo%TYPE, p_type IN vozidla.typ_vozidla%TYPE);

    PROCEDURE proc_vozidla_update(p_id IN vozidla.id_vozidlo%TYPE, p_evidence_number IN vozidla.evidencni_cislo%TYPE, p_type IN vozidla.typ_vozidla%TYPE);

    PROCEDURE proc_vozidla_delete(p_id IN vozidla.id_vozidlo%TYPE);

    FUNCTION func_vozidla_read RETURN t_vozidla PIPELINED;

    FUNCTION func_vozidla_read(p_id IN vozidla.id_vozidlo%TYPE) RETURN t_vozidla PIPELINED;



    TYPE t_logy is TABLE of logy%ROWTYPE;

    FUNCTION func_logy_read RETURN t_logy PIPELINED;

    FUNCTION func_logy_read(p_id IN logy.id_log%TYPE) RETURN t_logy PIPELINED;

    TYPE t_obrazky is TABLE of obrazky%ROWTYPE;
    
    PROCEDURE proc_obrazky_create(p_content IN obrazky.obsah%TYPE, p_hash IN obrazky.hash%TYPE, p_name IN obrazky.nazev%TYPE, p_date IN obrazky.datum_nahrani%TYPE);
    
    PROCEDURE proc_obrazky_delete(p_id in obrazky.id_obrazek%TYPE);
    
    FUNCTION func_obrazky_read RETURN t_obrazky PIPELINED;

    FUNCTION func_obrazky_read(p_id IN obrazky.id_obrazek%TYPE) RETURN t_obrazky PIPELINED;

END sempr_crud;

