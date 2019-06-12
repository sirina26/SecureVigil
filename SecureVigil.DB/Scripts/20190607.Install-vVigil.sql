create view securevigil.vVigil
as
select

    VigilId = t.VigilId,
    FirstName = t.FirstName,    
    LastName = t.LastName,
    Phone = t.Phone,
    Adresse = t.Adresse

from securevigil.tVigil t;
