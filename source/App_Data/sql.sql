create table myuser(uid int identity(1001,1) primary key,uname nvarchar(32),passwd varchar(32),umail varchar(60),utype int,status int)
create table myinfo(uid int primary key,uinfo varchar(60),sex varchar(2),avator ntext)
create table croom(rid int identity(1,1) primary key,r_owner varchar(32),r_count int,r_max int,r_announce nvarchar(max))
create table myfrd(uid int primary key,fid int)


