create table securevigil.tPlanning
(
	PlanningId int identity(0, 1),
	BeginDate datetime2 not null,
	EndDate datetime2 not null,
	StatePlanning bit,
    TallyBegin datetime2 not null,
    TallyEnd datetime2 not null,
	constraint PK_tPlanning primary key(PlanningId),
	constraint FK_tMission_tPlanning foreign Key(PlanningId)
	references securevigil.tPlanning(PlanningId)
);
insert into securevigil.tplanning(BeginDate, EndDate, StatePlanning, TallyBegin, TallyEnd)
values ('00010101'  ,'00010101',  0, '00010101', '00010101');

