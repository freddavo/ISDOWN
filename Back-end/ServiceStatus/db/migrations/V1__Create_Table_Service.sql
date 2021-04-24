CREATE TABLE IF NOT EXISTS `service` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `service_name` varchar(100) NOT NULL,
  `status` varchar(6) NOT NULL,
  PRIMARY KEY (`id`)
)