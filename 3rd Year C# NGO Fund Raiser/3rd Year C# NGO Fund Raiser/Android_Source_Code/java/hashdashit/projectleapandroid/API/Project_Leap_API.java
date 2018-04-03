package hashdashit.projectleapandroid.API;

import java.util.ArrayList;
import java.util.List;

import hashdashit.projectleapandroid.Model.MobileEventCall;
import hashdashit.projectleapandroid.Model.MobileFCCall;
import hashdashit.projectleapandroid.Model.UserDetailsCall;
import hashdashit.projectleapandroid.Model.VolunteerCall;
import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.Part;
import retrofit.http.Path;
import retrofit.http.Query;

/**
 * Created by Wald on 2015-07-30.
 */
public interface Project_Leap_API {

    @GET("/CheckDetails/")
    void getCheckUserDetails(@Query("email") String email, @Query("pass") String password, Callback<UserDetailsCall> callback);

    @GET("/getNPOWithManager/")
    void getNPOID(@Query("npoManID") int userID, Callback<Integer> callback);

    @GET("/TotalRecievedFromDonations/")
    void getTotalDonations(@Query("orgID") int oID, Callback<Double> callback);

    @GET("/GetNextEvent/")
    void getNextEvent(@Query("orgID") int oID, Callback<MobileEventCall> callback);

    @GET("/getNextNPOEvent/")
    void getNextNPOEvent(@Query("userID") int UserID, Callback<MobileEventCall> callback);

    @GET("/GetTotalFCProgress/")
    void getTotalFCProgress(@Query("orgID") int oID, Callback<MobileFCCall> callback);

    @GET("/getVolunteers/")
    void getVolunteers(@Query("orgID") int oID, Callback<List<VolunteerCall>> callback);

    @GET("/getMobileEvents/")
    void getMobileEvents(@Query("orgID") int oID, Callback<List<MobileEventCall>> callback);

    @GET("/PointsInd/")
    void getPointsInd(@Query("userID") int indID, Callback<Integer> callback);

    @GET("/PointsOrg/")
    void getPointsOrg(@Query("OrgID") int orgID, Callback<Integer> callback);

    @GET("/TotalDonated/")
    void getTotalDonated(@Query("userID") int UserID, Callback<Double> callback);

    @GET("/getNextVolunteer/")
    void getNextVolunteer(@Query("userID") int UserID, Callback<VolunteerCall> callback);

    @GET("/getNumOfBadgesEarned/")
    void getNumOfBadgesEarned(@Query("userID") int UserID, Callback<Integer> callback);

    @GET("/getVolunteerUser/")
    void getVolunteerUser(@Query("userID") int UserID, Callback<List<VolunteerCall>> callback);

    @GET("/CaptureVolTimeMobile/")
    void CaptureVolTimeMobile(@Query("VolID") int volID, @Query("Hours") int hours, @Query("Comment") String comment, Callback<Boolean> callback);

    @GET("/GetMobileEventsAtt/")
    void getMobileEventsAtt(@Query("UserID") int userID, Callback<List<MobileEventCall>> callback);
}
