create view SecureVigil.vUsers
as
    select UserId = u.UserId,
           Email = u.Email,         
           [Password] = case when p.[Password] is null then 0x else p.[Password] end
           
    from securevigil.tUser u
        left outer join securevigil.tPasswordUser p on p.UserId = u.UserId
    where u.UserId <> 0;
