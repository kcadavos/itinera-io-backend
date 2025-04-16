select * From Trip;
select * From dbo.[User];

Update Trip set EndDate = '2025-06-02' where id=21;
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
