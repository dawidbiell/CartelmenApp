
select *
from Person as p 
left join dbo.SpotPerson SP on p.Id = SP.PersonId
where SP.PersonId IS NULL;