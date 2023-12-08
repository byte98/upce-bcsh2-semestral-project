-- Vložení mockových dat do tabulky adresy
INSERT INTO adresy (ulice, cislo_popisne, cislo_orientacni, obec)
VALUES
    ('Hlavní', 123, NULL, 1),
    ('Náměstí', 456, 25, 2),
    ('Ulice Česká', 789, NULL, 3),
    ('Masarykova', 101, 7, 4),
    ('Školní', 222, NULL, 5),
    ('Jiráskova', 333, 15, 6),
    ('5. května', 444, NULL, 7),
    ('Lidická', 555, 30, 8),
    ('Riegrova', 666, NULL, 9),
    ('Komenského', 777, 10, 10);

-- Vložení mockových dat do tabulky jizdni_rady
INSERT INTO jizdni_rady (cas_prijezdu, cas_odjezdu, poradove_cislo, varianta, linka, zastavka)
VALUES
    (TO_DATE('2023-12-08 08:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 08:15:00', 'YYYY-MM-DD HH24:MI:SS'), 1, 1, 101, 1),
    (TO_DATE('2023-12-08 09:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 09:45:00', 'YYYY-MM-DD HH24:MI:SS'), 2, 2, 102, 3),
    (TO_DATE('2023-12-08 11:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 11:15:00', 'YYYY-MM-DD HH24:MI:SS'), 3, 1, 103, 5),
    (TO_DATE('2023-12-08 12:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 12:45:00', 'YYYY-MM-DD HH24:MI:SS'), 4, 2, 104, 7),
    (TO_DATE('2023-12-08 14:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 14:15:00', 'YYYY-MM-DD HH24:MI:SS'), 5, 1, 105, 9),
    (TO_DATE('2023-12-08 15:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 15:45:00', 'YYYY-MM-DD HH24:MI:SS'), 6, 2, 106, 11),
    (TO_DATE('2023-12-08 17:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 17:15:00', 'YYYY-MM-DD HH24:MI:SS'), 7, 1, 107, 13),
    (TO_DATE('2023-12-08 18:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 18:45:00', 'YYYY-MM-DD HH24:MI:SS'), 8, 2, 108, 15),
    (TO_DATE('2023-12-08 20:00:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 20:15:00', 'YYYY-MM-DD HH24:MI:SS'), 9, 1, 109, 17),
    (TO_DATE('2023-12-08 21:30:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 21:45:00', 'YYYY-MM-DD HH24:MI:SS'), 10, 2, 110, 19);

-- Vložení mockových dat do tabulky linky
INSERT INTO linky (kod)
VALUES
    ('101'),
    ('102'),
    ('103'),
    ('104'),
    ('105'),
    ('106'),
    ('107'),
    ('108'),
    ('109'),
    ('110');

-- Vložení mockových dat do tabulky obce
INSERT INTO obce (nazev, cast_obce, psc, stat)
VALUES
    ('Praha', 'Staré Město', '11000', 1),
    ('Brno', 'Královo Pole', '60200', 2),
    ('Ostrava', 'Moravská Ostrava', '70200', 3),
    ('Plzeň', 'Jižní Předměstí', '30100', 4),
    ('Liberec', 'Rochlice', '46001', 5),
    ('Olomouc', 'Nové Sady', '77900', 6),
    ('České Budějovice', 'Svornosti', '37001', 7),
    ('Hradec Králové', 'Malšova Lhota', '50001', 8),
    ('Ústí nad Labem', 'Kočkov', '40001', 9),
    ('Pardubice', 'Staré Hodkovice', '53203', 10);


-- Vložení mockových dat do tabulky osoby
INSERT INTO osoby (jmeno, prijmeni, e_mail, telefon)
VALUES
    ('Jan', 'Novák', 'jan.novak@email.cz', '123456789'),
    ('Eva', 'Svobodová', 'eva.svobodova@email.cz', '987654321'),
    ('Pavel', 'Krátký', 'pavel.kratky@email.cz', '111222333'),
    ('Jana', 'Veselá', 'jana.vesela@email.cz', '444555666'),
    ('Tomáš', 'Procházka', 'tomas.prochazka@email.cz', '777888999'),
    ('Martina', 'Bartošová', 'martina.bartosova@email.cz', '555444333'),
    ('Ondřej', 'Pospíšil', 'ondrej.pospisil@email.cz', '222111000'),
    ('Lucie', 'Havlová', 'lucie.havlova@email.cz', '666777888'),
    ('Marek', 'Němec', 'marek.nemec@email.cz', '999000111'),
    ('Petra', 'Kučerová', 'petra.kucerova@email.cz', '333222111');

-- Vložení mockových dat do tabulky plany_smen
INSERT INTO plany_smen (smena, jizdni_rad)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (1, 4),
    (2, 5),
    (3, 6),
    (1, 7),
    (2, 8),
    (3, 9),
    (1, 10);


-- Vložení mockových dat do tabulky smeny
INSERT INTO smeny (vozidlo, zamestnanec)
VALUES
    (1, 101),
    (2, 102),
    (3, 103),
    (4, 104),
    (5, 105),
    (6, 106),
    (7, 107),
    (8, 108),
    (9, 109),
    (10, 110);

-- Vložení mockových dat do tabulky skutecne_rady
INSERT INTO skutecne_rady (cas_prijezdu, cas_odjezdu, plan)
VALUES
    (TO_DATE('2023-12-08 08:10:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 08:25:00', 'YYYY-MM-DD HH24:MI:SS'), 1),
    (TO_DATE('2023-12-08 09:40:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 09:55:00', 'YYYY-MM-DD HH24:MI:SS'), 2),
    (TO_DATE('2023-12-08 11:10:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 11:25:00', 'YYYY-MM-DD HH24:MI:SS'), 3),
    (TO_DATE('2023-12-08 12:40:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 12:55:00', 'YYYY-MM-DD HH24:MI:SS'), 4),
    (TO_DATE('2023-12-08 14:10:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 14:25:00', 'YYYY-MM-DD HH24:MI:SS'), 5),
    (TO_DATE('2023-12-08 15:40:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 15:55:00', 'YYYY-MM-DD HH24:MI:SS'), 6),
    (TO_DATE('2023-12-08 17:10:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 17:25:00', 'YYYY-MM-DD HH24:MI:SS'), 7),
    (TO_DATE('2023-12-08 18:40:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 18:55:00', 'YYYY-MM-DD HH24:MI:SS'), 8),
    (TO_DATE('2023-12-08 20:10:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 20:25:00', 'YYYY-MM-DD HH24:MI:SS'), 9),
    (TO_DATE('2023-12-08 21:40:00', 'YYYY-MM-DD HH24:MI:SS'), TO_DATE('2023-12-08 21:55:00', 'YYYY-MM-DD HH24:MI:SS'), 10);

-- Vložení mockových dat do tabulky uzivatele
INSERT INTO uzivatele (heslo, datum_registrace, obrazek, role, stav, zamestnanec)
VALUES
    ('heslo123', CURRENT_TIMESTAMP, 'obrazek1.png', 1, 1, 101),
    ('uzivatel456', CURRENT_TIMESTAMP, 'obrazek2.png', 2, 1, 102),
    ('tajneHeslo', CURRENT_TIMESTAMP, 'obrazek3.png', 3, 1, 103),
    ('mojeHeslo', CURRENT_TIMESTAMP, 'obrazek4.png', 1, 1, 104),
    ('bezpecne123', CURRENT_TIMESTAMP, 'obrazek5.png', 2, 1, 105),
    ('komplikovane', CURRENT_TIMESTAMP, 'obrazek6.png', 3, 1, 106),
    ('testUser', CURRENT_TIMESTAMP, 'obrazek7.png', 1, 1, 107),
    ('novyUzivatel', CURRENT_TIMESTAMP, 'obrazek8.png', 2, 1, 108),
    ('secretPass', CURRENT_TIMESTAMP, 'obrazek9.png', 3, 1, 109),
    ('admin123', CURRENT_TIMESTAMP, 'obrazek10.png', 1, 1, 110);

-- Vložení mockových dat do tabulky zamestnanci
INSERT INTO zamestnanci (osobni_cislo, datum_nastupu, bydliste, osobni_udaje, nadrizeny)
VALUES
    (100001, TO_DATE('2020-01-15', 'YYYY-MM-DD'), 1, 1, NULL),
    (100002, TO_DATE('2019-05-20', 'YYYY-MM-DD'), 2, 2, 101),
    (100003, TO_DATE('2021-02-10', 'YYYY-MM-DD'), 3, 3, 102),
    (100004, TO_DATE('2018-08-05', 'YYYY-MM-DD'), 4, 4, 103),
    (100005, TO_DATE('2022-11-30', 'YYYY-MM-DD'), 5, 5, 104),
    (100006, TO_DATE('2020-07-22', 'YYYY-MM-DD'), 6, 6, 105),
    (100007, TO_DATE('2019-03-17', 'YYYY-MM-DD'), 7, 7, 106),
    (100008, TO_DATE('2022-09-01', 'YYYY-MM-DD'), 8, 8, 107),
    (100009, TO_DATE('2021-06-12', 'YYYY-MM-DD'), 9, 9, 108),
    (100010, TO_DATE('2020-04-25', 'YYYY-MM-DD'), 10, 10, 109);

-- Vložení mockových dat do tabulky zastavky
INSERT INTO zastavky (nazev, gps_severni_sirka, gps_vychodni_delka, kod, bezbarierova, na_znameni)
VALUES
    ('Náměstí Republiky', 50.087, 14.420, 'NR001', 1, 0),
    ('Hlavní nádraží', 50.083, 14.433, 'HN002', 1, 1),
    ('Staroměstská', 50.087, 14.419, 'SM003', 0, 1),
    ('Malostranská', 50.086, 14.406, 'MS004', 1, 0),
    ('Anděl', 50.071, 14.404, 'AN005', 0, 0),
    ('I. P. Pavlova', 50.075, 14.428, 'IP006', 1, 1),
    ('Náměstí Jiřího z Poděbrad', 50.075, 14.454, 'NP007', 0, 1),
    ('Flora', 50.082, 14.447, 'FL008', 1, 0),
    ('Želivského', 50.080, 14.465, 'ZE009', 0, 0),
    ('Černý Most', 50.106, 14.570, 'CM010', 1, 1);
