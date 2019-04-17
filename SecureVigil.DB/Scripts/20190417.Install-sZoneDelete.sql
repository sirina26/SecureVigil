create proc securvigil.sZoneDelete
(
    @ZoneId int
)
as
begin
    set transaction isolation level serialize;
    begin tran

    if not exists(select * from securvigil.tZone z where z.ZoneId = @ZoneId)
    begin
        rollback;
        return 1;
    end;

    delete from securvigil.tZone where ZoneId = @ZoneId;

    commit;
    return 0;

end;
