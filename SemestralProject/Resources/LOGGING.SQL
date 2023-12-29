DECLARE
    v_table_name VARCHAR2(128);
    v_sql CLOB;
BEGIN
    FOR tbl IN (SELECT table_name FROM user_tables WHERE table_name <> 'LOGY') LOOP
        v_table_name := tbl.table_name;
        v_sql := 
'CREATE OR REPLACE TRIGGER trg_' || v_table_name || '
    BEFORE DELETE OR INSERT OR UPDATE ON ' || v_table_name ||'
    FOR EACH ROW
    DECLARE
        v_old  logy.zprava%TYPE := ''['';
        v_new  logy.zprava%TYPE := ''['';
        v_op   logy.operace%TYPE;
        v_rows logy.pocet_radku%TYPE := 0;
        v_tab  logy.tabulka%TYPE;
    BEGIN
        v_tab := ''' || v_table_name || ''';
        IF SQL%ROWCOUNT IS NULL THEN
            v_rows := 1;
        ELSE
            v_rows := SQL%ROWCOUNT;
        END IF;
        IF DELETING THEN
            v_op := ''delete'';
        ';
        v_sql := CONCAT(v_sql, '    ');
        FOR col IN (SELECT column_name FROM user_tab_columns WHERE table_name=v_table_name)
        LOOP
            v_sql := CONCAT(v_sql, 'v_old := CONCAT(v_old, ''' || col.column_name ||': '' || :OLD.' || col.column_name || ' || ''; '');
            ');
        END LOOP;
        v_sql := CONCAT(v_sql, 'v_old := CONCAT(v_old, '']'');');
        v_sql := CONCAT(v_sql,'
        ELSIF UPDATING THEN
            v_op := ''update'';
            ');
        FOR col IN (SELECT column_name FROM user_tab_columns WHERE table_name=v_table_name)
        LOOP
            v_sql := CONCAT(v_sql, 'v_old := CONCAT(v_old, ''' || col.column_name ||': '' || :OLD.' || col.column_name || ' || ''; '');
            ');
        END LOOP;
        v_sql := CONCAT(v_sql, 'v_old := CONCAT(v_old, '']'');');
        v_sql := CONCAT(v_sql,'
            
            ');
        FOR col IN (SELECT column_name FROM user_tab_columns WHERE table_name=v_table_name)
        LOOP
            v_sql := CONCAT(v_sql, 'v_new := CONCAT(v_new, ''' || col.column_name ||': '' || :NEW.' || col.column_name || ' || ''; '');
            ');
        END LOOP;
        v_sql := CONCAT(v_sql, 'v_new := CONCAT(v_new, '']'');');
        v_sql := CONCAT(v_sql,'
        ELSIF INSERTING THEN
            v_rows := 1;
            v_op := ''insert'';
            ');
        FOR col IN (SELECT column_name FROM user_tab_columns WHERE table_name=v_table_name)
        LOOP
            v_sql := CONCAT(v_sql, 'v_new := CONCAT(v_new, ''' || col.column_name ||': '' || :NEW.' || col.column_name || ' || ''; '');
            ');
        END LOOP;
        v_sql := CONCAT(v_sql, 'v_new := CONCAT(v_new, '']'');');
        v_sql := CONCAT(v_sql,'
        END IF;
        sempr_api.proc_log(v_op, v_tab, v_rows, v_old, v_new);
    END;
');
    EXECUTE IMMEDIATE v_sql;
    END LOOP;
END;
