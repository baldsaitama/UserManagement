Drop Table pl_users;
Create Table pl_users (user_id int Primary Key identity,
name varchar(50) not null, phone varchar(10) not null, email nvarchar(30) not null,
address varchar(30), join_date DateTime, 
gender varchar(10) not null, username varchar(25) not null unique, password nvarchar(20) not null,
fk_role_id int foreign key references pl_roles(role_id), 
fk_dept_id int foreign key references pl_departments(dept_id),
fk_desig_id int foreign key references pl_designations(desig_id)
);
Drop Table pl_designations;
create table pl_designations(desig_id int primary key identity, desig_name varchar(50), description varchar(200) );

select * from pl_users