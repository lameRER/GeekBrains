package seminar.java_seminar_oop_7.Adapter.src.meteo;

import java.time.*;

class ST500Info {
    public SensorTemperature getData() {
        return new SensorTemperature() {
            public int identifier() {
                return 1;
            }

            public double temperature() {
                return 22.0;
            }

            public int year() {
                return LocalDateTime.now().getYear();
            }

            public int day() {
                return LocalDateTime.now().getDayOfYear();
            }

            public int second() {
                LocalDateTime now = LocalDateTime.now();
                return now.getHour() * 3600 + now.getMinute() * 60 + now.getSecond();
            }
        };
    }
}