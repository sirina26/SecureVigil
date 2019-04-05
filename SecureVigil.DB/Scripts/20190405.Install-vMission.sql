create view securevigil.vMission
as
select
    MissionId = t.MissionId,
    ZoneId = t.ZoneId,
    BeginDate = t.BeginDate,
    EndDate = t.EndDate,
    MissionRules = t.MissionRules

from securevigil.tMission t;
