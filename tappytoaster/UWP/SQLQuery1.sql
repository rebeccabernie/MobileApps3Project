
IF NOT EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'HighScores' )        
CREATE TABLE HighScores   
(   
  UserID int identity(1,1), 
   Username VARCHAR(100)  NOT NULL , 
   Score VARCHAR(100)  NOT NULL
CONSTRAINT [PK_HighScores] PRIMARY KEY CLUSTERED         
(        
  UserID ASC   
    
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]        
) ON [PRIMARY]      
 
 Insert into HotelMaster() Values('101','Single','50$')
  Insert into HotelMaster(RoomNo,RoomType,Prize) Values('102','Double','80$')
   
select * from HotelMaster 