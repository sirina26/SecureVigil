create table securevigil.tUser
(
    UserId int identity(0, 1),
    Email  nvarchar(64) not null,

    constraint PK_tUser primary key(UserId),
    constraint UK_tUser_Email unique(Email)
);

insert into securevigil.tUser(Email) values(N'');
