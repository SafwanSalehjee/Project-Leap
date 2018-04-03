package hashdashit.projectleapandroid.Fragments.NPO;


import android.app.Activity;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ProgressBar;
import android.widget.TextView;

import org.w3c.dom.Text;

import hashdashit.projectleapandroid.API.APIFragment;
import hashdashit.projectleapandroid.Model.MobileEventCall;
import hashdashit.projectleapandroid.Model.MobileFCCall;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


/**
 * A simple {@link Fragment} subclass.
 */
public class NPODashboardFragment extends APIFragment {


    public NPODashboardFragment() {
        // Required empty public constructor
    }

    private Activity getContext() {
        return getActivity();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View rootView = inflater.inflate(R.layout.fragment_npodashboard, container, false);

        SharedPreferences prefs = getContext().getSharedPreferences(SettingFiles.PREFERENCES, 0);

        api.getNPOID(prefs.getInt(SettingFiles.IDVal, 0), new Callback<Integer>() {
            @Override
            public void success(Integer integer, Response response) {
                final TextView txtTotal = (TextView) rootView.findViewById(R.id.lblTotalDonVal);
                api.getTotalDonations(integer, new Callback<Double>() {
                    @Override
                    public void success(Double aDouble, Response response) {
                        txtTotal.setText("R " + aDouble);
                    }

                    @Override
                    public void failure(RetrofitError error) {

                    }
                });

                final TextView txtEvent = (TextView) rootView.findViewById(R.id.lblNextEventVal);
                api.getNextEvent(integer, new Callback<MobileEventCall>() {
                    @Override
                    public void success(MobileEventCall mobileEventCall, Response response) {
                        if(mobileEventCall != null)
                        {
                            txtEvent.setText(mobileEventCall.getName() + "\n" + mobileEventCall.getDate());
                        }
                        else
                        {
                            txtEvent.setText("No upcoming \nevent!");
                        }
                    }

                    @Override
                    public void failure(RetrofitError error) {

                    }
                });

                final ProgressBar progressBar = (ProgressBar)rootView.findViewById(R.id.FCProgressBar);
                api.getTotalFCProgress(integer, new Callback<MobileFCCall>() {
                    @Override
                    public void success(MobileFCCall mobileFCCall, Response response) {
                        progressBar.setMax((int)mobileFCCall.getTarget());
                        progressBar.setProgress((int)mobileFCCall.getCurrent());
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

        return rootView;
    }


}
