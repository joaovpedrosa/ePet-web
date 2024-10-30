-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: ESN509VMYSQL    Database: epet
-- ------------------------------------------------------
-- Server version	5.7.11-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS usuario;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE usuario (
  Nome varchar(50) DEFAULT NULL,
  telefone varchar(12) DEFAULT NULL,
  Cep varchar(10) DEFAULT NULL,
  Cidade varchar(50) DEFAULT NULL,
  bairro varchar(50) DEFAULT NULL,
  Rua varchar(50) DEFAULT NULL,
  complemento varchar(50) DEFAULT NULL,
  CPF varchar(19) NOT NULL,
  Email varchar(50) DEFAULT NULL,
  DataNasc varchar(10) DEFAULT NULL,
  Senha varchar(20) DEFAULT NULL,
  isAdm varchar(3) DEFAULT NULL,
  PRIMARY KEY (CPF)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

INSERT INTO usuario VALUES ('pitbull do samba','199999999',NULL,NULL,NULL,'Rua dos dog',NULL,'09','pitbulldosamba@gmail.com',NULL,'12345','nao');
INSERT INTO usuario VALUES ('adm','123','123','123','123','123','123','123','adm','123','123','sim');
INSERT INTO usuario VALUES ('nome teste','99999999',NULL,NULL,NULL,'Rua teste',NULL,'123456789','emailTestea@gmail.com',NULL,'12345','nao');
INSERT INTO usuario VALUES ('valinhos','5133221889','11','oi douglas','ana@gmail','2005-10-19','ana','13275-720','Ana Caroline Scassa Chaparin','palmares','12312312312','nao');
INSERT INTO usuario VALUES ('robeerto cheio ','999999991',NULL,NULL,NULL,NULL,NULL,'1471475257','manguaga',NULL,'2036-07-04','nao');
INSERT INTO usuario VALUES ('tangoMalandro@gmail.com','123','499489468','tango Malandro','10/12','65465','horto','1999978555','antiga','das vivas','casa 1','nao');
INSERT INTO usuario VALUES ('cleitonRasta@gmail.com','12345','4468','cleiton rasta','09/12','137855','horto','199999999','nova','das almas','ddddd','nao');
INSERT INTO usuario VALUES ('nao','18888888888','0000000','xique xique ','mariaanalda ','74','sertão ','4444444444','roberta','2024-10-17','7474','nao');
INSERT INTO usuario VALUES ('va nao','18888888888p','0000000p','xique xique p','mariaanalda p','74p','sertão p','4444444444p','robertap','2024-10-21','p','sim');
INSERT INTO usuario VALUES ('juca','44444444444',NULL,NULL,NULL,NULL,NULL,'445545488565','cotia ',NULL,'2024-10-01',NULL);
INSERT INTO usuario VALUES ('gabs','19999626520','13185624','hortolandia','nova america ','nova america ','ap do caralho ','446487165','fabrigabriel321@gmail.com','2024-09-30','123',NULL);
INSERT INTO usuario VALUES ('tango Malandro','1999978555','65465','horto','antiga','das vivas','casa 1','499489468','tangoMalandro@gmail.com','10/12','123','nao');
INSERT INTO usuario VALUES ('Ana Caroline Scassa Chaparin','12312312312','13275-720','valinhos','palmares','11','oi douglas','5133221889','anacaroline25190@gmail.com','2005-10-19','ana',NULL);
INSERT INTO usuario VALUES ('maça molhada','8787','65465','horto','antiga','das vivas','casa 1','554','tangoMalandro@gmail.com','10/12','123','nao');
INSERT INTO usuario VALUES ('Roberto vizosa','199999999',NULL,NULL,NULL,NULL,NULL,'921948214','Uberlandia ',NULL,'1111-11-15',NULL);
INSERT INTO usuario VALUES ('nome','telefone','123','123','123','123','123','cpf','email','123','senha','nao');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed
