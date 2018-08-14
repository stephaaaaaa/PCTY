Use PCTYBenefitsData;

Create table Employee(
id int primary key auto_increment,
employeeNumber int,
firstName varchar(100) not null,
lastName varchar(100) not null,
hasDependent bool not null,
cost double not null
);

Create table Dependent(
id int primary key auto_increment,
firstName varchar(100) not null,
lastName varchar(100) not null,
foreign key (id) references Employee(id),
cost double not null
);
