create procedure securevigil.sVigilCreate
(
                        
    @FirstName nvarchar (30),
    @LastName nvarchar (30),
    @BeginDate dateTime2,
    @EndDate dateTime2,
    @TallyBegin dateTime2,
    @TallyEnd datetime2,
    @StatePlanning bit,
    @VigilId   int out
)
as
begin
    set transaction isolation level serializable;
	begin tran;

	insert into securevigil.tVigil
                   (FirstName, LastName,
                    BeginDate, EndDate,
                    TallyBegin, TallyEnd,
                    StatePlanning)
        values
                    (@FirstName, @LastName,
                    @BeginDate, @EndDate,
                    @TallyBegin, @TallyEnd,
                    @StatePlanning);

                    set @VigilId = scope_identity();
    commit;
	return 0;
end;
