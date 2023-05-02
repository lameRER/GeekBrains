use lesson_4;
# 1. Создайте таблицу users_old, аналогичную таблице users. Создайте процедуру,  с помощью которой можно переместить любого (одного) пользователя из
# таблицы users в таблицу users_old. (использование транзакции с выбором commit или rollback – обязательно).

create table users_old like users;

drop procedure if exists move_user;
delimiter //
create procedure move_user(in user_id int)
begin
    start transaction;
    insert into users_old
        select * from users where id = user_id;
    delete from users
        where id = user_id;

    if row_count() = 1 then
        commit;
        select 'OK';
    else
        rollback;
        select 'ERROR';
    end if;
end //
delimiter ;

call move_user(2);

select * from users_old;

# 2. Создайте функцию hello(), которая будет возвращать приветствие, в зависимости от текущего времени суток. С 6:00 до 12:00
# функция должна возвращать фразу "Доброе утро", с 12:00 до 18:00 функция должна возвращать фразу "Добрый день",
# с 18:00 до 00:00 — "Добрый вечер", с 00:00 до 6:00 — "Доброй ночи".

drop function if EXISTS hello;
create function hello()
RETURNS varchar(20)
    NO SQL
begin
    declare greeting VARCHAR(20);
    set greeting =
        case
            when time(now()) between '06:00:00' and '11:59:59' then 'Доброе утро'
            when time(now()) between '12:00:00' and '17:59:59' then 'Добрый день'
            when time(now()) between '18:00:00' and '23:59:59' then 'Добрый вечер'
            when time(now()) between '00:00:00' and '05:59:59' then 'Доброй ночи'
        end;
    return greeting;
end;

select hello();

# 3. Доп. Задача: Создайте процедуру, которая выведет id и его коэффициент
# популярности для всех пользователей из таблицы users

DROP FUNCTION IF EXISTS user_popularity_coefficient;
CREATE FUNCTION user_popularity_coefficient(id_researches_user BIGINT UNSIGNED)
RETURNS DOUBLE READS SQL DATA
BEGIN
	DECLARE to_user int;
    DECLARE from_user int;
    DECLARE user_popularity_coefficient DOUBLE;

    SET to_user = (SELECT COUNT(*) FROM friend_requests WHERE target_user_id = id_researches_user);
    SET from_user = (SELECT COUNT(*) FROM friend_requests WHERE initiator_user_id = id_researches_user);

		IF (from_user = 0) THEN SET user_popularity_coefficient = NULL;
		ELSE SET user_popularity_coefficient = to_user / from_user ;
		END IF;

    RETURN user_popularity_coefficient ;
END;

select user_popularity_coefficient(6)