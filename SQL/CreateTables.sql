Create Table Clients
(
 Id int not null AUTO_INCREMENT,
 Secret nvarchar(128),
 Name nvarchar(64),
 ApplicationType int,
 Active bool,
 RefreshTokenLifetime int,
 AllowedOrigin nvarchar(128),
 PRIMARY KEY(Id)
);


Create Table AspNetRoles
(
Id int not null AUTO_INCREMENT,
Name nvarchar(128),
PRIMARY KEY(Id)
);


Create Table AspNetUserRoles
(
UserId int not null AUTO_INCREMENT,
RoleId int not null,
PRIMARY KEY(UserId)
);


Create Table AspNetUsers
(
  Id int not null AUTO_INCREMENT,
Email nvarchar(256),
EmailConfirmed bool,
PasswordHash nvarchar(128),
SecurityStamp nvarchar(256),
PhoneNumber nvarchar(64),
PhoneNumberConfirmed bool,
TwoFactorEnabled bool,
LockoutEndDateUtc datetime,
LockoutEnabled bool,
AccessFailedCount int,
UserName nvarchar(256),
PRIMARY KEY(Id)
);

Create Table AspNetUserClaims
( Id int not null AUTO_INCREMENT,
  UserId int not null,
  ClaimId int not null,
  PRIMARY KEY(Id)
);


Create Table MenuAuthorizations
(
Id int not null AUTO_INCREMENT,
MenuId int not null,
RoleId int not null,
PRIMARY KEY(Id)
);

Create Table MenuItems
(
Id int not null AUTO_INCREMENT,
MenuItem nvarchar(128),
PRIMARY KEY(Id)
);

Create Table RoleClaims
(
Id int not null AUTO_INCREMENT,
RoleId int not null,
ClaimId int not null,
PRIMARY KEY(Id)
);

Create Table Claims
(
Id int not null AUTO_INCREMENT,
Claim nvarchar(128),
PRIMARY KEY(Id)
);


