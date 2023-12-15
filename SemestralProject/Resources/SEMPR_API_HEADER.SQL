CREATE OR REPLACE
/*
 * Package with some API functions.
 * :author: David Schwam <david.schwam@student.upce.cz>
 *          Jiri Skoda <jiri.skoda@student.upce.cz>
 */
PACKAGE sempr_api AS

--
    FUNCTION func_users_login(p_personal_nr IN zamestnanci.osobni_cislo%TYPE, p_password IN uzivatele.heslo%TYPE) RETURN uzivatele.id_uzivatel%TYPE;
--
    PROCEDURE proc_users_logout(p_id IN uzivatele.id_uzivatel%TYPE);
--
    PROCEDURE proc_log(p_operation IN logy.operace%TYPE, p_table IN logy.tabulka%TYPE, p_rows IN logy.pocet_radku%TYPE, p_old_json IN logy.zprava%TYPE, p_new_json IN logy.zprava%TYPE);
--
    PROCEDURE proc_obrazky_delete_unused;
END sempr_api;
