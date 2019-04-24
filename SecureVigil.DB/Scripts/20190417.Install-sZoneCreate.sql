create procedure securevigil.sZoneCreate
(
    @ZoneName nvarchar (30),
    @ZoneAdresse nvarchar (30),
    @Longitude float,
    @Latitude float,
    @ZoneId int out,
    @ContratId int out
)
as
begin
    set transaction isolation level serializable;
    begin tran;

    insert into securevigil.tZone
                (ZoneId, ContratId, ZoneName, ZoneAdresse, Longitude, Latitude)
    values
                (@ZoneId, @ContratId, @ZoneName, @ZoneAdresse, @Longitude, @Latitude);

                set @ZoneId = scope_identity();

    commit;
        return 0;
end;
