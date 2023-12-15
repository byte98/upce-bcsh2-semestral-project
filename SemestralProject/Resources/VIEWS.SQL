CREATE OR REPLACE VIEW vw_zamestnanci_hierarchie AS 
SELECT 
    LEVEL - 1 AS uroven, 
    id_zamestnanec AS zamestnanec 
FROM zamestnanci 
START WITH nadrizeny IS NULL 
CONNECT BY PRIOR id_zamestnanec = nadrizeny 
ORDER SIBLINGS BY id_zamestnanec 
