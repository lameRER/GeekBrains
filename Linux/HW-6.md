1. Установить Nginx
    >`sudo apt install nginx`
2. настроить Nginx на работу с PHP-FPM.
    >Устанавливаем php
    >`sudo apt install libapache2-mod-php8.1 php8.1`

    >Cоздадаем файл `info.php` в корне основного сайта для Apache (по умолчанию это /var/www/html)
    >со следующим содержанием:


    >```php
    ><?php
    >    phpinfo();
    >?>
    >```


    >Устанавливаем php-fpm
    >`sudo apt install php-fpm`

    >Добавляем секцию конфигурации сайта Nginx:

    >```conf
    >location ~ \.php$ {
    >    include snippets/fastcgi-php.conf;
    >    root /var/www/html;
    >    fastcgi_pass unix:/run/php/php8.1-fpm.sock;
    >}


    >Проверяем:
    >`http://localhost/info.php`
3. Установить Apache.
    >`sudo apt install apache2`
4. Настроить обработку PHP. Добиться одновременной работы с Nginx.
    >Изменить порт c 80 на 8080 в файле: `/etc/apache2/ports.conf`

    >После внесения изменений проверяем синтаксис:
    >`sudo apachectl -t`

    >И применить новую конфигурацию:
    >`sudo systemctl reload apache2`
5. Настроить схему обратного прокси для Nginx (динамика - на Apache).
    >Добавляем секцию конфигурации сайта Nginx:
    >```conf
    >location / {
    >     proxy_pass http://localhost:8080;
    >     proxy_set_header Host $host;
    >     proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
    >     proxy_set_header X-Real-IP $remote_addr;
    >}
    >
    >    location ~* ^.+.(jpg|jpeg|gif|png|ico|css|zip|pdf|txt|tar|js)$ {
    >    root /var/www/html;
    >}
   ```
6. Установить MySQL. Создать новую базу данных и таблицу в ней.
    >Установка сервера MySQL выполняется одной командой:
    >`sudo apt install mysql-server-8.0`

    >Заходим в MySQL
    >`sudo mysql`

    >Создаем базу и таблицу с данными:
    ```sql
    use mysql;
    -- Создадим новую базу данных и таблицу в ней:
    CREATE DATABASE gb;
    CREATE TABLE test(i INT);
    -- Создадим несколько записей в новой таблице и проверим, что они появились:
    INSERT INTO test (i) VALUES (1),(2),(3),(4);
    SELECT * FROM test;
    ```
7. Установить пакет phpmyadmin и запустить его веб-интерфейс для управления MySQL.
    >`sudo apt install phpmyadmin`

    >При установке выбираем `apache2`

    >Соглашаемся с настройкой базы и устанавливаем пароль

    >Перезапускаем apache
    >`sudo systemctl restart apache2`
