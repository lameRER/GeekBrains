package seminar.java_seminar_oop_7.Adapter.src.meteo;

interface SensorTemperature{
	int identifier(); // идентификатор датчика
	double temperature(); // температура датчика
	int year();			 // Год
	int day();			 // День года
	int second();		 // Секунда дня
}
	