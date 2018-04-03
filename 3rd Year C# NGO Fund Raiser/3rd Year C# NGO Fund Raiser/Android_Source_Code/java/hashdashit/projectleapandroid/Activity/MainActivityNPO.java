package hashdashit.projectleapandroid.Activity;

import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.nfc.FormatException;
import android.nfc.NdefMessage;
import android.nfc.NdefRecord;
import android.nfc.NfcAdapter;
import android.nfc.Tag;
import android.nfc.tech.Ndef;
import android.support.design.widget.NavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBar;
import android.os.Bundle;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import java.io.IOException;
import java.io.UnsupportedEncodingException;

import hashdashit.projectleapandroid.API.Project_Leap_API;
import hashdashit.projectleapandroid.API.RestClient;
import hashdashit.projectleapandroid.Fragments.NPO.EventFragmentListNPO;
import hashdashit.projectleapandroid.Fragments.NPO.NPODashboardFragment;
import hashdashit.projectleapandroid.Fragments.NPO.VolunteerListNPOFragment;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


public class MainActivityNPO extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener {

    private NavigationView mDrawer;
    private DrawerLayout mDrawerLayout;
    private ActionBarDrawerToggle mDrawerToggle;
    private int mNavClicked;
    private SharedPreferences prefs;


    private NfcAdapter adapter;
    private PendingIntent pendingIntent;
    private IntentFilter writeTagFilters[];
    private boolean writeMode;
    private Tag mytag;
    private Context ctx;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_activity_npo);

        ctx=this;

        prefs = getSharedPreferences(SettingFiles.PREFERENCES, 0);
        RestClient client = new RestClient();
        RestClient.setBaseURL(prefs.getString(SettingFiles.IPAdderss, ""), prefs.getString(SettingFiles.PortNum, ""));
        client.updateRestClient();
        Project_Leap_API api = client.getApiService();

        api.getNPOID(prefs.getInt(SettingFiles.IDVal, 0), new Callback<Integer>() {
            @Override
            public void success(Integer integer, Response response) {
                SharedPreferences.Editor settingsEditor = prefs.edit();
                settingsEditor.putInt(SettingFiles.NPOID, integer);
                settingsEditor.commit();
            }

            @Override
            public void failure(RetrofitError error) {

            }
        });

        TextView txtNameHeader = (TextView)findViewById(R.id.nameHeader);
        TextView txtEmailHeader = (TextView)findViewById(R.id.emailHeader);
        txtNameHeader.setText(prefs.getString(SettingFiles.FirstNameValue, "Name not found!") + " " + prefs.getString(SettingFiles.LastNameValue, "Surname not found!"));
        txtEmailHeader.setText(prefs.getString(SettingFiles.EmailVal, "No email found!"));

        ActionBar actionBar = getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(false);

        View mActionBarView = getLayoutInflater().inflate(R.layout.toolbar, null);
        actionBar.setCustomView(mActionBarView);
        actionBar.setDisplayOptions(ActionBar.DISPLAY_SHOW_CUSTOM);

        if(findViewById(R.id.fragment_container) != null) {

            //Since coming back from previous state, re-adding fragments will create overlaps
            if(savedInstanceState != null)
                return;

            NPODashboardFragment dashboardFragment = new NPODashboardFragment();

            dashboardFragment.setArguments(getIntent().getExtras());
            getSupportFragmentManager()
                    .beginTransaction()
                    .add(R.id.fragment_container, dashboardFragment)
                    .commit();
        }

        mDrawer = (NavigationView) findViewById(R.id.nav_drawer);
        mDrawer.setNavigationItemSelectedListener(this);
        mDrawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout); //Allows for the drawer to be manipulated
        mDrawerToggle = new ActionBarDrawerToggle(this, //Allows for the action bar to be toggled on/off depending on nav drawer
                mDrawerLayout,
                R.string.navigation_drawer_open,
                R.string.navigation_drawer_close);
        mDrawerLayout.setDrawerListener(mDrawerToggle);
        mDrawerToggle.syncState();



        adapter = NfcAdapter.getDefaultAdapter(this);
        pendingIntent = PendingIntent.getActivity(this, 0, new Intent(this, getClass()).addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP), 0);
        IntentFilter tagDetected = new IntentFilter(NfcAdapter.ACTION_TAG_DISCOVERED);
        tagDetected.addCategory(Intent.CATEGORY_DEFAULT);
        writeTagFilters = new IntentFilter[] { tagDetected };
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main_activity_npo, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_logout) {
            SharedPreferences prefs = getSharedPreferences(SettingFiles.PREFERENCES, 0);
            SharedPreferences.Editor settingsEditor = prefs.edit();
            settingsEditor.putBoolean(SettingFiles.loggedIn, true);
            settingsEditor.putInt(SettingFiles.IDVal, 0);
            settingsEditor.putInt(SettingFiles.AccessLvl, 0);
            settingsEditor.putString(SettingFiles.EmailVal, "");
            settingsEditor.putString(SettingFiles.FirstNameValue, "");
            settingsEditor.putString(SettingFiles.LastNameValue, "");
            settingsEditor.putBoolean(SettingFiles.Banned, true);
            settingsEditor.commit();
            Intent startScreen = new Intent(this, LoginActivity.class);
            startActivity(startScreen);
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    private void startNext(int navClicked) {

        Fragment nextFragment = null;

        switch(navClicked) { //Determine which fragment to move to next
            case R.id.navigation_item_npo_1:
                nextFragment = new NPODashboardFragment();
                break;
            case R.id.navigation_item_npo_2:
                nextFragment = new VolunteerListNPOFragment();
                break;
            case R.id.navigation_item_npo_3:
                nextFragment = new EventFragmentListNPO();
                break;
        }


        getSupportFragmentManager()
                .beginTransaction()
                .replace(R.id.fragment_container, nextFragment)
                .commit();
    }

    @Override
    public void onBackPressed() {
        if(mDrawerLayout.isDrawerOpen(mDrawer))
            mDrawerLayout.closeDrawers();
        else
            super.onBackPressed();
    }

    @Override
    public boolean onNavigationItemSelected(MenuItem menuItem) {

        menuItem.setChecked(true);
        mNavClicked = menuItem.getItemId();
        mDrawerLayout.closeDrawer(mDrawer);
        startNext(mNavClicked);

        return true;
    }



    private void write(String text, Tag tag) throws IOException, FormatException {

        NdefRecord[] records = { createRecord(text) };
        NdefMessage message = new NdefMessage(records);
        // Get an instance of Ndef for the tag.
        Ndef ndef = Ndef.get(tag);
        // Enable I/O
        ndef.connect();
        // Write the message
        ndef.writeNdefMessage(message);
        // Close the connection
        ndef.close();
    }

    private NdefRecord createRecord(String text) throws UnsupportedEncodingException {
        String lang       = "en";
        byte[] textBytes  = text.getBytes();
        byte[] langBytes  = lang.getBytes("US-ASCII");
        int    langLength = langBytes.length;
        int    textLength = textBytes.length;
        byte[] payload    = new byte[1 + langLength + textLength];

        // set status byte (see NDEF spec for actual bits)
        payload[0] = (byte) langLength;

        // copy langbytes and textbytes into payload
        System.arraycopy(langBytes, 0, payload, 1,              langLength);
        System.arraycopy(textBytes, 0, payload, 1 + langLength, textLength);

        NdefRecord recordNFC = new NdefRecord(NdefRecord.TNF_WELL_KNOWN,  NdefRecord.RTD_TEXT,  new byte[0], payload);

        return recordNFC;
    }


    @Override
    protected void onNewIntent(Intent intent){
        if(NfcAdapter.ACTION_TAG_DISCOVERED.equals(intent.getAction())){
            mytag = intent.getParcelableExtra(NfcAdapter.EXTRA_TAG);
            Toast.makeText(this, this.getString(R.string.ok_detection) + mytag.toString(), Toast.LENGTH_SHORT).show();
            try {
                write(String.valueOf(prefs.getInt(SettingFiles.NPOID, 0)) , mytag);
                Toast.makeText(ctx, ctx.getString(R.string.ok_writing), Toast.LENGTH_SHORT ).show();
            }
            catch (Exception ex)
            {
                Toast.makeText(ctx, ctx.getString(R.string.error_writing), Toast.LENGTH_LONG ).show();
            }
        }
    }

    @Override
    public void onPause(){
        super.onPause();
        WriteModeOff();
    }

    @Override
    public void onResume(){
        super.onResume();
        WriteModeOn();
    }

    private void WriteModeOn(){
        writeMode = true;
        adapter.enableForegroundDispatch(this, pendingIntent, writeTagFilters, null);
    }

    private void WriteModeOff(){
        writeMode = false;
        adapter.disableForegroundDispatch(this);
    }
}
