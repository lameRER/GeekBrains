/*1. Используя операторы языка SQL,

создайте таблицу “sales”. Заполните ее данными.*/

-- create table sales;
create database hw2;
use hw2;

create table sales(
    select 1 as id, date('2022-01-01') as order_date, 156 as count_product union
    select 2, date('2022-01-02'), 180 union
    select 3, date('2022-01-03'), 21 union
    select 4, date('2022-01-04'), 124 union
    select 5, date('2022-01-05'), 341
);

/*2.  Для данных таблицы “sales” укажите тип заказа в зависимости от кол-ва :

меньше 100  -    Маленький заказ

от 100 до 300 - Средний заказ

больше 300  -     Большой зака*/

select
    s.id,
    case
        when s.count_product < 100 then 'Маленький заказ'
        when s.count_product > 300 then 'Большой заказ'
        when 100 < s.count_product < 300 then 'Средний заказ'
    end
from sales s;

/*3. Создайте таблицу “orders”, заполните ее значениями


Выберите все заказы. В зависимости от поля order_status выведите столбец full_order_status:

OPEN – «Order is in open state» ; CLOSED - «Order is closed»; CANCELLED -  «Order is cancelled»*/

create table orders(
    select 1 as id, 'e03' as employee_id, 15.00 as amount, 'OPEN' as order_status union
    select 2, 'e01', 25.50, 'OPEN' union
    select 3, 'e05', 100.70, 'CLOSED' union
    select 4, 'e02', 22.18, 'OPEN' union
    select 5, 'e04', 9.50, 'CANCELLED'
);

select
    case
        when o.order_status = 'OPEN' then 'Order is in open state'
        when o.order_status = 'CLOSED' then 'Order is closed'
        when o.order_status = 'CANCELLED' then 'Order is cancelled'
    end,
    o.*
from orders o;
