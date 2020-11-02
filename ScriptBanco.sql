

CREATE TABLE Truck
( TruckId INT IDENTITY(1,1) PRIMARY KEY,
  Model VARCHAR(50) NOT NULL,
  Brand VARCHAR(50) NOT NULL,
  License VARCHAR(50) NOT NULL,
  Axle INT,
);



CREATE TABLE Address
( AddressId INT IDENTITY(1,1) PRIMARY KEY,
  Street VARCHAR(100) NOT NULL,
  Coordenates VARCHAR(50) NOT NULL,
  Number int,
  City VARCHAR(50),
);

CREATE TABLE TruckDriver
( Id INT IDENTITY(1,1) PRIMARY KEY,
  Name VARCHAR(50) NOT NULL,
  LastName VARCHAR(50),
  TruckId int NOT NULL,
  AddressId int NOT NULL,
    CONSTRAINT FK_Trucker_Truck
    FOREIGN KEY (TruckId)
    REFERENCES Truck (TruckId),
	CONSTRAINT FK_Trucker_Address
    FOREIGN KEY (AddressId)
    REFERENCES Address (AddressId)
);