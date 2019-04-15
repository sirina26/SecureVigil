create proc securevigil.sClientUpdate

(
    @FirstName nvarchar (30),
    @LastName nvarchar (30),
    @ClientPhone nvarchar (12),
    @ClientAdresse nvarchar (60),
    @ClientId   int
   
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

	if exists(select * from securevigil.tClient s where s.ClientId <> @ClientId)
	begin
		rollback;
		return 2;
	end;

	
	update securevigil.tClient
	set FirstName = @FirstName, LastName = @LastName, ClientPhone = @ClientPhone, ClientAdresse = @ClientAdresse
	where ClientId = @ClientId;

	
	commit;
    return 0;
end;
