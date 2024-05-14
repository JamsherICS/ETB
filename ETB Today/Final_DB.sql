
create database Emp_travel_booking_system

use Emp_travel_booking_system

-- employees table to store information about employees
create table employees (
    employeeid int primary key identity (100,1),
    emp_name varchar(50),
	email varchar(50),
	emp_password varchar(50),
    department varchar(50),
	position varchar(50),
	hiredate date,
    phonenumber varchar(20),
    address varchar(255),
	managerid int,
	status bit,
	foreign key (managerid) references managers(managerid) -- Reference to the managers table
)
update employees set status = 1 where employeeid = 100
update employees set status = 1 where employeeid = 101

select * from employees


-- managers table to store information about managers
create table managers (
    managerid int primary key identity (100,1),
    name varchar(50),
    department varchar(50),
    email varchar(50),
	mgr_password varchar(50),
	status bit,

)

INSERT INTO managers (name, department, email, mgr_password, status)
VALUES 
    ('John Doe', 'HR', 'manager1@example.com', 'password', 1),
    ('Jane Smith', 'Finance', 'manager2@example.com', 'password', 0),
    ('Michael Johnson', 'IT', 'manager3@example.com', 'password', 1);

-- admins table to store information about administrators
create table admins (
    adminid int primary key,
    name varchar(100),
    email varchar(100),
	admin_password varchar(50),
)

insert into admins values
(1,'James','admin@gmail.com','password')

-- travel agents table to store information about travel agents
create table travelagents (
    agentid int primary key,
    name varchar(100),
    email varchar(100),
	travel_agent_password varchar(50),
	status bit,
)
INSERT INTO travelagents (agentid, name, email, travel_agent_password, status)
VALUES 
    (1001, 'John Doe', 'agent@example.com', 'password', 1),
    (2003, 'Jane Smith', 'agent2@example.com', 'password', 0),
    (3004, 'Michael Johnson', 'agent3@example.com', 'password', 1),
    (4005, 'Emily Brown', 'agent4@example.com', 'password', 0);

	select * from travelagents

-- travelrequests table to store travel requests submitted by employees
create table travelrequest (
    requestid int primary key IDENTITY(700,1),
    employeename varchar(100),
    employeeemail varchar(100),
    employeeid int,
    reasonfortravel varchar(255),
    flightneeded varchar(10),
    hotelneeded varchar(10),
    departurecity varchar(100),
    arrivalcity varchar(100),
    departuredate date,
    departuretime time,
    additionalinformation text,
	bookingstatus varchar(50) DEFAULT 'Pending' check (bookingstatus IN ('Confirmed', 'Not available', 'Pending')), -- Restriction on status
	approvalstatus VARCHAR(50) DEFAULT 'Pending' CHECK (approvalstatus IN ('Approved', 'Rejected','Pending', 'Cancelled')),
	foreign key (employeeid) references employees(employeeid)
)

update travelrequest set bookingstatus = 'Not available' where  requestid = 709
update travelrequest set approvalstatus = 'Approved' where  requestid = 711


select * from travelrequest
select * from employees



INSERT INTO travelrequest (employeename, employeeemail, employeeid, reasonfortravel, flightneeded, hotelneeded, departurecity, arrivalcity, departuredate, departuretime, additionalinformation)
VALUES
    ('John Doe', 'john@example.com', 101, 'Vacation', 'Yes', 'No', 'City A', 'City B', '2024-05-10', '10:00:00', 'Some additional info');


select * from travelrequest
select * from Employees


update travelagents set status = 1 where agentid = 101 


select * from admins
select * from travelagents
select * from travelrequest
select * from managers
select * from bookingstatus

select * from travelrequest
select * from employees


-- Insert dummy data into the managers table

-- Insert dummy data into the employees table
INSERT INTO employees (emp_name, email, emp_password, department, position, hiredate, phonenumber, address, managerid)
VALUES
    ('John Doe', 'john@example.com', 'password', 'Engineering', 'Software Engineer', '2024-01-01', '123-456-7890', '123 Main St', 100), -- Assuming managerid 101 exists
    ('Jane Smith', 'jane@example.com', 'password', 'Marketing', 'Marketing Manager', '2023-12-15', '987-654-3210', '456 Elm St', 101); -- Assuming managerid 102 exists
