
CREATE TABLE [dbo].[Deadline] (
    DeadlineID INT NOT NULL,
    DeadlineTitle VARCHAR(20) NOT NULL,
    DeadlineDate DATETIME NOT NULL,
    DeadlineNotes VARCHAR(120),
    IsCompleted BIT NOT NULL,
    UserID INT NOT NULL,
    CONSTRAINT FK_Deadline FOREIGN KEY (UserID) REFERENCES [User](UserID),
    PRIMARY KEY (DeadlineID)

)
