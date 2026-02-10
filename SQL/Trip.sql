select * From Activity where TripId=21

select * from TRip where id=21
Select * from Itinerary
select * From dbo.[User];

delete from itinerary where tripId=21;


-- Insert Data for Trip 1 (Paris)
INSERT INTO Trip
    ( Destination, StartDate, EndDate, OwnerId, ParticipantsId, IsVotingOpen)
VALUES
    ( 'Paris', '2025-06-01', '2025-06-10', 1, '[12,3,4]', 1);


-- Insert Data for Trip 2 (Tokyo)
INSERT INTO Trip
    ( Destination, StartDate, EndDate, OwnerId, ParticipantsId, IsVotingOpen)
VALUES
    ( 'Tokyo', '2025-09-15', '2025-09-25', 2, '[13,5]', 1);

-- Insert Data for Trip 3 (New York)
INSERT INTO Trip
    ( Destination, StartDate, EndDate, OwnerId, ParticipantsId, IsVotingOpen)
VALUES
    ( 'New York', '2025-04-20', '2025-04-27', 3, '[11,2]', 1);

-- Insert Data for Trip 4 (Reykjavik)
INSERT INTO Trip
    ( Destination, StartDate, EndDate, OwnerId, ParticipantsId, IsVotingOpen)
VALUES
    ( 'Reykjavik', '2025-12-01', '2025-12-08', 4, '[1,2,4]', 0);


-- Insert Data for Trip 5 (Rome)
INSERT INTO Trip
    ( Destination, StartDate, EndDate, OwnerId, ParticipantsId, IsVotingOpen)
VALUES
    ( 'Rome', '2025-07-05', '2025-07-12', 5, '[2,3]', 1);

select * from Activity where tripId=21;

delete from Activity where id between 98 and 100;
   
    delete from itinerary where tripId=21;
    Update trip set isVotingOpen=1 where id=21;
    select * from trip where id=21;



select * from itinerary where tripId=21


select * from notification

Select * from [User]

INSERT INTO Trip (Destination, StartDate, EndDate, OwnerId, ParticipantsId, isVotingOpen)
VALUES
('Italy', '2025-06-10', '2025-06-20', 11, '[12,3,4,5,25,6,13,16,14,23,31]', 1);

select * from trip where ownerId=1



UPDATE Trip
SET OwnerId = 44
WHERE Id = 166;

INSERT INTO Trip (Destination, StartDate, EndDate, OwnerId, ParticipantsId, isVotingOpen)
VALUES
('Japan', '2025-09-05', '2025-09-18', 44, '[12,6,5,3,8,10]', 1),

('Iceland', '2025-12-01', '2025-12-10', 44, '[5,6,7,8,3,14]', 1),

('Thailand', '2026-01-15', '2026-01-30', 44, '[25,3,4,5,6,7,8,9]', 1),

('Canada - Rockies', '2025-07-20', '2025-07-29', 44, '[14,13,6,3,23]', 1);

INSERT INTO Trip (Destination, StartDate, EndDate, OwnerId, ParticipantsId, isVotingOpen)
VALUES
('Spain - Andalusia', '2025-10-05', '2025-10-18', 3, '[3,5,6,8,10,14,44]', 1);


select * from trip

INSERT INTO Trip (Destination, StartDate, EndDate, OwnerId, ParticipantsId, isVotingOpen)
VALUES
('Spain - Andalusia', '2025-10-05', '2025-10-18', 44, '[3,5,6,8,10,14]', 1);


Select * from [User]


INSERT INTO Trip (Destination, StartDate, EndDate, OwnerId, ParticipantsId, isVotingOpen)
VALUES
('Portland', '2025-06-03', '2025-06-05', 44, '[7,6,9,5,12,3]', 1);

select * from trip where id =183

delete from [User] where id IN (82);

