package hashdashit.projectleapandroid.Fragments.Individual;


import android.app.Activity;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import hashdashit.projectleapandroid.API.APIFragment;
import hashdashit.projectleapandroid.Model.VolunteerCall;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


/**
 * A simple {@link Fragment} subclass.
 */
public class DashboardInd extends APIFragment {


    public DashboardInd() {
        // Required empty public constructor
    }

    private Activity getContext() {
        return getActivity();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View rootView = inflater.inflate(R.layout.fragment_dashboard_ind, container, false);

        SharedPreferences prefs = getContext().getSharedPreferences(SettingFiles.PREFERENCES, 0);

        final TextView lblDon = (TextView)rootView.findViewById(R.id.lblTotalDonVal);
        final TextView lblNextVol = (TextView)rootView.findViewById(R.id.lblNextVolVal);
        final TextView lblPoints = (TextView)rootView.findViewById(R.id.lblTotalPointsVal);
        final TextView lblBadges = (TextView)rootView.findViewById(R.id.lblNumBadgesVal);

        int userID = prefs.getInt(SettingFiles.IDVal, 0);

        api.getTotalDonated(userID, new Callback<Double>() {
            @Override
            public void success(Double aDouble, Response response) {
                lblDon.setText("R " + aDouble);
            }

            @Override
            public void failure(RetrofitError error) {

            }
        });

        api.getNextVolunteer(userID, new Callback<VolunteerCall>() {
            @Override
            public void success(VolunteerCall volunteerCall, Response response) {
                if(volunteerCall != null)
                {
                    lblNextVol.setText(volunteerCall.getOrnName() + " on\n" + volunteerCall.getShortDate());
                }
                else
                {
                    lblNextVol.setText("No upcoming \nvolunteering!");
                }
            }

            @Override
            public void failure(RetrofitError error) {

            }
        });

        api.getPointsInd(userID, new Callback<Integer>() {
            @Override
            public void success(Integer integer, Response response) {
                lblPoints.setText("" + integer);
            }

            @Override
            public void failure(RetrofitError error) {

            }
        });

        api.getNumOfBadgesEarned(userID, new Callback<Integer>() {
            @Override
            public void success(Integer integer, Response response) {
                lblBadges.setText("" + integer);
            }

            @Override
            public void failure(RetrofitError error) {

            }
        });

        return rootView;
    }


}
