# Домашнее задание 7
Создаем директорию проекта для настройки Wordpress и переходим в нее:
`mkdir wordpress && cd wordpress`

Создаем директорию для файла конфигурации:
>`mkdir nginx-conf`

В этом файле мы добавляем серверный блок с директивами для имени сервера и
корневой директории документов, а так же блок расположения для направления
запросов:
>`nano nginx-conf/nginx.conf`
```
server {
 listen 80;
 listen [::]:80;
 server_name example.com www.example.com;
 index index.php index.html index.htm;
 root /var/www/html;
 location ~ /.well-known/acme-challenge {
 allow all;
 root /var/www/html;
 }
 location / {
 try_files $uri $uri/ /index.php$is_args$args;
 }
 location ~ \.php$ {
 try_files $uri =404;
 fastcgi_split_path_info ^(.+\.php)(/.+)$;
 fastcgi_pass wordpress:9000;
 fastcgi_index index.php;
 include fastcgi_params;
 fastcgi_param SCRIPT_FILENAME $document_root$fastcgi_script_name;
 fastcgi_param PATH_INFO $fastcgi_path_info;
 }
 location ~ /\.ht {
 deny all;
 }
 location = /favicon.ico {
 log_not_found off; access_log off;
 }
 location = /robots.txt {
 log_not_found off; access_log off; allow all;
 }
 location ~* \.(css|gif|ico|jpeg|jpg|js|png)$ {
 expires max;
 log_not_found off;
 }
}
```

Открываем файл для переменных среды:
>`nano .env`

создаем локальный репозиторий
>`git init`

открываем файл гитигнор и прописываем в нем .env
>`nano .gitignore`

делаем тоже самое для исключения попадания не нужных файлов в образ докера
>`nano .dockerignore`

добавляем код для определения версии файла Compose и базы данных
>`nano docker-compose.yml`

запускаем созданные контейнеры в фоновом режиме
>`docker-compose up -d`

проверяем статус служб
>`docker-compose ps`

останавиливаем докер
>`sudo docker-compose stop`

удаляем контейнеры
>`sudo docker-compose rm`

заходим в файл
>`nano docker-compose.yml`
```
version: '3'
services:
 mariadb:
 image: mariadb:10.3
 restart: always
 volumes:
 - ./mariadb:/var/lib/mysql
 environment:
 MYSQL_ROOT_PASSWORD: qwerty
 phpmyadmin:
 image: phpmyadmin/phpmyadmin
 links:
 - mariadb:db
 ports:
 - 8765:80
 environment:
 MYSQL_ROOT_PASSWORD: qwerty
 depends_on:
 - mariadb
```