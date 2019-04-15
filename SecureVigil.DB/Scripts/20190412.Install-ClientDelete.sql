create procedure securevigil.sClientDelete
(
    @ClientId int
)
as
begin
set transaction isolation level serializable;
	begin tran;

	if not exists(select * from securevigil.tClient s where s.ClientId = @ClientId)
	begin
		rollback;
		return 1;
	end;

    delete from securevigil.tClient where ClientId = @ClientId;

	commit;
    return 0;
end;
