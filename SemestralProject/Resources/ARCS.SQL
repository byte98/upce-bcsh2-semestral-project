CREATE OR REPLACE TRIGGER arc_vozidla_arc_trolejbusy BEFORE
    INSERT OR UPDATE OF id_vozidlo ON trolejbusy
    FOR EACH ROW
DECLARE
    d CHAR(3);
BEGIN
    SELECT
        a.typ_vozidla
    INTO d
    FROM
        vozidla a
    WHERE
        a.id_vozidlo = :new.id_vozidlo;

    IF ( d IS NULL OR d <> 'TRO' ) THEN
        raise_application_error(-20223, 'FK TROLEJBUS_VOZIDLO_FK in Table TROLEJBUSY violates Arc constraint on Table VOZIDLA - discriminator column typ_vozidla doesn''t have value ''TRO'''
        );
    END IF;

EXCEPTION
    WHEN no_data_found THEN
        NULL;
    WHEN OTHERS THEN
        RAISE;
END;
--
CREATE OR REPLACE TRIGGER arc_vozidla_arc_autobusy BEFORE
    INSERT OR UPDATE OF id_vozidlo ON autobusy
    FOR EACH ROW
DECLARE
    d CHAR(3);
BEGIN
    SELECT
        a.typ_vozidla
    INTO d
    FROM
        vozidla a
    WHERE
        a.id_vozidlo = :new.id_vozidlo;

    IF ( d IS NULL OR d <> 'AUT' ) THEN
        raise_application_error(-20223, 'FK AUTOBUS_VOZIDLO_FK in Table AUTOBUSY violates Arc constraint on Table VOZIDLA - discriminator column typ_vozidla doesn''t have value ''AUT'''
        );
    END IF;

EXCEPTION
    WHEN no_data_found THEN
        NULL;
    WHEN OTHERS THEN
        RAISE;
END;
--
CREATE OR REPLACE TRIGGER arc_vozidla_arc_tramvaje BEFORE
    INSERT OR UPDATE OF id_vozidlo ON tramvaje
    FOR EACH ROW
DECLARE
    d CHAR(3);
BEGIN
    SELECT
        a.typ_vozidla
    INTO d
    FROM
        vozidla a
    WHERE
        a.id_vozidlo = :new.id_vozidlo;

    IF ( d IS NULL OR d <> 'TRA' ) THEN
        raise_application_error(-20223, 'FK TRAMVAJ_VOZIDLO_FK in Table TRAMVAJE violates Arc constraint on Table VOZIDLA - discriminator column typ_vozidla doesn''t have value ''TRA'''
        );
    END IF;

EXCEPTION
    WHEN no_data_found THEN
        NULL;
    WHEN OTHERS THEN
        RAISE;
END;
--
CREATE OR REPLACE TRIGGER arc_vozidla_arc_soupravy_metra BEFORE
    INSERT OR UPDATE OF id_vozidlo ON soupravy_metra
    FOR EACH ROW
DECLARE
    d CHAR(3);
BEGIN
    SELECT
        a.typ_vozidla
    INTO d
    FROM
        vozidla a
    WHERE
        a.id_vozidlo = :new.id_vozidlo;

    IF ( d IS NULL OR d <> 'MET' ) THEN
        raise_application_error(-20223, 'FK METRO_VOZIDLO_FK in Table SOUPRAVY_METRA violates Arc constraint on Table VOZIDLA - discriminator column typ_vozidla doesn''t have value ''MET'''
        );
    END IF;

EXCEPTION
    WHEN no_data_found THEN
        NULL;
    WHEN OTHERS THEN
        RAISE;
END;
