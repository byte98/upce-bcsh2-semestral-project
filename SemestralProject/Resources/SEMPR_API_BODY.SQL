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
        v_user uzivatele%ROWTYPE;
        v_old logy.zprava%TYPE := '[';
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
--
    PROCEDURE proc_users_logout(p_id IN uzivatele.id_uzivatel%TYPE) AS
        v_user uzivatele%ROWTYPE;
        v_old logy.zprava%TYPE := '[';
    BEGIN
        SET TRANSACTION READ WRITE;
        SELECT * INTO v_user FROM uzivatele WHERE id_uzivatel=p_id;
        v_old := CONCAT(v_old, 'ID_UZIVATEL: ' || v_user.ID_UZIVATEL || '; ');
            v_old := CONCAT(v_old, 'HESLO: ' || v_user.HESLO || '; ');
            v_old := CONCAT(v_old, 'DATUM_REGISTRACE: ' || v_user.DATUM_REGISTRACE || '; ');
            v_old := CONCAT(v_old, 'OBRAZEK: ' || v_user.OBRAZEK || '; ');
            v_old := CONCAT(v_old, 'ROLE: ' || v_user.ROLE || '; ');
            v_old := CONCAT(v_old, 'STAV: ' || v_user.STAV || '; ');
            v_old := CONCAT(v_old, 'ZAMESTNANEC: ' || v_user.ZAMESTNANEC || '; ');
            v_old := CONCAT(v_old, ']');
            sempr_api.proc_log('logout', 'UZIVATELE', 1, v_old, '');
        COMMIT;
    END proc_users_logout;
--
    PROCEDURE proc_log(p_operation IN logy.operace%TYPE, p_table IN logy.tabulka%TYPE, p_rows IN logy.pocet_radku%TYPE, p_old_json IN logy.zprava%TYPE, p_new_json IN logy.zprava%TYPE) AS
        v_message logy.zprava%TYPE;
    BEGIN
        v_message := '';
        IF p_operation LIKE 'insert' THEN
            v_message := 'Vlozena nova data do tabulky ' || p_table || '(' || p_new_json || ')';
        ELSIF p_operation LIKE 'update' THEN
            v_message := 'Upravena data v tabulce ' || p_table || '(' || p_old_json || ' -> ' || p_new_json || ')';
        ELSIF p_operation LIKE 'delete' THEN
            v_message := 'Smazano ' || p_rows || ' zaznamu z tabulky ' || p_table || '(' || p_old_json || ')';
        ELSIF p_operation LIKE 'login' THEN
            v_message := 'Prihlasen uzivatel ' || p_old_json;
        ELSIF p_operation LIKE 'logout' THEN
            v_message := 'Odhlasen uzivatel' || p_old_json;
        END IF;
        INSERT
        INTO logy(operace, tabulka, pocet_radku, zprava)
        VALUES (p_operation, p_table, p_rows, v_message);
    END proc_log;
END sempr_api;
