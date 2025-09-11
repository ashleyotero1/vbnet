-- --------------------------------------------------------------------------------
-- Name: Bob Nields 
 
-- Abstract: FlyMe2theMoon
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbFlyMe2theMoon;     
SET NOCOUNT ON;  

-- --------------------------------------------------------------------------------
--						Problem #10
-- --------------------------------------------------------------------------------

-- Drop Table Statements
IF OBJECT_ID ('TPilotFlights')			IS NOT NULL DROP TABLE TPilotFlights
IF OBJECT_ID ('TAttendantFlights')		IS NOT NULL DROP TABLE TAttendantFlights
IF OBJECT_ID ('TFlightPassengers')		IS NOT NULL DROP TABLE TFlightPassengers
IF OBJECT_ID ('TMaintenanceMaintenanceWorkers')			IS NOT NULL DROP TABLE TMaintenanceMaintenanceWorkers

IF OBJECT_ID ('TPassengers')			IS NOT NULL DROP TABLE TPassengers
IF OBJECT_ID ('TPilots')				IS NOT NULL DROP TABLE TPilots
IF OBJECT_ID ('TAttendants')			IS NOT NULL DROP TABLE TAttendants
IF OBJECT_ID ('TMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceWorkers

IF OBJECT_ID ('TFlights')				IS NOT NULL DROP TABLE TFlights
IF OBJECT_ID ('TMaintenances')			IS NOT NULL DROP TABLE TMaintenances
IF OBJECT_ID ('TPlanes')				IS NOT NULL DROP TABLE TPlanes
IF OBJECT_ID ('TPlaneTypes')			IS NOT NULL DROP TABLE TPlaneTypes
IF OBJECT_ID ('TPilotRoles')			IS NOT NULL DROP TABLE TPilotRoles
IF OBJECT_ID ('TAirports')				IS NOT NULL DROP TABLE TAirports
IF OBJECT_ID ('TStates')				IS NOT NULL DROP TABLE TStates

-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------

CREATE TABLE TPassengers
(
	 intPassengerID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strCity				VARCHAR(255)	NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,strPhoneNumber			VARCHAR(255)	NOT NULL
	,strEmail				VARCHAR(255)	NOT NULL
	,CONSTRAINT TPassengers_PK PRIMARY KEY ( intPassengerID )
)


CREATE TABLE TPilots
(
	 intPilotID				INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfLicense		DATETIME		NOT NULL
	,intPilotRoleID			INTEGER			NOT NULL

	,CONSTRAINT TPilots_PK PRIMARY KEY ( intPilotID )
)


CREATE TABLE TAttendants
(
	 intAttendantID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,CONSTRAINT TAttendants_PK PRIMARY KEY ( intAttendantID )
)


CREATE TABLE TMaintenanceWorkers
(
	 intMaintenanceWorkerID	INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfCertification	DATETIME		NOT NULL
	,CONSTRAINT TMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceWorkerID )
)


CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)


CREATE TABLE TFlights
(
	 intFlightID			INTEGER			NOT NULL
	,strFlightNumber		VARCHAR(255)	NOT NULL
	,dtmFlightDate			DATETIME		NOT NULL
	,dtmTimeofDeparture		TIME			NOT NULL
	,dtmTimeOfLanding		TIME			NOT NULL
	,intFromAirportID		INTEGER			NOT NULL
	,intToAirportID			INTEGER			NOT NULL
	,intMilesFlown			INTEGER			NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TFlights_PK PRIMARY KEY ( intFlightID )
)


CREATE TABLE TMaintenances
(
	 intMaintenanceID		INTEGER			NOT NULL
	,strWorkCompleted		VARCHAR(8000)	NOT NULL
	,dtmMaintenanceDate		DATETIME		NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TMaintenances_PK PRIMARY KEY ( intMaintenanceID )
)


CREATE TABLE TPlanes
(
	 intPlaneID				INTEGER			NOT NULL
	,strPlaneNumber			VARCHAR(255)	NOT NULL
	,intPlaneTypeID			INTEGER			NOT NULL
	,CONSTRAINT TPlanes_PK PRIMARY KEY ( intPlaneID )
)


CREATE TABLE TPlaneTypes	
(
	 intPlaneTypeID			INTEGER			NOT NULL
	,strPlaneType			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPlaneTypes_PK PRIMARY KEY ( intPlaneTypeID )
)


CREATE TABLE TPilotRoles	
(
	 intPilotRoleID			INTEGER			NOT NULL
	,strPilotRole			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPilotRoles_PK PRIMARY KEY ( intPilotRoleID )
)


CREATE TABLE TAirports
(
	 intAirportID			INTEGER			NOT NULL
	,strAirportCity			VARCHAR(255)	NOT NULL
	,strAirportCode			VARCHAR(255)	NOT NULL
	,CONSTRAINT TAirports_PK PRIMARY KEY ( intAirportID )
)


CREATE TABLE TPilotFlights
(
	 intPilotFlightID		INTEGER			NOT NULL
	,intPilotID				INTEGER			NOT NULL
	,intFlightID			INTEGER			NOT NULL
	,CONSTRAINT TPilotFlights_PK PRIMARY KEY ( intPilotFlightID )
)


CREATE TABLE TAttendantFlights
(
	 intAttendantFlightID		INTEGER			NOT NULL
	,intAttendantID				INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,CONSTRAINT TAttendantFlights_PK PRIMARY KEY ( intAttendantFlightID )
)


CREATE TABLE TFlightPassengers
(
	 intFlightPassengerID		INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,intPassengerID				INTEGER			NOT NULL
	,strSeat					VARCHAR(255)	NOT NULL
	,CONSTRAINT TFlightPassengers_PK PRIMARY KEY ( intFlightPassengerID )
)


CREATE TABLE TMaintenanceMaintenanceWorkers
(
	 intMaintenanceMaintenanceWorkerID		INTEGER			NOT NULL
	,intMaintenanceID						INTEGER			NOT NULL
	,intMaintenanceWorkerID					INTEGER			NOT NULL
	,intHours								INTEGER			NOT NULL
	,CONSTRAINT TMaintenanceMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceMaintenanceWorkerID )
)

-- --------------------------------------------------------------------------------
--	Step #2 : Establish Referential Integrity 
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TPassengers						TStates						intStateID	
-- 2	TFlightPassenger				TPassengers					intPassengerID
-- 3	TFlights						TPlanes						intPlaneID
-- 4	TFlights						TAirports					intFromAiportID
-- 5	TFlights						TAirports					intToAiportID
-- 6	TPilotFlights					TFlights					intFlightID
-- 7	TAttendantFlights				TFlights					intFlightID
-- 8	TPilotFlights					TPilots						intPilotID
-- 9	TAttendantFlights				TAttendants					intAttendantID
-- 10	TPilots							TPilotRoles					intPilotRoleID
-- 11	TPlanes							TPlaneTypes					intPlaneTypeID
-- 12	TMaintenances					TPlanes						intPlaneID
-- 13	TMaintenanceMaintenanceWorkers	TMaintenance				intMaintenanceID
-- 14	TMaintenanceMaintenanceWorkers	TMaintenanceWorker			intMaintenanceWorkerID
-- 15	TFlightPassenger				TFlights					intFlightID

--1
ALTER TABLE TPassengers ADD CONSTRAINT TPassengers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID )

--2
ALTER TABLE TFlightPassengers ADD CONSTRAINT TPFlightPassengers_TPassengers_FK 
FOREIGN KEY ( intPassengerID ) REFERENCES TPassengers ( intPassengerID )

--3
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes ( intPlaneID )

--4
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TFromAirports_FK 
FOREIGN KEY ( intFromAirportID ) REFERENCES TAirports ( intAirportID )

--5
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TToAirports_FK 
FOREIGN KEY ( intToAirportID ) REFERENCES TAirports ( intAirportID )

--6
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  

--7
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 

--8
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots (intPilotID ) 

--9
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants (intAttendantID )

--10
ALTER TABLE TPilots	 ADD CONSTRAINT TPilots_TPilotRoles_FK 
FOREIGN KEY ( intPilotRoleID ) REFERENCES TPilotRoles (intPilotRoleID )  

--11
ALTER TABLE TPlanes	 ADD CONSTRAINT TPlanes_TPlaneTypes_FK 
FOREIGN KEY ( intPlaneTypeID ) REFERENCES TPlaneTypes (intPlaneTypeID )  

--12
ALTER TABLE TMaintenances	 ADD CONSTRAINT TMaintenances_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes (intPlaneID )  

--13
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenances_FK 
FOREIGN KEY ( intMaintenanceID ) REFERENCES TMaintenances (intMaintenanceID ) 

--14
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenanceWorkers_FK 
FOREIGN KEY ( intMaintenanceWorkerID ) REFERENCES TMaintenanceWorkers (intMaintenanceWorkerID ) 

--15
ALTER TABLE TFlightPassengers	 ADD CONSTRAINT TFlightPassengers_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) 

-- --------------------------------------------------------------------------------
--	Step #3 : Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')


INSERT INTO TPilotRoles( intPilotRoleID, strPilotRole)
VALUES				(1, 'Co-Pilot')
				   ,(2, 'Captain')

				
INSERT INTO TPlaneTypes( intPlaneTypeID, strPlaneType)
VALUES				(1, 'Airbus A350')
				   ,(2, 'Boeing 747-8')
				   ,(3, 'Boeing 767-300F')


INSERT INTO TPlanes( intPlaneID, strPlaneNumber, intPlaneTypeID)
VALUES				(1, '4X887G', 1)
				   ,(2, '5HT78F', 2)
				   ,(3, '5TYY65', 2)
				   ,(4, '4UR522', 1)
				   ,(5, '6OP3PK', 3)
				   ,(6, '67TYHH', 3)


INSERT INTO TAirports( intAirportID, strAirportCity, strAirportCode)
VALUES				(1, 'Cincinnati', 'CVG')
				   ,(2, 'Miami', 'MIA')
				   ,(3, 'Ft. Meyer', 'RSW')
				   ,(4, 'Louisville',  'SDF')
				   ,(5, 'Denver', 'DEN')
				   ,(6, 'Orlando', 'MCO' )


INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail)
VALUES				  (1, 'Knelly', 'Nervious', '321 Elm St.', 'Cincinnati', 1, '45201', '5135553333', 'nnelly@gmail.com')
					 ,(2, 'Orville', 'Waite', '987 Oak St.', 'Cleveland', 1, '45218', '5135556333', 'owright@gmail.com')
					 ,(3, 'Eileen', 'Awnewe', '1569 Windisch Rd.', 'Dayton', 1, '45069', '5135555333', 'eonewe1@yahoo.com')
					 ,(4, 'Bob', 'Eninocean', '44561 Oak Ave.', 'Florence', 2, '45246', '8596663333', 'bobenocean@gmail.com')
					 ,(5, 'Ware', 'Hyjeked', '44881 Pine Ave.', 'Aurora', 3, '45546', '2825553333', 'Hyjekedohmy@gmail.com')
					 ,(6, 'Kay', 'Oss', '4484 Bushfield Ave.', 'Lawrenceburg', 3, '45546', '2825553333', 'wehavekayoss@gmail.com')
UPDATE TPassengers
SET PassengerLoginID = CASE intPassengerID
    WHEN 1 THEN 'passenger1'
    WHEN 2 THEN 'passenger2'
    WHEN 3 THEN 'passenger3'
    WHEN 4 THEN 'passenger4'
    WHEN 5 THEN 'passenger5'
    WHEN 6 THEN 'passenger6'
END,
PassengerPassword = CASE intPassengerID
    WHEN 1 THEN 'p1pass'
    WHEN 2 THEN 'p2pass'
    WHEN 3 THEN 'p3pass'
    WHEN 4 THEN 'p4pass'
    WHEN 5 THEN 'p5pass'
    WHEN 6 THEN 'p6pass'
END,
PassengerDateOfBirth = CASE intPassengerID
    WHEN 1 THEN '01/01/1980'
    WHEN 2 THEN '02/02/1990'
    WHEN 3 THEN '03/03/2000'
    WHEN 4 THEN '04/04/1985'
    WHEN 5 THEN '05/05/1975'
    WHEN 6 THEN '06/06/2018'
END;

INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
VALUES				  (1, 'Tip', 'Seenow', '12121', '1/1/2015', '1/1/2099', '12/1/2014', 1)
					 ,(2, 'Ima', 'Soring', '13322', '1/1/2016', '1/1/2099', '12/1/2015', 1)
					 ,(3, 'Hugh', 'Encharge', '16666', '1/1/2017', '1/1/2099', '12/1/2016', 2)
					 ,(4, 'Iwanna', 'Knapp', '17676', '1/1/2014', '1/1/2015', '12/1/2013', 1)
					 ,(5, 'Rose', 'Ennair', '19909', '1/1/2012', '1/1/2099', '12/1/2011', 2)


INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
VALUES				  (1, 'Miller', 'Tyme', '22121', '1/1/2015', '1/1/2099')
					 ,(2, 'Sherley', 'Ujest', '23322', '1/1/2016', '1/1/2099')
					 ,(3, 'Buhh', 'Biy', '26666', '1/1/2017', '1/1/2099')
					 ,(4, 'Myles', 'Amanie', '27676', '1/1/2014', '1/1/2015')
					 ,(5, 'Walker', 'Toexet', '29909', '1/1/2012', '1/1/2099')


INSERT INTO TMaintenanceWorkers (intMaintenanceWorkerID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateOfCertification)
VALUES				  (1, 'Gressy', 'Nuckles', '32121', '1/1/2015', '1/1/2099', '12/1/2014')
					 ,(2, 'Bolt', 'Izamiss', '33322', '1/1/2016', '1/1/2099', '12/1/2015')
					 ,(3, 'Sharon', 'Urphood', '36666', '1/1/2017', '1/1/2099','12/1/2016')
					 ,(4, 'Ides', 'Racrozed', '37676', '1/1/2014', '1/1/2015','12/1/2013')
					

INSERT INTO TMaintenances (intMaintenanceID, strWorkCompleted, dtmMaintenanceDate, intPlaneID)
VALUES				  (1, 'Fixed Wing', '1/1/2022', 1)
					 ,(2, 'Repaired Flat Tire', '3/1/2022', 2)
					 ,(3, 'Added Wiper Fluid', '4/1/2022', 3)
					 ,(4, 'Tightened Engine to Wing', '5/1/2022', 2)
					 ,(5, '100,000 mile checkup', '3/10/2022', 4)
					 ,(6, 'Replaced Loose Door', '4/10/2022', 6)
					 ,(7, 'Trapped Raccoon in Cargo Hold', '5/1/2022', 6)


INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
VALUES				  (1, '4/1/2022', '111', '10:00:00', '12:00:00', 1, 2, 1200, 2)
					 ,(2, '4/4/2026', '222','13:00:00', '15:00:00', 1, 3, 1000, 2)
					 ,(3, '4/5/2022', '333','15:00:00', '17:00:00', 1, 5, 1200, 3)
					 ,(4, '4/16/2022','444', '10:00:00', '12:00:00', 4, 6, 1100, 3)
					 ,(5, '3/14/2026','555', '18:00:00', '20:00:00', 2, 1, 1200, 3)
					 ,(6, '3/21/2022','666', '19:00:00', '21:00:00', 3, 1, 1000, 1)
					 ,(7, '3/11/2026', '777','20:00:00', '22:00:00', 3, 6, 1400, 4)
					 ,(8, '3/17/2026', '888','09:00:00', '11:00:00', 6, 4, 1100, 5)
					 ,(9, '4/19/2022', '999','08:00:00', '10:00:00', 4, 2, 1000, 6)
					 ,(10, '4/22/2022', '091','10:00:00', '12:00:00', 2, 1, 1200, 6)
					 ,(11, '7/24/2025', '888', '08:00:00', '10:00:00', 1, 2,1212, 3)
					,(12, '7/25/2025', '889', '10:30:00', '13:00:00', 2, 3,11200, 1)
					,(13, '7/26/2025', '890', '14:00:00', '16:00:00', 3, 1,12220, 2);

INSERT INTO TPilotFlights ( intPilotFlightID, intPilotID, intFlightID)
VALUES				 ( 1, 1, 2 )
					,( 2, 1, 3 )
					,( 3, 3, 3 )
					,( 4, 3, 2 )
					,( 5, 5, 1 )
					,( 6, 2, 1 )
					,( 7, 3, 4 )
					,( 8, 2, 4 )
					,( 9, 2, 5 )
					,( 10, 3, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )
					,(13, 1, 11)
					,(14, 2, 12)
					 ,(15, 3, 13)

INSERT INTO TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID)
VALUES				( 1, 1, 2 )
					,( 2, 2, 3 )
					,( 3, 3, 3 )
					,( 4, 4, 2 )
					,( 5, 5, 1 )
					,( 6, 1, 1 )
					,( 7, 2, 4 )
					,( 8, 3, 4 )
					,( 9, 4, 5 )
					,( 10, 5, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )
					,(13, 1, 11)
					,(14, 2, 12)
					,(15, 3, 13)
					

INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat)
VALUES				 ( 1, 1, 1, '1A')
					,( 2, 1, 2, '2A' )
					,( 3, 1, 3, '1B' )
					,( 4, 1, 4, '1C' )
					,( 5, 1, 5, '1D' )
					,( 6, 2, 5, '1A' )
					,( 7, 2, 4, '2A' )
					,( 8, 2, 3, '1B' )
					,( 9, 3, 1, '1B' )
					,( 10, 3, 2, '2A' )
					,( 11, 3, 3, '1B' )
					,( 12, 3, 4, '1C' )
					,( 13, 3, 5, '1D' )
					,( 14, 4, 2, '1A' )
					,( 15, 4, 3, '1B' )
					,( 16, 4, 4, '1C' )
					,( 17, 4, 5, '1D' )
					,( 18, 5, 1, '1A' )
					,( 19, 5, 2, '2A' )
					,( 20, 5, 3, '1B' )
					,( 21, 5, 4, '2B' )
					,( 22, 6, 1, '1A' )
					,( 23, 6, 2, '2A' )
					,( 24, 6, 3, '3A' )
					,(25, 11, 1, '1B')
					,(26, 12, 2, '1C')
					,(27, 13, 3,'2B')
					,(28, 11, 4,'3A')
					,(29, 12, 5,'4C')
					,(30, 13, 6,'1A')

INSERT INTO TMaintenanceMaintenanceWorkers ( intMaintenanceMaintenanceWorkerID, intMaintenanceID, intMaintenanceWorkerID, intHours)
VALUES				 ( 1, 2, 1, 2 )
					,( 2, 4, 1, 3 )
					,( 3, 2, 3, 4 )
					,( 4, 1, 4, 2 )
					,( 5, 3, 4, 2 )
					,( 6, 4, 3, 5 )
					,( 7, 5, 1, 7 )
					,( 8, 6, 1, 2 )
					,( 9, 7, 3, 4 )
					,( 10, 4, 4, 1 )
					,( 11, 3, 3, 4 )
					,( 12, 7, 3, 8 )


				

CREATE PROCEDURE usp_GetCustomerFutureFlights
    @PassengerID INT
AS
BEGIN
    SELECT
        F.strFlightNumber,
        F.dtmFlightDate,
        F.intMilesFlown
    FROM TFlights F
    INNER JOIN TFlightPassengers FP ON F.intFlightID = FP.intFlightID
    WHERE FP.intPassengerID = @PassengerID
      AND F.dtmFlightDate > GETDATE()
    ORDER BY F.dtmFlightDate
END
-----------------------------------------------------------------------
CREATE PROCEDURE usp_TotalPassengers
AS
SELECT COUNT(*) AS TotalPassengers FROM TPassengers
---------------------------------------------------------------------

CREATE PROCEDURE usp_AverageFlightMiles
AS
SELECT AVG(intMilesFlown) AS AverageMiles FROM TFlights
----------------------------------------------------------------------------

CREATE PROCEDURE usp_CustomerFutureFlights
    @PassengerID INT
AS
SELECT F.strFlightNumber, F.dtmFlightDate, F.intMilesFlown
FROM TFlightPassengers FP
JOIN TFlights F ON FP.intFlightID = F.intFlightID
WHERE FP.intPassengerID = intPassengerID AND F.dtmFlightDate > GETDATE()
--------------------------------------------------------------------------------------

CREATE OR ALTER PROCEDURE usp_AttendantMiles
AS
BEGIN
    SELECT
        strFirstName + ' ' + strLastName AS FullName,
        ISNULL(SUM(TFlights.intMilesFlown), 0) AS TotalMiles
    FROM TAttendants
    LEFT JOIN TAttendantFlights ON TAttendants.intAttendantID = TAttendantFlights.intAttendantID
    LEFT JOIN TFlights ON TAttendantFlights.intFlightID = TFlights.intFlightID
    GROUP BY strFirstName, strLastName
    ORDER BY FullName
END;
-------------------------------------------------------------------------------------------
CREATE PROCEDURE usp_GetPilotPastFlights
    @PilotID INT
AS
BEGIN
    SELECT F.strFlightNumber, F.dtmFlightDate, F.intMilesFlown
    FROM TFlights F
    INNER JOIN TPilotFlights PF ON F.intFlightID = PF.intFlightID
    WHERE PF.intPilotID = @PilotID AND F.dtmFlightDate < GETDATE()
    ORDER BY F.dtmFlightDate
END
-------------------------------------------------------------------------------------------------


CREATE PROCEDURE usp_TotalFlights
AS
BEGIN
    SELECT COUNT(*) AS TotalFlights
    FROM TFlightPassengers
END
--------------------------------------------------------------------------------------------------

CREATE PROCEDURE usp_PilotMiles
AS
BEGIN
    SELECT
        strFirstName + ' ' + strLastName AS FullName,
        ISNULL(SUM(TFlights.intMilesFlown), 0) AS TotalMiles
    FROM TPilots
    LEFT JOIN TPilotFlights ON TPilots.intPilotID = TPilotFlights.intPilotID
    LEFT JOIN TFlights ON TPilotFlights.intFlightID = TFlights.intFlightID
    GROUP BY strFirstName, strLastName
    ORDER BY FullName
END;
-------------------------------------------------------------------------------------------------------
CREATE PROCEDURE usp_AddPassenger
    @intPassengerID INT,
    @strFirstName VARCHAR(255),
    @strLastName VARCHAR(255),
    @strAddress VARCHAR(255),
    @strCity VARCHAR(255),
    @intStateID INT,
    @strZip VARCHAR(255),
   @strPhoneNumber VARCHAR(255),
    @strEmail VARCHAR(255)
AS
BEGIN
    BEGIN TRANSACTION

    INSERT INTO TPassengers
        (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail)
    VALUES
        (@intPassengerID, @strFirstName, @strLastName, @strAddress, @strCity, @intStateID, @strZip, @strPhoneNumber, @strEmail)

    COMMIT TRANSACTION
END
GO
--------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE usp_AddPassenger
    @intPassengerID INT,
    @strFirstName VARCHAR(50),
    @strLastName VARCHAR(50),
    @strAddress VARCHAR(100),
    @strCity VARCHAR(50),
    @intStateID INT,
    @strZip VARCHAR(10),
    @strPhoneNumber VARCHAR(15),
    @strEmail VARCHAR(100),
	@PassengerLoginID VARCHAR (50),
	@PassengerPassword VARCHAR (50),
	@PassengerDateOfBirth VARCHAR (100)
AS
BEGIN
    BEGIN TRANSACTION

    INSERT INTO TPassengers
        (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, PassengerLoginID, PassengerPassword, PassengerDateOfBirth)
    VALUES
        (@intPassengerID, @strFirstName, @strLastName, @strAddress, @strCity, @intStateID, @strZip, @strPhoneNumber, @strEmail, @PassengerLoginID, @PassengerPassword, @PassengerDateOfBirth)

    COMMIT TRANSACTION
END
GO

CREATE OR ALTER PROCEDURE usp_AddEmployee
    @EmployeeLoginID  VARCHAR(50),
    @EmployeePassword VARCHAR(50),
    @EmployeeRole     VARCHAR(20),
    @EmployeeID       INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO TEmployee (EmployeeLoginID, EmployeePassword, EmployeeRole, EmployeeID)
    VALUES (@EmployeeLoginID, @EmployeePassword, @EmployeeRole, @EmployeeID);
END
--------------------------------------------------------------------------------------------------


ALTER PROCEDURE usp_UpdatePassenger
    @strFirstName VARCHAR(255),
    @strLastName VARCHAR(255),
    @strAddress VARCHAR(255),
    @strCity VARCHAR(255),
    @intStateID INT,
    @strZip VARCHAR(255),
    @strPhoneNumber VARCHAR(255),
    @strEmail VARCHAR(255),
    @PassengerLoginID VARCHAR(50),
    @PassengerPassword VARCHAR(50),
    @PassengerDateOfBirth VARCHAR(100),
    @intPassengerID INT
AS
BEGIN
    BEGIN TRANSACTION
        UPDATE TPassengers
        SET strFirstName = @strFirstName,
            strLastName = @strLastName,
            strAddress = @strAddress,
            strCity = @strCity,
            intStateID = @intStateID,
            strZip = @strZip,
            strPhoneNumber = @strPhoneNumber,
            strEmail = @strEmail,
            PassengerLoginID = @PassengerLoginID,
            PassengerPassword = @PassengerPassword,
            PassengerDateOfBirth = @PassengerDateOfBirth
        WHERE intPassengerID = @intPassengerID
    COMMIT TRANSACTION
END
---------------------------------------------------------------------------------------------------


CREATE PROCEDURE usp_DeletePilot
    @intPilotID INT
AS
BEGIN
    BEGIN TRANSACTION

    DELETE FROM TPilotFlights WHERE intPilotID = @intPilotID
    DELETE FROM TPilots WHERE intPilotID = @intPilotID

    COMMIT TRANSACTION
END
--------------------------------------------------------------------------------------
ALTER TABLE TPassengers
ADD PassengerLoginID VARCHAR(50),
    PassengerPassword VARCHAR(50),
    PassengerDateOfBirth DATE;

---------------------------------------------------------------------------------------
ALTER TABLE TFlightPassengers ADD FlightCost DECIMAL(10, 2);
----------------------------------------------------------------------------------------------
DROP TABLE TEmployee;

CREATE TABLE TEmployee (
    intEmployeeLoginKey INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeLoginID VARCHAR(50) NOT NULL,
    EmployeePassword VARCHAR(50) NOT NULL,
    EmployeeRole VARCHAR(20) NOT NULL,
    EmployeeID INT
	)
INSERT INTO TEmployee (EmployeeLoginID, EmployeePassword, EmployeeRole, EmployeeID)
VALUES
    ('admin1', 'adminpass', 'Admin', 0),
    ('pilot1', 'pass1', 'Pilot', 1),
    ('pilot2', 'pass2', 'Pilot', 2),
    ('pilot3', 'pass3', 'Pilot', 3),
    ('pilot4', 'pass4', 'Pilot', 4),
    ('pilot5', 'pass5', 'Pilot', 5),
    ('attendant1', 'pass1', 'Attendant', 1),
    ('attendant2', 'pass2', 'Attendant', 2),
    ('attendant3', 'pass3', 'Attendant', 3),
    ('attendant4', 'pass4', 'Attendant', 4),
    ('attendant5', 'pass5', 'Attendant', 5);

CREATE OR ALTER PROCEDURE usp_EmployeeLogin
    @EmployeeLoginID  VARCHAR(50),
    @EmployeePassword VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT EmployeeRole, EmployeeID
    FROM TEmployee
    WHERE EmployeeLoginID = @EmployeeLoginID
      AND EmployeePassword = @EmployeePassword;
END



	--------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE usp_PassengerLogin
    @PassengerLoginID VARCHAR(50),
    @PassengerPassword VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT intPassengerID
    FROM TPassengers
    WHERE PassengerLoginID = @PassengerLoginID
      AND PassengerPassword = @PassengerPassword;
END
----------------------------------------------------------------------------------------------------------
CREATE OR ALTER PROCEDURE usp_UpdatePilot
    @intPilotID INT,
    @strFirstName VARCHAR(255),
    @strLastName VARCHAR(255),
    @strEmployeeID VARCHAR(50),
    @dtmDateOfHire DATE,
    @dtmDateOfTermination DATE,
    @dtmDateOfLicense DATE,
    @intPilotRoleID INT,
    @EmployeeLoginID VARCHAR(50),
    @EmployeePassword VARCHAR(50)
AS
BEGIN
    BEGIN TRANSACTION;

    UPDATE TPilots
    SET strFirstName = @strFirstName,
        strLastName = @strLastName,
        strEmployeeID = @strEmployeeID,
        dtmDateOfHire = @dtmDateOfHire,
        dtmDateOfTermination = @dtmDateOfTermination,
        dtmDateOfLicense = @dtmDateOfLicense,
        intPilotRoleID = @intPilotRoleID
    WHERE intPilotID = @intPilotID;

    UPDATE TEmployee
    SET EmployeeLoginID = @EmployeeLoginID,
        EmployeePassword = @EmployeePassword
    WHERE EmployeeID = @strEmployeeID;

    COMMIT TRANSACTION;
END;
GO
-------------------------------------------------------------------------------------------
ALTER TABLE TFlightPassengers ADD FlightCost decimal(10,2)
----------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE usp_GetFlightDetailsForCost
    @FlightID int
AS
BEGIN
    SELECT
        F.intFlightID,
        F.intMilesFlown,
        P.strPlaneType,
        F.intToAirportID
    FROM TFlights F
    JOIN TPlanes PL ON F.intPlaneID = PL.intPlaneID
    JOIN TPlaneTypes P ON PL.intPlaneTypeID = P.intPlaneTypeID
    WHERE F.intFlightID = @FlightID
END
--------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE usp_CountReservedSeats
    @FlightID int
AS
BEGIN
    SELECT COUNT(*) AS ReservedCount
    FROM TFlightPassengers
    WHERE intFlightID = @FlightID
      AND strSeat = 'Reserved'
END
--------------------------------------------------------------------------------------------------------------------------


CREATE PROCEDURE usp_CountPastFlights
    @PassengerID int,
    @CurrentDate date
AS
BEGIN
    SELECT COUNT(*) AS PastFlights
    FROM TFlightPassengers FP
    JOIN TFlights F ON FP.intFlightID = F.intFlightID
    WHERE FP.intPassengerID = @PassengerID
      AND F.dtmFlightDate < @CurrentDate
END
---------------------------------------------------------------------------------------------------------------------------
IF OBJECT_ID('usp_AddFlight', 'P') IS NOT NULL
DROP PROCEDURE usp_AddFlight
GO

CREATE PROCEDURE usp_AddFlight
	@intFlightID INT,
    @FlightNumber VARCHAR(255),
    @FlightDate DATETIME,
    @TimeOfDeparture TIME,
    @TimeOfLanding TIME,
    @FromAirportID INT,
    @ToAirportID INT,
    @MilesFlown INT,
    @PlaneID INT
AS
BEGIN
    INSERT INTO TFlights (intFlightID, strFlightNumber, dtmFlightDate, dtmTimeOfDeparture, dtmTimeOfLanding,
                          intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
    VALUES (@intFlightID, @FlightNumber, @FlightDate, @TimeOfDeparture, @TimeOfLanding,
            @FromAirportID, @ToAirportID, @MilesFlown, @PlaneID)
END
-----------------------------------------------------------------------------------------------------
SELECT P.intPlaneID,
       P.strPlaneNumber + ' - ' + T.strPlaneType AS PlaneDisplay
FROM TPlanes P
JOIN TPlaneTypes T ON P.intPlaneTypeID = T.intPlaneTypeID
-------------------------------------------------------------------------------------------------
