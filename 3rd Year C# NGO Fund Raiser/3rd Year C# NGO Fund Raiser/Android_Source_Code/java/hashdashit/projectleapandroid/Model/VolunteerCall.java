package hashdashit.projectleapandroid.Model;

import com.google.gson.annotations.Expose;

import java.util.Date;

/**
 * Created by Wald on 2015-08-08.
 */
public class VolunteerCall {

    @Expose
    private String Comment;

    @Expose
    private Integer Hours;

    @Expose
    private Integer OrgID;

    @Expose
    private String OrnName;

    @Expose
    private String UserEmail;

    @Expose
    private String UserFN;

    @Expose
    private Integer UserID;

    @Expose
    private String UserLN;

    @Expose
    private String VolDate;

    @Expose
    private String ShortDate;

    @Expose
    private Integer VolunteerID;

    public String getComment() {
        return Comment;
    }

    public void setComment(String comment) {
        Comment = comment;
    }

    public Integer getHours() {
        return Hours;
    }

    public void setHours(Integer hours) {
        Hours = hours;
    }

    public Integer getOrgID() {
        return OrgID;
    }

    public void setOrgID(Integer orgID) {
        OrgID = orgID;
    }

    public String getOrnName() {
        return OrnName;
    }

    public void setOrnName(String ornName) {
        OrnName = ornName;
    }

    public String getUserEmail() {
        return UserEmail;
    }

    public void setUserEmail(String userEmail) {
        UserEmail = userEmail;
    }

    public String getUserFN() {
        return UserFN;
    }

    public void setUserFN(String userFN) {
        UserFN = userFN;
    }

    public Integer getUserID() {
        return UserID;
    }

    public void setUserID(Integer userID) {
        UserID = userID;
    }

    public String getUserLN() {
        return UserLN;
    }

    public void setUserLN(String userLN) {
        UserLN = userLN;
    }

    public String getVolDate() {
        return VolDate;
    }

    public void setVolDate(String volDate) {
        VolDate = volDate;
    }

    public String getShortDate() {
        return ShortDate;
    }

    public void setShortDate(String shortDate) {
        ShortDate = shortDate;
    }

    public Integer getVolunteerID() {
        return VolunteerID;
    }

    public void setVolunteerID(Integer volunteerID) {
        VolunteerID = volunteerID;
    }
}
