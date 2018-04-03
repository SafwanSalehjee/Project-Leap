package hashdashit.projectleapandroid.Activity;

import android.app.Activity;
import android.content.SharedPreferences;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.EditText;
import android.widget.SeekBar;
import android.widget.TextView;

import hashdashit.projectleapandroid.API.RestClient;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;


public class SettingsActivity extends ActionBarActivity {

    EditText txtIP;
    EditText txtPort;
    TextView lblSaved;
    SharedPreferences prefs;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_settings);

        txtIP = (EditText)findViewById(R.id.txtIP);
        txtPort = (EditText)findViewById(R.id.txtPort);
        lblSaved = (TextView)findViewById(R.id.lblSave);

        prefs = getSharedPreferences(SettingFiles.PREFERENCES, 0);

        if(prefs.getString(SettingFiles.IPAdderss, "").equals(""))
        {
            SharedPreferences.Editor settingsEditor = prefs.edit();
            settingsEditor.putString(SettingFiles.IPAdderss, "192.168.1.73");
            settingsEditor.commit();
        }
        if(prefs.getString(SettingFiles.PortNum, "").equals(""))
        {
            SharedPreferences.Editor settingsEditor = prefs.edit();
            settingsEditor.putString(SettingFiles.PortNum, "53319");
            settingsEditor.commit();
        }

        RestClient.setBaseURL(prefs.getString(SettingFiles.IPAdderss, ""), prefs.getString(SettingFiles.PortNum, ""));

        txtIP.setText(prefs.getString(SettingFiles.IPAdderss, "No IP Value found"));
        txtPort.setText(prefs.getString(SettingFiles.PortNum, "No Port value found"));

        ActionBar actionBar = getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(false);

        View mActionBarView = getLayoutInflater().inflate(R.layout.toolbar, null);
        actionBar.setCustomView(mActionBarView);
        actionBar.setDisplayOptions(ActionBar.DISPLAY_SHOW_CUSTOM);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_settings, menu);
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

    public void btnSave(View v){
        EditText txtIP = (EditText)findViewById(R.id.txtIP);
        EditText txtPort = (EditText)findViewById(R.id.txtPort);

        SharedPreferences.Editor settingsEditor = prefs.edit();
        settingsEditor.putString(SettingFiles.IPAdderss, txtIP.getText().toString());
        settingsEditor.putString(SettingFiles.PortNum, txtPort.getText().toString());
        settingsEditor.commit();
        lblSaved.setText("Settings saved!");
        RestClient.setBaseURL(prefs.getString(SettingFiles.IPAdderss, ""), prefs.getString(SettingFiles.PortNum, ""));
        txtIP.setText(prefs.getString(SettingFiles.IPAdderss, ""));
        txtPort.setText(prefs.getString(SettingFiles.PortNum, ""));
    }
}
