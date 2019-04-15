create procedure securevigil.sClientCreate
(
                        
    @FirstName nvarchar (30),
    @LastName nvarchar (30),
    @ClientPhone nvarchar (12),
    @ClientAdresse nvarchar (60),
    @ClientId   int out
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	insert into securevigil.tClient
                   (ClientId, FirstName, LastName,
                    ClientPhone, ClientAdresse)
        values
                    (@ClientId,@FirstName,@LastName,
                    @ClientPhone,@ClientAdresse);

                    set @ClientId = scope_identity();
    commit;
	return 0;
end;