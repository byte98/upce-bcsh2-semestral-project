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
        v_loggable stavy.prihlasitelny%TYPE    := 1;
    BEGIN
        FOR user_rec IN (
            SELECT * 
            FROM uzivatele u
            JOIN zamestnanci z ON u.zamestnanec = z.id_zamestnanec
            WHERE u.heslo=p_password
            AND z.osobni_cislo=p_personal_nr
        )
        LOOP
            v_reti := user_rec.id_uzivatel;
            EXIT;
        END LOOP;
        FOR state_rec IN (
            SELECT *
            FROM stavy s
            JOIN uzivatele u ON u.stav = s.id_stav
        )
        LOOP
            v_loggable := state_rec.prihlasitelny;
            EXIT;
        END LOOP;
        IF v_loggable = 1 THEN
            v_reti := -2147483648;
        END IF;
        RETURN v_reti;
    END func_users_login;

END sempr_api;
