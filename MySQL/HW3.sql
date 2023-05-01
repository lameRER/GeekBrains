create database hw3;

create table staff (
    select 1 as id, 'Вася' as firstname, 'Петров' as lastname, 'Начальник' as post, 40 as seniority, 100000 as salary, 60 as age union
    select 2, 'Петр', 'Власов', 'Начальник', 8, 70000, 30 union
    select 3, 'Катя', 'Катина', 'Инженер', 2, 70000, 25 union
    select 4, 'Саша', 'Сасин', 'Инженер', 12, 50000, 35 union
    select 5, 'Иван', 'Иванов', 'Рабочий', 40, 30000, 59 union
    select 6, 'Петр', 'Петров', 'Рабочий', 20, 25000, 40 union
    select 7, 'Сидр', 'Сидоров', 'Рабочий', 10, 20000, 35 union
    select 8, 'Антон', 'Антонов', 'Рабочий', 8, 19000, 28 union
    select 9, 'Юрий', 'Юрков', 'Рабочий', 5, 15000, 25 union
    select 10, 'Максим', 'Максимов', 'Рабочий', 2, 11000, 22 union
    select 11, 'Юрий', 'Галкин', 'Рабочий', 3, 12000, 24 union
    select 12, 'Людмила', 'Маркина', 'Уборщик', 10, 10000, 49
);

# 1. Отсортируйте данные по полю заработная плата (salary) в порядке убывания

select * from staff s order by s.salary desc;

# 2. Отсортируйте данные по полю заработная плата (salary) в порядке возрастания

select *
from staff s order by s.salary asc;

# 3. Выведите 5 максимальных заработных плат (salary)

select s.salary
from staff s group by s.salary order by s.salary desc limit 5;

# 4. Посчитайте суммарную зарплату (salary) по каждой специальности (роst)

select s.post, sum(s.salary)
from staff s group by s.post;

# 5. Найдите кол-во сотрудников с специальностью (post) «Рабочий» в возрасте от 24 до 49 лет включительно.

select count(s.id), s.post, group_concat(s.age separator ', ') as age
from staff s where s.age between 24 and 49 and s.post = 'Рабочий';

# 6. Найдите количество уникальных специальностей

select count(distinct s.post)
from staff s ;

# 7. Выведите специальности, у которых средний возраст сотрудников меньше 30 лет

select s.post, AVG(s.age) as avg_age
from staff s group by s.post
having AVG(s.age) < 30;
