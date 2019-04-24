create procedure securevigil.sMissionCreate
(
    @BeginDate DateTime,
    @EndDate DateTime,
    @MissionRules nvarchar (39),
    @MissionId int out,
    @ZoneId int out
)
as
begin
    set transaction isolation level serializable;
    begin tran;

    insert into securevigil.tMission
                (MissionId, ZoneId, BeginDate, EndDate, MissionRules)
    values
                (@MissionId, @ZoneId, @BeginDate, @EndDate, @MissionRules);

                set @MissionId = scope_identity();

    commit;
        return 0;
end;
