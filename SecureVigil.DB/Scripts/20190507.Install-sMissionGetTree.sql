create proc securevigil.sMissionGetTree
(
    @Json nvarchar(max) out
)
as
begin
set @Json = (select
                clientId = clients.ClientId,
                clientFirstName = clients.FirstName,
                clientLastName = clients.LastName,
                contractId = contracts.ContratId,
                contractBeginDate = contracts.BeginDate,
                contractEndDate = contracts.EndDate,
                zoneId = zones.ZoneId,
                zoneName = zones.ZoneName,
                zoneAddress = zones.ZoneAdresse,
                missionId = missions.MissionId,
                missionBeginDate = missions.BeginDate,
                missionEndDate = missions.EndDate,
                missionRules = missions.MissionRules
             from securevigil.tMission missions
                inner join securevigil.tZone zones on zones.ZoneId = missions.ZoneId
                inner join securevigil.tContrat contracts on contracts.ContratId = zones.ContratId
                inner join securevigil.tClient clients on clients.ClientId = contracts.ClientId
             where missions.MissionId <> 0
             for json auto);
    return 0;
end;
