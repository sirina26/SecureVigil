create procedure securevigil.sMissionDelete
(
    @MissionId int
)
as
begin
set transaction isolation level serializable;
	begin tran;

	if not exists(select * from securevigil.tMission s where s.MissionId = @MissionId)
	begin
		rollback;
		return 1;
	end;

    delete from securevigil.tMission where MissionId = @MissionId;

	commit;
    return 0;
end;
