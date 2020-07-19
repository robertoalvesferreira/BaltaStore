CREATE PROCEDURE spCreateAddress
	@Id UNIQUEIDENTIFIER,
	@CustomerId UNIQUEIDENTIFIER,
	@Number VARCHAR(10),
	@Complement VARCHAR(40),
	@District VARCHAR(40),
	@City VARCHAR(40),
	@State CHAR(2),
	@Country CHAR(2),
	@ZipCode CHAR(8),
	@Type int
AS
	INSERT INTO [Addresses] (
	[Id],
	[CustomerId],
	[Number],
	[Complement],
	[District],
	[City],
	[State],
	[Country],
	[ZipCode],
	[Type]) VALUES (
	@Id,
	@CustomerId,
	@Number,
	@Complement ,
	@District ,
	@City ,
	@State ,
	@Country ,
	@ZipCode ,
	@Type)