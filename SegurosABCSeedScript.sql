USE SegurosABC

CREATE TABLE Cliente (
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	NombreCompleto varchar(50) NOT NULL,
	Cedula varchar(20) NOT NULL,
	PIN int NOT NULL,
)

INSERT INTO Cliente (NombreCompleto,Cedula,PIN) VALUES 
('Juan Perez', '8-75-584', 1478),
('Miguel Batista', 'PE-254-845', 1244);

CREATE TABLE Pago (
	Id int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	Cedula varchar(20) NOT NULL,
	FechaPago datetime NOT NULL,
	Monto decimal NOT NULL,
)

INSERT INTO Pago (Cedula,FechaPago,Monto) VALUES
('8-75-584','4/4/21', 200.00),
('8-75-584','1/5/21', 198.22),
('8-75-584','1/6/21', 210.00),
('PE-254-845','4/30/21', 200.00),
('PE-254-845','3/29/21', 198.22),
('PE-254-845','2/17/21', 210.00)


CREATE OR ALTER PROCEDURE ConsultaPagosCliente @Cedula varchar(20)
AS
BEGIN
	SELECT 
		c.Cedula,
		c.NombreCompleto,
		p.FechaPago,
		p.Monto
	FROM
		Cliente c INNER JOIN Pago p 
		ON c.Cedula = p.Cedula 
	WHERE 
		c.Cedula LIKE '%'+@Cedula+'%'
		OR @Cedula IS NULL
		OR @Cedula LIKE ''
	ORDER BY FechaPago DESC
END

EXEC ConsultaPagosCliente @Cedula = ''