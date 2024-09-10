create database InventoryDB;
Go

use InventoryDB;
go
create schema InventorySchema;



create table InventorySchema.Category(
Id int primary key identity(1,1),
Name nvarchar(100) not null
)


create table InventorySchema.Product(
Id int primary key identity(1,1),
Name nvarchar(100) not null,
Price decimal(10,2) not null,
CategoryId int,
constraint FK_Product_Category foreign key (CategoryId) references   InventorySchema.Category(id)
)


create table InventorySchema.Inventory(
ProductId int primary key,
Quantity int,
constraint FK_Inventory_Product foreign key (ProductId) references   InventorySchema.Product(id)
);


insert into InventorySchema.Category 
(Name)
values
('Food'),
('Electronics'),
('Clothing')

insert into InventorySchema.Product 
(Name, Price, CategoryId)
values
('Apple', 1.25, 1),
('Ham', 12.7, 1),
('SmartTV', 785.48, 2),
('Iphone', 895.25, 2),
('Jeans', 25.36, 3),
('Jacket', 45.58, 3)

insert into InventorySchema.Inventory 
(ProductId, Quantity)
values
( 1, 750),
( 2, 452),
( 3, 158),
( 4, 587),
( 5, 789),
( 6, 598)


create procedure InventorySchema.sp_getInventoryByCategoryId
 @CategoryId int

AS 
BEGIN

   select i.ProductId, p.Name as Product, c.Name as Category, p.Price, i.Quantity 
   from InventorySchema.Inventory i
   left join InventorySchema.Product p on p.id = i.ProductId
   join InventorySchema.Category c on c.id = p.CategoryId
   where c.Id = @CategoryId
end;

create login UserTest
with password = 'password';

create user UserTest from login UserTest;

create role inv_dataowner;

alter role inv_dataowner add member UserTest;

grant select, insert, delete, update, execute on schema::InventorySchema to inv_dataowner;

grant view definition on database::InventoryDB to inv_dataowner
