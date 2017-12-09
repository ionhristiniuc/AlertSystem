CREATE DATABASE  IF NOT EXISTS `alertsystem` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `alertsystem`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: alertsystem
-- ------------------------------------------------------
-- Server version	5.7.10-log

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
-- Table structure for table `alert`
--

DROP TABLE IF EXISTS `alert`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alert` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Subject` varchar(1000) DEFAULT NULL,
  `Short_text` text,
  `Text` text,
  `Notify_time` datetime DEFAULT NULL,
  `User_id` int(11) DEFAULT NULL,
  `Source_id` int(11) DEFAULT NULL,
  `Search_key` varchar(200) DEFAULT NULL,
  `Address` varchar(500) DEFAULT NULL,
  `Alert_category` varchar(100) DEFAULT NULL,
  `Raiting` int(11) DEFAULT NULL,
  `Link` varchar(500) DEFAULT NULL,
  `InsertedOn` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_alert_user_idx` (`User_id`),
  KEY `fk_alert_source1_idx` (`Source_id`),
  KEY `fk_alert_alert_category1_idx` (`Alert_category`),
  CONSTRAINT `fk_alert_alert_category1` FOREIGN KEY (`Alert_category`) REFERENCES `alert_category` (`Category`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_alert_source1` FOREIGN KEY (`Source_id`) REFERENCES `source` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_alert_user` FOREIGN KEY (`User_id`) REFERENCES `user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=182 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alert`
--

LOCK TABLES `alert` WRITE;
/*!40000 ALTER TABLE `alert` DISABLE KEYS */;
INSERT INTO `alert` VALUES (161,'Un nou post de televiziune în grila canalelor IPTV de la Moldtelecom',NULL,'Începînd cu data de 3 mai, în lista canalelor televizate oferite de Moldtelecom va fi inclus un nou post al televiziunii naționale. Teleradio Moldova, lansează canalul “Moldova 2” conținutul căruia va fi axat, în principal, pe difuzarea celor mai importante evenimente sportive internaționale precum difuzarea zilnică a Jocurilor Olimpice de vară 2016 și a Campionatului European de fotbal 2016, dar și competiții sportive naționale. citiţi mai departe','2016-05-02 18:17:37',NULL,1,'1-Un nou post de televiziune în grila canalelor IPTV de la Moldtelecom-5/2/2016 18:17:37',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(162,'Dan Mitriuc este noul director general al Societății pe Acțiuni \"Moldtelecom\"',NULL,'Din 11 aprilie anul curent, Societatea pe Acțiuni \"Moldtelecom\" va avea un nou director general – domnul Dan Mitriuc. Decizia a fost luată de Consiliul Societății pe Acțiuni „Moldtelecom”, care l-a desemnat pe Dan Mitriuc în această funcție, în urma unui concurs public la care au aplicat 11 participanți.','2016-04-06 10:47:11',NULL,1,'1-Dan Mitriuc este noul director general al Societății pe Acțiuni \"Moldtelecom\"-4/6/2016 10:47:11',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(163,'Cîştigătorii premiilor mari din cadrul promoţiei “ Achită şi cîştigă doar la magazinul Moldtelecom pe str. Alecu Russo 2”',NULL,'C îştigătorii premiilor mari din cadrul promoţiei “ Achită şi cîştigă doar la magazinul Moldtelecom pe str. Alecu Russo 2” citiţi mai departe','2016-03-31 14:23:54',NULL,1,'1-Cîştigătorii premiilor mari din cadrul promoţiei “ Achită şi cîştigă doar la magazinul Moldtelecom pe str. Alecu Russo 2”-3/31/2016 14:23:54',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(164,'Promoţia „ Achită şi cîştigă doar la magazinul Moldtelecom de pe strada Alecu Russo 2” se prelungeşte pînă la data de 31 martie 2016.',NULL,'Compania Moldtelecom, anunţă despre prelungirea promoţiei “ Achită şi cîştigă doar la magazinul Moldtelecom de pe str. Alecu Russo 2” pînă la data de 31 martie 2016, conform punctului 8 al Regulamentului promoţiei. citiţi mai departe','2016-03-23 22:00:00',NULL,1,'1-Promoţia „ Achită şi cîştigă doar la magazinul Moldtelecom de pe strada Alecu Russo 2” se prelungeşte pînă la data de 31 martie 2016.-3/23/2016 22:00:00',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(165,'S-a finalizat recepționarea documentelor candidaților la funcția de Director general al Societății pe Acțiuni „Moldtelecom”',NULL,'La data de 21 Martie 2016 s-a finalizat recepționarea documentelor conform avizului din 04 Martie 2016. În total au fost recepționate documente de la 11 candidați. Dosarele se examinează de către comisia de selectare. Întru respectarea prevederilor legislației din domeniul protecției datelor cu caracter personal, datele personale ale candidaților nu se supun divulgării.','2016-03-22 16:17:18',NULL,1,'1-S-a finalizat recepționarea documentelor candidaților la funcția de Director general al Societății pe Acțiuni „Moldtelecom”-3/22/2016 16:17:18',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(166,'Aviz vizînd desfăşurarea selectării candidaturii la funcţia de Director general al Societății pe Acțiuni „Moldtelecom”',NULL,'Aprobat: Hotărîrea Consiliului S.A. „Moldtelecom” nr 04/15 din 03.03.2016 AVIZ vizînd desfăşurarea selectării candidaturii la funcţia de Director general al Societății pe Acțiuni „Moldtelecom” citiţi mai departe','2016-03-04 14:00:06',NULL,1,'1-Aviz vizînd desfăşurarea selectării candidaturii la funcţia de Director general al Societății pe Acțiuni „Moldtelecom”-3/4/2016 14:00:06',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(167,'Încearcă 12 funcţii TV interactive despre care nu ştiai până acum.',NULL,'Priveşte televizorul altfel decît te-ai obişnuit pentru că televiziunea ta îţi poate oferi mult mai multe decât ţi-ai imaginat. Televiziunea interactivă de la Moldtelecom conține peste 12 funcţii interactive despre care nu ştiai pînă acum. Află mai mult despre fiecare funcţie și încearcă-le: citiţi mai departe','2016-02-24 06:05:20',NULL,1,'1-Încearcă 12 funcţii TV interactive despre care nu ştiai până acum.-2/24/2016 06:05:20',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(168,'Modificări în grila IPTV',NULL,'Stimaţi abonaţi, Vă informăm asupra faptului că pe data de 11 februarie 2016, compania Moldtelecom va opera câteva modificări nesemnificative în grila serviciilor de televiziune IPTV. Modificările sunt operate pentru comoditatea abonaţilor şi se referă la reconfigurarea ordinii unor posturi TV. Modificări de acest gen se efectuează periodic, iar la baza lor sunt analiza popularităţii posturilor tv, tematica lor, comoditatea utilizării precum şi solicitările abonaţilor. Totodată va fi lansat un post nou: NTV Moldova, care va fi pe poziţia cu numărul 9. citiţi mai departe','2016-02-10 17:51:57',NULL,1,'1-Modificări în grila IPTV-2/10/2016 17:51:57',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(169,'Acces gratuit la toate canalele tv din grila IPTV Moldtelecom',NULL,'Compania Moldtelecom are ca scop prioritar oferirea de servicii calitative de telecomunicaţii. În vederea asigurării acestui lucru, compania se sesizează referitor la probleme de orice gen care pot afecta calitatea serviciilor şi satisfacţia abonaţilor. În aces sens, în urma identificării deficienţelor tehnice apărute în data de 20 ianuarie 2016 cauzate de atacul cibernetic, care au dus la sistarea temporară a cîteva posturi tv din grila de canale IPTV, compania a întreprins toate măsurile necesare depăşirii acestei situaţii. citiţi mai departe','2016-01-29 15:46:10',NULL,1,'1-Acces gratuit la toate canalele tv din grila IPTV Moldtelecom-1/29/2016 15:46:10',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(170,'Restabilirea deplină a grilei posturilor IPTV Moldtelecom',NULL,'Stimați abonați Începând de ieri 20 ianuarie, și pe parcursul zilei de astăzi, au fost întâmpinate probleme tehnice în difuzarea unui șir de canale TV din grila de emisie IPTV a companiei. Au fost întreprinse toate măsurile necesare pentru soluţionarea defecţiunilor apărute, astfel încât începând cu ora 15:30 serviciile au fost restabilite în deplină măsură. Ne cerem scuze pentru incomoditățile create. Vă mulțumim pentru înțelegere. citiţi mai departe','2016-01-21 15:49:17',NULL,1,'1-Restabilirea deplină a grilei posturilor IPTV Moldtelecom-1/21/2016 15:49:17',NULL,'ServiciiComunale',NULL,NULL,'2016-05-15 09:04:19'),(171,'Întrerupere programată de 3 ore în livrarea energiei electrice în mun. Chişinău pentru efectuarea unei lucrări de reparaţie',NULL,'\n	&Icirc;.C.S.&rdquo; Red Union Fenosa&rdquo; S.A. informează, că &icirc;n municipiul Chişinău, &icirc;n noaptea zilei de 17 mai, 2016, &icirc;n intervalul de timp cuprins &icirc;ntre orele 01:00 şi 04:00, vor avea loc lucrari planificate de reparaţie la...','2016-01-13 00:05:00',NULL,2,'2-Întrerupere programată de 3 ore în livrarea energiei electrice în mun. Chişinău pentru efectuarea unei lucrări de reparaţie-1/13/2016 00:05:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/ntrerupere-programat-de-3-ore-n-livrarea-energiei-electrice-n-mun-chi-u-pentru-efectuarea-unei-','2016-05-15 09:04:26'),(172,'Invitaţie la concertul chitaristului spaniol Michel Aranda',NULL,'\n	Gas Natural Fenosa &icirc;n Moldova vă invită vineri, 13 mai 2016 la un concert extraordinar de chitară susținut&nbsp;de talentatul muzician și&nbsp;chitarist spaniol Michel Aranda.\n\n	Evenimentul va avea loc la Filarmonica Națională din Chișinău,...','2016-01-12 00:05:00',NULL,2,'2-Invitaţie la concertul chitaristului spaniol Michel Aranda-1/12/2016 00:05:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/invita-ie-la-concertul-chitaristului-spaniol-michel-aranda','2016-05-15 09:04:26'),(173,'Studenţi de la UTM în vizită de documentare la Gas Natural Fenosa',NULL,'\n	Pe 11 mai curent,&nbsp;38 de studenţi ai Facultăţii Inginerie Mecanică, Industrială şi Transporturi din cadrul Universităţii Tehnice din Moldova au efectuat o vizită de documentare &icirc;n secţia transport a companiei Gas Natural Fenosa &icirc;n...','2016-01-11 00:05:00',NULL,2,'2-Studenţi de la UTM în vizită de documentare la Gas Natural Fenosa-1/11/2016 00:05:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/studen-i-de-la-utm-n-vizit-de-documentare-la-gas-natural-fenosa','2016-05-15 09:04:26'),(174,'Acţiuni de caritate cu ocazia Sfintelor Paşti',NULL,'\n	Lumina Sfintei &Icirc;nvieri &icirc;n acest an a readus &icirc;n familiile mai multor oameni necăjiţi&nbsp; de vitregiile vieţii bucuria carităţii şi &icirc;ncrederea &icirc;n bunătatea oamenilor. Sf&acirc;nta sărbătoare de Paşte este un moment &icirc;...','2016-01-03 00:05:00',NULL,2,'2-Acţiuni de caritate cu ocazia Sfintelor Paşti-1/3/2016 00:05:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/ac-iuni-de-caritate-cu-ocazia-sfintelor-pa-ti','2016-05-15 09:04:26'),(175,'Gas Natural Fenosa a ocupat locul doi la Open Cupa Presei 2016 la futsal, ediţia XVI',NULL,'La 17 aprilie, la Complexul Sportiv al Instituţiei Publice Universitatea de Stat de Medicină şi Farmacie &bdquo;Nicolae Testemiţanu&rdquo; a avut loc ceremonia de premiere a laureaţilor turneului Open Cupa Presei&nbsp;-&nbsp;2016 la futsal, ediţia XVI,...','2016-01-26 00:04:00',NULL,2,'2-Gas Natural Fenosa a ocupat locul doi la Open Cupa Presei 2016 la futsal, ediţia XVI-1/26/2016 00:04:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/gas-natural-fenosa-ocupat-locul-doi-la-open-cupa-presei-2016-la-futsal-edi-ia-xvi','2016-05-15 09:04:26'),(176,'Marcăm Ziua Pământului',NULL,'\n	De Ziua Păm&acirc;ntului, la 22 aprilie, echipa Gas Natural Fenosa &icirc;n Moldova &icirc;mpreună cu cea a Centrului Național de Mediu și-au propus să dedice c&acirc;teva ore curățirii de deșeuri a parcului din sectorul Buiucani.\n\n	&nbsp;\n\n	Av&acirc;...','2016-01-22 00:04:00',NULL,2,'2-Marcăm Ziua Pământului-1/22/2016 00:04:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/marcam-ziua-pamantului','2016-05-15 09:04:26'),(177,'Furturi în proporţii deosebit de mari din instalaţiile electrice au afectat consumatorii din 4 sate',NULL,'\n	Şase posturi de transformare (PT) ce alimentează cu energie electrică consumatori din raioanele Cahul, Taraclia şi Cead&icirc;r-Lunga au fost scoase din uz de hoții de ulei &icirc;n doar două nopţi. &Icirc;n rezultatul furtului instalaţiile electrice...','2016-01-06 00:04:00',NULL,2,'2-Furturi în proporţii deosebit de mari din instalaţiile electrice au afectat consumatorii din 4 sate-1/6/2016 00:04:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/furturi-n-propor-ii-deosebit-de-mari-din-instala-iile-electrice-au-afectat-consumatorii-din-4-s','2016-05-15 09:04:26'),(178,'Un copil s-a electrocutat mortal în urma atingerii de echipamentele unui post de transformare, aflate sub tensiune',NULL,'&nbsp;Acest caz tragic s-a produs pe 16 martie, curent, &icirc;n satul Copceac din raionul Ştefan Vodă &icirc;n interiorul unui post de transformare aflat &icirc;n apropierea şcolii din localitate. &Icirc;n urma investigării circumstanţelor producerii...','2016-01-24 00:03:00',NULL,2,'2-Un copil s-a electrocutat mortal în urma atingerii de echipamentele unui post de transformare, aflate sub tensiune-1/24/2016 00:03:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/un-copil-s-electrocutat-mortal-n-urma-atingerii-de-echipamentele-unui-post-de-transformare-afla','2016-05-15 09:04:26'),(179,'Lucrare neautorizată în preajma reţelelor electrice soldată cu accidentarea a trei persoane',NULL,'\n	Executarea&nbsp; de către un agent economic a unei lucrări necoordonate cu &icirc;ntreprinderea de distribuţie a energiei electrice şi &icirc;ncălcarea mai multor norme de securitate s-a soldat cu accidentarea a trei persoane.\n\n	&nbsp;\n\n	Cazul a avut...','2016-01-17 00:03:00',NULL,2,'2-Lucrare neautorizată în preajma reţelelor electrice soldată cu accidentarea a trei persoane-1/17/2016 00:03:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/lucrare-neautorizat-n-preajma-re-elelor-electrice-soldat-cu-accidentarea-trei-persoane','2016-05-15 09:04:26'),(180,'Gas Natural Fenosa participă la ediția a XX-a a expoziţiei internaţionale „Moldenergy”',NULL,'\n	Gas Natural Fenosa&nbsp;participă pentru al patrulea an consecutiv la expoziţia internaţională specializată &bdquo;Moldenergy&rdquo;, ediţia a XX-a, inaugurarea căreia a avut loc astăzi, 16 martie, 2016, la Centrul Internaţional de Expoziţii &bdquo;...','2016-01-16 00:03:00',NULL,2,'2-Gas Natural Fenosa participă la ediția a XX-a a expoziţiei internaţionale „Moldenergy”-1/16/2016 00:03:00',NULL,'ServiciiComunale',NULL,'http://gasnaturalfenosa.md/press/news/gas-natural-fenosa-particip-la-edi-ia-xx-expozi-iei-interna-ionale-moldenergy','2016-05-15 09:04:26'),(181,'Sunday - 11:00 EEST: Light Cloud, 16°C (61°F)',NULL,'Temperature: 16°C (61°F), Wind Direction: West North Westerly, Wind Speed: 11mph, Humidity: 66%, Pressure: 1002mb, Rising, Visibility: Very Good','2016-05-15 09:00:06',NULL,3,'3-Sunday - 11:00 EEST: Light Cloud, 16°C (61°F)-5/15/2016 09:00:06',NULL,'Meteo',NULL,NULL,'2016-05-15 09:04:26');
/*!40000 ALTER TABLE `alert` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `alert_category`
--

DROP TABLE IF EXISTS `alert_category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `alert_category` (
  `Category` varchar(100) NOT NULL,
  PRIMARY KEY (`Category`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alert_category`
--

LOCK TABLES `alert_category` WRITE;
/*!40000 ALTER TABLE `alert_category` DISABLE KEYS */;
INSERT INTO `alert_category` VALUES ('Evenimente'),('Meteo'),('ServiciiComunale'),('Transport');
/*!40000 ALTER TABLE `alert_category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `course` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
INSERT INTO `course` VALUES (1,'PSI');
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `element`
--

DROP TABLE IF EXISTS `element`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `element` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `TextContent` text NOT NULL,
  `BinaryContent` longblob,
  `Type` varchar(50) NOT NULL,
  `CreateDate` datetime NOT NULL,
  `LastChangedDate` datetime NOT NULL,
  `CursId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `FK_element_course_idx` (`CursId`),
  CONSTRAINT `FK_element_course` FOREIGN KEY (`CursId`) REFERENCES `course` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `element`
--

LOCK TABLES `element` WRITE;
/*!40000 ALTER TABLE `element` DISABLE KEYS */;
INSERT INTO `element` VALUES (1,'dnkajnd',NULL,'1','2016-04-06 10:47:11','2016-04-06 10:47:11',1);
/*!40000 ALTER TABLE `element` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `parser_types`
--

DROP TABLE IF EXISTS `parser_types`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `parser_types` (
  `Type` varchar(50) NOT NULL,
  PRIMARY KEY (`Type`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `parser_types`
--

LOCK TABLES `parser_types` WRITE;
/*!40000 ALTER TABLE `parser_types` DISABLE KEYS */;
INSERT INTO `parser_types` VALUES ('GazNaturalFenosaHtmlParser'),('RssFeed');
/*!40000 ALTER TABLE `parser_types` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `source`
--

DROP TABLE IF EXISTS `source`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `source` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `URL` varchar(1024) DEFAULT NULL,
  `ParserType` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_source.ParserType_parser_types.Type_idx` (`ParserType`),
  CONSTRAINT `FK_source.ParserType_parser_types.Type` FOREIGN KEY (`ParserType`) REFERENCES `parser_types` (`Type`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `source`
--

LOCK TABLES `source` WRITE;
/*!40000 ALTER TABLE `source` DISABLE KEYS */;
INSERT INTO `source` VALUES (1,'MoldtelecomRSS','http://www.moldtelecom.md/news/rss','RssFeed'),(2,'GazNaturalFenosaHtml','http://gasnaturalfenosa.md/press','GazNaturalFenosaHtmlParser'),(3,'MeteoRSS','http://open.live.bbc.co.uk/weather/feeds/en/618426/observations.rss','RssFeed');
/*!40000 ALTER TABLE `source` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'u1','u123u@yopmail.com','123'),(2,'u2','u2@yopmail.com','123');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_alert_queue`
--

DROP TABLE IF EXISTS `user_alert_queue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `user_alert_queue` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `AlertId` int(11) NOT NULL,
  `ViewedOn` datetime NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_uaq.UserId_user.Id_idx` (`UserId`),
  KEY `FK_uaq.AlertId_alert.Id_idx` (`AlertId`),
  CONSTRAINT `FK_uaq.AlertId_alert.Id` FOREIGN KEY (`AlertId`) REFERENCES `alert` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_uaq.UserId_user.Id` FOREIGN KEY (`UserId`) REFERENCES `user` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_alert_queue`
--

LOCK TABLES `user_alert_queue` WRITE;
/*!40000 ALTER TABLE `user_alert_queue` DISABLE KEYS */;
INSERT INTO `user_alert_queue` VALUES (1,1,181,'2016-05-18 16:24:41'),(2,1,161,'2016-05-18 16:24:43'),(3,1,162,'2016-05-18 16:24:45'),(4,1,169,'2016-05-18 16:24:54'),(5,1,168,'2016-05-18 16:24:55'),(6,1,163,'2016-05-18 16:26:06'),(7,1,164,'2016-05-18 16:26:08'),(8,1,165,'2016-05-18 16:26:09'),(9,1,175,'2016-05-18 16:26:17'),(10,2,164,'2016-05-18 16:28:18'),(11,2,174,'2016-05-18 16:28:43'),(12,2,162,'2016-05-18 16:29:06'),(13,2,161,'2016-05-18 16:29:08'),(14,1,167,'2017-12-09 11:15:45');
/*!40000 ALTER TABLE `user_alert_queue` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-12-09 14:10:20
