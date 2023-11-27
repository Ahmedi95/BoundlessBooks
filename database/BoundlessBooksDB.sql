-- MariaDB dump 10.19  Distrib 10.6.12-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: bsms
-- ------------------------------------------------------
-- Server version	10.6.12-MariaDB-0ubuntu0.22.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20231124221653_InitialCreate','7.0.10');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `author`
--

DROP TABLE IF EXISTS `author`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `author` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `author`
--

LOCK TABLES `author` WRITE;
/*!40000 ALTER TABLE `author` DISABLE KEYS */;
INSERT INTO `author` VALUES (1,'James Clear'),(2,'Andy Weir'),(3,'Frank Herbert'),(4,'Douglas Adams'),(5,'J.R.R. Tolkien'),(6,'C.S. Lewis');
/*!40000 ALTER TABLE `author` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `book`
--

DROP TABLE IF EXISTS `book`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `book` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(150) NOT NULL,
  `isbn` varchar(100) NOT NULL,
  `price` decimal(65,30) NOT NULL,
  `description` varchar(500) NOT NULL,
  `image` varchar(50) NOT NULL,
  `stock_qty` int(11) NOT NULL,
  `author_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `isbn` (`isbn`),
  KEY `IX_book_author_id` (`author_id`),
  CONSTRAINT `FK_book_author_author_id` FOREIGN KEY (`author_id`) REFERENCES `author` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `book`
--

LOCK TABLES `book` WRITE;
/*!40000 ALTER TABLE `book` DISABLE KEYS */;
INSERT INTO `book` VALUES (1,'Atomic Habits','073521121X',3950.000000000000000000000000000000,'Atomic Habits is a book by James Clear that offers a practical, science-backed guide to building good habits and breaking bad ones. Clear argues that small changes, made consistently over time, can have a profound impact on our lives.','bookImg1.jpg',2,1),(2,'The Martian','0545063598',4120.000000000000000000000000000000,'The Martian is a science fiction novel by Andy Weir that tells the story of an astronaut who is stranded on Mars and must use his ingenuity to survive. The book has been praised for its realistic portrayal of space travel and its suspenseful plot.','bookImg2.jpg',0,2),(3,'Project Hail Mary','059316468X',6250.000000000000000000000000000000,'Project Hail Mary is a science fiction novel by Andy Weir that tells the story of an amnesiac who wakes up on a spaceship with no memory of who he is or how he got there. He must use his scientific skills to figure out what is happening and save the world from an alien threat.','bookImg3.jpg',1,2),(4,'Dune','0441002404',4650.000000000000000000000000000000,'Dune is a science fiction novel by Frank Herbert that tells the story of Paul Atreides, a young man who is forced to leave his home planet and become the leader of a powerful desert tribe. The book is known for its complex plot, its rich world-building, and its exploration of themes such as ecology, politics, and religion.','bookImg4.jpg',24,3),(5,'The Lord of the Rings','0395074229',7100.000000000000000000000000000000,'The Lord of the Rings is a trilogy of fantasy novels by J.R.R. Tolkien that tells the story of a group of hobbits who must destroy the One Ring, an evil artifact that threatens to destroy Middle-earth. The books are known for their epic scope, their rich world-building, and their enduring popularity.','bookImg5.jpg',19,5),(6,'The Hitchhiker\'s Guide to the Galaxy','9780345521489',1950.000000000000000000000000000000,'The Hitchhiker\'s Guide to the Galaxy is a comedy science fiction series created by Douglas Adams. The series follows the adventures of Arthur Dent, an Englishman who escapes Earth\'s destruction with his friend Ford Prefect, who is actually an alien researcher who had been stranded on Earth for fifteen years collecting information for the titular Hitchhiker\'s Guide to the Galaxy.','bookImg6.jpg',9,4),(7,'The Silmarillion','0395752712',1250.000000000000000000000000000000,'The Silmarillion is a collection of stories and poems by J.R.R. Tolkien that tells the history of Middle-earth from its creation to the end of the First Age. The book is a valuable resource for anyone who wants to learn more about Tolkien\'s world, but it is also a challenging read due to its complex structure and its use of archaic language.','bookImg7.jpg',5,5),(8,'The Chronicles of Narnia','0064487710',3400.000000000000000000000000000000,' The Chronicles of Narnia is a series of seven fantasy novels by C.S. Lewis that tells the story of four children who discover a magical land called Narnia. The books are known for their Christian themes, their exciting adventures, and their charming characters.','bookImg8.jpg',0,6);
/*!40000 ALTER TABLE `book` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order`
--

DROP TABLE IF EXISTS `order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  `status` varchar(50) NOT NULL,
  `user_id` int(11) NOT NULL,
  `total_amount` decimal(65,30) NOT NULL,
  `address` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_order_user_id` (`user_id`),
  CONSTRAINT `FK_order_user_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order`
--

LOCK TABLES `order` WRITE;
/*!40000 ALTER TABLE `order` DISABLE KEYS */;
INSERT INTO `order` VALUES (1,'2023-11-28 01:26:06','order-placed',1,8600.000000000000000000000000000000,'Anderson Road Bampalapitya'),(2,'2023-11-28 01:36:09','order-placed',1,3200.000000000000000000000000000000,'Anderson Road Bampalapitya'),(3,'0001-01-01 00:00:00','order-placed',1,7100.000000000000000000000000000000,'100th lane Jaffna'),(4,'0001-01-01 00:00:00','order-placed',1,1950.000000000000000000000000000000,'Pepiliyana Dehiwala'),(5,'0001-01-01 00:00:00','order-placed',1,3950.000000000000000000000000000000,'wellawatte');
/*!40000 ALTER TABLE `order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_details`
--

DROP TABLE IF EXISTS `order_details`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `order_details` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `unit_price` decimal(65,30) NOT NULL,
  `quantity` int(11) NOT NULL,
  `book_id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `IX_order_details_book_id` (`book_id`),
  KEY `IX_order_details_order_id` (`order_id`),
  CONSTRAINT `FK_order_details_book_book_id` FOREIGN KEY (`book_id`) REFERENCES `book` (`id`),
  CONSTRAINT `FK_order_details_order_order_id` FOREIGN KEY (`order_id`) REFERENCES `order` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_details`
--

LOCK TABLES `order_details` WRITE;
/*!40000 ALTER TABLE `order_details` DISABLE KEYS */;
INSERT INTO `order_details` VALUES (1,4650.000000000000000000000000000000,1,4,1),(3,1950.000000000000000000000000000000,1,6,2),(4,1250.000000000000000000000000000000,1,7,2),(5,7100.000000000000000000000000000000,1,5,3),(6,1950.000000000000000000000000000000,1,6,4),(7,3950.000000000000000000000000000000,1,1,5);
/*!40000 ALTER TABLE `order_details` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(100) NOT NULL,
  `password` varchar(64) NOT NULL,
  `salt` varchar(64) NOT NULL,
  `first_name` varchar(50) NOT NULL,
  `last_name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone_number` varchar(10) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `user_name` (`user_name`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'ahmedi','Dn9VWMrFOcTTvGIZGtIo+OaKazKBZdv20jZtBQe3o04=','u0fvQHT1/D+DzMiC6z5BlNRjMY7WZqiy4YAzgjpPmtc=','Ahmed','Ismail','ahmedhussainismail95@gmail.com','0771472477'),(12,'sara99','hohSDYFsrOpgyrW4xi+M8J6c75gtFQKYit/sboTqSQ0=','pOYuobe5HYIRa7aBW0+IJ97HC5FzJxvmfxsyANXPtwE=','Sara','Mohamed','sara@gmail.com','0773097739'),(13,'percy_55','b1bNEGXMUKRjlko4MwA1Y5Sqy3KiDJGoZ0h7xBTzqLA=','fGwL210KJfj5WDkz90oFNyk4e41yNHnyz1nWXQsh/zs=','Percy','Uncle','percy@gmail.com','0771472477');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-28  2:49:33
