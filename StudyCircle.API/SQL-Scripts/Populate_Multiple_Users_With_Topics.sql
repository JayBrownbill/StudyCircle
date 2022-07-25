DECLARE 
@UserId_1 as UNIQUEIDENTIFIER = NEWID(),
@UserId_2 as UNIQUEIDENTIFIER = NEWID(),
@UserId_3 as UNIQUEIDENTIFIER = NEWID(),
@UserId_4 as UNIQUEIDENTIFIER = NEWID(),
@UserId_5 as UNIQUEIDENTIFIER = NEWID()

INSERT INTO Users
    (UserId, DisplayName,ProgressionMultiplier, Username, [Password])
VALUES(
        @UserId_1,
        'Rachel Studies',
        30,
        'Rachel',
        'pass1'
),
    (
        @UserId_2,
        'Jay Smart',
        100,
        'Jay',
        'pass2'
)
,
    (
        @UserId_3,
        'Han',
        60,
        'Hannah',
        'pass3'
)
,
    (
        @UserId_4,
        'Tormund Data',
        50,
        'TormundDA',
        'pass4'
)
,
    (
        @UserId_5,
        'Jack Online',
        10,
        'Jack Smith',
        'pass5'
)
INSERT INTO StudyTopic
    (StudyTopicId, UserId, Name)
VALUES
    (
        NEWID(),
        @UserId_1,
        'Mathematics'
),
    (
        NEWID(),
        @UserId_2,
        'Comp-Sci'
),
    (
        NEWID(),
        @UserId_3,
        'English'
),
    (
        NEWID(),
        @UserId_4,
        'Software Engineering'
),
    (
        NEWID(),
        @UserId_5,
        'Farming'
)