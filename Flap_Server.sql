-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Nov 26, 2024 at 01:18 PM
-- Server version: 8.0.35
-- PHP Version: 8.2.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `Flap_Server`
--

-- --------------------------------------------------------

--
-- Table structure for table `achievement`
--

CREATE TABLE `achievement` (
  `achievement_id` int NOT NULL,
  `achievement_name` varchar(25) DEFAULT NULL,
  `achievement_description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `points` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `achievement`
--

INSERT INTO `achievement` (`achievement_id`, `achievement_name`, `achievement_description`, `points`) VALUES
(1, '2 Pointer', 'Earned by achieving 2 points', 2),
(2, '5 Pointer', 'Earned by achieving 5 points', 5),
(3, '7 Pointer', 'Earned by achieving 7 points', 7);

-- --------------------------------------------------------

--
-- Table structure for table `players`
--

CREATE TABLE `players` (
  `id` int NOT NULL,
  `username` varchar(25) NOT NULL,
  `hash` varchar(255) NOT NULL,
  `salt` varchar(255) NOT NULL,
  `high_score` int NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `players`
--

INSERT INTO `players` (`id`, `username`, `hash`, `salt`, `high_score`) VALUES
(22, 'Rithvikm', '$5$rounds=5000$steamedhamsRithv$oMWG5nCRGxkRPO9xbVBxaFRX0DLVAwOGM26yZwZ7Gd8', '$5$rounds=5000$steamedhamsRithvikm$', 10),
(23, 'Reubenak', '$5$rounds=5000$steamedhamsReube$anoPlOX5VdXtAtET1JvEs6ApOhLHY/wQzQHCy5NJPO4', '$5$rounds=5000$steamedhamsReubenak$', 3),
(25, 'Player03', '$5$rounds=5000$steamedhamsPlaye$ycLJqSu2KfTCJv7cfLBp8LXMvhaTSUgn1uX.6jDIEPC', '$5$rounds=5000$steamedhamsPlayer03$', 0),
(28, 'Player04', '$5$rounds=5000$steamedhamsPlaye$Mo.gid.Vr.I6FnsPAX8PqZPC5ntFYLMBjbsaQ8aujR/', '$5$rounds=5000$steamedhamsPlayer04$', 0);

-- --------------------------------------------------------

--
-- Table structure for table `player_achievement`
--

CREATE TABLE `player_achievement` (
  `player_id` int NOT NULL,
  `achievement_id` int NOT NULL,
  `achievement_unlocked` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `player_achievement`
--

INSERT INTO `player_achievement` (`player_id`, `achievement_id`, `achievement_unlocked`) VALUES
(22, 1, '2024-11-13'),
(22, 2, '2024-11-13'),
(22, 3, '2024-11-16'),
(23, 1, '2024-11-13');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `achievement`
--
ALTER TABLE `achievement`
  ADD PRIMARY KEY (`achievement_id`);

--
-- Indexes for table `players`
--
ALTER TABLE `players`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `username` (`username`);

--
-- Indexes for table `player_achievement`
--
ALTER TABLE `player_achievement`
  ADD PRIMARY KEY (`player_id`,`achievement_id`),
  ADD KEY `Achievement` (`achievement_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `achievement`
--
ALTER TABLE `achievement`
  MODIFY `achievement_id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `players`
--
ALTER TABLE `players`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=31;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `player_achievement`
--
ALTER TABLE `player_achievement`
  ADD CONSTRAINT `Achievement` FOREIGN KEY (`achievement_id`) REFERENCES `achievement` (`achievement_id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  ADD CONSTRAINT `Player` FOREIGN KEY (`player_id`) REFERENCES `players` (`id`) ON DELETE CASCADE ON UPDATE RESTRICT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
