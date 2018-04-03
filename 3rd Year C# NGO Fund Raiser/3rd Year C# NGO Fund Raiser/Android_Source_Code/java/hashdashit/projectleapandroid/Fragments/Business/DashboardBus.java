package hashdashit.projectleapandroid.Fragments.Business;


import android.app.Activity;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import hashdashit.projectleapandroid.API.APIFragment;
import hashdashit.projectleapandroid.Model.MobileEventCall;
import hashdashit.projectleapandroid.Model.VolunteerCall;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


/**
 * A simple {@link Fragment} subclass.
 */
public class DashboardBus extends APIFragment {


    public DashboardBus() {
        // Required empty public constructor
    }

    private Activity getContext() {
        return getActivity();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View rootView = inflater.inflate(R.layout.fragment_dashboard_bus, container, false);

        SharedPreferences prefs = getContext().getSharedPreferences(SettingFiles.PREFERENCES, 0);

        final TextView lblDon = (TextView)rootView.findViewById(R.id.lblTotalDonVal);
        final TextView lblNextEve = (TextView)rootView.findViewById(R.id.lblNextEveVal);
        final TextView lblPoints = (TextView)rootView.findViewById(R.id.lblTotalPointsVal);

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

        api.getNextNPOEvent(userID, new Callback<MobileEventCall>() {
            @Override
            public void success(MobileEventCall mobileEventCall, Response response) {
                if(mobileEventCall != null)
                {
                    lblNextEve.setText(mobileEventCall.getName() + " on\n" + mobileEventCall.getDate());
                }
                else
                {
                    lblNextEve.setText("No upcoming \nevent!");
                }
            }

            @Override
            public void failure(RetrofitError error) {

            }
        });

        api.getNPOID(userID, new Callback<Integer>() {
            @Override
            public void success(Integer integer, Response response) {
                api.getPointsOrg(integer, new Callback<Integer>() {
                    @Override
                    public void success(Integer integer2, Response response) {
                        lblPoints.setText("" + integer2);
                    }

                    @Override
                    public void failure(RetrofitError error) {

                    }
                });
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

        return rootView;
    }


}
