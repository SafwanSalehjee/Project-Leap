package hashdashit.projectleapandroid.API;

import android.content.SharedPreferences;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.squareup.okhttp.OkHttpClient;

import java.util.concurrent.TimeUnit;

import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.RestAdapter;
import retrofit.converter.GsonConverter;

/**
 * Created by Wald on 2015-07-30.
 */
public class RestClient {
    private static String BASE_URL = "http://192.168.1.73:53319/Service1.svc/android";
    private Project_Leap_API api;

    public RestClient() {
        Gson gson = new GsonBuilder()
                .setDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'SSS'Z'")
                .create();

        RestAdapter restAdapter = new RestAdapter.Builder()
                .setLogLevel(RestAdapter.LogLevel.FULL)
                .setEndpoint(BASE_URL)
                .setConverter(new GsonConverter(gson))
                .build();

        OkHttpClient client = new OkHttpClient();
        client.setConnectTimeout(1, TimeUnit.MINUTES);
        client.setReadTimeout(1, TimeUnit.MINUTES);

        api = restAdapter.create(Project_Leap_API.class);
    }

    public Project_Leap_API getApiService() {
        return api;
    }

    public static void setBaseURL(String ip, String port)
    {
        BASE_URL = "http://" + ip + ":" + port + "/Service1.svc/android";
    }

    public void updateRestClient()
    {
        Gson gson = new GsonBuilder()
                .setDateFormat("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'SSS'Z'")
                .create();

        RestAdapter restAdapter = new RestAdapter.Builder()
                .setLogLevel(RestAdapter.LogLevel.FULL)
                .setEndpoint(BASE_URL)
                .setConverter(new GsonConverter(gson))
                .build();

        OkHttpClient client = new OkHttpClient();
        client.setConnectTimeout(1, TimeUnit.MINUTES);
        client.setReadTimeout(1, TimeUnit.MINUTES);

        api = restAdapter.create(Project_Leap_API.class);
    }
}
