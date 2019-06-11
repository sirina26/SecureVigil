create table securevigil.tVigil
(
	VigilId int identity(0, 1),
    FirstName nvarchar (30) not null,
    LastName nvarchar (30) not null,
    BeginDate datetime2 not null,
	EndDate datetime2 not null,
	StatePlanning bit,
    --pointage
    TallyBegin datetime2 not null,
    TallyEnd datetime2 not null,

	constraint PK_tVigil primary key(VigilId),
);
insert into securevigil.tVigil(FirstName, LastName, BeginDate, EndDate, StatePlanning,TallyBegin,TallyEnd )
values (N'', N'', '00010101', '00010101', 0, '00010101','00010101');

