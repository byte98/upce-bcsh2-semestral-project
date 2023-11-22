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

END sempr_utils;
