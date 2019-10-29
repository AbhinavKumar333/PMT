CREATE DATABASE PlanMyTripDB
Go
Use PlanMyTripDB
Go

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
/****** Object:  Table [dbo].[BookingDetails]    Script Date: 9/3/2019 9:50:00 AM ******/
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
/****** Object:  Table [dbo].[Flight]    Script Date: 9/3/2019 9:50:00 AM ******/
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
/****** Object:  Table [dbo].[FlightSchedule]    Script Date: 9/3/2019 9:50:00 AM ******/
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
/****** Object:  Table [dbo].[Hotel]    Script Date: 9/3/2019 9:50:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[HotelId] [int] IDENTITY(1,1) NOT NULL,
	[City] [varchar](30) NULL,
	[HotelName] [varchar](30) NULL,
	[Address] [varchar](100) NULL,
	[Description] [varchar](100) NULL,
	[AvgRoomRent] [int] NULL,
	[Phone] [char](10) NULL,
	[Rating] [int] NULL,
	[Email] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Itenary]    Script Date: 9/3/2019 9:50:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Itenary](
	[ReservationId] [int] IDENTITY(1,1) NOT NULL,
	[PassengerId] [int] NULL,
	[ScheduleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Passenger]    Script Date: 9/3/2019 9:50:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Passenger](
	[PassengerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[Age] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PassengerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/3/2019 9:50:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](30) NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomDetails]    Script Date: 9/3/2019 9:50:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomDetails](
	[HotelId] [int] NULL,
	[RoomId] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [varchar](3) NULL,
	[RoomType] [varchar](20) NULL,
	[PerDayRate] [int] NULL,
	[Availability] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RoomId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 9/3/2019 9:50:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[EmailId] [varchar](30) NOT NULL,
	[Password] [varchar](12) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [Location], [Description]) VALUES (N'BGLR  ', N'Bengaluru', N'Bengaluru', N'Devanalli')
INSERT [dbo].[Airport] ([AirportCode], [AirportName], [Location], [Description]) VALUES (N'PNQ   ', N'Pune', N'Viman Nagar', N'Lohegaon')
INSERT [dbo].[Flight] ([FlightNumber], [FlightName], [SeatsCapacity], [NoOfSeatsAvailable]) VALUES (N'SG-479', N'Spice Jet', 120, 10)
SET IDENTITY_INSERT [dbo].[FlightSchedule] ON 

INSERT [dbo].[FlightSchedule] ([Id], [FlightNumber], [Origin], [Destination], [DepartureTime], [ArrivalTime]) VALUES (24, N'SG-479', N'PNQ   ', N'BGLR  ', CAST(N'2018-12-02T00:00:00.000' AS DateTime), CAST(N'2018-12-02T17:35:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[FlightSchedule] OFF
SET IDENTITY_INSERT [dbo].[Hotel] ON 

INSERT [dbo].[Hotel] ([HotelId], [City], [HotelName], [Address], [Description], [AvgRoomRent], [Phone], [Rating], [Email]) VALUES (1, N'Pune', N'OYO', N'Satara Road', N'Affordable single and double rooms with bathtub', 2400, N'9881078730', 4, N'oyosatararoad@gmail.com')
SET IDENTITY_INSERT [dbo].[Hotel] OFF
SET IDENTITY_INSERT [dbo].[RoomDetails] ON 

INSERT [dbo].[RoomDetails] ([HotelId], [RoomId], [RoomName], [RoomType], [PerDayRate], [Availability]) VALUES (1, 13, N'B', N'AC', 2600, 0)
SET IDENTITY_INSERT [dbo].[RoomDetails] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserId], [FirstName], [LastName], [EmailId], [Password]) VALUES (1, N'Sample', N'User', N's@gmail.com', N'1')
SET IDENTITY_INSERT [dbo].[Users] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Users__7ED91ACE7E81EF0C]    Script Date: 9/3/2019 9:50:00 AM ******/
ALTER TABLE [dbo].[Users] ADD UNIQUE NONCLUSTERED 
(
	[EmailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD FOREIGN KEY([Roomid])
REFERENCES [dbo].[RoomDetails] ([RoomId])
GO
ALTER TABLE [dbo].[BookingDetails]  WITH CHECK ADD FOREIGN KEY([Roomid])
REFERENCES [dbo].[RoomDetails] ([RoomId])
GO
ALTER TABLE [dbo].[FlightSchedule]  WITH CHECK ADD FOREIGN KEY([Destination])
REFERENCES [dbo].[Airport] ([AirportCode])
GO
ALTER TABLE [dbo].[FlightSchedule]  WITH CHECK ADD FOREIGN KEY([Destination])
REFERENCES [dbo].[Airport] ([AirportCode])
GO
ALTER TABLE [dbo].[FlightSchedule]  WITH CHECK ADD FOREIGN KEY([FlightNumber])
REFERENCES [dbo].[Flight] ([FlightNumber])
GO
ALTER TABLE [dbo].[FlightSchedule]  WITH CHECK ADD FOREIGN KEY([FlightNumber])
REFERENCES [dbo].[Flight] ([FlightNumber])
GO
ALTER TABLE [dbo].[FlightSchedule]  WITH CHECK ADD FOREIGN KEY([Origin])
REFERENCES [dbo].[Airport] ([AirportCode])
GO
ALTER TABLE [dbo].[FlightSchedule]  WITH CHECK ADD FOREIGN KEY([Origin])
REFERENCES [dbo].[Airport] ([AirportCode])
GO
ALTER TABLE [dbo].[Itenary]  WITH CHECK ADD FOREIGN KEY([PassengerId])
REFERENCES [dbo].[Passenger] ([PassengerId])
GO
ALTER TABLE [dbo].[Itenary]  WITH CHECK ADD FOREIGN KEY([PassengerId])
REFERENCES [dbo].[Passenger] ([PassengerId])
GO
ALTER TABLE [dbo].[Itenary]  WITH CHECK ADD FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[FlightSchedule] ([Id])
GO
ALTER TABLE [dbo].[Itenary]  WITH CHECK ADD FOREIGN KEY([ScheduleId])
REFERENCES [dbo].[FlightSchedule] ([Id])
GO
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[Roles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO
ALTER TABLE [dbo].[RoomDetails]  WITH CHECK ADD FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([HotelId])
GO
ALTER TABLE [dbo].[RoomDetails]  WITH CHECK ADD FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([HotelId])
GO
/****** Object:  StoredProcedure [dbo].[usp_SearchFlights1]    Script Date: 9/3/2019 9:50:00 AM ******/
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
/****** Object:  StoredProcedure [dbo].[uspSearchHotels]    Script Date: 9/3/2019 9:50:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspSearchHotels]
@City varchar(30)
AS
BEGIN
	SELECT ht.HotelName,ht.Address,ht.Description,rd.RoomName,rd.RoomType,rd.PerDayRate
	From Hotel ht inner join RoomDetails rd
	on ht.HotelId = rd.HotelId
	WHERE ht.City = @City
END
GO
ALTER DATABASE [PlanMyTripDB] SET  READ_WRITE 
GO
