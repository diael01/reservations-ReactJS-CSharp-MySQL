create table reservations
(
Id INT NOT NULL AUTO_INCREMENT,
CourtId int,
PriceId int,
UserId int,
StatusId int,
Comments nvarchar (256),
StartTime datetime,
EndTime datetime,
FacilityId int,
PlayersNo int,
SlotNo int,
Players nvarchar(256),
PRIMARY KEY(Id)
);




