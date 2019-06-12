create procedure securevigil.sVigilCreate
(
                        
    @FirstName nvarchar (30),
    @LastName nvarchar (30),
    @Phone nvarchar (12),
    @Adresse nvarchar (100),
    @VigilId   int out
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	insert into securevigil.tVigil
                   (FirstName, LastName,
                    Phone, Adresse)
        values
                    (@FirstName, @LastName,
                    @Phone,@Adresse);

                    set @VigilId = scope_identity();
    commit;
	return 0;
end;
