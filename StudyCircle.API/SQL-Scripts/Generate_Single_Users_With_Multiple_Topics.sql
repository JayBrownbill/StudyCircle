DECLARE @UserId as UNIQUEIDENTIFIER = NEWID()
DECLARE @DateTimeFormatted as VARCHAR(25) = CONVERT(VARCHAR(25), GETDATE(), 127)
DECLARE @DynamicUsrname as NVARCHAR(MAX) = CONCAT('GeneratedUSER', '__', @DateTimeFormatted)

DECLARE @StudyId1 as UNIQUEIDENTIFIER = NEWID()
DECLARE @StudyId2 as UNIQUEIDENTIFIER = NEWID()
DECLARE @StudyId3 as UNIQUEIDENTIFIER = NEWID()

INSERT INTO Users
    (UserId, Username, DisplayName, [Password], ProgressionMultiplier)
VALUES(
        @UserId,
        @DynamicUsrname,
        @DynamicUsrname,
        '123',
        900
)

INSERT INTO StudyTopic
    (StudyTopicId, Name, UserId)
VALUES(
        @StudyId1,
        CONCAT('Subject','__',CAST(@StudyId1 as varchar(50))),
        @UserId
),
    (
        @StudyId2,
        CONCAT('Subject','__',CAST(@StudyId2 as varchar(50))),
        @UserId
),
    (
        @StudyId3,
        CONCAT('Subject','__',CAST(@StudyId3 as varchar(50))),
        @UserId
)

