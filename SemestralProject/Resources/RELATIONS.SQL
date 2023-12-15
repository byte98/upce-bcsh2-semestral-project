ALTER TABLE adresy
    ADD CONSTRAINT adresy_obce_fk FOREIGN KEY ( obec )
        REFERENCES obce ( id_obec )
        ON DELETE CASCADE

ALTER TABLE jizdni_rady
    ADD CONSTRAINT jizdni_rady_linky_fk FOREIGN KEY ( linka )
        REFERENCES linky ( id_linka )
        ON DELETE CASCADE

ALTER TABLE jizdni_rady
    ADD CONSTRAINT jizdni_rady_zastavka_fk FOREIGN KEY ( zastavka )
        REFERENCES zastavky ( id_zastavka )
        ON DELETE CASCADE

ALTER TABLE obce
    ADD CONSTRAINT obce_stat_fk FOREIGN KEY ( stat )
        REFERENCES staty ( id_stat )
        ON DELETE CASCADE

ALTER TABLE prava
    ADD CONSTRAINT prava_opravneni_fk FOREIGN KEY ( opravneni )
        REFERENCES opravneni ( id_opravneni )
        ON DELETE CASCADE

ALTER TABLE prava
    ADD CONSTRAINT prava_role_fk FOREIGN KEY ( role )
        REFERENCES role ( id_role )
        ON DELETE CASCADE

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatel_role_fk FOREIGN KEY ( role )
        REFERENCES role ( id_role )
        ON DELETE CASCADE

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatel_stav_fk FOREIGN KEY ( stav )
        REFERENCES stavy ( id_stav )
        ON DELETE CASCADE

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatel_zamestnanec_fk FOREIGN KEY ( zamestnanec )
        REFERENCES zamestnanci ( id_zamestnanec )
        ON DELETE CASCADE

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatele_obrazky_fk FOREIGN KEY ( obrazek )
        REFERENCES obrazky ( id_obrazek )
        ON DELETE CASCADE

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanci_zamestnanci_fk FOREIGN KEY ( nadrizeny )
        REFERENCES zamestnanci ( id_zamestnanec )
        ON DELETE CASCADE

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanec_adresa_fk FOREIGN KEY ( bydliste )
        REFERENCES adresy ( id_adresa )
        ON DELETE CASCADE

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanec_osoby_fk FOREIGN KEY ( osobni_udaje )
        REFERENCES osoby ( id_osoba )
        ON DELETE CASCADE
