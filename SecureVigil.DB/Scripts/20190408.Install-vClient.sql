create view securevigil.vClient
as
select
    ClientId = t.ClientId,
    FirstName = t.FirstName,
    LastName = t.LastName,
    ClientPhone = t.ClientPhone,
    ClientAdresse = t.ClientAdresse,
    contrat.Number

from securevigil.tClient  t 


inner join (
	select 
		Number = count( *), 
		ClientId 
	from securevigil.vContrat c 
	group by ClientId
) contrat on contrat.ClientId = t.ClientId;

