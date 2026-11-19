CREATE DATABASE IF NOT EXISTS EventConnectDB;
USE EventConnectDB;

CREATE TABLE IF NOT EXISTS Users (
    UserId INT PRIMARY KEY AUTO_INCREMENT,
    FullName VARCHAR(100),
    Email VARCHAR(100) UNIQUE,
    Phone VARCHAR(20),
    Password VARCHAR(100),
    Role VARCHAR(50)
);

CREATE TABLE IF NOT EXISTS Vendors (
    VendorId INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100),
    ServiceType VARCHAR(100),
    PriceMin DECIMAL(18,2),
    PriceMax DECIMAL(18,2),
    Location VARCHAR(100),
    OwnerEmail VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS Events (
    EventId INT PRIMARY KEY AUTO_INCREMENT,
    Title VARCHAR(100),
    EventDate DATE,
    Budget DECIMAL(18,2)
);

CREATE TABLE IF NOT EXISTS Guests (
    GuestId INT PRIMARY KEY AUTO_INCREMENT,
    EventId INT,
    FullNames VARCHAR(100),
    Email VARCHAR(100),
    Category VARCHAR(50) DEFAULT 'Regular',
    FOREIGN KEY (EventId) REFERENCES Events(EventId)
);

CREATE TABLE IF NOT EXISTS Bookings (
    BookingId INT PRIMARY KEY AUTO_INCREMENT,
    EventId INT,
    VendorId INT,
    PriceOffered DECIMAL(18,2) DEFAULT 0,
    Status VARCHAR(50) DEFAULT 'Pending',
    Message TEXT,
    VendorResponse TEXT,
    FOREIGN KEY (EventId) REFERENCES Events(EventId),
    FOREIGN KEY (VendorId) REFERENCES Vendors(VendorId)
);
