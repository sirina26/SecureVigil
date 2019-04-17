create proc securvigil.sZoneUpdate
(
    @ZoneName nvarchar (32),
    @ZoneAdresse nvarchar (32),
    @ZoneId int,
    @ContratId int
)
as
begin
    set transaction isolation level serialize;
    begin tran;

    if not exists(select * from securvigil.tZone z where z.ZoneId = @ZoneId)
    begin
        rollback;
        return 1;
    end;

    if exists( select * from securvigil.tZone z where z.ZoneId <> @ZoneId)
    begin
        rollback;
        return 2;
    end;

    update securvigil.tZone
    set ZoneName = @ZoneName, ZoneAdresse = @ZoneAdresse, ZoneLongitude = @ZoneLongitude, ZoneLatitude = @ZoneLatitude, ContratId = @ContratId
    where ZoneId = @ZoneId;

    commit;
    return 0;
end;
