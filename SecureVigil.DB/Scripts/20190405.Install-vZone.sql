create view securevigil.vZone
as
select
    ZoneId = t.ZoneId,
    ContratId = t.ContratId,
    ZoneName = t.ZoneName,
    ZoneAdresse = t.ZoneAdresse,
    NbrAgentJour = t.NbrAgentJour,
    NbrAgentNuit = t.NbrAgentNuit,
    NbrChienJour = t.NbrChienJour,
    NbrChienNuit = t.NbrChienNuit

from securevigil.tZone t;
