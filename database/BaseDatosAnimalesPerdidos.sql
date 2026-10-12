-- =============================================
-- BASE DE DATOS
-- REGISTRO DE ANIMALES PERDIDOS
-- =============================================

CREATE DATABASE RegistroAnimalesPerdidos;
GO

USE RegistroAnimalesPerdidos;
GO

-- =============================================
-- TABLA: PERSONAS
-- =============================================

CREATE TABLE Personas (
    IdPersona INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    Telefono VARCHAR(20) NOT NULL,
    Correo VARCHAR(100)
);
GO

-- =============================================
-- TABLA: ANIMALES PERDIDOS
-- =============================================

CREATE TABLE AnimalesPerdidos (
    IdAnimal INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(50) NOT NULL,
    Especie VARCHAR(30) NOT NULL,
    Raza VARCHAR(50),
    Color VARCHAR(50),
    Descripcion VARCHAR(200),
    FechaPerdida DATE NOT NULL,
    LugarPerdida VARCHAR(150) NOT NULL,
    Estado VARCHAR(30) NOT NULL,
    IdPersona INT NOT NULL,

    CONSTRAINT FK_Animal_Persona
        FOREIGN KEY (IdPersona)
        REFERENCES Personas(IdPersona)
);
GO

-- =============================================
-- STORED PROCEDURES
-- =============================================

USE RegistroAnimalesPerdidos;
GO

-- 1. Insertar persona
CREATE PROCEDURE InsertarPersona
    @Nombre VARCHAR(100),
    @Telefono VARCHAR(20),
    @Correo VARCHAR(100)
AS
BEGIN
    INSERT INTO Personas (Nombre, Telefono, Correo)
    VALUES (@Nombre, @Telefono, @Correo);
END;
GO

-- 2. Listar personas
CREATE PROCEDURE ListarPersonas
AS
BEGIN
    SELECT *
    FROM Personas;
END;
GO

-- 3. Insertar animal perdido
CREATE PROCEDURE InsertarAnimal
    @Nombre VARCHAR(50),
    @Especie VARCHAR(30),
    @Raza VARCHAR(50),
    @Color VARCHAR(50),
    @Descripcion VARCHAR(200),
    @FechaPerdida DATE,
    @LugarPerdida VARCHAR(150),
    @Estado VARCHAR(30),
    @IdPersona INT
AS
BEGIN
    INSERT INTO AnimalesPerdidos
    (
        Nombre,
        Especie,
        Raza,
        Color,
        Descripcion,
        FechaPerdida,
        LugarPerdida,
        Estado,
        IdPersona
    )
    VALUES
    (
        @Nombre,
        @Especie,
        @Raza,
        @Color,
        @Descripcion,
        @FechaPerdida,
        @LugarPerdida,
        @Estado,
        @IdPersona
    );
END;
GO

-- 4. Listar animales
CREATE PROCEDURE ListarAnimales
AS
BEGIN
    SELECT
        A.IdAnimal,
        A.Nombre,
        A.Especie,
        A.Raza,
        A.Color,
        A.Descripcion,
        A.FechaPerdida,
        A.LugarPerdida,
        A.Estado,
        P.Nombre AS NombrePersona,
        P.Telefono,
        P.Correo
    FROM AnimalesPerdidos A
    INNER JOIN Personas P
        ON A.IdPersona = P.IdPersona;
END;
GO

-- 5. Buscar animal por ID
CREATE PROCEDURE BuscarAnimal
    @IdAnimal INT
AS
BEGIN
    SELECT *
    FROM AnimalesPerdidos
    WHERE IdAnimal = @IdAnimal;
END;
GO

-- 6. Actualizar animal
CREATE PROCEDURE ActualizarAnimal
    @IdAnimal INT,
    @Nombre VARCHAR(50),
    @Especie VARCHAR(30),
    @Raza VARCHAR(50),
    @Color VARCHAR(50),
    @Descripcion VARCHAR(200),
    @FechaPerdida DATE,
    @LugarPerdida VARCHAR(150),
    @Estado VARCHAR(30),
    @IdPersona INT
AS
BEGIN
    UPDATE AnimalesPerdidos
    SET
        Nombre = @Nombre,
        Especie = @Especie,
        Raza = @Raza,
        Color = @Color,
        Descripcion = @Descripcion,
        FechaPerdida = @FechaPerdida,
        LugarPerdida = @LugarPerdida,
        Estado = @Estado,
        IdPersona = @IdPersona
    WHERE IdAnimal = @IdAnimal;
END;
GO

-- 7. Eliminar animal
CREATE PROCEDURE EliminarAnimal
    @IdAnimal INT
AS
BEGIN
    DELETE FROM AnimalesPerdidos
    WHERE IdAnimal = @IdAnimal;
END;
GO
-- 8. Obtener animales de una persona
CREATE OR ALTER PROCEDURE ObtenerAnimalesPorPersona
    @IdPersona INT
AS
BEGIN
    SELECT
        A.IdAnimal,
        A.Nombre,
        A.Especie,
        A.Raza,
        A.Color,
        A.Descripcion,
        A.FechaPerdida,
        A.LugarPerdida,
        A.Estado,
        A.IdPersona
    FROM AnimalesPerdidos A
    WHERE A.IdPersona = @IdPersona;
END;
GO


-- 9. Obtener resumen de animales por persona
CREATE OR ALTER PROCEDURE ObtenerResumenAnimalesPorPersona
    @IdPersona INT
AS
BEGIN
    SELECT
        P.IdPersona,
        P.Nombre AS NombrePersona,
        COUNT(A.IdAnimal) AS CantidadAnimales
    FROM Personas P
    LEFT JOIN AnimalesPerdidos A
        ON P.IdPersona = A.IdPersona
    WHERE P.IdPersona = @IdPersona
    GROUP BY
        P.IdPersona,
        P.Nombre;
END;
GO
USE RegistroAnimalesPerdidos;
GO

-- 10. Obtener cantidad de animales por categoria
CREATE OR ALTER PROCEDURE ObtenerAnimalesPorCategoria
AS
BEGIN
    SELECT
        Especie AS Categoria,
        COUNT(*) AS Cantidad
    FROM AnimalesPerdidos
    GROUP BY Especie
    ORDER BY Especie;
END;
GO