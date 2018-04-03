package hashdashit.projectleapandroid.API;

import android.app.Activity;
import android.support.v4.app.Fragment;

/**
 * Created by Wald on 2015-08-06.
 */
public class APIFragment extends Fragment{

    private RestClient restClient;
    protected Project_Leap_API api;

    public APIFragment()
    {
        restClient = new RestClient();
        restClient.updateRestClient();
        api = restClient.getApiService();
    }
}
