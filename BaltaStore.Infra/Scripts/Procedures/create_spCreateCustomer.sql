CREATE PROCEDURE spCreateCustomer
	@Id UNIQUEIDENTIFIER,
	@FirstName VARCHAR(50),
	@LastName VARCHAR(50),
	@Document VARCHAR(11),
	@Email VARCHAR(50),
	@Phone CHAR(2)
AS
	INSERT INTO Customers(
	[Id],
	[FirstName],
	[LastName],
	[Document],
	[Email],
	[Phone]
) VALUES (
	@Id,
	@FirstName,
	@LastName,
	@Document,
	@Email ,
	@Phone)