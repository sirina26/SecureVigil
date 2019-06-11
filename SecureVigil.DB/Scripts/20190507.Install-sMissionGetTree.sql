create proc securevigil.sMissionGetTree
(
    @Json nvarchar(max) out
)
as
begin
set @Json = (select clientId = clients.ClientId,
                clientFirstName = clients.FirstName,
                clientLastName = clients.LastName,
                contractId = contracts.ContratId,
                contractBeginDate = contracts.BeginDate,
                contractEndDate = contracts.EndDate,
                zoneId = zones.ZoneId,
                zoneName = zones.ZoneName,
                zoneAddress = zones.ZoneAdresse,
                nbrAgentJour = zones.NbrAgentJour,
                nbrAgentNuit = zones.NbrAgentNuit,
                nbrChienJour = zones.NbrChienJour,
                nbrChienNuit = zones.NbrChienNuit,
                missionId = missions.MissionId,
                missionBeginDate = missions.BeginDate,
                missionEndDate = missions.EndDate,
                missionRules = missions.MissionRules
             from securevigil.tClient clients
                left join securevigil.tContrat contracts on contracts.ClientId = clients.ClientId			
                left join securevigil.tZone zones on zones.ContratId = contracts.ContratId
                left join securevigil.tMission missions on missions.ZoneId = zones.ZoneId

             where clients.ClientId <> 0
             for json auto);
    return 0;
end;
