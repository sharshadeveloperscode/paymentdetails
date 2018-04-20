-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 182.50.133.78    Database: dbsalondev
-- ------------------------------------------------------
-- Server version	5.5.43-37.2-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `tblArea`
--

DROP TABLE IF EXISTS `tblArea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblArea` (
  `AreaId` int(11) NOT NULL AUTO_INCREMENT,
  `AreaName` varchar(100) DEFAULT NULL,
  `CityId` int(11) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `PostCode` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`AreaId`),
  KEY `CityId` (`CityId`)
) ENGINE=MyISAM AUTO_INCREMENT=46 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblBusinessHours`
--

DROP TABLE IF EXISTS `tblBusinessHours`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblBusinessHours` (
  `BusinessHoursId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonsId` int(11) DEFAULT NULL,
  `Day` varchar(100) DEFAULT NULL,
  `OpeningHours` int(11) DEFAULT NULL,
  `ClosingHours` int(11) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BusinessHoursId`),
  KEY `SalonsId` (`SalonsId`),
  KEY `OpeningHours` (`OpeningHours`),
  KEY `ClosingHours` (`ClosingHours`)
) ENGINE=MyISAM AUTO_INCREMENT=1374 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblBusinessType`
--

DROP TABLE IF EXISTS `tblBusinessType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblBusinessType` (
  `BusinessTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `BusinessTypeName` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BusinessTypeId`),
  UNIQUE KEY `BusinessTypeName` (`BusinessTypeName`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblCart`
--

DROP TABLE IF EXISTS `tblCart`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblCart` (
  `CartId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonServicesId` int(11) DEFAULT NULL,
  `SalonsId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `EmployeeServicesId` int(11) DEFAULT NULL,
  `BookingDate` date DEFAULT NULL,
  `BookingTime` varchar(45) DEFAULT NULL,
  `Chairs` int(11) DEFAULT NULL,
  PRIMARY KEY (`CartId`)
) ENGINE=MyISAM AUTO_INCREMENT=58 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblCategory`
--

DROP TABLE IF EXISTS `tblCategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblCategory` (
  `CategoryId` int(11) NOT NULL AUTO_INCREMENT,
  `Category` varchar(100) NOT NULL,
  `ImageName` varchar(100) NOT NULL,
  `ImagePath` varchar(100) NOT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  PRIMARY KEY (`CategoryId`),
  UNIQUE KEY `Category_UNIQUE` (`Category`)
) ENGINE=MyISAM AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblCity`
--

DROP TABLE IF EXISTS `tblCity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblCity` (
  `CityId` int(11) NOT NULL AUTO_INCREMENT,
  `CityName` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`CityId`),
  UNIQUE KEY `CityName` (`CityName`)
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblClasses`
--

DROP TABLE IF EXISTS `tblClasses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblClasses` (
  `ClassId` int(11) NOT NULL AUTO_INCREMENT,
  `ClassName` varchar(45) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`ClassId`),
  UNIQUE KEY `ClassName_UNIQUE` (`ClassName`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblCleanUpTime`
--

DROP TABLE IF EXISTS `tblCleanUpTime`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblCleanUpTime` (
  `CleanUpTimeId` int(11) NOT NULL AUTO_INCREMENT,
  `CleanUpTime` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`CleanUpTimeId`),
  UNIQUE KEY `CleanUpTime_UNIQUE` (`CleanUpTime`)
) ENGINE=MyISAM AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblComment`
--

DROP TABLE IF EXISTS `tblComment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblComment` (
  `CommentId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonReviewsId` int(11) DEFAULT NULL,
  `Comment` text,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` date DEFAULT NULL,
  PRIMARY KEY (`CommentId`),
  KEY `SalonReviewsId` (`SalonReviewsId`)
) ENGINE=MyISAM AUTO_INCREMENT=47 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblCustomers`
--

DROP TABLE IF EXISTS `tblCustomers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblCustomers` (
  `CustomerId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(100) NOT NULL,
  `LastName` varchar(100) NOT NULL,
  `ProfileName` varchar(100) NOT NULL,
  `MemberTypeId` int(11) NOT NULL,
  `PostalCode` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Note` longtext,
  `Gender` int(11) NOT NULL,
  `Newsletter` int(11) NOT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `Image` varchar(100) DEFAULT NULL,
  `ImagePath` varchar(500) DEFAULT NULL,
  `PhoneNumber` varchar(45) DEFAULT NULL,
  `Address` longtext,
  PRIMARY KEY (`CustomerId`),
  KEY `FK_UserId` (`UserId`)
) ENGINE=MyISAM AUTO_INCREMENT=440 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblDiscount`
--

DROP TABLE IF EXISTS `tblDiscount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblDiscount` (
  `DiscountId` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryId` int(11) DEFAULT NULL,
  `SalonsId` int(11) DEFAULT NULL,
  `Session` varchar(30) DEFAULT NULL,
  `SessionStart` varchar(30) DEFAULT NULL,
  `SessionEnd` varchar(30) DEFAULT NULL,
  `Monday` varchar(30) DEFAULT NULL,
  `TuesDay` varchar(30) DEFAULT NULL,
  `WednesDay` varchar(30) DEFAULT NULL,
  `ThursDay` varchar(30) DEFAULT NULL,
  `FriDay` varchar(30) DEFAULT NULL,
  `SaturDay` varchar(30) DEFAULT NULL,
  `SunDay` varchar(30) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `UpdatedDate` date DEFAULT NULL,
  PRIMARY KEY (`DiscountId`),
  KEY `CategoryId` (`CategoryId`),
  KEY `SalonsId` (`SalonsId`)
) ENGINE=MyISAM AUTO_INCREMENT=241 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblDuration`
--

DROP TABLE IF EXISTS `tblDuration`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblDuration` (
  `DurationId` int(11) NOT NULL AUTO_INCREMENT,
  `Duration` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`DurationId`),
  UNIQUE KEY `Duration_UNIQUE` (`Duration`)
) ENGINE=MyISAM AUTO_INCREMENT=62 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblEmailTemplate`
--

DROP TABLE IF EXISTS `tblEmailTemplate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblEmailTemplate` (
  `TemplateTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `TemplateType` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` date DEFAULT NULL,
  PRIMARY KEY (`TemplateTypeId`)
) ENGINE=MyISAM AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblEmpTreatment`
--

DROP TABLE IF EXISTS `tblEmpTreatment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblEmpTreatment` (
  `SalonServicesId` int(11) DEFAULT NULL,
  `SalonEmployeesId` int(11) DEFAULT NULL,
  `EmployeeName` varchar(25) DEFAULT NULL,
  `TreatmentTypeId` varchar(50) DEFAULT NULL,
  `BusinessName` varchar(50) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblEmployeeLeaves`
--

DROP TABLE IF EXISTS `tblEmployeeLeaves`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblEmployeeLeaves` (
  `LeaveId` int(11) NOT NULL AUTO_INCREMENT,
  `StartDate` datetime DEFAULT NULL,
  `StartTime` int(11) DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `EndTime` int(11) DEFAULT NULL,
  `SalonEmployeesId` int(11) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `Comments` longtext,
  PRIMARY KEY (`LeaveId`),
  KEY `SalonEmployeesId_idx` (`SalonEmployeesId`)
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblEmployeeServices`
--

DROP TABLE IF EXISTS `tblEmployeeServices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblEmployeeServices` (
  `EmployeeServicesId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonServicesId` int(11) DEFAULT NULL,
  `SalonEmployeesId` int(11) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`EmployeeServicesId`),
  KEY `SalonServicesId` (`SalonServicesId`),
  KEY `SalonEmployeesId` (`SalonEmployeesId`)
) ENGINE=MyISAM AUTO_INCREMENT=665 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblEndTime`
--

DROP TABLE IF EXISTS `tblEndTime`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblEndTime` (
  `EndTimeId` int(11) NOT NULL AUTO_INCREMENT,
  `EndTime` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`EndTimeId`)
) ENGINE=MyISAM AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblFavouriteSalonService`
--

DROP TABLE IF EXISTS `tblFavouriteSalonService`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblFavouriteSalonService` (
  `FavId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonServicesId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`FavId`),
  KEY `SalonServicesId` (`SalonServicesId`)
) ENGINE=MyISAM AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblFavouriteSalons`
--

DROP TABLE IF EXISTS `tblFavouriteSalons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblFavouriteSalons` (
  `FavId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonsId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`FavId`),
  KEY `SalonsId` (`SalonsId`)
) ENGINE=MyISAM AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblInvoice`
--

DROP TABLE IF EXISTS `tblInvoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblInvoice` (
  `InvoiceId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonsId` varchar(100) DEFAULT NULL,
  `Month` varchar(20) DEFAULT NULL,
  `Year` varchar(20) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` date DEFAULT NULL,
  `Period1` varchar(10) DEFAULT NULL,
  `Period2` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`InvoiceId`)
) ENGINE=MyISAM AUTO_INCREMENT=228 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblManageYourBooking`
--

DROP TABLE IF EXISTS `tblManageYourBooking`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblManageYourBooking` (
  `BookingsId` int(11) NOT NULL AUTO_INCREMENT,
  `BookingsName` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`BookingsId`),
  UNIQUE KEY `BookingsName` (`BookingsName`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblMemberType`
--

DROP TABLE IF EXISTS `tblMemberType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblMemberType` (
  `MemberTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `MemberTypeName` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`MemberTypeId`),
  UNIQUE KEY `MemberTypeName` (`MemberTypeName`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblPages`
--

DROP TABLE IF EXISTS `tblPages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblPages` (
  `PageID` int(11) NOT NULL AUTO_INCREMENT,
  `PageName` varchar(50) DEFAULT NULL,
  `MenuName` varchar(50) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `UpdatedBy` varchar(50) DEFAULT NULL,
  `PageDisplayName` varchar(50) DEFAULT NULL,
  `Display` char(1) DEFAULT NULL,
  PRIMARY KEY (`PageID`)
) ENGINE=InnoDB AUTO_INCREMENT=118 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblPayments`
--

DROP TABLE IF EXISTS `tblPayments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblPayments` (
  `PaymentsId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `PaymentType` varchar(100) DEFAULT NULL,
  `PaymentStatus` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `UpdatedDate` date DEFAULT NULL,
  `OriginalAmount` int(11) DEFAULT NULL,
  `DiscountAmount` int(11) DEFAULT NULL,
  `PayableAmount` int(11) DEFAULT NULL,
  `CouponCode` varchar(100) DEFAULT NULL,
  `VoucherTypeId` int(11) DEFAULT NULL,
  `GiftcardId` int(11) DEFAULT NULL,
  `Barcode` longtext,
  PRIMARY KEY (`PaymentsId`),
  KEY `UserId` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=3110 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblPolicy`
--

DROP TABLE IF EXISTS `tblPolicy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblPolicy` (
  `PolicyId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonsId` int(11) DEFAULT NULL,
  `PayAtVenue` int(11) DEFAULT NULL,
  `NeedBookingConfirmation` int(11) DEFAULT NULL,
  `CancellationPolicy` varchar(30) DEFAULT NULL,
  `BookingleadtimeforAppointments` varchar(30) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` int(11) DEFAULT NULL,
  `EvoucherCancellation` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`PolicyId`),
  KEY `SalonsId` (`SalonsId`)
) ENGINE=MyISAM AUTO_INCREMENT=67 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblPopularity`
--

DROP TABLE IF EXISTS `tblPopularity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblPopularity` (
  `PopularityId` int(11) NOT NULL AUTO_INCREMENT,
  `Popularity` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `PLimit` int(11) DEFAULT NULL,
  PRIMARY KEY (`PopularityId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblPricingLevel`
--

DROP TABLE IF EXISTS `tblPricingLevel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblPricingLevel` (
  `PricingLevelId` int(11) NOT NULL AUTO_INCREMENT,
  `PricingLevel` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`PricingLevelId`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblPricingType`
--

DROP TABLE IF EXISTS `tblPricingType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblPricingType` (
  `PricingTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `PricingType` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`PricingTypeId`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblReasonforSigningup`
--

DROP TABLE IF EXISTS `tblReasonforSigningup`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblReasonforSigningup` (
  `SigningId` int(11) NOT NULL AUTO_INCREMENT,
  `SigningupName` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SigningId`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblRole`
--

DROP TABLE IF EXISTS `tblRole`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblRole` (
  `RoleId` int(11) NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(50) NOT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  PRIMARY KEY (`RoleId`),
  UNIQUE KEY `RoleName_UNIQUE` (`RoleName`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblSalonCheckout`
--

DROP TABLE IF EXISTS `tblSalonCheckout`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblSalonCheckout` (
  `SalonCheckoutId` int(11) NOT NULL AUTO_INCREMENT,
  `EmployeeServicesId` int(11) DEFAULT NULL,
  `BookingDate` date DEFAULT NULL,
  `BookingTime` varchar(100) DEFAULT NULL,
  `PaymentType` varchar(100) DEFAULT NULL,
  `PaymentStatus` varchar(100) DEFAULT NULL,
  `BookingsId` varchar(200) DEFAULT NULL,
  `PaymentsId` int(11) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdateBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `SalonsId` int(11) DEFAULT NULL,
  `SalonServicesId` int(11) DEFAULT NULL,
  `tblSalonCheckoutcol` varchar(45) NOT NULL,
  `Isthisforyou` int(11) DEFAULT NULL,
  `ReferenceName` varchar(100) DEFAULT NULL,
  `BookingType` varchar(45) DEFAULT NULL,
  `EvoucherNumber` varchar(200) DEFAULT NULL,
  `ServicePrice` varchar(45) DEFAULT NULL,
  `Chairs` int(11) DEFAULT NULL,
  PRIMARY KEY (`SalonCheckoutId`,`tblSalonCheckoutcol`),
  KEY `EmployeeServicesId` (`EmployeeServicesId`),
  KEY `PaymentsId` (`PaymentsId`),
  KEY `SalonsId_idx` (`SalonsId`),
  KEY `SalonServicesId_idx` (`SalonServicesId`)
) ENGINE=InnoDB AUTO_INCREMENT=2908 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblSalonEmployees`
--

DROP TABLE IF EXISTS `tblSalonEmployees`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblSalonEmployees` (
  `SalonEmployeesId` int(11) NOT NULL AUTO_INCREMENT,
  `EmployeeName` varchar(100) DEFAULT NULL,
  `PricingLevel` varchar(100) DEFAULT NULL,
  `JobTitle` varchar(100) DEFAULT NULL,
  `Phone` varchar(100) DEFAULT NULL,
  `Gender` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `StartDate` datetime DEFAULT NULL,
  `StartTime` varchar(100) DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `EndTime` varchar(100) DEFAULT NULL,
  `About` longtext,
  `SalonsId` int(11) DEFAULT NULL,
  `Image` varchar(100) DEFAULT NULL,
  `ImagePath` varchar(200) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `DOB` date DEFAULT NULL,
  `DOJ` date DEFAULT NULL,
  PRIMARY KEY (`SalonEmployeesId`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  KEY `SalonsId` (`SalonsId`)
) ENGINE=MyISAM AUTO_INCREMENT=203 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblSalonImage`
--

DROP TABLE IF EXISTS `tblSalonImage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblSalonImage` (
  `SalonImageId` int(11) NOT NULL AUTO_INCREMENT,
  `Image` varchar(100) DEFAULT NULL,
  `ImagePath` varchar(100) DEFAULT NULL,
  `SalonsId` int(11) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`SalonImageId`),
  KEY `SalonsId` (`SalonsId`)
) ENGINE=MyISAM AUTO_INCREMENT=440 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblSalonReviews`
--

DROP TABLE IF EXISTS `tblSalonReviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblSalonReviews` (
  `SalonReviewsId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonsId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `TreatmnetRating` varchar(30) DEFAULT NULL,
  `Comment` varchar(1000) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` date DEFAULT NULL,
  `OverallSatisfaction` decimal(10,1) DEFAULT NULL,
  `Ambience` decimal(10,1) DEFAULT NULL,
  `Staff` decimal(10,1) DEFAULT NULL,
  `Cleanliness` decimal(10,1) DEFAULT NULL,
  `Value` decimal(10,1) DEFAULT NULL,
  `Type` varchar(45) DEFAULT NULL,
  `SalonServiceId` int(11) DEFAULT NULL,
  `EmployeeId` int(11) DEFAULT NULL,
  PRIMARY KEY (`SalonReviewsId`),
  KEY `SalonsId` (`SalonsId`),
  KEY `UserId` (`UserId`)
) ENGINE=MyISAM AUTO_INCREMENT=70 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblSalonServiceReviews`
--

DROP TABLE IF EXISTS `tblSalonServiceReviews`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblSalonServiceReviews` (
  `SalonServiceReviewsId` int(11) NOT NULL AUTO_INCREMENT,
  `ServiceTitle` varchar(50) DEFAULT NULL,
  `ServiceRating` decimal(10,1) DEFAULT NULL,
  `SalonsId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `SalonReviewsId` int(11) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `UpdatedDate` date DEFAULT NULL,
  `SalonServicesId` int(11) DEFAULT NULL,
  PRIMARY KEY (`SalonServiceReviewsId`),
  KEY `SalonReviewsId` (`SalonReviewsId`)
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblSalonServices`
--

DROP TABLE IF EXISTS `tblSalonServices`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblSalonServices` (
  `SalonServicesId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonsId` int(11) DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL,
  `TreatmentTypeId` varchar(100) DEFAULT NULL,
  `TreatmentTitleId` int(11) DEFAULT NULL,
  `PricingTypeId` int(11) DEFAULT NULL,
  `DurationId` int(11) DEFAULT NULL,
  `Price` varchar(100) DEFAULT NULL,
  `Sale` varchar(100) DEFAULT NULL,
  `CleanUpTime` int(11) DEFAULT NULL,
  `Description` longtext,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `featuredServices` int(11) DEFAULT NULL,
  `ImagePath` longtext,
  PRIMARY KEY (`SalonServicesId`),
  KEY `CategoryId` (`CategoryId`),
  KEY `TreatmentTypeId` (`TreatmentTypeId`),
  KEY `DurationId` (`DurationId`),
  KEY `SalonsId` (`SalonsId`)
) ENGINE=MyISAM AUTO_INCREMENT=363 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblSalons`
--

DROP TABLE IF EXISTS `tblSalons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblSalons` (
  `SalonsId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `BusinessName` varchar(100) NOT NULL,
  `BusinessType` int(11) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `PhoneNumber` varchar(100) NOT NULL,
  `Address` longtext NOT NULL,
  `MemberTypeId` int(11) NOT NULL,
  `PostalCode` varchar(100) NOT NULL,
  `CityId` int(11) NOT NULL,
  `ManageYourBookings` int(11) NOT NULL,
  `ReasonForSigningUp` int(11) NOT NULL,
  `Note` longtext,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CountryId` int(11) DEFAULT NULL,
  `SalonsUniqueId` varchar(100) DEFAULT NULL,
  `Website` varchar(100) DEFAULT NULL,
  `GoogleMaps` longtext,
  `Image` longtext,
  `ImagePath` longtext,
  `AreaId` int(11) NOT NULL,
  `FrontendStatus` int(11) DEFAULT NULL,
  `Noofchairs` int(11) DEFAULT NULL,
  `Available` int(11) DEFAULT '0',
  `Popularity` int(11) DEFAULT NULL,
  `ClassId` int(11) DEFAULT NULL,
  PRIMARY KEY (`SalonsId`),
  UNIQUE KEY `Email_UNIQUE` (`Email`),
  KEY `UserId` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=262 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblSample`
--

DROP TABLE IF EXISTS `tblSample`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblSample` (
  `SampleId` int(11) NOT NULL AUTO_INCREMENT,
  `EmailId` varchar(50) DEFAULT NULL,
  `Phonenumber` varchar(50) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` date DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` date DEFAULT NULL,
  PRIMARY KEY (`SampleId`),
  UNIQUE KEY `EmailId` (`EmailId`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblSaveForLater`
--

DROP TABLE IF EXISTS `tblSaveForLater`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblSaveForLater` (
  `SaveForLaterId` int(11) NOT NULL AUTO_INCREMENT,
  `SalonServicesId` int(11) DEFAULT NULL,
  `SalonsId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `EmployeeServicesId` int(11) DEFAULT NULL,
  `BookingDate` date DEFAULT NULL,
  `BookingTime` varchar(45) DEFAULT NULL,
  `Chairs` int(11) DEFAULT NULL,
  PRIMARY KEY (`SaveForLaterId`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblStartPage`
--

DROP TABLE IF EXISTS `tblStartPage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblStartPage` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` int(11) DEFAULT NULL,
  `PageID` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `UpdatedBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `RoleId_idx` (`RoleId`),
  KEY `PageID_idx` (`PageID`)
) ENGINE=MyISAM AUTO_INCREMENT=26 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblStartTime`
--

DROP TABLE IF EXISTS `tblStartTime`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblStartTime` (
  `StartTimeId` int(11) NOT NULL AUTO_INCREMENT,
  `StartTime` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`StartTimeId`)
) ENGINE=MyISAM AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblTest`
--

DROP TABLE IF EXISTS `tblTest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblTest` (
  `TestId` int(11) NOT NULL AUTO_INCREMENT,
  `Image` varchar(50) DEFAULT NULL,
  `ImagePath` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`TestId`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblTreatmentTitle`
--

DROP TABLE IF EXISTS `tblTreatmentTitle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblTreatmentTitle` (
  `TreatmentTitleId` int(11) NOT NULL AUTO_INCREMENT,
  `TreatmentTitle` varchar(100) DEFAULT NULL,
  `ImageName` varchar(100) DEFAULT NULL,
  `ImagePath` varchar(100) DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`TreatmentTitleId`),
  KEY `CategoryId` (`CategoryId`)
) ENGINE=MyISAM AUTO_INCREMENT=44 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblTreatmentType`
--

DROP TABLE IF EXISTS `tblTreatmentType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblTreatmentType` (
  `TreatmentTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `TreatmentTitleId` int(11) DEFAULT NULL,
  `TreatmentType` varchar(100) NOT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  PRIMARY KEY (`TreatmentTypeId`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblUserPermissions`
--

DROP TABLE IF EXISTS `tblUserPermissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblUserPermissions` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) DEFAULT NULL,
  `PageID` int(11) DEFAULT NULL,
  `View` char(1) DEFAULT NULL,
  `Insertion` char(1) DEFAULT NULL,
  `Edit` char(1) DEFAULT NULL,
  `Deletion` char(1) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `CreatedBy` varchar(50) DEFAULT NULL,
  `UpdatedBy` varchar(50) DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `UserId_idx` (`UserId`),
  KEY `PageID_idx` (`PageID`)
) ENGINE=MyISAM AUTO_INCREMENT=17884 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblUsers`
--

DROP TABLE IF EXISTS `tblUsers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblUsers` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) DEFAULT NULL,
  `RoleId` int(11) DEFAULT NULL,
  `UserName` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  `MobileNumber` varchar(100) DEFAULT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `UpdatedDate` date DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `DepartmentId` int(11) DEFAULT NULL,
  `OTP` varchar(45) DEFAULT NULL,
  `LoginType` varchar(45) DEFAULT NULL,
  `ProfilePicture` longtext,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `UserId` (`UserId`),
  UNIQUE KEY `Email` (`Email`),
  UNIQUE KEY `UserName_UNIQUE` (`UserName`),
  UNIQUE KEY `MobileNumber_UNIQUE` (`MobileNumber`),
  KEY `RoleId` (`RoleId`)
) ENGINE=InnoDB AUTO_INCREMENT=947 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblVoucherType`
--

DROP TABLE IF EXISTS `tblVoucherType`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblVoucherType` (
  `VoucherTypeId` int(11) NOT NULL AUTO_INCREMENT,
  `CouponName` varchar(100) DEFAULT NULL,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `CouponCode` varchar(100) DEFAULT NULL,
  `FromDate` date DEFAULT NULL,
  `ToDate` date DEFAULT NULL,
  `DiscountAmount` int(11) DEFAULT NULL,
  `DiscountType` varchar(100) DEFAULT NULL,
  `Salons` varchar(200) DEFAULT NULL,
  `UsersAccess` int(11) DEFAULT NULL,
  `Image` varchar(100) DEFAULT NULL,
  `ImagePath` varchar(300) DEFAULT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `UserType` varchar(100) DEFAULT NULL,
  `MinimumAmount` int(11) DEFAULT NULL,
  `Amount` int(11) DEFAULT NULL,
  `Quantity` varchar(50) DEFAULT NULL,
  `Email` varchar(30) DEFAULT NULL,
  `Address` varchar(50) DEFAULT NULL,
  `TotalAmount` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `VoucherType` varchar(30) DEFAULT NULL,
  `Status` int(11) DEFAULT NULL,
  `GiftCardName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`VoucherTypeId`)
) ENGINE=MyISAM AUTO_INCREMENT=133 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `tblemailTemplateTypes`
--

DROP TABLE IF EXISTS `tblemailTemplateTypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblemailTemplateTypes` (
  `TemplateId` int(11) NOT NULL AUTO_INCREMENT,
  `TemplateName` varchar(100) DEFAULT NULL,
  `Template` text,
  `IsActive` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `TemplateTypeId` int(11) DEFAULT NULL,
  PRIMARY KEY (`TemplateId`),
  KEY `TemplateTypeId_idx` (`TemplateTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping routines for database 'dbsalondev'
--
/*!50003 DROP PROCEDURE IF EXISTS `Sp_GetPopularSalons` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`dbsalonuser`@`%` PROCEDURE `Sp_GetPopularSalons`()
BEGIN
DECLARE popular INT;
DECLARE limits INT;
set popular=(select Popularity as popular from tblPopularity where PopularityId=1);
set limits=(select p.PLimit as limits from tblPopularity p where p.PopularityId=1);
if popular=1 then
SELECT *, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Reviews FROM tblSalons s WHERE s.IsActive = '1' order by Reviews desc limit limits;
else
SELECT *, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Reviews FROM tblSalons s WHERE s.IsActive = '1' order by s.Popularity desc limit limits;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_Get_Salons_By_Search` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`dbsalonuser`@`%` PROCEDURE `Sp_Get_Salons_By_Search`(in Id  int,Type nvarchar(50))
BEGIN
if Type="Salon" then
select * from tblSalons where IsActive=1 and SalonsId=Id;
else if Type="Area" then
select * from tblSalons where IsActive=1 and AreaId=Id;
else if Type="Service" then
select * from tblSalons s inner join tblSalonServices ss on s.SalonsId=ss.SalonsId inner join TreatmentTitle t on t.TreatmentTitleId=ss.TreatmentTitleId where s.IsActive=1 and t.TreatmentTitleId=Id;
end if;
end if;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_SalonsFilterSearch` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`dbsalonuser`@`%` PROCEDURE `Sp_SalonsFilterSearch`(in startprice varchar(50),endprice varchar(50),dayname varchar(50),city int,chairs varchar(50),class varchar(50))
BEGIN
select distinct s.*,f.*, IFNULL((SELECT AVG(OverallSatisfaction) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Rating, IFNULL((SELECT COUNT(*) FROM tblSalonReviews WHERE IsActive = 1 AND SalonsId = s.SalonsId),0) AS Reviews from tblSalons s inner join tblBusinessHours b on b.SalonsId=s.SalonsId inner join tblSalonServices ss on ss.SalonsId=s.SalonsId left outer join tblFavouriteSalons f on s.SalonsId=f.SalonsId where s.IsActive=1 and ss.IsActive=1 and ss.Price between ifnull(startprice,0) and ifnull(endprice,9000) and ((b.Day=dayname or dayname is null) and (s.CityId=city or city is null) and (s.Noofchairs=chairs or chairs is null) and (s.ClassId=class or class is null));
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_SearchAll` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`dbsalonuser`@`%` PROCEDURE `Sp_SearchAll`(in Name nvarchar(100))
BEGIN
select SalonsId as Id,BusinessName as Name,'Salon' as Type from tblSalons where BusinessName like concat('%',Name,'%')
union
select AreaId as Id,AreaName as Name,'Area' as Type from tblArea where AreaName like concat('%',Name,'%')
union
select TreatmentTitleId as Id,TreatmentTitle as Name,'Service' as Type from tblTreatmentTitle where TreatmentTitle like concat('%',Name,'%');
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_UpdateUserPermissions` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`dbsalonuser`@`%` PROCEDURE `Sp_UpdateUserPermissions`(IN PermissionId INT,PageID INT,UserId INT,View char(1) ,Insertion bit(1),Edit bit(1),Deletion bit(1))
BEGIN
set PermissionId=(select count(*) from tblUserPermissions where tblUserPermissions.UserId=UserId and tblUserPermissions.PageID=PageID);
if PermissionId=0 then
insert into tblUserPermissions(UserId,PageID,View,Insertion,Edit,Deletion,CreatedDate,CreatedBy)values(UserId,PageID,View,Insertion,Edit,Deletion,Curdate(),'Admin');
else
update tblUserPermissions set View=View,Insertion=Insertion,Edit=Edit,Deletion=Deletion where ID=PermissionId;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `Sp_UserPermissions` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = '' */ ;
DELIMITER ;;
CREATE DEFINER=`dbsalonuser`@`%` PROCEDURE `Sp_UserPermissions`(IN UserId INT,Count INT,rowcount INT,MenuName nvarchar(50))
BEGIN
set count=(select count(*) from tblPages left outer join tblUserPermissions on tblUserPermissions.PageID=tblPages.PageID where tblUserPermissions.UserId=UserId and tblPages.MenuName=MenuName);
if count=0 then
select *,0 as Insertion,0 as View,0 as Edit,0 as Deletion,0 as ID,0 as count from tblPages  where tblPages.MenuName=MenuName;
else
-- set rowcount=(select count(*) from tblPages);
-- if count=rowcount then
-- select distinct tblPages.PageDisplayName,tblPages.PageID,tblPages.PageName,tblPages.MenuName,tblUserPermissions.Insertion,tblUserPermissions.View,tblUserPermissions.Edit,tblUserPermissions.Deletion,tblUserPermissions.ID,1 as count from tblPages left outer join tblUserPermissions on tblUserPermissions.PageID=tblPages.PageID where tblUserPermissions.UserId=UserId and tblPages.MenuName=MenuName;
-- else
-- select tblPages.PageDisplayName,tblPages.PageID,tblPages.PageName,tblPages.MenuName,0 as Insertion,0 as View,0 as Edit,0 as Deletion,0 as ID,0 as count from tblPages where tblPages.MenuName=MenuName
-- union
select distinct tblPages.PageDisplayName,tblPages.PageID,tblPages.PageName,tblPages.MenuName,tblUserPermissions.Insertion,tblUserPermissions.View,tblUserPermissions.Edit,tblUserPermissions.Deletion,tblUserPermissions.ID,1 as count from tblPages left outer join tblUserPermissions on tblUserPermissions.PageID=tblPages.PageID where tblUserPermissions.UserId=UserId and
tblPages.MenuName=MenuName;

-- end if;
end if;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-12 19:49:06
