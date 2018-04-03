package hashdashit.projectleapandroid.Fragments.NPO;


import android.app.Activity;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import hashdashit.projectleapandroid.API.APIFragment;
import hashdashit.projectleapandroid.Adapter.AdapterVolNPO;
import hashdashit.projectleapandroid.Model.VolunteerCall;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


/**
 * A simple {@link Fragment} subclass.
 */
public class VolunteerListNPOFragment extends APIFragment {

    private ListView list;
    private AdapterVolNPO adapter;

    public VolunteerListNPOFragment() {
        // Required empty public constructor
    }

    private Activity getContext() {
        return getActivity();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        final View rootView = inflater.inflate(R.layout.fragment_volunteer_list_npo, container, false);
        SharedPreferences prefs = getContext().getSharedPreferences(SettingFiles.PREFERENCES, 0);

        AdapterVolNPO.counterVolNPO = 0;

        list = (ListView)rootView.findViewById(R.id.volunteer_list_view);

        api.getNPOID(prefs.getInt(SettingFiles.IDVal, 0), new Callback<Integer>() {
            @Override
            public void success(Integer integer, Response response) {
                api.getVolunteers(integer, new Callback<List<VolunteerCall>>() {
                    @Override
                    public void success(List<VolunteerCall> volunteerCalls, Response response) {
                        adapter = new AdapterVolNPO(getContext(), volunteerCalls);
                        list.setAdapter(adapter);

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
