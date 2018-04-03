package hashdashit.projectleapandroid.Activity;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;

import java.io.UnsupportedEncodingException;
import java.security.NoSuchAlgorithmException;

import hashdashit.projectleapandroid.API.Project_Leap_API;
import hashdashit.projectleapandroid.API.RestClient;
import hashdashit.projectleapandroid.Model.UserDetailsCall;
import hashdashit.projectleapandroid.Settings.Security;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


public class LoginActivity extends ActionBarActivity {

    private SharedPreferences prefs;
    private TextView txtEmail;
    private TextView txtPass;
    private Intent nextScreenNPO;
    private Intent nextScreenBus;
    private Intent nextScreenInd;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        prefs = getSharedPreferences(SettingFiles.PREFERENCES, 0);

        nextScreenNPO = new Intent(this, MainActivityNPO.class);
        nextScreenBus = new Intent(this, MainActivityBus.class);
        nextScreenInd = new Intent(this, MainActivityInd.class);

        txtEmail = (TextView)findViewById(R.id.txtEmail);
        txtPass = (TextView)findViewById(R.id.txtPassword);

        ActionBar actionBar = getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(false);

        View mActionBarView = getLayoutInflater().inflate(R.layout.toolbar, null);
        actionBar.setCustomView(mActionBarView);
        actionBar.setDisplayOptions(ActionBar.DISPLAY_SHOW_CUSTOM);
    }

    public void btnLogin(View v)
    {
        final TextView lblReturnText = (TextView)findViewById(R.id.lblReturnTest);

        RestClient client = new RestClient();
        RestClient.setBaseURL(prefs.getString(SettingFiles.IPAdderss, ""), prefs.getString(SettingFiles.PortNum, ""));
        client.updateRestClient();
        Project_Leap_API api = client.getApiService();

        try {
            api.getCheckUserDetails(txtEmail.getText().toString(), Security.SHA1(txtPass.getText().toString()), new Callback<UserDetailsCall>() {
                @Override
                public void success(UserDetailsCall userDetailsCall, Response response) {
                    SharedPreferences.Editor settingsEditor = prefs.edit();

                    //Log that the user has logged in
                    settingsEditor.putBoolean(SettingFiles.loggedIn, true);
                    settingsEditor.putInt(SettingFiles.IDVal, userDetailsCall.getUserValue().getUserID());
                    settingsEditor.putInt(SettingFiles.AccessLvl, userDetailsCall.getAccessLvl());
                    settingsEditor.putString(SettingFiles.EmailVal, userDetailsCall.getEmailValue());
                    settingsEditor.putString(SettingFiles.FirstNameValue, userDetailsCall.getFirstNameValue());
                    settingsEditor.putString(SettingFiles.LastNameValue, userDetailsCall.getUserValue().getLastName());
                    settingsEditor.putBoolean(SettingFiles.Banned, userDetailsCall.isBanned());
                    settingsEditor.commit();

                    if (prefs.getInt(SettingFiles.AccessLvl, 0) == 1) {
                        startActivity(nextScreenNPO);
                    } else if (prefs.getInt(SettingFiles.AccessLvl, 0) == 3) {
                        startActivity(nextScreenBus);
                    } else if (prefs.getInt(SettingFiles.AccessLvl, 0) == 5) {
                        startActivity(nextScreenInd);
                    }
                }

                @Override
                public void failure(RetrofitError error) {
                    lblReturnText.setText("Your username and password combination is incorrect! Also check your connection settings!");
                }
            });
        } catch (NoSuchAlgorithmException e) {
            e.printStackTrace();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_login, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            startActivity(new Intent(this, SettingsActivity.class));
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
