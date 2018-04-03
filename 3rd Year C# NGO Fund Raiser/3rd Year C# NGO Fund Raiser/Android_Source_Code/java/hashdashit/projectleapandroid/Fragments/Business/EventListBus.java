package hashdashit.projectleapandroid.Fragments.Business;


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
import hashdashit.projectleapandroid.Adapter.AdapterEventBus;
import hashdashit.projectleapandroid.Adapter.AdapterEventNPO;
import hashdashit.projectleapandroid.Model.MobileEventCall;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


/**
 * A simple {@link Fragment} subclass.
 */
public class EventListBus extends APIFragment {

    private ListView list;
    private AdapterEventBus adapter;

    public EventListBus() {
        // Required empty public constructor
    }

    private Activity getContext() {
        return getActivity();
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View rootView = inflater.inflate(R.layout.fragment_event_list_bus, container, false);
        SharedPreferences prefs = getContext().getSharedPreferences(SettingFiles.PREFERENCES, 0);

        AdapterEventBus.counterEventBus = 0;

        list = (ListView)rootView.findViewById(R.id.event_list_view_bus);

        api.getMobileEventsAtt(prefs.getInt(SettingFiles.IDVal, 0), new Callback<List<MobileEventCall>>() {
            @Override
            public void success(List<MobileEventCall> mobileEventCalls, Response response) {
                adapter = new AdapterEventBus(getContext(), mobileEventCalls);
                list.setAdapter(adapter);
            }

            @Override
            public void failure(RetrofitError error) {

            }
        });

        return rootView;
    }


}
