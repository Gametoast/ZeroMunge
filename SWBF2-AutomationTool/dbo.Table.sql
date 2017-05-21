CREATE TABLE [dbo].[Table]
(
	[Process] TEXT NOT NULL PRIMARY KEY , 
    [Copy] TEXT NOT NULL, 
    [FilePath] TEXT NULL, 
    [StagingDir] TEXT NULL, 
    [MungeDir] TEXT NULL, 
    [MungedFiles] TEXT NULL, 
    [IsMunge] TEXT NOT NULL, 
    [IsValid] TEXT NOT NULL
)
