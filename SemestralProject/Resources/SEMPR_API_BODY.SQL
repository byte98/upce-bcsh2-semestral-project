CREATE OR REPLACE
/*
 * Body of package with some API functions.
 * :author: David Schwam <david.schwam@student.upce.cz>
 *          Jiri Skoda <jiri.skoda@student.upce.cz>
 */
PACKAGE BODY sempr_api AS

--
    FUNCTION func_users_login(p_personal_nr IN zamestnanci.osobni_cislo%TYPE, p_password IN uzivatele.heslo%TYPE) RETURN uzivatele.id_uzivatel%TYPE AS
        v_reti uzivatele.id_uzivatel%TYPE      := -2147483648;
    BEGIN
        SELECT id_uzivatel INTO v_reti
        FROM uzivatele
        WHERE heslo=p_password
            AND zamestnanec IN (
                SELECT id_zamestnanec
                FROM zamestnanci
                WHERE osobni_cislo=p_personal_nr
            );
        RETURN v_reti;
    END func_users_login;

END sempr_api;
