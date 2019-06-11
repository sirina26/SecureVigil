create table securevigil.tZone
(
	ZoneId int identity(0, 1),
	ContratId int not null, 
	ZoneName nvarchar(60) not null,	
	ZoneAdresse nvarchar(60) not null,
	NbrAgentJour int not null,
	NbrAgentNuit int not null,
	NbrChienJour int not null,
	NbrChienNuit int not null,
	constraint PK_tZone primary key(ZoneId),
	constraint FK_tZone_tContrat foreign Key(ContratId)
	references securevigil.tContrat(ContratId)
);
insert into securevigil.tZone( ContratId, ZoneName, ZoneAdresse,NbrAgentJour,NbrAgentNuit, NbrChienJour, NbrChienNuit)
values (0,  N'',  N'', 0, 0, 0, 0);

