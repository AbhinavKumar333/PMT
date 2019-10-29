
CREATE TABLE [dbo].[Airport](
	[AirportCode] [char](6) NOT NULL,
	[AirportName] [varchar](30) NOT NULL,
	[Location] [varchar](30) NULL,
	[Description] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[AirportCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 4/8/2019 11:33:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookingDetails](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[Roomid] [int] NULL,
	[BookedFor] [varchar](40) NULL,
	[BookedFrom] [datetime] NULL,
	[BookedTo] [datetime] NULL,
	[NoOfAdults] [int] NULL,
	[NoOfChildren] [int] NULL,
	[Amount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flight]    Script Date: 4/8/2019 11:33:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flight](
	[FlightNumber] [char](6) NOT NULL,
	[FlightName] [varchar](30) NOT NULL,
	[SeatsCapacity] [int] NOT NULL,
	[NoOfSeatsAvailable] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FlightNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FlightSchedule]    Script Date: 4/8/2019 11:33:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FlightSchedule](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FlightNumber] [char](6) NULL,
	[Origin] [char](6) NULL,
	[Destination] [char](6) NULL,
	[DepartureTime] [datetime] NOT NULL,
	[ArrivalTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  StoredProcedure [dbo].[SearchFlights]    Script Date: 4/8/2019 11:33:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchFlights]
	@origin varchar(30),
	@dest varchar(30),
	@depttime datetime
AS
	SELECT F.FlightNumber, F.FlightName 
	From FlightSchedule FS inner join Flight F
	on FS.FlightNumber = F.FlightNumber
	WHERE FS.Origin = @origin and FS.Destination = @dest and FS.DepartureTime = @depttime
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchFlights]    Script Date: 4/8/2019 11:33:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchFlights]
	@origin varchar(30),
	@dest varchar(30),
	@depttime datetime
AS
	SELECT F.FlightNumber, F.FlightName,FS.DepartureTime,FS.ArrivalTime,F.NoOfSeatsAvailable
	From FlightSchedule FS inner join Flight F
	on FS.FlightNumber = F.FlightNumber
	WHERE FS.Origin = @origin and FS.Destination = @dest and FS.DepartureTime =  CAST(@depttime as Date)
RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchFlights1]    Script Date: 4/8/2019 11:33:33 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[usp_SearchFlights1]
	@origin varchar(30),
	@dest varchar(30),
	@depttime datetime
AS
	SELECT F.FlightNumber, F.FlightName,FS.DepartureTime,FS.ArrivalTime,F.NoOfSeatsAvailable
	From FlightSchedule FS inner join Flight F
	on FS.FlightNumber = F.FlightNumber
	WHERE FS.Origin = (Select AirportCode FROM Airport WHERE AirportCode=(Select AirportCode FROM Airport WHERE AirportName = @origin)) and FS.Destination = (Select AirportCode FROM Airport WHERE AirportCode=(Select AirportCode FROM Airport WHERE AirportName = @dest)) and FS.DepartureTime =  CAST(@depttime as Date)
RETURN 0
GO
