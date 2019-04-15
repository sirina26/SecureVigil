create view sv.vZone
as
  select z.ZoneId, z.[Name]
  from sv.tZone z
  where z.ZoneId <> 0;
