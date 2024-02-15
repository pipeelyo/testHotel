create database hotel;

use hotel;

CREATE TABLE Hotel (
  IdHotel int PRIMARY KEY IDENTITY,
  Name varchar(255) NOT NULL,
  Location varchar(255) NOT NULL,
  Description text NULL,
  Enabled bit NOT NULL DEFAULT 1
);

CREATE TABLE Room (
  IdRoom int PRIMARY KEY IDENTITY,
  IdHotel int FOREIGN KEY REFERENCES Hotel(IdHotel),
  Type varchar(50) NOT NULL,
  CostBase decimal(18,2) NOT NULL,
  Tax decimal(18,2) NOT NULL,
  LocationInHotel varchar(255) NOT NULL,
  Enabled bit NOT NULL DEFAULT 1
);

CREATE TABLE Reservation (
  IdReservation int PRIMARY KEY IDENTITY,
  IdRoom int FOREIGN KEY REFERENCES Room(IdRoom),
  EntryDate date NOT NULL,
  DateDeparture date NOT NULL,
  QuantityPersons int NOT NULL,
  Total decimal(18,2) NOT NULL,
  Status varchar(50) NOT NULL
);

CREATE TABLE Guest (
  IdGuest int PRIMARY KEY IDENTITY,
  IdReservation int FOREIGN KEY REFERENCES Reservation(IdReservation),
  FullName varchar(255) NOT NULL,
  DateBirth date NOT NULL,
  Gender varchar(50) NOT NULL,
  DocumentType varchar(50) NOT NULL,
  DocumentNumber varchar(50) NOT NULL,
  Email varchar(255) NOT NULL,
  Phone varchar(50) NOT NULL
);

CREATE TABLE ContactEmergency (
  IdContactEmergency int PRIMARY KEY IDENTITY,
  IdReservation int FOREIGN KEY REFERENCES Reservation(IdReservation),
  FullName varchar(255) NOT NULL,
  Phone varchar(50) NOT NULL
);
