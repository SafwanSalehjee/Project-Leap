package hashdashit.projectleapandroid.Activity;

import android.app.PendingIntent;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.SharedPreferences;
import android.nfc.NdefMessage;
import android.nfc.NdefRecord;
import android.nfc.NfcAdapter;
import android.nfc.Tag;
import android.nfc.tech.Ndef;
import android.os.AsyncTask;
import android.support.design.widget.NavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBar;
import android.os.Bundle;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import java.io.UnsupportedEncodingException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.concurrent.TimeUnit;

import hashdashit.projectleapandroid.API.Project_Leap_API;
import hashdashit.projectleapandroid.API.RestClient;
import hashdashit.projectleapandroid.Fragments.Individual.DashboardInd;
import hashdashit.projectleapandroid.Fragments.Individual.VolIndListFragment;
import hashdashit.projectleapandroid.Fragments.NPO.EventFragmentListNPO;
import hashdashit.projectleapandroid.Fragments.NPO.NPODashboardFragment;
import hashdashit.projectleapandroid.Fragments.NPO.VolunteerListNPOFragment;
import hashdashit.projectleapandroid.Model.VolunteerCall;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;
import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;


public class MainActivityInd extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener {

    private NavigationView mDrawer;
    private DrawerLayout mDrawerLayout;
    private ActionBarDrawerToggle mDrawerToggle;
    private int mNavClicked;
    private SharedPreferences prefs;
    private SharedPreferences.Editor settingsEditor;
    private Project_Leap_API api;


    public static final String MIME_TEXT_PLAIN = "text/plain";
    public static final String TAG = "NPOTag";
    public NfcAdapter mNfcAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_activity_ind);


        mNfcAdapter = NfcAdapter.getDefaultAdapter(this);

        if (mNfcAdapter == null) {
            // Stop here, we definitely need NFC
            Toast.makeText(this, "This device doesn't support NFC.", Toast.LENGTH_LONG).show();
            finish();
            return;

        }


        prefs = getSharedPreferences(SettingFiles.PREFERENCES, 0);
        settingsEditor = prefs.edit();
        RestClient client = new RestClient();
        RestClient.setBaseURL(prefs.getString(SettingFiles.IPAdderss, ""), prefs.getString(SettingFiles.PortNum, ""));
        client.updateRestClient();
        api = client.getApiService();

        TextView txtNameHeader = (TextView) findViewById(R.id.nameHeaderInd);
        TextView txtEmailHeader = (TextView) findViewById(R.id.emailHeaderInd);
        txtNameHeader.setText(prefs.getString(SettingFiles.FirstNameValue, "Name not found!") + " " + prefs.getString(SettingFiles.LastNameValue, "Surname not found!"));
        txtEmailHeader.setText(prefs.getString(SettingFiles.EmailVal, "No email found!"));

        ActionBar actionBar = getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(false);

        View mActionBarView = getLayoutInflater().inflate(R.layout.toolbar, null);
        actionBar.setCustomView(mActionBarView);
        actionBar.setDisplayOptions(ActionBar.DISPLAY_SHOW_CUSTOM);

        if (findViewById(R.id.fragment_container_ind) != null) {

            //Since coming back from previous state, re-adding fragments will create overlaps
            if (savedInstanceState != null)
                return;

            DashboardInd dashboardFragment = new DashboardInd();

            dashboardFragment.setArguments(getIntent().getExtras());
            getSupportFragmentManager()
                    .beginTransaction()
                    .add(R.id.fragment_container_ind, dashboardFragment)
                    .commit();
        }

        mDrawer = (NavigationView) findViewById(R.id.nav_drawer_ind);
        mDrawer.setNavigationItemSelectedListener(this);
        mDrawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout_ind); //Allows for the drawer to be manipulated
        mDrawerToggle = new ActionBarDrawerToggle(this, //Allows for the action bar to be toggled on/off depending on nav drawer
                mDrawerLayout,
                R.string.navigation_drawer_open,
                R.string.navigation_drawer_close);
        mDrawerLayout.setDrawerListener(mDrawerToggle);
        mDrawerToggle.syncState();


        if (!mNfcAdapter.isEnabled()) {
            Toast.makeText(this, "NFC is disabled.", Toast.LENGTH_LONG).show();
        }

        handleIntent(getIntent());
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main_activity_ind, menu);
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

        switch (navClicked) { //Determine which fragment to move to next
            case R.id.navigation_item_ind_1:
                nextFragment = new DashboardInd();
                break;
            case R.id.navigation_item_ind_2:
                nextFragment = new VolIndListFragment();
                break;
        }


        getSupportFragmentManager()
                .beginTransaction()
                .replace(R.id.fragment_container_ind, nextFragment)
                .commit();
    }

    @Override
    public void onBackPressed() {
        if (mDrawerLayout.isDrawerOpen(mDrawer))
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


    @Override
    protected void onResume() {
        super.onResume();

        setupForegroundDispatch(this, mNfcAdapter);
    }

    @Override
    protected void onPause() {
        stopForegroundDispatch(this, mNfcAdapter);

        super.onPause();
    }

    @Override
    protected void onNewIntent(Intent intent) {
        handleIntent(intent);
    }

    private void handleIntent(Intent intent) {
        String action = intent.getAction();
        if (NfcAdapter.ACTION_NDEF_DISCOVERED.equals(action)) {

            String type = intent.getType();
            if (MIME_TEXT_PLAIN.equals(type)) {

                Tag tag = intent.getParcelableExtra(NfcAdapter.EXTRA_TAG);
                new NdefReaderTask().execute(tag);

            } else {
                Log.d(TAG, "Wrong mime type: " + type);
            }
        } else if (NfcAdapter.ACTION_TECH_DISCOVERED.equals(action)) {

            // In case we would still use the Tech Discovered Intent
            Tag tag = intent.getParcelableExtra(NfcAdapter.EXTRA_TAG);
            String[] techList = tag.getTechList();
            String searchedTech = Ndef.class.getName();

            for (String tech : techList) {
                if (searchedTech.equals(tech)) {
                    new NdefReaderTask().execute(tag);
                    break;
                }
            }
        }

    }

    public static void setupForegroundDispatch(final MainActivityInd activity, NfcAdapter adapter) {
        final Intent intent = new Intent(activity.getApplicationContext(), activity.getClass());
        intent.setFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        final PendingIntent pendingIntent = PendingIntent.getActivity(activity.getApplicationContext(), 0, intent, 0);

        IntentFilter[] filters = new IntentFilter[1];
        String[][] techList = new String[][]{};

        filters[0] = new IntentFilter();
        filters[0].addAction(NfcAdapter.ACTION_NDEF_DISCOVERED);
        filters[0].addCategory(Intent.CATEGORY_DEFAULT);
        try {
            filters[0].addDataType(MIME_TEXT_PLAIN);
        } catch (IntentFilter.MalformedMimeTypeException e) {
            throw new RuntimeException("Check your mime type.");
        }

        adapter.enableForegroundDispatch(activity, pendingIntent, filters, techList);
    }

    public static void stopForegroundDispatch(final MainActivityInd activity, NfcAdapter adapter) {
        adapter.disableForegroundDispatch(activity);
    }

    private class NdefReaderTask extends AsyncTask<Tag, Void, String> {

        @Override
        protected String doInBackground(Tag... params) {
            Tag tag = params[0];

            Ndef ndef = Ndef.get(tag);
            if (ndef == null) {
                return null;
            }

            NdefMessage ndefMessage = ndef.getCachedNdefMessage();

            NdefRecord[] records = ndefMessage.getRecords();
            for (NdefRecord ndefRecord : records) {
                if (ndefRecord.getTnf() == NdefRecord.TNF_WELL_KNOWN && Arrays.equals(ndefRecord.getType(), NdefRecord.RTD_TEXT)) {
                    try {
                        return readText(ndefRecord);
                    } catch (UnsupportedEncodingException e) {
                        Log.e(TAG, "Unsupported Encoding", e);
                    }
                }
            }

            return null;
        }

        private String readText(NdefRecord record) throws UnsupportedEncodingException {

            byte[] payload = record.getPayload();

            String u8 = "UTF-8";
            String u16 = "UTF-16";

            String textEncoding = ((payload[0] & 128) == 0) ? u8 : u16;

            int languageCodeLength = payload[0] & 0063;
            return new String(payload, languageCodeLength + 1, payload.length - languageCodeLength - 1, textEncoding);
        }

        @Override
        protected void onPostExecute(final String result) {
            if (result != null) {
                Toast.makeText(MainActivityInd.this, "NFC Scanned", Toast.LENGTH_SHORT).show();

                int swipeCount = prefs.getInt(SettingFiles.SwipeCount, 0);

                if(swipeCount == 0)
                {
                    settingsEditor.putInt(SettingFiles.SwipeCount, 1);
                    settingsEditor.putLong(SettingFiles.SwipeTime, System.currentTimeMillis());
                    settingsEditor.commit();
                    Toast.makeText(MainActivityInd.this, "Volunteer start time logged!", Toast.LENGTH_LONG).show();
                }
                else if(swipeCount == 1)
                {
                    long startTime = prefs.getLong(SettingFiles.SwipeTime, 0);
                    long currentTime = System.currentTimeMillis();
                    long timeDifference = currentTime - startTime;

                    if(timeDifference < TimeUnit.MILLISECONDS.convert(1, TimeUnit.DAYS))
                    {
                        long hours = TimeUnit.MILLISECONDS.toHours(timeDifference);

                        if(hours < 1 && timeDifference > 0)
                        {
                            hours = 1;
                        }

                        final int finalHours = (int)hours;
                        api.getVolunteerUser(prefs.getInt(SettingFiles.IDVal, 0), new Callback<List<VolunteerCall>>() {
                            @Override
                            public void success(List<VolunteerCall> volunteerCalls, Response response) {

                                Calendar c = Calendar.getInstance();

                                SimpleDateFormat df = new SimpleDateFormat("M/dd/yyyy");
                                String formattedDate = df.format(c.getTime());

                                for(int a = 0; a < volunteerCalls.size(); a++)
                                {
                                    try {
                                        if(volunteerCalls.get(a).getOrgID() == Integer.parseInt(result))
                                        {
                                            if(volunteerCalls.get(a).getShortDate().equals(formattedDate)) {

                                                api.CaptureVolTimeMobile(volunteerCalls.get(a).getVolunteerID(), finalHours, "Thanks for volunteering.", new Callback<Boolean>() {
                                                    @Override
                                                    public void success(Boolean aBoolean, Response response) {
                                                        if(aBoolean)
                                                        {
                                                            Toast.makeText(MainActivityInd.this, "Attendance registered!", Toast.LENGTH_LONG).show();
                                                        }
                                                        else
                                                        {
                                                            Toast.makeText(MainActivityInd.this, "Hours not logged!", Toast.LENGTH_LONG).show();
                                                        }

                                                    }

                                                    @Override
                                                    public void failure(RetrofitError error) {

                                                    }
                                                });
                                            }
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Toast.makeText(MainActivityInd.this, "This is not an NPO tag!", Toast.LENGTH_LONG).show();
                                    }
                                }
                            }

                            @Override
                            public void failure(RetrofitError error) {

                            }
                        });

                        Toast.makeText(MainActivityInd.this, "Hours worked " + hours, Toast.LENGTH_LONG).show();
                    }
                    else
                    {
                        Toast.makeText(MainActivityInd.this, "You fail to log your volunteer time in a day. Your data has been reset!", Toast.LENGTH_LONG).show();
                    }

                    settingsEditor.putInt(SettingFiles.SwipeCount, 0);
                    settingsEditor.putLong(SettingFiles.SwipeTime, 0);
                    settingsEditor.commit();
                }
                else
                {
                    Toast.makeText(MainActivityInd.this, "Something whent wrong with the NFC swipe!", Toast.LENGTH_LONG).show();
                }
            }
        }
    }
}
