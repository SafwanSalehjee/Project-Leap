package hashdashit.projectleapandroid.Model;

import com.google.gson.annotations.Expose;

/**
 * Created by Wald on 2015-08-08.
 */
public class MobileEventCall {

    @Expose
    private String Name;

    @Expose
    private String Date;

    @Expose
    private String Location;

    @Expose
    private String Time;

    @Expose
    private String NpoName;

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getDate() {
        return Date;
    }

    public void setDate(String date) {
        Date = date;
    }

    public String getLocation() {
        return Location;
    }

    public void setLocation(String location) {
        Location = location;
    }

    public String getTime() {
        return Time;
    }

    public void setTime(String time) {
        Time = time;
    }

    public String getNpoName() {
        return NpoName;
    }

    public void setNpoName(String npoName) {
        NpoName = npoName;
    }
}
