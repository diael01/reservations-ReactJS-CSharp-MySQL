CREATE TABLE `reservationstatus` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='tables contining statuses for a reservation: free, reserved, pending, ingame, damaged, inrepair';

insert into reservationstatus(Status) values ("Empty");
insert into reservationstatus(Status) values ("Reserved");