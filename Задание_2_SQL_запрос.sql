CREATE TABLE Customers
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(20)
);

CREATE TABLE Orders 
(
    Id INT PRIMARY KEY IDENTITY,
    CustomerId INT
);

INSERT Customers VALUES ('Max');
INSERT Customers VALUES ('Pavel');
INSERT Customers VALUES ('Ivan');
INSERT Customers VALUES ('Leonid');

INSERT Orders VALUES (2);
INSERT Orders VALUES (4);

select Name as Customers from
(SELECT Customers.Id, Customers.Name FROM Customers
EXCEPT
SELECT Customers.Id, Customers.Name FROM Customers
JOIN Orders ON Customers.Id = Orders.CustomerId) t
order by t.Id;