create procedure securevigil.sZoneCreate
(
    @ZoneName nvarchar (30),
    @ZoneAdresse nvarchar (30),
    @GeogCol1 geography,
    @ZoneId int out,
    @ContratId int out
)
as
begin
    set transaction isolation level serializable;
    begin tran;

    insert into securevigil.tZone
       (ZoneId, ContratId, ZoneName, ZoneAdresse, GeogCol1)
    values
       (@ZoneId, @ContratId, @ZoneName, @ZoneAdresse, @GeogCol1)
       set @ZoneId = scope_identity();
    commit;
        return 0;
end;
