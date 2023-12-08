

CREATE OR REPLACE TRIGGER log_trigger_adresy
AFTER DELETE OR UPDATE OR ALTER ON adresy
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('adresy', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_jizdni_rady
AFTER DELETE OR UPDATE OR ALTER ON jizdni_rady
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('jizdni_rady', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_linky
AFTER DELETE OR UPDATE OR ALTER ON linky
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('linky', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_logs
AFTER DELETE OR UPDATE OR ALTER ON logs
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('logs', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_obce
AFTER DELETE OR UPDATE OR ALTER ON obce
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('obce', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_opravneni
AFTER DELETE OR UPDATE OR ALTER ON opravneni
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('opravneni', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END;
/
CREATE OR REPLACE TRIGGER log_trigger_osoby
AFTER DELETE OR UPDATE OR ALTER ON osoby
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('osoby', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_plany_smen
AFTER DELETE OR UPDATE OR ALTER ON plany_smen
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('plany_smen', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END;
/
CREATE OR REPLACE TRIGGER log_trigger_prava
AFTER DELETE OR UPDATE OR ALTER ON prava
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('prava', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END;
/
CREATE OR REPLACE TRIGGER log_trigger_role
AFTER DELETE OR UPDATE OR ALTER ON role
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('role', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_skutecne_rady
AFTER DELETE OR UPDATE OR ALTER ON skutecne_rady
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('skutecne_rady', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END;
/
CREATE OR REPLACE TRIGGER log_trigger_smeny
AFTER DELETE OR UPDATE OR ALTER ON smeny
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('smeny', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END;
/
CREATE OR REPLACE TRIGGER log_trigger_staty
AFTER DELETE OR UPDATE OR ALTER ON staty
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('staty', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END;
/
CREATE OR REPLACE TRIGGER log_trigger_stavy
AFTER DELETE OR UPDATE OR ALTER ON stavy
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('stavy', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_uzivatele
AFTER DELETE OR UPDATE OR ALTER ON uzivatele
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('uzivatele', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_zamestnanci
AFTER DELETE OR UPDATE OR ALTER ON zamestnanci
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('zamestnanci', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
/
CREATE OR REPLACE TRIGGER log_trigger_zastavky
AFTER DELETE OR UPDATE OR ALTER ON zastavky
FOR EACH ROW
DECLARE
    v_action VARCHAR2(10);
BEGIN
    IF DELETING THEN v_action := 'DELETE';
    ELSIF UPDATING THEN v_action := 'UPDATE';
    ELSE v_action := 'ALTER';
    END IF;
    INSERT INTO logs (table_name, message)
    VALUES ('zastavky', 'Action: ' || v_action || ', Row ID: ' || :OLD.id);
END; 
