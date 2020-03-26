CREATE TABLE [dbo].[PolicyValidityPeriod]
(
	PolicyValidityPeriodId INT NOT NULL PRIMARY KEY IDENTITY,
	PolicyFrom DATETIME2,
	PolicyTo DATETIME2
)
