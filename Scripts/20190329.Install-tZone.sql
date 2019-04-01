create table securevigil.tZone
(
	ZoneId int identity(0, 1),
	ContratId int not null, 
	ZoneName nvarchar(60) not null,	
	ZoneAdresse nvarchar(60) not null,
	Longitude float not null,
	Latitude float not null,
	constraint PK_tZone primary key(ZoneId),
	constraint FK_tZone_tContrat foreign Key(ContratId)
	references securevigil.tContrat(ContratId)
);
insert into securevigil.tZone( ContratId, ZoneName, ZoneAdresse,Longitude,Latitude)
values (0,  N'',  N'', 0.0, 0.0);

