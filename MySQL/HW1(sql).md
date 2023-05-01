1. Создайте таблицу с мобильными телефонами (mobile_phones), используя графический интерфейс. Заполните БД данными. Добавьте скриншот на платформу в качестве ответа на ДЗ

    ```sql
    CREATE DATABASE HW1;
    USE productsdb;
    CREATE TABLE mobile_phones
    (
        Id INT AUTO_INCREMENT PRIMARY KEY,
        Product_name VARCHAR(30) NOT NULL,
        Manufacturer VARCHAR(20) NOT NULL,
        Product_count INT DEFAULT 0,
        Price DECIMAL NOT NULL
    );

    insert mobile_phones(Id, Product_name, Manufacturer, Product_count, Price)
    VALUES (1, 'iPhone X', 'Apple', 3, 76000),
           (2, 'iPhone 8', 'Apple', 2, 51000),
           (3, 'Galaxy S9', 'Samsung', 2, 56000),
           (4, 'Galaxy S8', 'Samsung', 1, 41000),
           (5, 'P20 Pro', 'Huawei', 5, 36000);
    ```

2. Выведите название, производителя и цену для товаров, количество которых превышает 2

    ```sql
    select mp.Product_name, Manufacturer, Price
    from mobile_phones mp where mp.Product_count >= 2;
    ```

3.  Выведите весь ассортимент товаров марки “Samsung”

    ```sql
    select *
    from mobile_phones mp where mp.Manufacturer = 'Samsung';
    ```
4. (по желанию)* С помощью регулярных выражений найти:

   1. Товары, в которых есть упоминание "Iphone"

    ```sql
    select *
    from mobile_phones mp where mp.Product_name regexp 'iphone';
    ```

    2. Товары, в которых есть упоминание "Samsung"

    ```sql
    select *
    from mobile_phones mp where mp.Manufacturer regexp 'samsung';
    ```

    3.  Товары, в которых есть ЦИФРЫ

    ```sql
    select *
    from mobile_phones mp where mp.Product_name regexp '\\d';
    ```

    4.  Товары, в которых есть ЦИФРА "8"

    ```sql
    select *
    from mobile_phones mp where mp.Product_name regexp '8';
    ```
