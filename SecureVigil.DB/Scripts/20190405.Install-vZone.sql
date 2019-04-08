create view securevigil.vZone
as
select
    ZoneId = t.ZoneId,
    ContratId = t.ContratId,
    ZoneName = t.ZoneName,
    ZoneAdresse = t.ZoneAdresse,
    Longitude = t.Longitude,
    Latitude = t.Latitude

from securevigil.tZone t;
