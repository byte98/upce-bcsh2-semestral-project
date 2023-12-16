CREATE OR REPLACE

/*
 * Package with some usefull utility functions.
 *
 * :author: David Schwam <david.schwam@student.upce.cz>
 *          Jiri Skoda <jiri.skoda@student.upce.cz>
 */
PACKAGE sempr_utils AS
--
    FUNCTION func_last_seq(p_seq VARCHAR2) RETURN NUMBER;
--
    FUNCTION func_next_seq(p_seq VARCHAR2) RETURN NUMBER;
--
    FUNCTION func_mask_email(p_email IN osoby.e_mail%TYPE) RETURN VARCHAR2;
--
    FUNCTION func_mask_phone(p_phone IN osoby.telefon%TYPE) RETURN VARCHAR2;
END sempr_utils;
