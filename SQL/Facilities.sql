create table Facilities
(
Id INT NOT NULL AUTO_INCREMENT,
Name nVARCHAR(64),
Address nvarchar(256),
Phone nvarchar(64),
City nvarchar(64),
Country nvarchar(128),
Zipcode nvarchar(32),
Courts int,
Lights bool,
CourtTypes nvarchar(64),
Description nvarchar(128),
Latitude float,
Longitude float,
PRIMARY KEY(Id)
);

update facilities set Latitude=40.7397,longitude=-73.8408 where ID=1;
insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude)
 values("Flushing Meadows - Public", "Flushing Bay", "718-760-6565","Queens,NY", "NY,USA", 
"11368", 52, 1, "All", "Largest facility in NY",40.7397,-73.8408);


insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude)
values("Central Park - Public", "Central Park, Manhattan", "212-316-0800","Manhattan,NY", "NY,USA", 
"10023", 30, 1, "All", "so and so, 4 hard + 26 clay",40.7711,-73.9742);



insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude)
values("Manhattan Plaza Racquet Club", "450 West 43rd Street", "212-594-0554","Manhattan,NY", "NY,USA", 
"10036", 5, 1, "Hard", "accessible by public transp",40.7599,-73.9943);


insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude) 
values("Roosevelt Island Racquet Club", "281 Main Street Roosevelt Island", 
"212-935-0250","Queens,NY", "NY,USA",  "10044",12, 1, "Hartru=green clay", "difficult parking",40.7566,-73.9545);


insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude)
values("CityView Racquet Club", "43-34 32nd Pl", "718-389-6252",
"Long Island City,NY", "NY,USA", "11101", 7, 1, "Hard", "modern and accessible but expensive",40.7455,-73.9327);


insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude)
values("Lincoln Park - Public", "Lincoln Park", "201-309-1424","Jersey City,NJ", "NJ,USA", 
" 07304", 21, 1, "Concrete", "Awesome public facility in Jersey city, very accessible",40.7244,-74.0866);

insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude)
values("Public Court nearby Med Center", "‎355 Grand Street", "","Jersey City,NJ", "NJ,USA", 
"07302", 1, 0, "Concrete", "Accessible, bad court quality",40.7166,-74.0499);

insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude)
values("Seton Park - Public", "Seton Park, ‎Independence Ave", "","Bronx,NY", "NY,USA", 
"10463", 6, 0, "Concrete", "Accessible by car",40.8859,-73.9165);

insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude)
values("West Side Tennis Club", "1 Tennis Pl, Forest Hills", "718-268-2300","Forest Hills,NY", "NY,USA", 
"11375", 15, 0, "Grass", "Oldest club in NY",40.7196,-73.8473);


insert into facilities(Name,Address,Phone,City, Country, ZipCode, Courts, Lights,CourtTypes,Description,Latitude, Longitude)
values("Astoria Park - Public", " 21st St, Astoria", "718-626-8622","Astoria,NY", "NY,USA", 
"11102", 14, 0, "Concrete", "Courts have some cracks",40.7797,-73.9216);


