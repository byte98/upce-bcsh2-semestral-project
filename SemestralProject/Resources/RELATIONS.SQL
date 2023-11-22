ALTER TABLE adresy
    ADD CONSTRAINT adresy_obce_fk FOREIGN KEY ( obec )
    REFERENCES obce ( id_obec )

ALTER TABLE autobusy
    ADD CONSTRAINT autobus_prevodovka_fk FOREIGN KEY(prevodovka )
    REFERENCES prevodovky(id_prevodovka )

ALTER TABLE autobusy
    ADD CONSTRAINT autobus_vozidlo_fk FOREIGN KEY(id_vozidlo )
    REFERENCES vozidla(id_vozidlo )
    ON DELETE CASCADE

ALTER TABLE cipove_karty
    ADD CONSTRAINT cipove_karty_zamestnanec_fk FOREIGN KEY(drzitel )
    REFERENCES zamestnanci(id_zamestnanec )

ALTER TABLE jizdni_rady
    ADD CONSTRAINT jizdni_rady_linky_fk FOREIGN KEY(linka )
    REFERENCES linky(id_linka )

ALTER TABLE jizdni_rady
    ADD CONSTRAINT jizdni_rady_zastavka_fk FOREIGN KEY(zastavka )
    REFERENCES zastavky(id_zastavka )

ALTER TABLE soupravy_metra
    ADD CONSTRAINT metro_vozidlo_fk FOREIGN KEY(id_vozidlo )
    REFERENCES vozidla(id_vozidlo )
    ON DELETE CASCADE

ALTER TABLE soupravy_metra
    ADD CONSTRAINT metro_zabezpecovac_fk FOREIGN KEY(zabezpecovac )
    REFERENCES zabezpecovace(id_zabezpecovac )

ALTER TABLE modely
    ADD CONSTRAINT modely_vyrobce_fk FOREIGN KEY(vyrobce )
    REFERENCES vyrobci(id_vyrobce )

ALTER TABLE obce
    ADD CONSTRAINT obce_stat_fk FOREIGN KEY(stat )
    REFERENCES staty(id_stat )

ALTER TABLE provozy
    ADD CONSTRAINT provoz_adresy_fk FOREIGN KEY(sidlo )
    REFERENCES adresy(id_adresa )

ALTER TABLE provozy
    ADD CONSTRAINT provozy_zamestnanec_fk FOREIGN KEY(vedouci )
    REFERENCES zamestnanci(id_zamestnanec )

ALTER TABLE plany_smen
    ADD CONSTRAINT rel_smena_jizdni_rad_jizdni_rad_fk FOREIGN KEY(jizdni_rad )
    REFERENCES jizdni_rady(id_jizdni_rad )

ALTER TABLE plany_smen
    ADD CONSTRAINT rel_smena_jizdni_rad_smena_fk FOREIGN KEY(smena )
    REFERENCES smeny(id_smena )

ALTER TABLE skutecne_rady
    ADD CONSTRAINT skutecne_rady_plany_smen_fk FOREIGN KEY(plan )
    REFERENCES plany_smen(id_plan_smeny )

ALTER TABLE smeny
    ADD CONSTRAINT smena_vozidlo_fk FOREIGN KEY(vozidlo )
    REFERENCES vozidla(id_vozidlo )

ALTER TABLE smeny
    ADD CONSTRAINT smeny_zamestnanec_fk FOREIGN KEY(zamestnanec )
    REFERENCES zamestnanci(id_zamestnanec )

ALTER TABLE tramvaje
    ADD CONSTRAINT tramvaj_vozidlo_fk FOREIGN KEY(id_vozidlo )
    REFERENCES vozidla(id_vozidlo )
    ON DELETE CASCADE

ALTER TABLE trolejbusy
    ADD CONSTRAINT trolejbus_vozidlo_fk FOREIGN KEY(id_vozidlo )
    REFERENCES vozidla(id_vozidlo )
            ON DELETE CASCADE

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatel_role_fk FOREIGN KEY(role )
    REFERENCES role(id_role )

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatel_stav_fk FOREIGN KEY(stav )
    REFERENCES stavy(id_stav )

ALTER TABLE uzivatele
    ADD CONSTRAINT uzivatel_zamestnanec_fk FOREIGN KEY(zamestnanec )
    REFERENCES zamestnanci(id_zamestnanec )

ALTER TABLE vozidla
    ADD CONSTRAINT vozidlo_model_fk FOREIGN KEY(model )
    REFERENCES modely(id_model )

ALTER TABLE vozidla
    ADD CONSTRAINT vozidlo_provoz_fk FOREIGN KEY(deponace )
    REFERENCES provozy(id_provoz )

ALTER TABLE vyrobci
    ADD CONSTRAINT vyrobce_adresy_fk FOREIGN KEY(sidlo )
    REFERENCES adresy(id_adresa )

ALTER TABLE vyrobci
    ADD CONSTRAINT vyrobce_osoba_fk FOREIGN KEY(kontakt )
    REFERENCES osoby(id_osoba )

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanci_zamestnanci_fk FOREIGN KEY(nadrizeny )
    REFERENCES zamestnanci(id_zamestnanec )

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanec_adresa_fk FOREIGN KEY(bydliste )
    REFERENCES adresy(id_adresa )

ALTER TABLE zamestnanci
    ADD CONSTRAINT zamestnanec_osoby_fk FOREIGN KEY(osobni_udaje )
    REFERENCES osoby(id_osoba )
