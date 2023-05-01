1. Написать скрипт очистки директорий. На вход принимает путь к директории. Если директория существует, то удаляет в ней все файлы с расширениями .bak, .tmp, .backup. Если директории нет, то выводит ошибку.
```sh
#!/bin/bash
if [ -d $1 ]
then
echo "Got it!"
for file in $1/*
do
if [[ $file == *.bak ]] || [[ $file == *.tmp ]] || [[ $file == *.backup ]]
then
rm $file
fi
done
echo "Done"
else
echo "Directory does not exist"
fi
```


2. Создать скрипт ownersort.sh, который в заданной папке копирует файлы в директории, названные по имени владельца каждого файла. Учтите, что файл должен принадлежать соответствующему владельцу.
```sh
#!/bin/bash
dir="$1"
script=`echo $0 | xargs basename`
for name_file in $dir/* ;
do
if [[ `basename $name_file` != 'ownersort.sh' ]] ; then
user_name=`ls -la $name_file | awk {'print $3; '} | sort | uniq | xargs echo`
mkdir -p $dir/$user_name && chown -vR $user_name $dir
directory=($dir/$user_name)
cp -pv $name_file $directory
rm -v $name_file
echo
echo "Copied"
else
echo
echo "This is a script file. Skip file"
fi
done
```