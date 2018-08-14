Use PCTYBenefitsData;

Create table Employee(
id int primary key auto_increment,
employeeNumber int,
lastName varchar(100) not null,
firstName varchar(100) not null,
-- number of dependents gets calculated
hasDependent bool not null,
cost double not null,
paycheckBeforeDeductions double not null,
deductionsPerPaycheck double not null,
paycheckAfterDeductions double not null
);

Create table Dependent(
id int primary key auto_increment,
firstName varchar(100) not null,
lastName varchar(100) not null,
foreign key (id) references Employee(id),
cost double not null
);
