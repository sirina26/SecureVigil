create table securevigil.tClient
(
	ClientId int identity(0, 1),
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	ClientPhone nvarchar(12) not null,
	ClientAdresse nvarchar(100) not null,
	constraint PK_tClient primary key(ClientId)
);
insert into securevigil.tClient(
        FirstName, LastName, ClientPhone,
        ClientAdresse)
        values
        (   N'',      N'',		 N'',
            N'');
			


