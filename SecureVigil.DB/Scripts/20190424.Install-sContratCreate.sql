create procedure securevigil.sContratCreate
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
                (ContratId, ClientId, BeginDate, EndDate)
    values
                (@ContratId, @ClientId, @BeginDate, @EndDate);

                set @ContratId = scope_identity();

    commit;
        return 0;
end;
