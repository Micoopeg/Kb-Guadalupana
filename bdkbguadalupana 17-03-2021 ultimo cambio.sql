-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 17-03-2021 a las 20:02:10
-- Versión del servidor: 10.4.17-MariaDB
-- Versión de PHP: 7.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bdkbguadalupana`
--
CREATE DATABASE IF NOT EXISTS `bdkbguadalupana` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `bdkbguadalupana`;

DELIMITER $$
--
-- Procedimientos
--
DROP PROCEDURE IF EXISTS `bitacora_ingresos_egresos`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `bitacora_ingresos_egresos` (IN `username` VARCHAR(80), IN `ipaddress` VARCHAR(100), IN `macaddress` VARCHAR(50), IN `fechahora_actual` DATETIME, IN `nombremodulo` VARCHAR(80), IN `ingresos_egresos` VARCHAR(80))  BEGIN
INSERT INTO gen_bitacora_ingresos_egresos(codgen_bitacora_ingresos_egresos,gen_bitacora_ingresos_egresosusername,
gen_bitacora_ingresos_egresosipaddress,gen_bitacora_ingresos_egresosmacaddress,gen_bitacora_ingresos_egresosfechahora,
gen_bitacora_ingresos_egresosnombremodulo,gen_bitacora_ingresos_egresosestado)
VALUES (null,username,ipaddress,macaddress,fechahora_actual,nombremodulo,ingresos_egresos); 
END$$

DROP PROCEDURE IF EXISTS `bitacora_procedimientos`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `bitacora_procedimientos` (IN `username` VARCHAR(80), IN `ipaddress` VARCHAR(100), IN `macaddress` VARCHAR(50), IN `fechahora_actual` DATETIME, IN `nombremodulo` VARCHAR(80), IN `aplicacion` VARCHAR(80), IN `operacion` VARCHAR(150))  BEGIN
INSERT INTO gen_bitacora_procedimientos VALUES (null,username,ipaddress,macaddress,fechahora_actual,nombremodulo,aplicacion,operacion); 
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_agenda`
--

DROP TABLE IF EXISTS `av_agenda`;
CREATE TABLE `av_agenda` (
  `codavagenda` int(11) NOT NULL,
  `codavcontroling` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `av_agenda`
--

INSERT INTO `av_agenda` (`codavagenda`, `codavcontroling`) VALUES
(1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_controlasignado`
--

DROP TABLE IF EXISTS `av_controlasignado`;
CREATE TABLE `av_controlasignado` (
  `codavcontroling` int(11) NOT NULL,
  `codavtarea` int(11) NOT NULL,
  `avcifgeneral` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_controlingreso`
--

DROP TABLE IF EXISTS `av_controlingreso`;
CREATE TABLE `av_controlingreso` (
  `codavcontroling` int(11) NOT NULL,
  `av_controlusuario` varchar(20) NOT NULL,
  `av_controlarea` int(11) NOT NULL,
  `av_controlrol` int(11) NOT NULL,
  `avcifgeneral` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `av_controlingreso`
--

INSERT INTO `av_controlingreso` (`codavcontroling`, `av_controlusuario`, `av_controlarea`, `av_controlrol`, `avcifgeneral`) VALUES
(1, 'pgecasasola', 1, 3, 949930),
(2, 'pgaortiz', 1, 1, 949910),
(3, 'pggorellana', 2, 1, 874971),
(4, 'pglalvarado', 2, 1, 860949);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_controlsitio`
--

DROP TABLE IF EXISTS `av_controlsitio`;
CREATE TABLE `av_controlsitio` (
  `codavcontolsitio` int(11) NOT NULL,
  `av_nombre` varchar(90) NOT NULL,
  `av_tipositio` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `av_controlsitio`
--

INSERT INTO `av_controlsitio` (`codavcontolsitio`, `av_nombre`, `av_tipositio`) VALUES
(1, 'Agencia Central', 2),
(2, 'Negocios', 4);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_credito`
--

DROP TABLE IF EXISTS `av_credito`;
CREATE TABLE `av_credito` (
  `codavcredit` int(11) NOT NULL,
  `codavtarea` int(11) NOT NULL,
  `av_numcredito` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_estado`
--

DROP TABLE IF EXISTS `av_estado`;
CREATE TABLE `av_estado` (
  `codestado` int(11) NOT NULL,
  `av_estado` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `av_estado`
--

INSERT INTO `av_estado` (`codestado`, `av_estado`) VALUES
(1, 'Abierto'),
(2, 'En Proceso'),
(3, 'Cerrado'),
(4, 'Anulado');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_permisostarea`
--

DROP TABLE IF EXISTS `av_permisostarea`;
CREATE TABLE `av_permisostarea` (
  `codavpertarea` int(11) NOT NULL,
  `av_pertarea` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `av_permisostarea`
--

INSERT INTO `av_permisostarea` (`codavpertarea`, `av_pertarea`) VALUES
(1, 'lectura y escritura'),
(2, 'lectura'),
(3, 'ReasignarLE');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_prioridad`
--

DROP TABLE IF EXISTS `av_prioridad`;
CREATE TABLE `av_prioridad` (
  `codprioridad` int(11) NOT NULL,
  `av_prioridad` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `av_prioridad`
--

INSERT INTO `av_prioridad` (`codprioridad`, `av_prioridad`) VALUES
(1, 'Alta'),
(2, 'Media'),
(3, 'Baja');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_roles`
--

DROP TABLE IF EXISTS `av_roles`;
CREATE TABLE `av_roles` (
  `av_codrol` int(11) NOT NULL,
  `av_rolnombre` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `av_roles`
--

INSERT INTO `av_roles` (`av_codrol`, `av_rolnombre`) VALUES
(1, 'Administrador'),
(2, 'Usuario'),
(3, 'SuperUser');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_subtarea`
--

DROP TABLE IF EXISTS `av_subtarea`;
CREATE TABLE `av_subtarea` (
  `codsubtarea` int(11) NOT NULL,
  `codtarea` int(11) NOT NULL,
  `codestado` int(11) NOT NULL DEFAULT 1,
  `av_descsubtarea` varchar(140) NOT NULL,
  `av_fechaini` datetime NOT NULL,
  `av_fechafin` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_tarea`
--

DROP TABLE IF EXISTS `av_tarea`;
CREATE TABLE `av_tarea` (
  `codavtarea` int(11) NOT NULL,
  `codavagenda` int(11) NOT NULL,
  `av_titulo` varchar(60) NOT NULL,
  `av_pnombre` varchar(30) DEFAULT NULL,
  `av_papellido` varchar(30) DEFAULT NULL,
  `av_telefono` int(11) DEFAULT NULL,
  `av_monto` int(11) DEFAULT NULL,
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
  `av_comentario` varchar(140) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_tipositio`
--

DROP TABLE IF EXISTS `av_tipositio`;
CREATE TABLE `av_tipositio` (
  `codavtipositio` int(11) NOT NULL,
  `av_sitio` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `av_tipositio`
--

INSERT INTO `av_tipositio` (`codavtipositio`, `av_sitio`) VALUES
(1, 'Kiosko'),
(2, 'Agencia'),
(3, 'Mini Agencia'),
(4, 'Area');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `av_tipotarea`
--

DROP TABLE IF EXISTS `av_tipotarea`;
CREATE TABLE `av_tipotarea` (
  `codtipotarea` int(11) NOT NULL,
  `tipotarea` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `av_tipotarea`
--

INSERT INTO `av_tipotarea` (`codtipotarea`, `tipotarea`) VALUES
(1, 'Cita '),
(2, 'Visita tecnica');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crmalertas_programadas`
--

DROP TABLE IF EXISTS `crmalertas_programadas`;
CREATE TABLE `crmalertas_programadas` (
  `codcrmalertasprogramadas` int(11) NOT NULL,
  `codcrmcontrolingreso` int(11) DEFAULT NULL,
  `crmalertas_programadasfechainicio` date DEFAULT NULL,
  `crmalertas_programadasfechafin` date DEFAULT NULL,
  `crmalertas_programadasnobre` varchar(45) DEFAULT NULL,
  `crmalertas_programadasdescripcion` varchar(50) DEFAULT NULL,
  `crmalertas_programadasestado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crmalertas_programadas`
--

INSERT INTO `crmalertas_programadas` (`codcrmalertasprogramadas`, `codcrmcontrolingreso`, `crmalertas_programadasfechainicio`, `crmalertas_programadasfechafin`, `crmalertas_programadasnobre`, `crmalertas_programadasdescripcion`, `crmalertas_programadasestado`) VALUES
(1, 2, '2021-01-01', '2021-02-01', 'Llamar importante', 'llamada a las 15:00hrs', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crmcontacto_llamadas`
--

DROP TABLE IF EXISTS `crmcontacto_llamadas`;
CREATE TABLE `crmcontacto_llamadas` (
  `codcrmcontactollamadas` int(11) NOT NULL,
  `crmcontacto_llamadasnombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crmcontacto_llamadas`
--

INSERT INTO `crmcontacto_llamadas` (`codcrmcontactollamadas`, `crmcontacto_llamadasnombre`) VALUES
(1, 'Si contesto'),
(2, 'No contesto'),
(3, '1era Llamada'),
(4, '2da Llamada'),
(5, '3ra Llamada');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crmcontrol_ingreso`
--

DROP TABLE IF EXISTS `crmcontrol_ingreso`;
CREATE TABLE `crmcontrol_ingreso` (
  `codcrmcontrolingreso` int(11) NOT NULL,
  `crmcontrol_ingresosucursal` varchar(45) DEFAULT NULL,
  `crmcontrol_ingresousuario` varchar(45) DEFAULT NULL,
  `crmcontrol_ingresorol` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crmcontrol_ingreso`
--

INSERT INTO `crmcontrol_ingreso` (`codcrmcontrolingreso`, `crmcontrol_ingresosucursal`, `crmcontrol_ingresousuario`, `crmcontrol_ingresorol`) VALUES
(1, 'central', 'pggteo', '6'),
(2, 'central', 'pggteo1', '3'),
(3, 'mazate', 'pggteo2', '3'),
(4, 'telemercadeo', 'pggteo3', '3'),
(5, 'telemercadeo', 'pggteo4', '3');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crmcontrol_prospecto_agente`
--

DROP TABLE IF EXISTS `crmcontrol_prospecto_agente`;
CREATE TABLE `crmcontrol_prospecto_agente` (
  `codcrmcontrolprospectoagente` int(11) NOT NULL,
  `codcrminfoprospecto` int(11) DEFAULT NULL,
  `codcrmcontrolingreso` int(11) DEFAULT NULL,
  `fechaasignado` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crmcontrol_prospecto_agente`
--

INSERT INTO `crmcontrol_prospecto_agente` (`codcrmcontrolprospectoagente`, `codcrminfoprospecto`, `codcrmcontrolingreso`, `fechaasignado`) VALUES
(1, 1, 2, '2021-02-22'),
(2, 2, 4, '2021-02-22'),
(3, 3, 5, '2021-02-22'),
(4, 4, 4, '2021-02-22'),
(5, 5, 2, '2021-03-04');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crmestado_descripcion`
--

DROP TABLE IF EXISTS `crmestado_descripcion`;
CREATE TABLE `crmestado_descripcion` (
  `codcrmestadodescripcion` int(11) NOT NULL,
  `codcrmsemaforoestado` int(11) DEFAULT NULL,
  `crmestado_descripcionnombre` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crmestado_descripcion`
--

INSERT INTO `crmestado_descripcion` (`codcrmestadodescripcion`, `codcrmsemaforoestado`, `crmestado_descripcionnombre`) VALUES
(1, 1, 'Calificado'),
(2, 2, 'Entregando papeleria'),
(3, 3, 'Numero ocupado'),
(4, 4, 'Finalizado por no contestar');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crminfogeneral_prospecto`
--

DROP TABLE IF EXISTS `crminfogeneral_prospecto`;
CREATE TABLE `crminfogeneral_prospecto` (
  `codcrminfogeneralprospecto` int(11) NOT NULL,
  `crminfogeneral_prospectodpi` varchar(45) DEFAULT NULL,
  `crminfogeneral_prospectonombre` varchar(45) DEFAULT NULL,
  `crminfogeneral_prospectoapellido` varchar(45) DEFAULT NULL,
  `crminfogeneral_prospectonombrecompleto` varchar(45) DEFAULT NULL,
  `crminfogeneral_prospectoblacklist` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crminfogeneral_prospecto`
--

INSERT INTO `crminfogeneral_prospecto` (`codcrminfogeneralprospecto`, `crminfogeneral_prospectodpi`, `crminfogeneral_prospectonombre`, `crminfogeneral_prospectoapellido`, `crminfogeneral_prospectonombrecompleto`, `crminfogeneral_prospectoblacklist`) VALUES
(1, '2990655880101', 'José', 'Gonzalez', 'Jose Gonzalez Teo', 0),
(2, '2990655880102', 'Pepe', 'Aguilar', 'Pepe Aguilar', 0),
(3, '2411548550101', '', '', 'Francisco Santiago', 0),
(4, '2211723000114', '', '', 'Estiven Estuardo Guevara Canvas', 0),
(5, '100000', '', '', '56900142', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crminfo_prospecto`
--

DROP TABLE IF EXISTS `crminfo_prospecto`;
CREATE TABLE `crminfo_prospecto` (
  `codcrminfoprospecto` int(11) NOT NULL,
  `codcrminfogeneralprospecto` int(11) DEFAULT NULL,
  `codcrmtiposervicio` int(11) DEFAULT NULL,
  `codcrmcontactollamadas` int(11) DEFAULT NULL,
  `codcrmsemaforoestado` int(11) DEFAULT NULL,
  `codcrmestadodescripcion` int(11) DEFAULT NULL,
  `codcrmtipodomicilio` int(11) DEFAULT NULL,
  `codcrmfinalidadservicio` int(11) DEFAULT NULL,
  `crminfo_prospectotelefono` int(11) DEFAULT NULL,
  `crminfo_prospectoemail` varchar(100) DEFAULT NULL,
  `crminfo_prospectoingresos` double DEFAULT NULL,
  `crminfo_prospectoegresos` double DEFAULT NULL,
  `crminfo_prospectomonto` double DEFAULT NULL,
  `crminfo_prospectoañoslaborados` double DEFAULT NULL,
  `crminfo_prospectotrabajaactualmente` int(11) DEFAULT NULL,
  `crminfo_prospectodescripciontrabajoactual` varchar(100) DEFAULT NULL,
  `crminfo_prospectofechaprimerllamada` date DEFAULT NULL,
  `crminfo_prospectofechaultimallamada` date DEFAULT NULL,
  `crminfo_prospectodescripcion` varchar(600) DEFAULT NULL,
  `crminfo_prospectosucursalcerca` varchar(45) DEFAULT NULL,
  `crminfo_prospectocuentaconigss` int(11) DEFAULT NULL,
  `crminfo_prospectoañosdomicilio` double DEFAULT NULL,
  `crminfo_prospectocuentaencooperativa` int(11) DEFAULT NULL,
  `crminfo_contactadopor` varchar(200) DEFAULT NULL,
  `crminfo_prospectoreferenciado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crminfo_prospecto`
--

INSERT INTO `crminfo_prospecto` (`codcrminfoprospecto`, `codcrminfogeneralprospecto`, `codcrmtiposervicio`, `codcrmcontactollamadas`, `codcrmsemaforoestado`, `codcrmestadodescripcion`, `codcrmtipodomicilio`, `codcrmfinalidadservicio`, `crminfo_prospectotelefono`, `crminfo_prospectoemail`, `crminfo_prospectoingresos`, `crminfo_prospectoegresos`, `crminfo_prospectomonto`, `crminfo_prospectoañoslaborados`, `crminfo_prospectotrabajaactualmente`, `crminfo_prospectodescripciontrabajoactual`, `crminfo_prospectofechaprimerllamada`, `crminfo_prospectofechaultimallamada`, `crminfo_prospectodescripcion`, `crminfo_prospectosucursalcerca`, `crminfo_prospectocuentaconigss`, `crminfo_prospectoañosdomicilio`, `crminfo_prospectocuentaencooperativa`, `crminfo_contactadopor`, `crminfo_prospectoreferenciado`) VALUES
(1, 1, 1, 1, 2, 1, 1, 1, 52144414, 'elderherre@gmail.com', 250.16, 0, 1500, 0, 0, '', '2020-01-01', '2020-01-01', 'probando probando', '', 0, 0, 0, NULL, NULL),
(2, 3, 1, 1, 4, 1, 2, 1, 56900142, 'fdsantiagorizzo@yahoo.com', 588, 200, 100000, 0, 2, '', '2020-01-01', '2020-01-01', '', '1', 2, 2, 2, NULL, NULL),
(3, 2, 1, 1, 3, 1, 1, 1, 47029186, 'herbert.macdonald1@gmail.com', 0, 0, 85000, 0, 0, '', '2020-01-01', '2020-01-01', 'probando probando', '', 0, 0, 0, NULL, NULL),
(4, 4, 1, 1, 2, 2, 1, 1, 37060582, 'estivenstuardo6@gmail.com', 250, 100, 50000, 0, 2, '', '2020-01-01', '2020-01-01', '1', '1', 2, 2, 2, NULL, NULL),
(5, 1, 1, 1, 1, 1, 1, 1, 52144414, 'elderherre@gmail.com', 0, 0, 1500, 0, 0, '', '2020-01-01', '2020-01-01', '', '', 0, 0, 0, 'Facebook', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crmsemaforo_estado`
--

DROP TABLE IF EXISTS `crmsemaforo_estado`;
CREATE TABLE `crmsemaforo_estado` (
  `codcrmsemaforoestado` int(11) NOT NULL,
  `crmsemaforo_estadonombre` varchar(45) DEFAULT NULL,
  `crmsemaforo_estadodescripcion` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crmsemaforo_estado`
--

INSERT INTO `crmsemaforo_estado` (`codcrmsemaforoestado`, `crmsemaforo_estadonombre`, `crmsemaforo_estadodescripcion`) VALUES
(1, 'Verde', 'Aprobado'),
(2, 'Amarillo', 'En Proceso'),
(3, 'Naranja', 'No contesta'),
(4, 'Rojo', 'No aplica');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crmtamporal_cargadedatos`
--

DROP TABLE IF EXISTS `crmtamporal_cargadedatos`;
CREATE TABLE `crmtamporal_cargadedatos` (
  `codcrmtamporalcargadedatos` int(11) NOT NULL,
  `crmtamporal_cargadedatosfecha` date DEFAULT NULL,
  `crmtamporal_cargadedatosnombre` varchar(85) DEFAULT NULL,
  `crmtamporal_cargadedatostelefono` int(11) DEFAULT NULL,
  `crmtamporal_cargadedatoscorreo` varchar(100) DEFAULT NULL,
  `crmtamporal_cargadedatosdpi` varchar(45) DEFAULT NULL,
  `crmtamporal_cargadedatoscantidad` double DEFAULT NULL,
  `crmtamporal_cargadedatosfinalidad` varchar(80) DEFAULT NULL,
  `crmtamporal_cargadedatoszona` varchar(80) DEFAULT NULL,
  `crmtamporal_cargadedatotiposervicio` int(11) DEFAULT NULL,
  `crmtamporal_cargadedatocontactadopor` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crmtamporal_cargadedatos`
--

INSERT INTO `crmtamporal_cargadedatos` (`codcrmtamporalcargadedatos`, `crmtamporal_cargadedatosfecha`, `crmtamporal_cargadedatosnombre`, `crmtamporal_cargadedatostelefono`, `crmtamporal_cargadedatoscorreo`, `crmtamporal_cargadedatosdpi`, `crmtamporal_cargadedatoscantidad`, `crmtamporal_cargadedatosfinalidad`, `crmtamporal_cargadedatoszona`, `crmtamporal_cargadedatotiposervicio`, `crmtamporal_cargadedatocontactadopor`) VALUES
(1, '2021-01-01', 'Elder Esau Herrera', 52144414, 'elderherre@gmail.com', '2990655880101', 1500, 'Unificar deudas', 'Mixco', 1, 'Facebook'),
(2, '2021-01-02', 'Francisco Santiago', 56900142, 'fdsantiagorizzo@yahoo.com', '2411548550101', 100000, 'Comprar un veh√≠culo', 'zona 11', 1, 'Facebook'),
(3, '2021-01-03', 'Hebert Fernando Mac Donald Pivaral', 47029186, 'herbert.macdonald1@gmail.com', '2990655880102', 85000, 'Unificar deudas', 'zona 13', 1, 'Facebook'),
(4, '2021-01-03', 'Estiven Estuardo Guevara Canvas', 37060582, 'estivenstuardo6@gmail.com', '2211723000114', 50000, 'Comprar un veh√≠culo', 'zona 12', 1, 'Facebook'),
(5, '2021-01-01', 'Elder Esau Herrera', 52144414, 'elderherre@gmail.com', '2990655880101', 1500, 'Unificar deudas', 'Mixco', 1, 'Facebook'),
(6, '2021-01-02', 'Francisco Santiago', 56900142, 'fdsantiagorizzo@yahoo.com', '2411548550101', 100000, 'Comprar un vehículo', 'zona 11', 1, 'Facebook'),
(7, '2021-01-03', 'Hebert Fernando Mac Donald Pivaral', 47029186, 'herbert.macdonald1@gmail.com', '2990655880102', 85000, 'Unificar deudas', 'zona 13', 1, 'Facebook'),
(8, '2021-01-03', 'Estiven Estuardo Guevara Can√&#176;s', 37060582, 'estivenstuardo6@gmail.com', '2211723000114', 50000, 'Comprar un veh√≠culo', 'zona 12', 1, 'Facebook');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crmtipo_domicilio`
--

DROP TABLE IF EXISTS `crmtipo_domicilio`;
CREATE TABLE `crmtipo_domicilio` (
  `codcrmtipodomicilio` int(11) NOT NULL,
  `crmtipo_domicilionombre` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crmtipo_domicilio`
--

INSERT INTO `crmtipo_domicilio` (`codcrmtipodomicilio`, `crmtipo_domicilionombre`) VALUES
(1, 'Casa Propia'),
(2, 'Apartamento');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crmtipo_servicio`
--

DROP TABLE IF EXISTS `crmtipo_servicio`;
CREATE TABLE `crmtipo_servicio` (
  `codcrmtiposervicio` int(11) NOT NULL,
  `crmtipo_servicionombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crmtipo_servicio`
--

INSERT INTO `crmtipo_servicio` (`codcrmtiposervicio`, `crmtipo_servicionombre`) VALUES
(1, 'Prestamos Varios');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crm_finalidadservicio`
--

DROP TABLE IF EXISTS `crm_finalidadservicio`;
CREATE TABLE `crm_finalidadservicio` (
  `codcrmfinalidadservicio` int(11) NOT NULL,
  `codcrmtiposervicio` int(11) DEFAULT NULL,
  `crm_finalidaddescripcion` varchar(300) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crm_finalidadservicio`
--

INSERT INTO `crm_finalidadservicio` (`codcrmfinalidadservicio`, `codcrmtiposervicio`, `crm_finalidaddescripcion`) VALUES
(1, 1, 'Unificar deudas');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crm_frasesdeldia`
--

DROP TABLE IF EXISTS `crm_frasesdeldia`;
CREATE TABLE `crm_frasesdeldia` (
  `idcrm_frasesdeldia` int(11) NOT NULL,
  `crm_frasesdeldianombre` varchar(600) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crm_frasesdeldia`
--

INSERT INTO `crm_frasesdeldia` (`idcrm_frasesdeldia`, `crm_frasesdeldianombre`) VALUES
(1, '“Si quieres ser excelente en algo importante, necesitas tomar el hábito en las cosas pequeñas. La excelencia no es una opción, es un actitud imperante”, Charles R. Swindoll.'),
(2, '\"Es totalmente cierto que puedes tener éxito con mayor rapidez si ayudas a otras personas a tener éxito”, Napolean Hill.'),
(3, '\"Muchas ideas crecen mejor cuando se trasplantan a otra mente diferente de la que surgieron”, Oliver Wendell Holmes.'),
(4, '\"El trabajo en equipo es la habilidad de trabajar juntos con un objetivo en común. La habilidad de lograr logros personales relacionados con los objetivos empresariales. Es la gasolina que permite a la gente común lograr resultados no comunes”, Andrew Carnegie.');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `crm_genagencias`
--

DROP TABLE IF EXISTS `crm_genagencias`;
CREATE TABLE `crm_genagencias` (
  `codcrmgenagencias` int(11) NOT NULL,
  `crm_genagenciasnombre` varchar(100) DEFAULT NULL,
  `crm_genagenciasestado` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `crm_genagencias`
--

INSERT INTO `crm_genagencias` (`codcrmgenagencias`, `crm_genagenciasnombre`, `crm_genagenciasestado`) VALUES
(2, 'AG. BOCA DEL MONTE', 1),
(3, 'AG. FLORIDA', 1),
(4, 'AG. GRAN VIA', 1),
(5, 'AG. MEGA 6', 1),
(6, 'AG. METROCENTRO', 1),
(7, 'AG. MIXCO', 1),
(8, 'AG. PACIFIC VH', 1),
(9, 'AG. PETAPA', 1),
(10, 'AG. PORTALES', 1),
(11, 'AG. SAN CRISTOBAL', 1),
(12, 'AG. SAN LUCAS', 1),
(13, 'AG. SAN NICOLAS', 1),
(14, 'AG. TERMINAL', 1),
(15, 'AG. ZONA 4', 1),
(16, 'MINI AG. METRONORTE', 1),
(17, 'AG.C.C. NARANJO MALL', 1),
(18, 'AGENCIA LOS ALAMOS', 1),
(19, 'CENTRAL ZONA 14', 1),
(20, 'KIOSCO MIRAFLORES', 1),
(21, 'KIOSCO MONSERRAT', 1),
(22, 'KIOSKO PORTALES', 1),
(23, 'MINI AG C.C. PRADERA', 1),
(24, 'STA CATARINA PINULA', 1),
(25, 'TELEMERCADEO', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_administracionlote`
--

DROP TABLE IF EXISTS `ep_administracionlote`;
CREATE TABLE `ep_administracionlote` (
  `codepadministracionlote` int(11) NOT NULL,
  `ep_administracionlotefechainicio` date DEFAULT NULL,
  `ep_administracionfechafin` date DEFAULT NULL,
  `ep_administracionloteestado` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_administracionlote`
--

INSERT INTO `ep_administracionlote` (`codepadministracionlote`, `ep_administracionlotefechainicio`, `ep_administracionfechafin`, `ep_administracionloteestado`) VALUES
(1, '2018-01-01', '2018-01-15', 0),
(2, '2021-01-01', '2021-03-05', 1),
(3, '2019-01-01', '2019-01-15', 0),
(4, '2017-01-01', '2017-01-01', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_bactivos`
--

DROP TABLE IF EXISTS `ep_bactivos`;
CREATE TABLE `ep_bactivos` (
  `codepbactivos` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_bactivosinmuebles` tinyint(1) DEFAULT NULL,
  `ep_bactivosvehiculos` tinyint(1) DEFAULT NULL,
  `ep_bactivosequipo` tinyint(1) DEFAULT NULL,
  `ep_bactivoscaja` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_bactivos`
--

INSERT INTO `ep_bactivos` (`codepbactivos`, `codepinformaciongeneralcif`, `ep_bactivosinmuebles`, `ep_bactivosvehiculos`, `ep_bactivosequipo`, `ep_bactivoscaja`) VALUES
(1, 1, 1, 1, 1, 5000),
(2, 2, 1, 1, 1, 5000),
(3, 3, 1, 1, 1, 12),
(4, 2, 1, 1, 1, 5000),
(5, 3, 1, 1, 1, 12),
(6, 2, 1, 1, 1, 5000),
(7, 3, 1, 1, 1, 12),
(8, 2, 1, 1, 1, 5000),
(9, 17, 1, 1, 1, 2500),
(10, 21, 1, 1, 1, 0),
(11, 22, 1, 1, 1, 0),
(12, 23, 1, 1, 1, 0),
(13, 24, 1, 1, 1, 0),
(14, 25, 1, 1, 1, 0),
(15, 26, 1, 1, 1, 0),
(16, 27, 1, 1, 1, 0),
(17, 28, 1, 1, 1, 0),
(18, 29, 1, 1, 1, 0),
(19, 30, 1, 1, 1, 0),
(20, 31, 1, 1, 1, 2500),
(21, 32, 1, 1, 1, 500);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_contratistaproveedor`
--

DROP TABLE IF EXISTS `ep_contratistaproveedor`;
CREATE TABLE `ep_contratistaproveedor` (
  `codepcontratistaproveedor` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_contratistaproveedor_si_no` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_contratistaproveedor`
--

INSERT INTO `ep_contratistaproveedor` (`codepcontratistaproveedor`, `codepinformaciongeneralcif`, `ep_contratistaproveedor_si_no`) VALUES
(1, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_control`
--

DROP TABLE IF EXISTS `ep_control`;
CREATE TABLE `ep_control` (
  `codepcontrol` int(11) NOT NULL,
  `codgenusuario` int(11) DEFAULT NULL,
  `codepadministracionlote` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_control`
--

INSERT INTO `ep_control` (`codepcontrol`, `codgenusuario`, `codepadministracionlote`, `codepinformaciongeneralcif`) VALUES
(1, 1, 2, 1),
(3, 3, 2, 30),
(4, 1, 1, 12),
(7, 4, 2, 20),
(8, 1, 3, 1),
(9, 1, 4, 1),
(10, 5, 2, 32),
(11, 6, 2, NULL),
(13, 2, 2, 31),
(14, 8, 4, 860949),
(15, 7, 4, 874971);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_controlingreso`
--

DROP TABLE IF EXISTS `ep_controlingreso`;
CREATE TABLE `ep_controlingreso` (
  `codepcontrolingreso` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_controlingresoingreso` tinyint(1) DEFAULT NULL,
  `ep_controlingresnegocio` tinyint(1) DEFAULT NULL,
  `ep_controlingresoremesas` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_controlingreso`
--

INSERT INTO `ep_controlingreso` (`codepcontrolingreso`, `codepinformaciongeneralcif`, `ep_controlingresoingreso`, `ep_controlingresnegocio`, `ep_controlingresoremesas`) VALUES
(1, 1, 1, 1, 127),
(2, 17, 1, 1, 1),
(3, 21, 1, 1, 1),
(4, 22, 1, 1, 1),
(5, 23, 1, 1, 1),
(6, 24, 1, 1, 1),
(7, 25, 1, 1, 1),
(8, 26, 1, 1, 1),
(9, 27, 1, 1, 1),
(10, 28, 1, 1, 1),
(11, 29, 1, 1, 1),
(12, 30, 1, 1, 1),
(13, 31, 1, 1, 1),
(14, 31, 1, 1, 1),
(15, 31, 1, 1, 1),
(16, 32, 1, 1, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_cuentas`
--

DROP TABLE IF EXISTS `ep_cuentas`;
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
  `ep_cuentasorigen` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_cuentas`
--

INSERT INTO `ep_cuentas` (`codepcuentas`, `codepinformaciongeneralcif`, `codeptipocuenta`, `codeptipomoneda`, `codeptipoestatuscuenta`, `codepinstitucion`, `codeptipocuentacooperativa`, `ep_cuentasnombre`, `ep_cuentasmonto`, `ep_cuentasorigen`) VALUES
(1, 1, 4, 1, 1, NULL, NULL, 'PedritoArrivillaga', 22, '22'),
(2, 13, 1, 1, 1, NULL, NULL, 'BI', 22, '22'),
(3, 14, 1, 1, 2, NULL, NULL, 'BI', 66, '66'),
(4, 1, 4, 1, 1, NULL, NULL, 'Pedrulo', 4500, '325'),
(5, 1, 3, 1, 1, 3, 1, 'nulo', 22, 'Herencia'),
(6, 1, 3, 1, 1, 3, 2, 'nulo', 22, 'Desembolso'),
(7, 1, 1, 1, 1, 1, NULL, 'nulo', 20000, 'Heredacion'),
(8, 1, 3, 1, 1, 3, 1, 'nulo', 2500, 'Prestamitas'),
(9, 1, 4, 1, 1, 1, NULL, 'Diego', 5000, 'Manutención del niño'),
(10, 1, 4, 1, 1, 1, NULL, 'Pablo', 5000, 'Manutención del perro'),
(11, 30, 2, 1, 2, 1, NULL, 'nulo', 564565, '856465'),
(12, 30, 1, 1, 1, 1, NULL, 'nulo', 500, 'Teo'),
(13, 30, 3, 1, 1, 3, 1, 'nulo', 5656, 'asdas'),
(14, 30, 4, 1, 1, 1, NULL, 'asdas', 6456, 'asdas'),
(15, 21, 1, 1, 1, 1, NULL, 'nulo', 500, 'Prueba'),
(16, 21, 3, 1, 1, 3, 1, 'nulo', 500, 'asdas'),
(17, 31, 3, 1, 1, 29, 1, 'nulo', 500, 'asdas'),
(18, 31, 3, 1, 1, 38, 1, 'nulo', 150, 'prueba'),
(19, 31, 4, 1, 1, 1, 1, 'Prueba', 5000, 'asdas'),
(20, 32, 3, 1, 1, 38, 2, 'nulo', 50, 'AHORROS'),
(21, 32, 3, 1, 1, 38, 2, 'nulo', 116, 'AHORROS'),
(22, 32, 3, 1, 1, 34, 2, 'nulo', 100, 'AHORROS'),
(23, 32, 3, 1, 1, 34, 2, 'nulo', 500, 'AHORROS'),
(24, 32, 4, 1, 1, 1, 1, 'Marta Julia Arevalo Chacon', 2000, 'Préstamo personal');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_cuentasporpagar`
--

DROP TABLE IF EXISTS `ep_cuentasporpagar`;
CREATE TABLE `ep_cuentasporpagar` (
  `codepcuentasporpagar` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `codeptipocuentasporpagar` int(11) DEFAULT NULL,
  `ep_cuentasporpagardescripcion` varchar(100) DEFAULT NULL,
  `ep_cuentasporpagarmonto` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_cuentasporpagar`
--

INSERT INTO `ep_cuentasporpagar` (`codepcuentasporpagar`, `codepinformaciongeneralcif`, `codeptipocuentasporpagar`, `ep_cuentasporpagardescripcion`, `ep_cuentasporpagarmonto`) VALUES
(1, 1, 1, 'Por defecto de presencia', 1500),
(2, 1, 2, 'Por efecto de manualidad', 2500),
(3, 1, 1, 'Por efecto de prestamos', 50000),
(4, 30, 1, 'sadsad', 5646),
(5, 21, 1, 'Prueba', 6564),
(6, 21, 1, 'PRUEBA', 500),
(7, 32, 2, 'universidad', 2000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_deudasvarias`
--

DROP TABLE IF EXISTS `ep_deudasvarias`;
CREATE TABLE `ep_deudasvarias` (
  `codepdeudasvarias` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_deudasvariasdescripcion` varchar(200) DEFAULT NULL,
  `ep_deudasvariasvalor` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_deudasvarias`
--

INSERT INTO `ep_deudasvarias` (`codepdeudasvarias`, `codepinformaciongeneralcif`, `ep_deudasvariasdescripcion`, `ep_deudasvariasvalor`) VALUES
(1, 1, 'CASA EN LA PLAYA', 2000),
(2, 17, 'Ella', 4500000),
(3, 21, '', 0),
(4, 22, '', 0),
(5, 23, '', 0),
(6, 24, '', 0),
(7, 25, '', 0),
(8, 26, '', 0),
(9, 27, '', 0),
(10, 28, '', 0),
(11, 29, '', 0),
(12, 30, '', 0),
(13, 31, 'Pureba', 54564),
(14, 32, 'Prestamo personal que me hizo mi hermano', 3000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_egresos`
--

DROP TABLE IF EXISTS `ep_egresos`;
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
  `ep_egresosotros` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_egresos`
--

INSERT INTO `ep_egresos` (`codepegresos`, `codinformaciongeneralcif`, `ep_egresosalimentacion`, `ep_egresostransportes`, `ep_egresosestudios`, `ep_egresosprestamo`, `ep_egresostarjeta`, `ep_egresosropa`, `ep_egresosrecreacion`, `ep_egresosotros`) VALUES
(1, 1, 100, 100, 100, 100, 100, 100, 100, 100),
(2, 17, 0, 0, 0, 0, 0, 0, 0, 0),
(3, 21, 0, 0, 0, 0, 0, 0, 0, 0),
(4, 22, 0, 0, 0, 0, 0, 0, 0, 0),
(5, 23, 0, 0, 0, 0, 0, 0, 0, 0),
(6, 24, 0, 0, 0, 0, 0, 0, 0, 0),
(7, 25, 0, 0, 0, 0, 0, 0, 0, 0),
(8, 26, 0, 0, 0, 0, 0, 0, 0, 0),
(9, 27, 0, 0, 0, 0, 0, 0, 0, 0),
(10, 28, 0, 0, 0, 0, 0, 0, 0, 0),
(11, 29, 0, 0, 0, 0, 0, 0, 0, 0),
(12, 30, 0, 0, 0, 0, 0, 0, 0, 0),
(13, 31, 564, 54656, 56456, 564, 456, 45, 564, 564),
(14, 32, 1500, 150, 0, 1000, 200, 200, 400, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_estadocivil`
--

DROP TABLE IF EXISTS `ep_estadocivil`;
CREATE TABLE `ep_estadocivil` (
  `codepestadocivil` int(11) NOT NULL,
  `ep_estadocivilnombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_estadocivil`
--

INSERT INTO `ep_estadocivil` (`codepestadocivil`, `ep_estadocivilnombre`) VALUES
(1, 'Soltero(A)'),
(2, 'Casado(A)'),
(3, 'Unido(A)'),
(4, 'Divorciado(A)'),
(5, 'Viudo(A)');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_estudio`
--

DROP TABLE IF EXISTS `ep_estudio`;
CREATE TABLE `ep_estudio` (
  `codepestudio` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_estudionombre` varchar(100) DEFAULT NULL,
  `ep_estudioaño` int(11) DEFAULT NULL,
  `ep_estudioduracion` varchar(100) DEFAULT NULL,
  `ep_estudiolugar` varchar(100) DEFAULT NULL,
  `ep_estudioidioma` varchar(100) DEFAULT NULL,
  `ep_estudiotipo` varchar(45) DEFAULT NULL,
  `ep_estudiomodalidad` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_estudio`
--

INSERT INTO `ep_estudio` (`codepestudio`, `codepinformaciongeneralcif`, `ep_estudionombre`, `ep_estudioaño`, `ep_estudioduracion`, `ep_estudiolugar`, `ep_estudioidioma`, `ep_estudiotipo`, `ep_estudiomodalidad`) VALUES
(1, 1, 'Ingenieria en sistemas', 5, '5', 'Universidad Mariano Galvez De Guatemala', 'Español', '0', 'Presencial'),
(2, 1, 'informatica', 2, '2', 'Guatemala', 'Ingles', '1', 'Virtual'),
(3, 1, 'Ingles', 5, '5', 'Guatemala', 'Español', '1', 'Presencial'),
(4, 3, '', 0, '', '', '', '1', ''),
(5, 4, '', 0, '', '', '', '0', 'sindato'),
(6, 4, '', 0, '', '', '', '1', ''),
(7, 5, '', 0, '', '', '', '0', 'sindato'),
(8, 5, '', 0, '', '', '', '1', ''),
(9, 6, '', 0, '', '', '', '0', 'sindato'),
(10, 6, '', 0, '', '', '', '1', ''),
(11, 7, '', 0, '', '', '', '0', 'sindato'),
(12, 7, '', 0, '', '', '', '1', ''),
(13, 8, '', 0, '', '', '', '0', 'sindato'),
(14, 8, '', 0, '', '', '', '1', ''),
(15, 9, '', 0, '', '', '', '0', 'sindato'),
(16, 9, '', 0, '', '', '', '1', ''),
(17, 10, '', 0, '', '', '', '0', 'sindato'),
(18, 10, '', 0, '', '', '', '1', ''),
(19, 11, '', 0, '', '', '', '0', 'sindato'),
(20, 11, '', 0, '', '', '', '1', ''),
(21, 12, '', 0, '', '', '', '0', 'sindato'),
(22, 12, '', 0, '', '', '', '1', ''),
(23, 13, '', 0, '', '', '', '0', 'sindato'),
(24, 13, '', 0, '', '', '', '1', ''),
(25, 14, '', 0, '', '', '', '0', 'sindato'),
(26, 14, '', 0, '', '', '', '1', ''),
(27, 15, '', 0, '', '', '', '0', 'sindato'),
(28, 15, '', 0, '', '', '', '1', ''),
(29, 16, 'Ingenieria en sistemas', 5, '5', 'Guatemala', 'Español', '0', 'Presencial'),
(30, 16, 'informatica', 2, '2', 'Guatemala', 'Ingles', '1', 'Virtual'),
(31, 16, 'Ingles', 5, '5', 'Guatemala', 'Español', '1', 'Presencial'),
(32, 17, 'Tecnicas de estudios', 5, '5', 'Universidad Mariano Galvez De Guatemala', 'Español', '0', ''),
(33, 1, 'Posteria', 5, '4', 'PasteriaS.A', 'Español', '1', 'Virtual'),
(34, 21, '', 0, '', '', '', '0', ''),
(35, 22, '', 0, '', '', '', '0', ''),
(36, 23, '', 0, '', '', '', '0', ''),
(37, 24, '', 0, '', '', '', '0', ''),
(38, 25, '', 0, '', '', '', '0', ''),
(39, 26, '', 0, '', '', '', '0', ''),
(40, 27, '', 0, '', '', '', '0', ''),
(41, 28, '', 0, '', '', '', '0', ''),
(42, 29, '', 0, '', '', '', '0', ''),
(43, 30, '', 0, '', '', '', '0', ''),
(44, 30, '1asdas', 3, '5', '1sadas', 'fsfsd', '1', '1asdas'),
(45, 21, 'Prueba', 2020, '5', 'Pureba', 'Español', '1', 'sadasd'),
(46, 21, 'Ingenieria en Sistemas', 2021, '10 semestre', 'Mariano Galvez', 'sinidioma', '0', 'sinmodalidad'),
(47, 2, 'Ingenieria en Sistemas', 5, '10 semestre', 'Mariano Galvez', 'sinidioma', '0', 'sinmodalidad'),
(48, 2, 'Ingles', 10, '1', 'Umg', 'Ingles', '1', '1'),
(49, 31, 'Ingenieria en Sistemas', 5, '10 semestre', 'Mariano Galvez', 'sinidioma', '0', 'sinmodalidad'),
(50, 31, 'Ingles', 2020, '1', 'Umg', 'Ingles', '1', 'Virtual'),
(51, 32, 'Ingenieria', 5, 'Pensum Cerrado', 'San Carlos de Guatemala', 'sinidioma', '0', 'sinmodalidad'),
(52, 32, 'Economia', 3, '6', 'San Carlos de Guatemala', 'sinidioma', '0', 'sinmodalidad'),
(53, 32, 'Excel avanzado', 2020, '100', 'Intecap', 'Español', '1', 'Virtual'),
(54, 32, 'Excel intermedio', 2020, '100', 'Intecap', 'Español', '1', 'Virtual');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_infofamiliar`
--

DROP TABLE IF EXISTS `ep_infofamiliar`;
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
  `ep_infofamiliarnumeroemergencia` int(11) DEFAULT NULL,
  `ep_infofamiliarparentesco` varchar(50) DEFAULT NULL,
  `ep_infofamiliarcomentario` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_infofamiliar`
--

INSERT INTO `ep_infofamiliar` (`codepinfofamiliar`, `codepinformaciongeneralcif`, `ep_infofamiliarnombreconyuge`, `ep_infofamiliarnombrehijos`, `ep_infofamiliarocupacionconyuge`, `ep_infofamiliarocupacionhijos`, `ep_infofamiliarapellidocascada`, `ep_infofamiliarfechanacimientoconyuge`, `ep_infofamiliarfechanacimientohijo`, `ep_infofamiliarnombreemergencia`, `ep_infofamiliarnumeroemergencia`, `ep_infofamiliarparentesco`, `ep_infofamiliarcomentario`) VALUES
(1, 1, 'Maria', 'Pedro', 'Estudiante', 'Estudiante', 'Juarez', '2020-04-24', '2020-04-08', 'Pedro', 24358599, 'Tio', 'Es responsable'),
(2, 1, 'Maria', 'Pepe', 'Estudiante', 'Futbolero', 'Juarez', '2020-04-24', '2020-04-10', 'Pedro', 24358599, 'Tio', 'El primer hijo'),
(3, 5, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(4, 6, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(5, 7, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(6, 8, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(7, 9, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(8, 10, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(9, 11, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(10, 12, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(11, 13, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(12, 14, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(13, 15, '', '', '', '', '', '2020-04-24', '2020-04-24', '', 0, '', ''),
(16, 17, '', '', '', '', '', '2020-04-24', '0000-00-00', 'Alejandro', 222, 'Tio', ''),
(17, 1, 'Maria', '', 'Estudiante', '', 'Juarez', '2020-04-24', '2020-04-25', 'Pedro', 24358599, 'Tio', ''),
(18, 1, 'Maria', 'Luis', 'Estudiante', 'Futbol', 'Juarez', '2020-04-24', '2020-04-25', 'Pedro', 24358599, 'Tio', 'Hola'),
(19, 1, 'Maria', 'sdaasd', 'Estudiante', 'sadas', 'Juarez', '2020-04-24', '2020-04-15', 'Pedro', 24358599, 'Tio', 'dasd'),
(20, 21, '', '', '', '', '', '0001-01-01', '0000-00-00', 'Prueba', 123456, 'Prueba', ''),
(21, 20, '', 'Keys', '', 'asdsa', '', '0000-00-00', '2020-04-22', '', 0, '', 'sadas'),
(22, 22, '', '', '', '', '', '0000-00-00', '0000-00-00', '', 0, '', ''),
(23, 23, '', '', '', '', '', '0000-00-00', '0000-00-00', '', 0, '', ''),
(24, 24, '', '', '', '', '', '0000-00-00', '0000-00-00', '', 0, '', ''),
(25, 25, '', '', '', '', '', '0000-00-00', '0000-00-00', '', 0, '', ''),
(26, 26, '', '', '', '', '', '0000-00-00', '0000-00-00', '', 0, '', ''),
(27, 27, '', '', '', '', '', '0000-00-00', '0000-00-00', '', 0, '', ''),
(28, 28, '', '', '', '', '', '0000-00-00', '0000-00-00', '', 0, '', ''),
(29, 29, '', '', '', '', '', '0000-00-00', '0000-00-00', '', 0, '', ''),
(30, 30, '', '', '', '', '', '0000-00-00', '0000-00-00', '', 0, '', ''),
(31, 30, '', 'Diego', '', 'sadas', '', '0000-00-00', '2020-04-22', '', 0, '', 'asdasdas'),
(32, 30, '', 'Diego', '', 'sadas', '', '0000-00-00', '2020-04-22', '', 0, '', 'asdasdas'),
(33, 30, '', 'Diego', '', 'sadas', '', '0000-00-00', '2020-04-22', '', 0, '', 'asdasdas'),
(34, 30, '', 'sadsa', '', 'asdas', '', '0000-00-00', '2020-04-25', '', 0, '', 'adasd'),
(35, 31, '', '', '', '', '', '2020-04-24', '0000-00-00', 'Prueba', 54564, 'Prueba', ''),
(36, 31, '', 'Prueba', '', 'Estudiante', '', '2020-04-24', '2020-04-25', 'Prueba', 54564, 'Prueba', 'saasda'),
(37, 31, '', 'asdsa', '', 'asdsad', '', '2020-04-24', '2020-04-23', 'Prueba', 54564, 'Prueba', 'asdasd'),
(38, 31, '', 'Keys', '', 'sadas', '', '0000-00-00', '2020-04-07', '', 0, '', 'asdas'),
(39, 32, 'Marta Julia Arevalo Chacon', '', 'Perito Contador', '', 'Herrera', '1977-09-25', '2020-04-08', 'Marta Julia Arevalo Chacon de Herrera', 54858554, 'Esposa', ''),
(40, 32, 'Marta Julia Arevalo Chacon', 'Karla Daniela Herrera Arevalo', 'Perito Contador', 'Ninguna', 'Herrera', '1977-09-25', '2018-01-15', 'Marta Julia Arevalo Chacon de Herrera', 54858554, 'Esposa', ''),
(41, 32, 'Marta Julia Arevalo Chacon', 'Carlos Daniel Herrera Arevalo', 'Perito Contador', 'Estudiante', 'Herrera', '1977-09-25', '2014-01-15', 'Marta Julia Arevalo Chacon de Herrera', 54858554, 'Esposa', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_informaciongeneral`
--

DROP TABLE IF EXISTS `ep_informaciongeneral`;
CREATE TABLE `ep_informaciongeneral` (
  `codepinformaciongeneralcif` int(11) NOT NULL,
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
  `ep_informaciongeneralnumeroidentificacion` int(11) DEFAULT NULL,
  `ep_informaciongeneralnacionalidad` varchar(25) DEFAULT NULL,
  `ep_informaciongeneraldireccion` varchar(100) DEFAULT NULL,
  `ep_informaciongeneralestatura` int(11) DEFAULT NULL,
  `ep_informaciongeneralpeso` int(11) DEFAULT NULL,
  `ep_informaciongeneralreligion` varchar(20) DEFAULT NULL,
  `ep_informaciongeneralcorreo` varchar(50) DEFAULT NULL,
  `codgenpuesto` int(11) DEFAULT NULL,
  `ep_informaciongeneralfechaboda` date DEFAULT NULL,
  `ep_informaciongeneralcif` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_informaciongeneral`
--

INSERT INTO `ep_informaciongeneral` (`codepinformaciongeneralcif`, `codgensucursal`, `codepestadocivil`, `codgentipoidentificacion`, `codgendepartamento`, `codgenmunicipio`, `codgenzona`, `codgenarea`, `codeptipoestado`, `ep_informaciongeneralprimernombre`, `ep_informaciongeneralsegundonombre`, `ep_informaciongeneralprimerapellido`, `ep_informaciongeneralsegundoapellido`, `ep_informaciongeneralnombreadicional`, `ep_informaciongeneralfechanacimiento`, `ep_informaciongeneralnit`, `ep_informaciongeneralnumeroidentificacion`, `ep_informaciongeneralnacionalidad`, `ep_informaciongeneraldireccion`, `ep_informaciongeneralestatura`, `ep_informaciongeneralpeso`, `ep_informaciongeneralreligion`, `ep_informaciongeneralcorreo`, `codgenpuesto`, `ep_informaciongeneralfechaboda`, `ep_informaciongeneralcif`) VALUES
(1, 1, 2, 1, 1, 102, 1, 1, 2, 'Jose', 'Alejandro', 'Teo', 'Gonzalez', '', '1999-01-27', '10104', 2147483647, 'Guatemala', 'Zona 7 Guatemala', 12, 25, 'Catolico', 'jose.ale@guadalapuna.com.gt', 1, '2020-04-24', 123),
(2, 1, 2, 1, 1, 102, 1, 1, 2, '', 'Alejandro', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', 1, '0000-00-00', 1000),
(3, 2, 2, 1, 1, 102, 2, 2, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 455),
(4, 1, 1, 1, 1, 102, 1, 1, 2, 'Jose', 'Alejandro', 'Gonzalez', 'Teo', '', '2018-07-22', '239955', 2555, 'Guatemalteca', 'Zona 7 bethania ', 22, 22, '2', '22', NULL, '0000-00-00', 13222),
(5, 1, 1, 1, 1, 102, 1, 1, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 12225),
(6, 1, 1, 1, 1, 102, 1, 2, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 1555),
(7, 1, 1, 1, 1, 102, 1, 2, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 1444),
(8, 1, 1, 1, 1, 102, 1, 2, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 55555),
(9, 1, 1, 1, 1, 102, 1, 1, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 5151),
(10, 1, 3, 1, 1, 102, 2, 2, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 333),
(11, 1, 2, 1, 1, 102, 1, 1, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 555),
(12, 1, 3, 1, 2, 102, 1, 1, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 333),
(13, 1, 4, 1, 1, 102, 1, 1, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 22),
(14, 1, 2, 1, 2, 102, 1, 1, 1, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 666),
(15, 1, 3, 1, 2, 102, 2, 1, 2, 'Esgar', 'Ruben', 'Cassola', 'Casasola2', 'Gustavo', '2018-07-22', '22525545', 0, 'Guatemalteca', 'zona 7', 12, 12, '12', '12', NULL, '0000-00-00', 55555),
(16, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0000-00-00', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 1),
(17, 1, 1, 1, 1, 102, 1, 1, 2, 'Ruben', 'Edgar', 'Chuy', 'Ruiz', '', '2014-02-05', '239955', 85995959, 'Guatemalteca', '', 22, 22, '22', '22', NULL, '2020-04-24', 1234568),
(18, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0000-00-00', '', 0, '', '', 0, 0, '', '', NULL, '0000-00-00', 1),
(19, 1, 1, 1, 1, 102, 1, 1, 2, '', '', 'Gonzalez', 'Teo', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 1),
(20, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 0),
(21, 1, 1, 1, 1, 102, 1, 1, 2, 'Diego', 'asdsadsad', 'Gomez', 'Giron', '', '2018-07-22', '123456', 45646556, 'Guatemalñteco', 'zona 1', 10, 0, '', '', NULL, '0001-01-01', 2425232),
(22, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 0),
(23, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 0),
(24, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 0),
(25, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 0),
(26, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 0),
(27, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 0),
(28, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 0),
(29, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '0001-01-01', '', 0, '', '', 0, 0, '', '', NULL, '0001-01-01', 0),
(30, 1, 1, 1, 1, 102, 1, 1, 2, '', '', '', '', '', '2018-07-22', '', 0, '', '', 0, 0, '', '', NULL, '2020-04-24', 0),
(31, 6, 1, 1, 1, 101, 17, 32, 2, 'Diego', 'Jose', 'Gomez', 'Giron', '', '2018-07-22', '21867957', 123456, 'Guatemalteco', 'Guatemala', 21, 21, 'Catolico', 'dj_2425_gomez@hotmail.com', 278, '2020-04-24', 1234),
(32, 6, 2, 1, 1, 115, 4, 32, 2, 'Esdras', 'Josue', 'Herrera', 'Martinez', 'Antonio', '1976-12-11', '1612115-5', 2147483647, 'GUATEMALTECO', 'FRACCIÓN 4 LOTE 16 GRANJA ITALIA APTO. 511 ', 16, 180, 'Católico       ', 'esdras.herrera@micoopeguadalupana.com.gt', 279, '2013-12-20', 944070),
(33, 1, 1, 1, 1, 101, 1, 1, 1, '1', '1', '1', '1', '1', '0000-00-00', '1', 1, '1', '1', 1, 1, '1', '1', 1, '2013-12-20', 860949),
(34, 1, 1, 1, 1, 101, 1, 1, 1, '1', '1', '1', '1', '1', '0000-00-00', '1', 1, '1', '1', 1, 1, '1', '1', 1, '0000-00-00', 874971);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_ingreso`
--

DROP TABLE IF EXISTS `ep_ingreso`;
CREATE TABLE `ep_ingreso` (
  `codepingreso` int(11) NOT NULL,
  `codepcontrolingreso` int(11) DEFAULT NULL,
  `ep_ingresosueldo` double DEFAULT NULL,
  `ep_ingresobonificacion` double DEFAULT NULL,
  `ep_ingresocomisiones` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_ingreso`
--

INSERT INTO `ep_ingreso` (`codepingreso`, `codepcontrolingreso`, `ep_ingresosueldo`, `ep_ingresobonificacion`, `ep_ingresocomisiones`) VALUES
(1, 1, 5000, 300, 100),
(2, 2, 50000, 250, 5220),
(3, 3, 0, 0, 0),
(4, 4, 0, 0, 0),
(5, 5, 0, 0, 0),
(6, 6, 0, 0, 0),
(7, 7, 0, 0, 0),
(8, 8, 0, 0, 0),
(9, 9, 0, 0, 0),
(10, 10, 0, 0, 0),
(11, 11, 0, 0, 0),
(12, 12, 0, 0, 0),
(13, 13, 546, 45564, 6546),
(14, 14, 0, 0, 0),
(15, 15, 0, 0, 0),
(16, 16, 4000, 250, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_inmueble`
--

DROP TABLE IF EXISTS `ep_inmueble`;
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
  `ep_inmueblefinca` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_inmueble`
--

INSERT INTO `ep_inmueble` (`codepinmueble`, `codeptipoinmueble`, `codepinformaciongeneralcif`, `ep_inmueblefolio`, `ep_inmueblelibro`, `ep_inmuebledireccion`, `ep_inmueblevalor`, `ep_inmuebledescripcion`, `ep_inmueblecomentario`, `ep_inmueblefinca`) VALUES
(1, 1, 1, '12', '1', 'Guatemala Zona 7', 2500, 'ES MUY CARO', '', 'Finquero'),
(2, 2, 1, '1', '1', 'Guatemala Zona 3', 1500, 'Completo', NULL, NULL),
(3, 1, 16, '12', '1', 'Guatemala Zona 7', 2500, 'ES MUY CARO', NULL, NULL),
(4, 2, 16, '1', '1', 'Guatemala Zona 3', 1500, 'Completo', NULL, NULL),
(5, 1, 1, '25', '15', 'Zona 4 la estación central del momo', 20000, 'Es un lugar que contiene bosque', NULL, NULL),
(6, 2, 1, '3', '3', '3', 3, '3', NULL, NULL),
(7, 1, 30, 'adsa', 'asd', 'asda', 5465, 'asda', NULL, NULL),
(8, 1, 21, 'Prueba', 'Prueba', 'Ciudad', 500, 'Prueba', NULL, NULL),
(9, 1, 31, 'as', 'ads', 'ciuda', 546, 'acsc', 'ada', 'asd'),
(10, 2, 32, '365', '11E', 'FRACCIÓN 4 LOTE 16 GRANJA ITALIA APTO. 511 , ZONA ', 95000, 'CASA PROPIA', '', '5365');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_institucion`
--

DROP TABLE IF EXISTS `ep_institucion`;
CREATE TABLE `ep_institucion` (
  `codepinstitucion` int(11) NOT NULL,
  `codeptipoinstitucion` int(11) DEFAULT NULL,
  `ep_institucionnombre` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_institucion`
--

INSERT INTO `ep_institucion` (`codepinstitucion`, `codeptipoinstitucion`, `ep_institucionnombre`) VALUES
(1, 1, 'El Crédito Hipotecario Nacional de Guatemala'),
(2, 1, 'Banco Inmobiliario, S. A.'),
(3, 1, 'Banco de los Trabajadores'),
(4, 1, 'Banco Industrial, S. A.'),
(5, 1, 'Banco de Desarrollo Rural, S. A.'),
(6, 1, 'Banco Internacional, S. A.'),
(7, 1, 'Citibank, N.A., Sucursal Guatemala'),
(8, 1, 'Vivibanco, S. A.'),
(9, 1, 'Banco Ficohsa Guatemala, S. A'),
(10, 1, 'Banco Promerica, S. A.'),
(11, 1, 'Banco de Antigua, S. A.'),
(12, 1, 'Banco de América Central, S. A.'),
(13, 1, 'Banco Agromercantil de Guatemala, S. A.'),
(14, 1, 'Banco G&T Continental, S. A.'),
(15, 1, 'Banco Azteca de Guatemala, S. A.'),
(16, 1, 'Banco INV, S. A.'),
(17, 1, 'Banco Credicorp, S. A. (1)'),
(18, 2, 'Corporación Financiera Nacional '),
(19, 2, 'Financiera Industrial, S. A.'),
(20, 2, 'Financiera Rural, S. A. '),
(21, 2, 'Financiera de Capitales, S. A. '),
(22, 2, 'Financiera Summa, S. A.'),
(23, 2, 'Financiera Progreso, S. A.'),
(24, 2, 'Financiera Agromercantil, S. A.'),
(25, 2, 'Financiera MVA, S. A. '),
(26, 2, 'Financiera Consolidada, S. A.'),
(27, 2, 'Financiera de los Trabajadores, S. A.'),
(28, 2, 'Financiera G & T Continental, S. A.'),
(29, 3, 'FENACOAC'),
(30, 3, 'COOP. GUAYACAN'),
(31, 3, 'COOSADECO'),
(32, 3, 'COOSAJO'),
(33, 3, 'COOP. UNION POPULAR'),
(34, 3, 'COOP. UPA'),
(35, 3, 'COOP. GUALAN'),
(36, 3, 'COOP. COBAN'),
(37, 3, 'COOP. TECULUTAN'),
(38, 3, 'PARROQUIAL GUADALUPANA'),
(39, 3, 'COOP. TONANTEL'),
(40, 3, 'COOP. HORIZONTES'),
(41, 3, 'COOP. COMALAPA'),
(42, 3, 'COOP. BIENESTAR'),
(43, 3, 'COOP. MOYUTAN'),
(44, 3, 'COOP. CHIQUIMULA'),
(45, 3, 'COSAMI'),
(46, 3, 'COOP. SALCAJA'),
(47, 3, 'ACREDICOM'),
(48, 3, 'COLUA'),
(49, 3, 'COOSANJER'),
(50, 3, 'COOPSAMA'),
(51, 3, 'COOP. SOLOMA'),
(52, 3, 'COOP. ENCARNACION'),
(53, 3, 'ECOSABA'),
(54, 3, 'COOP. YAMAN KUTZ'),
(55, 3, 'COTONEB'),
(56, 4, 'Microfinanciera');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_inventario`
--

DROP TABLE IF EXISTS `ep_inventario`;
CREATE TABLE `ep_inventario` (
  `codepinventario` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_inventarionombre` varchar(50) DEFAULT NULL,
  `ep_inventariodescripcion` varchar(200) DEFAULT NULL,
  `ep_inventariomonto` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_inventario`
--

INSERT INTO `ep_inventario` (`codepinventario`, `codepinformaciongeneralcif`, `ep_inventarionombre`, `ep_inventariodescripcion`, `ep_inventariomonto`) VALUES
(1, 1, 'Mercaderia de computadoras', 'MERCADERIA DE TELA', 5000),
(2, 17, '50 Kilos de tela', '', 25000),
(3, 21, '', '', 0),
(4, 22, '', '', 0),
(5, 23, '', '', 0),
(6, 24, '', '', 0),
(7, 25, '', '', 0),
(8, 26, '', '', 0),
(9, 27, '', '', 0),
(10, 28, '', '', 0),
(11, 29, '', '', 0),
(12, 30, '', '', 0),
(13, 31, 'Prueba', '', 500),
(14, 32, 'Herramientas varias', '', 5000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_inversiones`
--

DROP TABLE IF EXISTS `ep_inversiones`;
CREATE TABLE `ep_inversiones` (
  `codepinversiones` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `codeptipoinstitucion` int(11) DEFAULT NULL,
  `codepinstitucion` int(11) DEFAULT NULL,
  `codeptipomoneda` int(11) DEFAULT NULL,
  `ep_inversionesnombre` varchar(100) DEFAULT NULL,
  `ep_inversionesplazo` varchar(100) DEFAULT NULL,
  `ep_inversionesmonto` double DEFAULT NULL,
  `ep_inversionesorigen` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_inversiones`
--

INSERT INTO `ep_inversiones` (`codepinversiones`, `codepinformaciongeneralcif`, `codeptipoinstitucion`, `codepinstitucion`, `codeptipomoneda`, `ep_inversionesnombre`, `ep_inversionesplazo`, `ep_inversionesmonto`, `ep_inversionesorigen`) VALUES
(1, 1, 1, 1, 1, 'Inversion mi ahorrito', '5', 2500, 'Sueldo promediado'),
(2, 31, 1, 3, 1, 'sinnombre', '5', 500, '100'),
(3, 32, 3, 38, 1, 'sinnombre', '', 40000, 'Liquidacion de pasivo laboral');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_maquinaria`
--

DROP TABLE IF EXISTS `ep_maquinaria`;
CREATE TABLE `ep_maquinaria` (
  `codepmaquinaria` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_maquinarianombre` varchar(45) DEFAULT NULL,
  `ep_maquinariadescripcion` varchar(100) DEFAULT NULL,
  `ep_maquinariamonto` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_maquinaria`
--

INSERT INTO `ep_maquinaria` (`codepmaquinaria`, `codepinformaciongeneralcif`, `ep_maquinarianombre`, `ep_maquinariadescripcion`, `ep_maquinariamonto`) VALUES
(1, 1, 'Excavadora', 'Maquina de construccion', 500000),
(2, 17, 'Excavadora2', 'Maquina de construccion', 50000),
(3, 21, '', '', 0),
(4, 22, '', '', 0),
(5, 23, '', '', 0),
(6, 24, '', '', 0),
(7, 25, '', '', 0),
(8, 26, '', '', 0),
(9, 27, '', '', 0),
(10, 28, '', '', 0),
(11, 29, '', '', 0),
(12, 30, '', '', 0),
(13, 31, 'sadsa', 'adsasdas', 4556),
(14, 32, 'Maquinas de coser', 'Poseo 2 maquinas de coser', 4000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_menajecasadetalle`
--

DROP TABLE IF EXISTS `ep_menajecasadetalle`;
CREATE TABLE `ep_menajecasadetalle` (
  `codepmenajecasadetalle` int(11) NOT NULL,
  `codmenajedecasaencabezado` int(11) DEFAULT NULL,
  `codeptipobien` int(11) DEFAULT NULL,
  `ep_menajecasadetallecantidad` int(11) DEFAULT NULL,
  `ep_menajecasadetallevalor` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_menajecasadetalle`
--

INSERT INTO `ep_menajecasadetalle` (`codepmenajecasadetalle`, `codmenajedecasaencabezado`, `codeptipobien`, `ep_menajecasadetallecantidad`, `ep_menajecasadetallevalor`) VALUES
(1, 1, 9, 1, 50),
(2, 2, 9, 0, 0),
(3, 2, 9, 0, 0),
(4, 2, 9, 0, 0),
(5, 2, 9, 0, 0),
(6, 2, 9, 0, 0),
(7, 2, 9, 0, 0),
(8, 2, 9, 0, 0),
(9, 2, 9, 0, 0),
(10, 2, 9, 0, 0),
(11, 2, 9, 0, 0),
(12, 3, 1, 0, 100),
(13, 3, 2, 0, 500),
(14, 3, 3, 0, 100),
(15, 3, 4, 2, 2500),
(16, 3, 5, 1, 1500),
(17, 3, 6, 2, 500),
(18, 3, 7, 1, 500),
(19, 3, 8, 1, 5000),
(20, 3, 9, 1, 3500),
(21, 3, 10, 5, 4500),
(22, 3, 11, 0, 0),
(23, 4, 1, 0, 0),
(24, 4, 2, 0, 0),
(25, 4, 3, 0, 0),
(26, 4, 4, 0, 0),
(27, 4, 5, 0, 0),
(28, 4, 6, 0, 0),
(29, 4, 7, 0, 0),
(30, 4, 8, 0, 0),
(31, 4, 9, 0, 0),
(32, 4, 10, 0, 0),
(33, 4, 11, 0, 0),
(34, 5, 1, 0, 0),
(35, 5, 2, 0, 0),
(36, 5, 3, 0, 0),
(37, 5, 4, 0, 0),
(38, 5, 5, 0, 0),
(39, 5, 6, 0, 0),
(40, 5, 7, 0, 0),
(41, 5, 8, 0, 0),
(42, 5, 9, 0, 0),
(43, 5, 10, 0, 0),
(44, 5, 11, 0, 0),
(45, 6, 1, 0, 0),
(46, 6, 2, 0, 0),
(47, 6, 3, 0, 0),
(48, 6, 4, 0, 0),
(49, 6, 5, 0, 0),
(50, 6, 6, 0, 0),
(51, 6, 7, 0, 0),
(52, 6, 8, 0, 0),
(53, 6, 9, 0, 0),
(54, 6, 10, 0, 0),
(55, 6, 11, 0, 0),
(56, 7, 1, 0, 0),
(57, 7, 2, 0, 0),
(58, 7, 3, 0, 0),
(59, 7, 4, 0, 0),
(60, 7, 5, 0, 0),
(61, 7, 6, 0, 0),
(62, 7, 7, 0, 0),
(63, 7, 8, 0, 0),
(64, 7, 9, 0, 0),
(65, 7, 10, 0, 0),
(66, 7, 11, 0, 0),
(67, 8, 1, 0, 0),
(68, 8, 2, 0, 0),
(69, 8, 3, 0, 0),
(70, 8, 4, 0, 0),
(71, 8, 5, 0, 0),
(72, 8, 6, 0, 0),
(73, 8, 7, 0, 0),
(74, 8, 8, 0, 0),
(75, 8, 9, 0, 0),
(76, 8, 10, 0, 0),
(77, 8, 11, 0, 0),
(78, 9, 1, 0, 0),
(79, 9, 2, 0, 0),
(80, 9, 3, 0, 0),
(81, 9, 4, 0, 0),
(82, 9, 5, 0, 0),
(83, 9, 6, 0, 0),
(84, 9, 7, 0, 0),
(85, 9, 8, 0, 0),
(86, 9, 9, 0, 0),
(87, 9, 10, 0, 0),
(88, 9, 11, 0, 0),
(89, 10, 1, 0, 0),
(90, 10, 2, 0, 0),
(91, 10, 3, 0, 0),
(92, 10, 4, 0, 0),
(93, 10, 5, 0, 0),
(94, 10, 6, 0, 0),
(95, 10, 7, 0, 0),
(96, 10, 8, 0, 0),
(97, 10, 9, 0, 0),
(98, 10, 10, 0, 0),
(99, 10, 11, 0, 0),
(100, 11, 1, 0, 0),
(101, 11, 2, 0, 0),
(102, 11, 3, 0, 0),
(103, 11, 4, 0, 0),
(104, 11, 5, 0, 0),
(105, 11, 6, 0, 0),
(106, 11, 7, 0, 0),
(107, 11, 8, 0, 0),
(108, 11, 9, 0, 0),
(109, 11, 10, 0, 0),
(110, 11, 11, 0, 0),
(111, 12, 1, 0, 0),
(112, 12, 2, 0, 0),
(113, 12, 3, 0, 0),
(114, 12, 4, 0, 0),
(115, 12, 5, 0, 0),
(116, 12, 6, 0, 0),
(117, 12, 7, 0, 0),
(118, 12, 8, 0, 0),
(119, 12, 9, 0, 0),
(120, 12, 10, 0, 0),
(121, 12, 11, 0, 0),
(122, 13, 1, 0, 499),
(123, 13, 2, 0, 500),
(124, 13, 3, 0, 501),
(125, 13, 4, 5, 51213),
(126, 13, 5, 2, 555),
(127, 13, 6, 1, 12),
(128, 13, 7, 1, 561),
(129, 13, 8, 2, 45),
(130, 13, 9, 1, 5465),
(131, 13, 10, 1, 5465),
(132, 13, 11, 0, 4654),
(133, 14, 1, 0, 2000),
(134, 14, 2, 0, 1500),
(135, 14, 3, 0, 800),
(136, 14, 4, 1, 3500),
(137, 14, 5, 1, 2000),
(138, 14, 6, 0, 0),
(139, 14, 7, 0, 0),
(140, 14, 8, 1, 1500),
(141, 14, 9, 1, 2500),
(142, 14, 10, 1, 2000),
(143, 14, 11, 1, 5000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_menajedecasaencabezado`
--

DROP TABLE IF EXISTS `ep_menajedecasaencabezado`;
CREATE TABLE `ep_menajedecasaencabezado` (
  `codepmenajedecasaencabezado` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_menajedecabezatotal` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_menajedecasaencabezado`
--

INSERT INTO `ep_menajedecasaencabezado` (`codepmenajedecasaencabezado`, `codepinformaciongeneralcif`, `ep_menajedecabezatotal`) VALUES
(1, 1, 2500),
(2, 17, 0),
(3, 21, 0),
(4, 22, 0),
(5, 23, 0),
(6, 24, 0),
(7, 25, 0),
(8, 26, 0),
(9, 27, 0),
(10, 28, 0),
(11, 29, 0),
(12, 30, 0),
(13, 31, 0),
(14, 32, 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_negocio`
--

DROP TABLE IF EXISTS `ep_negocio`;
CREATE TABLE `ep_negocio` (
  `codepnegocio` int(11) NOT NULL,
  `codepcontrolingreso` int(11) DEFAULT NULL,
  `ep_negocionombre` varchar(50) DEFAULT NULL,
  `ep_negociopatente` varchar(20) DEFAULT NULL,
  `ep_negocioempleados` int(11) DEFAULT NULL,
  `ep_negociodireccion` varchar(50) DEFAULT NULL,
  `ep_negocioingresos` double DEFAULT NULL,
  `ep_negocioegresos` double DEFAULT NULL,
  `ep_negociotipo` varchar(50) DEFAULT NULL,
  `ep_negocioobjeto` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_negocio`
--

INSERT INTO `ep_negocio` (`codepnegocio`, `codepcontrolingreso`, `ep_negocionombre`, `ep_negociopatente`, `ep_negocioempleados`, `ep_negociodireccion`, `ep_negocioingresos`, `ep_negocioegresos`, `ep_negociotipo`, `ep_negocioobjeto`) VALUES
(1, 1, '33', '33', 33, '33 av zona 7', 33, 33, '2500', '33'),
(2, 2, '', '', 0, '', 0, 0, '', ''),
(3, 3, '', '', 0, '', 0, 0, '', ''),
(4, 4, '', '', 0, '', 0, 0, '', ''),
(5, 5, '', '', 0, '', 0, 0, '', ''),
(6, 6, '', '', 0, '', 0, 0, '', ''),
(7, 7, '', '', 0, '', 0, 0, '', ''),
(8, 8, '', '', 0, '', 0, 0, '', ''),
(9, 9, '', '', 0, '', 0, 0, '', ''),
(10, 10, '', '', 0, '', 0, 0, '', ''),
(11, 11, '', '', 0, '', 0, 0, '', ''),
(12, 12, '', '', 0, '', 0, 0, '', ''),
(13, 13, '', '0', 0, '', 0, 0, '', '0'),
(14, 14, '', '', 0, '', 0, 0, '', ''),
(15, 15, '', '', 0, '', 0, 0, '', ''),
(16, 16, '', '0', 0, '', 1000, 18, 'LOS PATITOS', '2500');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_pasivocontigente`
--

DROP TABLE IF EXISTS `ep_pasivocontigente`;
CREATE TABLE `ep_pasivocontigente` (
  `codeppasivocontigente` int(11) NOT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_pasivocontigenombre` varchar(100) DEFAULT NULL,
  `ep_pasivocontigentedeudor` varchar(100) DEFAULT NULL,
  `ep_pasivocontigentefechadesembolso` date DEFAULT NULL,
  `ep_pasivocontigentefechafinalizacion` date DEFAULT NULL,
  `ep_pasivocontigentesaldo` double DEFAULT NULL,
  `ep_pasivocontigentecondeudor` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_pasivocontigente`
--

INSERT INTO `ep_pasivocontigente` (`codeppasivocontigente`, `codepinformaciongeneralcif`, `ep_pasivocontigenombre`, `ep_pasivocontigentedeudor`, `ep_pasivocontigentefechadesembolso`, `ep_pasivocontigentefechafinalizacion`, `ep_pasivocontigentesaldo`, `ep_pasivocontigentecondeudor`) VALUES
(1, 1, 'Organismo Judicial', 'Pablo picasso', '2020-04-26', '2021-05-26', 25500, 'LE DEVO POR UN PAPELEO'),
(2, 17, 'Casa de edgar', 'Edgar', '2020-04-01', '2020-04-30', 25000, 'Familiar'),
(3, 21, '', '', '2020-04-24', '0001-01-01', 0, ''),
(4, 22, '', '', '0000-00-00', '0000-00-00', 0, ''),
(5, 23, '', '', '0000-00-00', '0000-00-00', 0, ''),
(6, 24, '', '', '0000-00-00', '0000-00-00', 0, ''),
(7, 25, '', '', '0000-00-00', '0000-00-00', 0, ''),
(8, 26, '', '', '0000-00-00', '0000-00-00', 0, ''),
(9, 27, '', '', '0000-00-00', '0000-00-00', 0, ''),
(10, 28, '', '', '0000-00-00', '0000-00-00', 0, ''),
(11, 29, '', '', '0000-00-00', '0000-00-00', 0, ''),
(12, 30, '', '', '0000-00-00', '0000-00-00', 0, ''),
(13, 31, 'Prueba', 'Prueba', '2020-04-24', '0001-01-01', 131432, 'asdsa'),
(14, 32, '', '', '2020-04-24', '0001-01-01', 0, '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_personapep`
--

DROP TABLE IF EXISTS `ep_personapep`;
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
  `ep_personapepmotivo` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_personapep`
--

INSERT INTO `ep_personapep` (`codeppersonapep`, `codeptipopep`, `codepinformaciongeneralcif`, `codeptiponacionalidad`, `codeptipoparentesco`, `ep_personapepnombre`, `ep_personapepnombreinstitucion`, `ep_personapeppuesto`, `ep_personapeppais`, `ep_personapepmotivo`) VALUES
(1, 1, 1, NULL, NULL, NULL, '', '', '', NULL),
(2, 2, 1, 1, 4, 'Rosaura Perez', 'Relationshi', 'Desarollador', 'Guatemala', NULL),
(3, 3, 1, 2, 2, 'Luisa Fernandez', 'Makoto', 'Decorador', 'Guatemala', 'una deuda por choque'),
(4, 1, 17, 1, 1, '', '', '', '', ''),
(5, 2, 17, 1, 1, '', '', '', '', ''),
(6, 3, 17, 1, 1, '', '', '', '', ''),
(7, 1, 21, 1, 1, '', '', '', '', ''),
(8, 2, 21, 1, 1, '', '', '', '', ''),
(9, 3, 21, 1, 1, '', '', '', '', ''),
(10, 1, 22, 1, 1, '', '', '', '', ''),
(11, 2, 22, 1, 1, '', '', '', '', ''),
(12, 3, 22, 1, 1, '', '', '', '', ''),
(13, 1, 23, 1, 1, '', '', '', '', ''),
(14, 2, 23, 1, 1, '', '', '', '', ''),
(15, 3, 23, 1, 1, '', '', '', '', ''),
(16, 1, 24, 1, 1, '', '', '', '', ''),
(17, 2, 24, 1, 1, '', '', '', '', ''),
(18, 3, 24, 1, 1, '', '', '', '', ''),
(19, 1, 25, 1, 1, '', '', '', '', ''),
(20, 2, 25, 1, 1, '', '', '', '', ''),
(21, 3, 25, 1, 1, '', '', '', '', ''),
(22, 1, 26, 1, 1, '', '', '', '', ''),
(23, 2, 26, 1, 1, '', '', '', '', ''),
(24, 3, 26, 1, 1, '', '', '', '', ''),
(25, 1, 27, 1, 1, '', '', '', '', ''),
(26, 2, 27, 1, 1, '', '', '', '', ''),
(27, 3, 27, 1, 1, '', '', '', '', ''),
(28, 1, 28, 1, 1, '', '', '', '', ''),
(29, 2, 28, 1, 1, '', '', '', '', ''),
(30, 3, 28, 1, 1, '', '', '', '', ''),
(31, 1, 29, 1, 1, '', '', '', '', ''),
(32, 2, 29, 1, 1, '', '', '', '', ''),
(33, 3, 29, 1, 1, '', '', '', '', ''),
(34, 1, 30, 1, 1, '', '', '', '', ''),
(35, 2, 30, 1, 1, '', '', '', '', ''),
(36, 3, 30, 1, 1, '', '', '', '', ''),
(37, 1, 31, 1, 1, '', '', '', '', ''),
(38, 2, 31, 1, 1, '', '', '', '', ''),
(39, 3, 31, 1, 1, '', '', '', '', ''),
(40, 1, 32, 1, 1, '', '', '', '', ''),
(41, 2, 32, 1, 1, '', '', '', '', ''),
(42, 3, 32, 1, 1, '', '', '', '', '');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_prestamo`
--

DROP TABLE IF EXISTS `ep_prestamo`;
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
  `ep_prestamodestino` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_prestamo`
--

INSERT INTO `ep_prestamo` (`codepprestamo`, `codeptipoprestamo`, `codepinformaciongeneralcif`, `codepinstitucion`, `codeptipoinstitucion`, `ep_prestamomomentoinicial`, `ep_prestamosaldoactual`, `ep_prestamofechadesembolso`, `ep_prestamofechadefinalizacion`, `ep_prestamodestino`) VALUES
(1, 1, 1, 2, 2, 2500, 7000, '2020-05-12', '2020-01-12', 'Cuenta Monetaria'),
(2, 1, 1, 1, 1, 7500, 5222, '2020-05-14', '2020-01-01', 'Cuenta Familiar'),
(3, 1, 16, 2, 2, 2500, 7000, '0000-00-00', '0000-00-00', 'Cuenta Monetaria'),
(4, 1, 16, 1, 1, 7500, 5222, '0000-00-00', '0000-00-00', 'Cuenta Familiar'),
(5, 2, 1, 1, 1, 5000, 2000, '2018-08-01', '2018-08-11', 'Cuenta de destino'),
(6, 1, 30, 1, 1, 4654, 654, '2018-07-22', '2018-07-22', 'asdasd'),
(7, 1, 21, 2, 2, 5465, 5456, '2018-07-22', '2018-07-22', 'Prueba'),
(8, 1, 31, 1, 1, 5000, 2500, '2018-07-22', '2018-07-22', 'asdasd'),
(9, 1, 32, 3, 38, 25000, 1083333, '2018-11-25', '2021-11-25', 'Compra de vehículo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_remesas`
--

DROP TABLE IF EXISTS `ep_remesas`;
CREATE TABLE `ep_remesas` (
  `codepremesas` int(11) NOT NULL,
  `codepcontrolingreso` int(11) DEFAULT NULL,
  `ep_remesasnombre` varchar(50) DEFAULT NULL,
  `ep_remesasrelacion` varchar(100) DEFAULT NULL,
  `ep_remesasmonto` double DEFAULT NULL,
  `ep_remesasperiodo` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_remesas`
--

INSERT INTO `ep_remesas` (`codepremesas`, `codepcontrolingreso`, `ep_remesasnombre`, `ep_remesasrelacion`, `ep_remesasmonto`, `ep_remesasperiodo`) VALUES
(1, 1, 'REMESA MI COSECHA', 'Madre', 2500, '2021-10-10'),
(2, 2, '', '', 0, '0000-00-00'),
(3, 3, '', '', 0, '0000-00-00'),
(4, 4, '', '', 0, '0000-00-00'),
(5, 5, '', '', 0, '0000-00-00'),
(6, 6, '', '', 0, '0000-00-00'),
(7, 7, '', '', 0, '0000-00-00'),
(8, 8, '', '', 0, '0000-00-00'),
(9, 9, '', '', 0, '0000-00-00'),
(10, 10, '', '', 0, '0000-00-00'),
(11, 11, '', '', 0, '0000-00-00'),
(12, 12, '', '', 0, '0000-00-00'),
(13, 13, '', '', 0, '0000-00-00'),
(14, 14, '', '', 0, '0000-00-00'),
(15, 15, '', '', 0, '0000-00-00'),
(16, 16, 'Oscar David Herera Hernandez', 'Padre', 1000, '0000-00-00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tarjetadecredito`
--

DROP TABLE IF EXISTS `ep_tarjetadecredito`;
CREATE TABLE `ep_tarjetadecredito` (
  `codeptrajetadecredito` int(11) NOT NULL,
  `codeptipoinstitucion` int(11) DEFAULT NULL,
  `codepinstitucion` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_tarjetadecreditomonedaqtz` double DEFAULT NULL,
  `ep_tarjetadecreditomonedausd` double DEFAULT NULL,
  `ep_tarjetadecreditosaldoactual` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tarjetadecredito`
--

INSERT INTO `ep_tarjetadecredito` (`codeptrajetadecredito`, `codeptipoinstitucion`, `codepinstitucion`, `codepinformaciongeneralcif`, `ep_tarjetadecreditomonedaqtz`, `ep_tarjetadecreditomonedausd`, `ep_tarjetadecreditosaldoactual`) VALUES
(1, 1, 1, 1, 8000, 1000, 500000),
(2, 2, 2, 1, 7500, 950, 1000),
(3, 1, 1, 16, 1, 8000, 1000),
(4, 2, 2, 16, 1, 7500, 950),
(5, 1, 1, 1, 2500, 1000, 250),
(6, 1, 1, 30, 464, 56465, 65465),
(7, 1, 1, 21, 56465, 56465, 5564),
(8, 1, 1, 31, 5000, 2000, 3500),
(9, 3, 38, 32, 3000, 400, 1500),
(10, 3, 38, 32, 1500, 200, 1000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_telefono`
--

DROP TABLE IF EXISTS `ep_telefono`;
CREATE TABLE `ep_telefono` (
  `codeptelefono` int(11) NOT NULL,
  `codeptipotelefono` int(11) DEFAULT NULL,
  `codepinformaciongeneralcif` int(11) DEFAULT NULL,
  `ep_telefononumero` varchar(8) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_telefono`
--

INSERT INTO `ep_telefono` (`codeptelefono`, `codeptipotelefono`, `codepinformaciongeneralcif`, `ep_telefononumero`) VALUES
(1, 1, 1, '31417025'),
(2, 1, 1, '40113755'),
(3, 2, 1, '24358844'),
(5, 1, 16, '31417025'),
(6, 1, 16, '40113755'),
(7, 2, 16, '24358844'),
(8, 1, 16, '31417025'),
(9, 1, 19, '24352567'),
(10, 1, 1, '564654'),
(11, 2, 20, '12345678'),
(12, 1, 22, '4564654'),
(13, 2, 29, '54267957'),
(14, 1, 30, '123456'),
(15, 2, 21, '12345'),
(16, 2, 21, '54267957'),
(17, 2, 2, '54267957'),
(18, 2, 31, '5426757'),
(19, 1, 31, '123456'),
(21, 2, 32, '46712846'),
(22, 1, 32, '22583214'),
(23, 2, 32, '45451616'),
(24, 2, 32, '55152022'),
(25, 1, 32, '28781868');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipobien`
--

DROP TABLE IF EXISTS `ep_tipobien`;
CREATE TABLE `ep_tipobien` (
  `codeptipobien` int(11) NOT NULL,
  `ep_tipobiennombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipobien`
--

INSERT INTO `ep_tipobien` (`codeptipobien`, `ep_tipobiennombre`) VALUES
(1, 'Equipo de computo'),
(2, 'Amueblado de sala'),
(3, 'Amueblado de comedor'),
(4, 'Televisor'),
(5, 'Equipo de sonido'),
(6, 'Lavadora'),
(7, 'Secadora'),
(8, 'Estufa'),
(9, 'Refrigeradora'),
(10, 'Telefono Movil'),
(11, 'Otros');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipocuenta`
--

DROP TABLE IF EXISTS `ep_tipocuenta`;
CREATE TABLE `ep_tipocuenta` (
  `codeptipocuenta` int(11) NOT NULL,
  `ep_tipocuentanombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipocuenta`
--

INSERT INTO `ep_tipocuenta` (`codeptipocuenta`, `ep_tipocuentanombre`) VALUES
(1, 'Cuentas monetarias'),
(2, 'Cuentas de ahorro'),
(3, 'Cuentas en cooperativas'),
(4, 'Cuentas por cobrar');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipocuentacooperativa`
--

DROP TABLE IF EXISTS `ep_tipocuentacooperativa`;
CREATE TABLE `ep_tipocuentacooperativa` (
  `codeptipocuentacooperativa` int(11) NOT NULL,
  `ep_tipocuentacooperativanombre` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipocuentacooperativa`
--

INSERT INTO `ep_tipocuentacooperativa` (`codeptipocuentacooperativa`, `ep_tipocuentacooperativanombre`) VALUES
(1, 'Aportación'),
(2, 'Ahorro');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipocuentaspopagar`
--

DROP TABLE IF EXISTS `ep_tipocuentaspopagar`;
CREATE TABLE `ep_tipocuentaspopagar` (
  `codeptipocuentaspopagar` int(11) NOT NULL,
  `ep_tipocuentaspopagarnombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipocuentaspopagar`
--

INSERT INTO `ep_tipocuentaspopagar` (`codeptipocuentaspopagar`, `ep_tipocuentaspopagarnombre`) VALUES
(1, 'Largo Plazo'),
(2, 'Corto Plazo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipoestado`
--

DROP TABLE IF EXISTS `ep_tipoestado`;
CREATE TABLE `ep_tipoestado` (
  `codeptipoestado` int(11) NOT NULL,
  `ep_tipoestadonombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipoestado`
--

INSERT INTO `ep_tipoestado` (`codeptipoestado`, `ep_tipoestadonombre`) VALUES
(1, 'NUEVO'),
(2, 'PROCESO'),
(3, 'MODIFICACION'),
(4, 'FINALIZADO');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipoestatuscuenta`
--

DROP TABLE IF EXISTS `ep_tipoestatuscuenta`;
CREATE TABLE `ep_tipoestatuscuenta` (
  `codeptipoestatuscuenta` int(11) NOT NULL,
  `ep_tipoestatuscuentanombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipoestatuscuenta`
--

INSERT INTO `ep_tipoestatuscuenta` (`codeptipoestatuscuenta`, `ep_tipoestatuscuentanombre`) VALUES
(1, 'Activa'),
(2, 'Desactivada');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipoinmueble`
--

DROP TABLE IF EXISTS `ep_tipoinmueble`;
CREATE TABLE `ep_tipoinmueble` (
  `codeptipoinmueble` int(11) NOT NULL,
  `ep_tipoinmueblenombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipoinmueble`
--

INSERT INTO `ep_tipoinmueble` (`codeptipoinmueble`, `ep_tipoinmueblenombre`) VALUES
(1, 'Terreno'),
(2, 'Casa'),
(3, 'Apartamento');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipoinstitucion`
--

DROP TABLE IF EXISTS `ep_tipoinstitucion`;
CREATE TABLE `ep_tipoinstitucion` (
  `codeptipoinstitucion` int(11) NOT NULL,
  `ep_tipoinstitucionnombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipoinstitucion`
--

INSERT INTO `ep_tipoinstitucion` (`codeptipoinstitucion`, `ep_tipoinstitucionnombre`) VALUES
(1, 'Instituciónes Bancarias'),
(2, 'Sociedades Financieras'),
(3, 'Cooperatiivas Sistema Micoope'),
(4, 'Microfinanciera');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipomoneda`
--

DROP TABLE IF EXISTS `ep_tipomoneda`;
CREATE TABLE `ep_tipomoneda` (
  `codeptipomoneda` int(11) NOT NULL,
  `ep_tipomonedanombre` varchar(45) DEFAULT NULL,
  `ep_signomoneda` varchar(45) DEFAULT NULL,
  `ep_codigointernacional` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipomoneda`
--

INSERT INTO `ep_tipomoneda` (`codeptipomoneda`, `ep_tipomonedanombre`, `ep_signomoneda`, `ep_codigointernacional`) VALUES
(1, 'Quetzales', 'Q', 'GTQ'),
(2, 'Dolares', '$', 'USD');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tiponacionalidad`
--

DROP TABLE IF EXISTS `ep_tiponacionalidad`;
CREATE TABLE `ep_tiponacionalidad` (
  `codeptiponacionalidad` int(11) NOT NULL,
  `ep_tiponacionalidadnombre` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tiponacionalidad`
--

INSERT INTO `ep_tiponacionalidad` (`codeptiponacionalidad`, `ep_tiponacionalidadnombre`) VALUES
(1, 'Nacional'),
(2, 'Extranjero');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipoparentesco`
--

DROP TABLE IF EXISTS `ep_tipoparentesco`;
CREATE TABLE `ep_tipoparentesco` (
  `codeptipoparentesco` int(11) NOT NULL,
  `ep_tipoparentesconombre` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipoparentesco`
--

INSERT INTO `ep_tipoparentesco` (`codeptipoparentesco`, `ep_tipoparentesconombre`) VALUES
(1, 'Padre'),
(2, 'Madre'),
(3, 'Tio/a'),
(4, 'Abuelo/a'),
(5, 'Sobrino');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipopep`
--

DROP TABLE IF EXISTS `ep_tipopep`;
CREATE TABLE `ep_tipopep` (
  `codeptipopep` int(11) NOT NULL,
  `ep_tipopep` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipopep`
--

INSERT INTO `ep_tipopep` (`codeptipopep`, `ep_tipopep`) VALUES
(1, 'PEP'),
(2, 'PPEP'),
(3, 'CPEP');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipoprestamo`
--

DROP TABLE IF EXISTS `ep_tipoprestamo`;
CREATE TABLE `ep_tipoprestamo` (
  `codeptipoprestamo` int(11) NOT NULL,
  `ep_tipoprestamonombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipoprestamo`
--

INSERT INTO `ep_tipoprestamo` (`codeptipoprestamo`, `ep_tipoprestamonombre`) VALUES
(1, 'Fiduciario'),
(2, 'Hipotecario'),
(3, 'Prendario'),
(4, 'Back to Back / Automático'),
(5, 'Mixto');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipotelefono`
--

DROP TABLE IF EXISTS `ep_tipotelefono`;
CREATE TABLE `ep_tipotelefono` (
  `codeptipotelefono` int(11) NOT NULL,
  `ep_tipotelefononombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipotelefono`
--

INSERT INTO `ep_tipotelefono` (`codeptipotelefono`, `ep_tipotelefononombre`) VALUES
(1, 'Telefono Casa'),
(2, 'Celular');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_tipovehiculo`
--

DROP TABLE IF EXISTS `ep_tipovehiculo`;
CREATE TABLE `ep_tipovehiculo` (
  `codeptipovehiculo` int(11) NOT NULL,
  `ep_tipovehiculonombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_tipovehiculo`
--

INSERT INTO `ep_tipovehiculo` (`codeptipovehiculo`, `ep_tipovehiculonombre`) VALUES
(1, 'Carro'),
(2, 'Bus'),
(3, 'Camion');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ep_vehiculo`
--

DROP TABLE IF EXISTS `ep_vehiculo`;
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
  `ep_vehiculomotivodeanombrede` varchar(120) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `ep_vehiculo`
--

INSERT INTO `ep_vehiculo` (`codepvehiculo`, `codeptipovehiculo`, `codepinformaciongeneralcif`, `ep_vehiculomarca`, `ep_vehiculolinea`, `ep_vehiculomodelo`, `ep_vehiculoplaca`, `ep_vehiculocomentario`, `ep_vehiculoanombrede`, `ep_vehiculomotivodeanombrede`) VALUES
(1, 1, 1, 'Nissan', 'Lujo', '2015', '22545k', NULL, NULL, NULL),
(2, 1, 1, 'Toyota', 'Luxio', '2015', '11544k', NULL, NULL, NULL),
(3, 1, 16, 'Nissan', 'Lujo', '2015', '22545k', NULL, NULL, NULL),
(4, 1, 16, 'Toyota', 'Luxio', '2015', '11544k', NULL, NULL, NULL),
(5, 1, 1, 'Toyota', 'Lexus', 'M43', '2565D8', NULL, NULL, NULL),
(6, 2, 30, 'asd', 'asd', 'asd', '546', NULL, NULL, NULL),
(7, 1, 21, 'Prueba', 'Prueba', 'Prueba', 'sa5465', NULL, NULL, NULL),
(8, 1, 31, '2', '2', 'Prueba', '546', 'asdas', NULL, NULL),
(9, 1, 32, 'toyota', 'Yaris', '2004', '160BQX', 'CARRO PROPIO', NULL, NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_aplicacion`
--

DROP TABLE IF EXISTS `gen_aplicacion`;
CREATE TABLE `gen_aplicacion` (
  `codgenapp` int(11) NOT NULL,
  `gen_literalapp` varchar(10) NOT NULL,
  `gen_nombreapp` varchar(30) NOT NULL,
  `gen_urlcontrol` varchar(60) NOT NULL,
  `gen_estadoapp` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_aplicacion`
--

INSERT INTO `gen_aplicacion` (`codgenapp`, `gen_literalapp`, `gen_nombreapp`, `gen_urlcontrol`, `gen_estadoapp`) VALUES
(1, 'EP', 'Estado Patrimonial', '../MantenimientosControl/controlAgenda.aspx', 1),
(2, 'AV', 'Agenda Virtual', '../MantenimientosControl/controlAgenda.aspx', 1),
(3, 'ARQ', 'Arqueos', '../MantenimientosControl/SeguridadArqueos.aspx', 1),
(4, 'CRM', 'CRM', '../MantenimientosControl/controlAgenda.aspx', 1),
(5, 'EXC', 'Control Expedientes', '../MantenimientosControl/controlAgenda.aspx', 1),
(6, 'CHA', 'Control Hallazgos', '../MantenimientosControl/controlAgenda.aspx', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_area`
--

DROP TABLE IF EXISTS `gen_area`;
CREATE TABLE `gen_area` (
  `codgenarea` int(11) NOT NULL,
  `codgensucursal` int(11) DEFAULT NULL,
  `gen_areanombre` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_area`
--

INSERT INTO `gen_area` (`codgenarea`, `codgensucursal`, `gen_areanombre`) VALUES
(1, 1, 'ADMINISTRACIÓN'),
(2, 2, 'AG. ATANASIO TZUL'),
(3, 2, 'AG. BOCA DEL MONTE'),
(4, 2, 'AG. FLORIDA'),
(5, 2, 'MERCADEO'),
(6, 2, 'AG. GRAN VIA'),
(7, 2, 'AG. MEGA 6'),
(8, 2, 'AG. METROCENTRO'),
(9, 2, 'AG. MIXCO'),
(10, 2, 'AG. PACIFIC VH'),
(11, 2, 'AG. PETAPA'),
(12, 2, 'AG. PORTALES'),
(13, 2, 'AG. SAN CRISTOBAL'),
(14, 2, 'AG. SAN LUCAS'),
(15, 2, 'AG. SAN NICOLAS'),
(16, 2, 'AG. TERMINAL'),
(17, 2, 'AG. ZONA 4'),
(18, 2, 'MINI AG. METRONORTE'),
(19, 2, 'AG.C.C. NARANJO MALL'),
(20, 2, 'AGENCIA LOS ALAMOS'),
(21, 3, 'ARCHIVO'),
(22, 4, 'AUDITORIA INTERNA'),
(23, 1, 'CAPACITACIÓN Y DESARROLLO'),
(24, 3, 'CARTERA DEPURADA '),
(25, 2, 'CENTRAL ZONA 14'),
(26, 3, 'COBROS'),
(27, 2, 'COMERCIALIZACIÓN'),
(28, 5, 'CONTABILIDAD'),
(29, 3, 'CRÉDITOS'),
(30, 4, 'CUMPLIMIENTO'),
(31, 5, 'FINANZAS'),
(32, 6, 'GERENCIA GENERAL'),
(33, 1, 'IDT'),
(34, 3, 'JURIDICO'),
(35, 2, 'KIOSCO MIRAFLORES'),
(36, 2, 'KIOSCO MONSERRAT'),
(37, 2, 'KIOSKO PORTALES'),
(38, 2, 'MINI AG C.C. PRADERA'),
(39, 2, 'NEGOCIOS'),
(40, 1, 'NORMATIVIDAD/PROCESOS'),
(41, 2, 'OPERACIONES AGENCIA'),
(42, 2, 'PREMORA'),
(43, 2, 'QA'),
(44, 6, 'RIESGOS'),
(45, 1, 'SEGURIDAD'),
(46, 5, 'SEGUROS'),
(47, 1, 'SERVICIOS GENERALES'),
(48, 2, 'STA CATARINA PINULA'),
(49, 1, 'TALENTO HUMANO'),
(50, 5, 'TESORERIA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_bitacora_ingresos_egresos`
--

DROP TABLE IF EXISTS `gen_bitacora_ingresos_egresos`;
CREATE TABLE `gen_bitacora_ingresos_egresos` (
  `codgen_bitacora_ingresos_egresos` int(11) NOT NULL,
  `gen_bitacora_ingresos_egresosusername` varchar(80) DEFAULT NULL,
  `gen_bitacora_ingresos_egresosipaddress` varchar(80) DEFAULT NULL,
  `gen_bitacora_ingresos_egresosmacaddress` varchar(80) DEFAULT NULL,
  `gen_bitacora_ingresos_egresosfechahora` datetime DEFAULT NULL,
  `gen_bitacora_ingresos_egresosnombremodulo` varchar(80) DEFAULT NULL,
  `gen_bitacora_ingresos_egresosestado` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_bitacora_procedimientos`
--

DROP TABLE IF EXISTS `gen_bitacora_procedimientos`;
CREATE TABLE `gen_bitacora_procedimientos` (
  `codgen_bitacora_procedimientos` int(11) NOT NULL,
  `gen_bitacora_procedimientosusername` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosipaddress` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosmacaddress` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosfechahora` datetime DEFAULT NULL,
  `gen_bitacora_procedimientosnombremodulo` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosnombreaplicacion` varchar(80) DEFAULT NULL,
  `gen_bitacora_procedimientosoperacion` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_departamento`
--

DROP TABLE IF EXISTS `gen_departamento`;
CREATE TABLE `gen_departamento` (
  `codgendepartamento` int(11) NOT NULL,
  `gen_departamentonombre` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_departamento`
--

INSERT INTO `gen_departamento` (`codgendepartamento`, `gen_departamentonombre`) VALUES
(1, 'GUATEMALA'),
(2, 'SACATEPÉQUEZ'),
(3, 'CHIMALTENANGO'),
(4, 'EL PROGRESO'),
(5, 'ESCUINTLA'),
(6, 'SANTA ROSA'),
(7, 'SOLOLÁ'),
(8, 'TOTONICAPÁN'),
(9, 'QUETZALTENANGO'),
(10, 'SUCHITEPÉQUEZ'),
(11, 'RETALHULEU'),
(12, 'SAN MARCOS'),
(13, 'HUEHUETENANGO'),
(14, 'EL QUICHÉ'),
(15, 'BAJA VERAPAZ'),
(16, 'ALTA VERAPAZ'),
(17, 'PETÉN'),
(18, 'IZABAL'),
(19, 'ZACAPA'),
(20, 'CHIQUIMULA'),
(21, 'JALAPA'),
(22, 'JUTIAPA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_invequipo`
--

DROP TABLE IF EXISTS `gen_invequipo`;
CREATE TABLE `gen_invequipo` (
  `codgeninvequipo` int(11) NOT NULL,
  `codgensucursal` int(11) DEFAULT NULL,
  `gen_invequipodescripcion` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_invequipo`
--

INSERT INTO `gen_invequipo` (`codgeninvequipo`, `codgensucursal`, `gen_invequipodescripcion`) VALUES
(1, 1, 'Portatil');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_mdimenu`
--

DROP TABLE IF EXISTS `gen_mdimenu`;
CREATE TABLE `gen_mdimenu` (
  `codgenmdi` int(11) NOT NULL,
  `codgenapp` int(11) NOT NULL,
  `codgenusuario` int(11) NOT NULL,
  `gen_mdiest` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_mdimenu`
--

INSERT INTO `gen_mdimenu` (`codgenmdi`, `codgenapp`, `codgenusuario`, `gen_mdiest`) VALUES
(1, 3, 4, 1),
(2, 2, 1, 0),
(3, 6, 4, 1),
(4, 3, 1, 1),
(5, 4, 1, 1),
(6, 1, 2, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_municipio`
--

DROP TABLE IF EXISTS `gen_municipio`;
CREATE TABLE `gen_municipio` (
  `codgenmunicipio` int(11) NOT NULL,
  `codgendepartamento` int(11) DEFAULT NULL,
  `gen_municipionombre` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_municipio`
--

INSERT INTO `gen_municipio` (`codgenmunicipio`, `codgendepartamento`, `gen_municipionombre`) VALUES
(101, 1, 'GUATEMALA'),
(102, 1, 'SANTA CATARINA PINULA'),
(103, 1, 'SAN JOSÉ PINULA'),
(104, 1, 'SAN JOSÉ DEL GOLFO'),
(105, 1, 'PALENCIA'),
(106, 1, 'CHINAUTLA'),
(107, 1, 'SAN PEDRO AYAMPUC'),
(108, 1, 'MIXCO'),
(109, 1, 'SAN PEDRO SACATEPÉQUEZ'),
(110, 1, 'SAN JUAN SACATEPÉQUEZ'),
(111, 1, 'SAN RAYMUNDO'),
(112, 1, 'CHUARRANCHO'),
(113, 1, 'FRAIJANES'),
(114, 1, 'AMATITLÁN'),
(115, 1, 'VILLA NUEVA'),
(116, 1, 'VILLA CANALES'),
(117, 1, 'SAN MIGUEL PETAPA'),
(201, 4, 'GUASTATOYA'),
(202, 4, 'MORAZÁN'),
(203, 4, 'SAN AGUSTÍN ACASAGUASTLÁN'),
(204, 4, 'SAN CRISTÓBAL ACASAGUASTLÁN'),
(205, 4, 'EL JÍCARO'),
(206, 4, 'SANSARE'),
(207, 4, 'SANARATE'),
(208, 4, 'SAN ANTONIO LA PAZ'),
(301, 2, 'ANTIGUA GUATEMALA'),
(302, 2, 'JOCOTENANGO'),
(303, 2, 'PASTORES'),
(304, 2, 'SUMPANGO'),
(305, 2, 'SANTO DOMINGO XENACOJ'),
(306, 2, 'SANTIAGO SACATEPEQUÉZ'),
(307, 2, 'SAN BARTOLOMÉ MILPAS ALTAS'),
(308, 2, 'SAN LUCAS SACATEPÉQUEZ'),
(309, 2, 'SANTA LUCÍA MILPAS ALTAS'),
(310, 2, 'MAGDALENA MILPAS ALTAS'),
(311, 2, 'SANTA MARÍA DE JESÚS'),
(312, 2, 'CIUDAD VIEJA'),
(313, 2, 'SAN MIGUEL DUEÑAS'),
(314, 2, 'ALOTENANGO'),
(315, 2, 'SAN ANTONIO AGUAS CALIENTES'),
(316, 2, 'SANTA CATARINA BARAHONA'),
(401, 3, 'CHIMALTENANGO'),
(402, 3, 'SAN JOSÉ POAQUIL'),
(403, 3, 'SAN MARTÍN JILOTEPEQUE'),
(404, 3, 'SAN JUAN COMALAPA'),
(405, 3, 'SANTA APOLONIA'),
(406, 3, 'TECPÁN GUATEMALA'),
(407, 3, 'PATZÚN'),
(408, 3, 'POCHUTA'),
(409, 3, 'PATZICÍA'),
(410, 3, 'SANTA CRUZ BALANYA'),
(411, 3, 'ACATENANGO'),
(412, 3, 'SAN PEDRO YEPOCAPA'),
(413, 3, 'SAN ANDRÉS ITZAPA'),
(414, 3, 'PARRAMOS'),
(415, 3, 'ZARAGOZA'),
(416, 3, 'EL TEJAR'),
(501, 5, 'ESCUINTLA'),
(502, 5, 'SANTA LUCÍA COTZUMALGUAPA'),
(503, 5, 'LA DEMOCRACIA'),
(504, 5, 'SIQUINALÁ'),
(505, 5, 'MASAGUA'),
(506, 5, 'TIQUISATE'),
(507, 5, 'LA GOMERA'),
(508, 5, 'GUANAGAZAPA'),
(509, 5, 'PUERTO SAN JOSÉ'),
(510, 5, 'IZTAPA'),
(511, 5, 'PALÍN'),
(512, 5, 'SAN VICENTE PACAYA'),
(513, 5, 'NUEVA CONCEPCIÓN'),
(514, 5, 'SIPACATE'),
(601, 6, 'CUILAPA'),
(602, 6, 'BARBERENA'),
(603, 6, 'SANTA ROSA DE LIMA'),
(604, 6, 'CASILLAS'),
(605, 6, 'SAN RAFAEL LAS FLORES'),
(606, 6, 'ORATORIO'),
(607, 6, 'SAN JUAN TECUACO'),
(608, 6, 'CHIQUIMULILLA'),
(609, 6, 'TAXISCO'),
(610, 6, 'SANTA MARÍA IXHUATÁN'),
(611, 6, 'GUAZACAPÁN'),
(612, 6, 'SANTA CRUZ NARANJO'),
(613, 6, 'PUEBLO NUEVO VIÑAS'),
(614, 6, 'NUEVA SANTA ROSA'),
(701, 7, 'SOLOLÁ'),
(702, 7, 'SAN JOSÉ CHACAYÁ'),
(703, 7, 'SANTA MARÍA VISITACIÓN'),
(704, 7, 'SANTA LUCÍA UTATLÁN'),
(705, 7, 'NAHUALÁ'),
(706, 7, 'SANTA CATARINA IXTAHUACÁN'),
(707, 7, 'SANTA CLARA LA LAGUNA'),
(708, 7, 'CONCEPCIÓN'),
(709, 7, 'SAN ANDRÉS SEMETABAJ'),
(710, 7, 'PANAJACHEL'),
(711, 7, 'SANTA CATARINA PALOPÓ'),
(712, 7, 'SAN ANTONIO PALOPÓ'),
(713, 7, 'SAN LUCAS TOLIMÁN'),
(714, 7, 'SANTA CRUZ LA LAGUNA'),
(715, 7, 'SAN PABLO LA LAGUNA'),
(716, 7, 'SAN MARCOS LA LAGUNA'),
(717, 7, 'SAN JUAN LA LAGUNA'),
(718, 7, 'SAN PEDRO LA LAGUNA'),
(719, 7, 'SANTIAGO ATITLÁN'),
(801, 8, 'TOTONICAPÁN'),
(802, 8, 'SAN CRISTÓBAL TOTONICAPÁN'),
(803, 8, 'SAN FRANCISCO EL ALTO'),
(804, 8, 'SAN ANDRÉS XECUL'),
(805, 8, 'MOMOSTENANGO'),
(806, 8, 'SANTA MARÍA CHIQUIMULA'),
(807, 8, 'SANTA LUCÍA LA REFORMA'),
(808, 8, 'SAN BARTOLO'),
(901, 9, 'QUETZALTENANGO'),
(902, 9, 'SALCAJÁ'),
(903, 9, 'OLINTEPEQUE'),
(904, 9, 'SAN CARLOS SIJA'),
(905, 9, 'SIBILIA'),
(906, 9, 'CABRICÁN'),
(907, 9, 'CAJOLA'),
(908, 9, 'SAN MIGUEL SIGUILA'),
(909, 9, 'SAN JUAN OSTUNCALCO'),
(910, 9, 'SAN MATEO'),
(911, 9, 'CONCEPCIÓN CHIQUIRICHAPA'),
(912, 9, 'SAN MARTÍN SACATEPÉQUEZ'),
(913, 9, 'ALMOLONGA'),
(914, 9, 'CANTEL'),
(915, 9, 'HUITÁN'),
(916, 9, 'ZUNIL'),
(917, 9, 'COLOMBA'),
(918, 9, 'SAN FRANCISCO LA UNIÓN'),
(919, 9, 'EL PALMAR'),
(920, 9, 'COATEPEQUE'),
(921, 9, 'GÉNOVA COSTA CUCA'),
(922, 9, 'FLORES'),
(923, 9, 'LA ESPERANZA'),
(924, 9, 'PALESTINA DE LOS ALTOS'),
(1001, 10, 'MAZATENANGO'),
(1002, 10, 'CUYOTENANGO'),
(1003, 10, 'SAN FRANCISCO ZAPOTITLÁN'),
(1004, 10, 'SAN BERNARDINO'),
(1005, 10, 'SAN JOSÉ EL ÍDOLO'),
(1006, 10, 'SANTO DOMINGO SUCHITEPEQUEZ'),
(1007, 10, 'SAN LORENZO'),
(1008, 10, 'SAMAYAC'),
(1009, 10, 'SAN PABLO JOCOPILAS'),
(1010, 10, 'SAN ANTONIO SUCHITEPÉQUEZ'),
(1011, 10, 'SAN MIGUEL PANÁN'),
(1012, 10, 'SAN GABRIEL'),
(1013, 10, 'CHICACAO'),
(1014, 10, 'PATULUL'),
(1015, 10, 'SANTA BÁRBARA'),
(1016, 10, 'SAN JUAN BAUTISTA'),
(1017, 10, 'SANTO TOMÁS LA UNIÓN'),
(1018, 10, 'ZUNILITO'),
(1019, 10, 'PUEBLO NUEVO'),
(1020, 10, 'RÍO BRAVO'),
(1021, 10, 'SAN JOSÉ LA MÁQUINA'),
(1101, 11, 'RETALHULEU'),
(1102, 11, 'SAN SEBASTIÁN'),
(1103, 11, 'SANTA CRUZ MULUÁ'),
(1104, 11, 'SAN MARTÍN ZAPOTITLÁN'),
(1105, 11, 'SAN FELIPE'),
(1106, 11, 'SAN ANDRÉS VILLA SECA'),
(1107, 11, 'CHAMPERICO'),
(1108, 11, 'NUEVO SAN CARLOS'),
(1109, 11, 'EL ASINTAL'),
(1201, 12, 'SAN MARCOS'),
(1202, 12, 'SAN PEDRO SACATEPÉQUEZ'),
(1203, 12, 'SAN ANTONIO SACATEPÉQUEZ'),
(1204, 12, 'COMITANCILLO'),
(1205, 12, 'SAN MIGUEL IXTAHUACÁN'),
(1206, 12, 'CONCEPCIÓN TUTUAPA'),
(1207, 12, 'TACANÁ'),
(1208, 12, 'SIBINAL'),
(1209, 12, 'TAJUMULCO'),
(1210, 12, 'TEJUTLA'),
(1211, 12, 'SAN RAFAEL PIE DE LA CUESTA'),
(1212, 12, 'NUEVO PROGRESO'),
(1213, 12, 'EL TUMBADOR'),
(1214, 12, 'SAN JOSE EL RODEO'),
(1215, 12, 'MALACATÁN'),
(1216, 12, 'CATARINA'),
(1217, 12, 'AYUTLA (TECUN UMAN)'),
(1218, 12, 'OCÓS'),
(1219, 12, 'SAN PABLO'),
(1220, 12, 'EL QUETZAL'),
(1221, 12, 'LA REFORMA'),
(1222, 12, 'PAJAPITA'),
(1223, 12, 'IXCHIGUÁN'),
(1224, 12, 'SAN JOSÉ OJETENAM'),
(1225, 12, 'SAN CRISTÓBAL CUCHO'),
(1226, 12, 'SIPACAPA'),
(1227, 12, 'ESQUIPULAS PALO GORDO'),
(1228, 12, 'RÍO BLANCO'),
(1229, 12, 'SAN LORENZO'),
(1230, 12, 'LA BLANCA'),
(1301, 13, 'HUEHUETENANGO'),
(1302, 13, 'CHIANTLA'),
(1303, 13, 'MALACATANCITO'),
(1304, 13, 'CUILCO'),
(1305, 13, 'NENTÓN'),
(1306, 13, 'SAN PEDRO NECTA'),
(1307, 13, 'JACALTENANGO'),
(1308, 13, 'SOLOMA'),
(1309, 13, 'IXTAHUACÁN'),
(1310, 13, 'SANTA BÁRBARA'),
(1311, 13, 'LA LIBERTAD'),
(1312, 13, 'LA DEMOCRACIA'),
(1313, 13, 'SAN MIGUEL ACATÁN'),
(1314, 13, 'SAN RAFAEL LA INDEPENDENCIA'),
(1315, 13, 'TODOS SANTOS CUCHUMATÁN'),
(1316, 13, 'SAN JUAN ATITÁN'),
(1317, 13, 'SANTA EULALIA'),
(1318, 13, 'SAN MATEO IXTATÁN'),
(1319, 13, 'COLOTENANGO'),
(1320, 13, 'SAN SEBASTIÁN HUEHUETENANGO'),
(1321, 13, 'TECTITÁN'),
(1322, 13, 'CONCEPCIÓN HUISTA'),
(1323, 13, 'SAN JUAN IXCOY'),
(1324, 13, 'SAN ANTONIO HUISTA'),
(1325, 13, 'SAN SEBASTIÁN COATÁN'),
(1326, 13, 'BARILLAS'),
(1327, 13, 'AGUACATÁN'),
(1328, 13, 'SAN RAFAEL PETZAL'),
(1329, 13, 'SAN GASPAR IXCHIL'),
(1330, 13, 'SANTIAGO CHIMALTENANGO'),
(1331, 13, 'SANTA ANA HUISTA'),
(1332, 13, 'UNION CANTINIL'),
(1333, 13, 'PETATÁN'),
(1401, 14, 'SANTA CRUZ DEL QUICHÉ'),
(1402, 14, 'CHICHÉ'),
(1403, 14, 'CHINIQUE'),
(1404, 14, 'ZACUALPA'),
(1405, 14, 'CHAJUL'),
(1406, 14, 'CHICHICASTENANGO'),
(1407, 14, 'PATZITE'),
(1408, 14, 'SAN ANTONIO ILOTENANGO'),
(1409, 14, 'SAN PEDRO JOCOPILAS'),
(1410, 14, 'CUNÉN'),
(1411, 14, 'SAN JUAN COTZAL'),
(1412, 14, 'JOYABAJ'),
(1413, 14, 'NEBAJ'),
(1414, 14, 'SAN ANDRÉS SAJCABAJA'),
(1415, 14, 'SAN MIGUEL USPANTÁN'),
(1416, 14, 'SACAPULAS'),
(1417, 14, 'SAN BARTOLOMÉ JOCOTENANGO'),
(1418, 14, 'CANILLÁ'),
(1419, 14, 'CHICAMÁN'),
(1420, 14, 'IXCÁN'),
(1421, 14, 'PACHALUM'),
(1501, 15, 'SALAMÁ'),
(1502, 15, 'SAN MIGUEL CHICAJ'),
(1503, 15, 'RABINAL'),
(1504, 15, 'CUBULCO'),
(1505, 15, 'GRANADOS'),
(1506, 15, 'EL CHOL'),
(1507, 15, 'SAN JERÓNIMO'),
(1508, 15, 'PURULHÁ'),
(1601, 16, 'COBÁN'),
(1602, 16, 'SANTA CRUZ VERAPAZ'),
(1603, 16, 'SAN CRISTÓBAL VERAPAZ'),
(1604, 16, 'TACTIC'),
(1605, 16, 'TAMAHÚ'),
(1606, 16, 'TUCURÚ'),
(1607, 16, 'PANZÓS'),
(1608, 16, 'SENAHÚ'),
(1609, 16, 'SAN PEDRO CARCHÁ'),
(1610, 16, 'SAN JUAN CHAMELCO'),
(1611, 16, 'LANQUÍN'),
(1612, 16, 'CAHABÓN'),
(1613, 16, 'CHISEC'),
(1614, 16, 'CHAHAL'),
(1615, 16, 'FRAY BARTOLOMÉ DE LAS CASAS'),
(1616, 16, 'SANTA CATARINA LA TINTA'),
(1617, 16, 'RAXRUHA'),
(1701, 17, 'FLORES'),
(1702, 17, 'SAN JOSÉ'),
(1703, 17, 'SAN BENITO'),
(1704, 17, 'SAN ANDRÉS'),
(1705, 17, 'LA LIBERTAD'),
(1706, 17, 'SAN FRANCISCO'),
(1707, 17, 'SANTA ANA'),
(1708, 17, 'DOLORES'),
(1709, 17, 'SAN LUIS'),
(1710, 17, 'SAYAXCHÉ'),
(1711, 17, 'MELCHOR DE MENCOS'),
(1712, 17, 'POPTÚN'),
(1713, 17, 'LAS CRUCES'),
(1714, 17, 'EL CHAL'),
(1801, 18, 'PUERTO BARRIOS'),
(1802, 18, 'LIVINGSTON'),
(1803, 18, 'EL ESTOR'),
(1804, 18, 'MORALES'),
(1805, 18, 'LOS AMATES'),
(1901, 19, 'ZACAPA'),
(1902, 19, 'ESTANZUELA'),
(1903, 19, 'RÍO HONDO'),
(1904, 19, 'GUALÁN'),
(1905, 19, 'TECULUTÁN'),
(1906, 19, 'USUMATLÁN'),
(1907, 19, 'CABAÑAS'),
(1908, 19, 'SAN DIEGO'),
(1909, 19, 'LA UNIÓN'),
(1910, 19, 'HUITÉ'),
(1911, 19, 'SAN JORGE'),
(2001, 20, 'CHIQUIMULA'),
(2002, 20, 'SAN JOSÉ LA ARADA'),
(2003, 20, 'SAN JUAN ERMITA'),
(2004, 20, 'JOCOTÁN'),
(2005, 20, 'CAMOTÁN'),
(2006, 20, 'OLOPA'),
(2007, 20, 'ESQUIPULAS'),
(2008, 20, 'CONCEPCIÓN LAS MINAS'),
(2009, 20, 'QUETZALTEPEQUE'),
(2010, 20, 'SAN JACINTO'),
(2011, 20, 'IPALA'),
(2101, 21, 'JALAPA'),
(2102, 21, 'SAN PEDRO PINULA'),
(2103, 21, 'SAN LUIS JILOTEPEQUE'),
(2104, 21, 'SAN MIGUEL CHAPARRÓN'),
(2105, 21, 'SAN CARLOS ALZATATE'),
(2106, 21, 'MONJAS'),
(2107, 21, 'MATAQUESCUINTLA'),
(2201, 22, 'JUTIAPA'),
(2202, 22, 'EL PROGRESO'),
(2203, 22, 'SANTA CATARINA MITA'),
(2204, 22, 'AGUA BLANCA'),
(2205, 22, 'ASUNCIÓN MITA'),
(2206, 22, 'YUPILTEPEQUE'),
(2207, 22, 'ATESCATEMPA'),
(2208, 22, 'JEREZ'),
(2209, 22, 'EL ADELANTO'),
(2210, 22, 'ZAPOTITLÁN'),
(2211, 22, 'COMAPA'),
(2212, 22, 'JALPATAGUA'),
(2213, 22, 'CONGUACO'),
(2214, 22, 'MOYUTA'),
(2215, 22, 'PASACO'),
(2216, 22, 'SAN JOSÉ ACATEMPA'),
(2217, 22, 'QUEZADA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_puestos`
--

DROP TABLE IF EXISTS `gen_puestos`;
CREATE TABLE `gen_puestos` (
  `codgenpuestos` int(11) NOT NULL,
  `codgenarea` int(11) DEFAULT NULL,
  `gen_puestosnombre` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_puestos`
--

INSERT INTO `gen_puestos` (`codgenpuestos`, `codgenarea`, `gen_puestosnombre`) VALUES
(1, 1, 'ENCARGADA DE RECEPCION'),
(2, 1, 'ASISTENTE GERENCIA ADMINISTRATIVA'),
(3, 1, 'TRADEMARKETING'),
(4, 1, 'GERENTE ADMINISTRATIVO'),
(5, 1, 'RECEPCIONISTA'),
(6, 2, 'ASESOR DE ATENCION AL ASOCIADO'),
(8, 2, 'CONSERJE'),
(9, 2, 'SUBJEFE DE AGENCIA'),
(10, 2, 'RECEPTOR PAGADOR'),
(11, 2, 'EJECUTIVO MULTIFUNCIONAL'),
(13, 2, 'JEFE DE AGENCIA'),
(14, 2, 'ASESOR DE CREDITOS'),
(15, 3, 'CONSERJE'),
(16, 3, 'ASESOR DE CREDITOS'),
(17, 3, 'ASESOR DE ATENCION AL ASOCIADO'),
(18, 3, 'SUBJEFE DE AGENCIA'),
(19, 3, 'RECEPTOR PAGADOR'),
(20, 3, 'ASESOR DE CREDITOS'),
(23, 3, 'EJECUTIVO MULTIFUNCIONAL'),
(25, 3, 'JEFE DE AGENCIA'),
(26, 4, 'RECEPTOR PAGADOR'),
(28, 4, 'ASESOR DE ATENCION AL ASOCIADO'),
(29, 4, 'JEFE DE AGENCIA'),
(30, 5, 'AUXILIAR DE TELEVENTAS '),
(31, 4, 'ASESOR DE CREDITOS'),
(32, 4, 'CONSERJE'),
(33, 4, 'SUBJEFE DE AGENCIA'),
(37, 5, 'ASESOR DE ATENCION AL ASOCIADO'),
(38, 5, 'RECEPTOR PAGADOR'),
(39, 5, 'ASESOR DE ATENCION AL ASOCIADO'),
(40, 5, 'JEFE DE AGENCIA'),
(41, 5, 'SUBJEFE DE AGENCIA'),
(42, 5, 'ASESOR DE ATENCION AL ASOCIADO'),
(43, 5, 'ASESOR DE CREDITOS'),
(44, 5, 'RECEPTOR PAGADOR'),
(45, 5, 'RECEPTOR PAGADOR'),
(46, 5, 'CONSERJE'),
(47, 5, 'RECEPTOR PAGADOR'),
(48, 5, 'ASESOR DE ATENCION AL ASOCIADO'),
(49, 5, 'JEFE DE AGENCIA'),
(50, 5, 'RECEPTOR PAGADOR'),
(51, 5, 'ASESOR DE CREDITOS'),
(52, 5, 'CONSERJE'),
(53, 7, 'ASESOR DE CREDITOS'),
(54, 7, 'CONSERJE'),
(56, 7, 'ASESOR DE ATENCION AL ASOCIADO'),
(58, 7, 'JEFE DE AGENCIA'),
(59, 7, 'RECEPTOR PAGADOR'),
(62, 8, 'JEFE DE AGENCIA'),
(63, 8, 'CONSERJE'),
(64, 8, 'RECEPTOR PAGADOR'),
(65, 8, 'ASESOR DE CREDITOS'),
(68, 8, 'ASESOR DE ATENCION AL ASOCIADO'),
(69, 8, 'SUBJEFE DE AGENCIA'),
(70, 9, 'RECEPTOR PAGADOR'),
(71, 9, 'CONSERJE'),
(72, 9, 'ASESOR DE ATENCION AL ASOCIADO'),
(73, 9, 'JEFE DE AGENCIA'),
(74, 9, 'SUBJEFE DE AGENCIA'),
(75, 9, 'EJECUTIVO MULTIFUNCIONAL ROTATIVO ZONA 14'),
(77, 10, 'JEFE DE AGENCIA JUNIOR'),
(79, 10, 'RECEPTOR PAGADOR'),
(80, 10, 'EJECUTIVO MULTIFUNCIONAL'),
(82, 10, 'ASESOR DE ATENCION AL ASOCIADO'),
(86, 11, 'JEFE DE AGENCIA'),
(87, 11, 'RECEPTOR PAGADOR'),
(88, 11, 'ASESOR DE ATENCION AL ASOCIADO'),
(89, 11, 'EJECUTIVO MULTIFUNCIONAL'),
(90, 11, 'ASESOR DE CREDITOS'),
(92, 11, 'CONSERJE'),
(95, 11, 'SUBJEFE DE AGENCIA'),
(98, 12, 'JEFE DE AGENCIA'),
(99, 12, 'EJECUTIVO MULTIFUNCIONAL'),
(100, 12, 'RECEPTOR PAGADOR'),
(101, 12, 'ASESOR DE ATENCION AL ASOCIADO'),
(103, 12, 'ASESOR DE CREDITOS'),
(104, 12, 'SUBJEFE DE AGENCIA'),
(105, 12, 'CONSERJE'),
(107, 13, 'ASESOR DE ATENCION AL ASOCIADO'),
(108, 13, 'RECEPTOR PAGADOR'),
(109, 13, 'CONSERJE'),
(112, 13, 'ASESOR DE CREDITOS'),
(113, 13, 'JEFE DE AGENCIA'),
(114, 13, 'SUBJEFE DE AGENCIA'),
(115, 13, 'EJECUTIVO MULTIFUNCIONAL'),
(116, 14, 'ASESOR DE ATENCION AL ASOCIADO'),
(117, 14, 'RECEPTOR PAGADOR'),
(119, 14, 'SUBJEFE DE AGENCIA'),
(120, 14, 'ASESOR DE CREDITOS'),
(121, 14, 'JEFE DE AGENCIA'),
(122, 14, 'CONSERJE'),
(123, 14, 'EJECUTIVO MULTIFUNCIONAL'),
(125, 15, 'ASESOR DE ATENCION AL ASOCIADO'),
(126, 15, 'ASESOR DE CREDITOS'),
(127, 15, 'RECEPTOR PAGADOR'),
(128, 15, 'JEFE DE AGENCIA'),
(129, 15, 'SUBJEFE DE AGENCIA'),
(130, 16, 'ASESOR DE ATENCION AL ASOCIADO'),
(132, 16, 'RECEPTOR PAGADOR'),
(133, 16, 'SUBJEFE DE AGENCIA'),
(134, 16, 'JEFE DE AGENCIA'),
(137, 39, 'RECEPTOR PAGADOR'),
(140, 16, 'ASESOR DE CREDITOS'),
(141, 18, 'JEFE DE AGENCIA'),
(142, 18, 'ASESOR DE ATENCION AL ASOCIADO'),
(143, 18, 'ASESOR DE CREDITOS'),
(144, 18, 'ASESOR DE ATENCION AL ASOCIADO'),
(145, 18, 'RECEPTOR PAGADOR'),
(146, 18, 'CONSERJE'),
(147, 18, 'RECEPTOR PAGADOR'),
(148, 18, 'SUBJEFE DE AGENCIA'),
(149, 18, 'EJECUTIVO MULTIFUNCIONAL'),
(150, 19, 'ASESOR DE ATENCIÓN AL ASOCIADO'),
(152, 19, 'JEFE DE AGENCIA'),
(153, 19, 'CONSERJE'),
(154, 19, 'SUBJEFE DE AGENCIA'),
(155, 19, 'RECEPTOR PAGADOR'),
(156, 19, 'ASESOR DE CREDITOS'),
(157, 20, 'EJECUTIVO DE KIOSCO'),
(158, 20, 'JEFE DE AGENCIA JUNIOR'),
(159, 20, 'RECEPTOR PAGADOR'),
(160, 20, 'CONSERJE '),
(161, 20, 'ASESOR DE CREDITOS'),
(165, 21, 'ENCARGADO DE AUDITORIA'),
(166, 21, 'ASISTENTE DE AUDITORIA '),
(167, 21, 'ASISTENTE DE AUDITORIA '),
(168, 21, 'AUDITOR INTERNO'),
(169, 21, 'AUXILIAR DE AUDITORIA'),
(170, 21, 'AUXILIAR DE AUDITORIA'),
(171, 21, 'AUXILIAR DE AUDITORIA'),
(172, 21, 'AUXILIAR DE AUDITORIA'),
(173, 22, 'GESTOR DE EDUCACION'),
(174, 22, 'ASISTENTE DE SEGURIDAD OCUPACIONAL'),
(175, 22, 'GESTOR DE EDUCACION'),
(176, 22, 'JEFE DE CAPACITACION Y DESARROLLO'),
(177, 22, 'ASISTENTE DE CAPACITACION Y DESARROLLO'),
(178, 22, 'AUXILIAR DE CAPACITACIÓN'),
(179, 23, 'GESTOR DE EDUCACIÓN'),
(180, 23, 'ASISTENTE DE SEGURIDAD OCUPACIONAL'),
(181, 23, 'JEFE DE CAPACITACIÓN Y DESARROLLO'),
(182, 23, 'ASISTENTE DE CAPACITACIÓN Y DESARROLLO'),
(183, 23, 'AUXILIAR DE CAPACITACIÓN'),
(187, 24, 'JEFE DE AGENCIA'),
(188, 24, 'ASESOR DE ATENCION AL ASOCIADO'),
(189, 24, 'ASESOR DE ATENCION AL ASOCIADO'),
(190, 24, 'ASESOR DE CREDITOS'),
(191, 24, 'SUBJEFE DE AGENCIA'),
(192, 24, 'RECEPTOR PAGADOR'),
(193, 24, 'ASESOR DE CREDITOS'),
(194, 24, 'ASESOR DE ATENCION AL ASOCIADO'),
(195, 24, 'RECEPTOR PAGADOR'),
(196, 24, 'ASESOR DE CREDITOS'),
(197, 25, 'JEFE DE AGENCIA'),
(198, 25, 'ASESOR DE ATENCIÓN AL ASOCIADO'),
(199, 25, 'ASESOR DE CREDITOS'),
(200, 25, 'SUBJEFE DE AGENCIA'),
(201, 25, 'RECEPTOR PAGADOR'),
(217, 26, 'ASESOR FINANCIERO'),
(218, 26, 'ASESOR FINANCIERO'),
(219, 26, 'ASESOR FINANCIERO SENIOR'),
(220, 26, 'JEFE DE VENTAS'),
(221, 26, 'AUXILIAR DE VENTAS'),
(222, 26, 'ASESOR FINANCIERO'),
(223, 27, 'ASESOR FINANCIERO'),
(224, 27, 'ASESOR FINANCIERO SENIOR'),
(225, 27, 'JEFE DE VENTAS'),
(226, 27, 'AUXILIAR DE VENTAS'),
(233, 28, 'ASISTENTE DE CREDITOS'),
(234, 28, 'ANALISTA JUNIOR'),
(235, 28, 'ANALISTA SENIOR'),
(236, 28, 'VERIFICADOR TELEFONICO'),
(237, 28, 'VERIFICADOR DE CAMPO'),
(238, 28, 'ENCARGADO DE VERIFICACION'),
(239, 28, 'ANALISTA JUNIOR'),
(240, 28, 'ANALISTA SENIOR'),
(241, 28, 'ANALISTA SENIOR'),
(242, 28, 'VERIFICADOR DE CAMPO'),
(243, 28, 'AUXILIAR TARJETA DE CREDITO/DEBITO'),
(244, 28, 'ANALISTA DE CREDITOS MAYORES'),
(245, 28, 'AUXILIAR DE BACK OFFICE'),
(246, 28, 'ENCARGADO DE TARJETA DE CREDITO/DEBITO'),
(247, 28, 'VERIFICADOR DE CAMPO'),
(248, 28, 'DIGITADOR'),
(249, 28, 'AUXILIAR DE BACK OFFICE'),
(250, 28, 'AUXILIAR DE BACK OFFICE'),
(251, 28, 'ANALISTA JUNIOR'),
(252, 28, 'ANALISTA JUNIOR'),
(253, 28, 'ANALISTA JUNIOR'),
(254, 28, 'JEFE DE CREDITOS'),
(255, 28, 'ANALISTA JUNIOR'),
(256, 28, 'ANALISTA JUNIOR'),
(257, 28, 'VERIFICADOR DE CAMPO'),
(258, 28, 'VERIFICADOR DE CAMPO'),
(259, 28, 'ANALISTA SENIOR'),
(260, 28, 'VERIFICADOR DE CAMPO'),
(261, 28, 'VERIFICADOR DE CAMPO'),
(262, 28, 'ENCARGADA DE ANALISIS DE CRÉDITOS'),
(263, 28, 'AUXILIAR DE BACK OFFICE'),
(264, 28, 'ANALISTA SENIOR'),
(265, 28, 'ANALISTA JUNIOR'),
(266, 29, 'AUXILIAR DE CUMPLIMIENTO'),
(267, 29, 'AUXILIAR DE CUMPLIMIENTO'),
(268, 29, 'AUXILIAR DE CUMPLIMIENTO'),
(269, 29, 'OFICIAL DE CUMPLIMIENTO SUPLENTE'),
(270, 29, 'OFICIAL DE CUMPLIMIENTO'),
(271, 30, 'ASISTENTE DE GERENCIA FINANCIERA'),
(272, 30, 'GERENTE FINANCIERO'),
(273, 30, 'ENCARGADO DE NOMINA Y PRESTACIONES'),
(274, 31, 'GERENTE GENERAL'),
(275, 31, 'SUB GERENTE GENERAL'),
(276, 31, 'ASISTENTE DE GERENCIA GENERAL'),
(277, 31, 'ASISTENTE DE CONSEJO DE ADMINISTRACION'),
(278, 32, 'PROGRAMADOR'),
(279, 32, 'AUXILIAR DE INFORMATICA'),
(280, 32, 'PROGRAMADOR'),
(281, 32, 'PROGRAMADOR'),
(282, 32, 'AUXILIAR DE INFORMATICA'),
(283, 32, 'JEFE DE INFORMATICA'),
(284, 32, 'PROGRAMADOR'),
(285, 32, 'AUXILIAR DE INFORMATICA'),
(286, 32, 'ASISTENTE DE INFORMATICA'),
(287, 33, 'PROGRAMADOR'),
(288, 33, 'AUXILIAR DE INFORMÁTICA'),
(289, 33, 'JEFE DE INFORMÁTICA'),
(290, 33, 'ASISTENTE DE INFORMÁTICA'),
(295, 34, 'EJECUTIVO DE KIOSCO'),
(296, 34, 'EJECUTIVO DE KIOSCO'),
(297, 35, 'EJECUTIVO DE KIOSCO'),
(299, 36, 'EJECUTIVO DE KIOSCO'),
(301, 5, 'JEFE DE MERCADEO '),
(302, 5, 'EJECUTIVO DE TELEVENTAS'),
(303, 5, 'EJECUTIVO DE TELEVENTAS'),
(304, 5, 'DISEÑADOR GRAFICO'),
(305, 5, 'EJECUTIVO DE TELEVENTAS'),
(306, 5, 'ENCARGADO DE PRODUCTOS ELECTRONICOS'),
(307, 5, 'EJECUTIVO DE TELEVENTAS'),
(308, 5, 'EJECUTIVO DE TELEVENTAS'),
(309, 5, 'EJECUTIVO DE TELEVENTAS'),
(310, 5, 'EJECUTIVO DE TELEVENTAS'),
(311, 5, 'EJECUTIVO DE TELEVENTAS'),
(312, 5, 'AUXILIAR DE MERCADEO'),
(313, 5, 'ASISTENTE DE MERCADEO'),
(314, 38, 'EJECUTIVO DE KIOSCO'),
(315, 38, 'EJECUTIVO DE KIOSCO'),
(316, 39, 'RECEPTOR PAGADOR'),
(317, 39, 'ASESOR DE CREDITOS'),
(318, 39, 'JEFE DE AGENCIA JUNIOR'),
(319, 39, 'RECEPTOR PAGADOR'),
(320, 39, 'ASESOR DE ATENCION AL ASOCIADO'),
(321, 40, 'AUXILIAR DE PROCESOS'),
(322, 40, 'JEFE DE PROCESOS Y ASEGURAMIENTO DE LA CALIDAD'),
(326, 41, 'AUXILIAR DE PROCESOS'),
(327, 41, 'JEFE DE PROCESOS Y ASEGURAMIENTO DE LA CALIDAD'),
(328, 41, 'AUXILIAR DE PROCESOS'),
(329, 42, 'ANALISTA DE OPERACIONES DE AGENCIAS'),
(330, 42, 'ANALISTA DE OPERACIONES DE AGENCIAS'),
(331, 43, 'ENCARGADO DE PREMORA'),
(332, 43, 'GESTOR DE PREMORA'),
(333, 43, 'GESTOR DE PREMORA'),
(334, 43, 'GESTOR DE PREMORA'),
(335, 43, 'GESTOR DE PREMORA'),
(336, 44, 'ANALISTA QA'),
(337, 44, 'ENCARGADO QA'),
(338, 44, 'ANALISTA QA'),
(339, 44, 'ANALISTA QA'),
(340, 44, 'ANALISTA QA'),
(341, 44, 'ANALISTA QA'),
(342, 44, 'ANALISTA QA'),
(343, 45, 'MENSAJERO'),
(344, 45, 'VELADOR'),
(345, 45, 'AUXILIAR DE SEGURIDAD'),
(346, 46, 'MENSAJERO'),
(347, 46, 'VELADOR'),
(348, 46, 'MENSAJERO'),
(349, 46, 'MENSAJERO'),
(350, 46, 'MENSAJERO'),
(351, 46, 'VELADOR'),
(352, 46, 'AUXILIAR DE SEGURIDAD'),
(353, 46, 'JEFE DE SEGURIDAD'),
(354, 47, 'CONSERJE'),
(355, 47, 'AUXILIAR DE MANTENIMIENTO'),
(356, 47, 'JEFE DE MANTENIMIENTO E INFRAESTRUCTURA'),
(358, 48, 'CONSERJE'),
(359, 48, 'AUXILIAR DE MANTENIMIENTO'),
(360, 48, 'AUXILIAR DE MANTENIMIENTO'),
(361, 48, 'JEFE DE MANTENIMIENTO E INFRAESTRUCTURA'),
(362, 48, 'CONSERJE'),
(363, 48, 'AUXILIAR DE MANTENIMIENTO'),
(364, 48, 'AUXILIAR DE MANTENIMIENTO'),
(365, 49, 'ENCARGADA DE RECLUTAMIENTO Y SELECCIÓN'),
(366, 49, 'ASISTENTE DE TALENTO HUMANO'),
(367, 49, 'JEFE DE TALENTO HUMANO'),
(368, 50, 'ENCARGADA DE RECLUTAMIENTO Y SELECCION'),
(369, 50, 'ASISTENTE DE TALENTO HUMANO'),
(370, 50, 'JEFE DE TALENTO HUMANO'),
(371, 50, 'AUXILIAR DE TALENTO HUMANO'),
(372, 50, 'AUXILIAR DE ENFERMERÍA '),
(373, 45, 'JEFE DE SEGURIDAD'),
(374, 49, 'AUXILIAR DE ENFERMERÍA'),
(375, 6, 'ASESOR DE ATENCIÓN AL ASOCIADO'),
(376, 6, 'RECEPTOR PAGADOR'),
(377, 6, 'JEFE DE AGENCIA'),
(378, 6, 'SUBJEFE DE AGENCIA'),
(379, 6, 'ASESOR DE CREDITOS'),
(380, 6, 'CONSERJE'),
(383, 15, 'CONSERJE'),
(384, 15, 'EJECUTIVO MULTIFUNCIONAL'),
(386, 17, 'ASESOR DE ATENCIÓN AL ASOCIADO'),
(387, 17, 'RECEPTOR PAGADOR'),
(388, 17, 'SUBJEFE DE AGENCIA'),
(389, 17, 'JEFE DE AGENCIA'),
(390, 17, 'CONSERJE'),
(391, 17, 'EJECUTIVO MULTIFUNCIONAL'),
(392, 17, 'ASESOR DE CREDITOS'),
(393, 19, 'EJECUTIVO MULTIFUNCIONAL'),
(397, 37, 'EJECUTIVO DE KIOSCO');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_roles`
--

DROP TABLE IF EXISTS `gen_roles`;
CREATE TABLE `gen_roles` (
  `codgenroles` int(11) NOT NULL,
  `gen_rolesnombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_roles`
--

INSERT INTO `gen_roles` (`codgenroles`, `gen_rolesnombre`) VALUES
(1, 'Administrador'),
(2, 'Usuario');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_sucursal`
--

DROP TABLE IF EXISTS `gen_sucursal`;
CREATE TABLE `gen_sucursal` (
  `codgensucursal` int(11) NOT NULL,
  `gen_sucursalnombre` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_sucursal`
--

INSERT INTO `gen_sucursal` (`codgensucursal`, `gen_sucursalnombre`) VALUES
(1, 'GERENCIAS ADMINISTRATIVA'),
(2, 'GERENCIA DE NEGOCIOS'),
(3, 'GERENCIA JURIDICA'),
(4, 'CONSEJO DE ADMINISTRACIÓN'),
(5, 'GERENCIA FINANCIERA'),
(6, 'GERENCIA GENERAL');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_tipoidentificacion`
--

DROP TABLE IF EXISTS `gen_tipoidentificacion`;
CREATE TABLE `gen_tipoidentificacion` (
  `codgentipoidentificacion` int(11) NOT NULL,
  `gen_tipoidentificacionnombre` varchar(30) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_tipoidentificacion`
--

INSERT INTO `gen_tipoidentificacion` (`codgentipoidentificacion`, `gen_tipoidentificacionnombre`) VALUES
(1, 'Dpi'),
(2, 'Visa');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_usuario`
--

DROP TABLE IF EXISTS `gen_usuario`;
CREATE TABLE `gen_usuario` (
  `codgenusuario` int(11) NOT NULL,
  `codgeninvequipo` int(11) DEFAULT NULL,
  `gen_usuarionombre` varchar(45) DEFAULT NULL,
  `gen_usuariocorreo` varchar(100) DEFAULT NULL,
  `gen_usuarioest` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gen_usuario`
--

INSERT INTO `gen_usuario` (`codgenusuario`, `codgeninvequipo`, `gen_usuarionombre`, `gen_usuariocorreo`, `gen_usuarioest`) VALUES
(1, 1, 'pggteo', 'jose.gonzalez@guadalupana.comgt', 1),
(2, 1, 'pgdgomez', 'diego.gomez@guadalupana.com.gt', 1),
(3, 1, 'pgaortiz', 'aida.ortiz@guadalupana.com.gt', 1),
(4, 1, 'pgecasasola', 'e.casasola@guadalupana.com.gt', 1),
(5, 1, 'pgmreyes', 'marlon.reyes@guadalupana.com.gt', 1),
(6, 1, 'pgachun', 'anibal.chun@guadalupana.com.gt', 1),
(7, 1, 'pggorellana', 'gerber.orellana@guadalupana.com.gt', 1),
(8, 1, 'pglalvarado', 'lester.alvarado@guadalupana.com.gt', 1),
(9, 1, 'pgggarcia', 'gerson.garcia@guadalupana.com.gt', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gen_zona`
--

DROP TABLE IF EXISTS `gen_zona`;
CREATE TABLE `gen_zona` (
  `codgenzona` int(11) NOT NULL,
  `codgendepartamento` int(11) DEFAULT NULL,
  `gen_zonanombre` varchar(12) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='		';

--
-- Volcado de datos para la tabla `gen_zona`
--

INSERT INTO `gen_zona` (`codgenzona`, `codgendepartamento`, `gen_zonanombre`) VALUES
(1, 1, 'Zona 1'),
(2, 1, 'Zona 2'),
(3, 1, 'Zona 3'),
(4, 1, 'Zona 4'),
(5, 1, 'Zona 5'),
(6, 1, 'Zona 6'),
(7, 1, 'Zona 7'),
(8, 1, 'Zona 8'),
(9, 1, 'Zona 9'),
(10, 1, 'Zona 10'),
(11, 1, 'Zona 11'),
(12, 1, 'Zona 12'),
(13, 1, 'Zona 13'),
(14, 1, 'Zona 14'),
(15, 1, 'Zona 15'),
(16, 1, 'Zona 16'),
(17, 1, 'Zona 17'),
(18, 1, 'Zona 18'),
(19, 1, 'Zona 19'),
(20, 1, 'Zona 21'),
(21, 1, 'Zona 22'),
(22, 1, 'Zona 23'),
(23, 1, 'Zona 24'),
(24, 1, 'Zona 25'),
(25, 1, 'Sin Zona');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gerencias`
--

DROP TABLE IF EXISTS `gerencias`;
CREATE TABLE `gerencias` (
  `﻿1` int(11) DEFAULT NULL,
  `GERENCIA ADMINISTRATIVA` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `gerencias`
--

INSERT INTO `gerencias` (`﻿1`, `GERENCIA ADMINISTRATIVA`) VALUES
(2, 'GERENCIA DE NEGOCIOS'),
(3, 'GERENCIA JURIDICA'),
(4, 'CONSEJO DE ADMINISTRACIÓN'),
(5, 'GERENCIA ADMINISTRATIVA'),
(6, 'GERENCIA FINANCIERA');

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `graficamontos`
-- (Véase abajo para la vista actual)
--
DROP VIEW IF EXISTS `graficamontos`;
CREATE TABLE `graficamontos` (
`resultado` decimal(7,3)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `montodatos`
-- (Véase abajo para la vista actual)
--
DROP VIEW IF EXISTS `montodatos`;
CREATE TABLE `montodatos` (
`codavtarea` int(11)
,`av_titulo` varchar(60)
,`av_estado` varchar(30)
,`av_monto` int(11)
,`fechaini` varchar(90)
,`fechafin` varchar(90)
);

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `montosview`
-- (Véase abajo para la vista actual)
--
DROP VIEW IF EXISTS `montosview`;
CREATE TABLE `montosview` (
`resultado` decimal(7,3)
);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_agencia`
--

DROP TABLE IF EXISTS `sa_agencia`;
CREATE TABLE `sa_agencia` (
  `idsa_agencia` int(11) NOT NULL,
  `sa_nombreagencia` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_agencia`
--

INSERT INTO `sa_agencia` (`idsa_agencia`, `sa_nombreagencia`) VALUES
(1, 'Central'),
(2, 'Zona 4'),
(3, 'Plaza Florida'),
(4, 'Portales'),
(5, 'Petapa'),
(6, 'Boca del Monte'),
(7, 'Gran Via'),
(8, 'San Lucas'),
(9, 'Bosques San Nicolas'),
(10, 'San Cristóbal'),
(11, 'Metrocentro'),
(12, 'Santa Catarina Pinula'),
(13, 'Metronorte'),
(14, 'Mega 6'),
(15, 'Monserrat (Kiosco)'),
(16, 'Pacific Villa'),
(18, 'Miraflores (Kiosco)'),
(19, 'Mixco'),
(20, 'Atanacio'),
(21, 'Alamos (Kiosco)'),
(22, 'Naranjo Mall'),
(23, 'Pradera zona 10 (Kiosco)'),
(25, 'Portales (Kiosco)'),
(26, 'Terminal');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_billetes`
--

DROP TABLE IF EXISTS `sa_billetes`;
CREATE TABLE `sa_billetes` (
  `idsa_billetes` int(11) NOT NULL,
  `sa_valorbilletes` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_billetes`
--

INSERT INTO `sa_billetes` (`idsa_billetes`, `sa_valorbilletes`) VALUES
(1, 200),
(2, 100),
(3, 50),
(4, 20),
(5, 10),
(6, 5),
(7, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_chequescajero`
--

DROP TABLE IF EXISTS `sa_chequescajero`;
CREATE TABLE `sa_chequescajero` (
  `idsa_chequescajero` int(11) NOT NULL,
  `idsa_tipocheque` int(11) DEFAULT NULL,
  `idsa_tipomoneda` int(11) DEFAULT NULL,
  `sa_cantidadcheques` int(11) DEFAULT NULL,
  `sa_montocheques` decimal(10,2) DEFAULT NULL,
  `sa_totaldolares` decimal(10,2) DEFAULT NULL,
  `sa_totalquetzales` decimal(10,2) DEFAULT NULL,
  `sa_bolutilizadas` varchar(50) DEFAULT NULL,
  `sa_bolreservadas` varchar(50) DEFAULT NULL,
  `sa_bolanuladas` varchar(50) DEFAULT NULL,
  `idsa_encabezadocajero` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_chequescajero`
--

INSERT INTO `sa_chequescajero` (`idsa_chequescajero`, `idsa_tipocheque`, `idsa_tipomoneda`, `sa_cantidadcheques`, `sa_montocheques`, `sa_totaldolares`, `sa_totalquetzales`, `sa_bolutilizadas`, `sa_bolreservadas`, `sa_bolanuladas`, `idsa_encabezadocajero`) VALUES
(1, 1, 1, 1, '50.00', '0.00', '200.00', 'A1-A3', '1', '1', 1),
(2, 1, 2, 1, '100.00', '0.00', '300.00', 'A1-A3', '1', '1', 1),
(3, 2, 1, 1, '150.00', '0.00', '200.00', 'A1-A3', '1', '1', 1),
(4, 2, 2, 1, '200.00', '0.00', '300.00', 'A1-A3', '1', '1', 1),
(5, 1, 1, 2, '300.00', '50.00', '300.00', 'A1-A3', '1', '1', 2),
(6, 1, 2, 1, '50.00', '50.00', '300.00', 'A1-A3', '1', '1', 2),
(7, 2, 1, 0, '0.00', '50.00', '300.00', 'A1-A3', '1', '1', 2),
(8, 2, 2, 0, '0.00', '50.00', '300.00', 'A1-A3', '1', '1', 2),
(9, 1, 1, 0, '0.00', '600.00', '550.00', 'A1-A3', 'A5', 'A7', 3),
(10, 1, 2, 0, '0.00', '600.00', '600.00', 'A1-A3', 'A5', 'A7', 3),
(11, 2, 1, 2, '550.00', '600.00', '550.00', 'A1-A3', 'A5', 'A7', 3),
(12, 2, 2, 2, '600.00', '600.00', '600.00', 'A1-A3', 'A5', 'A7', 3),
(13, 1, 1, 1, '50.00', '0.00', '150.00', 'A1-A3', 'A5', 'A7', 4),
(14, 1, 2, 0, '0.00', '0.00', '0.00', 'A1-A3', 'A5', 'A7', 4),
(15, 2, 1, 1, '100.00', '0.00', '150.00', 'A1-A3', 'A5', 'A7', 4),
(16, 2, 2, 0, '0.00', '0.00', '0.00', 'A1-A3', 'A5', 'A7', 4),
(17, 1, 1, 2, '500.00', '250.00', '500.00', 'A1-A3', 'A5', 'A7', 5),
(18, 1, 2, 2, '250.00', '250.00', '250.00', 'A1-A3', 'A5', 'A7', 5),
(19, 2, 1, 0, '0.00', '250.00', '500.00', 'A1-A3', 'A5', 'A7', 5),
(20, 2, 2, 0, '0.00', '250.00', '250.00', 'A1-A3', 'A5', 'A7', 5),
(21, 1, 1, 1, '300.00', '150.00', '300.00', 'A1-A3', 'A5', 'A7', 6),
(22, 1, 2, 1, '150.00', '150.00', '150.00', 'A1-A3', 'A5', 'A7', 6),
(23, 2, 1, 0, '0.00', '150.00', '300.00', 'A1-A3', 'A5', 'A7', 6),
(24, 2, 2, 0, '0.00', '150.00', '150.00', 'A1-A3', 'A5', 'A7', 6);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_chequestesoreria`
--

DROP TABLE IF EXISTS `sa_chequestesoreria`;
CREATE TABLE `sa_chequestesoreria` (
  `idsa_chequestesoreria` int(11) NOT NULL,
  `idsa_tipocheque` int(11) DEFAULT NULL,
  `idsa_tipomoneda` int(11) DEFAULT NULL,
  `sa_cantidadcheques` int(11) DEFAULT NULL,
  `sa_montocheques` decimal(10,2) DEFAULT NULL,
  `sa_totalcheques` int(11) DEFAULT NULL,
  `sa_totalmonto` decimal(10,2) DEFAULT NULL,
  `idsa_encabezadotesoreria` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_chequestesoreria`
--

INSERT INTO `sa_chequestesoreria` (`idsa_chequestesoreria`, `idsa_tipocheque`, `idsa_tipomoneda`, `sa_cantidadcheques`, `sa_montocheques`, `sa_totalcheques`, `sa_totalmonto`, `idsa_encabezadotesoreria`) VALUES
(1, 1, 1, 2, '600.00', 2, '600.00', 1),
(2, 2, 1, 0, '0.00', 2, '600.00', 1),
(3, 1, 2, 0, '0.00', 2, '150.00', 1),
(4, 2, 2, 2, '150.00', 2, '150.00', 1),
(5, 1, 1, 1, '350.00', 1, '350.00', 2),
(6, 2, 1, 0, '0.00', 1, '350.00', 2),
(7, 1, 2, 0, '0.00', 1, '400.00', 2),
(8, 2, 2, 1, '400.00', 1, '400.00', 2),
(9, 1, 1, 1, '100.00', 1, '100.00', 3),
(10, 2, 1, 0, '0.00', 1, '100.00', 3),
(11, 1, 2, 0, '0.00', 1, '150.00', 3),
(12, 2, 2, 1, '150.00', 1, '150.00', 3),
(13, 1, 1, 1, '500.00', 1, '500.00', 4),
(14, 2, 1, 0, '0.00', 1, '500.00', 4),
(15, 1, 1, 1, '220.00', 1, '220.00', 5),
(16, 2, 1, 0, '0.00', 1, '220.00', 5),
(17, 1, 2, 0, '0.00', 1, '230.00', 5),
(18, 2, 2, 1, '230.00', 1, '230.00', 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_cuadrecajachica`
--

DROP TABLE IF EXISTS `sa_cuadrecajachica`;
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
  `idsa_encabezadocajachica` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_cuadrecajachica`
--

INSERT INTO `sa_cuadrecajachica` (`idsa_cuadrecajachica`, `idsa_billetes`, `sa_cantidadbilletes`, `sa_subtotalbilletes`, `sa_totalbilletes`, `idsa_monedas`, `sa_cantidadmonedas`, `sa_subtotalmonedas`, `sa_totalmonedas`, `sa_totalefectivo`, `sa_totalcajachica`, `sa_comentario`, `idsa_encabezadocajachica`) VALUES
(1, 1, 2, '400.00', '550.00', 1, 0, '0.00', '0.00', '550.00', '700.00', 'Arqueo caja chica', 1),
(2, 2, 1, '100.00', '550.00', 2, 0, '0.00', '0.00', '550.00', '700.00', 'Arqueo caja chica', 1),
(3, 3, 0, '0.00', '550.00', 3, 0, '0.00', '0.00', '550.00', '700.00', 'Arqueo caja chica', 1),
(4, 4, 0, '0.00', '550.00', 4, 0, '0.00', '0.00', '550.00', '700.00', 'Arqueo caja chica', 1),
(5, 5, 5, '50.00', '550.00', 5, 0, '0.00', '0.00', '550.00', '700.00', 'Arqueo caja chica', 1),
(6, 6, 0, '0.00', '550.00', 6, 0, '0.00', '0.00', '550.00', '700.00', 'Arqueo caja chica', 1),
(7, 7, 0, '0.00', '550.00', 8, 0, '0.00', '0.00', '550.00', '700.00', 'Arqueo caja chica', 1),
(8, 1, 1, '200.00', '400.00', 1, 0, '0.00', '0.00', '400.00', '500.00', 'Arqueo caja chica', 2),
(9, 2, 1, '100.00', '400.00', 2, 0, '0.00', '0.00', '400.00', '500.00', 'Arqueo caja chica', 2),
(10, 3, 2, '100.00', '400.00', 3, 0, '0.00', '0.00', '400.00', '500.00', 'Arqueo caja chica', 2),
(11, 4, 0, '0.00', '400.00', 4, 0, '0.00', '0.00', '400.00', '500.00', 'Arqueo caja chica', 2),
(12, 5, 0, '0.00', '400.00', 5, 0, '0.00', '0.00', '400.00', '500.00', 'Arqueo caja chica', 2),
(13, 6, 0, '0.00', '400.00', 6, 0, '0.00', '0.00', '400.00', '500.00', 'Arqueo caja chica', 2),
(14, 7, 0, '0.00', '400.00', 8, 0, '0.00', '0.00', '400.00', '500.00', 'Arqueo caja chica', 2),
(15, 1, 1, '200.00', '600.00', 1, 0, '0.00', '0.00', '600.00', '700.00', 'Arqueo caja chica', 4),
(16, 2, 3, '300.00', '600.00', 2, 0, '0.00', '0.00', '600.00', '700.00', 'Arqueo caja chica', 4),
(17, 3, 2, '100.00', '600.00', 3, 0, '0.00', '0.00', '600.00', '700.00', 'Arqueo caja chica', 4),
(18, 4, 0, '0.00', '600.00', 4, 0, '0.00', '0.00', '600.00', '700.00', 'Arqueo caja chica', 4),
(19, 5, 0, '0.00', '600.00', 5, 0, '0.00', '0.00', '600.00', '700.00', 'Arqueo caja chica', 4),
(20, 6, 0, '0.00', '600.00', 6, 0, '0.00', '0.00', '600.00', '700.00', 'Arqueo caja chica', 4),
(21, 7, 0, '0.00', '600.00', 8, 0, '0.00', '0.00', '600.00', '700.00', 'Arqueo caja chica', 4),
(22, 1, 1, '200.00', '300.00', 1, 0, '0.00', '0.00', '300.00', '400.00', 'Arqueo caja chica', 5),
(23, 2, 1, '100.00', '300.00', 2, 0, '0.00', '0.00', '300.00', '400.00', 'Arqueo caja chica', 5),
(24, 3, 0, '0.00', '300.00', 3, 0, '0.00', '0.00', '300.00', '400.00', 'Arqueo caja chica', 5),
(25, 4, 0, '0.00', '300.00', 4, 0, '0.00', '0.00', '300.00', '400.00', 'Arqueo caja chica', 5),
(26, 5, 0, '0.00', '300.00', 5, 0, '0.00', '0.00', '300.00', '400.00', 'Arqueo caja chica', 5),
(27, 6, 0, '0.00', '300.00', 6, 0, '0.00', '0.00', '300.00', '400.00', 'Arqueo caja chica', 5),
(28, 7, 0, '0.00', '300.00', 8, 0, '0.00', '0.00', '300.00', '400.00', 'Arqueo caja chica', 5),
(29, 1, 1, '200.00', '350.00', 1, 0, '0.00', '0.00', '350.00', '500.00', 'Arqueo caja chica', 6),
(30, 2, 1, '100.00', '350.00', 2, 0, '0.00', '0.00', '350.00', '500.00', 'Arqueo caja chica', 6),
(31, 3, 1, '50.00', '350.00', 3, 0, '0.00', '0.00', '350.00', '500.00', 'Arqueo caja chica', 6),
(32, 4, 0, '0.00', '350.00', 4, 0, '0.00', '0.00', '350.00', '500.00', 'Arqueo caja chica', 6),
(33, 5, 0, '0.00', '350.00', 5, 0, '0.00', '0.00', '350.00', '500.00', 'Arqueo caja chica', 6),
(34, 6, 0, '0.00', '350.00', 6, 0, '0.00', '0.00', '350.00', '500.00', 'Arqueo caja chica', 6),
(35, 7, 0, '0.00', '350.00', 8, 0, '0.00', '0.00', '350.00', '500.00', 'Arqueo caja chica', 6);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_detallecajachica`
--

DROP TABLE IF EXISTS `sa_detallecajachica`;
CREATE TABLE `sa_detallecajachica` (
  `idsa_detallecajachica` int(11) NOT NULL,
  `sa_fecha` date DEFAULT NULL,
  `sa_numdocumento` int(11) DEFAULT NULL,
  `sa_proveedor` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `sa_descripcion` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  `sa_debe` decimal(10,2) DEFAULT NULL,
  `sa_haber` decimal(10,2) DEFAULT NULL,
  `idsa_encabezadocajachica` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_detallecajachica`
--

INSERT INTO `sa_detallecajachica` (`idsa_detallecajachica`, `sa_fecha`, `sa_numdocumento`, `sa_proveedor`, `sa_descripcion`, `sa_debe`, `sa_haber`, `idsa_encabezadocajachica`) VALUES
(1, '2021-02-15', 455, 'Wallmart S.A.', 'Insumos de limpieza', '0.00', '50.00', 1),
(2, '2021-02-13', 456, 'Bebidas Preparadas', 'Agua Pura', '0.00', '100.00', 1),
(3, '2021-02-10', 135, 'Bebidas Preparadas', 'Agua', '0.00', '100.00', 2),
(4, '2021-02-12', 136, 'Wallmart S.A.', 'Desinfectante', '0.00', '150.00', 2),
(5, '2021-03-01', 123, 'Bebidas Preparadas', 'Agua', '0.00', '100.00', 3),
(6, '2021-03-01', 123, 'La Torre S.A.', 'Insumos de limpieza', '0.00', '50.00', 3),
(7, '2021-02-27', 123, 'La Torre S.A.', 'Insumos de limpieza', '0.00', '100.00', 4),
(8, '2021-03-01', 345, 'La Torre S.A.', 'Insumos de limpieza', '0.00', '100.00', 5),
(9, '2021-03-01', 257, 'Bebidas Preparadas', 'Agua Pura', '0.00', '50.00', 6),
(10, '2021-03-01', 876, 'Wallmart S.A.', 'Alcohol en Gel', '0.00', '100.00', 6);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_detallecajero`
--

DROP TABLE IF EXISTS `sa_detallecajero`;
CREATE TABLE `sa_detallecajero` (
  `idsa_detallecajero` int(11) NOT NULL,
  `idsa_billetes` int(11) DEFAULT NULL,
  `sa_cantidadbilletes` int(11) DEFAULT NULL,
  `sa_totalbilletes` decimal(10,2) DEFAULT NULL,
  `idsa_monedas` int(11) DEFAULT NULL,
  `sa_cantidadmonedas` int(11) DEFAULT NULL,
  `sa_totalmonedas` decimal(10,2) DEFAULT NULL,
  `sa_totalcierre` decimal(10,2) DEFAULT NULL,
  `sa_totalrecibido` decimal(10,2) DEFAULT NULL,
  `sa_totalentregado` decimal(10,2) DEFAULT NULL,
  `idsa_encabezadocajero` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_detallecajero`
--

INSERT INTO `sa_detallecajero` (`idsa_detallecajero`, `idsa_billetes`, `sa_cantidadbilletes`, `sa_totalbilletes`, `idsa_monedas`, `sa_cantidadmonedas`, `sa_totalmonedas`, `sa_totalcierre`, `sa_totalrecibido`, `sa_totalentregado`, `idsa_encabezadocajero`) VALUES
(1, 1, 2, '400.00', 1, 0, '0.00', '523.22', '100.00', '100.00', 1),
(2, 2, 0, '0.00', 2, 2, '1.00', '523.22', '100.00', '100.00', 1),
(3, 3, 2, '100.00', 3, 0, '0.00', '523.22', '100.00', '100.00', 1),
(4, 4, 0, '0.00', 4, 2, '0.20', '523.22', '100.00', '100.00', 1),
(5, 5, 2, '20.00', 5, 0, '0.00', '523.22', '100.00', '100.00', 1),
(6, 6, 0, '0.00', 6, 2, '0.02', '523.22', '100.00', '100.00', 1),
(7, 7, 2, '2.00', 8, 0, '0.00', '523.22', '100.00', '100.00', 1),
(8, 1, 1, '200.00', 1, 0, '0.00', '221.61', '30.00', '30.00', 2),
(9, 2, 0, '0.00', 2, 1, '0.50', '221.61', '30.00', '30.00', 2),
(10, 3, 0, '0.00', 3, 0, '0.00', '221.61', '30.00', '30.00', 2),
(11, 4, 1, '20.00', 4, 1, '0.10', '221.61', '30.00', '30.00', 2),
(12, 5, 0, '0.00', 5, 0, '0.00', '221.61', '30.00', '30.00', 2),
(13, 6, 0, '0.00', 6, 1, '0.01', '221.61', '30.00', '30.00', 2),
(14, 7, 1, '1.00', 8, 0, '0.00', '221.61', '30.00', '30.00', 2),
(15, 1, 2, '400.00', 1, 0, '0.00', '523.22', '100.00', '100.00', 3),
(16, 2, 0, '0.00', 2, 2, '1.00', '523.22', '100.00', '100.00', 3),
(17, 3, 2, '100.00', 3, 0, '0.00', '523.22', '100.00', '100.00', 3),
(18, 4, 0, '0.00', 4, 2, '0.20', '523.22', '100.00', '100.00', 3),
(19, 5, 2, '20.00', 5, 0, '0.00', '523.22', '100.00', '100.00', 3),
(20, 6, 0, '0.00', 6, 2, '0.02', '523.22', '100.00', '100.00', 3),
(21, 7, 2, '2.00', 8, 0, '0.00', '523.22', '100.00', '100.00', 3),
(22, 1, 1, '200.00', 1, 1, '1.00', '211.26', '100.00', '100.00', 4),
(23, 2, 0, '0.00', 2, 0, '0.00', '211.26', '100.00', '100.00', 4),
(24, 3, 0, '0.00', 3, 1, '0.25', '211.26', '100.00', '100.00', 4),
(25, 4, 0, '0.00', 4, 0, '0.00', '211.26', '100.00', '100.00', 4),
(26, 5, 1, '10.00', 5, 0, '0.00', '211.26', '100.00', '100.00', 4),
(27, 6, 0, '0.00', 6, 1, '0.01', '211.26', '100.00', '100.00', 4),
(28, 7, 0, '0.00', 8, 0, '0.00', '211.26', '100.00', '100.00', 4),
(29, 1, 1, '200.00', 1, 0, '0.00', '261.00', '230.00', '230.00', 5),
(30, 2, 0, '0.00', 2, 0, '0.00', '261.00', '230.00', '230.00', 5),
(31, 3, 1, '50.00', 3, 0, '0.00', '261.00', '230.00', '230.00', 5),
(32, 4, 0, '0.00', 4, 0, '0.00', '261.00', '230.00', '230.00', 5),
(33, 5, 1, '10.00', 5, 0, '0.00', '261.00', '230.00', '230.00', 5),
(34, 6, 0, '0.00', 6, 0, '0.00', '261.00', '230.00', '230.00', 5),
(35, 7, 1, '1.00', 8, 0, '0.00', '261.00', '230.00', '230.00', 5),
(36, 1, 2, '400.00', 1, 0, '0.00', '522.00', '500.00', '500.00', 6),
(37, 2, 0, '0.00', 2, 0, '0.00', '522.00', '500.00', '500.00', 6),
(38, 3, 2, '100.00', 3, 0, '0.00', '522.00', '500.00', '500.00', 6),
(39, 4, 0, '0.00', 4, 0, '0.00', '522.00', '500.00', '500.00', 6),
(40, 5, 2, '20.00', 5, 0, '0.00', '522.00', '500.00', '500.00', 6),
(41, 6, 0, '0.00', 6, 0, '0.00', '522.00', '500.00', '500.00', 6),
(42, 7, 2, '2.00', 8, 0, '0.00', '522.00', '500.00', '500.00', 6);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_detallecajeroaut`
--

DROP TABLE IF EXISTS `sa_detallecajeroaut`;
CREATE TABLE `sa_detallecajeroaut` (
  `idsa_detallecajeroaut` int(11) NOT NULL,
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
  `idsa_encabezadocajeroaut` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_detallecajeroaut`
--

INSERT INTO `sa_detallecajeroaut` (`idsa_detallecajeroaut`, `idsa_billetes`, `sa_cantidadbilletes`, `sa_subtotalbilletes`, `sa_totalbilletes`, `idsa_monedas`, `sa_cantidadmonedas`, `sa_subtotalmonedas`, `sa_totalmonedas`, `sa_totalefectivo`, `sa_efectivoreporte`, `sa_diferencia`, `sa_observaciones`, `idsa_encabezadocajeroaut`) VALUES
(1, 1, 1, '200.00', '221.00', 1, 0, '0.00', '0.55', '221.55', '30.00', '191.55', 'arqueo', 1),
(2, 2, 0, '0.00', '221.00', 2, 1, '0.50', '0.55', '221.55', '30.00', '191.55', 'arqueo', 1),
(3, 3, 0, '0.00', '221.00', 3, 0, '0.00', '0.55', '221.55', '30.00', '191.55', 'arqueo', 1),
(4, 4, 1, '20.00', '221.00', 4, 0, '0.00', '0.55', '221.55', '30.00', '191.55', 'arqueo', 1),
(5, 5, 0, '0.00', '221.00', 5, 1, '0.05', '0.55', '221.55', '30.00', '191.55', 'arqueo', 1),
(6, 6, 0, '0.00', '221.00', 6, 0, '0.05', '0.55', '221.55', '30.00', '191.55', 'arqueo', 1),
(7, 7, 1, '1.00', '221.00', 8, 0, '0.00', '0.55', '221.55', '30.00', '191.55', 'arqueo', 1),
(8, 1, 2, '400.00', '522.00', 1, 0, '0.00', '1.22', '523.22', '50.00', '473.22', 'arqueo', 2),
(9, 2, 0, '0.00', '522.00', 2, 2, '1.00', '1.22', '523.22', '50.00', '473.22', 'arqueo', 2),
(10, 3, 2, '100.00', '522.00', 3, 0, '0.00', '1.22', '523.22', '50.00', '473.22', 'arqueo', 2),
(11, 4, 0, '0.00', '522.00', 4, 2, '0.20', '1.22', '523.22', '50.00', '473.22', 'arqueo', 2),
(12, 5, 2, '20.00', '522.00', 5, 0, '0.00', '1.22', '523.22', '50.00', '473.22', 'arqueo', 2),
(13, 6, 0, '0.00', '522.00', 6, 2, '0.00', '1.22', '523.22', '50.00', '473.22', 'arqueo', 2),
(14, 7, 2, '2.00', '522.00', 8, 0, '0.00', '1.22', '523.22', '50.00', '473.22', 'arqueo', 2),
(15, 1, 2, '400.00', '522.00', 1, 1, '1.00', '1.91', '523.91', '30.00', '493.91', 'arqueo cajero automatico', 3),
(16, 2, 0, '0.00', '522.00', 2, 1, '0.50', '1.91', '523.91', '30.00', '493.91', 'arqueo cajero automatico', 3),
(17, 3, 2, '100.00', '522.00', 3, 1, '0.25', '1.91', '523.91', '30.00', '493.91', 'arqueo cajero automatico', 3),
(18, 4, 0, '0.00', '522.00', 4, 1, '0.10', '1.91', '523.91', '30.00', '493.91', 'arqueo cajero automatico', 3),
(19, 5, 2, '20.00', '522.00', 5, 1, '0.05', '1.91', '523.91', '30.00', '493.91', 'arqueo cajero automatico', 3),
(20, 6, 0, '0.00', '522.00', 6, 1, '0.05', '1.91', '523.91', '30.00', '493.91', 'arqueo cajero automatico', 3),
(21, 7, 2, '2.00', '522.00', 8, 0, '0.00', '1.91', '523.91', '30.00', '493.91', 'arqueo cajero automatico', 3),
(22, 1, 3, '600.00', '960.00', 1, 0, '0.00', '0.00', '960.00', '200.00', '760.00', 'arqueo', 4),
(23, 2, 3, '300.00', '960.00', 2, 0, '0.00', '0.00', '960.00', '200.00', '760.00', 'arqueo', 4),
(24, 3, 0, '0.00', '960.00', 3, 0, '0.00', '0.00', '960.00', '200.00', '760.00', 'arqueo', 4),
(25, 4, 3, '60.00', '960.00', 4, 0, '0.00', '0.00', '960.00', '200.00', '760.00', 'arqueo', 4),
(26, 5, 0, '0.00', '960.00', 5, 0, '0.00', '0.00', '960.00', '200.00', '760.00', 'arqueo', 4),
(27, 6, 0, '0.00', '960.00', 6, 0, '0.00', '0.00', '960.00', '200.00', '760.00', 'arqueo', 4),
(28, 7, 0, '0.00', '960.00', 8, 0, '0.00', '0.00', '960.00', '200.00', '760.00', 'arqueo', 4),
(29, 1, 1, '200.00', '261.00', 1, 0, '0.00', '0.00', '261.00', '100.00', '161.00', 'arqueo cajero automatico', 5),
(30, 2, 0, '0.00', '261.00', 2, 0, '0.00', '0.00', '261.00', '100.00', '161.00', 'arqueo cajero automatico', 5),
(31, 3, 1, '50.00', '261.00', 3, 0, '0.00', '0.00', '261.00', '100.00', '161.00', 'arqueo cajero automatico', 5),
(32, 4, 0, '0.00', '261.00', 4, 0, '0.00', '0.00', '261.00', '100.00', '161.00', 'arqueo cajero automatico', 5),
(33, 5, 1, '10.00', '261.00', 5, 0, '0.00', '0.00', '261.00', '100.00', '161.00', 'arqueo cajero automatico', 5),
(34, 6, 0, '0.00', '261.00', 6, 0, '0.00', '0.00', '261.00', '100.00', '161.00', 'arqueo cajero automatico', 5),
(35, 7, 1, '1.00', '261.00', 8, 0, '0.00', '0.00', '261.00', '100.00', '161.00', 'arqueo cajero automatico', 5),
(36, 1, 2, '400.00', '522.00', 1, 0, '0.00', '0.00', '522.00', '50.00', '472.00', 'arqueo cajero automatico', 6),
(37, 2, 0, '0.00', '522.00', 2, 0, '0.00', '0.00', '522.00', '50.00', '472.00', 'arqueo cajero automatico', 6),
(38, 3, 2, '100.00', '522.00', 3, 0, '0.00', '0.00', '522.00', '50.00', '472.00', 'arqueo cajero automatico', 6),
(39, 4, 0, '0.00', '522.00', 4, 0, '0.00', '0.00', '522.00', '50.00', '472.00', 'arqueo cajero automatico', 6),
(40, 5, 2, '20.00', '522.00', 5, 0, '0.00', '0.00', '522.00', '50.00', '472.00', 'arqueo cajero automatico', 6),
(41, 6, 0, '0.00', '522.00', 6, 0, '0.00', '0.00', '522.00', '50.00', '472.00', 'arqueo cajero automatico', 6),
(42, 7, 2, '2.00', '522.00', 8, 0, '0.00', '0.00', '522.00', '50.00', '472.00', 'arqueo cajero automatico', 6),
(43, 1, 1, '200.00', '312.00', 1, 0, '0.00', '0.00', '312.00', '120.00', '192.00', 'arqueo cajero automatico', 7),
(44, 2, 0, '0.00', '312.00', 2, 0, '0.00', '0.00', '312.00', '120.00', '192.00', 'arqueo cajero automatico', 7),
(45, 3, 2, '100.00', '312.00', 3, 0, '0.00', '0.00', '312.00', '120.00', '192.00', 'arqueo cajero automatico', 7),
(46, 4, 0, '0.00', '312.00', 4, 0, '0.00', '0.00', '312.00', '120.00', '192.00', 'arqueo cajero automatico', 7),
(47, 5, 1, '10.00', '312.00', 5, 0, '0.00', '0.00', '312.00', '120.00', '192.00', 'arqueo cajero automatico', 7),
(48, 6, 0, '0.00', '312.00', 6, 0, '0.00', '0.00', '312.00', '120.00', '192.00', 'arqueo cajero automatico', 7),
(49, 7, 2, '2.00', '312.00', 8, 0, '0.00', '0.00', '312.00', '120.00', '192.00', 'arqueo cajero automatico', 7);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_detalletesoreria`
--

DROP TABLE IF EXISTS `sa_detalletesoreria`;
CREATE TABLE `sa_detalletesoreria` (
  `idsa_detalletesoreria` int(11) NOT NULL,
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
  `idsa_encabezadotesoreria` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_detalletesoreria`
--

INSERT INTO `sa_detalletesoreria` (`idsa_detalletesoreria`, `sa_tipomoneda`, `idsa_billetes`, `sa_cantidadbilletes`, `sa_subtotalbilletes`, `sa_totalbilletes`, `idsa_monedas`, `sa_cantidadmonedas`, `sa_subtotalmonedas`, `sa_totalmonedas`, `sa_totalefectivo`, `sa_solicitud`, `sa_efectivoentregado`, `sa_totalfondo`, `sa_remesapendiente`, `sa_deposito`, `idsa_encabezadotesoreria`) VALUES
(1, 1, 1, 3, '600.00', '675.00', 1, 0, '0.00', '1.65', '676.65', '50.00', '50.00', '776.65', '0.00', '0.00', 1),
(2, 1, 2, 0, '0.00', '675.00', 2, 3, '1.50', '1.65', '676.65', '50.00', '50.00', '776.65', '0.00', '0.00', 1),
(3, 1, 3, 0, '0.00', '675.00', 3, 0, '0.00', '1.65', '676.65', '50.00', '50.00', '776.65', '0.00', '0.00', 1),
(4, 1, 4, 3, '60.00', '675.00', 4, 0, '0.00', '1.65', '676.65', '50.00', '50.00', '776.65', '0.00', '0.00', 1),
(5, 1, 5, 0, '0.00', '675.00', 5, 3, '0.15', '1.65', '676.65', '50.00', '50.00', '776.65', '0.00', '0.00', 1),
(6, 1, 6, 3, '15.00', '675.00', 6, 0, '0.00', '1.65', '676.65', '50.00', '50.00', '776.65', '0.00', '0.00', 1),
(7, 1, 7, 0, '0.00', '675.00', 8, 0, '0.00', '1.65', '676.65', '50.00', '50.00', '776.65', '0.00', '0.00', 1),
(8, 2, 1, 2, '400.00', '450.00', 1, 2, '2.00', '2.60', '452.60', '0.00', '0.00', '0.00', '0.00', '452.60', 1),
(9, 2, 2, 0, '0.00', '450.00', 2, 0, '0.00', '2.60', '452.60', '0.00', '0.00', '0.00', '0.00', '452.60', 1),
(10, 2, 3, 0, '0.00', '450.00', 3, 2, '0.50', '2.60', '452.60', '0.00', '0.00', '0.00', '0.00', '452.60', 1),
(11, 2, 4, 2, '40.00', '450.00', 4, 0, '0.00', '2.60', '452.60', '0.00', '0.00', '0.00', '0.00', '452.60', 1),
(12, 2, 5, 0, '0.00', '450.00', 5, 2, '0.10', '2.60', '452.60', '0.00', '0.00', '0.00', '0.00', '452.60', 1),
(13, 2, 6, 2, '10.00', '450.00', 6, 0, '0.00', '2.60', '452.60', '0.00', '0.00', '0.00', '0.00', '452.60', 1),
(14, 2, 7, 0, '0.00', '450.00', 8, 0, '0.00', '2.60', '452.60', '0.00', '0.00', '0.00', '0.00', '452.60', 1),
(15, 1, 1, 3, '600.00', '783.00', 1, 0, '0.00', '1.83', '784.83', '100.00', '100.00', '984.83', '0.00', '0.00', 2),
(16, 1, 2, 0, '0.00', '783.00', 2, 3, '1.50', '1.83', '784.83', '100.00', '100.00', '984.83', '0.00', '0.00', 2),
(17, 1, 3, 3, '150.00', '783.00', 3, 0, '0.00', '1.83', '784.83', '100.00', '100.00', '984.83', '0.00', '0.00', 2),
(18, 1, 4, 0, '0.00', '783.00', 4, 3, '0.30', '1.83', '784.83', '100.00', '100.00', '984.83', '0.00', '0.00', 2),
(19, 1, 5, 3, '30.00', '783.00', 5, 0, '0.00', '1.83', '784.83', '100.00', '100.00', '984.83', '0.00', '0.00', 2),
(20, 1, 6, 0, '0.00', '783.00', 6, 3, '0.03', '1.83', '784.83', '100.00', '100.00', '984.83', '0.00', '0.00', 2),
(21, 1, 7, 3, '3.00', '783.00', 8, 0, '0.00', '1.83', '784.83', '100.00', '100.00', '984.83', '0.00', '0.00', 2),
(22, 2, 1, 3, '600.00', '783.00', 1, 0, '0.00', '1.83', '784.83', '0.00', '0.00', '0.00', '100.00', '884.83', 2),
(23, 2, 2, 0, '0.00', '783.00', 2, 3, '1.50', '1.83', '784.83', '0.00', '0.00', '0.00', '100.00', '884.83', 2),
(24, 2, 3, 3, '150.00', '783.00', 3, 0, '0.00', '1.83', '784.83', '0.00', '0.00', '0.00', '100.00', '884.83', 2),
(25, 2, 4, 0, '0.00', '783.00', 4, 3, '0.30', '1.83', '784.83', '0.00', '0.00', '0.00', '100.00', '884.83', 2),
(26, 2, 5, 3, '30.00', '783.00', 5, 0, '0.00', '1.83', '784.83', '0.00', '0.00', '0.00', '100.00', '884.83', 2),
(27, 2, 6, 0, '0.00', '783.00', 6, 3, '0.03', '1.83', '784.83', '0.00', '0.00', '0.00', '100.00', '884.83', 2),
(28, 2, 7, 3, '3.00', '783.00', 8, 0, '0.00', '1.83', '784.83', '0.00', '0.00', '0.00', '100.00', '884.83', 2),
(29, 1, 1, 1, '200.00', '386.00', 1, 0, '0.00', '0.00', '386.00', '30.00', '30.00', '446.00', '0.00', '0.00', 3),
(30, 1, 2, 1, '100.00', '386.00', 2, 0, '0.00', '0.00', '386.00', '30.00', '30.00', '446.00', '0.00', '0.00', 3),
(31, 1, 3, 1, '50.00', '386.00', 3, 0, '0.00', '0.00', '386.00', '30.00', '30.00', '446.00', '0.00', '0.00', 3),
(32, 1, 4, 1, '20.00', '386.00', 4, 0, '0.00', '0.00', '386.00', '30.00', '30.00', '446.00', '0.00', '0.00', 3),
(33, 1, 5, 1, '10.00', '386.00', 5, 0, '0.00', '0.00', '386.00', '30.00', '30.00', '446.00', '0.00', '0.00', 3),
(34, 1, 6, 1, '5.00', '386.00', 6, 0, '0.00', '0.00', '386.00', '30.00', '30.00', '446.00', '0.00', '0.00', 3),
(35, 1, 7, 1, '1.00', '386.00', 8, 0, '0.00', '0.00', '386.00', '30.00', '30.00', '446.00', '0.00', '0.00', 3),
(36, 2, 1, 1, '200.00', '261.00', 1, 0, '0.00', '0.00', '261.00', '0.00', '0.00', '0.00', '60.00', '321.00', 3),
(37, 2, 2, 0, '0.00', '261.00', 2, 0, '0.00', '0.00', '261.00', '0.00', '0.00', '0.00', '60.00', '321.00', 3),
(38, 2, 3, 1, '50.00', '261.00', 3, 0, '0.00', '0.00', '261.00', '0.00', '0.00', '0.00', '60.00', '321.00', 3),
(39, 2, 4, 0, '0.00', '261.00', 4, 0, '0.00', '0.00', '261.00', '0.00', '0.00', '0.00', '60.00', '321.00', 3),
(40, 2, 5, 1, '10.00', '261.00', 5, 0, '0.00', '0.00', '261.00', '0.00', '0.00', '0.00', '60.00', '321.00', 3),
(41, 2, 6, 0, '0.00', '261.00', 6, 0, '0.00', '0.00', '261.00', '0.00', '0.00', '0.00', '60.00', '321.00', 3),
(42, 2, 7, 1, '1.00', '261.00', 8, 0, '0.00', '0.00', '261.00', '0.00', '0.00', '0.00', '60.00', '321.00', 3),
(43, 1, 1, 3, '600.00', '630.00', 1, 0, '0.00', '0.03', '630.03', '100.00', '50.00', '780.03', '0.00', '0.00', 4),
(44, 1, 2, 0, '0.00', '630.00', 2, 0, '0.00', '0.03', '630.03', '100.00', '50.00', '780.03', '0.00', '0.00', 4),
(45, 1, 3, 0, '0.00', '630.00', 3, 0, '0.00', '0.03', '630.03', '100.00', '50.00', '780.03', '0.00', '0.00', 4),
(46, 1, 4, 0, '0.00', '630.00', 4, 0, '0.00', '0.03', '630.03', '100.00', '50.00', '780.03', '0.00', '0.00', 4),
(47, 1, 5, 3, '30.00', '630.00', 5, 0, '0.00', '0.03', '630.03', '100.00', '50.00', '780.03', '0.00', '0.00', 4),
(48, 1, 6, 0, '0.00', '630.00', 6, 3, '0.03', '0.03', '630.03', '100.00', '50.00', '780.03', '0.00', '0.00', 4),
(49, 1, 7, 0, '0.00', '630.00', 8, 0, '0.00', '0.03', '630.03', '100.00', '50.00', '780.03', '0.00', '0.00', 4),
(50, 1, 1, 1, '200.00', '261.00', 1, 0, '0.00', '0.00', '261.00', '220.00', '120.00', '601.00', '0.00', '0.00', 5),
(51, 1, 2, 0, '0.00', '261.00', 2, 0, '0.00', '0.00', '261.00', '220.00', '120.00', '601.00', '0.00', '0.00', 5),
(52, 1, 3, 1, '50.00', '261.00', 3, 0, '0.00', '0.00', '261.00', '220.00', '120.00', '601.00', '0.00', '0.00', 5),
(53, 1, 4, 0, '0.00', '261.00', 4, 0, '0.00', '0.00', '261.00', '220.00', '120.00', '601.00', '0.00', '0.00', 5),
(54, 1, 5, 1, '10.00', '261.00', 5, 0, '0.00', '0.00', '261.00', '220.00', '120.00', '601.00', '0.00', '0.00', 5),
(55, 1, 6, 0, '0.00', '261.00', 6, 0, '0.00', '0.00', '261.00', '220.00', '120.00', '601.00', '0.00', '0.00', 5),
(56, 1, 7, 1, '1.00', '261.00', 8, 0, '0.00', '0.00', '261.00', '220.00', '120.00', '601.00', '0.00', '0.00', 5),
(57, 2, 1, 2, '400.00', '522.00', 1, 0, '0.00', '0.00', '522.00', '0.00', '0.00', '0.00', '450.00', '972.00', 5),
(58, 2, 2, 0, '0.00', '522.00', 2, 0, '0.00', '0.00', '522.00', '0.00', '0.00', '0.00', '450.00', '972.00', 5),
(59, 2, 3, 2, '100.00', '522.00', 3, 0, '0.00', '0.00', '522.00', '0.00', '0.00', '0.00', '450.00', '972.00', 5),
(60, 2, 4, 0, '0.00', '522.00', 4, 0, '0.00', '0.00', '522.00', '0.00', '0.00', '0.00', '450.00', '972.00', 5),
(61, 2, 5, 2, '20.00', '522.00', 5, 0, '0.00', '0.00', '522.00', '0.00', '0.00', '0.00', '450.00', '972.00', 5),
(62, 2, 6, 0, '0.00', '522.00', 6, 0, '0.00', '0.00', '522.00', '0.00', '0.00', '0.00', '450.00', '972.00', 5),
(63, 2, 7, 2, '2.00', '522.00', 8, 0, '0.00', '0.00', '522.00', '0.00', '0.00', '0.00', '450.00', '972.00', 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_encabezadocajachica`
--

DROP TABLE IF EXISTS `sa_encabezadocajachica`;
CREATE TABLE `sa_encabezadocajachica` (
  `idsa_encabezadocajachica` int(11) NOT NULL,
  `sa_numarqueo` int(11) DEFAULT NULL,
  `idsa_usuario` int(11) DEFAULT NULL,
  `sa_agencia` int(11) DEFAULT NULL,
  `sa_fecha` datetime DEFAULT NULL,
  `sa_nombre` varchar(50) DEFAULT NULL,
  `sa_numoperador` int(11) DEFAULT NULL,
  `sa_puestooperador` varchar(50) DEFAULT NULL,
  `sa_nombreencargado` varchar(50) DEFAULT NULL,
  `sa_puestoencargado` varchar(50) DEFAULT NULL,
  `sa_saldoinicial` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_encabezadocajachica`
--

INSERT INTO `sa_encabezadocajachica` (`idsa_encabezadocajachica`, `sa_numarqueo`, `idsa_usuario`, `sa_agencia`, `sa_fecha`, `sa_nombre`, `sa_numoperador`, `sa_puestooperador`, `sa_nombreencargado`, `sa_puestoencargado`, `sa_saldoinicial`) VALUES
(1, 1, 3, 5, '2021-02-26 14:31:00', 'Aida Jimena Ortiz Delgado', 1256, 'Auditor', 'Juan Perez', 'Auditor', '700.00'),
(2, 1, 3, 13, '2021-02-27 23:11:00', 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Carlos Perez', 'Auditor', '500.00'),
(3, 1, 3, 15, '2021-02-28 14:56:00', 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Carlos Garcia', 'Auditor', '700.00'),
(4, 1, 3, 5, '2021-03-01 15:33:00', 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Luis Perez', 'Auditor', '700.00'),
(5, 1, 3, 12, '2021-03-02 18:16:00', 'Luisa Garcia', 123, 'Auditor', 'Aida Jimena Ortiz Delgado', 'Jefe', '700.00'),
(6, 2, 3, 6, '2021-03-02 18:25:00', 'Fernando Jimenez', 123, 'Auditor', 'Aida Jimena Ortiz Delgado', 'Jefe', '500.00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_encabezadocajero`
--

DROP TABLE IF EXISTS `sa_encabezadocajero`;
CREATE TABLE `sa_encabezadocajero` (
  `idsa_encabezadocajero` int(11) NOT NULL,
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
  `sa_comentarios` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_encabezadocajero`
--

INSERT INTO `sa_encabezadocajero` (`idsa_encabezadocajero`, `sa_numarqueo`, `idsa_usuario`, `sa_fechayhora`, `sa_agencia`, `sa_nombre`, `sa_usuario`, `sa_operador`, `sa_puestooperador`, `sa_nombreencargado`, `sa_puestoencargado`, `sa_comentarios`) VALUES
(1, 1, 3, '2021-02-26 12:50:00', 3, 'Aida Jimena Ortiz Delgado', 'pgaortiz', 123, 'Auditor', 'Juan Perez', 'Auditor', 'arqueo '),
(2, 1, 3, '2021-02-27 21:51:00', 12, 'Aida Jimena Ortiz Delgado', 'pgaortiz', 456, 'Auditor', 'Juan Perez', 'Auditor', 'arqueo '),
(3, 1, 3, '2021-02-28 14:33:00', 16, 'Aida Jimena Ortiz Delgado', 'pgaortiz', 456, 'Auditor', 'Juan Perez', 'Auditor', 'arqueo '),
(4, 1, 3, '2021-03-01 15:07:00', 25, 'Aida Jimena Ortiz Delgado', 'pgaortiz', 456, 'Auditor', 'Juan Perez', 'Auditor', 'arqueo '),
(5, 1, 3, '2021-03-02 19:01:00', 12, 'Luisa Ortiz', 'pglortiz', 456, 'Auditor', 'Aida Jimena Ortiz Delgado', 'Jefe', 'arqueo '),
(6, 2, 3, '2021-03-02 19:05:00', 5, 'Silvia Delgado', 'pgsdelgado', 123, 'Auditor', 'Aida Jimena Ortiz Delgado', 'Jefe', 'arqueo 2');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_encabezadocajeroaut`
--

DROP TABLE IF EXISTS `sa_encabezadocajeroaut`;
CREATE TABLE `sa_encabezadocajeroaut` (
  `idsa_encabezadocajeroaut` int(11) NOT NULL,
  `sa_numarqueo` int(11) DEFAULT NULL,
  `idsa_usuario` int(11) DEFAULT NULL,
  `sa_fechayhora` datetime DEFAULT NULL,
  `sa_agencia` int(11) DEFAULT NULL,
  `sa_nombreoperador` varchar(50) DEFAULT NULL,
  `sa_numoperador` int(11) DEFAULT NULL,
  `sa_puestooperador` varchar(50) DEFAULT NULL,
  `sa_nombreencargado` varchar(50) DEFAULT NULL,
  `sa_puestoencargado` varchar(50) DEFAULT NULL,
  `sa_atm` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_encabezadocajeroaut`
--

INSERT INTO `sa_encabezadocajeroaut` (`idsa_encabezadocajeroaut`, `sa_numarqueo`, `idsa_usuario`, `sa_fechayhora`, `sa_agencia`, `sa_nombreoperador`, `sa_numoperador`, `sa_puestooperador`, `sa_nombreencargado`, `sa_puestoencargado`, `sa_atm`) VALUES
(1, 1, 3, '2021-02-26 14:15:00', 5, 'Aida Jimena Ortiz Delgado', 456, 'Auditor', 'Juan Perez', 'Auditor', '20000.00'),
(2, 1, 3, '2021-02-27 23:05:00', 7, 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Luis Perez', 'Auditor', '20000.00'),
(3, 1, 3, '2021-02-28 14:35:00', 15, 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Luis Perez', 'Auditor', '20000.00'),
(4, 1, 3, '2021-03-01 15:23:00', 11, 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Juan Perez', 'Auditor', '20000.00'),
(5, 1, 3, '2021-03-02 16:01:00', 5, 'Andres Lopez', 123, 'Auditor', 'Aida Jimena Ortiz Delgado', 'Jefe', '20000.00'),
(6, 2, 3, '2021-03-02 16:08:00', 6, 'Gerson Garcia', 123, 'Auditor', 'Aida Jimena Ortiz Delgado', 'Jefe', '20000.00'),
(7, 3, 3, '2021-03-02 16:11:00', 4, 'Juan Perez', 123, 'Auditor', 'Aida Jimena Ortiz Delgado', 'Jefe', '20000.00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_encabezadotesoreria`
--

DROP TABLE IF EXISTS `sa_encabezadotesoreria`;
CREATE TABLE `sa_encabezadotesoreria` (
  `idsa_encabezadotesoreria` int(11) NOT NULL,
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
  `sa_tesoreriaDol` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_encabezadotesoreria`
--

INSERT INTO `sa_encabezadotesoreria` (`idsa_encabezadotesoreria`, `sa_numarqueo`, `idsa_usuario`, `sa_fechayhora`, `sa_agencia`, `sa_nombreoperador`, `sa_numoperador`, `sa_puestooperador`, `sa_nombreencargado`, `sa_puestoencargado`, `sa_tesoreriaQ`, `sa_tesoreriaDol`) VALUES
(1, 1, 3, '2021-02-26 14:18:00', 14, 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Juan Perez', 'Jefe', '300.00', '500.00'),
(2, 1, 3, '2021-02-27 23:07:00', 25, 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Juan Perez', 'Jefe', '500.00', '600.00'),
(3, 1, 3, '2021-02-28 14:54:00', 5, 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Juan Perez', 'Auditor', '250.00', '300.00'),
(4, 1, 3, '2021-03-02 15:27:00', 8, 'Aida Jimena Ortiz Delgado', 123, 'Auditor', 'Luis Perez', 'Auditor', '500.00', '0.00'),
(5, 2, 3, '2021-03-02 19:16:00', 3, 'Andres Lopez', 123, 'Auditor', 'Aida Jimena Ortiz Delgado', 'Jefe', '500.00', '300.00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_monedas`
--

DROP TABLE IF EXISTS `sa_monedas`;
CREATE TABLE `sa_monedas` (
  `idsa_monedas` int(11) NOT NULL,
  `sa_valormonedas` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_monedas`
--

INSERT INTO `sa_monedas` (`idsa_monedas`, `sa_valormonedas`) VALUES
(1, '1.00'),
(2, '0.50'),
(3, '0.25'),
(4, '0.10'),
(5, '0.50'),
(6, '0.01'),
(8, '0.00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_puesto`
--

DROP TABLE IF EXISTS `sa_puesto`;
CREATE TABLE `sa_puesto` (
  `idsa_puesto` int(11) NOT NULL,
  `sa_puestonombre` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_puesto`
--

INSERT INTO `sa_puesto` (`idsa_puesto`, `sa_puestonombre`) VALUES
(1, 'Auditor campo'),
(2, 'Auditor general');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_tipocheque`
--

DROP TABLE IF EXISTS `sa_tipocheque`;
CREATE TABLE `sa_tipocheque` (
  `idsa_tipocheque` int(11) NOT NULL,
  `sa_nombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_tipocheque`
--

INSERT INTO `sa_tipocheque` (`idsa_tipocheque`, `sa_nombre`) VALUES
(1, 'Propios'),
(2, 'Ajenos');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `sa_tipomoneda`
--

DROP TABLE IF EXISTS `sa_tipomoneda`;
CREATE TABLE `sa_tipomoneda` (
  `idsa_tipomoneda` int(11) NOT NULL,
  `sa_nombretipomoneda` varchar(50) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `sa_tipomoneda`
--

INSERT INTO `sa_tipomoneda` (`idsa_tipomoneda`, `sa_nombretipomoneda`) VALUES
(1, 'Quetzales'),
(2, 'Dolares');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `seg_log`
--

DROP TABLE IF EXISTS `seg_log`;
CREATE TABLE `seg_log` (
  `codseglog` int(11) NOT NULL,
  `codgenusuario` int(11) DEFAULT NULL,
  `codsegtipoproceso` int(11) DEFAULT NULL,
  `seg_logusuario` varchar(45) DEFAULT NULL,
  `seg_loghora` time DEFAULT NULL,
  `seg_logfecha` date DEFAULT NULL,
  `seg_logip` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `seg_tipoproceso`
--

DROP TABLE IF EXISTS `seg_tipoproceso`;
CREATE TABLE `seg_tipoproceso` (
  `codsegtipoproceso` int(11) NOT NULL,
  `seg_tipoprocesonombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `sumamonto`
-- (Véase abajo para la vista actual)
--
DROP VIEW IF EXISTS `sumamonto`;
CREATE TABLE `sumamonto` (
`SUM(avt.av_monto)` decimal(32,0)
);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ticket_detalle`
--

DROP TABLE IF EXISTS `ticket_detalle`;
CREATE TABLE `ticket_detalle` (
  `codticketdetalle` int(11) NOT NULL,
  `codticketencabezado` int(11) DEFAULT NULL,
  `codticketestado` int(11) DEFAULT NULL,
  `codticketprioridad` int(11) DEFAULT NULL,
  `ticket_detalleresponsable` varchar(45) DEFAULT NULL,
  `ticket_detallehoradeactualizacion` time DEFAULT NULL,
  `ticket_detallefechadeactualizacion` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ticket_encabezado`
--

DROP TABLE IF EXISTS `ticket_encabezado`;
CREATE TABLE `ticket_encabezado` (
  `codticketencabezado` int(11) NOT NULL,
  `codgenarea` int(11) DEFAULT NULL,
  `ticket_encabezadousuario` varchar(45) DEFAULT NULL,
  `ticket_encabezadodescripcion` varchar(45) DEFAULT NULL,
  `ticket_encabezadoimagen` blob DEFAULT NULL,
  `ticket_encabezadofecha` date DEFAULT NULL,
  `ticket_encabezadohora` time DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ticket_estado`
--

DROP TABLE IF EXISTS `ticket_estado`;
CREATE TABLE `ticket_estado` (
  `codticketestado` int(11) NOT NULL,
  `ticket_estadonombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ticket_prioridad`
--

DROP TABLE IF EXISTS `ticket_prioridad`;
CREATE TABLE `ticket_prioridad` (
  `codticketprioridad` int(11) NOT NULL,
  `ticket_prioridadnombre` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ticket_tipo`
--

DROP TABLE IF EXISTS `ticket_tipo`;
CREATE TABLE `ticket_tipo` (
  `codtickettipo` int(11) NOT NULL,
  `codgenarea` int(11) DEFAULT NULL,
  `ticket_tiponombew` varchar(45) DEFAULT NULL,
  `ticket_tipodescripcion` varchar(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `usuariostareas`
-- (Véase abajo para la vista actual)
--
DROP VIEW IF EXISTS `usuariostareas`;
CREATE TABLE `usuariostareas` (
`av_controlusuario` varchar(20)
,`codavtarea` int(11)
,`codavagenda` int(11)
,`av_titulo` varchar(60)
,`fechaini` varchar(90)
,`fechafin` varchar(90)
,`av_estado` varchar(30)
);

-- --------------------------------------------------------

--
-- Estructura para la vista `graficamontos`
--
DROP TABLE IF EXISTS `graficamontos`;

DROP VIEW IF EXISTS `graficamontos`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `graficamontos`  AS SELECT cast((select count(`avcr`.`av_numcredito`) from (`av_tarea` `avt` join `av_credito` `avcr` on(`avt`.`codavtarea` = `avcr`.`codavtarea`)) where `avt`.`av_fechaini` between '2021-02-01' and '2021-02-27') / (select count(`avt`.`codavtarea`) AS `tareas` from `av_tarea` `avt` where `avt`.`av_fechaini` between '2021-02-01' and '2021-02-27' and `avt`.`cod_estado` = 3 and `avt`.`codtipotarea` = 1) as decimal(4,3)) * 100 AS `resultado` ;

-- --------------------------------------------------------

--
-- Estructura para la vista `montodatos`
--
DROP TABLE IF EXISTS `montodatos`;

DROP VIEW IF EXISTS `montodatos`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `montodatos`  AS SELECT `avt`.`codavtarea` AS `codavtarea`, `avt`.`av_titulo` AS `av_titulo`, `ave`.`av_estado` AS `av_estado`, `avt`.`av_monto` AS `av_monto`, `avt`.`fechaini` AS `fechaini`, `avt`.`fechafin` AS `fechafin` FROM (`av_tarea` `avt` join `av_estado` `ave` on(`avt`.`cod_estado` = `ave`.`codestado`)) WHERE `avt`.`av_fechaini` between '2021-02-01' and '2021-02-27' AND `avt`.`cod_estado` = 3 AND `avt`.`codtipotarea` = 1 ;

-- --------------------------------------------------------

--
-- Estructura para la vista `montosview`
--
DROP TABLE IF EXISTS `montosview`;

DROP VIEW IF EXISTS `montosview`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `montosview`  AS SELECT cast((select count(`avcr`.`av_numcredito`) from (`av_tarea` `avt` join `av_credito` `avcr` on(`avt`.`codavtarea` = `avcr`.`codavtarea`))) / (select count(`avt`.`codavtarea`) AS `tareas` from `av_tarea` `avt` where `avt`.`cod_estado` = 3 and `avt`.`codtipotarea` = 1) as decimal(4,3)) * 100 AS `resultado` ;

-- --------------------------------------------------------

--
-- Estructura para la vista `sumamonto`
--
DROP TABLE IF EXISTS `sumamonto`;

DROP VIEW IF EXISTS `sumamonto`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `sumamonto`  AS SELECT sum(`avt`.`av_monto`) AS `SUM(avt.av_monto)` FROM (`av_tarea` `avt` join `av_estado` `ave` on(`avt`.`cod_estado` = `ave`.`codestado`)) WHERE `avt`.`av_fechaini` between '2021-02-01' and '2021-02-27' AND `avt`.`cod_estado` = 3 AND `avt`.`codtipotarea` = 1 ;

-- --------------------------------------------------------

--
-- Estructura para la vista `usuariostareas`
--
DROP TABLE IF EXISTS `usuariostareas`;

DROP VIEW IF EXISTS `usuariostareas`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `usuariostareas`  AS SELECT DISTINCT `avci`.`av_controlusuario` AS `av_controlusuario`, `avt`.`codavtarea` AS `codavtarea`, `avt`.`codavagenda` AS `codavagenda`, `avt`.`av_titulo` AS `av_titulo`, `avt`.`fechaini` AS `fechaini`, `avt`.`fechafin` AS `fechafin`, `ave`.`av_estado` AS `av_estado` FROM ((((`av_estado` `ave` join `av_tarea` `avt` on(`ave`.`codestado` = `avt`.`cod_estado`)) join `av_agenda` `avg` on(`avt`.`codavagenda` = `avg`.`codavagenda`)) join `av_controlingreso` `avci` on(`avci`.`codavcontroling` = `avg`.`codavcontroling`)) join `av_controlasignado` `avc` on(`avc`.`codavcontroling` = `avci`.`codavcontroling`)) WHERE `avg`.`codavcontroling` = 1 AND `avci`.`av_controlarea` = 1 ;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `av_agenda`
--
ALTER TABLE `av_agenda`
  ADD PRIMARY KEY (`codavagenda`),
  ADD KEY `av_agenda_ibfk_1` (`codavcontroling`);

--
-- Indices de la tabla `av_controlasignado`
--
ALTER TABLE `av_controlasignado`
  ADD KEY `codavtarea` (`codavtarea`),
  ADD KEY `codavcontroling` (`codavcontroling`);

--
-- Indices de la tabla `av_controlingreso`
--
ALTER TABLE `av_controlingreso`
  ADD PRIMARY KEY (`codavcontroling`),
  ADD KEY `av_controlingreso_ibfk_1` (`av_controlrol`),
  ADD KEY `av_controlarea` (`av_controlarea`);

--
-- Indices de la tabla `av_controlsitio`
--
ALTER TABLE `av_controlsitio`
  ADD PRIMARY KEY (`codavcontolsitio`),
  ADD KEY `av_tipositio` (`av_tipositio`);

--
-- Indices de la tabla `av_credito`
--
ALTER TABLE `av_credito`
  ADD PRIMARY KEY (`codavcredit`),
  ADD KEY `codavtarea` (`codavtarea`);

--
-- Indices de la tabla `av_estado`
--
ALTER TABLE `av_estado`
  ADD PRIMARY KEY (`codestado`);

--
-- Indices de la tabla `av_permisostarea`
--
ALTER TABLE `av_permisostarea`
  ADD PRIMARY KEY (`codavpertarea`);

--
-- Indices de la tabla `av_prioridad`
--
ALTER TABLE `av_prioridad`
  ADD PRIMARY KEY (`codprioridad`);

--
-- Indices de la tabla `av_roles`
--
ALTER TABLE `av_roles`
  ADD PRIMARY KEY (`av_codrol`);

--
-- Indices de la tabla `av_subtarea`
--
ALTER TABLE `av_subtarea`
  ADD PRIMARY KEY (`codsubtarea`),
  ADD KEY `av_subtarea_ibfk_2` (`codestado`),
  ADD KEY `av_subtarea_ibfk_1` (`codtarea`);

--
-- Indices de la tabla `av_tarea`
--
ALTER TABLE `av_tarea`
  ADD PRIMARY KEY (`codavtarea`),
  ADD KEY `av_tarea_ibfk_1` (`codtipotarea`),
  ADD KEY `av_tarea_ibfk_2` (`codprioridad`),
  ADD KEY `av_tarea_ibfk_3` (`cod_estado`),
  ADD KEY `av_tarea_ibfk_4` (`codavagenda`),
  ADD KEY `codavpertarea` (`codavpertarea`);

--
-- Indices de la tabla `av_tipositio`
--
ALTER TABLE `av_tipositio`
  ADD PRIMARY KEY (`codavtipositio`);

--
-- Indices de la tabla `av_tipotarea`
--
ALTER TABLE `av_tipotarea`
  ADD PRIMARY KEY (`codtipotarea`);

--
-- Indices de la tabla `crmalertas_programadas`
--
ALTER TABLE `crmalertas_programadas`
  ADD PRIMARY KEY (`codcrmalertasprogramadas`),
  ADD KEY `fk_crmalertas_programadas_crmcontrol_ingreso_idx` (`codcrmcontrolingreso`);

--
-- Indices de la tabla `crmcontacto_llamadas`
--
ALTER TABLE `crmcontacto_llamadas`
  ADD PRIMARY KEY (`codcrmcontactollamadas`);

--
-- Indices de la tabla `crmcontrol_ingreso`
--
ALTER TABLE `crmcontrol_ingreso`
  ADD PRIMARY KEY (`codcrmcontrolingreso`);

--
-- Indices de la tabla `crmcontrol_prospecto_agente`
--
ALTER TABLE `crmcontrol_prospecto_agente`
  ADD PRIMARY KEY (`codcrmcontrolprospectoagente`),
  ADD KEY `fk_crmcontrol_prospecto_agente_crminfo_prospecto_idx` (`codcrminfoprospecto`),
  ADD KEY `fk_crmcontrol_prospecto_agente_crminfo_controlingreso_idx` (`codcrmcontrolingreso`);

--
-- Indices de la tabla `crmestado_descripcion`
--
ALTER TABLE `crmestado_descripcion`
  ADD PRIMARY KEY (`codcrmestadodescripcion`),
  ADD KEY `fk_crmestado_descripcion_crmsemaforo_estado1_idx` (`codcrmsemaforoestado`);

--
-- Indices de la tabla `crminfogeneral_prospecto`
--
ALTER TABLE `crminfogeneral_prospecto`
  ADD PRIMARY KEY (`codcrminfogeneralprospecto`);

--
-- Indices de la tabla `crminfo_prospecto`
--
ALTER TABLE `crminfo_prospecto`
  ADD PRIMARY KEY (`codcrminfoprospecto`),
  ADD KEY `fk_crminfo_prospecto_crminfogeneral_prospecto_idx` (`codcrminfogeneralprospecto`),
  ADD KEY `fk_crminfo_prospecto_crmcontacto_llamadas1_idx` (`codcrmcontactollamadas`),
  ADD KEY `fk_crminfo_prospecto_crmsemaforo_estado1_idx` (`codcrmsemaforoestado`),
  ADD KEY `fk_crminfo_prospecto_crmestado_descripcion1_idx` (`codcrmestadodescripcion`),
  ADD KEY `fk_crminfo_prospecto_crmtipo_domicilio1_idx` (`codcrmtipodomicilio`),
  ADD KEY `fk_crminfo_prospecto_crmtipo_servicio1_idx` (`codcrmtiposervicio`),
  ADD KEY `fk_crminfo_prospecto_crmfinalidadservicio1_idx` (`codcrmfinalidadservicio`);

--
-- Indices de la tabla `crmsemaforo_estado`
--
ALTER TABLE `crmsemaforo_estado`
  ADD PRIMARY KEY (`codcrmsemaforoestado`);

--
-- Indices de la tabla `crmtamporal_cargadedatos`
--
ALTER TABLE `crmtamporal_cargadedatos`
  ADD PRIMARY KEY (`codcrmtamporalcargadedatos`);

--
-- Indices de la tabla `crmtipo_domicilio`
--
ALTER TABLE `crmtipo_domicilio`
  ADD PRIMARY KEY (`codcrmtipodomicilio`);

--
-- Indices de la tabla `crmtipo_servicio`
--
ALTER TABLE `crmtipo_servicio`
  ADD PRIMARY KEY (`codcrmtiposervicio`);

--
-- Indices de la tabla `crm_finalidadservicio`
--
ALTER TABLE `crm_finalidadservicio`
  ADD PRIMARY KEY (`codcrmfinalidadservicio`);

--
-- Indices de la tabla `crm_frasesdeldia`
--
ALTER TABLE `crm_frasesdeldia`
  ADD PRIMARY KEY (`idcrm_frasesdeldia`);

--
-- Indices de la tabla `crm_genagencias`
--
ALTER TABLE `crm_genagencias`
  ADD PRIMARY KEY (`codcrmgenagencias`);

--
-- Indices de la tabla `ep_administracionlote`
--
ALTER TABLE `ep_administracionlote`
  ADD PRIMARY KEY (`codepadministracionlote`);

--
-- Indices de la tabla `ep_bactivos`
--
ALTER TABLE `ep_bactivos`
  ADD PRIMARY KEY (`codepbactivos`),
  ADD KEY `fk_ep_bactivos_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_contratistaproveedor`
--
ALTER TABLE `ep_contratistaproveedor`
  ADD PRIMARY KEY (`codepcontratistaproveedor`),
  ADD KEY `fk_ep_contratistaproveedor_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_control`
--
ALTER TABLE `ep_control`
  ADD PRIMARY KEY (`codepcontrol`),
  ADD KEY `fk_ep_control_ep_administracionlote1_idx` (`codepadministracionlote`),
  ADD KEY `fk_ep_control_gen_usuario1_idx` (`codgenusuario`);

--
-- Indices de la tabla `ep_controlingreso`
--
ALTER TABLE `ep_controlingreso`
  ADD PRIMARY KEY (`codepcontrolingreso`);

--
-- Indices de la tabla `ep_cuentas`
--
ALTER TABLE `ep_cuentas`
  ADD PRIMARY KEY (`codepcuentas`),
  ADD KEY `fk_ep_cuentas_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  ADD KEY `fk_ep_cuentas_ep_tipocuenta1_idx` (`codeptipocuenta`),
  ADD KEY `fk_ep_cuentas_ep_tipomoneda1_idx` (`codeptipomoneda`),
  ADD KEY `fk_ep_cuentas_ep_tipoestatuscuenta1_idx` (`codeptipoestatuscuenta`),
  ADD KEY `fk_ep_cuentas_ep_institucion1_idx` (`codepinstitucion`),
  ADD KEY `fk_ep_cuentas_ep_tipocuentacooperativa1_idx` (`codeptipocuentacooperativa`);

--
-- Indices de la tabla `ep_cuentasporpagar`
--
ALTER TABLE `ep_cuentasporpagar`
  ADD PRIMARY KEY (`codepcuentasporpagar`),
  ADD KEY `fk_ep_cuentasporpagar_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  ADD KEY `fk_ep_cuentasporpagar_ep_tipocuentasporpagar1_idx` (`codeptipocuentasporpagar`);

--
-- Indices de la tabla `ep_deudasvarias`
--
ALTER TABLE `ep_deudasvarias`
  ADD PRIMARY KEY (`codepdeudasvarias`),
  ADD KEY `fk_ep_deudasvarias_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_egresos`
--
ALTER TABLE `ep_egresos`
  ADD PRIMARY KEY (`codepegresos`),
  ADD KEY `fk_ep_egresos_ep_informaciongeneral1_idx` (`codinformaciongeneralcif`);

--
-- Indices de la tabla `ep_estadocivil`
--
ALTER TABLE `ep_estadocivil`
  ADD PRIMARY KEY (`codepestadocivil`);

--
-- Indices de la tabla `ep_estudio`
--
ALTER TABLE `ep_estudio`
  ADD PRIMARY KEY (`codepestudio`),
  ADD KEY `fk_ep_estudio_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_infofamiliar`
--
ALTER TABLE `ep_infofamiliar`
  ADD PRIMARY KEY (`codepinfofamiliar`),
  ADD KEY `fk_ep_infofamiliar_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_informaciongeneral`
--
ALTER TABLE `ep_informaciongeneral`
  ADD PRIMARY KEY (`codepinformaciongeneralcif`),
  ADD KEY `fk_ep_informaciongeneral_gen_tipoidentificacion1_idx` (`codgentipoidentificacion`),
  ADD KEY `fk_ep_informaciongeneral_ep_tipoestado1_idx` (`codeptipoestado`),
  ADD KEY `fk_ep_informaciongeneral_gen_sucursal1_idx` (`codgensucursal`),
  ADD KEY `fk_ep_informaciongeneral_gen_departamento1_idx` (`codgendepartamento`),
  ADD KEY `fk_ep_informaciongeneral_ep_estadocivil1_idx` (`codepestadocivil`),
  ADD KEY `fk_ep_informaciongeneral_ep_municipio1_idx` (`codgenmunicipio`),
  ADD KEY `fk_ep_informaciongeneral_ep_area1_idx` (`codgenarea`),
  ADD KEY `fk_ep_informaciongeneral_ep_zona1_idx` (`codgenzona`),
  ADD KEY `fk_ep_informaciongeneral_ep_tipoid_idx` (`codgentipoidentificacion`);

--
-- Indices de la tabla `ep_ingreso`
--
ALTER TABLE `ep_ingreso`
  ADD PRIMARY KEY (`codepingreso`),
  ADD KEY `fk_ep_ingreso_ep_controlingreso1_idx` (`codepcontrolingreso`);

--
-- Indices de la tabla `ep_inmueble`
--
ALTER TABLE `ep_inmueble`
  ADD PRIMARY KEY (`codepinmueble`),
  ADD KEY `fk_ep_inmueble_ep_tipoinmueble1_idx` (`codeptipoinmueble`),
  ADD KEY `fk_ep_inmueble_ep_informaciongeneralcif_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_institucion`
--
ALTER TABLE `ep_institucion`
  ADD PRIMARY KEY (`codepinstitucion`),
  ADD KEY `fk_ep_institucion_ep_tipoinstitucion_idx` (`codeptipoinstitucion`);

--
-- Indices de la tabla `ep_inventario`
--
ALTER TABLE `ep_inventario`
  ADD PRIMARY KEY (`codepinventario`),
  ADD KEY `fk_ep_inventario_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_inversiones`
--
ALTER TABLE `ep_inversiones`
  ADD PRIMARY KEY (`codepinversiones`),
  ADD KEY `fk_ep_inversiones_ep_tipomoneda1_idx` (`codeptipomoneda`),
  ADD KEY `fk_ep_inversiones_ep_tipoinstitucion1_idx` (`codeptipoinstitucion`),
  ADD KEY `fk_ep_inversiones_ep_institucion1_idx` (`codepinstitucion`),
  ADD KEY `fk_ep_inversiones_ep_informaciongeneral1` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_maquinaria`
--
ALTER TABLE `ep_maquinaria`
  ADD PRIMARY KEY (`codepmaquinaria`),
  ADD KEY `fk_ep_prestamo_ep_informaciongeneralcif_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_menajecasadetalle`
--
ALTER TABLE `ep_menajecasadetalle`
  ADD PRIMARY KEY (`codepmenajecasadetalle`),
  ADD KEY `fk_ep_menajecasadetalle_ep_menajedecasaencabezado1_idx` (`codmenajedecasaencabezado`),
  ADD KEY `fk_ep_menajecasadetalle_ep_tipobien1_idx` (`codeptipobien`);

--
-- Indices de la tabla `ep_menajedecasaencabezado`
--
ALTER TABLE `ep_menajedecasaencabezado`
  ADD PRIMARY KEY (`codepmenajedecasaencabezado`),
  ADD KEY `fk_ep_menajedecasaencabezado_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_negocio`
--
ALTER TABLE `ep_negocio`
  ADD PRIMARY KEY (`codepnegocio`),
  ADD KEY `fk_ep_negocio_ep_controlingreso1_idx` (`codepcontrolingreso`);

--
-- Indices de la tabla `ep_pasivocontigente`
--
ALTER TABLE `ep_pasivocontigente`
  ADD PRIMARY KEY (`codeppasivocontigente`),
  ADD KEY `fk_ep_pasivocontigente_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_personapep`
--
ALTER TABLE `ep_personapep`
  ADD PRIMARY KEY (`codeppersonapep`),
  ADD KEY `fk_ep_personapep_ep_tipopep1_idx` (`codeptipopep`),
  ADD KEY `fk_ep_personapep_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  ADD KEY `fk_ep_personapep_ep_tiponacionalidad1_idx` (`codeptiponacionalidad`),
  ADD KEY `fk_ep_personapep_ep_tipoparentesco_idx` (`codeptipoparentesco`);

--
-- Indices de la tabla `ep_prestamo`
--
ALTER TABLE `ep_prestamo`
  ADD PRIMARY KEY (`codepprestamo`),
  ADD KEY `fk_ep_prestamo_ep_tipoprestamo1_idx` (`codeptipoprestamo`),
  ADD KEY `fk_ep_prestamo_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  ADD KEY `fk_ep_prestamo_ep_institucion1_idx` (`codepinstitucion`),
  ADD KEY `fk_ep_prestamo_ep_tipoinstitucion1_idx` (`codeptipoinstitucion`);

--
-- Indices de la tabla `ep_remesas`
--
ALTER TABLE `ep_remesas`
  ADD PRIMARY KEY (`codepremesas`),
  ADD KEY `fk_ep_remesas_ep_controlingreso1_idx` (`codepcontrolingreso`);

--
-- Indices de la tabla `ep_tarjetadecredito`
--
ALTER TABLE `ep_tarjetadecredito`
  ADD PRIMARY KEY (`codeptrajetadecredito`),
  ADD KEY `fk_ep_tarjetadecredito_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`),
  ADD KEY `fk_ep_tarjetadecredito_ep_tipoinstitucion1_idx` (`codeptipoinstitucion`),
  ADD KEY `fk_ep_tarjetadecredito_ep_institucion1_idx` (`codepinstitucion`);

--
-- Indices de la tabla `ep_telefono`
--
ALTER TABLE `ep_telefono`
  ADD PRIMARY KEY (`codeptelefono`),
  ADD KEY `fk_ep_telefonol_ep_tipotelefono1_idx` (`codeptipotelefono`),
  ADD KEY `fk_ep_telefonol_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `ep_tipobien`
--
ALTER TABLE `ep_tipobien`
  ADD PRIMARY KEY (`codeptipobien`);

--
-- Indices de la tabla `ep_tipocuenta`
--
ALTER TABLE `ep_tipocuenta`
  ADD PRIMARY KEY (`codeptipocuenta`);

--
-- Indices de la tabla `ep_tipocuentacooperativa`
--
ALTER TABLE `ep_tipocuentacooperativa`
  ADD PRIMARY KEY (`codeptipocuentacooperativa`);

--
-- Indices de la tabla `ep_tipocuentaspopagar`
--
ALTER TABLE `ep_tipocuentaspopagar`
  ADD PRIMARY KEY (`codeptipocuentaspopagar`);

--
-- Indices de la tabla `ep_tipoestado`
--
ALTER TABLE `ep_tipoestado`
  ADD PRIMARY KEY (`codeptipoestado`);

--
-- Indices de la tabla `ep_tipoestatuscuenta`
--
ALTER TABLE `ep_tipoestatuscuenta`
  ADD PRIMARY KEY (`codeptipoestatuscuenta`);

--
-- Indices de la tabla `ep_tipoinmueble`
--
ALTER TABLE `ep_tipoinmueble`
  ADD PRIMARY KEY (`codeptipoinmueble`);

--
-- Indices de la tabla `ep_tipoinstitucion`
--
ALTER TABLE `ep_tipoinstitucion`
  ADD PRIMARY KEY (`codeptipoinstitucion`);

--
-- Indices de la tabla `ep_tipomoneda`
--
ALTER TABLE `ep_tipomoneda`
  ADD PRIMARY KEY (`codeptipomoneda`);

--
-- Indices de la tabla `ep_tiponacionalidad`
--
ALTER TABLE `ep_tiponacionalidad`
  ADD PRIMARY KEY (`codeptiponacionalidad`);

--
-- Indices de la tabla `ep_tipoparentesco`
--
ALTER TABLE `ep_tipoparentesco`
  ADD PRIMARY KEY (`codeptipoparentesco`);

--
-- Indices de la tabla `ep_tipopep`
--
ALTER TABLE `ep_tipopep`
  ADD PRIMARY KEY (`codeptipopep`);

--
-- Indices de la tabla `ep_tipoprestamo`
--
ALTER TABLE `ep_tipoprestamo`
  ADD PRIMARY KEY (`codeptipoprestamo`);

--
-- Indices de la tabla `ep_tipotelefono`
--
ALTER TABLE `ep_tipotelefono`
  ADD PRIMARY KEY (`codeptipotelefono`);

--
-- Indices de la tabla `ep_tipovehiculo`
--
ALTER TABLE `ep_tipovehiculo`
  ADD PRIMARY KEY (`codeptipovehiculo`);

--
-- Indices de la tabla `ep_vehiculo`
--
ALTER TABLE `ep_vehiculo`
  ADD PRIMARY KEY (`codepvehiculo`),
  ADD KEY `fk_ep_vehiculo_ep_tipovehiculo1_idx` (`codeptipovehiculo`),
  ADD KEY `fk_ep_vehiculo_ep_informaciongeneral1_idx` (`codepinformaciongeneralcif`);

--
-- Indices de la tabla `gen_aplicacion`
--
ALTER TABLE `gen_aplicacion`
  ADD PRIMARY KEY (`codgenapp`);

--
-- Indices de la tabla `gen_area`
--
ALTER TABLE `gen_area`
  ADD PRIMARY KEY (`codgenarea`),
  ADD KEY `fk_gen_area_gen_sucursal1_idx` (`codgensucursal`);

--
-- Indices de la tabla `gen_bitacora_ingresos_egresos`
--
ALTER TABLE `gen_bitacora_ingresos_egresos`
  ADD PRIMARY KEY (`codgen_bitacora_ingresos_egresos`);

--
-- Indices de la tabla `gen_bitacora_procedimientos`
--
ALTER TABLE `gen_bitacora_procedimientos`
  ADD PRIMARY KEY (`codgen_bitacora_procedimientos`);

--
-- Indices de la tabla `gen_departamento`
--
ALTER TABLE `gen_departamento`
  ADD PRIMARY KEY (`codgendepartamento`);

--
-- Indices de la tabla `gen_invequipo`
--
ALTER TABLE `gen_invequipo`
  ADD PRIMARY KEY (`codgeninvequipo`),
  ADD KEY `fk_gen_invequipo_gen_sucursal1_idx` (`codgensucursal`);

--
-- Indices de la tabla `gen_mdimenu`
--
ALTER TABLE `gen_mdimenu`
  ADD PRIMARY KEY (`codgenmdi`),
  ADD KEY `codgenapp` (`codgenapp`),
  ADD KEY `codgenusuario` (`codgenusuario`);

--
-- Indices de la tabla `gen_municipio`
--
ALTER TABLE `gen_municipio`
  ADD PRIMARY KEY (`codgenmunicipio`),
  ADD KEY `fk_gen_municipio_gen_departamento1_idx` (`codgendepartamento`);

--
-- Indices de la tabla `gen_puestos`
--
ALTER TABLE `gen_puestos`
  ADD PRIMARY KEY (`codgenpuestos`),
  ADD KEY `fk_gen_puestos_gen_area1_idx` (`codgenarea`);

--
-- Indices de la tabla `gen_sucursal`
--
ALTER TABLE `gen_sucursal`
  ADD PRIMARY KEY (`codgensucursal`);

--
-- Indices de la tabla `gen_tipoidentificacion`
--
ALTER TABLE `gen_tipoidentificacion`
  ADD PRIMARY KEY (`codgentipoidentificacion`);

--
-- Indices de la tabla `gen_usuario`
--
ALTER TABLE `gen_usuario`
  ADD PRIMARY KEY (`codgenusuario`),
  ADD KEY `fk_gen_usuario_gen_invequipo_idx` (`codgeninvequipo`);

--
-- Indices de la tabla `gen_zona`
--
ALTER TABLE `gen_zona`
  ADD PRIMARY KEY (`codgenzona`),
  ADD KEY `fk_gen_zona_gen_departamento1_idx` (`codgendepartamento`);

--
-- Indices de la tabla `sa_agencia`
--
ALTER TABLE `sa_agencia`
  ADD PRIMARY KEY (`idsa_agencia`);

--
-- Indices de la tabla `sa_billetes`
--
ALTER TABLE `sa_billetes`
  ADD PRIMARY KEY (`idsa_billetes`);

--
-- Indices de la tabla `sa_chequescajero`
--
ALTER TABLE `sa_chequescajero`
  ADD PRIMARY KEY (`idsa_chequescajero`),
  ADD KEY `sa_tipocheque_idx` (`idsa_tipocheque`),
  ADD KEY `sa_tipomoneda_idx` (`idsa_tipomoneda`),
  ADD KEY `sa_encabezadocajero_idx` (`idsa_encabezadocajero`);

--
-- Indices de la tabla `sa_chequestesoreria`
--
ALTER TABLE `sa_chequestesoreria`
  ADD PRIMARY KEY (`idsa_chequestesoreria`),
  ADD KEY `sa_tipocheque2_idx` (`idsa_tipocheque`),
  ADD KEY `sa_tipomoneda2_idx` (`idsa_tipomoneda`),
  ADD KEY `idsa_encabezadotesoreria_idx` (`idsa_encabezadotesoreria`);

--
-- Indices de la tabla `sa_cuadrecajachica`
--
ALTER TABLE `sa_cuadrecajachica`
  ADD PRIMARY KEY (`idsa_cuadrecajachica`),
  ADD KEY `idsa_billetes7_idx` (`idsa_billetes`),
  ADD KEY `idsa_monedas7_idx` (`idsa_monedas`),
  ADD KEY `idsa_encabezadocajachica3_idx` (`idsa_encabezadocajachica`);

--
-- Indices de la tabla `sa_detallecajachica`
--
ALTER TABLE `sa_detallecajachica`
  ADD PRIMARY KEY (`idsa_detallecajachica`),
  ADD KEY `idsa_encabezadocajachica2_idx` (`idsa_encabezadocajachica`);

--
-- Indices de la tabla `sa_detallecajero`
--
ALTER TABLE `sa_detallecajero`
  ADD PRIMARY KEY (`idsa_detallecajero`),
  ADD KEY `idsa_billetes2_idx` (`idsa_billetes`),
  ADD KEY `idsa_monedas2_idx` (`idsa_monedas`),
  ADD KEY `idsa_encabezadocajero2_idx` (`idsa_encabezadocajero`);

--
-- Indices de la tabla `sa_detallecajeroaut`
--
ALTER TABLE `sa_detallecajeroaut`
  ADD PRIMARY KEY (`idsa_detallecajeroaut`),
  ADD KEY `idsa_billetes3_idx` (`idsa_billetes`),
  ADD KEY `idsa_monedas3_idx` (`idsa_monedas`),
  ADD KEY `idsa_encabezadocajeroaut2_idx` (`idsa_encabezadocajeroaut`);

--
-- Indices de la tabla `sa_detalletesoreria`
--
ALTER TABLE `sa_detalletesoreria`
  ADD PRIMARY KEY (`idsa_detalletesoreria`),
  ADD KEY `sa_tipomoneda4_idx` (`sa_tipomoneda`),
  ADD KEY `idsa_encabezadotesoreria5_idx` (`idsa_encabezadotesoreria`);

--
-- Indices de la tabla `sa_encabezadocajachica`
--
ALTER TABLE `sa_encabezadocajachica`
  ADD PRIMARY KEY (`idsa_encabezadocajachica`),
  ADD KEY `sa_agencia_idx` (`sa_agencia`);

--
-- Indices de la tabla `sa_encabezadocajero`
--
ALTER TABLE `sa_encabezadocajero`
  ADD PRIMARY KEY (`idsa_encabezadocajero`),
  ADD KEY `sa_agencia2_idx` (`sa_agencia`);

--
-- Indices de la tabla `sa_encabezadocajeroaut`
--
ALTER TABLE `sa_encabezadocajeroaut`
  ADD PRIMARY KEY (`idsa_encabezadocajeroaut`),
  ADD KEY `sa_agencia3_idx` (`sa_agencia`);

--
-- Indices de la tabla `sa_encabezadotesoreria`
--
ALTER TABLE `sa_encabezadotesoreria`
  ADD PRIMARY KEY (`idsa_encabezadotesoreria`),
  ADD KEY `sa_agencia4_idx` (`sa_agencia`);

--
-- Indices de la tabla `sa_monedas`
--
ALTER TABLE `sa_monedas`
  ADD PRIMARY KEY (`idsa_monedas`);

--
-- Indices de la tabla `sa_puesto`
--
ALTER TABLE `sa_puesto`
  ADD PRIMARY KEY (`idsa_puesto`);

--
-- Indices de la tabla `sa_tipocheque`
--
ALTER TABLE `sa_tipocheque`
  ADD PRIMARY KEY (`idsa_tipocheque`);

--
-- Indices de la tabla `sa_tipomoneda`
--
ALTER TABLE `sa_tipomoneda`
  ADD PRIMARY KEY (`idsa_tipomoneda`);

--
-- Indices de la tabla `seg_log`
--
ALTER TABLE `seg_log`
  ADD PRIMARY KEY (`codseglog`),
  ADD KEY `fk_seg_log_seg_tipoproceso1_idx` (`codsegtipoproceso`),
  ADD KEY `fk_seg_log_gen_usuario1_idx` (`codgenusuario`);

--
-- Indices de la tabla `seg_tipoproceso`
--
ALTER TABLE `seg_tipoproceso`
  ADD PRIMARY KEY (`codsegtipoproceso`);

--
-- Indices de la tabla `ticket_detalle`
--
ALTER TABLE `ticket_detalle`
  ADD PRIMARY KEY (`codticketdetalle`),
  ADD KEY `fk_ticket_detalle_ticket_estado1_idx` (`codticketestado`),
  ADD KEY `fk_ticket_detalle_ticket_prioridad1_idx` (`codticketprioridad`);

--
-- Indices de la tabla `ticket_encabezado`
--
ALTER TABLE `ticket_encabezado`
  ADD PRIMARY KEY (`codticketencabezado`);

--
-- Indices de la tabla `ticket_estado`
--
ALTER TABLE `ticket_estado`
  ADD PRIMARY KEY (`codticketestado`);

--
-- Indices de la tabla `ticket_prioridad`
--
ALTER TABLE `ticket_prioridad`
  ADD PRIMARY KEY (`codticketprioridad`);

--
-- Indices de la tabla `ticket_tipo`
--
ALTER TABLE `ticket_tipo`
  ADD PRIMARY KEY (`codtickettipo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `av_agenda`
--
ALTER TABLE `av_agenda`
  MODIFY `codavagenda` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `av_controlingreso`
--
ALTER TABLE `av_controlingreso`
  MODIFY `codavcontroling` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `av_controlsitio`
--
ALTER TABLE `av_controlsitio`
  MODIFY `codavcontolsitio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `av_estado`
--
ALTER TABLE `av_estado`
  MODIFY `codestado` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `av_permisostarea`
--
ALTER TABLE `av_permisostarea`
  MODIFY `codavpertarea` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `av_prioridad`
--
ALTER TABLE `av_prioridad`
  MODIFY `codprioridad` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `av_roles`
--
ALTER TABLE `av_roles`
  MODIFY `av_codrol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `av_subtarea`
--
ALTER TABLE `av_subtarea`
  MODIFY `codsubtarea` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `av_tarea`
--
ALTER TABLE `av_tarea`
  MODIFY `codavtarea` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT de la tabla `av_tipositio`
--
ALTER TABLE `av_tipositio`
  MODIFY `codavtipositio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `av_tipotarea`
--
ALTER TABLE `av_tipotarea`
  MODIFY `codtipotarea` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `crmalertas_programadas`
--
ALTER TABLE `crmalertas_programadas`
  MODIFY `codcrmalertasprogramadas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `crmcontrol_prospecto_agente`
--
ALTER TABLE `crmcontrol_prospecto_agente`
  MODIFY `codcrmcontrolprospectoagente` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `crminfogeneral_prospecto`
--
ALTER TABLE `crminfogeneral_prospecto`
  MODIFY `codcrminfogeneralprospecto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `crmtamporal_cargadedatos`
--
ALTER TABLE `crmtamporal_cargadedatos`
  MODIFY `codcrmtamporalcargadedatos` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=57;

--
-- AUTO_INCREMENT de la tabla `crmtipo_servicio`
--
ALTER TABLE `crmtipo_servicio`
  MODIFY `codcrmtiposervicio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `crm_finalidadservicio`
--
ALTER TABLE `crm_finalidadservicio`
  MODIFY `codcrmfinalidadservicio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `crm_frasesdeldia`
--
ALTER TABLE `crm_frasesdeldia`
  MODIFY `idcrm_frasesdeldia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `ep_control`
--
ALTER TABLE `ep_control`
  MODIFY `codepcontrol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT de la tabla `ep_estudio`
--
ALTER TABLE `ep_estudio`
  MODIFY `codepestudio` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- AUTO_INCREMENT de la tabla `ep_informaciongeneral`
--
ALTER TABLE `ep_informaciongeneral`
  MODIFY `codepinformaciongeneralcif` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=35;

--
-- AUTO_INCREMENT de la tabla `ep_telefono`
--
ALTER TABLE `ep_telefono`
  MODIFY `codeptelefono` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT de la tabla `gen_bitacora_ingresos_egresos`
--
ALTER TABLE `gen_bitacora_ingresos_egresos`
  MODIFY `codgen_bitacora_ingresos_egresos` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT de la tabla `gen_bitacora_procedimientos`
--
ALTER TABLE `gen_bitacora_procedimientos`
  MODIFY `codgen_bitacora_procedimientos` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `gen_mdimenu`
--
ALTER TABLE `gen_mdimenu`
  MODIFY `codgenmdi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `sa_agencia`
--
ALTER TABLE `sa_agencia`
  MODIFY `idsa_agencia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT de la tabla `sa_billetes`
--
ALTER TABLE `sa_billetes`
  MODIFY `idsa_billetes` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `sa_chequescajero`
--
ALTER TABLE `sa_chequescajero`
  MODIFY `idsa_chequescajero` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT de la tabla `sa_chequestesoreria`
--
ALTER TABLE `sa_chequestesoreria`
  MODIFY `idsa_chequestesoreria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de la tabla `sa_detallecajachica`
--
ALTER TABLE `sa_detallecajachica`
  MODIFY `idsa_detallecajachica` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `sa_detallecajero`
--
ALTER TABLE `sa_detallecajero`
  MODIFY `idsa_detallecajero` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT de la tabla `sa_detallecajeroaut`
--
ALTER TABLE `sa_detallecajeroaut`
  MODIFY `idsa_detallecajeroaut` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=50;

--
-- AUTO_INCREMENT de la tabla `sa_detalletesoreria`
--
ALTER TABLE `sa_detalletesoreria`
  MODIFY `idsa_detalletesoreria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=64;

--
-- AUTO_INCREMENT de la tabla `sa_encabezadocajachica`
--
ALTER TABLE `sa_encabezadocajachica`
  MODIFY `idsa_encabezadocajachica` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT de la tabla `sa_encabezadocajero`
--
ALTER TABLE `sa_encabezadocajero`
  MODIFY `idsa_encabezadocajero` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `sa_encabezadocajeroaut`
--
ALTER TABLE `sa_encabezadocajeroaut`
  MODIFY `idsa_encabezadocajeroaut` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de la tabla `sa_encabezadotesoreria`
--
ALTER TABLE `sa_encabezadotesoreria`
  MODIFY `idsa_encabezadotesoreria` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `sa_monedas`
--
ALTER TABLE `sa_monedas`
  MODIFY `idsa_monedas` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `sa_puesto`
--
ALTER TABLE `sa_puesto`
  MODIFY `idsa_puesto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `sa_tipocheque`
--
ALTER TABLE `sa_tipocheque`
  MODIFY `idsa_tipocheque` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `sa_tipomoneda`
--
ALTER TABLE `sa_tipomoneda`
  MODIFY `idsa_tipomoneda` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `av_agenda`
--
ALTER TABLE `av_agenda`
  ADD CONSTRAINT `av_agenda_ibfk_1` FOREIGN KEY (`codavcontroling`) REFERENCES `av_controlingreso` (`codavcontroling`);

--
-- Filtros para la tabla `av_controlasignado`
--
ALTER TABLE `av_controlasignado`
  ADD CONSTRAINT `av_controlasignado_ibfk_2` FOREIGN KEY (`codavtarea`) REFERENCES `av_tarea` (`codavtarea`),
  ADD CONSTRAINT `av_controlasignado_ibfk_3` FOREIGN KEY (`codavcontroling`) REFERENCES `av_controlingreso` (`codavcontroling`);

--
-- Filtros para la tabla `av_controlingreso`
--
ALTER TABLE `av_controlingreso`
  ADD CONSTRAINT `av_controlingreso_ibfk_1` FOREIGN KEY (`av_controlrol`) REFERENCES `av_roles` (`av_codrol`),
  ADD CONSTRAINT `av_controlingreso_ibfk_2` FOREIGN KEY (`av_controlarea`) REFERENCES `av_controlsitio` (`codavcontolsitio`);

--
-- Filtros para la tabla `av_controlsitio`
--
ALTER TABLE `av_controlsitio`
  ADD CONSTRAINT `av_controlsitio_ibfk_1` FOREIGN KEY (`av_tipositio`) REFERENCES `av_tipositio` (`codavtipositio`);

--
-- Filtros para la tabla `av_credito`
--
ALTER TABLE `av_credito`
  ADD CONSTRAINT `av_credito_ibfk_1` FOREIGN KEY (`codavtarea`) REFERENCES `av_tarea` (`codavtarea`);

--
-- Filtros para la tabla `av_subtarea`
--
ALTER TABLE `av_subtarea`
  ADD CONSTRAINT `av_subtarea_ibfk_1` FOREIGN KEY (`codtarea`) REFERENCES `av_tarea` (`codavtarea`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `av_subtarea_ibfk_2` FOREIGN KEY (`codestado`) REFERENCES `av_estado` (`codestado`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `av_tarea`
--
ALTER TABLE `av_tarea`
  ADD CONSTRAINT `av_tarea_ibfk_1` FOREIGN KEY (`codtipotarea`) REFERENCES `av_tipotarea` (`codtipotarea`),
  ADD CONSTRAINT `av_tarea_ibfk_2` FOREIGN KEY (`codprioridad`) REFERENCES `av_prioridad` (`codprioridad`),
  ADD CONSTRAINT `av_tarea_ibfk_3` FOREIGN KEY (`cod_estado`) REFERENCES `av_estado` (`codestado`),
  ADD CONSTRAINT `av_tarea_ibfk_4` FOREIGN KEY (`codavagenda`) REFERENCES `av_agenda` (`codavagenda`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `av_tarea_ibfk_5` FOREIGN KEY (`codavpertarea`) REFERENCES `av_permisostarea` (`codavpertarea`);

--
-- Filtros para la tabla `crmalertas_programadas`
--
ALTER TABLE `crmalertas_programadas`
  ADD CONSTRAINT `fk_crmalertas_programadas_crmcontrol_ingresi1` FOREIGN KEY (`codcrmcontrolingreso`) REFERENCES `crmcontrol_ingreso` (`codcrmcontrolingreso`);

--
-- Filtros para la tabla `crmcontrol_prospecto_agente`
--
ALTER TABLE `crmcontrol_prospecto_agente`
  ADD CONSTRAINT `fk_crmcontrol_prospecto_agente_crm_controlingreso1` FOREIGN KEY (`codcrmcontrolingreso`) REFERENCES `crmcontrol_ingreso` (`codcrmcontrolingreso`),
  ADD CONSTRAINT `fk_crmcontrol_prospecto_agente_crm_infoprospecto1` FOREIGN KEY (`codcrminfoprospecto`) REFERENCES `crminfo_prospecto` (`codcrminfoprospecto`);

--
-- Filtros para la tabla `crmestado_descripcion`
--
ALTER TABLE `crmestado_descripcion`
  ADD CONSTRAINT `fk_crmestado_descripcion_crmsemaforo_estado1` FOREIGN KEY (`codcrmsemaforoestado`) REFERENCES `crmsemaforo_estado` (`codcrmsemaforoestado`);

--
-- Filtros para la tabla `crminfo_prospecto`
--
ALTER TABLE `crminfo_prospecto`
  ADD CONSTRAINT `fk_crminfo_prospecto_crm_finalidadservicio1` FOREIGN KEY (`codcrmfinalidadservicio`) REFERENCES `crm_finalidadservicio` (`codcrmfinalidadservicio`),
  ADD CONSTRAINT `fk_crminfo_prospecto_crmcontacto_llamadas1` FOREIGN KEY (`codcrmcontactollamadas`) REFERENCES `crmcontacto_llamadas` (`codcrmcontactollamadas`),
  ADD CONSTRAINT `fk_crminfo_prospecto_crmestado_descripcion1` FOREIGN KEY (`codcrmestadodescripcion`) REFERENCES `crmestado_descripcion` (`codcrmestadodescripcion`),
  ADD CONSTRAINT `fk_crminfo_prospecto_crminfogeneral_prospecto` FOREIGN KEY (`codcrminfogeneralprospecto`) REFERENCES `crminfogeneral_prospecto` (`codcrminfogeneralprospecto`),
  ADD CONSTRAINT `fk_crminfo_prospecto_crmsemaforo_estado1` FOREIGN KEY (`codcrmsemaforoestado`) REFERENCES `crmsemaforo_estado` (`codcrmsemaforoestado`),
  ADD CONSTRAINT `fk_crminfo_prospecto_crmtipo_domicilio1` FOREIGN KEY (`codcrmtipodomicilio`) REFERENCES `crmtipo_domicilio` (`codcrmtipodomicilio`),
  ADD CONSTRAINT `fk_crminfo_prospecto_crmtipo_servicio1` FOREIGN KEY (`codcrmtiposervicio`) REFERENCES `crmtipo_servicio` (`codcrmtiposervicio`);

--
-- Filtros para la tabla `ep_bactivos`
--
ALTER TABLE `ep_bactivos`
  ADD CONSTRAINT `fk_ep_bactivos_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_contratistaproveedor`
--
ALTER TABLE `ep_contratistaproveedor`
  ADD CONSTRAINT `fk_ep_contratistaproveedor_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_control`
--
ALTER TABLE `ep_control`
  ADD CONSTRAINT `fk_ep_control_ep_administracionlote1` FOREIGN KEY (`codepadministracionlote`) REFERENCES `ep_administracionlote` (`codepadministracionlote`),
  ADD CONSTRAINT `fk_ep_control_gen_usuario1` FOREIGN KEY (`codgenusuario`) REFERENCES `gen_usuario` (`codgenusuario`);

--
-- Filtros para la tabla `ep_cuentas`
--
ALTER TABLE `ep_cuentas`
  ADD CONSTRAINT `fk_ep_cuentas_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`),
  ADD CONSTRAINT `fk_ep_cuentas_ep_institucion1` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`),
  ADD CONSTRAINT `fk_ep_cuentas_ep_tipocuenta1` FOREIGN KEY (`codeptipocuenta`) REFERENCES `ep_tipocuenta` (`codeptipocuenta`),
  ADD CONSTRAINT `fk_ep_cuentas_ep_tipoestatuscuenta1` FOREIGN KEY (`codeptipoestatuscuenta`) REFERENCES `ep_tipoestatuscuenta` (`codeptipoestatuscuenta`),
  ADD CONSTRAINT `fk_ep_cuentas_ep_tipomoneda1` FOREIGN KEY (`codeptipomoneda`) REFERENCES `ep_tipomoneda` (`codeptipomoneda`),
  ADD CONSTRAINT `fk_ep_cuentas_institucion` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`),
  ADD CONSTRAINT `fk_ep_cuentas_tipocuentacooperativa1` FOREIGN KEY (`codeptipocuentacooperativa`) REFERENCES `ep_tipocuentacooperativa` (`codeptipocuentacooperativa`);

--
-- Filtros para la tabla `ep_cuentasporpagar`
--
ALTER TABLE `ep_cuentasporpagar`
  ADD CONSTRAINT `fk_ep_cuentasporpagar_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`),
  ADD CONSTRAINT `fk_ep_cuentasporpagar_ep_tipocuentasporpagar1` FOREIGN KEY (`codeptipocuentasporpagar`) REFERENCES `ep_tipocuentaspopagar` (`codeptipocuentaspopagar`);

--
-- Filtros para la tabla `ep_deudasvarias`
--
ALTER TABLE `ep_deudasvarias`
  ADD CONSTRAINT `fk_ep_deudasvarias_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_egresos`
--
ALTER TABLE `ep_egresos`
  ADD CONSTRAINT `fk_ep_egresos_ep_informaciongeneral1` FOREIGN KEY (`codinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_estudio`
--
ALTER TABLE `ep_estudio`
  ADD CONSTRAINT `fk_ep_estudio_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_infofamiliar`
--
ALTER TABLE `ep_infofamiliar`
  ADD CONSTRAINT `fk_ep_infofamiliar_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_informaciongeneral`
--
ALTER TABLE `ep_informaciongeneral`
  ADD CONSTRAINT `fk_ep_informaciongeneral_ep_estadocivil1` FOREIGN KEY (`codepestadocivil`) REFERENCES `ep_estadocivil` (`codepestadocivil`),
  ADD CONSTRAINT `fk_ep_informaciongeneral_ep_tipoestado1` FOREIGN KEY (`codeptipoestado`) REFERENCES `ep_tipoestado` (`codeptipoestado`),
  ADD CONSTRAINT `fk_ep_informaciongeneral_gen_area1` FOREIGN KEY (`codgenarea`) REFERENCES `gen_area` (`codgenarea`),
  ADD CONSTRAINT `fk_ep_informaciongeneral_gen_departamento1` FOREIGN KEY (`codgendepartamento`) REFERENCES `gen_departamento` (`codgendepartamento`),
  ADD CONSTRAINT `fk_ep_informaciongeneral_gen_municipio1` FOREIGN KEY (`codgenmunicipio`) REFERENCES `gen_municipio` (`codgenmunicipio`),
  ADD CONSTRAINT `fk_ep_informaciongeneral_gen_sucursal1` FOREIGN KEY (`codgensucursal`) REFERENCES `gen_sucursal` (`codgensucursal`),
  ADD CONSTRAINT `fk_ep_informaciongeneral_gen_tipoidentificacion1` FOREIGN KEY (`codgentipoidentificacion`) REFERENCES `gen_tipoidentificacion` (`codgentipoidentificacion`),
  ADD CONSTRAINT `fk_ep_informaciongeneral_gen_zona1` FOREIGN KEY (`codgenzona`) REFERENCES `gen_zona` (`codgenzona`);

--
-- Filtros para la tabla `ep_ingreso`
--
ALTER TABLE `ep_ingreso`
  ADD CONSTRAINT `fk_ep_ingreso_ep_controlingreso1` FOREIGN KEY (`codepcontrolingreso`) REFERENCES `ep_controlingreso` (`codepcontrolingreso`);

--
-- Filtros para la tabla `ep_inmueble`
--
ALTER TABLE `ep_inmueble`
  ADD CONSTRAINT `fk_ep_inmueble_ep_informaciongeneralcif1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`),
  ADD CONSTRAINT `fk_ep_inmueble_ep_tipoinmueble1` FOREIGN KEY (`codeptipoinmueble`) REFERENCES `ep_tipoinmueble` (`codeptipoinmueble`);

--
-- Filtros para la tabla `ep_institucion`
--
ALTER TABLE `ep_institucion`
  ADD CONSTRAINT `fk_ep_institucion_ep_tipoinstitucion1` FOREIGN KEY (`codeptipoinstitucion`) REFERENCES `ep_tipoinstitucion` (`codeptipoinstitucion`);

--
-- Filtros para la tabla `ep_inventario`
--
ALTER TABLE `ep_inventario`
  ADD CONSTRAINT `fk_ep_inventario_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_inversiones`
--
ALTER TABLE `ep_inversiones`
  ADD CONSTRAINT `fk_ep_inversiones_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`),
  ADD CONSTRAINT `fk_ep_inversiones_ep_institucion1` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`),
  ADD CONSTRAINT `fk_ep_inversiones_ep_tipoinstitucion1` FOREIGN KEY (`codeptipoinstitucion`) REFERENCES `ep_tipoinstitucion` (`codeptipoinstitucion`),
  ADD CONSTRAINT `fk_ep_inversiones_ep_tipomoneda1` FOREIGN KEY (`codeptipomoneda`) REFERENCES `ep_tipomoneda` (`codeptipomoneda`);

--
-- Filtros para la tabla `ep_maquinaria`
--
ALTER TABLE `ep_maquinaria`
  ADD CONSTRAINT `fk_ep_prestamo_ep_informaciongeneralcif1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_menajecasadetalle`
--
ALTER TABLE `ep_menajecasadetalle`
  ADD CONSTRAINT `fk_ep_menajecasadetalle_ep_menajedecasaencabezado1` FOREIGN KEY (`codmenajedecasaencabezado`) REFERENCES `ep_menajedecasaencabezado` (`codepmenajedecasaencabezado`),
  ADD CONSTRAINT `fk_ep_menajecasadetalle_ep_tipobien1` FOREIGN KEY (`codeptipobien`) REFERENCES `ep_tipobien` (`codeptipobien`);

--
-- Filtros para la tabla `ep_menajedecasaencabezado`
--
ALTER TABLE `ep_menajedecasaencabezado`
  ADD CONSTRAINT `fk_ep_menajedecasaencabezado_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_negocio`
--
ALTER TABLE `ep_negocio`
  ADD CONSTRAINT `fk_ep_negocio_ep_controlingreso1` FOREIGN KEY (`codepcontrolingreso`) REFERENCES `ep_controlingreso` (`codepcontrolingreso`);

--
-- Filtros para la tabla `ep_pasivocontigente`
--
ALTER TABLE `ep_pasivocontigente`
  ADD CONSTRAINT `fk_ep_pasivocontigente_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`);

--
-- Filtros para la tabla `ep_personapep`
--
ALTER TABLE `ep_personapep`
  ADD CONSTRAINT `fk_ep_personapep_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`),
  ADD CONSTRAINT `fk_ep_personapep_ep_tiponacionalidad1` FOREIGN KEY (`codeptiponacionalidad`) REFERENCES `ep_tiponacionalidad` (`codeptiponacionalidad`),
  ADD CONSTRAINT `fk_ep_personapep_ep_tipoparentesco1` FOREIGN KEY (`codeptipoparentesco`) REFERENCES `ep_tipoparentesco` (`codeptipoparentesco`),
  ADD CONSTRAINT `fk_ep_personapep_ep_tipopep1` FOREIGN KEY (`codeptipopep`) REFERENCES `ep_tipopep` (`codeptipopep`);

--
-- Filtros para la tabla `ep_prestamo`
--
ALTER TABLE `ep_prestamo`
  ADD CONSTRAINT `fk_ep_prestamo_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`),
  ADD CONSTRAINT `fk_ep_prestamo_ep_institucion1` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`),
  ADD CONSTRAINT `fk_ep_prestamo_ep_tipoinstitucion1` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_tipoinstitucion` (`codeptipoinstitucion`),
  ADD CONSTRAINT `fk_ep_prestamo_ep_tipoprestamo1` FOREIGN KEY (`codeptipoprestamo`) REFERENCES `ep_tipoprestamo` (`codeptipoprestamo`);

--
-- Filtros para la tabla `ep_remesas`
--
ALTER TABLE `ep_remesas`
  ADD CONSTRAINT `fk_ep_remesas_ep_controlingreso1` FOREIGN KEY (`codepcontrolingreso`) REFERENCES `ep_controlingreso` (`codepcontrolingreso`);

--
-- Filtros para la tabla `ep_tarjetadecredito`
--
ALTER TABLE `ep_tarjetadecredito`
  ADD CONSTRAINT `fk_ep_tarjetadecredito_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`),
  ADD CONSTRAINT `fk_ep_tarjetadecredito_ep_institucion1` FOREIGN KEY (`codepinstitucion`) REFERENCES `ep_institucion` (`codepinstitucion`),
  ADD CONSTRAINT `fk_ep_tarjetadecredito_ep_tipoinstitucion1` FOREIGN KEY (`codeptipoinstitucion`) REFERENCES `ep_tipoinstitucion` (`codeptipoinstitucion`);

--
-- Filtros para la tabla `ep_telefono`
--
ALTER TABLE `ep_telefono`
  ADD CONSTRAINT `fk_ep_telefono_ep_infromaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`),
  ADD CONSTRAINT `fk_ep_telefono_ep_tipotelefono1` FOREIGN KEY (`codeptipotelefono`) REFERENCES `ep_tipotelefono` (`codeptipotelefono`);

--
-- Filtros para la tabla `ep_vehiculo`
--
ALTER TABLE `ep_vehiculo`
  ADD CONSTRAINT `fk_ep_vehiculo_ep_informaciongeneral1` FOREIGN KEY (`codepinformaciongeneralcif`) REFERENCES `ep_informaciongeneral` (`codepinformaciongeneralcif`),
  ADD CONSTRAINT `fk_ep_vehiculo_ep_tipovehiculo1` FOREIGN KEY (`codeptipovehiculo`) REFERENCES `ep_tipovehiculo` (`codeptipovehiculo`);

--
-- Filtros para la tabla `gen_area`
--
ALTER TABLE `gen_area`
  ADD CONSTRAINT `fk_gen_area_gen_sucursal1` FOREIGN KEY (`codgensucursal`) REFERENCES `gen_sucursal` (`codgensucursal`);

--
-- Filtros para la tabla `gen_invequipo`
--
ALTER TABLE `gen_invequipo`
  ADD CONSTRAINT `fk_gen_invequipo_gen_sucursal1` FOREIGN KEY (`codgensucursal`) REFERENCES `gen_sucursal` (`codgensucursal`);

--
-- Filtros para la tabla `gen_mdimenu`
--
ALTER TABLE `gen_mdimenu`
  ADD CONSTRAINT `gen_mdimenu_ibfk_1` FOREIGN KEY (`codgenapp`) REFERENCES `gen_aplicacion` (`codgenapp`) ON UPDATE CASCADE,
  ADD CONSTRAINT `gen_mdimenu_ibfk_2` FOREIGN KEY (`codgenusuario`) REFERENCES `gen_usuario` (`codgenusuario`) ON UPDATE CASCADE;

--
-- Filtros para la tabla `gen_municipio`
--
ALTER TABLE `gen_municipio`
  ADD CONSTRAINT `fk_gen_municipio_gen_departamento1` FOREIGN KEY (`codgendepartamento`) REFERENCES `gen_departamento` (`codgendepartamento`);

--
-- Filtros para la tabla `gen_puestos`
--
ALTER TABLE `gen_puestos`
  ADD CONSTRAINT `fk_gen_puesto_gen_areal1` FOREIGN KEY (`codgenarea`) REFERENCES `gen_area` (`codgenarea`);

--
-- Filtros para la tabla `gen_usuario`
--
ALTER TABLE `gen_usuario`
  ADD CONSTRAINT `fk_gen_usuario_gen_invequipo` FOREIGN KEY (`codgeninvequipo`) REFERENCES `gen_invequipo` (`codgeninvequipo`);

--
-- Filtros para la tabla `gen_zona`
--
ALTER TABLE `gen_zona`
  ADD CONSTRAINT `fk_gen_zona_gen_departamento1` FOREIGN KEY (`codgendepartamento`) REFERENCES `gen_departamento` (`codgendepartamento`);

--
-- Filtros para la tabla `sa_chequescajero`
--
ALTER TABLE `sa_chequescajero`
  ADD CONSTRAINT `sa_encabezadocajero` FOREIGN KEY (`idsa_encabezadocajero`) REFERENCES `sa_encabezadocajero` (`idsa_encabezadocajero`),
  ADD CONSTRAINT `sa_tipocheque` FOREIGN KEY (`idsa_tipocheque`) REFERENCES `sa_tipocheque` (`idsa_tipocheque`),
  ADD CONSTRAINT `sa_tipomoneda` FOREIGN KEY (`idsa_tipomoneda`) REFERENCES `sa_tipomoneda` (`idsa_tipomoneda`);

--
-- Filtros para la tabla `sa_chequestesoreria`
--
ALTER TABLE `sa_chequestesoreria`
  ADD CONSTRAINT `idsa_encabezadotesoreria` FOREIGN KEY (`idsa_encabezadotesoreria`) REFERENCES `sa_encabezadotesoreria` (`idsa_encabezadotesoreria`),
  ADD CONSTRAINT `sa_tipocheque2` FOREIGN KEY (`idsa_tipocheque`) REFERENCES `sa_tipocheque` (`idsa_tipocheque`),
  ADD CONSTRAINT `sa_tipomoneda2` FOREIGN KEY (`idsa_tipomoneda`) REFERENCES `sa_tipomoneda` (`idsa_tipomoneda`);

--
-- Filtros para la tabla `sa_cuadrecajachica`
--
ALTER TABLE `sa_cuadrecajachica`
  ADD CONSTRAINT `idsa_billetes7` FOREIGN KEY (`idsa_billetes`) REFERENCES `sa_billetes` (`idsa_billetes`),
  ADD CONSTRAINT `idsa_encabezadocajachica3` FOREIGN KEY (`idsa_encabezadocajachica`) REFERENCES `sa_encabezadocajachica` (`idsa_encabezadocajachica`),
  ADD CONSTRAINT `idsa_monedas7` FOREIGN KEY (`idsa_monedas`) REFERENCES `sa_monedas` (`idsa_monedas`);

--
-- Filtros para la tabla `sa_detallecajachica`
--
ALTER TABLE `sa_detallecajachica`
  ADD CONSTRAINT `idsa_encabezadocajachica2` FOREIGN KEY (`idsa_encabezadocajachica`) REFERENCES `sa_encabezadocajachica` (`idsa_encabezadocajachica`);

--
-- Filtros para la tabla `sa_detallecajero`
--
ALTER TABLE `sa_detallecajero`
  ADD CONSTRAINT `idsa_billetes2` FOREIGN KEY (`idsa_billetes`) REFERENCES `sa_billetes` (`idsa_billetes`),
  ADD CONSTRAINT `idsa_encabezadocajero2` FOREIGN KEY (`idsa_encabezadocajero`) REFERENCES `sa_encabezadocajero` (`idsa_encabezadocajero`),
  ADD CONSTRAINT `idsa_monedas2` FOREIGN KEY (`idsa_monedas`) REFERENCES `sa_monedas` (`idsa_monedas`);

--
-- Filtros para la tabla `sa_detallecajeroaut`
--
ALTER TABLE `sa_detallecajeroaut`
  ADD CONSTRAINT `idsa_billetes3` FOREIGN KEY (`idsa_billetes`) REFERENCES `sa_billetes` (`idsa_billetes`),
  ADD CONSTRAINT `idsa_encabezadocajeroaut2` FOREIGN KEY (`idsa_encabezadocajeroaut`) REFERENCES `sa_encabezadocajeroaut` (`idsa_encabezadocajeroaut`),
  ADD CONSTRAINT `idsa_monedas3` FOREIGN KEY (`idsa_monedas`) REFERENCES `sa_monedas` (`idsa_monedas`);

--
-- Filtros para la tabla `sa_detalletesoreria`
--
ALTER TABLE `sa_detalletesoreria`
  ADD CONSTRAINT `idsa_encabezadotesoreria5` FOREIGN KEY (`idsa_encabezadotesoreria`) REFERENCES `sa_encabezadotesoreria` (`idsa_encabezadotesoreria`),
  ADD CONSTRAINT `sa_tipomoneda4` FOREIGN KEY (`sa_tipomoneda`) REFERENCES `sa_tipomoneda` (`idsa_tipomoneda`);

--
-- Filtros para la tabla `sa_encabezadocajachica`
--
ALTER TABLE `sa_encabezadocajachica`
  ADD CONSTRAINT `sa_agencia` FOREIGN KEY (`sa_agencia`) REFERENCES `sa_agencia` (`idsa_agencia`);

--
-- Filtros para la tabla `sa_encabezadocajero`
--
ALTER TABLE `sa_encabezadocajero`
  ADD CONSTRAINT `sa_agencia2` FOREIGN KEY (`sa_agencia`) REFERENCES `sa_agencia` (`idsa_agencia`);

--
-- Filtros para la tabla `sa_encabezadocajeroaut`
--
ALTER TABLE `sa_encabezadocajeroaut`
  ADD CONSTRAINT `sa_agencia3` FOREIGN KEY (`sa_agencia`) REFERENCES `sa_agencia` (`idsa_agencia`);

--
-- Filtros para la tabla `sa_encabezadotesoreria`
--
ALTER TABLE `sa_encabezadotesoreria`
  ADD CONSTRAINT `sa_agencia4` FOREIGN KEY (`sa_agencia`) REFERENCES `sa_agencia` (`idsa_agencia`);

--
-- Filtros para la tabla `seg_log`
--
ALTER TABLE `seg_log`
  ADD CONSTRAINT `fk_seg_log_gen_usuario1` FOREIGN KEY (`codgenusuario`) REFERENCES `gen_usuario` (`codgenusuario`),
  ADD CONSTRAINT `fk_seg_log_seg_tipoproceso1` FOREIGN KEY (`codsegtipoproceso`) REFERENCES `seg_tipoproceso` (`codsegtipoproceso`);

--
-- Filtros para la tabla `ticket_detalle`
--
ALTER TABLE `ticket_detalle`
  ADD CONSTRAINT `fk_ticket_detalle_ticket_estado1` FOREIGN KEY (`codticketestado`) REFERENCES `ticket_estado` (`codticketestado`),
  ADD CONSTRAINT `fk_ticket_detalle_ticket_prioridad1` FOREIGN KEY (`codticketprioridad`) REFERENCES `ticket_prioridad` (`codticketprioridad`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
