create table securevigil.tMission
(
	MissionId int identity(0, 1),
	ZoneId int not null,
	VigilId int not null,
	BeginDate datetime2 not null,
	EndDate datetime2 not null,
	MissionRules nvarchar(100) not null,
	constraint PK_tMission primary key(MissionId),
    constraint FK_tMission_tZone foreign Key(ZoneId) references securevigil.tZone(ZoneId),
    constraint FK_tMission_tVigil foreign Key(VigilId) references securevigil.tVigil(VigilId)
);
insert into securevigil.tMission(ZoneId, VigilId, BeginDate, EndDate, MissionRules)
values ( 0, 0, '00010101'  ,'00010101',  N'');

