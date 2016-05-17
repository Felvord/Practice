-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: storage
-- ------------------------------------------------------
-- Server version	5.7.12-log

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
-- Table structure for table `hangar`
--

DROP TABLE IF EXISTS `hangar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hangar` (
  `hangarID` int(11) NOT NULL,
  `hangarName` varchar(45) NOT NULL,
  `platformID` int(11) NOT NULL,
  `totalAmount` int(11) NOT NULL,
  `usedAmount` int(11) DEFAULT NULL,
  PRIMARY KEY (`hangarID`),
  UNIQUE KEY `hangarName_UNIQUE` (`hangarName`),
  KEY `platformID_idx` (`platformID`),
  CONSTRAINT `platformID` FOREIGN KEY (`platformID`) REFERENCES `platform` (`platformID`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hangar`
--

LOCK TABLES `hangar` WRITE;
/*!40000 ALTER TABLE `hangar` DISABLE KEYS */;
INSERT INTO `hangar` VALUES (1,'H_1',1,20,20),(2,'H_2',1,25,15),(3,'H_3',1,30,22),(4,'H_4',1,35,26),(5,'H_5',2,40,24),(6,'H_6',2,26,16),(7,'H_7',2,27,17),(8,'H_8',2,28,18),(9,'H_9',2,29,10),(10,'H_10',3,30,0),(11,'H_11',3,40,5),(12,'H_12',3,39,6),(13,'H_13',3,21,7),(14,'H_14',3,22,9),(15,'H_15',3,23,15),(16,'H_16',3,34,22),(17,'H_17',3,36,34),(18,'H_18',3,30,28),(19,'H_19',3,24,24),(20,'H_20',3,28,28),(21,'H_21',4,32,32),(22,'H_22',4,30,1),(23,'H_23',4,28,2),(24,'H_24',4,26,3),(25,'H_25',4,24,4),(26,'H_26',4,22,5),(27,'H_27',4,39,6),(28,'H_28',4,37,7),(29,'H_29',4,35,8),(30,'H_30',4,33,9),(31,'H_31',4,31,4),(32,'H_32',4,29,3),(33,'H_33',4,27,2),(34,'H_34',4,25,1),(35,'H_35',4,23,11),(36,'H_36',4,21,15),(37,'H_37',5,20,16),(38,'H_38',5,21,17),(39,'H_39',5,22,12),(40,'H_40',5,23,13),(41,'H_41',5,24,14),(42,'H_42',6,25,16),(43,'H_43',6,26,20),(44,'H_44',6,27,16),(45,'H_45',6,28,11),(46,'H_46',6,29,10),(47,'H_47',7,30,9),(48,'H_48',7,31,8),(49,'H_49',7,32,3),(50,'H_50',7,33,25),(51,'H_51',8,34,26),(52,'H_52',8,35,1),(53,'H_53',8,36,14),(54,'H_54',8,37,16),(55,'H_55',8,38,22),(56,'H_56',8,39,34),(57,'H_57',9,40,22),(58,'H_58',9,25,26),(59,'H_59',9,35,14),(60,'H_60',9,37,33),(61,'H_61',9,36,20),(62,'H_62',9,38,1),(63,'H_63',9,28,0),(64,'H_64',9,29,11),(65,'H_65',10,27,0),(66,'H_66',10,29,22),(67,'H_67',10,25,0),(68,'H_68',10,22,8),(69,'H_69',10,20,2),(70,'H_70',10,30,30);
/*!40000 ALTER TABLE `hangar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `platform`
--

DROP TABLE IF EXISTS `platform`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `platform` (
  `platformID` int(11) NOT NULL,
  `platformName` varchar(45) NOT NULL,
  PRIMARY KEY (`platformID`),
  UNIQUE KEY `platformName_UNIQUE` (`platformName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `platform`
--

LOCK TABLES `platform` WRITE;
/*!40000 ALTER TABLE `platform` DISABLE KEYS */;
INSERT INTO `platform` VALUES (1,'A'),(2,'B'),(3,'C'),(4,'D'),(5,'E'),(6,'F'),(7,'G'),(8,'H'),(9,'J'),(10,'K');
/*!40000 ALTER TABLE `platform` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-05-17 23:08:15
