ALTER TABLE adresy
    ADD CONSTRAINT adresy_obce_fk FOREIGN KEY ( obec )
        REFERENCES obce ( id_obec )

ALTER TABLE jizdni_rady
    ADD CONSTRAINT jizdni_rady_linky_fk FOREIGN KEY ( linka )
        REFERENCES linky ( id_linka )

ALTER TABLE jizdni_rady
    ADD CONSTRAINT jizdni_rady_zastavka_fk FOREIGN KEY ( zastavka )
        REFERENCES zastavky ( id_zastavka )

ALTER TABLE obce
    ADD CONSTRAINT obce_stat_fk FOREIGN KEY ( stat )
        REFERENCES staty ( id_stat )

ALTER TABLE prava
    ADD CONSTRAINT prava_opravneni_fk FOREIGN KEY ( opravneni )
        REFERENCES opravneni ( id_opravneni )

ALTER TABLE prava
    ADD CONSTRAINT prava_role_fk FOREIGN KEY ( role )
        REFERENCES role ( id_role )

ALTER TABLE skutecne_rady
    ADD CONSTRAINT skutecne_rady_plany_smen_fk FOREIGN KEY ( plan )
        REFERENCES plany_smen ( id_plan_smeny )

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatel_role_fk FOREIGN KEY ( role )
        REFERENCES role ( id_role )

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatel_stav_fk FOREIGN KEY ( stav )
        REFERENCES stavy ( id_stav )

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatel_zamestnanec_fk FOREIGN KEY ( zamestnanec )
        REFERENCES zamestnanci ( id_zamestnanec )

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanci_zamestnanci_fk FOREIGN KEY ( nadrizeny )
        REFERENCES zamestnanci ( id_zamestnanec )

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanec_adresa_fk FOREIGN KEY ( bydliste )
        REFERENCES adresy ( id_adresa )

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanec_osoby_fk FOREIGN KEY ( osobni_udaje )
        REFERENCES osoby ( id_osoba )
