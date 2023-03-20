package seminar.java_seminar_oop_7.Adapter.src.meteo;

import java.time.LocalDateTime;

public class SensorAdapter implements MeteoSensor{

    private SensorTemperature adptee;

    public SensorAdapter(SensorTemperature adptee) {
        this.adptee = adptee;
    }

    @Override
    public int getId() {
        return adptee.identifier();
    }

    @Override
    public Float getTemperature() {
        return (float) adptee.temperature();
    }

    @Override
    public Float getHumidity() {
        return null;
    }

    @Override
    public Float getPressure() {
        return null;
    }

    @Override
    public LocalDateTime getDateTime() {
        LocalDateTime result = LocalDateTime.of(adptee.year(),1,1,0,0,0);
        return result.plusDays(adptee.day()-1).plusSeconds(adptee.second());
    }
}
