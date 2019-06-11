create procedure securevigil.sContratCreate
(
    @BeginDate DateTime,
    @EndDate DateTime,
    @ClientId int,
    @ContratId int out
)
as
begin
    set transaction isolation level serializable;
    begin tran;

    insert into securevigil.tContrat
                ( ClientId, BeginDate, EndDate)
    values
                ( @ClientId, @BeginDate, @EndDate);

                set @ContratId = scope_identity();

    commit;
        return 0;
end;
