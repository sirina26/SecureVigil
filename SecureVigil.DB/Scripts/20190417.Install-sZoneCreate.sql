create procedure securevigil.sZoneCreate
(
    @ZoneName nvarchar (30),
    @ZoneAdresse nvarchar (30),
    @NbrAgentJour int,
    @NbrAgentNuit int,
    @NbrChienJour int,
    @NbrChienNuit int,
    @ContratId int,
    @ZoneId int out
)
as
begin
    set transaction isolation level serializable;
    begin tran;

    insert into securevigil.tZone
                (ContratId, ZoneName, ZoneAdresse, NbrAgentJour, NbrAgentNuit, NbrChienJour, NbrChienNuit)
    values
                ( @ContratId, @ZoneName, @ZoneAdresse, @NbrAgentJour, @NbrAgentNuit, @NbrChienJour, @NbrChienNuit);

                set @ZoneId = scope_identity();

    commit;
        return 0;
end;
