create proc sv.sZoneCreate
(
  @Name nvarchar(32),
  @ZoneId int out
)
as
begin
  set xact_abort on;
  set transaction isolation level serializable;
  begin tran;

  if exists(select * from sv.tZone z where z.[Name] = @Name)
  begin
    rollback;
    return 1;
  end;

  insert into sv.tZone([Name]) values(@Name);

  commit;
  return 0;
end;
