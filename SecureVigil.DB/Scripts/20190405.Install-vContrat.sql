create view securevigil.vContrat
as
select
    ContratId = t.ContratId,
    ClientId = t.ClientId,
    BeginDate = t.BeginDate,
    EndDate = t.EndDate

from securevigil.tContrat t;
