CREATE DATABASE  IF NOT EXISTS `bdkbguadalupana` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `bdkbguadalupana`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: bdkbguadalupana
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.17-MariaDB

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
-- Table structure for table `av_agenda`
--

DROP TABLE IF EXISTS `av_agenda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_agenda` (
  `codavagenda` int(11) NOT NULL AUTO_INCREMENT,
  `codgenusuario` int(11) NOT NULL,
  PRIMARY KEY (`codavagenda`),
  KEY `codgenusuario` (`codgenusuario`),
  CONSTRAINT `av_agenda_ibfk_1` FOREIGN KEY (`codgenusuario`) REFERENCES `gen_usuario` (`codgenusuario`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_agenda`
--

LOCK TABLES `av_agenda` WRITE;
/*!40000 ALTER TABLE `av_agenda` DISABLE KEYS */;
INSERT INTO `av_agenda` VALUES (1,1),(3,3),(2,4),(4,8);
/*!40000 ALTER TABLE `av_agenda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `av_bitacora`
--

DROP TABLE IF EXISTS `av_bitacora`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_bitacora` (
  `codregistro` int(11) NOT NULL,
  `bit_fechahora` datetime NOT NULL,
  `codgenusuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_bitacora`
--

LOCK TABLES `av_bitacora` WRITE;
/*!40000 ALTER TABLE `av_bitacora` DISABLE KEYS */;
/*!40000 ALTER TABLE `av_bitacora` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `av_controlasignado`
--

DROP TABLE IF EXISTS `av_controlasignado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_controlasignado` (
  `codgenusuario` int(11) NOT NULL,
  `codavtarea` int(11) NOT NULL,
  `avcifgeneral` int(11) NOT NULL,
  KEY `codavtarea` (`codavtarea`),
  KEY `codgenusuario` (`codgenusuario`),
  CONSTRAINT `av_controlasignado_ibfk_2` FOREIGN KEY (`codavtarea`) REFERENCES `av_tarea` (`codavtarea`),
  CONSTRAINT `av_controlasignado_ibfk_3` FOREIGN KEY (`codgenusuario`) REFERENCES `gen_usuario` (`codgenusuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_controlasignado`
--

LOCK TABLES `av_controlasignado` WRITE;
/*!40000 ALTER TABLE `av_controlasignado` DISABLE KEYS */;
INSERT INTO `av_controlasignado` VALUES (1,1,1),(1,2,1),(1,3,1),(1,4,1),(4,5,949931),(4,6,949931),(4,7,949931),(4,8,1),(4,9,0),(1,10,1),(3,11,0),(8,12,0),(8,13,860949),(8,14,860949);
/*!40000 ALTER TABLE `av_controlasignado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `av_credito`
--

DROP TABLE IF EXISTS `av_credito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_credito` (
  `codavcredit` int(11) NOT NULL,
  `codavtarea` int(11) NOT NULL,
  `av_numcredito` int(11) DEFAULT NULL,
  PRIMARY KEY (`codavcredit`),
  KEY `codavtarea` (`codavtarea`),
  CONSTRAINT `av_credito_ibfk_1` FOREIGN KEY (`codavtarea`) REFERENCES `av_tarea` (`codavtarea`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_credito`
--

LOCK TABLES `av_credito` WRITE;
/*!40000 ALTER TABLE `av_credito` DISABLE KEYS */;
INSERT INTO `av_credito` VALUES (1,1,48475748),(2,6,45845857),(3,11,123);
/*!40000 ALTER TABLE `av_credito` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `av_estado`
--

DROP TABLE IF EXISTS `av_estado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_estado` (
  `codestado` int(3) NOT NULL AUTO_INCREMENT,
  `av_estado` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`codestado`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_estado`
--

LOCK TABLES `av_estado` WRITE;
/*!40000 ALTER TABLE `av_estado` DISABLE KEYS */;
INSERT INTO `av_estado` VALUES (1,'Abierto'),(2,'En Proceso'),(3,'Cerrado'),(4,'Anulado');
/*!40000 ALTER TABLE `av_estado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `av_permisostarea`
--

DROP TABLE IF EXISTS `av_permisostarea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_permisostarea` (
  `codavpertarea` int(11) NOT NULL AUTO_INCREMENT,
  `av_pertarea` varchar(20) NOT NULL,
  PRIMARY KEY (`codavpertarea`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_permisostarea`
--

LOCK TABLES `av_permisostarea` WRITE;
/*!40000 ALTER TABLE `av_permisostarea` DISABLE KEYS */;
INSERT INTO `av_permisostarea` VALUES (1,'lectura y escritura'),(2,'lectura'),(3,'ReasignarLE');
/*!40000 ALTER TABLE `av_permisostarea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `av_prioridad`
--

DROP TABLE IF EXISTS `av_prioridad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_prioridad` (
  `codprioridad` int(3) NOT NULL AUTO_INCREMENT,
  `av_prioridad` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`codprioridad`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_prioridad`
--

LOCK TABLES `av_prioridad` WRITE;
/*!40000 ALTER TABLE `av_prioridad` DISABLE KEYS */;
INSERT INTO `av_prioridad` VALUES (1,'Alta'),(2,'Media'),(3,'Baja');
/*!40000 ALTER TABLE `av_prioridad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `av_subtarea`
--

DROP TABLE IF EXISTS `av_subtarea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_subtarea` (
  `codsubtarea` int(11) NOT NULL AUTO_INCREMENT,
  `codtarea` int(11) NOT NULL,
  `codestado` int(11) NOT NULL DEFAULT 1,
  `av_descsubtarea` varchar(140) NOT NULL,
  `av_fechaini` datetime NOT NULL,
  `av_fechafin` datetime NOT NULL,
  PRIMARY KEY (`codsubtarea`),
  KEY `av_subtarea_ibfk_2` (`codestado`),
  KEY `av_subtarea_ibfk_1` (`codtarea`),
  CONSTRAINT `av_subtarea_ibfk_1` FOREIGN KEY (`codtarea`) REFERENCES `av_tarea` (`codavtarea`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `av_subtarea_ibfk_2` FOREIGN KEY (`codestado`) REFERENCES `av_estado` (`codestado`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_subtarea`
--

LOCK TABLES `av_subtarea` WRITE;
/*!40000 ALTER TABLE `av_subtarea` DISABLE KEYS */;
INSERT INTO `av_subtarea` VALUES (1,1,3,'Tarea1','2021-02-16 13:59:00','2021-02-22 13:59:00'),(2,1,1,'Tarea2','2021-02-16 14:00:00','2021-02-21 14:00:00'),(3,4,3,'Tarea1','2021-02-16 14:18:00','2021-03-09 13:18:00'),(4,1,1,'llamar cliente','2021-02-16 15:21:00','2021-02-22 15:21:00'),(5,4,3,'Tarea2','2021-02-17 15:24:00','2021-02-23 15:24:00'),(6,4,3,'Tarea2','2021-02-16 15:55:00','2021-02-17 15:55:00'),(7,8,3,'Tarea1','2021-02-21 11:16:00','2021-02-21 11:16:00'),(8,8,3,'Tarea2','2021-02-21 11:16:00','2021-02-21 11:16:00');
/*!40000 ALTER TABLE `av_subtarea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `av_tarea`
--

DROP TABLE IF EXISTS `av_tarea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_tarea` (
  `codavtarea` int(11) NOT NULL AUTO_INCREMENT,
  `codavagenda` int(11) NOT NULL,
  `av_titulo` varchar(60) NOT NULL,
  `av_pnombre` varchar(30) DEFAULT NULL,
  `av_papellido` varchar(30) DEFAULT NULL,
  `av_telefono` int(8) DEFAULT NULL,
  `av_monto` int(20) DEFAULT NULL,
  `av_fechaini` datetime NOT NULL,
  `av_fechafin` datetime NOT NULL,
  `fechaini` varchar(90) NOT NULL,
  `fechafin` varchar(90) NOT NULL,
  `av_descripcion` varchar(140) NOT NULL,
  `cod_estado` int(11) NOT NULL DEFAULT 1,
  `codprioridad` int(11) NOT NULL,
  `codtipotarea` int(11) NOT NULL DEFAULT 1,
  `codasociado` int(11) NOT NULL,
  `codavpertarea` int(11) NOT NULL DEFAULT 1,
  `av_comentario` varchar(140) DEFAULT NULL,
  PRIMARY KEY (`codavtarea`),
  KEY `av_tarea_ibfk_1` (`codtipotarea`),
  KEY `av_tarea_ibfk_2` (`codprioridad`),
  KEY `av_tarea_ibfk_3` (`cod_estado`),
  KEY `av_tarea_ibfk_4` (`codavagenda`),
  KEY `codavpertarea` (`codavpertarea`),
  CONSTRAINT `av_tarea_ibfk_1` FOREIGN KEY (`codtipotarea`) REFERENCES `av_tipotarea` (`codtipotarea`),
  CONSTRAINT `av_tarea_ibfk_2` FOREIGN KEY (`codprioridad`) REFERENCES `av_prioridad` (`codprioridad`),
  CONSTRAINT `av_tarea_ibfk_3` FOREIGN KEY (`cod_estado`) REFERENCES `av_estado` (`codestado`),
  CONSTRAINT `av_tarea_ibfk_4` FOREIGN KEY (`codavagenda`) REFERENCES `av_agenda` (`codavagenda`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `av_tarea_ibfk_5` FOREIGN KEY (`codavpertarea`) REFERENCES `av_permisostarea` (`codavpertarea`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_tarea`
--

LOCK TABLES `av_tarea` WRITE;
/*!40000 ALTER TABLE `av_tarea` DISABLE KEYS */;
INSERT INTO `av_tarea` VALUES (1,1,'Visita A cliente zona 5','Antonio ','Melgar',24495856,20000,'2021-02-16 13:58:00','2021-02-23 13:58:00','16 feb 2021','23 feb 2021','Visita a cliente',3,1,1,1,1,'Cliente no interesado'),(2,1,'Actualizar un sistema','Edgar ','Ximenes',212321,458,'2021-02-16 14:01:00','2021-02-28 14:01:00','16 feb 2021','28 feb 2021','Actualizar',3,1,1,1,1,'Cliente no interesado'),(3,1,'Actualización de antivirus ESET NOD32','Edgar ','Ximenes',0,0,'2021-02-16 14:08:00','2021-03-02 14:08:00','16 feb 2021','02 mar 2021','',3,2,2,1,1,'Cliente no interesado'),(4,1,'Realizar informe de tareas','Edgar ','Casasola',0,0,'2021-02-16 14:14:00','2021-03-09 14:15:00','16 feb 2021','09 mar 2021','Informes de tareas',3,2,2,1,1,'Cliente no interesado'),(5,2,'Tienes una tarea nueva','Edgar ','Alvarado',48554788,NULL,'2021-02-16 19:06:00','2021-02-22 19:06:00','16 feb 2021','22 feb 2021','Tarea nueva edgar',1,1,2,1,2,'Cliente no interesado'),(6,2,'Visita A cliente zona 5','Edgar ','Casasola',88988777,80000,'2021-02-17 12:29:00','2021-03-02 12:29:00','17 feb 2021','02 mar 2021','',2,2,1,1,1,'Cliente no interesado'),(7,2,'Actualizar un sistema','Edgar ','Herrea',77777777,22000,'2021-02-18 21:43:00','2021-02-28 21:43:00','18 feb 2021','28 feb 2021','sss',3,1,1,1,1,'El cliente no esta interesado'),(8,2,'Ingreso de datos para testeo','Jose','Gonzalez',22,22,'2021-02-20 19:00:00','2021-02-21 20:04:00','20 feb 2021','21 feb 2021','prueba',3,1,2,1,2,NULL),(9,2,'Tarea configurar servidor','Edgar Casasola','Casasola',21321231,11122,'2021-02-20 21:17:00','2021-03-01 21:17:00','20 feb 2021','01 mar 2021','CONFIGURACION DE SERVER',2,1,1,1,3,NULL),(10,1,'Realizar diseño preliminar','Jose','Gonzalez',31417025,2500,'2021-02-24 16:24:00','2021-02-26 19:27:00','24 feb 2021','26 feb 2021','Terminar el diseño',1,1,1,1,1,NULL),(11,3,'Sistema de arqueos','Aida','Ortiz',12345678,0,'2021-02-24 16:27:00','2021-03-01 16:27:00','24 feb 2021','01 mar 2021','Terminar el sistema de arqueos',2,1,1,1,1,NULL),(12,4,'Ingreso de datos para testeo','Jose','Gonzalez',44444444,0,'2021-02-24 16:59:00','2021-03-14 16:05:00','24 feb 2021','14 mar 2021','prueba',1,1,1,1,1,NULL),(13,4,'Ingreso de datos para testeo','Jose','Gonzalez',22222222,0,'2021-02-24 17:03:00','2021-03-06 22:03:00','24 feb 2021','06 mar 2021','prueba',1,1,1,1,1,NULL),(14,4,'Visita cliente zona 7 ','Jose','Teo',58653431,20000,'2021-02-24 18:28:00','2021-02-27 18:28:00','24 feb 2021','27 feb 2021','Visitar cliente interesado',1,1,1,1,1,NULL);
/*!40000 ALTER TABLE `av_tarea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `av_tipotarea`
--

DROP TABLE IF EXISTS `av_tipotarea`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `av_tipotarea` (
  `codtipotarea` int(3) NOT NULL AUTO_INCREMENT,
  `tipotarea` varchar(30) NOT NULL,
  PRIMARY KEY (`codtipotarea`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `av_tipotarea`
--

LOCK TABLES `av_tipotarea` WRITE;
/*!40000 ALTER TABLE `av_tipotarea` DISABLE KEYS */;
INSERT INTO `av_tipotarea` VALUES (1,'Cita '),(2,'Visita tecnica');
/*!40000 ALTER TABLE `av_tipotarea` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crm_finalidadservicio`
--

DROP TABLE IF EXISTS `crm_finalidadservicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crm_finalidadservicio` (
  `codcrmfinalidadservicio` int(11) NOT NULL AUTO_INCREMENT,
  `codcrmtiposervicio` int(11) DEFAULT NULL,
  `crm_finalidaddescripcion` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`codcrmfinalidadservicio`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crm_finalidadservicio`
--

LOCK TABLES `crm_finalidadservicio` WRITE;
/*!40000 ALTER TABLE `crm_finalidadservicio` DISABLE KEYS */;
INSERT INTO `crm_finalidadservicio` VALUES (1,1,'Unificar deudas');
/*!40000 ALTER TABLE `crm_finalidadservicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crm_frasesdeldia`
--

DROP TABLE IF EXISTS `crm_frasesdeldia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crm_frasesdeldia` (
  `idcrm_frasesdeldia` int(11) NOT NULL AUTO_INCREMENT,
  `crm_frasesdeldianombre` varchar(600) DEFAULT NULL,
  PRIMARY KEY (`idcrm_frasesdeldia`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crm_frasesdeldia`
--

LOCK TABLES `crm_frasesdeldia` WRITE;
/*!40000 ALTER TABLE `crm_frasesdeldia` DISABLE KEYS */;
INSERT INTO `crm_frasesdeldia` VALUES (1,'“Si quieres ser excelente en algo importante, necesitas tomar el hábito en las cosas pequeñas. La excelencia no es una opción, es un actitud imperante”, Charles R. Swindoll.'),(2,'\"Es totalmente cierto que puedes tener éxito con mayor rapidez si ayudas a otras personas a tener éxito”, Napolean Hill.'),(3,'\"Muchas ideas crecen mejor cuando se trasplantan a otra mente diferente de la que surgieron”, Oliver Wendell Holmes.'),(4,'\"El trabajo en equipo es la habilidad de trabajar juntos con un objetivo en común. La habilidad de lograr logros personales relacionados con los objetivos empresariales. Es la gasolina que permite a la gente común lograr resultados no comunes”, Andrew Carnegie.');
/*!40000 ALTER TABLE `crm_frasesdeldia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crm_genagencias`
--

DROP TABLE IF EXISTS `crm_genagencias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crm_genagencias` (
  `codcrmgenagencias` int(11) NOT NULL,
  `crm_genagenciasnombre` varchar(100) DEFAULT NULL,
  `crm_genagenciasestado` int(1) DEFAULT NULL,
  PRIMARY KEY (`codcrmgenagencias`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crm_genagencias`
--

LOCK TABLES `crm_genagencias` WRITE;
/*!40000 ALTER TABLE `crm_genagencias` DISABLE KEYS */;
INSERT INTO `crm_genagencias` VALUES (2,'AG. BOCA DEL MONTE',1),(3,'AG. FLORIDA',1),(4,'AG. GRAN VIA',1),(5,'AG. MEGA 6',1),(6,'AG. METROCENTRO',1),(7,'AG. MIXCO',1),(8,'AG. PACIFIC VH',1),(9,'AG. PETAPA',1),(10,'AG. PORTALES',1),(11,'AG. SAN CRISTOBAL',1),(12,'AG. SAN LUCAS',1),(13,'AG. SAN NICOLAS',1),(14,'AG. TERMINAL',1),(15,'AG. ZONA 4',1),(16,'MINI AG. METRONORTE',1),(17,'AG.C.C. NARANJO MALL',1),(18,'AGENCIA LOS ALAMOS',1),(19,'CENTRAL ZONA 14',1),(20,'KIOSCO MIRAFLORES',1),(21,'KIOSCO MONSERRAT',1),(22,'KIOSKO PORTALES',1),(23,'MINI AG C.C. PRADERA',1),(24,'STA CATARINA PINULA',1),(25,'TELEMERCADEO',1);
/*!40000 ALTER TABLE `crm_genagencias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crmalertas_programadas`
--

DROP TABLE IF EXISTS `crmalertas_programadas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crmalertas_programadas` (
  `codcrmalertasprogramadas` int(11) NOT NULL AUTO_INCREMENT,
  `codcrmcontrolingreso` int(11) DEFAULT NULL,
  `crmalertas_programadasfechainicio` date DEFAULT NULL,
  `crmalertas_programadasfechafin` date DEFAULT NULL,
  `crmalertas_programadasnobre` varchar(45) DEFAULT NULL,
  `crmalertas_programadasdescripcion` varchar(50) DEFAULT NULL,
  `crmalertas_programadasestado` int(1) DEFAULT NULL,
  PRIMARY KEY (`codcrmalertasprogramadas`),
  KEY `fk_crmalertas_programadas_crmcontrol_ingreso_idx` (`codcrmcontrolingreso`),
  CONSTRAINT `fk_crmalertas_programadas_crmcontrol_ingresi1` FOREIGN KEY (`codcrmcontrolingreso`) REFERENCES `crmcontrol_ingreso` (`codcrmcontrolingreso`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crmalertas_programadas`
--

LOCK TABLES `crmalertas_programadas` WRITE;
/*!40000 ALTER TABLE `crmalertas_programadas` DISABLE KEYS */;
INSERT INTO `crmalertas_programadas` VALUES (1,2,'2021-01-01','2021-02-01','Llamar importante','llamada a las 15:00hrs',1);
/*!40000 ALTER TABLE `crmalertas_programadas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crmcontacto_llamadas`
--

DROP TABLE IF EXISTS `crmcontacto_llamadas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crmcontacto_llamadas` (
  `codcrmcontactollamadas` int(11) NOT NULL,
  `crmcontacto_llamadasnombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codcrmcontactollamadas`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crmcontacto_llamadas`
--

LOCK TABLES `crmcontacto_llamadas` WRITE;
/*!40000 ALTER TABLE `crmcontacto_llamadas` DISABLE KEYS */;
INSERT INTO `crmcontacto_llamadas` VALUES (1,'Si contesto'),(2,'No contesto'),(3,'1era Llamada'),(4,'2da Llamada'),(5,'3ra Llamada');
/*!40000 ALTER TABLE `crmcontacto_llamadas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crmcontrol_ingreso`
--

DROP TABLE IF EXISTS `crmcontrol_ingreso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crmcontrol_ingreso` (
  `codcrmcontrolingreso` int(11) NOT NULL,
  `crmcontrol_ingresosucursal` varchar(45) DEFAULT NULL,
  `crmcontrol_ingresousuario` varchar(45) DEFAULT NULL,
  `crmcontrol_ingresorol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codcrmcontrolingreso`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crmcontrol_ingreso`
--

LOCK TABLES `crmcontrol_ingreso` WRITE;
/*!40000 ALTER TABLE `crmcontrol_ingreso` DISABLE KEYS */;
INSERT INTO `crmcontrol_ingreso` VALUES (1,'central','pggteo','6'),(2,'central','pggteo1','3'),(3,'mazate','pggteo2','3'),(4,'telemercadeo','pggteo3','3'),(5,'telemercadeo','pggteo4','3');
/*!40000 ALTER TABLE `crmcontrol_ingreso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crmcontrol_prospecto_agente`
--

DROP TABLE IF EXISTS `crmcontrol_prospecto_agente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crmcontrol_prospecto_agente` (
  `codcrmcontrolprospectoagente` int(11) NOT NULL AUTO_INCREMENT,
  `codcrminfoprospecto` int(11) DEFAULT NULL,
  `codcrmcontrolingreso` int(11) DEFAULT NULL,
  `fechaasignado` date DEFAULT NULL,
  PRIMARY KEY (`codcrmcontrolprospectoagente`),
  KEY `fk_crmcontrol_prospecto_agente_crminfo_prospecto_idx` (`codcrminfoprospecto`),
  KEY `fk_crmcontrol_prospecto_agente_crminfo_controlingreso_idx` (`codcrmcontrolingreso`),
  CONSTRAINT `fk_crmcontrol_prospecto_agente_crm_controlingreso1` FOREIGN KEY (`codcrmcontrolingreso`) REFERENCES `crmcontrol_ingreso` (`codcrmcontrolingreso`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_crmcontrol_prospecto_agente_crm_infoprospecto1` FOREIGN KEY (`codcrminfoprospecto`) REFERENCES `crminfo_prospecto` (`codcrminfoprospecto`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crmcontrol_prospecto_agente`
--

LOCK TABLES `crmcontrol_prospecto_agente` WRITE;
/*!40000 ALTER TABLE `crmcontrol_prospecto_agente` DISABLE KEYS */;
INSERT INTO `crmcontrol_prospecto_agente` VALUES (1,1,2,'2021-02-22'),(2,2,4,'2021-02-22'),(3,3,5,'2021-02-22'),(4,4,4,'2021-02-22'),(5,5,2,'2021-03-04');
/*!40000 ALTER TABLE `crmcontrol_prospecto_agente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crmestado_descripcion`
--

DROP TABLE IF EXISTS `crmestado_descripcion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crmestado_descripcion` (
  `codcrmestadodescripcion` int(11) NOT NULL,
  `codcrmsemaforoestado` int(11) DEFAULT NULL,
  `crmestado_descripcionnombre` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`codcrmestadodescripcion`),
  KEY `fk_crmestado_descripcion_crmsemaforo_estado1_idx` (`codcrmsemaforoestado`),
  CONSTRAINT `fk_crmestado_descripcion_crmsemaforo_estado1` FOREIGN KEY (`codcrmsemaforoestado`) REFERENCES `crmsemaforo_estado` (`codcrmsemaforoestado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crmestado_descripcion`
--

LOCK TABLES `crmestado_descripcion` WRITE;
/*!40000 ALTER TABLE `crmestado_descripcion` DISABLE KEYS */;
INSERT INTO `crmestado_descripcion` VALUES (1,1,'Calificado'),(2,2,'Entregando papeleria'),(3,3,'Numero ocupado'),(4,4,'Finalizado por no contestar');
/*!40000 ALTER TABLE `crmestado_descripcion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crminfo_prospecto`
--

DROP TABLE IF EXISTS `crminfo_prospecto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crminfo_prospecto` (
  `codcrminfoprospecto` int(11) NOT NULL,
  `codcrminfogeneralprospecto` int(11) DEFAULT NULL,
  `codcrmtiposervicio` int(11) DEFAULT NULL,
  `codcrmcontactollamadas` int(11) DEFAULT NULL,
  `codcrmsemaforoestado` int(11) DEFAULT NULL,
  `codcrmestadodescripcion` int(11) DEFAULT NULL,
  `codcrmtipodomicilio` int(11) DEFAULT NULL,
  `codcrmfinalidadservicio` int(11) DEFAULT NULL,
  `crminfo_prospectotelefono` int(8) DEFAULT NULL,
  `crminfo_prospectoemail` varchar(100) DEFAULT NULL,
  `crminfo_prospectoingresos` double DEFAULT NULL,
  `crminfo_prospectoegresos` double DEFAULT NULL,
  `crminfo_prospectomonto` double DEFAULT NULL,
  `crminfo_prospectoañoslaborados` double DEFAULT NULL,
  `crminfo_prospectotrabajaactualmente` int(2) DEFAULT NULL,
  `crminfo_prospectodescripciontrabajoactual` varchar(100) DEFAULT NULL,
  `crminfo_prospectofechaprimerllamada` date DEFAULT NULL,
  `crminfo_prospectofechaultimallamada` date DEFAULT NULL,
  `crminfo_prospectodescripcion` varchar(600) DEFAULT NULL,
  `crminfo_prospectosucursalcerca` varchar(45) DEFAULT NULL,
  `crminfo_prospectocuentaconigss` int(2) DEFAULT NULL,
  `crminfo_prospectoañosdomicilio` double DEFAULT NULL,
  `crminfo_prospectocuentaencooperativa` int(2) DEFAULT NULL,
  `crminfo_contactadopor` varchar(200) DEFAULT NULL,
  `crminfo_prospectoreferenciado` int(11) DEFAULT NULL,
  PRIMARY KEY (`codcrminfoprospecto`),
  KEY `fk_crminfo_prospecto_crminfogeneral_prospecto_idx` (`codcrminfogeneralprospecto`),
  KEY `fk_crminfo_prospecto_crmcontacto_llamadas1_idx` (`codcrmcontactollamadas`),
  KEY `fk_crminfo_prospecto_crmsemaforo_estado1_idx` (`codcrmsemaforoestado`),
  KEY `fk_crminfo_prospecto_crmestado_descripcion1_idx` (`codcrmestadodescripcion`),
  KEY `fk_crminfo_prospecto_crmtipo_domicilio1_idx` (`codcrmtipodomicilio`),
  KEY `fk_crminfo_prospecto_crmtipo_servicio1_idx` (`codcrmtiposervicio`),
  KEY `fk_crminfo_prospecto_crmfinalidadservicio1_idx` (`codcrmfinalidadservicio`),
  CONSTRAINT `fk_crminfo_prospecto_crm_finalidadservicio1` FOREIGN KEY (`codcrmfinalidadservicio`) REFERENCES `crm_finalidadservicio` (`codcrmfinalidadservicio`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_crminfo_prospecto_crmcontacto_llamadas1` FOREIGN KEY (`codcrmcontactollamadas`) REFERENCES `crmcontacto_llamadas` (`codcrmcontactollamadas`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_crminfo_prospecto_crmestado_descripcion1` FOREIGN KEY (`codcrmestadodescripcion`) REFERENCES `crmestado_descripcion` (`codcrmestadodescripcion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_crminfo_prospecto_crminfogeneral_prospecto` FOREIGN KEY (`codcrminfogeneralprospecto`) REFERENCES `crminfogeneral_prospecto` (`codcrminfogeneralprospecto`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_crminfo_prospecto_crmsemaforo_estado1` FOREIGN KEY (`codcrmsemaforoestado`) REFERENCES `crmsemaforo_estado` (`codcrmsemaforoestado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_crminfo_prospecto_crmtipo_domicilio1` FOREIGN KEY (`codcrmtipodomicilio`) REFERENCES `crmtipo_domicilio` (`codcrmtipodomicilio`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_crminfo_prospecto_crmtipo_servicio1` FOREIGN KEY (`codcrmtiposervicio`) REFERENCES `crmtipo_servicio` (`codcrmtiposervicio`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crminfo_prospecto`
--

LOCK TABLES `crminfo_prospecto` WRITE;
/*!40000 ALTER TABLE `crminfo_prospecto` DISABLE KEYS */;
INSERT INTO `crminfo_prospecto` VALUES (1,1,1,1,2,1,1,1,52144414,'elderherre@gmail.com',250.16,0,1500,0,0,'','2020-01-01','2020-01-01','probando probando','',0,0,0,NULL,NULL),(2,3,1,1,4,1,2,1,56900142,'fdsantiagorizzo@yahoo.com',588,200,100000,0,2,'','2020-01-01','2020-01-01','','1',2,2,2,NULL,NULL),(3,2,1,1,3,1,1,1,47029186,'herbert.macdonald1@gmail.com',0,0,85000,0,0,'','2020-01-01','2020-01-01','probando probando','',0,0,0,NULL,NULL),(4,4,1,1,2,2,1,1,37060582,'estivenstuardo6@gmail.com',250,100,50000,0,2,'','2020-01-01','2020-01-01','1','1',2,2,2,NULL,NULL),(5,1,1,1,1,1,1,1,52144414,'elderherre@gmail.com',0,0,1500,0,0,'','2020-01-01','2020-01-01','','',0,0,0,'Facebook',0);
/*!40000 ALTER TABLE `crminfo_prospecto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crminfogeneral_prospecto`
--

DROP TABLE IF EXISTS `crminfogeneral_prospecto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crminfogeneral_prospecto` (
  `codcrminfogeneralprospecto` int(11) NOT NULL AUTO_INCREMENT,
  `crminfogeneral_prospectodpi` varchar(45) DEFAULT NULL,
  `crminfogeneral_prospectonombre` varchar(45) DEFAULT NULL,
  `crminfogeneral_prospectoapellido` varchar(45) DEFAULT NULL,
  `crminfogeneral_prospectonombrecompleto` varchar(45) DEFAULT NULL,
  `crminfogeneral_prospectoblacklist` int(2) DEFAULT NULL,
  PRIMARY KEY (`codcrminfogeneralprospecto`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crminfogeneral_prospecto`
--

LOCK TABLES `crminfogeneral_prospecto` WRITE;
/*!40000 ALTER TABLE `crminfogeneral_prospecto` DISABLE KEYS */;
INSERT INTO `crminfogeneral_prospecto` VALUES (1,'2990655880101','José','Gonzalez','Jose Gonzalez Teo',0),(2,'2990655880102','Pepe','Aguilar','Pepe Aguilar',0),(3,'2411548550101','','','Francisco Santiago',0),(4,'2211723000114','','','Estiven Estuardo Guevara Canvas',0),(5,'100000','','','56900142',0);
/*!40000 ALTER TABLE `crminfogeneral_prospecto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crmsemaforo_estado`
--

DROP TABLE IF EXISTS `crmsemaforo_estado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crmsemaforo_estado` (
  `codcrmsemaforoestado` int(11) NOT NULL,
  `crmsemaforo_estadonombre` varchar(45) DEFAULT NULL,
  `crmsemaforo_estadodescripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codcrmsemaforoestado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crmsemaforo_estado`
--

LOCK TABLES `crmsemaforo_estado` WRITE;
/*!40000 ALTER TABLE `crmsemaforo_estado` DISABLE KEYS */;
INSERT INTO `crmsemaforo_estado` VALUES (1,'Verde','Aprobado'),(2,'Amarillo','En Proceso'),(3,'Naranja','No contesta'),(4,'Rojo','No aplica');
/*!40000 ALTER TABLE `crmsemaforo_estado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crmtamporal_cargadedatos`
--

DROP TABLE IF EXISTS `crmtamporal_cargadedatos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crmtamporal_cargadedatos` (
  `codcrmtamporalcargadedatos` int(11) NOT NULL AUTO_INCREMENT,
  `crmtamporal_cargadedatosfecha` date DEFAULT NULL,
  `crmtamporal_cargadedatosnombre` varchar(85) DEFAULT NULL,
  `crmtamporal_cargadedatostelefono` int(8) DEFAULT NULL,
  `crmtamporal_cargadedatoscorreo` varchar(100) DEFAULT NULL,
  `crmtamporal_cargadedatosdpi` varchar(45) DEFAULT NULL,
  `crmtamporal_cargadedatoscantidad` double DEFAULT NULL,
  `crmtamporal_cargadedatosfinalidad` varchar(80) DEFAULT NULL,
  `crmtamporal_cargadedatoszona` varchar(80) DEFAULT NULL,
  `crmtamporal_cargadedatotiposervicio` int(11) DEFAULT NULL,
  `crmtamporal_cargadedatocontactadopor` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`codcrmtamporalcargadedatos`)
) ENGINE=InnoDB AUTO_INCREMENT=57 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crmtamporal_cargadedatos`
--

LOCK TABLES `crmtamporal_cargadedatos` WRITE;
/*!40000 ALTER TABLE `crmtamporal_cargadedatos` DISABLE KEYS */;
INSERT INTO `crmtamporal_cargadedatos` VALUES (1,'2021-01-01','Elder Esau Herrera',52144414,'elderherre@gmail.com','2990655880101',1500,'Unificar deudas','Mixco',1,'Facebook'),(2,'2021-01-02','Francisco Santiago',56900142,'fdsantiagorizzo@yahoo.com','2411548550101',100000,'Comprar un veh√≠culo','zona 11',1,'Facebook'),(3,'2021-01-03','Hebert Fernando Mac Donald Pivaral',47029186,'herbert.macdonald1@gmail.com','2990655880102',85000,'Unificar deudas','zona 13',1,'Facebook'),(4,'2021-01-03','Estiven Estuardo Guevara Canvas',37060582,'estivenstuardo6@gmail.com','2211723000114',50000,'Comprar un veh√≠culo','zona 12',1,'Facebook'),(5,'2021-01-01','Elder Esau Herrera',52144414,'elderherre@gmail.com','2990655880101',1500,'Unificar deudas','Mixco',1,'Facebook'),(6,'2021-01-02','Francisco Santiago',56900142,'fdsantiagorizzo@yahoo.com','2411548550101',100000,'Comprar un vehículo','zona 11',1,'Facebook'),(7,'2021-01-03','Hebert Fernando Mac Donald Pivaral',47029186,'herbert.macdonald1@gmail.com','2990655880102',85000,'Unificar deudas','zona 13',1,'Facebook'),(8,'2021-01-03','Estiven Estuardo Guevara Can√&#176;s',37060582,'estivenstuardo6@gmail.com','2211723000114',50000,'Comprar un veh√≠culo','zona 12',1,'Facebook');
/*!40000 ALTER TABLE `crmtamporal_cargadedatos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crmtipo_domicilio`
--

DROP TABLE IF EXISTS `crmtipo_domicilio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crmtipo_domicilio` (
  `codcrmtipodomicilio` int(11) NOT NULL,
  `crmtipo_domicilionombre` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`codcrmtipodomicilio`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crmtipo_domicilio`
--

LOCK TABLES `crmtipo_domicilio` WRITE;
/*!40000 ALTER TABLE `crmtipo_domicilio` DISABLE KEYS */;
INSERT INTO `crmtipo_domicilio` VALUES (1,'Casa Propia'),(2,'Apartamento');
/*!40000 ALTER TABLE `crmtipo_domicilio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `crmtipo_servicio`
--

DROP TABLE IF EXISTS `crmtipo_servicio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `crmtipo_servicio` (
  `codcrmtiposervicio` int(11) NOT NULL AUTO_INCREMENT,
  `crmtipo_servicionombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codcrmtiposervicio`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `crmtipo_servicio`
--

LOCK TABLES `crmtipo_servicio` WRITE;
/*!40000 ALTER TABLE `crmtipo_servicio` DISABLE KEYS */;
INSERT INTO `crmtipo_servicio` VALUES (1,'Prestamos Varios');
/*!40000 ALTER TABLE `crmtipo_servicio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_administracionlote`
--

DROP TABLE IF EXISTS `ep_administracionlote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_administracionlote` (
  `codepadministracionlote` int(11) NOT NULL,
  `ep_administracionlotefechainicio` date DEFAULT NULL,
  `ep_administracionfechafin` date DEFAULT NULL,
  `ep_administracionloteestado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`codepadministracionlote`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_administracionlote`
--

LOCK TABLES `ep_administracionlote` WRITE;
/*!40000 ALTER TABLE `ep_administracionlote` DISABLE KEYS */;
INSERT INTO `ep_administracionlote` VALUES (1,'2018-01-01','2018-01-15',0),(2,'2021-01-01','2021-04-15',1),(3,'2019-01-01','2019-01-15',0),(4,'2017-01-01','2017-01-01',0);
/*!40000 ALTER TABLE `ep_administracionlote` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_bactivos`
--

DROP TABLE IF EXISTS `ep_bactivos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_bactivos` (
  `codepbactivos` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_bactivosinmuebles` tinyint(1) DEFAULT NULL,
  `ep_bactivosvehiculos` tinyint(1) DEFAULT NULL,
  `ep_bactivosequipo` tinyint(1) DEFAULT NULL,
  `ep_bactivoscaja` double DEFAULT NULL,
  PRIMARY KEY (`codepbactivos`),
  KEY `fk_ep_bactivos_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_bactivos_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_bactivos`
--

LOCK TABLES `ep_bactivos` WRITE;
/*!40000 ALTER TABLE `ep_bactivos` DISABLE KEYS */;
INSERT INTO `ep_bactivos` VALUES (1,1,1,1,1,5000),(2,2,1,1,1,5000),(3,3,1,1,1,12),(4,2,1,1,1,5000),(5,3,1,1,1,12),(6,2,1,1,1,5000),(7,3,1,1,1,12),(8,2,1,1,1,5000),(9,17,1,1,1,2500),(10,21,1,1,1,0),(11,22,1,1,1,0),(12,23,1,1,1,0),(13,24,1,1,1,0),(14,25,1,1,1,0),(15,26,1,1,1,0),(16,27,1,1,1,0),(17,28,1,1,1,0),(18,29,1,1,1,0),(19,30,1,1,1,0),(20,31,1,1,1,2500),(21,32,1,1,1,500),(22,35,1,1,1,0),(23,36,1,1,1,0),(24,37,1,1,1,0),(25,38,1,1,1,0),(26,39,1,1,1,0),(27,40,1,1,1,0),(28,41,1,1,1,0),(29,42,1,1,1,0),(30,43,1,1,1,0);
/*!40000 ALTER TABLE `ep_bactivos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_contratistaproveedor`
--

DROP TABLE IF EXISTS `ep_contratistaproveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_contratistaproveedor` (
  `codepcontratistaproveedor` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_contratistaproveedor_si_no` int(1) DEFAULT NULL,
  PRIMARY KEY (`codepcontratistaproveedor`),
  KEY `fk_ep_contratistaproveedor_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_contratistaproveedor_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_contratistaproveedor`
--

LOCK TABLES `ep_contratistaproveedor` WRITE;
/*!40000 ALTER TABLE `ep_contratistaproveedor` DISABLE KEYS */;
INSERT INTO `ep_contratistaproveedor` VALUES (1,1,1);
/*!40000 ALTER TABLE `ep_contratistaproveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_control`
--

DROP TABLE IF EXISTS `ep_control`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_control` (
  `codepcontrol` int(11) NOT NULL AUTO_INCREMENT,
  `codgenusuario` int(11) DEFAULT NULL,
  `codepadministracionlote` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  PRIMARY KEY (`codepcontrol`),
  KEY `fk_ep_control_ep_administracionlote1_idx` (`codepadministracionlote`),
  KEY `fk_ep_control_gen_usuario1_idx` (`codgenusuario`),
  CONSTRAINT `fk_ep_control_ep_administracionlote1` FOREIGN KEY (`codepadministracionlote`) REFERENCES `ep_administracionlote` (`codepadministracionlote`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_control_gen_usuario1` FOREIGN KEY (`codgenusuario`) REFERENCES `gen_usuario` (`codgenusuario`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_control`
--

LOCK TABLES `ep_control` WRITE;
/*!40000 ALTER TABLE `ep_control` DISABLE KEYS */;
INSERT INTO `ep_control` VALUES (10,5,2,32),(11,6,2,4),(14,8,4,5),(15,7,4,6),(22,16,2,36),(23,17,2,35),(24,18,2,37),(25,15,2,38),(26,21,2,39),(27,2,2,43);
/*!40000 ALTER TABLE `ep_control` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_controlingreso`
--

DROP TABLE IF EXISTS `ep_controlingreso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_controlingreso` (
  `codepcontrolingreso` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_controlingresoingreso` tinyint(1) DEFAULT NULL,
  `ep_controlingresnegocio` tinyint(1) DEFAULT NULL,
  `ep_controlingresoremesas` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`codepcontrolingreso`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_controlingreso`
--

LOCK TABLES `ep_controlingreso` WRITE;
/*!40000 ALTER TABLE `ep_controlingreso` DISABLE KEYS */;
INSERT INTO `ep_controlingreso` VALUES (1,1,1,1,127),(2,17,1,1,1),(3,21,1,1,1),(4,22,1,1,1),(5,23,1,1,1),(6,24,1,1,1),(7,25,1,1,1),(8,26,1,1,1),(9,27,1,1,1),(10,28,1,1,1),(11,29,1,1,1),(12,30,1,1,1),(13,31,1,1,1),(14,31,1,1,1),(15,31,1,1,1),(16,32,1,1,1),(17,35,1,1,1),(18,36,1,1,1),(19,37,1,1,1),(20,38,1,1,1),(21,39,1,1,1),(22,40,1,1,1),(23,41,1,1,1),(24,42,1,1,1),(25,43,1,1,1);
/*!40000 ALTER TABLE `ep_controlingreso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_cuentas`
--

DROP TABLE IF EXISTS `ep_cuentas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_cuentas` (
  `codepcuentas` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `codeptipocuenta` int(11) DEFAULT NULL,
  `codeptipomoneda` int(11) DEFAULT NULL,
  `codeptipoestatuscuenta` int(11) DEFAULT NULL,
  `codepinstitucion` int(11) DEFAULT NULL,
  `codeptipocuentacooperativa` int(11) DEFAULT NULL,
  `ep_cuentasnombre` varchar(100) DEFAULT NULL,
  `ep_cuentasmonto` double DEFAULT NULL,
  `ep_cuentasorigen` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`codepcuentas`),
  KEY `fk_ep_cuentas_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  KEY `fk_ep_cuentas_ep_tipocuenta1_idx` (`codeptipocuenta`),
  KEY `fk_ep_cuentas_ep_tipomoneda1_idx` (`codeptipomoneda`),
  KEY `fk_ep_cuentas_ep_tipoestatuscuenta1_idx` (`codeptipoestatuscuenta`),
  KEY `fk_ep_cuentas_ep_institucion1_idx` (`codepinstitucion`),
  KEY `fk_ep_cuentas_ep_tipocuentacooperativa1_idx` (`codeptipocuentacooperativa`),
  CONSTRAINT `fk_ep_cuentas_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_cuentas_ep_institucion1` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_cuentas_ep_tipocuenta1` FOREIGN KEY (`codeptipocuenta`) REFERENCES `ep_tipocuenta` (`codeptipocuenta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_cuentas_ep_tipoestatuscuenta1` FOREIGN KEY (`codeptipoestatuscuenta`) REFERENCES `ep_tipoestatuscuenta` (`codeptipoestatuscuenta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_cuentas_ep_tipomoneda1` FOREIGN KEY (`codeptipomoneda`) REFERENCES `ep_tipomoneda` (`codeptipomoneda`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_cuentas_institucion` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_cuentas_tipocuentacooperativa1` FOREIGN KEY (`codeptipocuentacooperativa`) REFERENCES `ep_tipocuentacooperativa` (`codeptipocuentacooperativa`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_cuentas`
--

LOCK TABLES `ep_cuentas` WRITE;
/*!40000 ALTER TABLE `ep_cuentas` DISABLE KEYS */;
INSERT INTO `ep_cuentas` VALUES (1,1,4,1,1,NULL,NULL,'PedritoArrivillaga',22,'22'),(2,13,1,1,1,NULL,NULL,'BI',22,'22'),(3,14,1,1,2,NULL,NULL,'BI',66,'66'),(4,1,4,1,1,NULL,NULL,'Pedrulo',4500,'325'),(5,1,3,1,1,3,1,'nulo',22,'Herencia'),(6,1,3,1,1,3,2,'nulo',22,'Desembolso'),(7,1,1,1,1,1,NULL,'nulo',20000,'Heredacion'),(8,1,3,1,1,3,1,'nulo',2500,'Prestamitas'),(9,1,4,1,1,1,NULL,'Diego',5000,'Manutención del niño'),(10,1,4,1,1,1,NULL,'Pablo',5000,'Manutención del perro'),(11,30,2,1,2,1,NULL,'nulo',564565,'856465'),(12,30,1,1,1,1,NULL,'nulo',500,'Teo'),(13,30,3,1,1,3,1,'nulo',5656,'asdas'),(14,30,4,1,1,1,NULL,'asdas',6456,'asdas'),(15,21,1,1,1,1,NULL,'nulo',500,'Prueba'),(16,21,3,1,1,3,1,'nulo',500,'asdas'),(18,31,3,1,1,38,1,'nulo',150,'prueba'),(25,4,1,1,2,4,1,'nulo',1,'Salario'),(26,4,2,1,1,4,1,'nulo',700,'Salario'),(27,4,2,1,1,5,1,'nulo',1200,'Salario'),(28,4,3,1,1,38,1,'nulo',1200,'Sueldo'),(29,4,3,1,1,38,2,'nulo',16500,'Sueldo'),(30,32,3,1,1,38,1,'nulo',2394,'AHORROS POR DESCUENTO MENSUAL DE PLANILLA'),(31,36,3,1,1,38,1,'nulo',1000,'Ahorros personales'),(32,37,3,1,1,29,2,'nulo',1,'trabajo'),(33,37,4,1,1,1,1,'kevin rivera',1,'helados'),(34,35,2,1,1,5,1,'nulo',100,'Ahorro'),(35,35,2,1,1,5,1,'nulo',300,'Ahorro'),(36,35,2,1,1,14,1,'nulo',100,'Ahorro'),(37,35,3,1,1,38,1,'nulo',50,'Ahorros'),(38,38,1,1,1,4,1,'nulo',500,'Ahorro'),(39,35,3,1,1,38,2,'nulo',100,''),(40,35,4,1,1,1,1,'Henry Castillo',5,'Pasaje'),(41,38,1,1,1,5,1,'nulo',2000,'Ahorro'),(42,38,1,2,1,5,1,'nulo',50,'Ahorro'),(43,38,3,1,1,38,2,'nulo',550,'Salario'),(44,38,3,1,1,38,1,'nulo',125,'Salario'),(45,32,3,1,1,38,2,'nulo',284,'AHORROS'),(46,31,1,1,1,2,1,'nulo',100,'Prueba'),(47,31,3,1,1,29,1,'nulo',100,'Prteuba'),(48,31,4,1,1,1,1,'Prueba',5000,'asdas'),(49,31,4,1,1,1,1,'1',213,'asdas');
/*!40000 ALTER TABLE `ep_cuentas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_cuentasporpagar`
--

DROP TABLE IF EXISTS `ep_cuentasporpagar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_cuentasporpagar` (
  `codepcuentasporpagar` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `codeptipocuentasporpagar` int(11) DEFAULT NULL,
  `ep_cuentasporpagardescripcion` varchar(100) DEFAULT NULL,
  `ep_cuentasporpagarmonto` double DEFAULT NULL,
  PRIMARY KEY (`codepcuentasporpagar`),
  KEY `fk_ep_cuentasporpagar_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  KEY `fk_ep_cuentasporpagar_ep_tipocuentasporpagar1_idx` (`codeptipocuentasporpagar`),
  CONSTRAINT `fk_ep_cuentasporpagar_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_cuentasporpagar_ep_tipocuentasporpagar1` FOREIGN KEY (`codeptipocuentasporpagar`) REFERENCES `ep_tipocuentaspopagar` (`codeptipocuentaspopagar`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_cuentasporpagar`
--

LOCK TABLES `ep_cuentasporpagar` WRITE;
/*!40000 ALTER TABLE `ep_cuentasporpagar` DISABLE KEYS */;
INSERT INTO `ep_cuentasporpagar` VALUES (1,1,1,'Por defecto de presencia',1500),(2,1,2,'Por efecto de manualidad',2500),(3,1,1,'Por efecto de prestamos',50000),(4,30,1,'sadsad',5646),(5,21,1,'Prueba',6564),(6,21,1,'PRUEBA',500),(7,32,2,'universidad',2000),(8,37,1,'0004379741',10000),(9,31,1,'1',5456);
/*!40000 ALTER TABLE `ep_cuentasporpagar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_deudasvarias`
--

DROP TABLE IF EXISTS `ep_deudasvarias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_deudasvarias` (
  `codepdeudasvarias` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_deudasvariasdescripcion` varchar(200) DEFAULT NULL,
  `ep_deudasvariasvalor` double DEFAULT NULL,
  PRIMARY KEY (`codepdeudasvarias`),
  KEY `fk_ep_deudasvarias_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_deudasvarias_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_deudasvarias`
--

LOCK TABLES `ep_deudasvarias` WRITE;
/*!40000 ALTER TABLE `ep_deudasvarias` DISABLE KEYS */;
INSERT INTO `ep_deudasvarias` VALUES (1,1,'CASA EN LA PLAYA',2000),(2,17,'Ella',4500000),(3,21,'',0),(4,22,'',0),(5,23,'',0),(6,24,'',0),(7,25,'',0),(8,26,'',0),(9,27,'',0),(10,28,'',0),(11,29,'',0),(12,30,'',0),(13,31,'Pureba',54564),(14,32,'Prestamo personal que me hizo mi hermano',3000),(15,35,'',0),(16,36,'',0),(17,37,'',0),(18,38,'',0),(19,39,'',0),(20,40,'',0),(21,41,'',0),(22,42,'',0),(23,43,'',0);
/*!40000 ALTER TABLE `ep_deudasvarias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_egresos`
--

DROP TABLE IF EXISTS `ep_egresos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_egresos` (
  `codepegresos` int(11) NOT NULL,
  `codinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_egresosalimentacion` double DEFAULT NULL,
  `ep_egresostransportes` double DEFAULT NULL,
  `ep_egresosestudios` double DEFAULT NULL,
  `ep_egresosprestamo` double DEFAULT NULL,
  `ep_egresostarjeta` double DEFAULT NULL,
  `ep_egresosropa` double DEFAULT NULL,
  `ep_egresosrecreacion` double DEFAULT NULL,
  `ep_egresosotros` double DEFAULT NULL,
  PRIMARY KEY (`codepegresos`),
  KEY `fk_ep_egresos_ep_informaciongeneral1_idx` (`codinformaciongeneralcif`),
  CONSTRAINT `fk_ep_egresos_ep_informaciongeneral1` FOREIGN KEY (`codinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_egresos`
--

LOCK TABLES `ep_egresos` WRITE;
/*!40000 ALTER TABLE `ep_egresos` DISABLE KEYS */;
INSERT INTO `ep_egresos` VALUES (1,1,100,100,100,100,100,100,100,100),(2,17,0,0,0,0,0,0,0,0),(3,21,0,0,0,0,0,0,0,0),(4,22,0,0,0,0,0,0,0,0),(5,23,0,0,0,0,0,0,0,0),(6,24,0,0,0,0,0,0,0,0),(7,25,0,0,0,0,0,0,0,0),(8,26,0,0,0,0,0,0,0,0),(9,27,0,0,0,0,0,0,0,0),(10,28,0,0,0,0,0,0,0,0),(11,29,0,0,0,0,0,0,0,0),(12,30,0,0,0,0,0,0,0,0),(13,31,564,54656,56456,564,456,45,564,564),(14,32,1500,150,0,1000,200,200,400,0),(15,35,1000,350,450,0,0,250,600,1350),(16,36,500,300,700,300,0,300,0,0),(17,37,500,700,750,2000,4500,500,1000,800),(18,38,0,0,0,0,0,0,0,0),(19,39,0,0,0,0,0,0,0,0),(20,40,0,0,0,0,0,0,0,0),(21,41,0,0,0,0,0,0,0,0),(22,42,0,0,0,0,0,0,0,0),(23,43,0,0,0,0,0,0,0,0);
/*!40000 ALTER TABLE `ep_egresos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_estadocivil`
--

DROP TABLE IF EXISTS `ep_estadocivil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_estadocivil` (
  `codepestadocivil` int(11) NOT NULL,
  `ep_estadocivilnombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codepestadocivil`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_estadocivil`
--

LOCK TABLES `ep_estadocivil` WRITE;
/*!40000 ALTER TABLE `ep_estadocivil` DISABLE KEYS */;
INSERT INTO `ep_estadocivil` VALUES (1,'Soltero(A)'),(2,'Casado(A)'),(3,'Unido(A)'),(4,'Divorciado(A)'),(5,'Viudo(A)');
/*!40000 ALTER TABLE `ep_estadocivil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_estudio`
--

DROP TABLE IF EXISTS `ep_estudio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_estudio` (
  `codepestudio` int(11) NOT NULL AUTO_INCREMENT,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_estudionombre` varchar(100) DEFAULT NULL,
  `ep_estudioaño` int(4) DEFAULT NULL,
  `ep_estudioduracion` varchar(100) DEFAULT NULL,
  `ep_estudiolugar` varchar(100) DEFAULT NULL,
  `ep_estudioidioma` varchar(100) DEFAULT NULL,
  `ep_estudiotipo` varchar(45) DEFAULT NULL,
  `ep_estudiomodalidad` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codepestudio`),
  KEY `fk_ep_estudio_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_estudio_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=69 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_estudio`
--

LOCK TABLES `ep_estudio` WRITE;
/*!40000 ALTER TABLE `ep_estudio` DISABLE KEYS */;
INSERT INTO `ep_estudio` VALUES (1,1,'Ingenieria en sistemas',5,'5','Universidad Mariano Galvez De Guatemala','Español','0','Presencial'),(2,1,'informatica',2,'2','Guatemala','Ingles','1','Virtual'),(3,1,'Ingles',5,'5','Guatemala','Español','1','Presencial'),(4,3,'',0,'','','','1',''),(5,4,'',0,'','','','0','sindato'),(6,4,'',0,'','','','1',''),(7,5,'',0,'','','','0','sindato'),(8,5,'',0,'','','','1',''),(9,6,'',0,'','','','0','sindato'),(10,6,'',0,'','','','1',''),(11,7,'',0,'','','','0','sindato'),(12,7,'',0,'','','','1',''),(13,8,'',0,'','','','0','sindato'),(14,8,'',0,'','','','1',''),(15,9,'',0,'','','','0','sindato'),(16,9,'',0,'','','','1',''),(17,10,'',0,'','','','0','sindato'),(18,10,'',0,'','','','1',''),(19,11,'',0,'','','','0','sindato'),(20,11,'',0,'','','','1',''),(21,12,'',0,'','','','0','sindato'),(22,12,'',0,'','','','1',''),(23,13,'',0,'','','','0','sindato'),(24,13,'',0,'','','','1',''),(25,14,'',0,'','','','0','sindato'),(26,14,'',0,'','','','1',''),(27,15,'',0,'','','','0','sindato'),(28,15,'',0,'','','','1',''),(29,16,'Ingenieria en sistemas',5,'5','Guatemala','Español','0','Presencial'),(30,16,'informatica',2,'2','Guatemala','Ingles','1','Virtual'),(31,16,'Ingles',5,'5','Guatemala','Español','1','Presencial'),(32,17,'Tecnicas de estudios',5,'5','Universidad Mariano Galvez De Guatemala','Español','0',''),(33,1,'Posteria',5,'4','PasteriaS.A','Español','1','Virtual'),(34,21,'',0,'','','','0',''),(35,22,'',0,'','','','0',''),(36,23,'',0,'','','','0',''),(37,24,'',0,'','','','0',''),(38,25,'',0,'','','','0',''),(39,26,'',0,'','','','0',''),(40,27,'',0,'','','','0',''),(41,28,'',0,'','','','0',''),(42,29,'',0,'','','','0',''),(43,30,'',0,'','','','0',''),(44,30,'1asdas',3,'5','1sadas','fsfsd','1','1asdas'),(45,21,'Prueba',2020,'5','Pureba','Español','1','sadasd'),(46,21,'Ingenieria en Sistemas',2021,'10 semestre','Mariano Galvez','sinidioma','0','sinmodalidad'),(47,2,'Ingenieria en Sistemas',5,'10 semestre','Mariano Galvez','sinidioma','0','sinmodalidad'),(48,2,'Ingles',10,'1','Umg','Ingles','1','1'),(55,4,'Economía',5,'Graduado','San Carlos','sinidioma','0','sinmodalidad'),(56,4,'Gestion de Riesgos',2019,'50','Escuela Bancaria de Guatemala','Español','1','presencial'),(57,4,'Gestion de Riesgos',2019,'120','Politécnico Superior de Pruebas ','Español','1','en linea'),(58,32,'Ciencias Juridicas y Sociales',1,'1','Universidad Rural de Guatemala','sinidioma','0','sinmodalidad'),(59,35,'Licenciatura en Ciencias de la Administración',2020,'7mo Semestre','Universidad Mariano Gálvez de Guatemala','sinidioma','0','sinmodalidad'),(60,35,'Operador y reparador de computadoras',2011,'9','Centro de Formación Profesional Don Bosco','Español','1','Presencial'),(61,35,'Certificado e-commerce ',2019,'6','Google','Español','1','En Linea'),(62,35,'Certificado Marketing Digital ',2020,'6','Google','Español','1','En Linea'),(63,35,'Gestión de Recursos Humanos – Los Fundamentos Del Concepto de Liderazgo – Gestión de Equipos de Trab',2021,'6','International E-Learning Academy','Español','1','En Linea'),(64,37,'Administraciòn de empresas',2021,'3er semestre','Mariano Galvez','sinidioma','0','sinmodalidad'),(65,37,'Lavado de Dinero y Financiamiento del terrorismo',2021,'1','kon tacto','Español','1','en linea'),(66,31,'Ingenieria en Sistemas',10,'10 semestre','Mariano Galvez','sinidioma','0','sinmodalidad'),(67,31,'Ingles',2020,'1','Umg','Ingles','1','Virtual'),(68,31,'Ingles',234,'1','Umg','Ingles','1','Virtual');
/*!40000 ALTER TABLE `ep_estudio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_infofamiliar`
--

DROP TABLE IF EXISTS `ep_infofamiliar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_infofamiliar` (
  `codepinfofamiliar` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_infofamiliarnombreconyuge` varchar(100) DEFAULT NULL,
  `ep_infofamiliarnombrehijos` varchar(100) DEFAULT NULL,
  `ep_infofamiliarocupacionconyuge` varchar(50) DEFAULT NULL,
  `ep_infofamiliarocupacionhijos` varchar(50) DEFAULT NULL,
  `ep_infofamiliarapellidocascada` varchar(50) DEFAULT NULL,
  `ep_infofamiliarfechanacimientoconyuge` date DEFAULT NULL,
  `ep_infofamiliarfechanacimientohijo` date DEFAULT NULL,
  `ep_infofamiliarnombreemergencia` varchar(100) DEFAULT NULL,
  `ep_infofamiliarnumeroemergencia` int(8) DEFAULT NULL,
  `ep_infofamiliarparentesco` varchar(50) DEFAULT NULL,
  `ep_infofamiliarcomentario` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`codepinfofamiliar`),
  KEY `fk_ep_infofamiliar_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_infofamiliar_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_infofamiliar`
--

LOCK TABLES `ep_infofamiliar` WRITE;
/*!40000 ALTER TABLE `ep_infofamiliar` DISABLE KEYS */;
INSERT INTO `ep_infofamiliar` VALUES (1,1,'Maria','Pedro','Estudiante','Estudiante','Juarez','2020-04-24','2020-04-08','Pedro',24358599,'Tio','Es responsable'),(2,1,'Maria','Pepe','Estudiante','Futbolero','Juarez','2020-04-24','2020-04-10','Pedro',24358599,'Tio','El primer hijo'),(3,5,'','','','','','2020-04-24','2020-04-24','',0,'',''),(4,6,'','','','','','2020-04-24','2020-04-24','',0,'',''),(5,7,'','','','','','2020-04-24','2020-04-24','',0,'',''),(6,8,'','','','','','2020-04-24','2020-04-24','',0,'',''),(7,9,'','','','','','2020-04-24','2020-04-24','',0,'',''),(8,10,'','','','','','2020-04-24','2020-04-24','',0,'',''),(9,11,'','','','','','2020-04-24','2020-04-24','',0,'',''),(10,12,'','','','','','2020-04-24','2020-04-24','',0,'',''),(11,13,'','','','','','2020-04-24','2020-04-24','',0,'',''),(12,14,'','','','','','2020-04-24','2020-04-24','',0,'',''),(13,15,'','','','','','2020-04-24','2020-04-24','',0,'',''),(16,17,'','','','','','2020-04-24','0000-00-00','Alejandro',222,'Tio',''),(17,1,'Maria','','Estudiante','','Juarez','2020-04-24','2020-04-25','Pedro',24358599,'Tio',''),(18,1,'Maria','Luis','Estudiante','Futbol','Juarez','2020-04-24','2020-04-25','Pedro',24358599,'Tio','Hola'),(19,1,'Maria','sdaasd','Estudiante','sadas','Juarez','2020-04-24','2020-04-15','Pedro',24358599,'Tio','dasd'),(20,21,'','','','','','0001-01-01','0000-00-00','Prueba',123456,'Prueba',''),(21,20,'','Keys','','asdsa','','0000-00-00','2020-04-22','',0,'','sadas'),(22,22,'','','','','','0000-00-00','0000-00-00','',0,'',''),(23,23,'','','','','','0000-00-00','0000-00-00','',0,'',''),(24,24,'','','','','','0000-00-00','0000-00-00','',0,'',''),(25,25,'','','','','','0000-00-00','0000-00-00','',0,'',''),(26,26,'','','','','','0000-00-00','0000-00-00','',0,'',''),(27,27,'','','','','','0000-00-00','0000-00-00','',0,'',''),(28,28,'','','','','','0000-00-00','0000-00-00','',0,'',''),(29,29,'','','','','','0000-00-00','0000-00-00','',0,'',''),(30,30,'','','','','','0000-00-00','0000-00-00','',0,'',''),(31,30,'','Diego','','sadas','','0000-00-00','2020-04-22','',0,'','asdasdas'),(32,30,'','Diego','','sadas','','0000-00-00','2020-04-22','',0,'','asdasdas'),(33,30,'','Diego','','sadas','','0000-00-00','2020-04-22','',0,'','asdasdas'),(34,30,'','sadsa','','asdas','','0000-00-00','2020-04-25','',0,'','adasd'),(36,31,'','Prueba','','Estudiante','','2020-04-24','2020-04-25','Prueba',54564,'Prueba','saasda'),(38,31,'','Keys','','sadas','','2020-04-24','2020-04-07','Prueba',54564,'Prueba','asdas'),(39,32,'Joselinne Elizabeth De La Cruz Garcia','','Perito Contador','','Reyes','1994-04-27','2020-04-08','Joselinne Elizabeth De La Cruz Garcia',22563205,'Esposa',''),(40,35,'','','','','','2020-04-24','2020-04-08','Ana Patricia González Torres',43881251,'Madre',''),(41,36,'','','','','','0000-00-00','2020-04-08','',0,'',''),(42,37,'','','','','','0000-00-00','2020-04-08','',0,'',''),(43,35,'','Gepeto Rivera','','Estudiante','','2020-04-24','2019-07-06','Ana Patricia González Torres',43881251,'Madre',''),(44,37,'','Cintya Castillo Ruano','','Estudiante','','0000-00-00','2020-12-04','',0,'',''),(45,38,'Leslie Stella Catillo Caridi','','Gestora de Calidad','','de Arriola','1977-04-19','2020-04-08','Leslie Stella Catillo Caridi',53154970,'Esposa',''),(46,38,'Leslie Stella Catillo Caridi','Melanie Eunice Arriola Castillo','Gestora de Calidad','Estudiante','de Arriola','1977-04-19','1996-11-18','Leslie Stella Catillo Caridi',53154970,'Esposa',''),(47,38,'Leslie Stella Catillo Caridi','Natalie Sofía Arriola Castillo','Gestora de Calidad','Estudiante','de Arriola','1977-04-19','2004-11-11','Leslie Stella Catillo Caridi',53154970,'Esposa',''),(48,39,'','','','','','0000-00-00','2020-04-08','',0,'',''),(49,39,'','CARLOS SAMUEL HERRERA MÉNDEZ','','ESTUDIANTE','','0000-00-00','2008-07-21','',0,'',''),(50,39,'','CARLOS DANIEL HERRERA MÉNDEZ','','ESTUDIANTE','','0000-00-00','2009-06-02','',0,'',''),(51,39,'','JAVIER ANDRÉS HERRERA MÉNDEZ','','ESTUDIANTE','','0000-00-00','2012-02-19','',0,'',''),(52,31,'','asdsa','','asdsad','','2020-04-24','2020-04-23','Prueba',54564,'Prueba','asdasd'),(53,40,'','','','','','0000-00-00','2020-04-08','',0,'',''),(54,41,'','','','','','0000-00-00','2020-04-08','',0,'',''),(55,42,'','','','','','0000-00-00','2020-04-08','',0,'',''),(56,43,'','','','','','0000-00-00','2020-04-08','',0,'','');
/*!40000 ALTER TABLE `ep_infofamiliar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_informaciongeneral`
--

DROP TABLE IF EXISTS `ep_informaciongeneral`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_informaciongeneral` (
  `codepinformaciongeneralcif` int(11) NOT NULL AUTO_INCREMENT,
  `codgensucursal` int(11) DEFAULT NULL,
  `codepestadocivil` int(11) DEFAULT NULL,
  `codgentipoidentificacion` int(11) DEFAULT NULL,
  `codgendepartamento` int(11) DEFAULT NULL,
  `codgenmunicipio` int(11) DEFAULT NULL,
  `codgenzona` int(11) DEFAULT NULL,
  `codgenarea` int(11) DEFAULT NULL,
  `codeptipoestado` int(11) DEFAULT NULL,
  `ep_informaciongeneralprimernombre` varchar(15) DEFAULT NULL,
  `ep_informaciongeneralsegundonombre` varchar(15) DEFAULT NULL,
  `ep_informaciongeneralprimerapellido` varchar(15) DEFAULT NULL,
  `ep_informaciongeneralsegundoapellido` varchar(15) DEFAULT NULL,
  `ep_informaciongeneralnombreadicional` varchar(15) DEFAULT NULL,
  `ep_informaciongeneralfechanacimiento` date DEFAULT NULL,
  `ep_informaciongeneralnit` varchar(15) DEFAULT NULL,
  `ep_informaciongeneralnumeroidentificacion` int(20) DEFAULT NULL,
  `ep_informaciongeneralnacionalidad` varchar(25) DEFAULT NULL,
  `ep_informaciongeneraldireccion` varchar(100) DEFAULT NULL,
  `ep_informaciongeneralestatura` int(4) DEFAULT NULL,
  `ep_informaciongeneralpeso` int(3) DEFAULT NULL,
  `ep_informaciongeneralreligion` varchar(20) DEFAULT NULL,
  `ep_informaciongeneralcorreo` varchar(50) DEFAULT NULL,
  `codgenpuesto` int(11) DEFAULT NULL,
  `ep_informaciongeneralfechaboda` date DEFAULT NULL,
  `ep_informaciongeneralcif` int(11) DEFAULT NULL,
  PRIMARY KEY (`codepinformaciongeneralcif`),
  KEY `fk_ep_informaciongeneral_gen_tipoidentificacion1_idx` (`codgentipoidentificacion`),
  KEY `fk_ep_informaciongeneral_ep_tipoestado1_idx` (`codeptipoestado`),
  KEY `fk_ep_informaciongeneral_gen_sucursal1_idx` (`codgensucursal`),
  KEY `fk_ep_informaciongeneral_gen_departamento1_idx` (`codgendepartamento`),
  KEY `fk_ep_informaciongeneral_ep_estadocivil1_idx` (`codepestadocivil`),
  KEY `fk_ep_informaciongeneral_ep_municipio1_idx` (`codgenmunicipio`),
  KEY `fk_ep_informaciongeneral_ep_area1_idx` (`codgenarea`),
  KEY `fk_ep_informaciongeneral_ep_zona1_idx` (`codgenzona`),
  KEY `fk_ep_informaciongeneral_ep_tipoid_idx` (`codgentipoidentificacion`),
  CONSTRAINT `fk_ep_informaciongeneral_ep_estadocivil1` FOREIGN KEY (`codepestadocivil`) REFERENCES `ep_estadocivil` (`codepestadocivil`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_informaciongeneral_ep_tipoestado1` FOREIGN KEY (`codeptipoestado`) REFERENCES `ep_tipoestado` (`codeptipoestado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_informaciongeneral_gen_area1` FOREIGN KEY (`codgenarea`) REFERENCES `gen_area` (`codgenarea`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_informaciongeneral_gen_departamento1` FOREIGN KEY (`codgendepartamento`) REFERENCES `gen_departamento` (`codgendepartamento`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_informaciongeneral_gen_municipio1` FOREIGN KEY (`codgenmunicipio`) REFERENCES `gen_municipio` (`codgenmunicipio`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_informaciongeneral_gen_sucursal1` FOREIGN KEY (`codgensucursal`) REFERENCES `gen_sucursal` (`codgensucursal`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_informaciongeneral_gen_tipoidentificacion1` FOREIGN KEY (`codgentipoidentificacion`) REFERENCES `gen_tipoidentificacion` (`codgentipoidentificacion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_informaciongeneral_gen_zona1` FOREIGN KEY (`codgenzona`) REFERENCES `gen_zona` (`codgenzona`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_informaciongeneral`
--

LOCK TABLES `ep_informaciongeneral` WRITE;
/*!40000 ALTER TABLE `ep_informaciongeneral` DISABLE KEYS */;
INSERT INTO `ep_informaciongeneral` VALUES (1,1,2,1,1,102,1,1,2,'Jose','Alejandro','Teo','Gonzalez','','1999-01-27','10104',2147483647,'Guatemala','Zona 7 Guatemala',12,25,'Catolico','jose.ale@guadalapuna.com.gt',1,'2020-04-24',123),(2,1,2,1,1,102,1,1,2,'','Alejandro','','','','2018-07-22','',0,'','',0,0,'','',1,'0000-00-00',1000),(3,2,2,1,1,102,2,2,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',455),(4,1,1,1,1,102,1,1,2,'Jose','Alejandro','Gonzalez','Teo','','2018-07-22','239955',2555,'Guatemalteca','Zona 7 bethania ',22,22,'2','22',NULL,'0000-00-00',13222),(5,1,1,1,1,102,1,1,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',12225),(6,1,1,1,1,102,1,2,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',1555),(7,1,1,1,1,102,1,2,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',1444),(8,1,1,1,1,102,1,2,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',55555),(9,1,1,1,1,102,1,1,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',5151),(10,1,3,1,1,102,2,2,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',333),(11,1,2,1,1,102,1,1,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',555),(12,1,3,1,2,102,1,1,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',333),(13,1,4,1,1,102,1,1,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',22),(14,1,2,1,2,102,1,1,1,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'0000-00-00',666),(15,1,3,1,2,102,2,1,2,'Esgar','Ruben','Cassola','Casasola2','Gustavo','2018-07-22','22525545',0,'Guatemalteca','zona 7',12,12,'12','12',NULL,'0000-00-00',55555),(16,1,1,1,1,102,1,1,2,'','','','','','0000-00-00','',0,'','',0,0,'','',NULL,'0000-00-00',1),(17,1,1,1,1,102,1,1,2,'Ruben','Edgar','Chuy','Ruiz','','2014-02-05','239955',85995959,'Guatemalteca','',22,22,'22','22',NULL,'2020-04-24',1234568),(18,1,1,1,1,102,1,1,2,'','','','','','0000-00-00','',0,'','',0,0,'','',NULL,'0000-00-00',1),(19,1,1,1,1,102,1,1,2,'','','Gonzalez','Teo','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',1),(20,1,1,1,1,102,1,1,2,'','','','','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',0),(21,1,1,1,1,102,1,1,2,'Diego','asdsadsad','Gomez','Giron','','2018-07-22','123456',45646556,'Guatemalñteco','zona 1',10,0,'','',NULL,'0001-01-01',2425232),(22,1,1,1,1,102,1,1,2,'','','','','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',0),(23,1,1,1,1,102,1,1,2,'','','','','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',0),(24,1,1,1,1,102,1,1,2,'','','','','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',0),(25,1,1,1,1,102,1,1,2,'','','','','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',0),(26,1,1,1,1,102,1,1,2,'','','','','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',0),(27,1,1,1,1,102,1,1,2,'','','','','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',0),(28,1,1,1,1,102,1,1,2,'','','','','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',0),(29,1,1,1,1,102,1,1,2,'','','','','','0001-01-01','',0,'','',0,0,'','',NULL,'0001-01-01',0),(30,1,1,1,1,102,1,1,2,'','','','','','2018-07-22','',0,'','',0,0,'','',NULL,'2020-04-24',0),(31,6,1,1,1,716,17,32,2,'Diego','Jose','Gomez','Giron','','2018-07-22','21867957',123456,'Guatemalteco','Guatemala',21,21,'Catolico','dj_2425_gomez@hotmail.com',278,'2020-04-24',1234),(32,4,2,1,1,101,18,30,2,'Marlon','René','Reyes','Cruz','','1993-09-12','8008490-7',2147483647,'GUATEMALTECO','18 avenida 1-83 Colonia Renacimiento',2,220,'Cristiano ','marlon.rr.cruz@gmail.com',273,'2016-05-14',944070),(33,1,1,1,1,101,1,1,1,'1','1','1','1','1','0000-00-00','1',1,'1','1',1,1,'1','1',1,'2013-12-20',860949),(34,1,1,1,1,101,1,1,1,'1','1','1','1','1','0000-00-00','1',1,'1','1',1,1,'1','1',1,'0000-00-00',874971),(35,3,1,1,1,117,7,29,2,'Kévin','Vixhaín','Rivera','González','','1993-01-13','7626371-1',2147483647,'Guatemalteco','25 av. 23-67 Sector 1, Villa Hermosa 2, San Miguel Petapa',2,215,'Católico','kvriverag@gmail.com',266,'2020-04-24',927573),(36,1,1,1,1,102,1,1,2,'','','','','','2018-07-22','',0,'','',0,0,'','',0,'2020-04-24',0),(37,1,1,1,1,102,1,1,2,'','','','','','2018-07-22','',0,'','',0,0,'','',0,'2020-04-24',0),(38,1,2,1,1,101,16,33,2,'Hugo','René','Arriola','Vega','','1976-04-08','954055-5',2147483647,'guatemalteco','24 calle \"C\" 18-74, Residenciales San Carlos, Bulevar Hospital Militar',2,170,'Católico','lharriola@gmail.com',289,'1996-06-15',932030),(39,1,1,1,1,102,1,1,2,'','','','','','2018-07-22','',0,'','',0,0,'','',0,'2020-04-24',10902331),(40,1,1,1,1,102,1,1,2,'','','','','','2018-07-22','',0,'','',0,0,'','',0,'2020-04-24',0),(41,1,1,1,1,102,1,1,2,'','','','','','2018-07-22','',0,'','',0,0,'','',0,'2020-04-24',0),(42,1,1,1,1,102,1,1,2,'','','','','','2018-07-22','',0,'','',0,0,'','',0,'2020-04-24',0),(43,1,1,1,1,102,1,1,2,'','','','','','2018-07-22','',0,'','',0,0,'','',0,'2020-04-24',0);
/*!40000 ALTER TABLE `ep_informaciongeneral` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_ingreso`
--

DROP TABLE IF EXISTS `ep_ingreso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_ingreso` (
  `codepingreso` int(11) NOT NULL,
  `codepcontrolingreso` int(11) DEFAULT NULL,
  `ep_ingresosueldo` double DEFAULT NULL,
  `ep_ingresobonificacion` double DEFAULT NULL,
  `ep_ingresocomisiones` double DEFAULT NULL,
  PRIMARY KEY (`codepingreso`),
  KEY `fk_ep_ingreso_ep_controlingreso1_idx` (`codepcontrolingreso`),
  CONSTRAINT `fk_ep_ingreso_ep_controlingreso1` FOREIGN KEY (`codepcontrolingreso`) REFERENCES `ep_controlingreso` (`codepcontrolingreso`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_ingreso`
--

LOCK TABLES `ep_ingreso` WRITE;
/*!40000 ALTER TABLE `ep_ingreso` DISABLE KEYS */;
INSERT INTO `ep_ingreso` VALUES (1,1,5000,300,100),(2,2,50000,250,5220),(3,3,0,0,0),(4,4,0,0,0),(5,5,0,0,0),(6,6,0,0,0),(7,7,0,0,0),(8,8,0,0,0),(9,9,0,0,0),(10,10,0,0,0),(11,11,0,0,0),(12,12,0,0,0),(13,13,546,45564,6546),(14,14,0,0,0),(15,15,0,0,0),(16,16,4000,250,0),(17,17,4000,0,0),(18,18,4650,400,0),(19,19,4000,400,4000),(20,20,0,0,0),(21,21,0,0,0),(22,22,0,0,0),(23,23,0,0,0),(24,24,0,0,0),(25,25,0,0,0);
/*!40000 ALTER TABLE `ep_ingreso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_inmueble`
--

DROP TABLE IF EXISTS `ep_inmueble`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_inmueble` (
  `codepinmueble` int(11) NOT NULL,
  `codeptipoinmueble` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_inmueblefolio` varchar(50) DEFAULT NULL,
  `ep_inmueblelibro` varchar(50) DEFAULT NULL,
  `ep_inmuebledireccion` varchar(50) DEFAULT NULL,
  `ep_inmueblevalor` double DEFAULT NULL,
  `ep_inmuebledescripcion` varchar(200) DEFAULT NULL,
  `ep_inmueblecomentario` varchar(100) DEFAULT NULL,
  `ep_inmueblefinca` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`codepinmueble`),
  KEY `fk_ep_inmueble_ep_tipoinmueble1_idx` (`codeptipoinmueble`),
  KEY `fk_ep_inmueble_ep_informaciongeneralcif_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_inmueble_ep_informaciongeneralcif1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_inmueble_ep_tipoinmueble1` FOREIGN KEY (`codeptipoinmueble`) REFERENCES `ep_tipoinmueble` (`codeptipoinmueble`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_inmueble`
--

LOCK TABLES `ep_inmueble` WRITE;
/*!40000 ALTER TABLE `ep_inmueble` DISABLE KEYS */;
INSERT INTO `ep_inmueble` VALUES (1,1,1,'12','1','Guatemala Zona 7',2500,'ES MUY CARO','','Finquero'),(2,2,1,'1','1','Guatemala Zona 3',1500,'Completo',NULL,NULL),(3,1,16,'12','1','Guatemala Zona 7',2500,'ES MUY CARO',NULL,NULL),(4,2,16,'1','1','Guatemala Zona 3',1500,'Completo',NULL,NULL),(5,1,1,'25','15','Zona 4 la estación central del momo',20000,'Es un lugar que contiene bosque',NULL,NULL),(6,2,1,'3','3','3',3,'3',NULL,NULL),(7,1,30,'adsa','asd','asda',5465,'asda',NULL,NULL),(8,1,21,'Prueba','Prueba','Ciudad',500,'Prueba',NULL,NULL),(10,2,38,'124','1935','24 calle \"C\" 18-74 Zona 16, Res. San Carlos',850000,'Residencia','','7124'),(11,2,31,'1','1','Carretera Al Altlantico Km 8.5 Zona 17',1,'1','','asd');
/*!40000 ALTER TABLE `ep_inmueble` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_institucion`
--

DROP TABLE IF EXISTS `ep_institucion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_institucion` (
  `codepinstitucion` int(11) NOT NULL,
  `codeptipoinstitucion` int(11) DEFAULT NULL,
  `ep_institucionnombre` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`codepinstitucion`),
  KEY `fk_ep_institucion_ep_tipoinstitucion_idx` (`codeptipoinstitucion`),
  CONSTRAINT `fk_ep_institucion_ep_tipoinstitucion1` FOREIGN KEY (`codeptipoinstitucion`) REFERENCES `ep_tipoinstitucion` (`codeptipoinstitucion`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_institucion`
--

LOCK TABLES `ep_institucion` WRITE;
/*!40000 ALTER TABLE `ep_institucion` DISABLE KEYS */;
INSERT INTO `ep_institucion` VALUES (1,1,'El Crédito Hipotecario Nacional de Guatemala'),(2,1,'Banco Inmobiliario, S. A.'),(3,1,'Banco de los Trabajadores'),(4,1,'Banco Industrial, S. A.'),(5,1,'Banco de Desarrollo Rural, S. A.'),(6,1,'Banco Internacional, S. A.'),(7,1,'Citibank, N.A., Sucursal Guatemala'),(8,1,'Vivibanco, S. A.'),(9,1,'Banco Ficohsa Guatemala, S. A'),(10,1,'Banco Promerica, S. A.'),(11,1,'Banco de Antigua, S. A.'),(12,1,'Banco de América Central, S. A.'),(13,1,'Banco Agromercantil de Guatemala, S. A.'),(14,1,'Banco G&T Continental, S. A.'),(15,1,'Banco Azteca de Guatemala, S. A.'),(16,1,'Banco INV, S. A.'),(17,1,'Banco Credicorp, S. A. (1)'),(18,2,'Corporación Financiera Nacional '),(19,2,'Financiera Industrial, S. A.'),(20,2,'Financiera Rural, S. A. '),(21,2,'Financiera de Capitales, S. A. '),(22,2,'Financiera Summa, S. A.'),(23,2,'Financiera Progreso, S. A.'),(24,2,'Financiera Agromercantil, S. A.'),(25,2,'Financiera MVA, S. A. '),(26,2,'Financiera Consolidada, S. A.'),(27,2,'Financiera de los Trabajadores, S. A.'),(28,2,'Financiera G & T Continental, S. A.'),(29,3,'FENACOAC'),(30,3,'COOP. GUAYACAN'),(31,3,'COOSADECO'),(32,3,'COOSAJO'),(33,3,'COOP. UNION POPULAR'),(34,3,'COOP. UPA'),(35,3,'COOP. GUALAN'),(36,3,'COOP. COBAN'),(37,3,'COOP. TECULUTAN'),(38,3,'PARROQUIAL GUADALUPANA'),(39,3,'COOP. TONANTEL'),(40,3,'COOP. HORIZONTES'),(41,3,'COOP. COMALAPA'),(42,3,'COOP. BIENESTAR'),(43,3,'COOP. MOYUTAN'),(44,3,'COOP. CHIQUIMULA'),(45,3,'COSAMI'),(46,3,'COOP. SALCAJA'),(47,3,'ACREDICOM'),(48,3,'COLUA'),(49,3,'COOSANJER'),(50,3,'COOPSAMA'),(51,3,'COOP. SOLOMA'),(52,3,'COOP. ENCARNACION'),(53,3,'ECOSABA'),(54,3,'COOP. YAMAN KUTZ'),(55,3,'COTONEB'),(56,4,'Microfinanciera');
/*!40000 ALTER TABLE `ep_institucion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_inventario`
--

DROP TABLE IF EXISTS `ep_inventario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_inventario` (
  `codepinventario` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_inventarionombre` varchar(50) DEFAULT NULL,
  `ep_inventariodescripcion` varchar(200) DEFAULT NULL,
  `ep_inventariomonto` double DEFAULT NULL,
  PRIMARY KEY (`codepinventario`),
  KEY `fk_ep_inventario_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_inventario_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_inventario`
--

LOCK TABLES `ep_inventario` WRITE;
/*!40000 ALTER TABLE `ep_inventario` DISABLE KEYS */;
INSERT INTO `ep_inventario` VALUES (1,1,'Mercaderia de computadoras','MERCADERIA DE TELA',5000),(2,17,'50 Kilos de tela','',25000),(3,21,'','',0),(4,22,'','',0),(5,23,'','',0),(6,24,'','',0),(7,25,'','',0),(8,26,'','',0),(9,27,'','',0),(10,28,'','',0),(11,29,'','',0),(12,30,'','',0),(13,31,'Prueba','',500),(14,32,'Herramientas varias','',5000),(15,35,'','',0),(16,36,'','',0),(17,37,'','',0),(18,38,'','',0),(19,39,'','',0),(20,40,'','',0),(21,41,'','',0),(22,42,'','',0),(23,43,'','',0);
/*!40000 ALTER TABLE `ep_inventario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_inversiones`
--

DROP TABLE IF EXISTS `ep_inversiones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_inversiones` (
  `codepinversiones` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `codeptipoinstitucion` int(11) DEFAULT NULL,
  `codepinstitucion` int(11) DEFAULT NULL,
  `codeptipomoneda` int(11) DEFAULT NULL,
  `ep_inversionesnombre` varchar(100) DEFAULT NULL,
  `ep_inversionesplazo` varchar(100) DEFAULT NULL,
  `ep_inversionesmonto` double DEFAULT NULL,
  `ep_inversionesorigen` varchar(200) DEFAULT NULL,
  `ep_inversionesnumerocuenta` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codepinversiones`),
  KEY `fk_ep_inversiones_ep_tipomoneda1_idx` (`codeptipomoneda`),
  KEY `fk_ep_inversiones_ep_tipoinstitucion1_idx` (`codeptipoinstitucion`),
  KEY `fk_ep_inversiones_ep_institucion1_idx` (`codepinstitucion`),
  KEY `fk_ep_inversiones_ep_informaciongeneral1` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_inversiones_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_inversiones_ep_institucion1` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_inversiones_ep_tipoinstitucion1` FOREIGN KEY (`codeptipoinstitucion`) REFERENCES `ep_tipoinstitucion` (`codeptipoinstitucion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_inversiones_ep_tipomoneda1` FOREIGN KEY (`codeptipomoneda`) REFERENCES `ep_tipomoneda` (`codeptipomoneda`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_inversiones`
--

LOCK TABLES `ep_inversiones` WRITE;
/*!40000 ALTER TABLE `ep_inversiones` DISABLE KEYS */;
INSERT INTO `ep_inversiones` VALUES (1,1,1,1,1,'Inversion mi ahorrito','5',2500,'Sueldo promediado',NULL),(2,31,1,3,1,'sinnombre','5',500,'100',NULL),(3,32,3,38,1,'sinnombre','',40000,'Liquidacion de pasivo laboral',NULL);
/*!40000 ALTER TABLE `ep_inversiones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_maquinaria`
--

DROP TABLE IF EXISTS `ep_maquinaria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_maquinaria` (
  `codepmaquinaria` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_maquinarianombre` varchar(45) DEFAULT NULL,
  `ep_maquinariadescripcion` varchar(100) DEFAULT NULL,
  `ep_maquinariamonto` double DEFAULT NULL,
  PRIMARY KEY (`codepmaquinaria`),
  KEY `fk_ep_prestamo_ep_informaciongeneralcif_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_prestamo_ep_informaciongeneralcif1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_maquinaria`
--

LOCK TABLES `ep_maquinaria` WRITE;
/*!40000 ALTER TABLE `ep_maquinaria` DISABLE KEYS */;
INSERT INTO `ep_maquinaria` VALUES (1,1,'Excavadora','Maquina de construccion',500000),(2,17,'Excavadora2','Maquina de construccion',50000),(3,21,'','',0),(4,22,'','',0),(5,23,'','',0),(6,24,'','',0),(7,25,'','',0),(8,26,'','',0),(9,27,'','',0),(10,28,'','',0),(11,29,'','',0),(12,30,'','',0),(13,31,'sadsa','adsasdas',4556),(14,32,'Maquinas de coser','Poseo 2 maquinas de coser',4000),(15,35,'','',0),(16,36,'','',0),(17,37,'','',0),(18,38,'','',0),(19,39,'','',0),(20,40,'','',0),(21,41,'','',0),(22,42,'','',0),(23,43,'','',0);
/*!40000 ALTER TABLE `ep_maquinaria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_menajecasadetalle`
--

DROP TABLE IF EXISTS `ep_menajecasadetalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_menajecasadetalle` (
  `codepmenajecasadetalle` int(11) NOT NULL,
  `codmenajedecasaencabezado` int(11) DEFAULT NULL,
  `codeptipobien` int(11) DEFAULT NULL,
  `ep_menajecasadetallecantidad` int(20) DEFAULT NULL,
  `ep_menajecasadetallevalor` double DEFAULT NULL,
  PRIMARY KEY (`codepmenajecasadetalle`),
  KEY `fk_ep_menajecasadetalle_ep_menajedecasaencabezado1_idx` (`codmenajedecasaencabezado`),
  KEY `fk_ep_menajecasadetalle_ep_tipobien1_idx` (`codeptipobien`),
  CONSTRAINT `fk_ep_menajecasadetalle_ep_menajedecasaencabezado1` FOREIGN KEY (`codmenajedecasaencabezado`) REFERENCES `ep_menajedecasaencabezado` (`codepmenajedecasaencabezado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_menajecasadetalle_ep_tipobien1` FOREIGN KEY (`codeptipobien`) REFERENCES `ep_tipobien` (`codeptipobien`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_menajecasadetalle`
--

LOCK TABLES `ep_menajecasadetalle` WRITE;
/*!40000 ALTER TABLE `ep_menajecasadetalle` DISABLE KEYS */;
INSERT INTO `ep_menajecasadetalle` VALUES (1,1,9,1,50),(2,2,9,0,0),(3,2,9,0,0),(4,2,9,0,0),(5,2,9,0,0),(6,2,9,0,0),(7,2,9,0,0),(8,2,9,0,0),(9,2,9,0,0),(10,2,9,0,0),(11,2,9,0,0),(12,3,1,0,100),(13,3,2,0,500),(14,3,3,0,100),(15,3,4,2,2500),(16,3,5,1,1500),(17,3,6,2,500),(18,3,7,1,500),(19,3,8,1,5000),(20,3,9,1,3500),(21,3,10,5,4500),(22,3,11,0,0),(23,4,1,0,0),(24,4,2,0,0),(25,4,3,0,0),(26,4,4,0,0),(27,4,5,0,0),(28,4,6,0,0),(29,4,7,0,0),(30,4,8,0,0),(31,4,9,0,0),(32,4,10,0,0),(33,4,11,0,0),(34,5,1,0,0),(35,5,2,0,0),(36,5,3,0,0),(37,5,4,0,0),(38,5,5,0,0),(39,5,6,0,0),(40,5,7,0,0),(41,5,8,0,0),(42,5,9,0,0),(43,5,10,0,0),(44,5,11,0,0),(45,6,1,0,0),(46,6,2,0,0),(47,6,3,0,0),(48,6,4,0,0),(49,6,5,0,0),(50,6,6,0,0),(51,6,7,0,0),(52,6,8,0,0),(53,6,9,0,0),(54,6,10,0,0),(55,6,11,0,0),(56,7,1,0,0),(57,7,2,0,0),(58,7,3,0,0),(59,7,4,0,0),(60,7,5,0,0),(61,7,6,0,0),(62,7,7,0,0),(63,7,8,0,0),(64,7,9,0,0),(65,7,10,0,0),(66,7,11,0,0),(67,8,1,0,0),(68,8,2,0,0),(69,8,3,0,0),(70,8,4,0,0),(71,8,5,0,0),(72,8,6,0,0),(73,8,7,0,0),(74,8,8,0,0),(75,8,9,0,0),(76,8,10,0,0),(77,8,11,0,0),(78,9,1,0,0),(79,9,2,0,0),(80,9,3,0,0),(81,9,4,0,0),(82,9,5,0,0),(83,9,6,0,0),(84,9,7,0,0),(85,9,8,0,0),(86,9,9,0,0),(87,9,10,0,0),(88,9,11,0,0),(89,10,1,0,0),(90,10,2,0,0),(91,10,3,0,0),(92,10,4,0,0),(93,10,5,0,0),(94,10,6,0,0),(95,10,7,0,0),(96,10,8,0,0),(97,10,9,0,0),(98,10,10,0,0),(99,10,11,0,0),(100,11,1,0,0),(101,11,2,0,0),(102,11,3,0,0),(103,11,4,0,0),(104,11,5,0,0),(105,11,6,0,0),(106,11,7,0,0),(107,11,8,0,0),(108,11,9,0,0),(109,11,10,0,0),(110,11,11,0,0),(111,12,1,0,0),(112,12,2,0,0),(113,12,3,0,0),(114,12,4,0,0),(115,12,5,0,0),(116,12,6,0,0),(117,12,7,0,0),(118,12,8,0,0),(119,12,9,0,0),(120,12,10,0,0),(121,12,11,0,0),(122,13,1,0,499),(123,13,2,0,500),(124,13,3,0,501),(125,13,4,5,51213),(126,13,5,2,555),(127,13,6,1,12),(128,13,7,1,561),(129,13,8,2,45),(130,13,9,1,5465),(131,13,10,1,5465),(132,13,11,0,4654),(133,14,1,0,2000),(134,14,2,0,1500),(135,14,3,0,800),(136,14,4,1,3500),(137,14,5,1,2000),(138,14,6,0,0),(139,14,7,0,0),(140,14,8,1,1500),(141,14,9,1,2500),(142,14,10,1,2000),(143,14,11,1,5000),(144,15,1,0,3500),(145,15,2,0,1000),(146,15,3,0,800),(147,15,4,4,1800),(148,15,5,2,1400),(149,15,6,1,1200),(150,15,7,0,0),(151,15,8,1,1000),(152,15,9,1,1500),(153,15,10,1,1000),(154,15,11,0,0),(155,16,1,0,0),(156,16,2,0,0),(157,16,3,0,0),(158,16,4,0,0),(159,16,5,0,0),(160,16,6,0,0),(161,16,7,0,0),(162,16,8,0,0),(163,16,9,0,0),(164,16,10,0,0),(165,16,11,0,0),(166,17,1,0,0),(167,17,2,0,0),(168,17,3,0,0),(169,17,4,0,0),(170,17,5,0,0),(171,17,6,0,0),(172,17,7,0,0),(173,17,8,0,0),(174,17,9,0,0),(175,17,10,0,0),(176,17,11,0,0),(177,18,1,0,20000),(178,18,2,0,6000),(179,18,3,0,1500),(180,18,4,5,8000),(181,18,5,0,0),(182,18,6,1,1000),(183,18,7,0,0),(184,18,8,1,1000),(185,18,9,1,2000),(186,18,10,1,1500),(187,18,11,0,0),(188,19,1,0,0),(189,19,2,0,0),(190,19,3,0,0),(191,19,4,0,0),(192,19,5,0,0),(193,19,6,0,0),(194,19,7,0,0),(195,19,8,0,0),(196,19,9,0,0),(197,19,10,0,0),(198,19,11,0,0),(199,20,1,0,0),(200,20,2,0,0),(201,20,3,0,0),(202,20,4,0,0),(203,20,5,0,0),(204,20,6,0,0),(205,20,7,0,0),(206,20,8,0,0),(207,20,9,0,0),(208,20,10,0,0),(209,20,11,0,0),(210,21,1,0,0),(211,21,2,0,0),(212,21,3,0,0),(213,21,4,0,0),(214,21,5,0,0),(215,21,6,0,0),(216,21,7,0,0),(217,21,8,0,0),(218,21,9,0,0),(219,21,10,0,0),(220,21,11,0,0),(221,22,1,0,0),(222,22,2,0,0),(223,22,3,0,0),(224,22,4,0,0),(225,22,5,0,0),(226,22,6,0,0),(227,22,7,0,0),(228,22,8,0,0),(229,22,9,0,0),(230,22,10,0,0),(231,22,11,0,0),(232,23,1,0,0),(233,23,2,0,0),(234,23,3,0,0),(235,23,4,0,0),(236,23,5,0,0),(237,23,6,0,0),(238,23,7,0,0),(239,23,8,0,0),(240,23,9,0,0),(241,23,10,0,0),(242,23,11,0,0);
/*!40000 ALTER TABLE `ep_menajecasadetalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_menajedecasaencabezado`
--

DROP TABLE IF EXISTS `ep_menajedecasaencabezado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_menajedecasaencabezado` (
  `codepmenajedecasaencabezado` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_menajedecabezatotal` double DEFAULT NULL,
  PRIMARY KEY (`codepmenajedecasaencabezado`),
  KEY `fk_ep_menajedecasaencabezado_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_menajedecasaencabezado_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_menajedecasaencabezado`
--

LOCK TABLES `ep_menajedecasaencabezado` WRITE;
/*!40000 ALTER TABLE `ep_menajedecasaencabezado` DISABLE KEYS */;
INSERT INTO `ep_menajedecasaencabezado` VALUES (1,1,2500),(2,17,0),(3,21,0),(4,22,0),(5,23,0),(6,24,0),(7,25,0),(8,26,0),(9,27,0),(10,28,0),(11,29,0),(12,30,0),(13,31,0),(14,32,0),(15,35,0),(16,36,0),(17,37,0),(18,38,0),(19,39,0),(20,40,0),(21,41,0),(22,42,0),(23,43,0);
/*!40000 ALTER TABLE `ep_menajedecasaencabezado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_negocio`
--

DROP TABLE IF EXISTS `ep_negocio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_negocio` (
  `codepnegocio` int(11) NOT NULL,
  `codepcontrolingreso` int(11) DEFAULT NULL,
  `ep_negocionombre` varchar(50) DEFAULT NULL,
  `ep_negociopatente` varchar(20) DEFAULT NULL,
  `ep_negocioempleados` int(4) DEFAULT NULL,
  `ep_negociodireccion` varchar(50) DEFAULT NULL,
  `ep_negocioingresos` double DEFAULT NULL,
  `ep_negocioegresos` double DEFAULT NULL,
  `ep_negociotipo` varchar(50) DEFAULT NULL,
  `ep_negocioobjeto` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`codepnegocio`),
  KEY `fk_ep_negocio_ep_controlingreso1_idx` (`codepcontrolingreso`),
  CONSTRAINT `fk_ep_negocio_ep_controlingreso1` FOREIGN KEY (`codepcontrolingreso`) REFERENCES `ep_controlingreso` (`codepcontrolingreso`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_negocio`
--

LOCK TABLES `ep_negocio` WRITE;
/*!40000 ALTER TABLE `ep_negocio` DISABLE KEYS */;
INSERT INTO `ep_negocio` VALUES (1,1,'33','33',33,'33 av zona 7',33,33,'2500','33'),(2,2,'','',0,'',0,0,'',''),(3,3,'','',0,'',0,0,'',''),(4,4,'','',0,'',0,0,'',''),(5,5,'','',0,'',0,0,'',''),(6,6,'','',0,'',0,0,'',''),(7,7,'','',0,'',0,0,'',''),(8,8,'','',0,'',0,0,'',''),(9,9,'','',0,'',0,0,'',''),(10,10,'','',0,'',0,0,'',''),(11,11,'','',0,'',0,0,'',''),(12,12,'','',0,'',0,0,'',''),(13,13,'','0',0,'',0,0,'','0'),(14,14,'','',0,'',0,0,'',''),(15,15,'','',0,'',0,0,'',''),(16,16,'','0',0,'',1000,18,'LOS PATITOS','2500'),(17,17,'','',0,'',0,0,'',''),(18,18,'','',0,'',0,0,'',''),(19,19,'','',0,'',500,0,'Henry Castillo Foto','1000'),(20,20,'','',0,'',0,0,'',''),(21,21,'','',0,'',0,0,'',''),(22,22,'','',0,'',0,0,'',''),(23,23,'','',0,'',0,0,'',''),(24,24,'','',0,'',0,0,'',''),(25,25,'','',0,'',0,0,'','');
/*!40000 ALTER TABLE `ep_negocio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_pasivocontigente`
--

DROP TABLE IF EXISTS `ep_pasivocontigente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_pasivocontigente` (
  `codeppasivocontigente` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_pasivocontigenombre` varchar(100) DEFAULT NULL,
  `ep_pasivocontigentedeudor` varchar(100) DEFAULT NULL,
  `ep_pasivocontigentefechadesembolso` date DEFAULT NULL,
  `ep_pasivocontigentefechafinalizacion` date DEFAULT NULL,
  `ep_pasivocontigentesaldo` double DEFAULT NULL,
  `ep_pasivocontigentecondeudor` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`codeppasivocontigente`),
  KEY `fk_ep_pasivocontigente_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_pasivocontigente_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_pasivocontigente`
--

LOCK TABLES `ep_pasivocontigente` WRITE;
/*!40000 ALTER TABLE `ep_pasivocontigente` DISABLE KEYS */;
INSERT INTO `ep_pasivocontigente` VALUES (1,1,'Organismo Judicial','Pablo picasso','2020-04-26','2021-05-26',25500,'LE DEVO POR UN PAPELEO'),(2,17,'Casa de edgar','Edgar','2020-04-01','2020-04-30',25000,'Familiar'),(3,21,'','','2020-04-24','0001-01-01',0,''),(4,22,'','','0000-00-00','0000-00-00',0,''),(5,23,'','','0000-00-00','0000-00-00',0,''),(6,24,'','','0000-00-00','0000-00-00',0,''),(7,25,'','','0000-00-00','0000-00-00',0,''),(8,26,'','','0000-00-00','0000-00-00',0,''),(9,27,'','','0000-00-00','0000-00-00',0,''),(10,28,'','','0000-00-00','0000-00-00',0,''),(11,29,'','','0000-00-00','0000-00-00',0,''),(12,30,'','','0000-00-00','0000-00-00',0,''),(13,31,'Prueba','Prueba','2020-04-24','0001-01-01',131432,'asdsa'),(14,32,'','','2020-04-24','0001-01-01',0,''),(15,35,'','','0000-00-00','0000-00-00',0,''),(16,36,'','','0000-00-00','0000-00-00',0,''),(17,37,'','','0000-00-00','0000-00-00',0,''),(18,38,'','','0000-00-00','0000-00-00',0,''),(19,39,'','','0000-00-00','0000-00-00',0,''),(20,40,'','','0000-00-00','0000-00-00',0,''),(21,41,'','','0000-00-00','0000-00-00',0,''),(22,42,'','','0000-00-00','0000-00-00',0,''),(23,43,'','','0000-00-00','0000-00-00',0,'');
/*!40000 ALTER TABLE `ep_pasivocontigente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_personapep`
--

DROP TABLE IF EXISTS `ep_personapep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_personapep` (
  `codeppersonapep` int(11) NOT NULL,
  `codeptipopep` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `codeptiponacionalidad` int(11) DEFAULT NULL,
  `codeptipoparentesco` int(11) DEFAULT NULL,
  `ep_personapepnombre` varchar(100) DEFAULT NULL,
  `ep_personapepnombreinstitucion` varchar(100) DEFAULT NULL,
  `ep_personapeppuesto` varchar(100) DEFAULT NULL,
  `ep_personapeppais` varchar(100) DEFAULT NULL,
  `ep_personapepmotivo` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`codeppersonapep`),
  KEY `fk_ep_personapep_ep_tipopep1_idx` (`codeptipopep`),
  KEY `fk_ep_personapep_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  KEY `fk_ep_personapep_ep_tiponacionalidad1_idx` (`codeptiponacionalidad`),
  KEY `fk_ep_personapep_ep_tipoparentesco_idx` (`codeptipoparentesco`),
  CONSTRAINT `fk_ep_personapep_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_personapep_ep_tiponacionalidad1` FOREIGN KEY (`codeptiponacionalidad`) REFERENCES `ep_tiponacionalidad` (`codeptiponacionalidad`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_personapep_ep_tipoparentesco1` FOREIGN KEY (`codeptipoparentesco`) REFERENCES `ep_tipoparentesco` (`codeptipoparentesco`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_personapep_ep_tipopep1` FOREIGN KEY (`codeptipopep`) REFERENCES `ep_tipopep` (`codeptipopep`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_personapep`
--

LOCK TABLES `ep_personapep` WRITE;
/*!40000 ALTER TABLE `ep_personapep` DISABLE KEYS */;
INSERT INTO `ep_personapep` VALUES (1,1,1,NULL,NULL,NULL,'','','',NULL),(2,2,1,1,4,'Rosaura Perez','Relationshi','Desarollador','Guatemala',NULL),(3,3,1,2,2,'Luisa Fernandez','Makoto','Decorador','Guatemala','una deuda por choque'),(4,1,17,1,1,'','','','',''),(5,2,17,1,1,'','','','',''),(6,3,17,1,1,'','','','',''),(7,1,21,1,1,'','','','',''),(8,2,21,1,1,'','','','',''),(9,3,21,1,1,'','','','',''),(10,1,22,1,1,'','','','',''),(11,2,22,1,1,'','','','',''),(12,3,22,1,1,'','','','',''),(13,1,23,1,1,'','','','',''),(14,2,23,1,1,'','','','',''),(15,3,23,1,1,'','','','',''),(16,1,24,1,1,'','','','',''),(17,2,24,1,1,'','','','',''),(18,3,24,1,1,'','','','',''),(19,1,25,1,1,'','','','',''),(20,2,25,1,1,'','','','',''),(21,3,25,1,1,'','','','',''),(22,1,26,1,1,'','','','',''),(23,2,26,1,1,'','','','',''),(24,3,26,1,1,'','','','',''),(25,1,27,1,1,'','','','',''),(26,2,27,1,1,'','','','',''),(27,3,27,1,1,'','','','',''),(28,1,28,1,1,'','','','',''),(29,2,28,1,1,'','','','',''),(30,3,28,1,1,'','','','',''),(31,1,29,1,1,'','','','',''),(32,2,29,1,1,'','','','',''),(33,3,29,1,1,'','','','',''),(34,1,30,1,1,'','','','',''),(35,2,30,1,1,'','','','',''),(36,3,30,1,1,'','','','',''),(37,1,31,1,1,'','','','',''),(38,2,31,1,1,'','','','',''),(39,3,31,1,1,'','','','',''),(40,1,32,1,1,'','','','',''),(41,2,32,1,1,'','','','',''),(42,3,32,1,1,'','','','',''),(43,1,35,1,1,'','','','',''),(44,2,35,1,1,'','','','',''),(45,3,35,1,1,'','','','',''),(46,1,36,1,1,'','','','',''),(47,2,36,1,1,'','','','',''),(48,3,36,1,1,'','','','',''),(49,1,37,1,1,'','','','',''),(50,2,37,1,1,'','','','',''),(51,3,37,1,1,'','','','',''),(52,1,38,1,1,'','','','',''),(53,2,38,1,1,'','','','',''),(54,3,38,1,1,'','','','',''),(55,1,39,1,1,'','','','',''),(56,2,39,1,1,'','','','',''),(57,3,39,1,1,'','','','',''),(58,1,40,1,1,'','','','',''),(59,2,40,1,1,'','','','',''),(60,3,40,1,1,'','','','',''),(61,1,41,1,1,'','','','',''),(62,2,41,1,1,'','','','',''),(63,3,41,1,1,'','','','',''),(64,1,42,1,1,'','','','',''),(65,2,42,1,1,'','','','',''),(66,3,42,1,1,'','','','',''),(67,1,43,1,1,'','','','',''),(68,2,43,1,1,'','','','',''),(69,3,43,1,1,'','','','','');
/*!40000 ALTER TABLE `ep_personapep` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_prestamo`
--

DROP TABLE IF EXISTS `ep_prestamo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_prestamo` (
  `codepprestamo` int(11) NOT NULL,
  `codeptipoprestamo` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `codepinstitucion` int(11) DEFAULT NULL,
  `codeptipoinstitucion` int(11) DEFAULT NULL,
  `ep_prestamomomentoinicial` double DEFAULT NULL,
  `ep_prestamosaldoactual` double DEFAULT NULL,
  `ep_prestamofechadesembolso` date DEFAULT NULL,
  `ep_prestamofechadefinalizacion` date DEFAULT NULL,
  `ep_prestamodestino` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`codepprestamo`),
  KEY `fk_ep_prestamo_ep_tipoprestamo1_idx` (`codeptipoprestamo`),
  KEY `fk_ep_prestamo_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  KEY `fk_ep_prestamo_ep_institucion1_idx` (`codepinstitucion`),
  CONSTRAINT `fk_ep_prestamo_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_prestamo_ep_institucion1` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_prestamo_ep_tipoprestamo1` FOREIGN KEY (`codeptipoprestamo`) REFERENCES `ep_tipoprestamo` (`codeptipoprestamo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_prestamo`
--

LOCK TABLES `ep_prestamo` WRITE;
/*!40000 ALTER TABLE `ep_prestamo` DISABLE KEYS */;
INSERT INTO `ep_prestamo` VALUES (1,1,1,2,2,2500,7000,'2020-05-12','2020-01-12','Cuenta Monetaria'),(2,1,1,1,1,7500,5222,'2020-05-14','2020-01-01','Cuenta Familiar'),(3,1,16,2,2,2500,7000,'0000-00-00','0000-00-00','Cuenta Monetaria'),(4,1,16,1,1,7500,5222,'0000-00-00','0000-00-00','Cuenta Familiar'),(5,2,1,1,1,5000,2000,'2018-08-01','2018-08-11','Cuenta de destino'),(6,1,30,1,1,4654,654,'2018-07-22','2018-07-22','asdasd'),(7,1,21,2,2,5465,5456,'2018-07-22','2018-07-22','Prueba'),(9,1,32,3,38,25000,1083333,'2018-11-25','2021-11-25','Compra de vehículo'),(10,1,31,2,20,500,5456,'2021-03-02','2021-03-30','sadad'),(11,2,31,2,21,12321,2312,'2021-03-16','2021-03-19','asdasd'),(12,1,43,1,1,25002,33,'2018-07-22','2018-07-22','222'),(13,1,43,56,4,25002,33,'2018-07-22','2018-07-22','222');
/*!40000 ALTER TABLE `ep_prestamo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_remesas`
--

DROP TABLE IF EXISTS `ep_remesas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_remesas` (
  `codepremesas` int(11) NOT NULL,
  `codepcontrolingreso` int(11) DEFAULT NULL,
  `ep_remesasnombre` varchar(50) DEFAULT NULL,
  `ep_remesasrelacion` varchar(100) DEFAULT NULL,
  `ep_remesasmonto` double DEFAULT NULL,
  `ep_remesasperiodo` date DEFAULT NULL,
  PRIMARY KEY (`codepremesas`),
  KEY `fk_ep_remesas_ep_controlingreso1_idx` (`codepcontrolingreso`),
  CONSTRAINT `fk_ep_remesas_ep_controlingreso1` FOREIGN KEY (`codepcontrolingreso`) REFERENCES `ep_controlingreso` (`codepcontrolingreso`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_remesas`
--

LOCK TABLES `ep_remesas` WRITE;
/*!40000 ALTER TABLE `ep_remesas` DISABLE KEYS */;
INSERT INTO `ep_remesas` VALUES (1,1,'REMESA MI COSECHA','Madre',2500,'2021-10-10'),(2,2,'','',0,'0000-00-00'),(3,3,'','',0,'0000-00-00'),(4,4,'','',0,'0000-00-00'),(5,5,'','',0,'0000-00-00'),(6,6,'','',0,'0000-00-00'),(7,7,'','',0,'0000-00-00'),(8,8,'','',0,'0000-00-00'),(9,9,'','',0,'0000-00-00'),(10,10,'','',0,'0000-00-00'),(11,11,'','',0,'0000-00-00'),(12,12,'','',0,'0000-00-00'),(13,13,'','',0,'0000-00-00'),(14,14,'','',0,'0000-00-00'),(15,15,'','',0,'0000-00-00'),(16,16,'Oscar David Herera Hernandez','Padre',1000,'0000-00-00'),(17,17,'','',0,'0000-00-00'),(18,18,'','',0,'0000-00-00'),(19,19,'Estela Castillo','tia',100,'0000-00-00'),(20,20,'','',0,'0000-00-00'),(21,21,'','',0,'0000-00-00'),(22,22,'','',0,'0000-00-00'),(23,23,'','',0,'0000-00-00'),(24,24,'','',0,'0000-00-00'),(25,25,'','',0,'0000-00-00');
/*!40000 ALTER TABLE `ep_remesas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tarjetadecredito`
--

DROP TABLE IF EXISTS `ep_tarjetadecredito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tarjetadecredito` (
  `codeptrajetadecredito` int(11) NOT NULL,
  `codeptipoinstitucion` int(11) DEFAULT NULL,
  `codepinstitucion` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_tarjetadecreditomonedaqtz` double DEFAULT NULL,
  `ep_tarjetadecreditomonedausd` double DEFAULT NULL,
  `ep_tarjetadecreditosaldoactual` double DEFAULT NULL,
  PRIMARY KEY (`codeptrajetadecredito`),
  KEY `fk_ep_tarjetadecredito_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  KEY `fk_ep_tarjetadecredito_ep_tipoinstitucion1_idx` (`codeptipoinstitucion`),
  KEY `fk_ep_tarjetadecredito_ep_institucion1_idx` (`codepinstitucion`),
  CONSTRAINT `fk_ep_tarjetadecredito_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_tarjetadecredito_ep_institucion1` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_tarjetadecredito_ep_tipoinstitucion1` FOREIGN KEY (`codeptipoinstitucion`) REFERENCES `ep_tipoinstitucion` (`codeptipoinstitucion`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tarjetadecredito`
--

LOCK TABLES `ep_tarjetadecredito` WRITE;
/*!40000 ALTER TABLE `ep_tarjetadecredito` DISABLE KEYS */;
INSERT INTO `ep_tarjetadecredito` VALUES (1,1,1,1,8000,1000,500000),(2,2,2,1,7500,950,1000),(3,1,1,16,1,8000,1000),(4,2,2,16,1,7500,950),(5,1,1,1,2500,1000,250),(6,1,1,30,464,56465,65465),(7,1,1,21,56465,56465,5564),(8,1,1,31,5000,2000,3500),(9,3,38,32,3000,400,1500),(10,3,38,32,1500,200,1000);
/*!40000 ALTER TABLE `ep_tarjetadecredito` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_telefono`
--

DROP TABLE IF EXISTS `ep_telefono`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_telefono` (
  `codeptelefono` int(11) NOT NULL AUTO_INCREMENT,
  `codeptipotelefono` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_telefononumero` varchar(8) DEFAULT NULL,
  PRIMARY KEY (`codeptelefono`),
  KEY `fk_ep_telefonol_ep_tipotelefono1_idx` (`codeptipotelefono`),
  KEY `fk_ep_telefonol_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_telefono_ep_infromaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_telefono_ep_tipotelefono1` FOREIGN KEY (`codeptipotelefono`) REFERENCES `ep_tipotelefono` (`codeptipotelefono`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_telefono`
--

LOCK TABLES `ep_telefono` WRITE;
/*!40000 ALTER TABLE `ep_telefono` DISABLE KEYS */;
INSERT INTO `ep_telefono` VALUES (1,1,1,'31417025'),(2,1,1,'40113755'),(3,2,1,'24358844'),(5,1,16,'31417025'),(6,1,16,'40113755'),(7,2,16,'24358844'),(8,1,16,'31417025'),(9,1,19,'24352567'),(10,1,1,'564654'),(11,2,20,'12345678'),(12,1,22,'4564654'),(13,2,29,'54267957'),(14,1,30,'123456'),(15,2,21,'12345'),(16,2,21,'54267957'),(17,2,2,'54267957'),(19,1,31,'123456'),(20,2,32,'43798706'),(21,1,32,'22563205'),(22,2,35,'58439386'),(23,1,37,'24771255'),(24,2,37,'48446050'),(25,2,36,'45211761'),(26,1,38,'22196980'),(27,2,38,'42112196'),(28,2,4,'50600901'),(29,1,36,'44225566'),(30,1,36,'44225566'),(31,2,39,'30998428'),(32,2,39,'40009985'),(33,2,31,'5426757');
/*!40000 ALTER TABLE `ep_telefono` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipobien`
--

DROP TABLE IF EXISTS `ep_tipobien`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipobien` (
  `codeptipobien` int(11) NOT NULL,
  `ep_tipobiennombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codeptipobien`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipobien`
--

LOCK TABLES `ep_tipobien` WRITE;
/*!40000 ALTER TABLE `ep_tipobien` DISABLE KEYS */;
INSERT INTO `ep_tipobien` VALUES (1,'Equipo de computo'),(2,'Amueblado de sala'),(3,'Amueblado de comedor'),(4,'Televisor'),(5,'Equipo de sonido'),(6,'Lavadora'),(7,'Secadora'),(8,'Estufa'),(9,'Refrigeradora'),(10,'Telefono Movil'),(11,'Otros');
/*!40000 ALTER TABLE `ep_tipobien` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipocuenta`
--

DROP TABLE IF EXISTS `ep_tipocuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipocuenta` (
  `codeptipocuenta` int(11) NOT NULL,
  `ep_tipocuentanombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codeptipocuenta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipocuenta`
--

LOCK TABLES `ep_tipocuenta` WRITE;
/*!40000 ALTER TABLE `ep_tipocuenta` DISABLE KEYS */;
INSERT INTO `ep_tipocuenta` VALUES (1,'Cuentas monetarias'),(2,'Cuentas de ahorro'),(3,'Cuentas en cooperativas'),(4,'Cuentas por cobrar');
/*!40000 ALTER TABLE `ep_tipocuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipocuentacooperativa`
--

DROP TABLE IF EXISTS `ep_tipocuentacooperativa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipocuentacooperativa` (
  `codeptipocuentacooperativa` int(11) NOT NULL,
  `ep_tipocuentacooperativanombre` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`codeptipocuentacooperativa`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipocuentacooperativa`
--

LOCK TABLES `ep_tipocuentacooperativa` WRITE;
/*!40000 ALTER TABLE `ep_tipocuentacooperativa` DISABLE KEYS */;
INSERT INTO `ep_tipocuentacooperativa` VALUES (1,'Aportación'),(2,'Ahorro');
/*!40000 ALTER TABLE `ep_tipocuentacooperativa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipocuentaspopagar`
--

DROP TABLE IF EXISTS `ep_tipocuentaspopagar`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipocuentaspopagar` (
  `codeptipocuentaspopagar` int(11) NOT NULL,
  `ep_tipocuentaspopagarnombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codeptipocuentaspopagar`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipocuentaspopagar`
--

LOCK TABLES `ep_tipocuentaspopagar` WRITE;
/*!40000 ALTER TABLE `ep_tipocuentaspopagar` DISABLE KEYS */;
INSERT INTO `ep_tipocuentaspopagar` VALUES (1,'Largo Plazo'),(2,'Corto Plazo');
/*!40000 ALTER TABLE `ep_tipocuentaspopagar` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipoestado`
--

DROP TABLE IF EXISTS `ep_tipoestado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipoestado` (
  `codeptipoestado` int(11) NOT NULL,
  `ep_tipoestadonombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codeptipoestado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipoestado`
--

LOCK TABLES `ep_tipoestado` WRITE;
/*!40000 ALTER TABLE `ep_tipoestado` DISABLE KEYS */;
INSERT INTO `ep_tipoestado` VALUES (1,'NUEVO'),(2,'PROCESO'),(3,'MODIFICACION'),(4,'FINALIZADO');
/*!40000 ALTER TABLE `ep_tipoestado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipoestatuscuenta`
--

DROP TABLE IF EXISTS `ep_tipoestatuscuenta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipoestatuscuenta` (
  `codeptipoestatuscuenta` int(11) NOT NULL,
  `ep_tipoestatuscuentanombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codeptipoestatuscuenta`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipoestatuscuenta`
--

LOCK TABLES `ep_tipoestatuscuenta` WRITE;
/*!40000 ALTER TABLE `ep_tipoestatuscuenta` DISABLE KEYS */;
INSERT INTO `ep_tipoestatuscuenta` VALUES (1,'Activa'),(2,'Desactivada');
/*!40000 ALTER TABLE `ep_tipoestatuscuenta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipoinmueble`
--

DROP TABLE IF EXISTS `ep_tipoinmueble`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipoinmueble` (
  `codeptipoinmueble` int(11) NOT NULL,
  `ep_tipoinmueblenombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codeptipoinmueble`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipoinmueble`
--

LOCK TABLES `ep_tipoinmueble` WRITE;
/*!40000 ALTER TABLE `ep_tipoinmueble` DISABLE KEYS */;
INSERT INTO `ep_tipoinmueble` VALUES (1,'Terreno'),(2,'Casa'),(3,'Apartamento');
/*!40000 ALTER TABLE `ep_tipoinmueble` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipoinstitucion`
--

DROP TABLE IF EXISTS `ep_tipoinstitucion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipoinstitucion` (
  `codeptipoinstitucion` int(11) NOT NULL,
  `ep_tipoinstitucionnombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codeptipoinstitucion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipoinstitucion`
--

LOCK TABLES `ep_tipoinstitucion` WRITE;
/*!40000 ALTER TABLE `ep_tipoinstitucion` DISABLE KEYS */;
INSERT INTO `ep_tipoinstitucion` VALUES (1,'Instituciónes Bancarias'),(2,'Sociedades Financieras'),(3,'Cooperatiivas Sistema Micoope'),(4,'Microfinanciera');
/*!40000 ALTER TABLE `ep_tipoinstitucion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipomoneda`
--

DROP TABLE IF EXISTS `ep_tipomoneda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipomoneda` (
  `codeptipomoneda` int(11) NOT NULL,
  `ep_tipomonedanombre` varchar(45) DEFAULT NULL,
  `ep_signomoneda` varchar(45) DEFAULT NULL,
  `ep_codigointernacional` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codeptipomoneda`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipomoneda`
--

LOCK TABLES `ep_tipomoneda` WRITE;
/*!40000 ALTER TABLE `ep_tipomoneda` DISABLE KEYS */;
INSERT INTO `ep_tipomoneda` VALUES (1,'Quetzales','Q','GTQ'),(2,'Dolares','$','USD');
/*!40000 ALTER TABLE `ep_tipomoneda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tiponacionalidad`
--

DROP TABLE IF EXISTS `ep_tiponacionalidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tiponacionalidad` (
  `codeptiponacionalidad` int(11) NOT NULL,
  `ep_tiponacionalidadnombre` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`codeptiponacionalidad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tiponacionalidad`
--

LOCK TABLES `ep_tiponacionalidad` WRITE;
/*!40000 ALTER TABLE `ep_tiponacionalidad` DISABLE KEYS */;
INSERT INTO `ep_tiponacionalidad` VALUES (1,'Nacional'),(2,'Extranjero');
/*!40000 ALTER TABLE `ep_tiponacionalidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipoparentesco`
--

DROP TABLE IF EXISTS `ep_tipoparentesco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipoparentesco` (
  `codeptipoparentesco` int(11) NOT NULL,
  `ep_tipoparentesconombre` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`codeptipoparentesco`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipoparentesco`
--

LOCK TABLES `ep_tipoparentesco` WRITE;
/*!40000 ALTER TABLE `ep_tipoparentesco` DISABLE KEYS */;
INSERT INTO `ep_tipoparentesco` VALUES (1,'Padre'),(2,'Madre'),(3,'Tio/a'),(4,'Abuelo/a'),(5,'Sobrino');
/*!40000 ALTER TABLE `ep_tipoparentesco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipopep`
--

DROP TABLE IF EXISTS `ep_tipopep`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipopep` (
  `codeptipopep` int(11) NOT NULL,
  `ep_tipopep` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`codeptipopep`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipopep`
--

LOCK TABLES `ep_tipopep` WRITE;
/*!40000 ALTER TABLE `ep_tipopep` DISABLE KEYS */;
INSERT INTO `ep_tipopep` VALUES (1,'PEP'),(2,'PPEP'),(3,'CPEP');
/*!40000 ALTER TABLE `ep_tipopep` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipoprestamo`
--

DROP TABLE IF EXISTS `ep_tipoprestamo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipoprestamo` (
  `codeptipoprestamo` int(11) NOT NULL,
  `ep_tipoprestamonombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codeptipoprestamo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipoprestamo`
--

LOCK TABLES `ep_tipoprestamo` WRITE;
/*!40000 ALTER TABLE `ep_tipoprestamo` DISABLE KEYS */;
INSERT INTO `ep_tipoprestamo` VALUES (1,'Fiduciario'),(2,'Hipotecario'),(3,'Prendario'),(4,'Back to Back / Automático'),(5,'Mixto');
/*!40000 ALTER TABLE `ep_tipoprestamo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipotelefono`
--

DROP TABLE IF EXISTS `ep_tipotelefono`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipotelefono` (
  `codeptipotelefono` int(11) NOT NULL,
  `ep_tipotelefononombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codeptipotelefono`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipotelefono`
--

LOCK TABLES `ep_tipotelefono` WRITE;
/*!40000 ALTER TABLE `ep_tipotelefono` DISABLE KEYS */;
INSERT INTO `ep_tipotelefono` VALUES (1,'Telefono Casa'),(2,'Celular');
/*!40000 ALTER TABLE `ep_tipotelefono` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_tipovehiculo`
--

DROP TABLE IF EXISTS `ep_tipovehiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_tipovehiculo` (
  `codeptipovehiculo` int(11) NOT NULL,
  `ep_tipovehiculonombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codeptipovehiculo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_tipovehiculo`
--

LOCK TABLES `ep_tipovehiculo` WRITE;
/*!40000 ALTER TABLE `ep_tipovehiculo` DISABLE KEYS */;
INSERT INTO `ep_tipovehiculo` VALUES (1,'Carro'),(2,'Bus'),(3,'Camion'),(4,'Bicicleta'),(5,'Moto'),(6,'Moto2');
/*!40000 ALTER TABLE `ep_tipovehiculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ep_vehiculo`
--

DROP TABLE IF EXISTS `ep_vehiculo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ep_vehiculo` (
  `codepvehiculo` int(11) NOT NULL,
  `codeptipovehiculo` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_vehiculomarca` varchar(100) DEFAULT NULL,
  `ep_vehiculolinea` varchar(100) DEFAULT NULL,
  `ep_vehiculomodelo` varchar(100) DEFAULT NULL,
  `ep_vehiculoplaca` varchar(100) DEFAULT NULL,
  `ep_vehiculocomentario` varchar(100) DEFAULT NULL,
  `ep_vehiculoanombrede` varchar(120) DEFAULT NULL,
  `ep_vehiculomotivodeanombrede` varchar(120) DEFAULT NULL,
  PRIMARY KEY (`codepvehiculo`),
  KEY `fk_ep_vehiculo_ep_tipovehiculo1_idx` (`codeptipovehiculo`),
  KEY `fk_ep_vehiculo_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  CONSTRAINT `fk_ep_vehiculo_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ep_vehiculo_ep_tipovehiculo1` FOREIGN KEY (`codeptipovehiculo`) REFERENCES `ep_tipovehiculo` (`codeptipovehiculo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ep_vehiculo`
--

LOCK TABLES `ep_vehiculo` WRITE;
/*!40000 ALTER TABLE `ep_vehiculo` DISABLE KEYS */;
INSERT INTO `ep_vehiculo` VALUES (1,1,1,'Nissan','Lujo','2015','22545k',NULL,NULL,NULL),(2,1,1,'Toyota','Luxio','2015','11544k',NULL,NULL,NULL),(3,1,16,'Nissan','Lujo','2015','22545k',NULL,NULL,NULL),(4,1,16,'Toyota','Luxio','2015','11544k',NULL,NULL,NULL),(5,1,1,'Toyota','Lexus','M43','2565D8',NULL,NULL,NULL),(6,2,30,'asd','asd','asd','546',NULL,NULL,NULL),(7,1,21,'Prueba','Prueba','Prueba','sa5465',NULL,NULL,NULL),(10,5,4,'Bajaj','Boxer','2018','MO 580GGF','','',''),(11,1,37,'Toyota','Scion','2006','810GGP','Gris','',''),(12,5,35,'Haojue','KA 150','2019','606 GCY','','',''),(13,1,32,'toyota','ECHO','2001','661fwp','CARRO PROPIO','ESPOSA','QUISE REGISTRARLO A SU NOMBRE'),(14,1,35,'Mitsubishi','Lancer','2005','662GSV','','Jorge Luis Chacon',''),(15,1,38,'Toyota','Yaris','2008','P-642GGG','','Melanie Eunice Arriola Castillo',''),(16,1,38,'Mazda','3','2006','P-088GFS','','Leslie Stella Castillo Caridi',''),(17,3,31,'2','2','Prueba','546','asdas','',''),(18,3,31,'2','2','Prueba','546','asdas','','');
/*!40000 ALTER TABLE `ep_vehiculo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_area`
--

DROP TABLE IF EXISTS `gen_area`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_area` (
  `codgenarea` int(11) NOT NULL,
  `codgensucursal` int(11) DEFAULT NULL,
  `gen_areanombre` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`codgenarea`),
  KEY `fk_gen_area_gen_sucursal1_idx` (`codgensucursal`),
  CONSTRAINT `fk_gen_area_gen_sucursal1` FOREIGN KEY (`codgensucursal`) REFERENCES `gen_sucursal` (`codgensucursal`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_area`
--

LOCK TABLES `gen_area` WRITE;
/*!40000 ALTER TABLE `gen_area` DISABLE KEYS */;
INSERT INTO `gen_area` VALUES (1,1,'ADMINISTRACIÓN'),(2,2,'AG. ATANASIO TZUL'),(3,2,'AG. BOCA DEL MONTE'),(4,2,'AG. FLORIDA'),(5,2,'MERCADEO'),(6,2,'AG. GRAN VIA'),(7,2,'AG. MEGA 6'),(8,2,'AG. METROCENTRO'),(9,2,'AG. MIXCO'),(10,2,'AG. PACIFIC VH'),(11,2,'AG. PETAPA'),(12,2,'AG. PORTALES'),(13,2,'AG. SAN CRISTOBAL'),(14,2,'AG. SAN LUCAS'),(15,2,'AG. SAN NICOLAS'),(16,2,'AG. TERMINAL'),(17,2,'AG. ZONA 4'),(18,2,'MINI AG. METRONORTE'),(19,2,'AG.C.C. NARANJO MALL'),(20,2,'AGENCIA LOS ALAMOS'),(21,3,'ARCHIVO'),(22,4,'AUDITORIA INTERNA'),(23,1,'CAPACITACIÓN Y DESARROLLO'),(24,3,'CARTERA DEPURADA '),(25,2,'CENTRAL ZONA 14'),(26,3,'COBROS'),(27,2,'COMERCIALIZACIÓN'),(28,5,'CONTABILIDAD'),(29,3,'CRÉDITOS'),(30,4,'CUMPLIMIENTO'),(31,5,'FINANZAS'),(32,6,'GERENCIA GENERAL'),(33,1,'IDT'),(34,3,'JURIDICO'),(35,2,'KIOSCO MIRAFLORES'),(36,2,'KIOSCO MONSERRAT'),(37,2,'KIOSKO PORTALES'),(38,2,'MINI AG C.C. PRADERA'),(39,2,'NEGOCIOS'),(40,1,'NORMATIVIDAD/PROCESOS'),(41,2,'OPERACIONES AGENCIA'),(42,2,'PREMORA'),(43,2,'QA'),(44,6,'RIESGOS'),(45,1,'SEGURIDAD'),(46,5,'SEGUROS'),(47,1,'SERVICIOS GENERALES'),(48,2,'STA CATARINA PINULA'),(49,1,'TALENTO HUMANO'),(50,5,'TESORERIA');
/*!40000 ALTER TABLE `gen_area` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_bitacora_ingresos_egresos`
--

DROP TABLE IF EXISTS `gen_bitacora_ingresos_egresos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_bitacora_ingresos_egresos` (
  `codgen_bitacora_ingresos_egresos` int(11) NOT NULL AUTO_INCREMENT,
  `gen_bitacora_ingresos_egresosusername` varchar(80) DEFAULT NULL,
  `gen_bitacora_ingresos_egresosipaddress` varchar(80) DEFAULT NULL,
  `gen_bitacora_ingresos_egresosmacaddress` varchar(80) DEFAULT NULL,
  `gen_bitacora_ingresos_egresosfechahora` datetime DEFAULT NULL,
  `gen_bitacora_ingresos_egresosnombremodulo` varchar(80) DEFAULT NULL,
  `gen_bitacora_ingresos_egresosestado` varchar(80) DEFAULT NULL,
  PRIMARY KEY (`codgen_bitacora_ingresos_egresos`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_bitacora_ingresos_egresos`
--

LOCK TABLES `gen_bitacora_ingresos_egresos` WRITE;
/*!40000 ALTER TABLE `gen_bitacora_ingresos_egresos` DISABLE KEYS */;
/*!40000 ALTER TABLE `gen_bitacora_ingresos_egresos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_bitacora_procedimientos`
--

DROP TABLE IF EXISTS `gen_bitacora_procedimientos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_bitacora_procedimientos` (
  `codgen_bitacora_procedimientos` int(11) NOT NULL AUTO_INCREMENT,
  `gen_bitacora_procedimientosusername` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosipaddress` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosmacaddress` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosfechahora` datetime DEFAULT NULL,
  `gen_bitacora_procedimientosnombremodulo` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosnombreaplicacion` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosoperacion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`codgen_bitacora_procedimientos`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_bitacora_procedimientos`
--

LOCK TABLES `gen_bitacora_procedimientos` WRITE;
/*!40000 ALTER TABLE `gen_bitacora_procedimientos` DISABLE KEYS */;
/*!40000 ALTER TABLE `gen_bitacora_procedimientos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_departamento`
--

DROP TABLE IF EXISTS `gen_departamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_departamento` (
  `codgendepartamento` int(11) NOT NULL,
  `gen_departamentonombre` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`codgendepartamento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_departamento`
--

LOCK TABLES `gen_departamento` WRITE;
/*!40000 ALTER TABLE `gen_departamento` DISABLE KEYS */;
INSERT INTO `gen_departamento` VALUES (1,'GUATEMALA'),(2,'SACATEPÉQUEZ'),(3,'CHIMALTENANGO'),(4,'EL PROGRESO'),(5,'ESCUINTLA'),(6,'SANTA ROSA'),(7,'SOLOLÁ'),(8,'TOTONICAPÁN'),(9,'QUETZALTENANGO'),(10,'SUCHITEPÉQUEZ'),(11,'RETALHULEU'),(12,'SAN MARCOS'),(13,'HUEHUETENANGO'),(14,'EL QUICHÉ'),(15,'BAJA VERAPAZ'),(16,'ALTA VERAPAZ'),(17,'PETÉN'),(18,'IZABAL'),(19,'ZACAPA'),(20,'CHIQUIMULA'),(21,'JALAPA'),(22,'JUTIAPA');
/*!40000 ALTER TABLE `gen_departamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_invequipo`
--

DROP TABLE IF EXISTS `gen_invequipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_invequipo` (
  `codgeninvequipo` int(11) NOT NULL,
  `codgensucursal` int(11) DEFAULT NULL,
  `gen_invequipodescripcion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`codgeninvequipo`),
  KEY `fk_gen_invequipo_gen_sucursal1_idx` (`codgensucursal`),
  CONSTRAINT `fk_gen_invequipo_gen_sucursal1` FOREIGN KEY (`codgensucursal`) REFERENCES `gen_sucursal` (`codgensucursal`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_invequipo`
--

LOCK TABLES `gen_invequipo` WRITE;
/*!40000 ALTER TABLE `gen_invequipo` DISABLE KEYS */;
INSERT INTO `gen_invequipo` VALUES (1,1,'Portatil');
/*!40000 ALTER TABLE `gen_invequipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_municipio`
--

DROP TABLE IF EXISTS `gen_municipio`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_municipio` (
  `codgenmunicipio` int(11) NOT NULL,
  `codgendepartamento` int(11) DEFAULT NULL,
  `gen_municipionombre` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`codgenmunicipio`),
  KEY `fk_gen_municipio_gen_departamento1_idx` (`codgendepartamento`),
  CONSTRAINT `fk_gen_municipio_gen_departamento1` FOREIGN KEY (`codgendepartamento`) REFERENCES `gen_departamento` (`codgendepartamento`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_municipio`
--

LOCK TABLES `gen_municipio` WRITE;
/*!40000 ALTER TABLE `gen_municipio` DISABLE KEYS */;
INSERT INTO `gen_municipio` VALUES (101,1,'GUATEMALA'),(102,1,'SANTA CATARINA PINULA'),(103,1,'SAN JOSÉ PINULA'),(104,1,'SAN JOSÉ DEL GOLFO'),(105,1,'PALENCIA'),(106,1,'CHINAUTLA'),(107,1,'SAN PEDRO AYAMPUC'),(108,1,'MIXCO'),(109,1,'SAN PEDRO SACATEPÉQUEZ'),(110,1,'SAN JUAN SACATEPÉQUEZ'),(111,1,'SAN RAYMUNDO'),(112,1,'CHUARRANCHO'),(113,1,'FRAIJANES'),(114,1,'AMATITLÁN'),(115,1,'VILLA NUEVA'),(116,1,'VILLA CANALES'),(117,1,'SAN MIGUEL PETAPA'),(201,4,'GUASTATOYA'),(202,4,'MORAZÁN'),(203,4,'SAN AGUSTÍN ACASAGUASTLÁN'),(204,4,'SAN CRISTÓBAL ACASAGUASTLÁN'),(205,4,'EL JÍCARO'),(206,4,'SANSARE'),(207,4,'SANARATE'),(208,4,'SAN ANTONIO LA PAZ'),(301,2,'ANTIGUA GUATEMALA'),(302,2,'JOCOTENANGO'),(303,2,'PASTORES'),(304,2,'SUMPANGO'),(305,2,'SANTO DOMINGO XENACOJ'),(306,2,'SANTIAGO SACATEPEQUÉZ'),(307,2,'SAN BARTOLOMÉ MILPAS ALTAS'),(308,2,'SAN LUCAS SACATEPÉQUEZ'),(309,2,'SANTA LUCÍA MILPAS ALTAS'),(310,2,'MAGDALENA MILPAS ALTAS'),(311,2,'SANTA MARÍA DE JESÚS'),(312,2,'CIUDAD VIEJA'),(313,2,'SAN MIGUEL DUEÑAS'),(314,2,'ALOTENANGO'),(315,2,'SAN ANTONIO AGUAS CALIENTES'),(316,2,'SANTA CATARINA BARAHONA'),(401,3,'CHIMALTENANGO'),(402,3,'SAN JOSÉ POAQUIL'),(403,3,'SAN MARTÍN JILOTEPEQUE'),(404,3,'SAN JUAN COMALAPA'),(405,3,'SANTA APOLONIA'),(406,3,'TECPÁN GUATEMALA'),(407,3,'PATZÚN'),(408,3,'POCHUTA'),(409,3,'PATZICÍA'),(410,3,'SANTA CRUZ BALANYA'),(411,3,'ACATENANGO'),(412,3,'SAN PEDRO YEPOCAPA'),(413,3,'SAN ANDRÉS ITZAPA'),(414,3,'PARRAMOS'),(415,3,'ZARAGOZA'),(416,3,'EL TEJAR'),(501,5,'ESCUINTLA'),(502,5,'SANTA LUCÍA COTZUMALGUAPA'),(503,5,'LA DEMOCRACIA'),(504,5,'SIQUINALÁ'),(505,5,'MASAGUA'),(506,5,'TIQUISATE'),(507,5,'LA GOMERA'),(508,5,'GUANAGAZAPA'),(509,5,'PUERTO SAN JOSÉ'),(510,5,'IZTAPA'),(511,5,'PALÍN'),(512,5,'SAN VICENTE PACAYA'),(513,5,'NUEVA CONCEPCIÓN'),(514,5,'SIPACATE'),(601,6,'CUILAPA'),(602,6,'BARBERENA'),(603,6,'SANTA ROSA DE LIMA'),(604,6,'CASILLAS'),(605,6,'SAN RAFAEL LAS FLORES'),(606,6,'ORATORIO'),(607,6,'SAN JUAN TECUACO'),(608,6,'CHIQUIMULILLA'),(609,6,'TAXISCO'),(610,6,'SANTA MARÍA IXHUATÁN'),(611,6,'GUAZACAPÁN'),(612,6,'SANTA CRUZ NARANJO'),(613,6,'PUEBLO NUEVO VIÑAS'),(614,6,'NUEVA SANTA ROSA'),(701,7,'SOLOLÁ'),(702,7,'SAN JOSÉ CHACAYÁ'),(703,7,'SANTA MARÍA VISITACIÓN'),(704,7,'SANTA LUCÍA UTATLÁN'),(705,7,'NAHUALÁ'),(706,7,'SANTA CATARINA IXTAHUACÁN'),(707,7,'SANTA CLARA LA LAGUNA'),(708,7,'CONCEPCIÓN'),(709,7,'SAN ANDRÉS SEMETABAJ'),(710,7,'PANAJACHEL'),(711,7,'SANTA CATARINA PALOPÓ'),(712,7,'SAN ANTONIO PALOPÓ'),(713,7,'SAN LUCAS TOLIMÁN'),(714,7,'SANTA CRUZ LA LAGUNA'),(715,7,'SAN PABLO LA LAGUNA'),(716,7,'SAN MARCOS LA LAGUNA'),(717,7,'SAN JUAN LA LAGUNA'),(718,7,'SAN PEDRO LA LAGUNA'),(719,7,'SANTIAGO ATITLÁN'),(801,8,'TOTONICAPÁN'),(802,8,'SAN CRISTÓBAL TOTONICAPÁN'),(803,8,'SAN FRANCISCO EL ALTO'),(804,8,'SAN ANDRÉS XECUL'),(805,8,'MOMOSTENANGO'),(806,8,'SANTA MARÍA CHIQUIMULA'),(807,8,'SANTA LUCÍA LA REFORMA'),(808,8,'SAN BARTOLO'),(901,9,'QUETZALTENANGO'),(902,9,'SALCAJÁ'),(903,9,'OLINTEPEQUE'),(904,9,'SAN CARLOS SIJA'),(905,9,'SIBILIA'),(906,9,'CABRICÁN'),(907,9,'CAJOLA'),(908,9,'SAN MIGUEL SIGUILA'),(909,9,'SAN JUAN OSTUNCALCO'),(910,9,'SAN MATEO'),(911,9,'CONCEPCIÓN CHIQUIRICHAPA'),(912,9,'SAN MARTÍN SACATEPÉQUEZ'),(913,9,'ALMOLONGA'),(914,9,'CANTEL'),(915,9,'HUITÁN'),(916,9,'ZUNIL'),(917,9,'COLOMBA'),(918,9,'SAN FRANCISCO LA UNIÓN'),(919,9,'EL PALMAR'),(920,9,'COATEPEQUE'),(921,9,'GÉNOVA COSTA CUCA'),(922,9,'FLORES'),(923,9,'LA ESPERANZA'),(924,9,'PALESTINA DE LOS ALTOS'),(1001,10,'MAZATENANGO'),(1002,10,'CUYOTENANGO'),(1003,10,'SAN FRANCISCO ZAPOTITLÁN'),(1004,10,'SAN BERNARDINO'),(1005,10,'SAN JOSÉ EL ÍDOLO'),(1006,10,'SANTO DOMINGO SUCHITEPEQUEZ'),(1007,10,'SAN LORENZO'),(1008,10,'SAMAYAC'),(1009,10,'SAN PABLO JOCOPILAS'),(1010,10,'SAN ANTONIO SUCHITEPÉQUEZ'),(1011,10,'SAN MIGUEL PANÁN'),(1012,10,'SAN GABRIEL'),(1013,10,'CHICACAO'),(1014,10,'PATULUL'),(1015,10,'SANTA BÁRBARA'),(1016,10,'SAN JUAN BAUTISTA'),(1017,10,'SANTO TOMÁS LA UNIÓN'),(1018,10,'ZUNILITO'),(1019,10,'PUEBLO NUEVO'),(1020,10,'RÍO BRAVO'),(1021,10,'SAN JOSÉ LA MÁQUINA'),(1101,11,'RETALHULEU'),(1102,11,'SAN SEBASTIÁN'),(1103,11,'SANTA CRUZ MULUÁ'),(1104,11,'SAN MARTÍN ZAPOTITLÁN'),(1105,11,'SAN FELIPE'),(1106,11,'SAN ANDRÉS VILLA SECA'),(1107,11,'CHAMPERICO'),(1108,11,'NUEVO SAN CARLOS'),(1109,11,'EL ASINTAL'),(1201,12,'SAN MARCOS'),(1202,12,'SAN PEDRO SACATEPÉQUEZ'),(1203,12,'SAN ANTONIO SACATEPÉQUEZ'),(1204,12,'COMITANCILLO'),(1205,12,'SAN MIGUEL IXTAHUACÁN'),(1206,12,'CONCEPCIÓN TUTUAPA'),(1207,12,'TACANÁ'),(1208,12,'SIBINAL'),(1209,12,'TAJUMULCO'),(1210,12,'TEJUTLA'),(1211,12,'SAN RAFAEL PIE DE LA CUESTA'),(1212,12,'NUEVO PROGRESO'),(1213,12,'EL TUMBADOR'),(1214,12,'SAN JOSE EL RODEO'),(1215,12,'MALACATÁN'),(1216,12,'CATARINA'),(1217,12,'AYUTLA (TECUN UMAN)'),(1218,12,'OCÓS'),(1219,12,'SAN PABLO'),(1220,12,'EL QUETZAL'),(1221,12,'LA REFORMA'),(1222,12,'PAJAPITA'),(1223,12,'IXCHIGUÁN'),(1224,12,'SAN JOSÉ OJETENAM'),(1225,12,'SAN CRISTÓBAL CUCHO'),(1226,12,'SIPACAPA'),(1227,12,'ESQUIPULAS PALO GORDO'),(1228,12,'RÍO BLANCO'),(1229,12,'SAN LORENZO'),(1230,12,'LA BLANCA'),(1301,13,'HUEHUETENANGO'),(1302,13,'CHIANTLA'),(1303,13,'MALACATANCITO'),(1304,13,'CUILCO'),(1305,13,'NENTÓN'),(1306,13,'SAN PEDRO NECTA'),(1307,13,'JACALTENANGO'),(1308,13,'SOLOMA'),(1309,13,'IXTAHUACÁN'),(1310,13,'SANTA BÁRBARA'),(1311,13,'LA LIBERTAD'),(1312,13,'LA DEMOCRACIA'),(1313,13,'SAN MIGUEL ACATÁN'),(1314,13,'SAN RAFAEL LA INDEPENDENCIA'),(1315,13,'TODOS SANTOS CUCHUMATÁN'),(1316,13,'SAN JUAN ATITÁN'),(1317,13,'SANTA EULALIA'),(1318,13,'SAN MATEO IXTATÁN'),(1319,13,'COLOTENANGO'),(1320,13,'SAN SEBASTIÁN HUEHUETENANGO'),(1321,13,'TECTITÁN'),(1322,13,'CONCEPCIÓN HUISTA'),(1323,13,'SAN JUAN IXCOY'),(1324,13,'SAN ANTONIO HUISTA'),(1325,13,'SAN SEBASTIÁN COATÁN'),(1326,13,'BARILLAS'),(1327,13,'AGUACATÁN'),(1328,13,'SAN RAFAEL PETZAL'),(1329,13,'SAN GASPAR IXCHIL'),(1330,13,'SANTIAGO CHIMALTENANGO'),(1331,13,'SANTA ANA HUISTA'),(1332,13,'UNION CANTINIL'),(1333,13,'PETATÁN'),(1401,14,'SANTA CRUZ DEL QUICHÉ'),(1402,14,'CHICHÉ'),(1403,14,'CHINIQUE'),(1404,14,'ZACUALPA'),(1405,14,'CHAJUL'),(1406,14,'CHICHICASTENANGO'),(1407,14,'PATZITE'),(1408,14,'SAN ANTONIO ILOTENANGO'),(1409,14,'SAN PEDRO JOCOPILAS'),(1410,14,'CUNÉN'),(1411,14,'SAN JUAN COTZAL'),(1412,14,'JOYABAJ'),(1413,14,'NEBAJ'),(1414,14,'SAN ANDRÉS SAJCABAJA'),(1415,14,'SAN MIGUEL USPANTÁN'),(1416,14,'SACAPULAS'),(1417,14,'SAN BARTOLOMÉ JOCOTENANGO'),(1418,14,'CANILLÁ'),(1419,14,'CHICAMÁN'),(1420,14,'IXCÁN'),(1421,14,'PACHALUM'),(1501,15,'SALAMÁ'),(1502,15,'SAN MIGUEL CHICAJ'),(1503,15,'RABINAL'),(1504,15,'CUBULCO'),(1505,15,'GRANADOS'),(1506,15,'EL CHOL'),(1507,15,'SAN JERÓNIMO'),(1508,15,'PURULHÁ'),(1601,16,'COBÁN'),(1602,16,'SANTA CRUZ VERAPAZ'),(1603,16,'SAN CRISTÓBAL VERAPAZ'),(1604,16,'TACTIC'),(1605,16,'TAMAHÚ'),(1606,16,'TUCURÚ'),(1607,16,'PANZÓS'),(1608,16,'SENAHÚ'),(1609,16,'SAN PEDRO CARCHÁ'),(1610,16,'SAN JUAN CHAMELCO'),(1611,16,'LANQUÍN'),(1612,16,'CAHABÓN'),(1613,16,'CHISEC'),(1614,16,'CHAHAL'),(1615,16,'FRAY BARTOLOMÉ DE LAS CASAS'),(1616,16,'SANTA CATARINA LA TINTA'),(1617,16,'RAXRUHA'),(1701,17,'FLORES'),(1702,17,'SAN JOSÉ'),(1703,17,'SAN BENITO'),(1704,17,'SAN ANDRÉS'),(1705,17,'LA LIBERTAD'),(1706,17,'SAN FRANCISCO'),(1707,17,'SANTA ANA'),(1708,17,'DOLORES'),(1709,17,'SAN LUIS'),(1710,17,'SAYAXCHÉ'),(1711,17,'MELCHOR DE MENCOS'),(1712,17,'POPTÚN'),(1713,17,'LAS CRUCES'),(1714,17,'EL CHAL'),(1801,18,'PUERTO BARRIOS'),(1802,18,'LIVINGSTON'),(1803,18,'EL ESTOR'),(1804,18,'MORALES'),(1805,18,'LOS AMATES'),(1901,19,'ZACAPA'),(1902,19,'ESTANZUELA'),(1903,19,'RÍO HONDO'),(1904,19,'GUALÁN'),(1905,19,'TECULUTÁN'),(1906,19,'USUMATLÁN'),(1907,19,'CABAÑAS'),(1908,19,'SAN DIEGO'),(1909,19,'LA UNIÓN'),(1910,19,'HUITÉ'),(1911,19,'SAN JORGE'),(2001,20,'CHIQUIMULA'),(2002,20,'SAN JOSÉ LA ARADA'),(2003,20,'SAN JUAN ERMITA'),(2004,20,'JOCOTÁN'),(2005,20,'CAMOTÁN'),(2006,20,'OLOPA'),(2007,20,'ESQUIPULAS'),(2008,20,'CONCEPCIÓN LAS MINAS'),(2009,20,'QUETZALTEPEQUE'),(2010,20,'SAN JACINTO'),(2011,20,'IPALA'),(2101,21,'JALAPA'),(2102,21,'SAN PEDRO PINULA'),(2103,21,'SAN LUIS JILOTEPEQUE'),(2104,21,'SAN MIGUEL CHAPARRÓN'),(2105,21,'SAN CARLOS ALZATATE'),(2106,21,'MONJAS'),(2107,21,'MATAQUESCUINTLA'),(2201,22,'JUTIAPA'),(2202,22,'EL PROGRESO'),(2203,22,'SANTA CATARINA MITA'),(2204,22,'AGUA BLANCA'),(2205,22,'ASUNCIÓN MITA'),(2206,22,'YUPILTEPEQUE'),(2207,22,'ATESCATEMPA'),(2208,22,'JEREZ'),(2209,22,'EL ADELANTO'),(2210,22,'ZAPOTITLÁN'),(2211,22,'COMAPA'),(2212,22,'JALPATAGUA'),(2213,22,'CONGUACO'),(2214,22,'MOYUTA'),(2215,22,'PASACO'),(2216,22,'SAN JOSÉ ACATEMPA'),(2217,22,'QUEZADA');
/*!40000 ALTER TABLE `gen_municipio` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_puestos`
--

DROP TABLE IF EXISTS `gen_puestos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_puestos` (
  `codgenpuestos` int(11) NOT NULL,
  `codgenarea` int(11) DEFAULT NULL,
  `gen_puestosnombre` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`codgenpuestos`),
  KEY `fk_gen_puestos_gen_area1_idx` (`codgenarea`),
  CONSTRAINT `fk_gen_puesto_gen_areal1` FOREIGN KEY (`codgenarea`) REFERENCES `gen_area` (`codgenarea`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_puestos`
--

LOCK TABLES `gen_puestos` WRITE;
/*!40000 ALTER TABLE `gen_puestos` DISABLE KEYS */;
INSERT INTO `gen_puestos` VALUES (1,1,'ENCARGADA DE RECEPCION'),(2,1,'ASISTENTE GERENCIA ADMINISTRATIVA'),(3,1,'TRADEMARKETING'),(4,1,'GERENTE ADMINISTRATIVO'),(5,1,'RECEPCIONISTA'),(6,2,'ASESOR DE ATENCION AL ASOCIADO'),(8,2,'CONSERJE'),(9,2,'SUBJEFE DE AGENCIA'),(10,2,'RECEPTOR PAGADOR'),(11,2,'EJECUTIVO MULTIFUNCIONAL'),(13,2,'JEFE DE AGENCIA'),(14,2,'ASESOR DE CREDITOS'),(15,3,'CONSERJE'),(16,3,'ASESOR DE CREDITOS'),(17,3,'ASESOR DE ATENCION AL ASOCIADO'),(18,3,'SUBJEFE DE AGENCIA'),(19,3,'RECEPTOR PAGADOR'),(20,3,'ASESOR DE CREDITOS'),(23,3,'EJECUTIVO MULTIFUNCIONAL'),(25,3,'JEFE DE AGENCIA'),(26,4,'RECEPTOR PAGADOR'),(28,4,'ASESOR DE ATENCION AL ASOCIADO'),(29,4,'JEFE DE AGENCIA'),(30,5,'AUXILIAR DE TELEVENTAS '),(31,4,'ASESOR DE CREDITOS'),(32,4,'CONSERJE'),(33,4,'SUBJEFE DE AGENCIA'),(53,7,'ASESOR DE CREDITOS'),(54,7,'CONSERJE'),(56,7,'ASESOR DE ATENCION AL ASOCIADO'),(58,7,'JEFE DE AGENCIA'),(59,7,'RECEPTOR PAGADOR'),(62,8,'JEFE DE AGENCIA'),(63,8,'CONSERJE'),(64,8,'RECEPTOR PAGADOR'),(65,8,'ASESOR DE CREDITOS'),(68,8,'ASESOR DE ATENCION AL ASOCIADO'),(69,8,'SUBJEFE DE AGENCIA'),(70,9,'RECEPTOR PAGADOR'),(71,9,'CONSERJE'),(72,9,'ASESOR DE ATENCION AL ASOCIADO'),(73,9,'JEFE DE AGENCIA'),(74,9,'SUBJEFE DE AGENCIA'),(75,9,'EJECUTIVO MULTIFUNCIONAL ROTATIVO ZONA 14'),(77,10,'JEFE DE AGENCIA JUNIOR'),(79,10,'RECEPTOR PAGADOR'),(80,10,'EJECUTIVO MULTIFUNCIONAL'),(82,10,'ASESOR DE ATENCION AL ASOCIADO'),(86,11,'JEFE DE AGENCIA'),(87,11,'RECEPTOR PAGADOR'),(88,11,'ASESOR DE ATENCION AL ASOCIADO'),(89,11,'EJECUTIVO MULTIFUNCIONAL'),(90,11,'ASESOR DE CREDITOS'),(92,11,'CONSERJE'),(95,11,'SUBJEFE DE AGENCIA'),(98,12,'JEFE DE AGENCIA'),(99,12,'EJECUTIVO MULTIFUNCIONAL'),(100,12,'RECEPTOR PAGADOR'),(101,12,'ASESOR DE ATENCION AL ASOCIADO'),(103,12,'ASESOR DE CREDITOS'),(104,12,'SUBJEFE DE AGENCIA'),(105,12,'CONSERJE'),(107,13,'ASESOR DE ATENCION AL ASOCIADO'),(108,13,'RECEPTOR PAGADOR'),(109,13,'CONSERJE'),(112,13,'ASESOR DE CREDITOS'),(113,13,'JEFE DE AGENCIA'),(114,13,'SUBJEFE DE AGENCIA'),(115,13,'EJECUTIVO MULTIFUNCIONAL'),(116,14,'ASESOR DE ATENCION AL ASOCIADO'),(117,14,'RECEPTOR PAGADOR'),(119,14,'SUBJEFE DE AGENCIA'),(120,14,'ASESOR DE CREDITOS'),(121,14,'JEFE DE AGENCIA'),(122,14,'CONSERJE'),(123,14,'EJECUTIVO MULTIFUNCIONAL'),(125,15,'ASESOR DE ATENCION AL ASOCIADO'),(126,15,'ASESOR DE CREDITOS'),(127,15,'RECEPTOR PAGADOR'),(128,15,'JEFE DE AGENCIA'),(129,15,'SUBJEFE DE AGENCIA'),(130,16,'ASESOR DE ATENCION AL ASOCIADO'),(132,16,'RECEPTOR PAGADOR'),(133,16,'SUBJEFE DE AGENCIA'),(134,16,'JEFE DE AGENCIA'),(137,39,'GERENTE DE NEGOCIOS'),(140,16,'ASESOR DE CREDITOS'),(141,18,'JEFE DE AGENCIA JUNIOR'),(142,18,'ASESOR DE ATENCION AL ASOCIADO'),(143,18,'ASESOR DE CREDITOS'),(145,18,'RECEPTOR PAGADOR'),(150,19,'ASESOR DE ATENCIÓN AL ASOCIADO'),(152,19,'JEFE DE AGENCIA'),(153,19,'CONSERJE'),(154,19,'SUBJEFE DE AGENCIA'),(155,19,'RECEPTOR PAGADOR'),(156,19,'ASESOR DE CREDITOS'),(157,20,'EJECUTIVO DE KIOSCO'),(158,20,'JEFE DE AGENCIA JUNIOR'),(159,20,'RECEPTOR PAGADOR'),(160,20,'CONSERJE '),(161,20,'ASESOR DE CREDITOS'),(167,21,'JEFE DE ARCHIVO'),(168,21,'CONSERJE'),(169,21,'AUXILIAR DE ARCHIVO'),(173,22,'ENCARGADO DE AUDITORÍA'),(174,22,'ASISTENTE DE AUDITORÍA'),(175,22,'AUDITOR INTERNO'),(176,22,'AUXILIAR DE AUDITORÍA'),(179,23,'GESTOR DE EDUCACIÓN'),(180,23,'ASISTENTE DE SEGURIDAD OCUPACIONAL'),(181,23,'JEFE DE CAPACITACIÓN Y DESARROLLO'),(182,23,'ASISTENTE DE CAPACITACIÓN Y DESARROLLO'),(183,23,'AUXILIAR DE CAPACITACIÓN'),(187,24,'JEFE DE CARTERA DEPURADA'),(188,24,'ASISTENTE DE CARTERA DEPURADA'),(189,24,'GESTOR DE COBROS CARTERA DEPURADA'),(190,24,'EJECUTIVO DE ACTIVOS EXTRAORDINARIOS'),(197,25,'JEFE DE AGENCIA'),(198,25,'ASESOR DE ATENCIÓN AL ASOCIADO'),(199,25,'ASESOR DE CREDITOS'),(200,25,'SUBJEFE DE AGENCIA'),(201,25,'RECEPTOR PAGADOR'),(217,26,'RECEPCIONISTA'),(218,26,'JEFE DE COBROS'),(219,26,'GESTOR DE COBROS'),(220,26,'ASISTENTE DE COBROS'),(221,26,'ENCARGADO DE COBROS'),(223,27,'ASESOR FINANCIERO'),(224,27,'ASESOR FINANCIERO SENIOR'),(225,27,'JEFE DE VENTAS'),(226,27,'AUXILIAR DE VENTAS'),(233,28,'AUXILIAR DE CONTABILIDAD'),(234,28,'ASISTENTE DE CONTABILIDAD'),(235,28,'JEFE DE CONTABILIDAD'),(266,29,'ASISTENTE DE CREDITOS'),(267,29,'ANALISTA JUNIOR'),(268,29,'ANALISTA SENIOR'),(269,29,'VERIFICACOR TELEFONICO'),(270,29,'VERIFICADOR DE CAMPO'),(271,30,'AUXILIAR DE CUMPLIMIENTO'),(272,30,'OFICIAL DE CUMPLIMIENTO SUPLENTE'),(273,30,'OFICIAL DE CUMPLIMIENTO'),(274,31,'GERENTE FINANCIERO'),(275,31,'ENCARGADO DE NOMINA Y PRESTACIONES'),(276,31,'ASISTENTE DE GERENCIA FINANCIERA'),(278,32,'GERENTE GENERAL'),(279,32,'SUB GERENTE GENERAL'),(280,32,'ASISTENTE DE GERENCIA GENERAL'),(281,32,'ASISTENTE DE CONSEJO DE ADMINISTRACIÓN'),(287,33,'PROGRAMADOR'),(288,33,'AUXILIAR DE INFORMÁTICA'),(289,33,'JEFE DE INFORMÁTICA'),(290,33,'ASISTENTE DE INFORMÁTICA'),(295,34,'COORDINADOR LEGAL'),(296,34,'PROCURADOR'),(297,35,'EJECUTIVO DE KIOSCO'),(299,36,'EJECUTIVO DE KIOSCO'),(301,5,'JEFE DE MERCADEO '),(302,5,'EJECUTIVO DE TELEVENTAS'),(304,5,'DISEÑADOR GRAFICO'),(306,5,'ENCARGADO DE PRODUCTOS ELECTRONICOS'),(312,5,'AUXILIAR DE MERCADEO'),(313,5,'ASISTENTE DE MERCADEO'),(314,38,'EJECUTIVO DE KIOSCO'),(316,39,'SUPERVISOR DE NEGOCIOS'),(317,39,'ASISTENTE DE GERENCIA DE NEGOCIOS'),(318,39,'COORDINADOR DE AGENCIAS'),(319,39,'ANALISTA DE NEGOCIOS'),(321,40,'AUXILIAR DE PROCESOS'),(322,40,'JEFE DE PROCESOS Y ASEGURAMIENTO DE LA CALIDAD'),(326,41,'ANALISTA DE OPERACIONES DE AGENCIA'),(329,42,'ENCARGADO DE PREMORA'),(330,42,'GESTOR DE PREMORA'),(331,43,'ANALISTA QA'),(332,43,'ENCARGADO QA'),(336,44,'JEFE DE RIESGOS'),(337,44,'ASISTENTE DE RIESGOS'),(338,44,'ANALISTA DE RIESGOS'),(343,45,'MENSAJERO'),(344,45,'VELADOR'),(345,45,'AUXILIAR DE SEGURIDAD'),(346,46,'AUXILIAR DE SEGUROS'),(347,46,'JEFE DE SEGUROS'),(354,47,'CONSERJE'),(355,47,'AUXILIAR DE MANTENIMIENTO'),(356,47,'JEFE DE MANTENIMIENTO E INFRAESTRUCTURA'),(358,48,'RECEPTOR PAGADOR'),(359,48,'JEFE DE AGENCIA JUNIOR'),(360,48,'ASESOR DE CREDITOS'),(365,49,'ENCARGADA DE RECLUTAMIENTO Y SELECCIÓN'),(366,49,'ASISTENTE DE TALENTO HUMANO'),(367,49,'JEFE DE TALENTO HUMANO'),(368,50,'TESORERO'),(369,50,'AUXILIAR DE TESORERIA'),(373,45,'JEFE DE SEGURIDAD'),(374,49,'AUXILIAR DE ENFERMERÍA'),(375,6,'ASESOR DE ATENCIÓN AL ASOCIADO'),(376,6,'RECEPTOR PAGADOR'),(377,6,'JEFE DE AGENCIA'),(378,6,'SUBJEFE DE AGENCIA'),(379,6,'ASESOR DE CREDITOS'),(380,6,'CONSERJE'),(383,15,'CONSERJE'),(384,15,'EJECUTIVO MULTIFUNCIONAL'),(386,17,'ASESOR DE ATENCIÓN AL ASOCIADO'),(387,17,'RECEPTOR PAGADOR'),(388,17,'SUBJEFE DE AGENCIA'),(389,17,'JEFE DE AGENCIA'),(390,17,'CONSERJE'),(391,17,'EJECUTIVO MULTIFUNCIONAL'),(392,17,'ASESOR DE CREDITOS'),(393,19,'EJECUTIVO MULTIFUNCIONAL'),(397,37,'EJECUTIVO DE KIOSCO'),(398,29,'ENCARGADO DE VERIFICACION'),(399,29,'AUXILIAR TARJETA DE CREDITO/DEBITO'),(400,29,'ANALISTA DE CREDITOS MAYORES'),(401,29,'AUXILIAR DE BACK OFFICE'),(402,29,'ENCARGADO DE TARJETA DE CREDITO/DEBITO'),(403,29,'DIGITADOR'),(404,29,'JEFE DE CREDITOS'),(405,29,'ENCARGADA DE ANALISIS DE CREDITOS'),(406,34,'GERENTE JURÍDICO'),(407,34,'JEFE DE ÁREA JURÍDICA'),(408,34,'ESPECIALISTA JURÍDICO'),(409,34,'ASISTENTE LEGAL');
/*!40000 ALTER TABLE `gen_puestos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_roles`
--

DROP TABLE IF EXISTS `gen_roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_roles` (
  `codgenroles` int(11) NOT NULL,
  `gen_rolesnombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_roles`
--

LOCK TABLES `gen_roles` WRITE;
/*!40000 ALTER TABLE `gen_roles` DISABLE KEYS */;
INSERT INTO `gen_roles` VALUES (1,'Administrador'),(2,'Usuario');
/*!40000 ALTER TABLE `gen_roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_sucursal`
--

DROP TABLE IF EXISTS `gen_sucursal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_sucursal` (
  `codgensucursal` int(11) NOT NULL,
  `gen_sucursalnombre` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`codgensucursal`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_sucursal`
--

LOCK TABLES `gen_sucursal` WRITE;
/*!40000 ALTER TABLE `gen_sucursal` DISABLE KEYS */;
INSERT INTO `gen_sucursal` VALUES (1,'GERENCIAS ADMINISTRATIVA'),(2,'GERENCIA DE NEGOCIOS'),(3,'GERENCIA JURIDICA'),(4,'CONSEJO DE ADMINISTRACIÓN'),(5,'GERENCIA FINANCIERA'),(6,'GERENCIA GENERAL');
/*!40000 ALTER TABLE `gen_sucursal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_tipoidentificacion`
--

DROP TABLE IF EXISTS `gen_tipoidentificacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_tipoidentificacion` (
  `codgentipoidentificacion` int(11) NOT NULL,
  `gen_tipoidentificacionnombre` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`codgentipoidentificacion`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_tipoidentificacion`
--

LOCK TABLES `gen_tipoidentificacion` WRITE;
/*!40000 ALTER TABLE `gen_tipoidentificacion` DISABLE KEYS */;
INSERT INTO `gen_tipoidentificacion` VALUES (1,'Dpi'),(2,'Visa');
/*!40000 ALTER TABLE `gen_tipoidentificacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_usuario`
--

DROP TABLE IF EXISTS `gen_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_usuario` (
  `codgenusuario` int(11) NOT NULL,
  `codgeninvequipo` int(11) DEFAULT NULL,
  `gen_usuarionombre` varchar(45) DEFAULT NULL,
  `gen_usuariocorreo` varchar(100) DEFAULT NULL,
  `gen_area_codgenarea` int(11) DEFAULT NULL,
  `gen_roles_codgenroles` int(11) DEFAULT NULL,
  PRIMARY KEY (`codgenusuario`),
  KEY `fk_gen_usuario_gen_invequipo_idx` (`codgeninvequipo`),
  KEY `fk_gen_usuario_gen_area1` (`gen_area_codgenarea`),
  KEY `fk_gen_usuario_gen_roles1` (`gen_roles_codgenroles`),
  CONSTRAINT `fk_gen_usuario_gen_area` FOREIGN KEY (`gen_area_codgenarea`) REFERENCES `gen_area` (`codgenarea`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_gen_usuario_gen_invequipo` FOREIGN KEY (`codgeninvequipo`) REFERENCES `gen_invequipo` (`codgeninvequipo`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_usuario`
--

LOCK TABLES `gen_usuario` WRITE;
/*!40000 ALTER TABLE `gen_usuario` DISABLE KEYS */;
INSERT INTO `gen_usuario` VALUES (1,1,'pggteo','jose.gonzalez@guadalupana.comgt',1,1),(2,1,'pgdgomez','diego.gomez@guadalupana.com.gt',1,1),(3,1,'pgaortiz','aida.ortiz@guadalupana.com.gt',1,2),(4,1,'pgecasasola','e.casasola@guadalupana.com.gt',39,3),(5,1,'pgmreyes','marlon.reyes@guadalupana.com.gt',1,1),(6,1,'pgachun','anibal.chun@guadalupana.com.gt',1,1),(7,1,'pggorellana','gerber.orellana@guadalupana.com.gt',39,1),(8,1,'pglalvarado','lester.alvarado@guadalupana.com.gt',39,2),(9,1,'pgggarcia','gerson.garcia@guadalupana.com.gt',22,1),(10,1,'pgjdelgado','dtbhrtf',1,1),(11,1,'pgalazaro','@guadapulana.com.gt',1,1),(12,1,'pgps2','@guadapulana.com.gt',1,1),(13,1,'pgcsagastume','@guadapulana.com.gt',1,1),(14,1,'pgcgodoy','@guadapulana.com.gt',1,1),(15,1,'pgharriola','@guadapulana.com.gt',1,1),(16,1,'pgksalazar','@guadapulana.com.gt',1,1),(17,1,'pgkrivera','@guadapulana.com.gt',1,1),(18,1,'pghcastillo','@guadapulana.com.gt',1,1),(19,1,'pgksalazar','@guadapulana.com.gt',1,1),(20,1,'pjherrera','@guadalupana.com.gt',1,1),(21,1,'pgjherrera','@guadapulana.com.gt',1,1);
/*!40000 ALTER TABLE `gen_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gen_zona`
--

DROP TABLE IF EXISTS `gen_zona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gen_zona` (
  `codgenzona` int(11) NOT NULL,
  `codgendepartamento` int(11) DEFAULT NULL,
  `gen_zonanombre` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`codgenzona`),
  KEY `fk_gen_zona_gen_departamento1_idx` (`codgendepartamento`),
  CONSTRAINT `fk_gen_zona_gen_departamento1` FOREIGN KEY (`codgendepartamento`) REFERENCES `gen_departamento` (`codgendepartamento`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='		';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gen_zona`
--

LOCK TABLES `gen_zona` WRITE;
/*!40000 ALTER TABLE `gen_zona` DISABLE KEYS */;
INSERT INTO `gen_zona` VALUES (1,1,'Zona 0'),(2,1,'Zona 1'),(3,1,'Zona 2'),(4,1,'Zona 3'),(5,1,'Zona 4'),(6,1,'Zona 5'),(7,1,'Zona 6'),(8,1,'Zona 7'),(9,1,'Zona 8'),(10,1,'Zona 9'),(11,1,'Zona 10'),(12,1,'Zona 11'),(13,1,'Zona 12'),(14,1,'Zona 13'),(15,1,'Zona 14'),(16,1,'Zona 15'),(17,1,'Zona 16'),(18,1,'Zona 17'),(19,1,'Zona 18'),(20,1,'Zona 19'),(21,1,'Zona 20'),(22,1,'Zona 21'),(23,1,'Zona 22'),(24,1,'Zona 23'),(25,1,'Zona 24'),(26,1,'Zona 25');
/*!40000 ALTER TABLE `gen_zona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gerencias`
--

DROP TABLE IF EXISTS `gerencias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `gerencias` (
  `﻿1` int(11) DEFAULT NULL,
  `GERENCIA ADMINISTRATIVA` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gerencias`
--

LOCK TABLES `gerencias` WRITE;
/*!40000 ALTER TABLE `gerencias` DISABLE KEYS */;
INSERT INTO `gerencias` VALUES (1,'GERENCIAS ADMINISTRATIVA'),(2,'GERENCIA DE NEGOCIOS'),(3,'GERENCIA JURIDICA'),(4,'CONSEJO DE ADMINISTRACIÓN'),(5,'GERENCIA FINANCIERA'),(6,'GERENCIA GENERAL');
/*!40000 ALTER TABLE `gerencias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `graficamontos`
--

DROP TABLE IF EXISTS `graficamontos`;
/*!50001 DROP VIEW IF EXISTS `graficamontos`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `graficamontos` AS SELECT 
 1 AS `resultado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `montodatos`
--

DROP TABLE IF EXISTS `montodatos`;
/*!50001 DROP VIEW IF EXISTS `montodatos`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `montodatos` AS SELECT 
 1 AS `codavtarea`,
 1 AS `av_titulo`,
 1 AS `av_estado`,
 1 AS `av_monto`,
 1 AS `fechaini`,
 1 AS `fechafin`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `montosview`
--

DROP TABLE IF EXISTS `montosview`;
/*!50001 DROP VIEW IF EXISTS `montosview`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `montosview` AS SELECT 
 1 AS `resultado`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `sa_agencia`
--

DROP TABLE IF EXISTS `sa_agencia`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_agencia` (
  `idsa_agencia` int(11) NOT NULL AUTO_INCREMENT,
  `sa_nombreagencia` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idsa_agencia`)
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_agencia`
--

LOCK TABLES `sa_agencia` WRITE;
/*!40000 ALTER TABLE `sa_agencia` DISABLE KEYS */;
INSERT INTO `sa_agencia` VALUES (1,'Central'),(2,'Zona 4'),(3,'Plaza Florida'),(4,'Portales'),(5,'Petapa'),(6,'Boca del Monte'),(7,'Gran Via'),(8,'San Lucas'),(9,'Bosques San Nicolas'),(10,'San Cristóbal'),(11,'Metrocentro'),(12,'Santa Catarina Pinula'),(13,'Metronorte'),(14,'Mega 6'),(15,'Monserrat (Kiosco)'),(16,'Pacific Villa'),(18,'Miraflores (Kiosco)'),(19,'Mixco'),(20,'Atanacio'),(21,'Alamos (Kiosco)'),(22,'Naranjo Mall'),(23,'Pradera zona 10 (Kiosco)'),(25,'Portales (Kiosco)'),(26,'Terminal');
/*!40000 ALTER TABLE `sa_agencia` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_billetes`
--

DROP TABLE IF EXISTS `sa_billetes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_billetes` (
  `idsa_billetes` int(11) NOT NULL AUTO_INCREMENT,
  `sa_valorbilletes` int(11) DEFAULT NULL,
  PRIMARY KEY (`idsa_billetes`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_billetes`
--

LOCK TABLES `sa_billetes` WRITE;
/*!40000 ALTER TABLE `sa_billetes` DISABLE KEYS */;
INSERT INTO `sa_billetes` VALUES (1,200),(2,100),(3,50),(4,20),(5,10),(6,5),(7,1);
/*!40000 ALTER TABLE `sa_billetes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_chequescajero`
--

DROP TABLE IF EXISTS `sa_chequescajero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_chequescajero` (
  `idsa_chequescajero` int(11) NOT NULL AUTO_INCREMENT,
  `idsa_tipocheque` int(11) DEFAULT NULL,
  `idsa_tipomoneda` int(11) DEFAULT NULL,
  `sa_cantidadcheques` int(11) DEFAULT NULL,
  `sa_montocheques` decimal(10,2) DEFAULT NULL,
  `sa_totaldolares` decimal(10,2) DEFAULT NULL,
  `sa_totalquetzales` decimal(10,2) DEFAULT NULL,
  `sa_bolutilizadas` varchar(50) DEFAULT NULL,
  `sa_bolreservadas` varchar(50) DEFAULT NULL,
  `sa_bolanuladas` varchar(50) DEFAULT NULL,
  `idsa_encabezadocajero` int(11) DEFAULT NULL,
  PRIMARY KEY (`idsa_chequescajero`),
  KEY `sa_tipocheque_idx` (`idsa_tipocheque`),
  KEY `sa_tipomoneda_idx` (`idsa_tipomoneda`),
  KEY `sa_encabezadocajero_idx` (`idsa_encabezadocajero`),
  CONSTRAINT `sa_encabezadocajero` FOREIGN KEY (`idsa_encabezadocajero`) REFERENCES `sa_encabezadocajero` (`idsa_encabezadocajero`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `sa_tipocheque` FOREIGN KEY (`idsa_tipocheque`) REFERENCES `sa_tipocheque` (`idsa_tipocheque`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `sa_tipomoneda` FOREIGN KEY (`idsa_tipomoneda`) REFERENCES `sa_tipomoneda` (`idsa_tipomoneda`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_chequescajero`
--

LOCK TABLES `sa_chequescajero` WRITE;
/*!40000 ALTER TABLE `sa_chequescajero` DISABLE KEYS */;
INSERT INTO `sa_chequescajero` VALUES (1,1,1,1,50.00,0.00,200.00,'A1-A3','1','1',1),(2,1,2,1,100.00,0.00,300.00,'A1-A3','1','1',1),(3,2,1,1,150.00,0.00,200.00,'A1-A3','1','1',1),(4,2,2,1,200.00,0.00,300.00,'A1-A3','1','1',1),(5,1,1,2,300.00,50.00,300.00,'A1-A3','1','1',2),(6,1,2,1,50.00,50.00,300.00,'A1-A3','1','1',2),(7,2,1,0,0.00,50.00,300.00,'A1-A3','1','1',2),(8,2,2,0,0.00,50.00,300.00,'A1-A3','1','1',2),(9,1,1,0,0.00,600.00,550.00,'A1-A3','A5','A7',3),(10,1,2,0,0.00,600.00,600.00,'A1-A3','A5','A7',3),(11,2,1,2,550.00,600.00,550.00,'A1-A3','A5','A7',3),(12,2,2,2,600.00,600.00,600.00,'A1-A3','A5','A7',3),(13,1,1,1,50.00,0.00,150.00,'A1-A3','A5','A7',4),(14,1,2,0,0.00,0.00,0.00,'A1-A3','A5','A7',4),(15,2,1,1,100.00,0.00,150.00,'A1-A3','A5','A7',4),(16,2,2,0,0.00,0.00,0.00,'A1-A3','A5','A7',4),(17,1,1,2,500.00,250.00,500.00,'A1-A3','A5','A7',5),(18,1,2,2,250.00,250.00,250.00,'A1-A3','A5','A7',5),(19,2,1,0,0.00,250.00,500.00,'A1-A3','A5','A7',5),(20,2,2,0,0.00,250.00,250.00,'A1-A3','A5','A7',5),(21,1,1,1,300.00,150.00,300.00,'A1-A3','A5','A7',6),(22,1,2,1,150.00,150.00,150.00,'A1-A3','A5','A7',6),(23,2,1,0,0.00,150.00,300.00,'A1-A3','A5','A7',6),(24,2,2,0,0.00,150.00,150.00,'A1-A3','A5','A7',6);
/*!40000 ALTER TABLE `sa_chequescajero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_chequestesoreria`
--

DROP TABLE IF EXISTS `sa_chequestesoreria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_chequestesoreria` (
  `idsa_chequestesoreria` int(11) NOT NULL AUTO_INCREMENT,
  `idsa_tipocheque` int(11) DEFAULT NULL,
  `idsa_tipomoneda` int(11) DEFAULT NULL,
  `sa_cantidadcheques` int(11) DEFAULT NULL,
  `sa_montocheques` decimal(10,2) DEFAULT NULL,
  `sa_totalcheques` int(11) DEFAULT NULL,
  `sa_totalmonto` decimal(10,2) DEFAULT NULL,
  `idsa_encabezadotesoreria` int(11) DEFAULT NULL,
  PRIMARY KEY (`idsa_chequestesoreria`),
  KEY `sa_tipocheque2_idx` (`idsa_tipocheque`),
  KEY `sa_tipomoneda2_idx` (`idsa_tipomoneda`),
  KEY `idsa_encabezadotesoreria_idx` (`idsa_encabezadotesoreria`),
  CONSTRAINT `idsa_encabezadotesoreria` FOREIGN KEY (`idsa_encabezadotesoreria`) REFERENCES `sa_encabezadotesoreria` (`idsa_encabezadotesoreria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `sa_tipocheque2` FOREIGN KEY (`idsa_tipocheque`) REFERENCES `sa_tipocheque` (`idsa_tipocheque`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `sa_tipomoneda2` FOREIGN KEY (`idsa_tipomoneda`) REFERENCES `sa_tipomoneda` (`idsa_tipomoneda`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_chequestesoreria`
--

LOCK TABLES `sa_chequestesoreria` WRITE;
/*!40000 ALTER TABLE `sa_chequestesoreria` DISABLE KEYS */;
INSERT INTO `sa_chequestesoreria` VALUES (1,1,1,2,600.00,2,600.00,1),(2,2,1,0,0.00,2,600.00,1),(3,1,2,0,0.00,2,150.00,1),(4,2,2,2,150.00,2,150.00,1),(5,1,1,1,350.00,1,350.00,2),(6,2,1,0,0.00,1,350.00,2),(7,1,2,0,0.00,1,400.00,2),(8,2,2,1,400.00,1,400.00,2),(9,1,1,1,100.00,1,100.00,3),(10,2,1,0,0.00,1,100.00,3),(11,1,2,0,0.00,1,150.00,3),(12,2,2,1,150.00,1,150.00,3),(13,1,1,1,500.00,1,500.00,4),(14,2,1,0,0.00,1,500.00,4),(15,1,1,1,220.00,1,220.00,5),(16,2,1,0,0.00,1,220.00,5),(17,1,2,0,0.00,1,230.00,5),(18,2,2,1,230.00,1,230.00,5);
/*!40000 ALTER TABLE `sa_chequestesoreria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_control_ingreso`
--

DROP TABLE IF EXISTS `sa_control_ingreso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_control_ingreso` (
  `cod_controlingreso` int(11) NOT NULL AUTO_INCREMENT,
  `cod_genusuario` int(11) DEFAULT NULL,
  `cod_puesto` int(11) DEFAULT NULL,
  PRIMARY KEY (`cod_controlingreso`),
  KEY `cod_genusuario_idx` (`cod_genusuario`),
  KEY `cod_puesto_idx` (`cod_puesto`),
  CONSTRAINT `cod_genusuario` FOREIGN KEY (`cod_genusuario`) REFERENCES `gen_usuario` (`codgenusuario`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `cod_puesto` FOREIGN KEY (`cod_puesto`) REFERENCES `sa_puesto` (`idsa_puesto`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_control_ingreso`
--

LOCK TABLES `sa_control_ingreso` WRITE;
/*!40000 ALTER TABLE `sa_control_ingreso` DISABLE KEYS */;
INSERT INTO `sa_control_ingreso` VALUES (1,3,2),(2,1,1),(3,2,1),(4,9,1);
/*!40000 ALTER TABLE `sa_control_ingreso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_cuadrecajachica`
--

DROP TABLE IF EXISTS `sa_cuadrecajachica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_cuadrecajachica` (
  `idsa_cuadrecajachica` int(11) NOT NULL,
  `idsa_billetes` int(11) DEFAULT NULL,
  `sa_cantidadbilletes` int(11) DEFAULT NULL,
  `sa_subtotalbilletes` decimal(10,2) DEFAULT NULL,
  `sa_totalbilletes` decimal(10,2) DEFAULT NULL,
  `idsa_monedas` int(11) DEFAULT NULL,
  `sa_cantidadmonedas` int(11) DEFAULT NULL,
  `sa_subtotalmonedas` decimal(10,2) DEFAULT NULL,
  `sa_totalmonedas` decimal(10,2) DEFAULT NULL,
  `sa_totalefectivo` decimal(10,2) DEFAULT NULL,
  `sa_totalcajachica` decimal(10,2) DEFAULT NULL,
  `sa_comentario` varchar(50) DEFAULT NULL,
  `idsa_encabezadocajachica` int(11) DEFAULT NULL,
  PRIMARY KEY (`idsa_cuadrecajachica`),
  KEY `idsa_billetes7_idx` (`idsa_billetes`),
  KEY `idsa_monedas7_idx` (`idsa_monedas`),
  KEY `idsa_encabezadocajachica3_idx` (`idsa_encabezadocajachica`),
  CONSTRAINT `idsa_billetes7` FOREIGN KEY (`idsa_billetes`) REFERENCES `sa_billetes` (`idsa_billetes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idsa_encabezadocajachica3` FOREIGN KEY (`idsa_encabezadocajachica`) REFERENCES `sa_encabezadocajachica` (`idsa_encabezadocajachica`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idsa_monedas7` FOREIGN KEY (`idsa_monedas`) REFERENCES `sa_monedas` (`idsa_monedas`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_cuadrecajachica`
--

LOCK TABLES `sa_cuadrecajachica` WRITE;
/*!40000 ALTER TABLE `sa_cuadrecajachica` DISABLE KEYS */;
INSERT INTO `sa_cuadrecajachica` VALUES (1,1,2,400.00,550.00,1,0,0.00,0.00,550.00,700.00,'Arqueo caja chica',1),(2,2,1,100.00,550.00,2,0,0.00,0.00,550.00,700.00,'Arqueo caja chica',1),(3,3,0,0.00,550.00,3,0,0.00,0.00,550.00,700.00,'Arqueo caja chica',1),(4,4,0,0.00,550.00,4,0,0.00,0.00,550.00,700.00,'Arqueo caja chica',1),(5,5,5,50.00,550.00,5,0,0.00,0.00,550.00,700.00,'Arqueo caja chica',1),(6,6,0,0.00,550.00,6,0,0.00,0.00,550.00,700.00,'Arqueo caja chica',1),(7,7,0,0.00,550.00,8,0,0.00,0.00,550.00,700.00,'Arqueo caja chica',1),(8,1,1,200.00,400.00,1,0,0.00,0.00,400.00,500.00,'Arqueo caja chica',2),(9,2,1,100.00,400.00,2,0,0.00,0.00,400.00,500.00,'Arqueo caja chica',2),(10,3,2,100.00,400.00,3,0,0.00,0.00,400.00,500.00,'Arqueo caja chica',2),(11,4,0,0.00,400.00,4,0,0.00,0.00,400.00,500.00,'Arqueo caja chica',2),(12,5,0,0.00,400.00,5,0,0.00,0.00,400.00,500.00,'Arqueo caja chica',2),(13,6,0,0.00,400.00,6,0,0.00,0.00,400.00,500.00,'Arqueo caja chica',2),(14,7,0,0.00,400.00,8,0,0.00,0.00,400.00,500.00,'Arqueo caja chica',2),(15,1,1,200.00,600.00,1,0,0.00,0.00,600.00,700.00,'Arqueo caja chica',4),(16,2,3,300.00,600.00,2,0,0.00,0.00,600.00,700.00,'Arqueo caja chica',4),(17,3,2,100.00,600.00,3,0,0.00,0.00,600.00,700.00,'Arqueo caja chica',4),(18,4,0,0.00,600.00,4,0,0.00,0.00,600.00,700.00,'Arqueo caja chica',4),(19,5,0,0.00,600.00,5,0,0.00,0.00,600.00,700.00,'Arqueo caja chica',4),(20,6,0,0.00,600.00,6,0,0.00,0.00,600.00,700.00,'Arqueo caja chica',4),(21,7,0,0.00,600.00,8,0,0.00,0.00,600.00,700.00,'Arqueo caja chica',4),(22,1,1,200.00,300.00,1,0,0.00,0.00,300.00,400.00,'Arqueo caja chica',5),(23,2,1,100.00,300.00,2,0,0.00,0.00,300.00,400.00,'Arqueo caja chica',5),(24,3,0,0.00,300.00,3,0,0.00,0.00,300.00,400.00,'Arqueo caja chica',5),(25,4,0,0.00,300.00,4,0,0.00,0.00,300.00,400.00,'Arqueo caja chica',5),(26,5,0,0.00,300.00,5,0,0.00,0.00,300.00,400.00,'Arqueo caja chica',5),(27,6,0,0.00,300.00,6,0,0.00,0.00,300.00,400.00,'Arqueo caja chica',5),(28,7,0,0.00,300.00,8,0,0.00,0.00,300.00,400.00,'Arqueo caja chica',5),(29,1,1,200.00,350.00,1,0,0.00,0.00,350.00,500.00,'Arqueo caja chica',6),(30,2,1,100.00,350.00,2,0,0.00,0.00,350.00,500.00,'Arqueo caja chica',6),(31,3,1,50.00,350.00,3,0,0.00,0.00,350.00,500.00,'Arqueo caja chica',6),(32,4,0,0.00,350.00,4,0,0.00,0.00,350.00,500.00,'Arqueo caja chica',6),(33,5,0,0.00,350.00,5,0,0.00,0.00,350.00,500.00,'Arqueo caja chica',6),(34,6,0,0.00,350.00,6,0,0.00,0.00,350.00,500.00,'Arqueo caja chica',6),(35,7,0,0.00,350.00,8,0,0.00,0.00,350.00,500.00,'Arqueo caja chica',6);
/*!40000 ALTER TABLE `sa_cuadrecajachica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_detallecajachica`
--

DROP TABLE IF EXISTS `sa_detallecajachica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_detallecajachica` (
  `idsa_detallecajachica` int(11) NOT NULL AUTO_INCREMENT,
  `sa_fecha` date DEFAULT NULL,
  `sa_numdocumento` int(11) DEFAULT NULL,
  `sa_proveedor` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `sa_descripcion` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `sa_debe` decimal(10,2) DEFAULT NULL,
  `sa_haber` decimal(10,2) DEFAULT NULL,
  `idsa_encabezadocajachica` int(11) DEFAULT NULL,
  PRIMARY KEY (`idsa_detallecajachica`),
  KEY `idsa_encabezadocajachica2_idx` (`idsa_encabezadocajachica`),
  CONSTRAINT `idsa_encabezadocajachica2` FOREIGN KEY (`idsa_encabezadocajachica`) REFERENCES `sa_encabezadocajachica` (`idsa_encabezadocajachica`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_detallecajachica`
--

LOCK TABLES `sa_detallecajachica` WRITE;
/*!40000 ALTER TABLE `sa_detallecajachica` DISABLE KEYS */;
INSERT INTO `sa_detallecajachica` VALUES (1,'2021-02-15',455,'Wallmart S.A.','Insumos de limpieza',0.00,50.00,1),(2,'2021-02-13',456,'Bebidas Preparadas','Agua Pura',0.00,100.00,1),(3,'2021-02-10',135,'Bebidas Preparadas','Agua',0.00,100.00,2),(4,'2021-02-12',136,'Wallmart S.A.','Desinfectante',0.00,150.00,2),(5,'2021-03-01',123,'Bebidas Preparadas','Agua',0.00,100.00,3),(6,'2021-03-01',123,'La Torre S.A.','Insumos de limpieza',0.00,50.00,3),(7,'2021-02-27',123,'La Torre S.A.','Insumos de limpieza',0.00,100.00,4),(8,'2021-03-01',345,'La Torre S.A.','Insumos de limpieza',0.00,100.00,5),(9,'2021-03-01',257,'Bebidas Preparadas','Agua Pura',0.00,50.00,6),(10,'2021-03-01',876,'Wallmart S.A.','Alcohol en Gel',0.00,100.00,6);
/*!40000 ALTER TABLE `sa_detallecajachica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_detallecajero`
--

DROP TABLE IF EXISTS `sa_detallecajero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_detallecajero` (
  `idsa_detallecajero` int(11) NOT NULL AUTO_INCREMENT,
  `idsa_billetes` int(11) DEFAULT NULL,
  `sa_cantidadbilletes` int(11) DEFAULT NULL,
  `sa_totalbilletes` decimal(10,2) DEFAULT NULL,
  `idsa_monedas` int(11) DEFAULT NULL,
  `sa_cantidadmonedas` int(11) DEFAULT NULL,
  `sa_totalmonedas` decimal(10,2) DEFAULT NULL,
  `sa_totalcierre` decimal(10,2) DEFAULT NULL,
  `sa_totalrecibido` decimal(10,2) DEFAULT NULL,
  `sa_totalentregado` decimal(10,2) DEFAULT NULL,
  `idsa_encabezadocajero` int(11) DEFAULT NULL,
  PRIMARY KEY (`idsa_detallecajero`),
  KEY `idsa_billetes2_idx` (`idsa_billetes`),
  KEY `idsa_monedas2_idx` (`idsa_monedas`),
  KEY `idsa_encabezadocajero2_idx` (`idsa_encabezadocajero`),
  CONSTRAINT `idsa_billetes2` FOREIGN KEY (`idsa_billetes`) REFERENCES `sa_billetes` (`idsa_billetes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idsa_encabezadocajero2` FOREIGN KEY (`idsa_encabezadocajero`) REFERENCES `sa_encabezadocajero` (`idsa_encabezadocajero`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idsa_monedas2` FOREIGN KEY (`idsa_monedas`) REFERENCES `sa_monedas` (`idsa_monedas`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_detallecajero`
--

LOCK TABLES `sa_detallecajero` WRITE;
/*!40000 ALTER TABLE `sa_detallecajero` DISABLE KEYS */;
INSERT INTO `sa_detallecajero` VALUES (1,1,2,400.00,1,0,0.00,523.22,100.00,100.00,1),(2,2,0,0.00,2,2,1.00,523.22,100.00,100.00,1),(3,3,2,100.00,3,0,0.00,523.22,100.00,100.00,1),(4,4,0,0.00,4,2,0.20,523.22,100.00,100.00,1),(5,5,2,20.00,5,0,0.00,523.22,100.00,100.00,1),(6,6,0,0.00,6,2,0.02,523.22,100.00,100.00,1),(7,7,2,2.00,8,0,0.00,523.22,100.00,100.00,1),(8,1,1,200.00,1,0,0.00,221.61,30.00,30.00,2),(9,2,0,0.00,2,1,0.50,221.61,30.00,30.00,2),(10,3,0,0.00,3,0,0.00,221.61,30.00,30.00,2),(11,4,1,20.00,4,1,0.10,221.61,30.00,30.00,2),(12,5,0,0.00,5,0,0.00,221.61,30.00,30.00,2),(13,6,0,0.00,6,1,0.01,221.61,30.00,30.00,2),(14,7,1,1.00,8,0,0.00,221.61,30.00,30.00,2),(15,1,2,400.00,1,0,0.00,523.22,100.00,100.00,3),(16,2,0,0.00,2,2,1.00,523.22,100.00,100.00,3),(17,3,2,100.00,3,0,0.00,523.22,100.00,100.00,3),(18,4,0,0.00,4,2,0.20,523.22,100.00,100.00,3),(19,5,2,20.00,5,0,0.00,523.22,100.00,100.00,3),(20,6,0,0.00,6,2,0.02,523.22,100.00,100.00,3),(21,7,2,2.00,8,0,0.00,523.22,100.00,100.00,3),(22,1,1,200.00,1,1,1.00,211.26,100.00,100.00,4),(23,2,0,0.00,2,0,0.00,211.26,100.00,100.00,4),(24,3,0,0.00,3,1,0.25,211.26,100.00,100.00,4),(25,4,0,0.00,4,0,0.00,211.26,100.00,100.00,4),(26,5,1,10.00,5,0,0.00,211.26,100.00,100.00,4),(27,6,0,0.00,6,1,0.01,211.26,100.00,100.00,4),(28,7,0,0.00,8,0,0.00,211.26,100.00,100.00,4),(29,1,1,200.00,1,0,0.00,261.00,230.00,230.00,5),(30,2,0,0.00,2,0,0.00,261.00,230.00,230.00,5),(31,3,1,50.00,3,0,0.00,261.00,230.00,230.00,5),(32,4,0,0.00,4,0,0.00,261.00,230.00,230.00,5),(33,5,1,10.00,5,0,0.00,261.00,230.00,230.00,5),(34,6,0,0.00,6,0,0.00,261.00,230.00,230.00,5),(35,7,1,1.00,8,0,0.00,261.00,230.00,230.00,5),(36,1,2,400.00,1,0,0.00,522.00,500.00,500.00,6),(37,2,0,0.00,2,0,0.00,522.00,500.00,500.00,6),(38,3,2,100.00,3,0,0.00,522.00,500.00,500.00,6),(39,4,0,0.00,4,0,0.00,522.00,500.00,500.00,6),(40,5,2,20.00,5,0,0.00,522.00,500.00,500.00,6),(41,6,0,0.00,6,0,0.00,522.00,500.00,500.00,6),(42,7,2,2.00,8,0,0.00,522.00,500.00,500.00,6);
/*!40000 ALTER TABLE `sa_detallecajero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_detallecajeroaut`
--

DROP TABLE IF EXISTS `sa_detallecajeroaut`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_detallecajeroaut` (
  `idsa_detallecajeroaut` int(11) NOT NULL AUTO_INCREMENT,
  `idsa_billetes` int(11) DEFAULT NULL,
  `sa_cantidadbilletes` int(11) DEFAULT NULL,
  `sa_subtotalbilletes` decimal(10,2) DEFAULT NULL,
  `sa_totalbilletes` decimal(10,2) DEFAULT NULL,
  `idsa_monedas` int(11) DEFAULT NULL,
  `sa_cantidadmonedas` int(11) DEFAULT NULL,
  `sa_subtotalmonedas` decimal(10,2) DEFAULT NULL,
  `sa_totalmonedas` decimal(10,2) DEFAULT NULL,
  `sa_totalefectivo` decimal(10,2) DEFAULT NULL,
  `sa_efectivoreporte` decimal(10,2) DEFAULT NULL,
  `sa_diferencia` decimal(10,2) DEFAULT NULL,
  `sa_observaciones` varchar(50) DEFAULT NULL,
  `idsa_encabezadocajeroaut` int(11) DEFAULT NULL,
  PRIMARY KEY (`idsa_detallecajeroaut`),
  KEY `idsa_billetes3_idx` (`idsa_billetes`),
  KEY `idsa_monedas3_idx` (`idsa_monedas`),
  KEY `idsa_encabezadocajeroaut2_idx` (`idsa_encabezadocajeroaut`),
  CONSTRAINT `idsa_billetes3` FOREIGN KEY (`idsa_billetes`) REFERENCES `sa_billetes` (`idsa_billetes`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idsa_encabezadocajeroaut2` FOREIGN KEY (`idsa_encabezadocajeroaut`) REFERENCES `sa_encabezadocajeroaut` (`idsa_encabezadocajeroaut`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `idsa_monedas3` FOREIGN KEY (`idsa_monedas`) REFERENCES `sa_monedas` (`idsa_monedas`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=50 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_detallecajeroaut`
--

LOCK TABLES `sa_detallecajeroaut` WRITE;
/*!40000 ALTER TABLE `sa_detallecajeroaut` DISABLE KEYS */;
INSERT INTO `sa_detallecajeroaut` VALUES (1,1,1,200.00,221.00,1,0,0.00,0.55,221.55,30.00,191.55,'arqueo',1),(2,2,0,0.00,221.00,2,1,0.50,0.55,221.55,30.00,191.55,'arqueo',1),(3,3,0,0.00,221.00,3,0,0.00,0.55,221.55,30.00,191.55,'arqueo',1),(4,4,1,20.00,221.00,4,0,0.00,0.55,221.55,30.00,191.55,'arqueo',1),(5,5,0,0.00,221.00,5,1,0.05,0.55,221.55,30.00,191.55,'arqueo',1),(6,6,0,0.00,221.00,6,0,0.05,0.55,221.55,30.00,191.55,'arqueo',1),(7,7,1,1.00,221.00,8,0,0.00,0.55,221.55,30.00,191.55,'arqueo',1),(8,1,2,400.00,522.00,1,0,0.00,1.22,523.22,50.00,473.22,'arqueo',2),(9,2,0,0.00,522.00,2,2,1.00,1.22,523.22,50.00,473.22,'arqueo',2),(10,3,2,100.00,522.00,3,0,0.00,1.22,523.22,50.00,473.22,'arqueo',2),(11,4,0,0.00,522.00,4,2,0.20,1.22,523.22,50.00,473.22,'arqueo',2),(12,5,2,20.00,522.00,5,0,0.00,1.22,523.22,50.00,473.22,'arqueo',2),(13,6,0,0.00,522.00,6,2,0.00,1.22,523.22,50.00,473.22,'arqueo',2),(14,7,2,2.00,522.00,8,0,0.00,1.22,523.22,50.00,473.22,'arqueo',2),(15,1,2,400.00,522.00,1,1,1.00,1.91,523.91,30.00,493.91,'arqueo cajero automatico',3),(16,2,0,0.00,522.00,2,1,0.50,1.91,523.91,30.00,493.91,'arqueo cajero automatico',3),(17,3,2,100.00,522.00,3,1,0.25,1.91,523.91,30.00,493.91,'arqueo cajero automatico',3),(18,4,0,0.00,522.00,4,1,0.10,1.91,523.91,30.00,493.91,'arqueo cajero automatico',3),(19,5,2,20.00,522.00,5,1,0.05,1.91,523.91,30.00,493.91,'arqueo cajero automatico',3),(20,6,0,0.00,522.00,6,1,0.05,1.91,523.91,30.00,493.91,'arqueo cajero automatico',3),(21,7,2,2.00,522.00,8,0,0.00,1.91,523.91,30.00,493.91,'arqueo cajero automatico',3),(22,1,3,600.00,960.00,1,0,0.00,0.00,960.00,200.00,760.00,'arqueo',4),(23,2,3,300.00,960.00,2,0,0.00,0.00,960.00,200.00,760.00,'arqueo',4),(24,3,0,0.00,960.00,3,0,0.00,0.00,960.00,200.00,760.00,'arqueo',4),(25,4,3,60.00,960.00,4,0,0.00,0.00,960.00,200.00,760.00,'arqueo',4),(26,5,0,0.00,960.00,5,0,0.00,0.00,960.00,200.00,760.00,'arqueo',4),(27,6,0,0.00,960.00,6,0,0.00,0.00,960.00,200.00,760.00,'arqueo',4),(28,7,0,0.00,960.00,8,0,0.00,0.00,960.00,200.00,760.00,'arqueo',4),(29,1,1,200.00,261.00,1,0,0.00,0.00,261.00,100.00,161.00,'arqueo cajero automatico',5),(30,2,0,0.00,261.00,2,0,0.00,0.00,261.00,100.00,161.00,'arqueo cajero automatico',5),(31,3,1,50.00,261.00,3,0,0.00,0.00,261.00,100.00,161.00,'arqueo cajero automatico',5),(32,4,0,0.00,261.00,4,0,0.00,0.00,261.00,100.00,161.00,'arqueo cajero automatico',5),(33,5,1,10.00,261.00,5,0,0.00,0.00,261.00,100.00,161.00,'arqueo cajero automatico',5),(34,6,0,0.00,261.00,6,0,0.00,0.00,261.00,100.00,161.00,'arqueo cajero automatico',5),(35,7,1,1.00,261.00,8,0,0.00,0.00,261.00,100.00,161.00,'arqueo cajero automatico',5),(36,1,2,400.00,522.00,1,0,0.00,0.00,522.00,50.00,472.00,'arqueo cajero automatico',6),(37,2,0,0.00,522.00,2,0,0.00,0.00,522.00,50.00,472.00,'arqueo cajero automatico',6),(38,3,2,100.00,522.00,3,0,0.00,0.00,522.00,50.00,472.00,'arqueo cajero automatico',6),(39,4,0,0.00,522.00,4,0,0.00,0.00,522.00,50.00,472.00,'arqueo cajero automatico',6),(40,5,2,20.00,522.00,5,0,0.00,0.00,522.00,50.00,472.00,'arqueo cajero automatico',6),(41,6,0,0.00,522.00,6,0,0.00,0.00,522.00,50.00,472.00,'arqueo cajero automatico',6),(42,7,2,2.00,522.00,8,0,0.00,0.00,522.00,50.00,472.00,'arqueo cajero automatico',6),(43,1,1,200.00,312.00,1,0,0.00,0.00,312.00,120.00,192.00,'arqueo cajero automatico',7),(44,2,0,0.00,312.00,2,0,0.00,0.00,312.00,120.00,192.00,'arqueo cajero automatico',7),(45,3,2,100.00,312.00,3,0,0.00,0.00,312.00,120.00,192.00,'arqueo cajero automatico',7),(46,4,0,0.00,312.00,4,0,0.00,0.00,312.00,120.00,192.00,'arqueo cajero automatico',7),(47,5,1,10.00,312.00,5,0,0.00,0.00,312.00,120.00,192.00,'arqueo cajero automatico',7),(48,6,0,0.00,312.00,6,0,0.00,0.00,312.00,120.00,192.00,'arqueo cajero automatico',7),(49,7,2,2.00,312.00,8,0,0.00,0.00,312.00,120.00,192.00,'arqueo cajero automatico',7);
/*!40000 ALTER TABLE `sa_detallecajeroaut` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_detalletesoreria`
--

DROP TABLE IF EXISTS `sa_detalletesoreria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_detalletesoreria` (
  `idsa_detalletesoreria` int(11) NOT NULL AUTO_INCREMENT,
  `sa_tipomoneda` int(11) DEFAULT NULL,
  `idsa_billetes` int(11) DEFAULT NULL,
  `sa_cantidadbilletes` int(11) DEFAULT NULL,
  `sa_subtotalbilletes` decimal(10,2) DEFAULT NULL,
  `sa_totalbilletes` decimal(10,2) DEFAULT NULL,
  `idsa_monedas` int(11) DEFAULT NULL,
  `sa_cantidadmonedas` int(11) DEFAULT NULL,
  `sa_subtotalmonedas` decimal(10,2) DEFAULT NULL,
  `sa_totalmonedas` decimal(10,2) DEFAULT NULL,
  `sa_totalefectivo` decimal(10,2) DEFAULT NULL,
  `sa_solicitud` decimal(10,2) DEFAULT NULL,
  `sa_efectivoentregado` decimal(10,2) DEFAULT NULL,
  `sa_totalfondo` decimal(10,2) DEFAULT NULL,
  `sa_remesapendiente` decimal(10,2) DEFAULT NULL,
  `sa_deposito` decimal(10,2) DEFAULT NULL,
  `idsa_encabezadotesoreria` int(11) DEFAULT NULL,
  PRIMARY KEY (`idsa_detalletesoreria`),
  KEY `sa_tipomoneda4_idx` (`sa_tipomoneda`),
  KEY `idsa_encabezadotesoreria5_idx` (`idsa_encabezadotesoreria`),
  CONSTRAINT `idsa_encabezadotesoreria5` FOREIGN KEY (`idsa_encabezadotesoreria`) REFERENCES `sa_encabezadotesoreria` (`idsa_encabezadotesoreria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `sa_tipomoneda4` FOREIGN KEY (`sa_tipomoneda`) REFERENCES `sa_tipomoneda` (`idsa_tipomoneda`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=64 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_detalletesoreria`
--

LOCK TABLES `sa_detalletesoreria` WRITE;
/*!40000 ALTER TABLE `sa_detalletesoreria` DISABLE KEYS */;
INSERT INTO `sa_detalletesoreria` VALUES (1,1,1,3,600.00,675.00,1,0,0.00,1.65,676.65,50.00,50.00,776.65,0.00,0.00,1),(2,1,2,0,0.00,675.00,2,3,1.50,1.65,676.65,50.00,50.00,776.65,0.00,0.00,1),(3,1,3,0,0.00,675.00,3,0,0.00,1.65,676.65,50.00,50.00,776.65,0.00,0.00,1),(4,1,4,3,60.00,675.00,4,0,0.00,1.65,676.65,50.00,50.00,776.65,0.00,0.00,1),(5,1,5,0,0.00,675.00,5,3,0.15,1.65,676.65,50.00,50.00,776.65,0.00,0.00,1),(6,1,6,3,15.00,675.00,6,0,0.00,1.65,676.65,50.00,50.00,776.65,0.00,0.00,1),(7,1,7,0,0.00,675.00,8,0,0.00,1.65,676.65,50.00,50.00,776.65,0.00,0.00,1),(8,2,1,2,400.00,450.00,1,2,2.00,2.60,452.60,0.00,0.00,0.00,0.00,452.60,1),(9,2,2,0,0.00,450.00,2,0,0.00,2.60,452.60,0.00,0.00,0.00,0.00,452.60,1),(10,2,3,0,0.00,450.00,3,2,0.50,2.60,452.60,0.00,0.00,0.00,0.00,452.60,1),(11,2,4,2,40.00,450.00,4,0,0.00,2.60,452.60,0.00,0.00,0.00,0.00,452.60,1),(12,2,5,0,0.00,450.00,5,2,0.10,2.60,452.60,0.00,0.00,0.00,0.00,452.60,1),(13,2,6,2,10.00,450.00,6,0,0.00,2.60,452.60,0.00,0.00,0.00,0.00,452.60,1),(14,2,7,0,0.00,450.00,8,0,0.00,2.60,452.60,0.00,0.00,0.00,0.00,452.60,1),(15,1,1,3,600.00,783.00,1,0,0.00,1.83,784.83,100.00,100.00,984.83,0.00,0.00,2),(16,1,2,0,0.00,783.00,2,3,1.50,1.83,784.83,100.00,100.00,984.83,0.00,0.00,2),(17,1,3,3,150.00,783.00,3,0,0.00,1.83,784.83,100.00,100.00,984.83,0.00,0.00,2),(18,1,4,0,0.00,783.00,4,3,0.30,1.83,784.83,100.00,100.00,984.83,0.00,0.00,2),(19,1,5,3,30.00,783.00,5,0,0.00,1.83,784.83,100.00,100.00,984.83,0.00,0.00,2),(20,1,6,0,0.00,783.00,6,3,0.03,1.83,784.83,100.00,100.00,984.83,0.00,0.00,2),(21,1,7,3,3.00,783.00,8,0,0.00,1.83,784.83,100.00,100.00,984.83,0.00,0.00,2),(22,2,1,3,600.00,783.00,1,0,0.00,1.83,784.83,0.00,0.00,0.00,100.00,884.83,2),(23,2,2,0,0.00,783.00,2,3,1.50,1.83,784.83,0.00,0.00,0.00,100.00,884.83,2),(24,2,3,3,150.00,783.00,3,0,0.00,1.83,784.83,0.00,0.00,0.00,100.00,884.83,2),(25,2,4,0,0.00,783.00,4,3,0.30,1.83,784.83,0.00,0.00,0.00,100.00,884.83,2),(26,2,5,3,30.00,783.00,5,0,0.00,1.83,784.83,0.00,0.00,0.00,100.00,884.83,2),(27,2,6,0,0.00,783.00,6,3,0.03,1.83,784.83,0.00,0.00,0.00,100.00,884.83,2),(28,2,7,3,3.00,783.00,8,0,0.00,1.83,784.83,0.00,0.00,0.00,100.00,884.83,2),(29,1,1,1,200.00,386.00,1,0,0.00,0.00,386.00,30.00,30.00,446.00,0.00,0.00,3),(30,1,2,1,100.00,386.00,2,0,0.00,0.00,386.00,30.00,30.00,446.00,0.00,0.00,3),(31,1,3,1,50.00,386.00,3,0,0.00,0.00,386.00,30.00,30.00,446.00,0.00,0.00,3),(32,1,4,1,20.00,386.00,4,0,0.00,0.00,386.00,30.00,30.00,446.00,0.00,0.00,3),(33,1,5,1,10.00,386.00,5,0,0.00,0.00,386.00,30.00,30.00,446.00,0.00,0.00,3),(34,1,6,1,5.00,386.00,6,0,0.00,0.00,386.00,30.00,30.00,446.00,0.00,0.00,3),(35,1,7,1,1.00,386.00,8,0,0.00,0.00,386.00,30.00,30.00,446.00,0.00,0.00,3),(36,2,1,1,200.00,261.00,1,0,0.00,0.00,261.00,0.00,0.00,0.00,60.00,321.00,3),(37,2,2,0,0.00,261.00,2,0,0.00,0.00,261.00,0.00,0.00,0.00,60.00,321.00,3),(38,2,3,1,50.00,261.00,3,0,0.00,0.00,261.00,0.00,0.00,0.00,60.00,321.00,3),(39,2,4,0,0.00,261.00,4,0,0.00,0.00,261.00,0.00,0.00,0.00,60.00,321.00,3),(40,2,5,1,10.00,261.00,5,0,0.00,0.00,261.00,0.00,0.00,0.00,60.00,321.00,3),(41,2,6,0,0.00,261.00,6,0,0.00,0.00,261.00,0.00,0.00,0.00,60.00,321.00,3),(42,2,7,1,1.00,261.00,8,0,0.00,0.00,261.00,0.00,0.00,0.00,60.00,321.00,3),(43,1,1,3,600.00,630.00,1,0,0.00,0.03,630.03,100.00,50.00,780.03,0.00,0.00,4),(44,1,2,0,0.00,630.00,2,0,0.00,0.03,630.03,100.00,50.00,780.03,0.00,0.00,4),(45,1,3,0,0.00,630.00,3,0,0.00,0.03,630.03,100.00,50.00,780.03,0.00,0.00,4),(46,1,4,0,0.00,630.00,4,0,0.00,0.03,630.03,100.00,50.00,780.03,0.00,0.00,4),(47,1,5,3,30.00,630.00,5,0,0.00,0.03,630.03,100.00,50.00,780.03,0.00,0.00,4),(48,1,6,0,0.00,630.00,6,3,0.03,0.03,630.03,100.00,50.00,780.03,0.00,0.00,4),(49,1,7,0,0.00,630.00,8,0,0.00,0.03,630.03,100.00,50.00,780.03,0.00,0.00,4),(50,1,1,1,200.00,261.00,1,0,0.00,0.00,261.00,220.00,120.00,601.00,0.00,0.00,5),(51,1,2,0,0.00,261.00,2,0,0.00,0.00,261.00,220.00,120.00,601.00,0.00,0.00,5),(52,1,3,1,50.00,261.00,3,0,0.00,0.00,261.00,220.00,120.00,601.00,0.00,0.00,5),(53,1,4,0,0.00,261.00,4,0,0.00,0.00,261.00,220.00,120.00,601.00,0.00,0.00,5),(54,1,5,1,10.00,261.00,5,0,0.00,0.00,261.00,220.00,120.00,601.00,0.00,0.00,5),(55,1,6,0,0.00,261.00,6,0,0.00,0.00,261.00,220.00,120.00,601.00,0.00,0.00,5),(56,1,7,1,1.00,261.00,8,0,0.00,0.00,261.00,220.00,120.00,601.00,0.00,0.00,5),(57,2,1,2,400.00,522.00,1,0,0.00,0.00,522.00,0.00,0.00,0.00,450.00,972.00,5),(58,2,2,0,0.00,522.00,2,0,0.00,0.00,522.00,0.00,0.00,0.00,450.00,972.00,5),(59,2,3,2,100.00,522.00,3,0,0.00,0.00,522.00,0.00,0.00,0.00,450.00,972.00,5),(60,2,4,0,0.00,522.00,4,0,0.00,0.00,522.00,0.00,0.00,0.00,450.00,972.00,5),(61,2,5,2,20.00,522.00,5,0,0.00,0.00,522.00,0.00,0.00,0.00,450.00,972.00,5),(62,2,6,0,0.00,522.00,6,0,0.00,0.00,522.00,0.00,0.00,0.00,450.00,972.00,5),(63,2,7,2,2.00,522.00,8,0,0.00,0.00,522.00,0.00,0.00,0.00,450.00,972.00,5);
/*!40000 ALTER TABLE `sa_detalletesoreria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_encabezadocajachica`
--

DROP TABLE IF EXISTS `sa_encabezadocajachica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_encabezadocajachica` (
  `idsa_encabezadocajachica` int(11) NOT NULL AUTO_INCREMENT,
  `sa_numarqueo` int(11) DEFAULT NULL,
  `idsa_usuario` int(11) DEFAULT NULL,
  `sa_agencia` int(11) DEFAULT NULL,
  `sa_fecha` datetime DEFAULT NULL,
  `sa_nombre` varchar(50) DEFAULT NULL,
  `sa_numoperador` int(11) DEFAULT NULL,
  `sa_puestooperador` varchar(50) DEFAULT NULL,
  `sa_nombreencargado` varchar(50) DEFAULT NULL,
  `sa_puestoencargado` varchar(50) DEFAULT NULL,
  `sa_saldoinicial` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idsa_encabezadocajachica`),
  KEY `sa_agencia_idx` (`sa_agencia`),
  CONSTRAINT `sa_agencia` FOREIGN KEY (`sa_agencia`) REFERENCES `sa_agencia` (`idsa_agencia`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_encabezadocajachica`
--

LOCK TABLES `sa_encabezadocajachica` WRITE;
/*!40000 ALTER TABLE `sa_encabezadocajachica` DISABLE KEYS */;
INSERT INTO `sa_encabezadocajachica` VALUES (1,1,3,5,'2021-02-26 14:31:00','Aida Jimena Ortiz Delgado',1256,'Auditor','Juan Perez','Auditor',700.00),(2,1,3,13,'2021-02-27 23:11:00','Aida Jimena Ortiz Delgado',123,'Auditor','Carlos Perez','Auditor',500.00),(3,1,3,15,'2021-02-28 14:56:00','Aida Jimena Ortiz Delgado',123,'Auditor','Carlos Garcia','Auditor',700.00),(4,1,3,5,'2021-03-01 15:33:00','Aida Jimena Ortiz Delgado',123,'Auditor','Luis Perez','Auditor',700.00),(5,1,3,12,'2021-03-02 18:16:00','Luisa Garcia',123,'Auditor','Aida Jimena Ortiz Delgado','Jefe',700.00),(6,2,3,6,'2021-03-02 18:25:00','Fernando Jimenez',123,'Auditor','Aida Jimena Ortiz Delgado','Jefe',500.00);
/*!40000 ALTER TABLE `sa_encabezadocajachica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_encabezadocajero`
--

DROP TABLE IF EXISTS `sa_encabezadocajero`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_encabezadocajero` (
  `idsa_encabezadocajero` int(11) NOT NULL AUTO_INCREMENT,
  `sa_numarqueo` int(11) DEFAULT NULL,
  `idsa_usuario` int(11) DEFAULT NULL,
  `sa_fechayhora` datetime DEFAULT NULL,
  `sa_agencia` int(11) DEFAULT NULL,
  `sa_nombre` varchar(50) DEFAULT NULL,
  `sa_usuario` varchar(50) DEFAULT NULL,
  `sa_operador` int(11) DEFAULT NULL,
  `sa_puestooperador` varchar(50) DEFAULT NULL,
  `sa_nombreencargado` varchar(50) DEFAULT NULL,
  `sa_puestoencargado` varchar(50) DEFAULT NULL,
  `sa_comentarios` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idsa_encabezadocajero`),
  KEY `sa_agencia2_idx` (`sa_agencia`),
  CONSTRAINT `sa_agencia2` FOREIGN KEY (`sa_agencia`) REFERENCES `sa_agencia` (`idsa_agencia`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_encabezadocajero`
--

LOCK TABLES `sa_encabezadocajero` WRITE;
/*!40000 ALTER TABLE `sa_encabezadocajero` DISABLE KEYS */;
INSERT INTO `sa_encabezadocajero` VALUES (1,1,3,'2021-02-26 12:50:00',3,'Aida Jimena Ortiz Delgado','pgaortiz',123,'Auditor','Juan Perez','Auditor','arqueo '),(2,1,3,'2021-02-27 21:51:00',12,'Aida Jimena Ortiz Delgado','pgaortiz',456,'Auditor','Juan Perez','Auditor','arqueo '),(3,1,3,'2021-02-28 14:33:00',16,'Aida Jimena Ortiz Delgado','pgaortiz',456,'Auditor','Juan Perez','Auditor','arqueo '),(4,1,3,'2021-03-01 15:07:00',25,'Aida Jimena Ortiz Delgado','pgaortiz',456,'Auditor','Juan Perez','Auditor','arqueo '),(5,1,3,'2021-03-02 19:01:00',12,'Luisa Ortiz','pglortiz',456,'Auditor','Aida Jimena Ortiz Delgado','Jefe','arqueo '),(6,2,3,'2021-03-02 19:05:00',5,'Silvia Delgado','pgsdelgado',123,'Auditor','Aida Jimena Ortiz Delgado','Jefe','arqueo 2');
/*!40000 ALTER TABLE `sa_encabezadocajero` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_encabezadocajeroaut`
--

DROP TABLE IF EXISTS `sa_encabezadocajeroaut`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_encabezadocajeroaut` (
  `idsa_encabezadocajeroaut` int(11) NOT NULL AUTO_INCREMENT,
  `sa_numarqueo` int(11) DEFAULT NULL,
  `idsa_usuario` int(11) DEFAULT NULL,
  `sa_fechayhora` datetime DEFAULT NULL,
  `sa_agencia` int(11) DEFAULT NULL,
  `sa_nombreoperador` varchar(50) DEFAULT NULL,
  `sa_numoperador` int(11) DEFAULT NULL,
  `sa_puestooperador` varchar(50) DEFAULT NULL,
  `sa_nombreencargado` varchar(50) DEFAULT NULL,
  `sa_puestoencargado` varchar(50) DEFAULT NULL,
  `sa_atm` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idsa_encabezadocajeroaut`),
  KEY `sa_agencia3_idx` (`sa_agencia`),
  CONSTRAINT `sa_agencia3` FOREIGN KEY (`sa_agencia`) REFERENCES `sa_agencia` (`idsa_agencia`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_encabezadocajeroaut`
--

LOCK TABLES `sa_encabezadocajeroaut` WRITE;
/*!40000 ALTER TABLE `sa_encabezadocajeroaut` DISABLE KEYS */;
INSERT INTO `sa_encabezadocajeroaut` VALUES (1,1,3,'2021-02-26 14:15:00',5,'Aida Jimena Ortiz Delgado',456,'Auditor','Juan Perez','Auditor',20000.00),(2,1,3,'2021-02-27 23:05:00',7,'Aida Jimena Ortiz Delgado',123,'Auditor','Luis Perez','Auditor',20000.00),(3,1,3,'2021-02-28 14:35:00',15,'Aida Jimena Ortiz Delgado',123,'Auditor','Luis Perez','Auditor',20000.00),(4,1,3,'2021-03-01 15:23:00',11,'Aida Jimena Ortiz Delgado',123,'Auditor','Juan Perez','Auditor',20000.00),(5,1,3,'2021-03-02 16:01:00',5,'Andres Lopez',123,'Auditor','Aida Jimena Ortiz Delgado','Jefe',20000.00),(6,2,3,'2021-03-02 16:08:00',6,'Gerson Garcia',123,'Auditor','Aida Jimena Ortiz Delgado','Jefe',20000.00),(7,3,3,'2021-03-02 16:11:00',4,'Juan Perez',123,'Auditor','Aida Jimena Ortiz Delgado','Jefe',20000.00);
/*!40000 ALTER TABLE `sa_encabezadocajeroaut` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_encabezadotesoreria`
--

DROP TABLE IF EXISTS `sa_encabezadotesoreria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_encabezadotesoreria` (
  `idsa_encabezadotesoreria` int(11) NOT NULL AUTO_INCREMENT,
  `sa_numarqueo` int(11) DEFAULT NULL,
  `idsa_usuario` int(11) DEFAULT NULL,
  `sa_fechayhora` datetime DEFAULT NULL,
  `sa_agencia` int(11) DEFAULT NULL,
  `sa_nombreoperador` varchar(50) DEFAULT NULL,
  `sa_numoperador` int(11) DEFAULT NULL,
  `sa_puestooperador` varchar(50) DEFAULT NULL,
  `sa_nombreencargado` varchar(50) DEFAULT NULL,
  `sa_puestoencargado` varchar(50) DEFAULT NULL,
  `sa_tesoreriaQ` decimal(10,2) DEFAULT NULL,
  `sa_tesoreriaDol` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idsa_encabezadotesoreria`),
  KEY `sa_agencia4_idx` (`sa_agencia`),
  CONSTRAINT `sa_agencia4` FOREIGN KEY (`sa_agencia`) REFERENCES `sa_agencia` (`idsa_agencia`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_encabezadotesoreria`
--

LOCK TABLES `sa_encabezadotesoreria` WRITE;
/*!40000 ALTER TABLE `sa_encabezadotesoreria` DISABLE KEYS */;
INSERT INTO `sa_encabezadotesoreria` VALUES (1,1,3,'2021-02-26 14:18:00',14,'Aida Jimena Ortiz Delgado',123,'Auditor','Juan Perez','Jefe',300.00,500.00),(2,1,3,'2021-02-27 23:07:00',25,'Aida Jimena Ortiz Delgado',123,'Auditor','Juan Perez','Jefe',500.00,600.00),(3,1,3,'2021-02-28 14:54:00',5,'Aida Jimena Ortiz Delgado',123,'Auditor','Juan Perez','Auditor',250.00,300.00),(4,1,3,'2021-03-02 15:27:00',8,'Aida Jimena Ortiz Delgado',123,'Auditor','Luis Perez','Auditor',500.00,0.00),(5,2,3,'2021-03-02 19:16:00',3,'Andres Lopez',123,'Auditor','Aida Jimena Ortiz Delgado','Jefe',500.00,300.00);
/*!40000 ALTER TABLE `sa_encabezadotesoreria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_monedas`
--

DROP TABLE IF EXISTS `sa_monedas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_monedas` (
  `idsa_monedas` int(11) NOT NULL AUTO_INCREMENT,
  `sa_valormonedas` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idsa_monedas`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_monedas`
--

LOCK TABLES `sa_monedas` WRITE;
/*!40000 ALTER TABLE `sa_monedas` DISABLE KEYS */;
INSERT INTO `sa_monedas` VALUES (1,1.00),(2,0.50),(3,0.25),(4,0.10),(5,0.50),(6,0.01),(8,0.00);
/*!40000 ALTER TABLE `sa_monedas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_puesto`
--

DROP TABLE IF EXISTS `sa_puesto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_puesto` (
  `idsa_puesto` int(11) NOT NULL AUTO_INCREMENT,
  `sa_puestonombre` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idsa_puesto`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_puesto`
--

LOCK TABLES `sa_puesto` WRITE;
/*!40000 ALTER TABLE `sa_puesto` DISABLE KEYS */;
INSERT INTO `sa_puesto` VALUES (1,'Auditor campo'),(2,'Auditor general');
/*!40000 ALTER TABLE `sa_puesto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_tipocheque`
--

DROP TABLE IF EXISTS `sa_tipocheque`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_tipocheque` (
  `idsa_tipocheque` int(11) NOT NULL AUTO_INCREMENT,
  `sa_nombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idsa_tipocheque`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_tipocheque`
--

LOCK TABLES `sa_tipocheque` WRITE;
/*!40000 ALTER TABLE `sa_tipocheque` DISABLE KEYS */;
INSERT INTO `sa_tipocheque` VALUES (1,'Propios'),(2,'Ajenos');
/*!40000 ALTER TABLE `sa_tipocheque` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sa_tipomoneda`
--

DROP TABLE IF EXISTS `sa_tipomoneda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sa_tipomoneda` (
  `idsa_tipomoneda` int(11) NOT NULL AUTO_INCREMENT,
  `sa_nombretipomoneda` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`idsa_tipomoneda`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sa_tipomoneda`
--

LOCK TABLES `sa_tipomoneda` WRITE;
/*!40000 ALTER TABLE `sa_tipomoneda` DISABLE KEYS */;
INSERT INTO `sa_tipomoneda` VALUES (1,'Quetzales'),(2,'Dolares');
/*!40000 ALTER TABLE `sa_tipomoneda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seg_log`
--

DROP TABLE IF EXISTS `seg_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `seg_log` (
  `codseglog` int(11) NOT NULL,
  `codgenusuario` int(11) DEFAULT NULL,
  `codsegtipoproceso` int(11) DEFAULT NULL,
  `seg_logusuario` varchar(45) DEFAULT NULL,
  `seg_loghora` time DEFAULT NULL,
  `seg_logfecha` date DEFAULT NULL,
  `seg_logip` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codseglog`),
  KEY `fk_seg_log_seg_tipoproceso1_idx` (`codsegtipoproceso`),
  KEY `fk_seg_log_gen_usuario1_idx` (`codgenusuario`),
  CONSTRAINT `fk_seg_log_gen_usuario1` FOREIGN KEY (`codgenusuario`) REFERENCES `gen_usuario` (`codgenusuario`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_seg_log_seg_tipoproceso1` FOREIGN KEY (`codsegtipoproceso`) REFERENCES `seg_tipoproceso` (`codsegtipoproceso`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seg_log`
--

LOCK TABLES `seg_log` WRITE;
/*!40000 ALTER TABLE `seg_log` DISABLE KEYS */;
/*!40000 ALTER TABLE `seg_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `seg_tipoproceso`
--

DROP TABLE IF EXISTS `seg_tipoproceso`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `seg_tipoproceso` (
  `codsegtipoproceso` int(11) NOT NULL,
  `seg_tipoprocesonombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codsegtipoproceso`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `seg_tipoproceso`
--

LOCK TABLES `seg_tipoproceso` WRITE;
/*!40000 ALTER TABLE `seg_tipoproceso` DISABLE KEYS */;
/*!40000 ALTER TABLE `seg_tipoproceso` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `sumamonto`
--

DROP TABLE IF EXISTS `sumamonto`;
/*!50001 DROP VIEW IF EXISTS `sumamonto`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `sumamonto` AS SELECT 
 1 AS `SUM(avt.av_monto)`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `ticket_detalle`
--

DROP TABLE IF EXISTS `ticket_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ticket_detalle` (
  `codticketdetalle` int(11) NOT NULL,
  `codticketencabezado` int(11) DEFAULT NULL,
  `codticketestado` int(11) DEFAULT NULL,
  `codticketprioridad` int(11) DEFAULT NULL,
  `ticket_detalleresponsable` varchar(45) DEFAULT NULL,
  `ticket_detallehoradeactualizacion` time DEFAULT NULL,
  `ticket_detallefechadeactualizacion` date DEFAULT NULL,
  PRIMARY KEY (`codticketdetalle`),
  KEY `fk_ticket_detalle_ticket_estado1_idx` (`codticketestado`),
  KEY `fk_ticket_detalle_ticket_prioridad1_idx` (`codticketprioridad`),
  CONSTRAINT `fk_ticket_detalle_ticket_estado1` FOREIGN KEY (`codticketestado`) REFERENCES `ticket_estado` (`codticketestado`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ticket_detalle_ticket_prioridad1` FOREIGN KEY (`codticketprioridad`) REFERENCES `ticket_prioridad` (`codticketprioridad`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket_detalle`
--

LOCK TABLES `ticket_detalle` WRITE;
/*!40000 ALTER TABLE `ticket_detalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `ticket_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket_encabezado`
--

DROP TABLE IF EXISTS `ticket_encabezado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ticket_encabezado` (
  `codticketencabezado` int(11) NOT NULL,
  `codgenarea` int(11) DEFAULT NULL,
  `ticket_encabezadousuario` varchar(45) DEFAULT NULL,
  `ticket_encabezadodescripcion` varchar(45) DEFAULT NULL,
  `ticket_encabezadoimagen` blob DEFAULT NULL,
  `ticket_encabezadofecha` date DEFAULT NULL,
  `ticket_encabezadohora` time DEFAULT NULL,
  PRIMARY KEY (`codticketencabezado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket_encabezado`
--

LOCK TABLES `ticket_encabezado` WRITE;
/*!40000 ALTER TABLE `ticket_encabezado` DISABLE KEYS */;
/*!40000 ALTER TABLE `ticket_encabezado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket_estado`
--

DROP TABLE IF EXISTS `ticket_estado`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ticket_estado` (
  `codticketestado` int(11) NOT NULL,
  `ticket_estadonombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codticketestado`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket_estado`
--

LOCK TABLES `ticket_estado` WRITE;
/*!40000 ALTER TABLE `ticket_estado` DISABLE KEYS */;
/*!40000 ALTER TABLE `ticket_estado` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket_prioridad`
--

DROP TABLE IF EXISTS `ticket_prioridad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ticket_prioridad` (
  `codticketprioridad` int(11) NOT NULL,
  `ticket_prioridadnombre` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`codticketprioridad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket_prioridad`
--

LOCK TABLES `ticket_prioridad` WRITE;
/*!40000 ALTER TABLE `ticket_prioridad` DISABLE KEYS */;
/*!40000 ALTER TABLE `ticket_prioridad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ticket_tipo`
--

DROP TABLE IF EXISTS `ticket_tipo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ticket_tipo` (
  `codtickettipo` int(11) NOT NULL,
  `codgenarea` int(11) DEFAULT NULL,
  `ticket_tiponombew` varchar(45) DEFAULT NULL,
  `ticket_tipodescripcion` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`codtickettipo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ticket_tipo`
--

LOCK TABLES `ticket_tipo` WRITE;
/*!40000 ALTER TABLE `ticket_tipo` DISABLE KEYS */;
/*!40000 ALTER TABLE `ticket_tipo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `usuariostareas`
--

DROP TABLE IF EXISTS `usuariostareas`;
/*!50001 DROP VIEW IF EXISTS `usuariostareas`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `usuariostareas` AS SELECT 
 1 AS `gen_usuarionombre`,
 1 AS `codavtarea`,
 1 AS `codavagenda`,
 1 AS `av_titulo`,
 1 AS `fechaini`,
 1 AS `fechafin`,
 1 AS `av_estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `vistausuariostarea`
--

DROP TABLE IF EXISTS `vistausuariostarea`;
/*!50001 DROP VIEW IF EXISTS `vistausuariostarea`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `vistausuariostarea` AS SELECT 
 1 AS `gen_usuarionombre`,
 1 AS `codavtarea`,
 1 AS `codavagenda`,
 1 AS `av_pnombre`,
 1 AS `av_papellido`,
 1 AS `fechaini`,
 1 AS `fechafin`,
 1 AS `av_estado`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'bdkbguadalupana'
--

--
-- Dumping routines for database 'bdkbguadalupana'
--
/*!50003 DROP PROCEDURE IF EXISTS `bitacora_ingresos_egresos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `bitacora_ingresos_egresos`(IN `username` VARCHAR(80), IN `ipaddress` VARCHAR(100), IN `macaddress` VARCHAR(50), IN `fechahora_actual` DATETIME, IN `nombremodulo` VARCHAR(80), IN `ingresos_egresos` VARCHAR(80))
BEGIN
INSERT INTO gen_bitacora_ingresos_egresos(codgen_bitacora_ingresos_egresos,gen_bitacora_ingresos_egresosusername,
gen_bitacora_ingresos_egresosipaddress,gen_bitacora_ingresos_egresosmacaddress,gen_bitacora_ingresos_egresosfechahora,
gen_bitacora_ingresos_egresosnombremodulo,gen_bitacora_ingresos_egresosestado)
VALUES (null,username,ipaddress,macaddress,fechahora_actual,nombremodulo,ingresos_egresos); 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `bitacora_procedimientos` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `bitacora_procedimientos`(IN `username` VARCHAR(80), IN `ipaddress` VARCHAR(100), IN `macaddress` VARCHAR(50), IN `fechahora_actual` DATETIME, IN `nombremodulo` VARCHAR(80), IN `aplicacion` VARCHAR(80), IN `operacion` VARCHAR(150))
BEGIN
INSERT INTO gen_bitacora_procedimientos VALUES (null,username,ipaddress,macaddress,fechahora_actual,nombremodulo,aplicacion,operacion); 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `graficamontos`
--

/*!50001 DROP VIEW IF EXISTS `graficamontos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `graficamontos` AS select cast((select count(`avcr`.`av_numcredito`) from (`av_tarea` `avt` join `av_credito` `avcr` on(`avt`.`codavtarea` = `avcr`.`codavtarea`)) where `avt`.`av_fechaini` between '2021-02-01' and '2021-02-27') / (select count(`avt`.`codavtarea`) AS `tareas` from `av_tarea` `avt` where `avt`.`av_fechaini` between '2021-02-01' and '2021-02-27' and `avt`.`cod_estado` = 3 and `avt`.`codtipotarea` = 1) as decimal(4,3)) * 100 AS `resultado` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `montodatos`
--

/*!50001 DROP VIEW IF EXISTS `montodatos`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `montodatos` AS select `avt`.`codavtarea` AS `codavtarea`,`avt`.`av_titulo` AS `av_titulo`,`ave`.`av_estado` AS `av_estado`,`avt`.`av_monto` AS `av_monto`,`avt`.`fechaini` AS `fechaini`,`avt`.`fechafin` AS `fechafin` from (`av_tarea` `avt` join `av_estado` `ave` on(`avt`.`cod_estado` = `ave`.`codestado`)) where `avt`.`av_fechaini` between '2021-02-01' and '2021-02-27' and `avt`.`cod_estado` = 3 and `avt`.`codtipotarea` = 1 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `montosview`
--

/*!50001 DROP VIEW IF EXISTS `montosview`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `montosview` AS select cast((select count(`avcr`.`av_numcredito`) from (`av_tarea` `avt` join `av_credito` `avcr` on(`avt`.`codavtarea` = `avcr`.`codavtarea`))) / (select count(`avt`.`codavtarea`) AS `tareas` from `av_tarea` `avt` where `avt`.`cod_estado` = 3 and `avt`.`codtipotarea` = 1) as decimal(4,3)) * 100 AS `resultado` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `sumamonto`
--

/*!50001 DROP VIEW IF EXISTS `sumamonto`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `sumamonto` AS select sum(`avt`.`av_monto`) AS `SUM(avt.av_monto)` from (`av_tarea` `avt` join `av_estado` `ave` on(`avt`.`cod_estado` = `ave`.`codestado`)) where `avt`.`av_fechaini` between '2021-02-01' and '2021-02-27' and `avt`.`cod_estado` = 3 and `avt`.`codtipotarea` = 1 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `usuariostareas`
--

/*!50001 DROP VIEW IF EXISTS `usuariostareas`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `usuariostareas` AS select distinct `geu`.`gen_usuarionombre` AS `gen_usuarionombre`,`avt`.`codavtarea` AS `codavtarea`,`avt`.`codavagenda` AS `codavagenda`,`avt`.`av_titulo` AS `av_titulo`,`avt`.`fechaini` AS `fechaini`,`avt`.`fechafin` AS `fechafin`,`ave`.`av_estado` AS `av_estado` from ((((`av_estado` `ave` join `av_tarea` `avt` on(`ave`.`codestado` = `avt`.`cod_estado`)) join `av_agenda` `avg` on(`avt`.`codavagenda` = `avg`.`codavagenda`)) join `gen_usuario` `geu` on(`geu`.`codgenusuario` = `avg`.`codgenusuario`)) join `av_controlasignado` `avc` on(`avc`.`codgenusuario` = `geu`.`codgenusuario`)) where `avg`.`codgenusuario` = 4 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `vistausuariostarea`
--

/*!50001 DROP VIEW IF EXISTS `vistausuariostarea`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `vistausuariostarea` AS select `geu`.`gen_usuarionombre` AS `gen_usuarionombre`,`avt`.`codavtarea` AS `codavtarea`,`avt`.`codavagenda` AS `codavagenda`,`avt`.`av_pnombre` AS `av_pnombre`,`avt`.`av_papellido` AS `av_papellido`,`avt`.`fechaini` AS `fechaini`,`avt`.`fechafin` AS `fechafin`,`ave`.`av_estado` AS `av_estado` from (((`av_estado` `ave` join `av_tarea` `avt` on(`ave`.`codestado` = `avt`.`cod_estado`)) join `av_agenda` `avg` on(`avt`.`codavagenda` = `avg`.`codavagenda`)) join `gen_usuario` `geu` on(`geu`.`codgenusuario` = `avg`.`codgenusuario`)) where `avg`.`codgenusuario` = 4 */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-03-14 23:22:05
