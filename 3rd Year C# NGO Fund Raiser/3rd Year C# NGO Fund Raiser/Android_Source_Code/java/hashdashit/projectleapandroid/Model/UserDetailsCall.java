package hashdashit.projectleapandroid.Model;

import com.google.gson.annotations.Expose;

/**
 * Created by Wald on 2015-07-30.
 */
public class UserDetailsCall {

    @Expose
    private Integer AccessLvl;

    @Expose
    private boolean Banned;

    @Expose
    private String EmailValue;

    @Expose
    private String FirstNameValue;

    @Expose
    private UserDetails userValue;


    public Integer getAccessLvl() {
        return AccessLvl;
    }

    public void setAccessLvl(Integer accessLvl) {
        AccessLvl = accessLvl;
    }

    public boolean isBanned() {
        return Banned;
    }

    public void setBanned(boolean banned) {
        Banned = banned;
    }

    public String getEmailValue() {
        return EmailValue;
    }

    public void setEmailValue(String emailValue) {
        EmailValue = emailValue;
    }

    public String getFirstNameValue() {
        return FirstNameValue;
    }

    public void setFirstNameValue(String firstNameValue) {
        FirstNameValue = firstNameValue;
    }

    public UserDetails getUserValue() {
        return userValue;
    }

    public void setUserValue(UserDetails userValue) {
        this.userValue = userValue;
    }
}
