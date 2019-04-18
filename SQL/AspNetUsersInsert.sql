insert into aspnetusers(email,emailconfirmed,passwordhash,securitystamp,
phonenumber,phonenumberconfirmed,twofactorenabled,lockoutenddateutc,
lockoutenabled,accessfailedcount,username) values("a.b@art.com", 1 ,null,null,null,
1,1,sysdate(),0,0,"SuperUser");
commit;

select * from aspnetusers

