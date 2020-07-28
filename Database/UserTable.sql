CREATE TABLE [dbo].[User] (
    UserID INT IDENTITY(1,1),
    UserName VARCHAR(20) NOT NULL,
    IsParent BIT NOT NULL,
    PRIMARY KEY (UserID)

)
