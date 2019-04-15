create table sv.tZone
(
  ZoneId int identity(0, 1),
  [Name] nvarchar(32) collate Latin1_General_100_CI_AS not null,

  constraint PK_sv_tZone primary key(ZoneId),
  constraint UK_sv_tZone_Name unique([Name])
);

insert into sv.tZone([Name]) values(N'');
