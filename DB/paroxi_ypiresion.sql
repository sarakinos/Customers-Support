-- phpMyAdmin SQL Dump
-- version 4.1.12
-- http://www.phpmyadmin.net
--
-- Φιλοξενητής: 127.0.0.1
-- Χρόνος δημιουργίας: 02 Σεπ 2014 στις 16:44:06
-- Έκδοση διακομιστή: 5.6.16
-- Έκδοση PHP: 5.5.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Βάση δεδομένων: `paroxi_ypiresion`
--

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `aitimata`
--

CREATE TABLE IF NOT EXISTS `aitimata` (
  `ait_id` int(11) NOT NULL AUTO_INCREMENT,
  `p_id` int(11) NOT NULL,
  `Titlos` varchar(300) NOT NULL,
  `Proodos` int(11) DEFAULT '0',
  `Sxolia` varchar(500) NOT NULL,
  `Hmerominia_Ypovolis` date NOT NULL,
  `Hmerominia_Ekplirosis` date DEFAULT NULL,
  `eidopoihsh` int(11) DEFAULT NULL,
  `apotelesma` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`ait_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Άδειασμα δεδομένων του πίνακα `aitimata`
--

INSERT INTO `aitimata` (`ait_id`, `p_id`, `Titlos`, `Proodos`, `Sxolia`, `Hmerominia_Ypovolis`, `Hmerominia_Ekplirosis`, `eidopoihsh`, `apotelesma`) VALUES
(6, 41, 'Aitima1', 1, 'asd', '2014-09-02', NULL, NULL, 0);

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `days`
--

CREATE TABLE IF NOT EXISTS `days` (
  `day` int(2) NOT NULL DEFAULT '0',
  `month` int(2) NOT NULL DEFAULT '0',
  `text` varchar(255) NOT NULL DEFAULT ''
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Άδειασμα δεδομένων του πίνακα `days`
--

INSERT INTO `days` (`day`, `month`, `text`) VALUES
(7, 1, 'Ιωάννης, Ιωάννα, Ιώ, Πρόδρομος'),
(1, 1, 'Βασίλης, Βασιλική'),
(6, 1, 'Φώτης, Φωτεινή, Θεοφάνης, Θεοφανία, Φανή'),
(9, 1, 'Ευστράτιος, Ευστρατία'),
(11, 1, 'Θεοδόσιος'),
(12, 1, 'Τατιάνα'),
(17, 1, 'Αντώνης, Αντωνία'),
(18, 1, 'Θανάσης, Αθανασία'),
(20, 1, 'Ευθύμιος, Ευθυμία'),
(21, 1, 'Μάξιμος'),
(22, 1, 'Τιμόθεος'),
(24, 1, 'Ξένη'),
(25, 1, 'Γρηγόρης, Γρηγορία'),
(26, 1, 'Ξενοφώντας'),
(1, 2, 'Τρύφωνας'),
(2, 2, 'Ιορδάνης'),
(4, 2, 'Ισίδωρος'),
(5, 2, 'Αγαθή'),
(7, 2, 'Παρθένα, Παρθένιος'),
(8, 2, 'Ζαχαρίας, Ζάχος, Ζαχαρούλα'),
(9, 2, 'Νικηφόρος'),
(10, 2, 'Χαράλαμπος, Χαρίκλεια, Κλειώ'),
(11, 2, 'Βλάσσης'),
(12, 2, 'Μελέτης'),
(14, 2, 'Βαλεντίνος, Βαλεντίνα'),
(18, 2, 'Λέων'),
(19, 2, 'Φιλοθέη'),
(23, 2, 'Πολύκαρπος'),
(26, 2, 'Πορφύριος'),
(27, 2, 'Ασκληπιός'),
(1, 3, 'Ευδοκία'),
(2, 3, 'Θάλια'),
(8, 3, 'Ερμής'),
(17, 3, 'Αλέξιος, Αλεξία, Αλίκη'),
(18, 3, 'Θεόδωρος'),
(19, 3, 'Χρύσανθος, Χρυσάνθη'),
(25, 3, 'Βαγγέλης, Ευαγγελία'),
(6, 4, 'Ευτύχιος, Ευτυχία'),
(14, 4, 'Ανθή'),
(15, 4, 'Λεωνίδας'),
(20, 4, 'Ζωή, Πηγή'),
(22, 4, 'Ναθαναήλ'),
(23, 4, 'Γιώργος, Γεωργία'),
(24, 4, 'Ελισσάβετ, Λίζα'),
(25, 4, 'Μάρκος'),
(29, 4, 'Ιάσωνας'),
(30, 4, 'Ιάκωβος'),
(1, 5, 'Ιερεμίας'),
(5, 5, 'Ειρήνη'),
(8, 5, 'Αρσένιος, Θεολόγος'),
(9, 5, 'Ησαΐας, Χριστόφορος'),
(11, 5, 'Μεθόδιος'),
(13, 5, 'Γλυκερία'),
(18, 5, 'Ιουλία'),
(21, 5, 'Κωνσταντίνος, Ελένη'),
(29, 5, 'Θεοδοσία'),
(4, 6, 'Μάρθα'),
(5, 6, 'Δωροθέος, Δωροθέα, Απόλλωνας'),
(8, 6, 'Καλλιόπη'),
(11, 6, 'Βαρναβάς, Βαρθολομαίος'),
(22, 6, 'Ευσέβιος'),
(27, 6, 'Παντελής'),
(29, 6, 'Παύλος, Πέτρος, Πετρούλα, Παυλίνα, Πωλίνα'),
(30, 6, 'Απόστολος'),
(1, 7, 'Αργύρης, Αργυρώ, Δαμιανός, Κοσμάς'),
(7, 7, 'Κυριάκος, Κυριακή'),
(8, 7, 'Θεόφιλος, Προκόπης'),
(11, 7, 'Ευθημία, Όλγα'),
(17, 7, 'Μαρίνος, Μαρίνα'),
(18, 7, 'Αιμίλιος, Αιμιλία'),
(20, 7, 'Ηλίας, Ηλιάνα'),
(22, 7, 'Μαγδαληνή, Μαρκέλα, Άννα'),
(26, 7, 'Παρασκευή, Παρασκευάς'),
(27, 7, 'Παντελεήμων,  Παντελής, Λάκης'),
(29, 7, 'Καλλίνικος'),
(31, 7, 'Ιωσήφ'),
(6, 8, 'Σωτήρης, Σωτηρία'),
(8, 8, 'Αιμιλιανός, Τριαντάφυλλος'),
(10, 8, 'Λαυρέντης'),
(15, 8, 'Παναγιώτης, Παναγιώτα, Μαριάννα, Μαρία, Μάριος, Δέσποινα'),
(20, 8, 'Σαμουήλ'),
(25, 8, 'Τίτος, Πάστης'),
(26, 8, 'Ναταλία'),
(27, 8, 'Φανούριος, Φανουρία'),
(30, 8, 'Αλέξανδρος, Αλεξάνδρα, Αλέκα, Αλέκος'),
(1, 9, 'Συμεών'),
(3, 9, 'Άνθιμος'),
(5, 9, 'Ζαχαρίας'),
(9, 9, 'Ιωακείμ'),
(11, 9, 'Ευανθία, Εύα'),
(14, 9, 'Σταύρος, Σταυρούλα'),
(15, 9, 'Νικήτας'),
(16, 9, 'Ευθημία, Έφη'),
(17, 9, 'Αγάπη, Σοφία, Ελπίδα'),
(18, 9, 'Αριάδνη'),
(20, 9, 'Στάθης, Ευσταθία'),
(23, 9, 'Ξανθιππη, Πολυξένη, Ξένια'),
(24, 9, 'Θέκλα, Μυρτώ'),
(25, 9, 'Φρόσω'),
(2, 10, 'Κυπριανός'),
(3, 10, 'Διονύσιος, Διονυσία'),
(4, 10, 'Ιερόθεος, Φραγκίσκος'),
(5, 10, 'Χαριτίνη'),
(7, 10, 'Σέργιος'),
(8, 10, 'Πελαγία, Πέλλα'),
(10, 10, 'Ευλάμπιος, Ευλαμπία'),
(15, 10, 'Λουκιανός'),
(18, 10, 'Λουκάς'),
(20, 10, 'Αρτέμιος, Γεράσιμος'),
(21, 10, 'Σωκράτης'),
(23, 10, 'Ιάκωβος'),
(26, 10, 'Δήμητρα, Δημήτρης'),
(27, 10, 'Νέστωρας'),
(1, 11, 'Αργύρης, Αργυρώ, Δαμιανός, Κοσμάς'),
(8, 11, 'Αγγελική, Άγγελος, Ταξιάρχης, Γαρβιήλ, Μιχάλης, Σεραφείμ, Σταμάτης, Σταματία'),
(9, 11, 'Νεκτάριος, Νεκταρία'),
(10, 11, 'Ορέστης'),
(11, 11, 'Βίκτωρας, Βικτώρια, Μηνάς'),
(13, 11, 'Χρυσόστομος'),
(14, 11, 'Φίλιππος'),
(16, 11, 'Ματθαίος'),
(18, 11, 'Πλάτωνας'),
(21, 11, 'Μαρία, Δέσποινα, Παναγιώτα'),
(25, 11, 'Κατερίνα, Κάτια, Μερκούρης'),
(26, 11, 'Στυλιαννός, Στέλιος, Στέλλα'),
(30, 11, 'Ανδρέας, Ανδριαννή'),
(4, 12, 'Βαρβάρα'),
(5, 12, 'Σάββας, Διογένης'),
(6, 12, 'Νίκος, Νικολέτα'),
(7, 12, 'Αμβρόσιος'),
(9, 12, 'Άννα'),
(12, 12, 'Σπύρος, Σπυριδούλα'),
(13, 12, 'Λουκία, Στράτος'),
(15, 12, 'Λευτέρης, Ελευθερία'),
(17, 12, 'Δανιήλ, Διονύσης, Διονυσία'),
(19, 12, 'Αγλαΐα'),
(20, 12, 'Ιγνάτιος'),
(21, 12, 'Θεμιστοκλής'),
(22, 12, 'Αναστασία'),
(24, 12, 'Ευγένιος, Ευγενία'),
(25, 12, 'Χρήστος, Χριστίνα, Χρύσα, Μανώλης'),
(27, 12, 'Στέφανος, Στεφανία');

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `dimoi`
--

CREATE TABLE IF NOT EXISTS `dimoi` (
  `dimos_id` int(11) NOT NULL AUTO_INCREMENT,
  `periferiaki_enotita_id` int(11) NOT NULL,
  `onoma` varchar(200) NOT NULL,
  PRIMARY KEY (`dimos_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=greek AUTO_INCREMENT=61 ;

--
-- Άδειασμα δεδομένων του πίνακα `dimoi`
--

INSERT INTO `dimoi` (`dimos_id`, `periferiaki_enotita_id`, `onoma`) VALUES
(1, 1, 'Doksatou'),
(2, 1, 'Dramas'),
(3, 1, 'Kato Nevrokopiou'),
(4, 1, 'Paranestiou'),
(5, 1, 'Prosotsanis'),
(6, 2, 'Aleksandroupolis'),
(7, 2, 'Didimoteixou'),
(8, 2, 'Orestiadas'),
(9, 2, 'Samothrakis'),
(10, 2, 'Soufliou'),
(11, 3, 'Thasou'),
(12, 3, 'Kavalas'),
(13, 3, 'Nestou'),
(14, 3, 'Paggaiou'),
(15, 5, 'Avdiron'),
(16, 5, 'Mikis'),
(17, 5, 'Ksanthis'),
(18, 5, 'Topeirou'),
(19, 6, 'Arrianon'),
(20, 6, 'Iasmou'),
(21, 6, 'Komotinis'),
(22, 6, 'Maroneias - Sapon'),
(23, 7, 'Aleksandreias'),
(24, 7, 'Veroias'),
(25, 7, 'Naousas'),
(26, 8, 'Ampelokipon-Menemenis'),
(27, 8, 'Volvis'),
(28, 8, 'Delta'),
(29, 8, 'Thermaikou'),
(30, 8, 'Thermis'),
(31, 8, 'Thessalonikis'),
(32, 8, 'Kalamarias'),
(33, 8, 'Kardeliou-Evosmou'),
(34, 8, 'Lagkada'),
(35, 8, 'Neapolis-Sikeon'),
(36, 8, 'Pavlou Mela'),
(37, 8, 'Pylaias-Xortiati'),
(38, 8, 'Xalkidonos'),
(39, 8, 'Oraiokastrou'),
(40, 9, 'Kilkis'),
(41, 9, 'Paionias'),
(42, 10, 'Almotias'),
(43, 10, 'Edessas'),
(44, 10, 'Pellas'),
(45, 10, 'Skydras'),
(46, 11, 'Diou-Olympou'),
(47, 11, 'Katerinis'),
(48, 11, 'Pydnas-Kolindrou'),
(49, 12, 'Amfipolis'),
(50, 12, 'Visaltias'),
(51, 12, 'Emmanouil Pappa'),
(52, 12, 'Hrakleias'),
(53, 12, 'Neas Zixnis'),
(54, 12, 'Serron'),
(55, 12, 'Sintikis'),
(56, 13, 'Aristoteli'),
(57, 13, 'Kasandras'),
(58, 13, 'Neas Propontidas'),
(59, 13, 'Polygyrou'),
(60, 13, 'Sithonias');

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `migrations`
--

CREATE TABLE IF NOT EXISTS `migrations` (
  `migration` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `batch` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Άδειασμα δεδομένων του πίνακα `migrations`
--

INSERT INTO `migrations` (`migration`, `batch`) VALUES
('2014_08_27_174600_create_users_table', 1),
('2014_08_27_191526_create_users_table', 2),
('2014_08_27_192713_create_users_table', 3);

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `pelates`
--

CREATE TABLE IF NOT EXISTS `pelates` (
  `p_id` int(11) NOT NULL AUTO_INCREMENT,
  `Onoma` varchar(250) NOT NULL,
  `Epitheto` varchar(250) NOT NULL,
  `Onoma_Miteras` varchar(250) NOT NULL,
  `Onoma_Patera` varchar(250) NOT NULL,
  `Hmerominia_Gennisis` date NOT NULL,
  `Tilefono_Oikias` int(11) NOT NULL,
  `Kinito_Tilefono` int(11) NOT NULL,
  `Diefthinsi` varchar(250) NOT NULL,
  `Dimos` varchar(250) NOT NULL,
  `Periferia` varchar(250) NOT NULL,
  `Periferiaki_Enotita` int(11) NOT NULL,
  `Epaggelma` varchar(250) NOT NULL,
  `Email` varchar(250) NOT NULL,
  PRIMARY KEY (`p_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=44 ;

--
-- Άδειασμα δεδομένων του πίνακα `pelates`
--

INSERT INTO `pelates` (`p_id`, `Onoma`, `Epitheto`, `Onoma_Miteras`, `Onoma_Patera`, `Hmerominia_Gennisis`, `Tilefono_Oikias`, `Kinito_Tilefono`, `Diefthinsi`, `Dimos`, `Periferia`, `Periferiaki_Enotita`, `Epaggelma`, `Email`) VALUES
(41, 'Bampis', 'Sykovaridis', 'pok', 'pok', '2014-09-02', 90, 909, 'oijoij', 'Doksatou', 'Anatoliki Makedokia kai Thraki', 0, 'dwd', 'bampis.2@fmaid.com'),
(42, 'Stefanos', 'Zagkotas111', 'pokpo', '1111', '2014-09-18', 334, 3434, 'asdasd', 'sad', 'asd', 0, 'ads', 'asdsa@gdfdf.com');

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `periferiaki_enotita`
--

CREATE TABLE IF NOT EXISTS `periferiaki_enotita` (
  `periferiaki_enotita_id` int(11) NOT NULL AUTO_INCREMENT,
  `periferia_id` int(11) NOT NULL,
  `onoma` varchar(150) NOT NULL,
  PRIMARY KEY (`periferiaki_enotita_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=greek AUTO_INCREMENT=75 ;

--
-- Άδειασμα δεδομένων του πίνακα `periferiaki_enotita`
--

INSERT INTO `periferiaki_enotita` (`periferiaki_enotita_id`, `periferia_id`, `onoma`) VALUES
(1, 49, 'Dramas'),
(2, 49, 'Evrou'),
(3, 49, 'Kavalas'),
(4, 49, 'Thasou'),
(5, 49, 'Ksanthis'),
(6, 49, 'Rodopis'),
(7, 50, 'Imathias'),
(8, 50, 'Thessalonikis'),
(9, 50, 'Kilkis'),
(10, 50, 'Pellas'),
(11, 50, 'Pierias'),
(12, 50, 'Serron'),
(13, 50, 'Xalkidikis'),
(14, 51, 'Grevenon'),
(15, 51, 'Kastorias'),
(16, 51, 'Kozanis'),
(17, 51, 'Florinas'),
(18, 52, 'Artas'),
(19, 52, 'Thesprotias'),
(20, 52, 'Ioanninon'),
(21, 52, 'Prevezas'),
(22, 53, 'Karditsas'),
(23, 53, 'Larisas'),
(24, 53, 'Magnisias'),
(25, 53, 'Sporadon'),
(26, 53, 'Trikalon'),
(27, 54, 'Zakinthou'),
(28, 54, 'Kerkiras'),
(29, 54, 'Kefallinias'),
(30, 54, 'Ithakis'),
(31, 54, 'Lefkadas'),
(32, 55, 'Aitoloakarnanias'),
(33, 55, 'Axaias'),
(34, 55, 'Ileias'),
(35, 56, 'Voiotias'),
(36, 56, 'Efvoias'),
(37, 56, 'Evritanias'),
(38, 56, 'Fthiotidas'),
(39, 56, 'Fokidas'),
(40, 57, 'Voreiou Tomea Athinon'),
(41, 57, 'Ditikou Tomea Athinon'),
(42, 57, 'Kentrikou Tomea Athinon'),
(43, 57, 'Notiou Tomea Athinon'),
(44, 57, 'Piraios'),
(45, 57, 'Nison'),
(46, 57, 'Anatolikis Attikis'),
(47, 57, 'Ditikis Attikis'),
(48, 58, 'Argolidas'),
(49, 58, 'Arkadias'),
(50, 58, 'Korinthias'),
(51, 58, 'Lakonias'),
(52, 58, 'Messinias'),
(53, 59, 'Lesvos'),
(54, 59, 'Ikarias'),
(55, 59, 'Limnou'),
(56, 59, 'Samou'),
(57, 59, 'Xiou'),
(58, 60, 'Androu'),
(59, 60, 'Milou'),
(60, 60, 'Thiras'),
(61, 60, 'Neas-Kithnou'),
(62, 60, 'Mikonou'),
(63, 60, 'Naksou'),
(64, 60, 'Sirou'),
(65, 60, 'Tinou'),
(66, 60, 'Parou'),
(67, 60, 'Kalimnou'),
(68, 60, 'Karpathou'),
(69, 60, 'Ko'),
(70, 61, 'Radou'),
(71, 61, 'Irakleiou'),
(72, 61, 'Lasithiou'),
(73, 61, 'Rethimnis'),
(74, 61, 'Xanion');

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `periferies`
--

CREATE TABLE IF NOT EXISTS `periferies` (
  `periferia_id` int(11) NOT NULL AUTO_INCREMENT,
  `onoma` varchar(200) NOT NULL,
  PRIMARY KEY (`periferia_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=greek AUTO_INCREMENT=62 ;

--
-- Άδειασμα δεδομένων του πίνακα `periferies`
--

INSERT INTO `periferies` (`periferia_id`, `onoma`) VALUES
(49, 'Anatoliki Makedokia kai Thraki'),
(50, 'Kentriki Makedonia'),
(51, 'Ditiki Makedonia'),
(52, 'Hpeiros'),
(53, 'Thessalia'),
(54, 'Periferia Ionion Nison'),
(55, 'Periferia Ditikis Elladas'),
(56, 'Periferia Stereas Elladas'),
(57, 'Periferia Attikis'),
(58, 'Peloponnisos'),
(59, 'Voreio Aigaio'),
(60, 'Notio Aigaio'),
(61, 'Kriti');

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `rantevou`
--

CREATE TABLE IF NOT EXISTS `rantevou` (
  `rant_id` int(11) NOT NULL AUTO_INCREMENT,
  `p_id` int(11) NOT NULL,
  `ait_id` int(11) NOT NULL,
  `Thema` varchar(350) NOT NULL,
  `Hmerominia` datetime NOT NULL,
  `Krisimotita` int(11) NOT NULL,
  `Sxolia` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`rant_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=36 ;

--
-- Άδειασμα δεδομένων του πίνακα `rantevou`
--

INSERT INTO `rantevou` (`rant_id`, `p_id`, `ait_id`, `Thema`, `Hmerominia`, `Krisimotita`, `Sxolia`) VALUES
(35, 41, 6, 'rant1', '2014-09-02 00:00:00', 1, '');

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `settings`
--

CREATE TABLE IF NOT EXISTS `settings` (
  `s_id` int(11) NOT NULL AUTO_INCREMENT,
  `email_username` varchar(250) NOT NULL,
  `email_password` varchar(250) NOT NULL,
  `email_host` varchar(255) NOT NULL,
  `email_from` varchar(250) NOT NULL,
  PRIMARY KEY (`s_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=greek AUTO_INCREMENT=2 ;

--
-- Άδειασμα δεδομένων του πίνακα `settings`
--

INSERT INTO `settings` (`s_id`, `email_username`, `email_password`, `email_host`, `email_from`) VALUES
(1, 'bampis.s', 'mpampinos3200!', 'smtp.gmail.com', 'bampis.s@gmail.com');

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `settings_minimata`
--

CREATE TABLE IF NOT EXISTS `settings_minimata` (
  `s_minimata_id` int(11) NOT NULL AUTO_INCREMENT,
  `eortazontesThema` varchar(255) NOT NULL,
  `eortazontesMinima` varchar(255) NOT NULL,
  `aporifthikanThema` varchar(255) NOT NULL,
  `aporifthikanMinima` varchar(255) NOT NULL,
  `oloklirothikanThema` varchar(255) NOT NULL,
  `oloklirothikanMinima` varchar(255) NOT NULL,
  PRIMARY KEY (`s_minimata_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Άδειασμα δεδομένων του πίνακα `settings_minimata`
--

INSERT INTO `settings_minimata` (`s_minimata_id`, `eortazontesThema`, `eortazontesMinima`, `aporifthikanThema`, `aporifthikanMinima`, `oloklirothikanThema`, `oloklirothikanMinima`) VALUES
(1, 'Χρόνια Πολλά', 'Χρόνια πολλά!Να χαίρεσαι την ονομαστική σου εορτή!', 'Το αίτημά σας εγκρίθηκε', 'Το αίτημά σας εγκρίθηκε, παρακαλώ επικοινωνίστε μαζί μας για λεπτομέριες.', 'Το αίτημά σας απορριφθηκε', 'Το αίτημά σας απορριφθηκε, παρακαλώ επικοινωνίστε μαζί μας για λεπτομέριες.');

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `users`
--

CREATE TABLE IF NOT EXISTS `users` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `remember_token` varchar(100) COLLATE utf8_unicode_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `updated_at` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`id`),
  UNIQUE KEY `users_email_unique` (`email`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci AUTO_INCREMENT=3 ;

--
-- Άδειασμα δεδομένων του πίνακα `users`
--

INSERT INTO `users` (`id`, `username`, `email`, `password`, `remember_token`, `created_at`, `updated_at`) VALUES
(1, 'admin', 'adminSite@gmail.com', '$2y$10$Q4TyiL3RwinnEV6oN7hJDe8RXkwXBalsATDyA9eM2etIjBdRDMy0a', 'awD21D0KT2iS4sGRS6nkvmmZNGTmSVQOJJVwyN5JH5FB5pY4HJOY59LVbGnh', '0000-00-00 00:00:00', '0000-00-00 00:00:00'),
(2, 'admin', 'admin@gmail.com', 'admin', '', '0000-00-00 00:00:00', '0000-00-00 00:00:00');

-- --------------------------------------------------------

--
-- Δομή πίνακα για τον πίνακα `usersp`
--

CREATE TABLE IF NOT EXISTS `usersp` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(200) NOT NULL,
  `password` varchar(200) NOT NULL,
  `email` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=greek AUTO_INCREMENT=2 ;

--
-- Άδειασμα δεδομένων του πίνακα `usersp`
--

INSERT INTO `usersp` (`id`, `username`, `password`, `email`) VALUES
(1, 'admin', 'admin', 'admin@gmail.com');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
