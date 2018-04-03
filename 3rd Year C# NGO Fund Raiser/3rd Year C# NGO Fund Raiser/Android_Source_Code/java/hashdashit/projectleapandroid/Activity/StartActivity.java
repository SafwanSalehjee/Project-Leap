package hashdashit.projectleapandroid.Activity;

import android.app.Activity;
import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.Toast;

import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;


public class StartActivity extends Activity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_start);

        Intent startScreen = null;

        SharedPreferences prefs = getSharedPreferences(SettingFiles.PREFERENCES, 0);
        if(prefs.getBoolean(SettingFiles.loggedIn, false)) {
            if (prefs.getInt(SettingFiles.AccessLvl, 0) == 1) {
                startScreen = new Intent(this, MainActivityNPO.class);
            } else if (prefs.getInt(SettingFiles.AccessLvl, 0) == 3) {
                startScreen = new Intent(this, MainActivityBus.class);
            } else if (prefs.getInt(SettingFiles.AccessLvl, 0) == 5) {
                startScreen = new Intent(this, MainActivityInd.class);
            }
            else if (prefs.getInt(SettingFiles.AccessLvl, 0) == 6 || prefs.getInt(SettingFiles.AccessLvl, 0) == 7 || prefs.getInt(SettingFiles.AccessLvl, 0) == 4 || prefs.getInt(SettingFiles.AccessLvl, 0) == 2) {
                SharedPreferences.Editor settingsEditor = prefs.edit();
                settingsEditor.putBoolean(SettingFiles.loggedIn, true);
                settingsEditor.putInt(SettingFiles.IDVal, 0);
                settingsEditor.putInt(SettingFiles.AccessLvl, 0);
                settingsEditor.putString(SettingFiles.EmailVal, "");
                settingsEditor.putString(SettingFiles.FirstNameValue, "");
                settingsEditor.putString(SettingFiles.LastNameValue, "");
                settingsEditor.putBoolean(SettingFiles.Banned, true);
                settingsEditor.commit();
                startScreen = new Intent(this, LoginActivity.class);
            }
            else {
                startScreen = new Intent(this, LoginActivity.class);
            }
        }
        else {
            startScreen = new Intent(this, LoginActivity.class);
        }

        startActivity(startScreen);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_start, menu);
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
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
