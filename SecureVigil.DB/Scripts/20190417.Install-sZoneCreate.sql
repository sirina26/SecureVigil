create procedure securevigil.sZoneCreate
(
    @ZoneName nvarchar (30),
    @ZoneAdresse nvarchar (30),
    @ZoneLongitude nvarchar (30),
    @ZoneLatitude nvarchar (30),
    @ZoneId int out,
    @ContratId int out
)
as
begin
    set transaction isolation level serializable;
    begin tran;

    insert into securevigil.tZone
                (ZoneId, ContratId, ZoneName, ZoneAdresse)
    values
                (@ZoneId, @ContratId, @ZoneName, @ZoneAdresse);

                set @ZoneId = scope_identity();

    commit;
        return 0;
end;
