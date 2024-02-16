create database hotel

use hotel;

CREATE TABLE public."Hotel" (
  "IdHotel" SERIAL PRIMARY KEY,
  "Name" varchar(255) NOT NULL,
  "Location" varchar(255) NOT NULL,
  "Description" text NULL,
  "Enabled" bool NOT NULL DEFAULT true
);

CREATE TABLE public."Room" (
  "IdRoom" SERIAL PRIMARY KEY,
  "IdHotel" int NOT NULL REFERENCES public."Hotel"("IdHotel"),
  "Type" varchar(50) NOT NULL,
  "CostBase" decimal(18,2) NOT NULL,
  "Tax" decimal(18,2) NOT NULL,
  "LocationInHotel" varchar(255) NOT NULL,
  "Enabled" bool NOT NULL DEFAULT true
);


CREATE TABLE public."Reservation" (
  "IdReservation" SERIAL PRIMARY KEY,
  "IdRoom" int NOT NULL REFERENCES public."Room"("IdRoom"),
  "EntryDate" date NOT NULL,
  "DepartureDate" date NOT NULL,
  "QuantityPersons" int NOT NULL,
  "Total" decimal(18,2) NOT NULL,
  "Status" varchar(50) NOT NULL
);

CREATE TABLE public."Guest" (
  "IdGuest" SERIAL PRIMARY KEY,
  "IdReservation" int NOT NULL REFERENCES public."Reservation"("IdReservation"),
  "FullName" varchar(255) NOT NULL,
  "DateBirth" date NOT NULL,
  "Gender" varchar(50) NOT NULL,
  "DocumentType" varchar(50) NOT NULL,
  "DocumentNumber" varchar(50) NOT NULL,
  "Email" varchar(255) NOT NULL,
  "Phone" varchar(50) NOT NULL
);

CREATE TABLE public."ContactEmergency" (
  "IdContactEmergency" SERIAL PRIMARY KEY,
  "IdReservation" int NOT NULL REFERENCES public."Reservation"("IdReservation"),
  "FullName" varchar(255) NOT NULL,
  "Phone" varchar(50) NOT NULL
);
