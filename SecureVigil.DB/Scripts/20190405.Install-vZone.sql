create view securevigil.vZone
as
select
    ZoneId = t.ZoneId,
    ContratId = t.ContratId,
    ZoneName = t.ZoneName,
    ZoneAdresse = t.ZoneAdresse,
    GeogCol1 = t.GeogCol1

from securevigil.tZone t;
