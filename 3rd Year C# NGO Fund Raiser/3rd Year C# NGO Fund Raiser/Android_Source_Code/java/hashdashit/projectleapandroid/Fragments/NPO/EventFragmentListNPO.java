package hashdashit.projectleapandroid.Fragments.NPO;


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
import hashdashit.projectleapandroid.Adapter.AdapterEventNPO;
import hashdashit.projectleapandroid.Adapter.AdapterVolNPO;
import hashdashit.projectleapandroid.Model.MobileEventCall;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


/**
 * A simple {@link Fragment} subclass.
 */
public class EventFragmentListNPO extends APIFragment {

    private ListView list;
    private AdapterEventNPO adapter;

    public EventFragmentListNPO() {
        // Required empty public constructor
    }

    private Activity getContext() {
        return getActivity();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View rootView = inflater.inflate(R.layout.fragment_event_fragment_list_npo, container, false);
        SharedPreferences prefs = getContext().getSharedPreferences(SettingFiles.PREFERENCES, 0);

        AdapterEventNPO.counterEventNPO = 0;

        list = (ListView)rootView.findViewById(R.id.event_list_view);

        api.getNPOID(prefs.getInt(SettingFiles.IDVal, 0), new Callback<Integer>() {
            @Override
            public void success(Integer integer, Response response) {
                api.getMobileEvents(integer, new Callback<List<MobileEventCall>>() {
                    @Override
                    public void success(List<MobileEventCall> mobileEventCalls, Response response) {
                        adapter = new AdapterEventNPO(getContext(), mobileEventCalls);
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
