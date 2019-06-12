create procedure securevigil.sMissionCreate
(
    @BeginDate DateTime,
    @EndDate DateTime,
    @MissionRules nvarchar (100),
    @ZoneId int,
    @MissionId int out
    
)
as
begin
    set transaction isolation level serializable;
    begin tran;

    insert into securevigil.tMission
                (ZoneId, BeginDate, EndDate, MissionRules)
    values
                (@ZoneId, @BeginDate, @EndDate, @MissionRules);

                set @MissionId = scope_identity();

    commit;
        return 0;
end;
