Create table securevigil.tZone
(
	ZoneId int identity(0, 1),
	ContratId int not null, 
	ZoneName nvarchar(60) not null,	
	ZoneAdresse nvarchar(60) not null,
	GeogCol1 geography not null,
	constraint PK_tZone primary key(ZoneId),
	constraint FK_tZone_tContrat foreign Key(ContratId)
	references securevigil.tContrat(ContratId)
);
insert into securevigil.tZone( ContratId, ZoneName, ZoneAdresse, GeogCol1)
values (0,  N'',  N'', geography::STGeomFromText('LINESTRING(-122.360 47.656, -122.343 47.656 )', 4326) );
