create view securevigil.vVigil
as
select

    VigilId = t.VigilId,
    FirstName = t.FirstName,    
    LastName = t.LastName,    
    BeginDate = t.BeginDate,
    EndDate  = t.EndDate,    
    TallyBegin = t.TallyBegin,    
    TallyEnd = t.TallyEnd 

from securevigil.tVigil t;
