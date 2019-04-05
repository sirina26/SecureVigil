create view securevigil.vClient
as
select
    ClientId = t.ClientId,
    FirstName = t.FirstName,
    LastName = t.LastName,
    ClientPhone = t.ClientPhone,
    ClientAdresse = t.ClientAdresse

from securevigil.tClient t;
