INSERT INTO prava (role, opravneni)
SELECT 0 AS role_id, o.id_opravneni AS opravneni_id
FROM opravneni o
