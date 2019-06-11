create procedure securevigil.sVigilCreate
(
                        
    @FirstName nvarchar (30),
    @LastName nvarchar (30),
    @BeginDate dateTime2,
    @EndDate dateTime2,    
    @VigilId   int out
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	insert into securevigil.tVigil
                   (FirstName, LastName,
                    BeginDate, EndDate)                    
        values
                    (@FirstName, @LastName,
                    @BeginDate, @EndDate);

                    set @VigilId = scope_identity();
    commit;
	return 0;
end;
