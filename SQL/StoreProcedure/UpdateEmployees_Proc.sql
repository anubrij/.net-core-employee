CREATE OR ALTER PROCEDURE [dbo].[UpdateEmployees] 
	@Id as int,
	@firstName as varchar(200),
	@lastName as varchar(200),
	@dateOfBirth as date,
	@designation as varchar(200),
	@dateOfJoining as date,
	@CTC as int
AS
BEGIN
	UPDATE EMPLOYEES SET
		firstName = @firstName,
		lastName = @lastName,
		dateOfBirth = @dateOfBirth,
		designation = @designation,
		dateOfJoining = @dateOfJoining,
		ctc = @CTC
	WHERE
		Id = @Id
END