create view SecureVigil.vAuthenticationProvider
as
    select usr.UserId, usr.ProviderName
    from (select UserId = u.UserId,
              ProviderName = 'SecureVigil'
          from securevigil.tPasswordUser u
         ) usr
          where usr.UserId <> null;

