CREATE DATABASE `persons_db`;

-- persons_db.person definition

CREATE TABLE `person` (
  `person_id` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(128) NOT NULL,
  `surname` varchar(128) NOT NULL,
  `document_number` varchar(25) NOT NULL,
  `document_type` varchar(2) NOT NULL,
  `email` varchar(128) NOT NULL,
  `document_full` varchar(27) GENERATED ALWAYS AS (concat(`document_type`,_utf8mb4' ',`document_number`)) VIRTUAL,
  `name_full` varchar(256) GENERATED ALWAYS AS (concat(`name`,_utf8mb4' ',`surname`)) VIRTUAL,
  `creation` datetime(3) NOT NULL,
  PRIMARY KEY (`person_id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- persons_db.`user` definition

CREATE TABLE `user` (
  `user_id` bigint NOT NULL,
  `login` varchar(25) NOT NULL,
  `pass` varchar(25) NOT NULL,
  `creation` datetime(3) NOT NULL,
  PRIMARY KEY (`user_id`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `person` (`person_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;