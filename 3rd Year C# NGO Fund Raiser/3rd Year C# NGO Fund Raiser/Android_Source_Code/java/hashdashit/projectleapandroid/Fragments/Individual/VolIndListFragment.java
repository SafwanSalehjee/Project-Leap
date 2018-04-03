package hashdashit.projectleapandroid.Fragments.Individual;


import android.app.Activity;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import java.util.List;

import hashdashit.projectleapandroid.API.APIFragment;
import hashdashit.projectleapandroid.Adapter.AdapterVolInd;
import hashdashit.projectleapandroid.Model.VolunteerCall;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


/**
 * A simple {@link Fragment} subclass.
 */
public class VolIndListFragment extends APIFragment {

    private ListView list;
    private AdapterVolInd adapter;

    public VolIndListFragment() {
        // Required empty public constructor
    }

    private Activity getContext() {
        return getActivity();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View rootView = inflater.inflate(R.layout.fragment_vol_ind_list, container, false);
        SharedPreferences prefs = getContext().getSharedPreferences(SettingFiles.PREFERENCES, 0);

        AdapterVolInd.counterVolInd = 0;

        list = (ListView)rootView.findViewById(R.id.volunteer_list_view_ind);

        api.getVolunteerUser(prefs.getInt(SettingFiles.IDVal, 0), new Callback<List<VolunteerCall>>() {
            @Override
            public void success(List<VolunteerCall> volunteerCalls, Response response) {
                adapter = new AdapterVolInd(getContext(), volunteerCalls);
                list.setAdapter(adapter);
            }

            @Override
            public void failure(RetrofitError error) {

            }
        });

        return rootView;
    }


}
