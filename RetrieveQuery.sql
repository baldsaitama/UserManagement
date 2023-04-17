select u.name as Name, u.gender as Gender,u.address as Address, u.phone as Phone_Number,u.email as Email,u.join_date as Join_Date,
p.desig_name as Designation, r.name as Role, dept_name as Department 
from pl_users as u 
inner join pl_roles as r 
on u.fk_role_id = r.role_id
inner join pl_designations p 
on u.fk_desig_id = p.desig_id
inner join pl_departments d
on u.fk_dept_id = d.dept_id

select * from pl_designations
select * from pl_roles
select * from pl_departments
