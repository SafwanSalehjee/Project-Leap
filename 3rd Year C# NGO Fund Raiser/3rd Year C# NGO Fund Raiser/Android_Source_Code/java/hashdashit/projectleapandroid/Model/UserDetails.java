package hashdashit.projectleapandroid.Model;

import android.content.Intent;

import com.google.gson.annotations.Expose;

import java.util.Date;
import java.util.Objects;

/**
 * Created by Wald on 2015-07-30.
 */
public class UserDetails {

    @Expose
    private Integer AccessLvl;

    @Expose
    private boolean Banned;

    @Expose
    private String EmailValue;

    @Expose
    private String FirstNameValue;

    @Expose
    private String Continent;

    @Expose
    private String Country;

    @Expose
    private String DateOfBirth;

    @Expose
    private Object Donations;

    @Expose
    private String Email;

    @Expose
    private Object EventRSVPs;

    @Expose
    private String FirstName;

    @Expose
    private String Gender;

    @Expose
    private Object Individual;

    @Expose
    private String LastName;

    @Expose
    private Object Managers;

    @Expose
    private Object NPORatings;

    @Expose
    private String Password;

    @Expose
    private String ProfilePictureURL;

    @Expose
    private String Province;

    @Expose
    private String RegistrationDate;

    @Expose
    private String Title;

    @Expose
    private Integer UserID;

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

    public String getContinent() {
        return Continent;
    }

    public void setContinent(String continent) {
        Continent = continent;
    }

    public String getCountry() {
        return Country;
    }

    public void setCountry(String country) {
        Country = country;
    }

    public String getDateOfBirth() {
        return DateOfBirth;
    }

    public void setDateOfBirth(String dateOfBirth) {
        DateOfBirth = dateOfBirth;
    }

    public Object getDonations() {
        return Donations;
    }

    public void setDonations(Object donations) {
        Donations = donations;
    }

    public String getEmail() {
        return Email;
    }

    public void setEmail(String email) {
        Email = email;
    }

    public Object getEventRSVPs() {
        return EventRSVPs;
    }

    public void setEventRSVPs(Object eventRSVPs) {
        EventRSVPs = eventRSVPs;
    }

    public String getFirstName() {
        return FirstName;
    }

    public void setFirstName(String firstName) {
        FirstName = firstName;
    }

    public String getGender() {
        return Gender;
    }

    public void setGender(String gender) {
        Gender = gender;
    }

    public Object getIndividual() {
        return Individual;
    }

    public void setIndividual(Object individual) {
        Individual = individual;
    }

    public String getLastName() {
        return LastName;
    }

    public void setLastName(String lastName) {
        LastName = lastName;
    }

    public Object getManagers() {
        return Managers;
    }

    public void setManagers(Object managers) {
        Managers = managers;
    }

    public Object getNPORatings() {
        return NPORatings;
    }

    public void setNPORatings(Object NPORatings) {
        this.NPORatings = NPORatings;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }

    public String getProfilePictureURL() {
        return ProfilePictureURL;
    }

    public void setProfilePictureURL(String profilePictureURL) {
        ProfilePictureURL = profilePictureURL;
    }

    public String getProvince() {
        return Province;
    }

    public void setProvince(String province) {
        Province = province;
    }

    public String getRegistrationDate() {
        return RegistrationDate;
    }

    public void setRegistrationDate(String registrationDate) {
        RegistrationDate = registrationDate;
    }

    public String getTitle() {
        return Title;
    }

    public void setTitle(String title) {
        Title = title;
    }

    public Integer getUserID() {
        return UserID;
    }

    public void setUserID(Integer userID) {
        UserID = userID;
    }
}
