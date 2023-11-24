INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Změnit svoji roli za běhu', 'role.modify.runtime')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Změnit svoji roli', 'role.modify.own')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Změnit své údaje', 'user.modify.own')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Změnit své osobní číslo', 'employee.personal_number.modify.own')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Změnit svůj datum nástupu', 'employee.date.modify.own')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Změnit svůj datum registrace', 'user.date.modify.own')

INSERT INTO prava(role, opravneni) VALUES (1, 3)
