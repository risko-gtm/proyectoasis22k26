
-- ============================================================================
-- MÓDULO: EXAMEN (ID 15000)
-- APLICACIÓN: DIRECTORES (ID 15001)
-- DESCRIPCIÓN:
-- Registra el módulo Examen y su aplicación Directores
-- en el catálogo de Seguridad.
-- No modifica registros existentes.
-- ============================================================================

USE dbsistemaembutidos;

START TRANSACTION;


-- 1. Registrar el módulo Examen.
INSERT INTO tblmodulo
    (idModulo, nombreModulo, descripcionModulo, is_active)
SELECT
    15000,
    'Examen',
    'Módulo para la consulta y generación de reportes de directores.',
    1
WHERE NOT EXISTS (
    SELECT 1
    FROM tblmodulo
    WHERE idModulo = 15000
);

-- 2. Registrar la aplicación Directores.
INSERT INTO tblaplicacion
    (idAplicacion, idModulo, nombreAplicacion, descripcionAplicacion, is_active)
SELECT
    15001,
    15000,
    'Directores',
    'Consulta y generación del reporte de directores.',
    1
FROM tblmodulo AS m
LEFT JOIN tblaplicacion AS existente
    ON existente.idAplicacion = 15001
WHERE m.idModulo = 15000
  AND m.nombreModulo = 'Examen'
  AND existente.idAplicacion IS NULL;

-- 3. Asignar permisos al Administrador (rol 1).
INSERT INTO tblRolModuloAplicacion
(
    idRol,
    idModulo,
    idAplicacion,
    derInsertarRolModuloAplicacion,
    derEditarRolModuloAplicacion,
    derEliminarRolModuloAplicacion,
    derImprimirRolModuloAplicacion
)
SELECT
    r.idRol,
    a.idModulo,
    a.idAplicacion,
    1, 1, 1, 1
FROM tblRol AS r
INNER JOIN tblAplicacion AS a
    ON a.idModulo = 15000
   AND a.idAplicacion = 15001
WHERE r.idRol = 1
ON DUPLICATE KEY UPDATE
    derInsertarRolModuloAplicacion = 1,
    derEditarRolModuloAplicacion = 1,
    derEliminarRolModuloAplicacion = 1,
    derImprimirRolModuloAplicacion = 1;

COMMIT;

-- ============================================================================
-- 4. VERIFICAR EL REGISTRO
-- ============================================================================

SELECT *
FROM tblmodulo
WHERE idModulo = 15000;

SELECT *
FROM tblaplicacion
WHERE idAplicacion = 15001;

SELECT *
FROM tblRolModuloAplicacion
WHERE idModulo = 15000
  AND idAplicacion = 15001;
