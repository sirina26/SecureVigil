create table securevigil.tVigil
(
	VigilId int identity(0, 1),
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	Phone nvarchar(12) not null,
	Adresse nvarchar(100) not null,
	constraint PK_tVigil primary key(VigilId)
);
insert into securevigil.tVigil(
        FirstName, LastName, Phone, Adresse)
        values
         ( N'',      N'',		 N'',
            N'');



