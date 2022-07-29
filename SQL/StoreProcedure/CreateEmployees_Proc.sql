CREATE OR ALTER PROCEDURE [dbo].[CreateEmployees] 
	@firstName as varchar(200),
	@lastName as varchar(200),
	@dateOfBirth as date,
	@designation as varchar(200),
	@dateOfJoining as date,
	@CTC as int
AS
BEGIN
   INSERT INTO EMPLOYEES(
		firstName,
		lastName,
		dateOfBirth,
		designation,
		dateOfJoining,
		ctc)
	VALUES
	(
		@firstName,
		@lastName,
		@dateOfBirth,
		@designation,
		@dateOfJoining,
		@CTC
	)
	return SCOPE_IDENTITY()
END