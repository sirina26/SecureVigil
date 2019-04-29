Alter procedure securevigil.sContratCreate
(
    @BeginDate DateTime,
    @EndDate DateTime,
    @ContratId int out,
    @ClientId int out
)
as
begin
    set transaction isolation level serializable;
    begin tran;

    insert into securevigil.tContrat
                (ClientId, BeginDate, EndDate)
    values
                (@ClientId, @BeginDate, @EndDate);

                set @ContratId = scope_identity();

    commit;
        return 0;
end;
