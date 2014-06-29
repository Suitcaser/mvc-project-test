CREATE TABLE [dbo].[ContractInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ContractNumber] [int] NOT NULL,
	[ContractSubject] [varchar](50) NOT NULL,
	[FullName] [varchar](50) NOT NULL,
	[ContractDate] [date] NOT NULL,
	[ExecutorInfo] [varchar](150) NOT NULL,
	[Sum] [float] NOT NULL,
	[Sygnatory] [varchar](50) NOT NULL,
	[ContactInfo] [varchar](150) NOT NULL,
)
