CREATE OR REPLACE TRIGGER trg_delete_images
    AFTER UPDATE ON uzivatele
    FOR EACH ROW
    DECLARE 
        v_count NUMBER := 0;
    BEGIN
        SELECT COUNT(*) INTO v_count
        FROM obrazky o
        LEFT JOIN uzivatele u ON o.id_obrazek=u.obrazek
        WHERE u.id_uzivatel IS NULL;
        IF v_count > 0 THEN
            sempr_api.proc_obrazky_delete_unused();
        END IF;
    END


