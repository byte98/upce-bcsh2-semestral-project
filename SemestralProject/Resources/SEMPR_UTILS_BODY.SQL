CREATE OR REPLACE
/*
 * Body of package with utility functions.
 *
 * :author: David Schwam <david.schwam@student.upce.cz>
 *          Jiri Skoda <jiri.skoda@student.upce.cz>
 */
PACKAGE BODY sempr_utils AS

--
    FUNCTION func_last_seq(p_seq VARCHAR2) RETURN NUMBER AS
        v_reti NUMBER := -2147483648;
        v_sequence_exists NUMBER;
        sequence_not_found EXCEPTION;
        PRAGMA EXCEPTION_INIT(sequence_not_found, -10000);
    BEGIN
        SELECT COUNT(*)
        INTO v_sequence_exists
        FROM all_sequences
        WHERE sequence_name=p_seq;
        IF v_sequence_exists = 0 THEN
            RAISE sequence_not_found;
            RETURN v_reti;
        END IF;
        EXECUTE IMMEDIATE 'SELECT ' || p_seq || '.CURRVAL FROM DUAL' INTO v_reti;
        RETURN v_reti;
    EXCEPTION
        WHEN OTHERS THEN
            RETURN v_reti;
    END func_last_seq;
--
    FUNCTION get_employee_hierarchy(p_employee_id IN INTEGER) RETURN SYS_REFCURSOR IS
        v_cursor SYS_REFCURSOR;
    BEGIN
        OPEN v_cursor FOR
        SELECT id_zamestnanec,
                CONNECT_BY_ROOT id_zamestnanec AS root_id,
                LEVEL AS hierarchy_level
        FROM zamestnanci
        CONNECT BY PRIOR id_zamestnanec = nadrizeny
        START WITH id_zamestnanec = p_employee_id;
        
        RETURN v_cursor;
    END get_employee_hierarchy;
--
    FUNCTION get_top_managers(p_employee_id IN INTEGER) RETURN SYS_REFCURSOR 
        IS v_result SYS_REFCURSOR;
    BEGIN
        OPEN v_result FOR
        SELECT id_zamestnanec,
            CONNECT_BY_ROOT id_zamestnanec AS root_id,
            LEVEL AS hierarchy_level
        FROM zamestnanci
        WHERE CONNECT_BY_ISLEAF = 1
        CONNECT BY PRIOR id_zamestnanec = nadrizeny
        START WITH nadrizeny IS NULL AND id_zamestnanec = p_employee_id;
    RETURN v_result;
    END get_top_managers;
--
    FUNCTION func_next_seq(p_seq VARCHAR2) RETURN NUMBER AS
        v_reti NUMBER := -2147483648;
        v_sequence_exists NUMBER;
        sequence_not_found EXCEPTION;
        PRAGMA EXCEPTION_INIT(sequence_not_found, -10000);
    BEGIN
        SELECT COUNT(*)
        INTO v_sequence_exists
        FROM all_sequences
        WHERE sequence_name=p_seq;
        IF v_sequence_exists = 0 THEN
            RAISE sequence_not_found;
            RETURN v_reti;
        END IF;
        EXECUTE IMMEDIATE 'SELECT ' || p_seq || '.NEXTVAL FROM DUAL' INTO v_reti;
        RETURN v_reti;
    EXCEPTION
        WHEN OTHERS THEN
            RETURN v_reti;
    END func_next_seq;

END sempr_utils;
