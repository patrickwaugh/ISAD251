CREATE TABLE [dbo].[User] (
    UserID INT NOT NULL,
    UserName VARCHAR(20) NOT NULL,
    IsParent BIT NOT NULL,
    PRIMARY KEY (UserID)

)
