CREATE DATABASE FlightSearchDB;
GO
USE FlightSearchDB;
CREATE TABLE Flights(
	FLightId INT PRIMARY KEY IDENTITY(1,1),
	FlightName NVARCHAR(100) NOT NULL,
	FlightType NVARCHAR(50) NOT NULL,
	Source NVARCHAR(100) NOT NULL,
	Destination NVARCHAR(100) NOT NULL,
	PricePerSeat DECIMAL(18,2) NOT NULL
);

CREATE TABLE Hotels(
	HotelId INT PRIMARY KEY IDENTITY(1,1),
	HotelName NVARCHAR(100) NOT NULL,
	HotelType NVARCHAR(50) NOT NULL,
	Location  NVARCHAR(100) NOT NULL,
	PricePerDay DECIMAL(18,2) NOT NULL
);

INSERT INTO Flights VALUES
('Air India', 'Domestic', 'Delhi', 'Mumbai', 5000),
('Indigo', 'Domestic', 'Delhi', 'Bangalore', 4500),
('Emirates', 'International', 'Delhi', 'Dubai', 15000);

INSERT INTO Hotels VALUES
('Taj Mumbai','5-Star','Mumbai',8000),
('ITC Bangalore','5-Star','Bangalore',7000),
('Burj Stay','Luxury','Dubai',20000);
GO

CREATE PROCEDURE sp_GetSources
AS
BEGIN
	SELECT DISTINCT Source FROM Flights;
END
Go


CREATE PROCEDURE sp_GetDestinations
AS 
BEGIN
	SELECT DISTINCT Destination FROM Flights;
END
Go


CREATE PROCEDURE sp_SearchFlights
	@Source NVARCHAR(100),
	@Destination NVARCHAR(100),
	@Persons INT
AS 
BEGIN
	SELECT
		FlightId,
		FlightName,
		FlightType,
		Source,
		Destination,
		PricePerSeat*@Persons AS TotalCost
	FROM Flights
	WHERE Source=@Source AND Destination=@Destination;
END
GO


CREATE PROCEDURE sp_SearchFlightWithHotels
	@Source NVARCHAR(100),
	@Destination NVARCHAR(100),
	@Persons INT
AS
BEGIN
	SELECT
		f.FLightId,
		f.FlightName,
		f.Source,
		f.Destination,
		h.HotelName,
		(f.PricePerSeat*@Persons) + h.PricePerDay AS  TotalCost
	FROM Flights f
	INNER JOIN Hotels h ON f.Destination=h.Location
	WHERE f.Source=@Source AND f.Destination=@Destination;
END

SELECT @@SERVERNAME;