/*
SQLyog Ultimate v12.4.1 (64 bit)
MySQL - 10.4.14-MariaDB : Database - practica2
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`practica2` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;

USE `practica2`;

/*Table structure for table `addresses` */

DROP TABLE IF EXISTS `addresses`;

CREATE TABLE `addresses` (
  `id` varchar(10) DEFAULT NULL,
  `calle` varchar(15) DEFAULT NULL,
  `num_casa` varchar(6) DEFAULT NULL,
  `colonia` varchar(25) DEFAULT NULL,
  KEY `ID` (`id`),
  CONSTRAINT `addresses_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `distributors` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `addresses` */

insert  into `addresses`(`id`,`calle`,`num_casa`,`colonia`) values 
('COD1','Principal','12','Juárez'),
('COD2','Aquiles Serdan','15','Centro');

/*Table structure for table `distributors` */

DROP TABLE IF EXISTS `distributors`;

CREATE TABLE `distributors` (
  `id` varchar(10) NOT NULL,
  `fecha_registro` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `distributors` */

insert  into `distributors`(`id`,`fecha_registro`) values 
('COD1','2021-01-03'),
('COD2','2021-01-04');

/*Table structure for table `persons` */

DROP TABLE IF EXISTS `persons`;

CREATE TABLE `persons` (
  `id` varchar(10) DEFAULT NULL,
  `nombre` varchar(30) DEFAULT NULL,
  `ap_paterno` varchar(30) DEFAULT NULL,
  `ap_materno` varchar(30) DEFAULT NULL,
  KEY `ID` (`id`),
  CONSTRAINT `persons_ibfk_1` FOREIGN KEY (`ID`) REFERENCES `distributors` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

/*Data for the table `persons` */

insert  into `persons`(`id`,`nombre`,`ap_paterno`,`ap_materno`) values 
('COD1','Dafne','Montoya','Herrera'),
('COD2','Elias','Morales','Portillo');

/* Procedure structure for procedure `consulta_distribuidor` */

/*!50003 DROP PROCEDURE IF EXISTS  `consulta_distribuidor` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`root`@`localhost` PROCEDURE `consulta_distribuidor`(IN id_dist varchar(10))
BEGIN
SELECT concat(nombre, ' ', ap_paterno, ' ', ap_materno) as Nombre_completo, calle, num_casa, colonia 
FROM persons Inner join addresses
on persons.`id` = addresses.`id`
WHERE persons.`id` = id_dist;
end */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
