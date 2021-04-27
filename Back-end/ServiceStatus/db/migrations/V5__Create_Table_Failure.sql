CREATE TABLE IF NOT EXISTS `failure` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `date` DATE,
  `time` bigint(20) NOT NULL,
  `description` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
)