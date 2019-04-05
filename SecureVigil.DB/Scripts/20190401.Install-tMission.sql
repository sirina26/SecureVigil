create table securevigil.tMission
(
	MissionId int identity(0, 1),
	ZoneId int not null,
	BeginDate datetime2 not null,
	EndDate datetime2 not null,
	MissionRules nvarchar(max) not null,
	constraint PK_tMission primary key(MissionId),
	constraint FK_tMission_tZone foreign Key(ZoneId)
	references securevigil.tZone(ZoneId)
);
insert into securevigil.tMission(ZoneId, BeginDate, EndDate, MissionRules)
values (0,  '00010101'  ,'00010101',  N'');

