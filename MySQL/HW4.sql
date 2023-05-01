-- 1. Таблица:
-- https://drive.google.com/file/d/1TZzW8ZlDdvIfDC9C46bUeILey6opQjdu/view?usp=share_link
create database hw4;

use hw4;

CREATE TABLE `shops` (
	`id` INT,
    `shopname` VARCHAR (100),
    PRIMARY KEY (id)
);

CREATE TABLE `cats` (
	`name` VARCHAR (100),
    `id` INT,
    PRIMARY KEY (id),
    shops_id INT,
    CONSTRAINT fk_cats_shops_id FOREIGN KEY (shops_id)
        REFERENCES `shops` (id)
);

INSERT INTO `shops`
VALUES
		(1, "Четыре лапы"),
        (2, "Мистер Зоо"),
        (3, "МурзиЛЛа"),
        (4, "Кошки и собаки");

INSERT INTO `cats`
VALUES
		("Murzik",1,1),
        ("Nemo",2,2),
        ("Vicont",3,1),
        ("Zuza",4,3);


-- Используя JOIN-ы, выполните следующие операции:

-- 1.1. Вывести всех котиков по магазинам по id (условие соединения shops.id = cats.shops_id)

select c.*
from shops s
join cats c on s.id = c.shops_id;

-- 1.2. Вывести магазин, в котором продается кот “Мурзик” (попробуйте выполнить 2 способами)

select s.shopname
from shops s
join cats c on s.id = c.shops_id
where c.name = 'Murzik';

select s.shopname
from shops s
join cats c on s.id = c.shops_id and c.name = 'Murzik'
where exists(select * from shops s1 where s1.shopname = s.shopname);

-- 1.3. Вывести магазины, в которых НЕ продаются коты “Мурзик” и “Zuza”

select s.*
from shops s
where s.id not in(
    select s1.id from shops s1
    join cats c on s1.id = c.shops_id
    where c.name in ('Murzik', 'Zuza')
);

-- 2. Табличка (после слов “Последнее задание, таблица:”):
-- https://drive.google.com/file/d/1TZzW8ZlDdvIfDC9C46bUeILey6opQjdu/view?usp=share_link

DROP TABLE IF EXISTS Analysis;

CREATE TABLE Analysis
(
	an_id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	an_name varchar(50),
	an_cost INT,
	an_price INT,
	an_group INT
);

INSERT INTO analysis (an_name, an_cost, an_price, an_group)
VALUES
	('Общий анализ крови', 30, 50, 1),
	('Биохимия крови', 150, 210, 1),
	('Анализ крови на глюкозу', 110, 130, 1),
	('Общий анализ мочи', 25, 40, 2),
	('Общий анализ кала', 35, 50, 2),
	('Общий анализ мочи', 25, 40, 2),
	('Тест на COVID-19', 160, 210, 3);

DROP TABLE IF EXISTS GroupsAn;

CREATE TABLE GroupsAn
(
	gr_id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	gr_name varchar(50),
	gr_temp FLOAT(5,1),
	FOREIGN KEY (gr_id) REFERENCES Analysis (an_id)
	ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO groupsan (gr_name, gr_temp)
VALUES
	('Анализы крови', -12.2),
	('Общие анализы', -20.0),
	('ПЦР-диагностика', -20.5);

DROP TABLE IF EXISTS Orders;
CREATE TABLE Orders
(
	ord_id INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	ord_datetime DATETIME,	-- 'YYYY-MM-DD hh:mm:ss'
	ord_an INT,
	FOREIGN KEY (ord_an) REFERENCES Analysis (an_id)
	ON DELETE CASCADE ON UPDATE CASCADE
);

INSERT INTO Orders (ord_datetime, ord_an)
VALUES
	('2020-02-04 07:15:25', 1),
	('2020-02-04 07:20:50', 2),
	('2020-02-04 07:30:04', 1),
	('2020-02-04 07:40:57', 1),
	('2020-02-05 07:05:14', 1),
	('2020-02-05 07:15:15', 3),
	('2020-02-05 07:30:49', 3),
	('2020-02-06 07:10:10', 2),
	('2020-02-06 07:20:38', 2),
	('2020-02-07 07:05:09', 1),
	('2020-02-07 07:10:54', 1),
	('2020-02-07 07:15:25', 1),
	('2020-02-08 07:05:44', 1),
	('2020-02-08 07:10:39', 2),
	('2020-02-08 07:20:36', 1),
	('2020-02-08 07:25:26', 3),
	('2020-02-09 07:05:06', 1),
	('2020-02-09 07:10:34', 1),
	('2020-02-09 07:20:19', 2),
	('2020-02-10 07:05:55', 3),
	('2020-02-10 07:15:08', 3),
	('2020-02-10 07:25:07', 1),
	('2020-02-11 07:05:33', 1),
	('2020-02-11 07:10:32', 2),
	('2020-02-11 07:20:17', 3),
	('2020-02-12 07:05:36', 1),
	('2020-02-12 07:10:54', 2),
	('2020-02-12 07:20:19', 3),
	('2020-02-12 07:35:38', 1);

-- 2.1. Вывести название и цену для всех анализов, которые продавались 5 февраля 2020 и всю следующую неделю.

# Есть таблица анализов Analysis:
# an_id — ID анализа;
# an_name — название анализа;
# an_cost — себестоимость анализа;
# an_price — розничная цена анализа;
# an_group — группа анализов.

# Есть таблица групп анализов Groups:
# gr_id — ID группы;
# gr_name — название группы;
# gr_temp — температурный режим хранения.
# Есть таблица заказов Orders:
# ord_id — ID заказа;
# ord_datetime — дата и время заказа;
# ord_an — ID анализа.

set @date = date('2020-02-05');

select a.an_id, a.an_name, a.an_price, o.ord_datetime
from analysis a
join Orders o on a.an_id = o.ord_an
where date(o.ord_datetime) between @date and adddate(@date , interval 7 day);
