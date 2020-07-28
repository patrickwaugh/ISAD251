CREATE TABLE [dbo].[Appointment] (
    ApptID INT IDENTITY(1,1),
    ApptTitle VARCHAR(20) NOT NULL,
    ApptDate DATETIME NOT NULL,
    ApptLocation VARCHAR(20),
    ApptDuration TIME,
    ApptNotes VARCHAR(120),
    UserID INT NOT NULL,
    CONSTRAINT FK_Appointment FOREIGN KEY (UserID) REFERENCES [User](UserID),
    PRIMARY KEY (ApptID)

)
