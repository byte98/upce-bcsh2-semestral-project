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

END sempr_utils;
