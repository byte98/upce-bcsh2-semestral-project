INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit svoji roli za běhu', 'role.modify.runtime')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit svoji roli', 'role.modify.own')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit své údaje', 'user.modify.own')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit své osobní číslo', 'employee.personal_number.modify.own')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit svůj datum nástupu', 'employee.date.modify.own')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit svůj datum registrace', 'user.date.modify.own')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst zaměstnance', 'employees.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit zaměstnance', 'employees.modify')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst uživatelské účty', 'users.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit uživatelské účty', 'users.modify')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst role', 'roles.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit role', 'roles.modify')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst linky', 'lines.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit linky', 'lines.modify')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst zastávky', 'stops.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit zastávky', 'stops.modify')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst jízdní řády', 'schedules.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit jízdní řády', 'schedules.modify')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst žurnál', 'logs.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst hierarchii společnosti', 'hierarchy.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Používat supernástroj databáze', 'supertool')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst e-maily', 'emails.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst telefonní čísla', 'phones.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst směny', 'shifts.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit směny', 'shifts.modify')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Číst vozidla', 'vehicles.read')
INSERT INTO opravneni(nazev, systemovy_nazev) VALUES ('Měnit vozidla', 'vehicles.modify')
INSERT INTO prava(role, opravneni) VALUES (1, 3)
