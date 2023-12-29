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
    FUNCTION func_mask_email(p_email IN osoby.e_mail%TYPE) RETURN VARCHAR2 AS
    email_masked VARCHAR2(256);
    username VARCHAR2(256);
    domain VARCHAR2(256);
    pos_at PLS_INTEGER;
    masked_username VARCHAR2(256);
    BEGIN
        pos_at := INSTR(p_email, '@');
        
        IF pos_at > 0 THEN
            username := SUBSTR(p_email, 1, pos_at - 1);
            domain := SUBSTR(p_email, pos_at);
            
            IF LENGTH(username) > 3 THEN
                masked_username := SUBSTR(username, 1, 1) || '***' || SUBSTR(username, LENGTH(username) - 1);
            ELSE
                masked_username := SUBSTR(username, 1, 1) || '***';
            END IF;
            
            email_masked := masked_username || domain;
        ELSE
            email_masked := p_email;
        END IF;
    
        RETURN email_masked;
    END func_mask_email;
--
    FUNCTION func_mask_phone(p_phone IN osoby.telefon%TYPE) RETURN VARCHAR2 AS
    masked_output VARCHAR2(100);
    visible_part VARCHAR2(100);
    masked_part VARCHAR2(100);
BEGIN
    IF LENGTH(p_phone) > 8 THEN
        visible_part := SUBSTR(p_phone, 1, 8);
        masked_part := RPAD('*', LENGTH(p_phone) - 8, '*');
        masked_output := visible_part || masked_part;
    ELSE
        masked_output := p_phone;
    END IF;

    RETURN masked_output;
    
END func_mask_phone;

END sempr_utils;
