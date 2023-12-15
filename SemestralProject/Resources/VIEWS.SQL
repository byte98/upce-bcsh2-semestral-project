CREATE OR REPLACE VIEW vw_zamestnanci_hierarchie AS 
SELECT 
    LEVEL - 1 AS uroven, 
    id_zamestnanec AS zamestnanec 
FROM zamestnanci 
START WITH nadrizeny IS NULL 
CONNECT BY PRIOR id_zamestnanec = nadrizeny 
ORDER SIBLINGS BY id_zamestnanec 

CREATE OR REPLACE VIEW vw_role_opravneni_count AS
SELECT r.id_role AS role,
COUNT (p.opravneni) AS opravneni
FROM role r
LEFT JOIN prava p ON r.id_role = p.role
GROUP BY r.id_role;

CREATE OR REPLACE VIEW vw_uzivatele_data AS
SELECT u.id_uzivatel AS id,
       sempr_utils.func_mask_email(o.e_mail) AS email,
       sempr_utils.func_mask_phone(o.telefon) AS phone
FROM uzivatele u
JOIN zamestnanci z ON u.zamestnanec = z.id_zamestnanec
JOIN osoby o ON z.osobni_udaje = o.id_osoba;
