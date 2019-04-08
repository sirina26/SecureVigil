create table securevigil.tContrat
(
	ContratId int identity(0, 1),
	ClientId int not null,
	BeginDate datetime2 not null,
	EndDate datetime2 not null,
	constraint PK_tContrat primary key(ContratId),
	constraint FK_tContrat_tClient foreign key(ClientId) 
	references securevigil.tClient(ClientId)

);
insert into securevigil.tContrat(
        ClientId, BeginDate, EndDate)
        values
        (  0,      '00010101'  ,'00010101');
			
