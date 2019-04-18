DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_insert_reservation`(
IN courtId int,
IN priceId int,
IN userId int,
IN statusId int,
IN comments nvarchar(256),
IN startTime datetime,
IN endTime datetime,
IN facilityId int,
IN playersNo int,
IN slotNo int,
IN players nvarchar(256)
)
BEGIN

insert into Reservations(CourtId,PriceId,UserId,StatusId, Comments, StartTime, EndTime, FacilityId,PlayersNo, 
SlotNo, Players) 
values(courtId, priceId, userId, statusId,comments, startTime, endTime, facilityId, playersNo, slotNo, players);


END$$
DELIMITER ;
