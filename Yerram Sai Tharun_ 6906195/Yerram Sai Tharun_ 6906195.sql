create database Asses1DB
use Asses1DB
create table Customers (
    CustomerID int identity primary key,
    CustomerName varchar(100),
    CustomerPhone varchar(20),
    CustomerCity varchar(50)
);

insert into Customers (CustomerName, CustomerPhone, CustomerCity)
values
('Ravi Kumar', '9876543210', 'Chennai'),
('Priya Sharma', '9123456789', 'Bangalore'),
('John Peter', '9988776655', 'Hyderabad');

select * from Customers


create table SalesPersons (
    SalesPersonID int identity primary key,
    SalesPersonName varchar(100)
);

insert into SalesPersons (SalesPersonName)
values
('Anitha'),
('Suresh');

select * from SalesPersons



create table Orders (
    OrderID int primary key,
    OrderDate date,
    CustomerID int,
    SalesPersonID int,
    foreign key (CustomerID) references Customers(CustomerID),
    foreign key (SalesPersonID) references SalesPersons(SalesPersonID)
);

insert into Orders (OrderID, OrderDate, CustomerID, SalesPersonID)
values
(101, '2024-01-05', 1, 1),
(102, '2024-01-06', 2, 1),
(103, '2024-01-10', 1, 2),
(104, '2024-02-01', 3, 1),
(105, '2024-02-10', 2, 2);

select * from Orders


create table Products (
    ProductID int identity primary key,
    ProductName varchar(100),
    UnitPrice decimal(10,2)
);

insert into Products (ProductName, UnitPrice)
values
('Laptop', 55000),
('Mouse', 500),
('Keyboard', 1500),
('Monitor', 12000);

select * from Products


create table OrderDetails (
    OrderDetailID int identity primary key,
    OrderID int,
    ProductID int,
    Quantity int,
    foreign key (OrderID) references Orders(OrderID),
    foreign key (ProductID) references Products(ProductID)
);

insert into OrderDetails (OrderID, ProductID, Quantity)
values
(101, 1, 1),  
(101, 2, 2),  

(102, 3, 1),  
(102, 2, 1),  

(103, 1, 1),  

(104, 4, 1),  
(104, 2, 1),  

(105, 1, 1),  
(105, 3, 1); 

select * from OrderDetails

select 
    o.OrderID,
    o.OrderDate,
    c.CustomerName,
    sp.SalesPersonName,
    p.ProductName,
    od.Quantity,
    p.UnitPrice,
    od.Quantity * p.UnitPrice as LineTotal
from Orders o
join Customers c on o.CustomerID = c.CustomerID
join SalesPersons sp on o.SalesPersonID = sp.SalesPersonID
join OrderDetails od on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID
order by o.OrderID;

select 
    o.OrderID,
    sum(od.Quantity * p.UnitPrice) as TotalSales
from Orders o
join OrderDetails od on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID
group by o.OrderID
order by TotalSales DESC;

WITH OrderTotals AS (
    SELECT 
        o.OrderID,
        SUM(od.Quantity * p.UnitPrice) AS TotalSales
    FROM Orders o
    JOIN OrderDetails od ON o.OrderID = od.OrderID
    JOIN Products p ON od.ProductID = p.ProductID
    GROUP BY o.OrderID
)
SELECT OrderID, TotalSales
from (
    select *,
           DENSE_RANK() over (ORDER BY TotalSales DESC) AS rnk
    from OrderTotals
) t
where rnk = 3;

select 
    sp.SalesPersonName,
    sum(od.Quantity * p.UnitPrice) as TotalSales
from SalesPersons sp
join Orders o on sp.SalesPersonID = o.SalesPersonID
join OrderDetails od on o.OrderID = od.OrderID
join Products p on od.ProductID = p.ProductID
group by sp.SalesPersonName
having sum(od.Quantity * p.UnitPrice) > 60000;

with CustomerTotals as (
select 
        c.CustomerName,
        sum(od.Quantity * p.UnitPrice) as TotalSpent
    from Customers c
    join Orders o on c.CustomerID = o.CustomerID
    join OrderDetails od on o.OrderID = od.OrderID
    join Products p on od.ProductID = p.ProductID
    group by c.CustomerName
)
select *
from CustomerTotals
where TotalSpent >
(
    select avg(TotalSpent) from CustomerTotals
);

select
    upper(c.CustomerName) as CustomerName,
    month(o.OrderDate) as OrderMonth,
    o.OrderDate
from Orders o
join Customers c on o.CustomerID = c.CustomerID
where 
    year(o.OrderDate) = 2024
    and month(o.OrderDate) = 1;
