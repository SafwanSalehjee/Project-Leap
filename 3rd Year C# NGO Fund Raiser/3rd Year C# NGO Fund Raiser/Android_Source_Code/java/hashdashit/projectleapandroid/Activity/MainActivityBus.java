package hashdashit.projectleapandroid.Activity;

import android.content.Intent;
import android.content.SharedPreferences;
import android.support.design.widget.NavigationView;
import android.support.v4.app.Fragment;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.ActionBar;
import android.support.v7.app.ActionBarActivity;
import android.os.Bundle;
import android.support.v7.app.ActionBarDrawerToggle;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;

import hashdashit.projectleapandroid.API.Project_Leap_API;
import hashdashit.projectleapandroid.API.RestClient;
import hashdashit.projectleapandroid.Fragments.Business.DashboardBus;
import hashdashit.projectleapandroid.Fragments.Business.EventListBus;
import hashdashit.projectleapandroid.Fragments.Individual.DashboardInd;
import hashdashit.projectleapandroid.Fragments.Individual.VolIndListFragment;
import hashdashit.projectleapandroid.R;
import hashdashit.projectleapandroid.Settings.SettingFiles;


public class MainActivityBus extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener {

    private NavigationView mDrawer;
    private DrawerLayout mDrawerLayout;
    private ActionBarDrawerToggle mDrawerToggle;
    private int mNavClicked;
    private SharedPreferences prefs;
    private SharedPreferences.Editor settingsEditor;
    private Project_Leap_API api;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main_activity_bus);

        prefs = getSharedPreferences(SettingFiles.PREFERENCES, 0);
        settingsEditor = prefs.edit();
        RestClient client = new RestClient();
        RestClient.setBaseURL(prefs.getString(SettingFiles.IPAdderss, ""), prefs.getString(SettingFiles.PortNum, ""));
        client.updateRestClient();
        api = client.getApiService();

        TextView txtNameHeader = (TextView) findViewById(R.id.nameHeaderBus);
        TextView txtEmailHeader = (TextView) findViewById(R.id.emailHeaderBus);
        txtNameHeader.setText(prefs.getString(SettingFiles.FirstNameValue, "Name not found!") + " " + prefs.getString(SettingFiles.LastNameValue, "Surname not found!"));
        txtEmailHeader.setText(prefs.getString(SettingFiles.EmailVal, "No email found!"));

        ActionBar actionBar = getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(false);

        View mActionBarView = getLayoutInflater().inflate(R.layout.toolbar, null);
        actionBar.setCustomView(mActionBarView);
        actionBar.setDisplayOptions(ActionBar.DISPLAY_SHOW_CUSTOM);

        if (findViewById(R.id.fragment_container_bus) != null) {

            //Since coming back from previous state, re-adding fragments will create overlaps
            if (savedInstanceState != null)
                return;

            DashboardBus dashboardFragment = new DashboardBus();

            dashboardFragment.setArguments(getIntent().getExtras());
            getSupportFragmentManager()
                    .beginTransaction()
                    .add(R.id.fragment_container_bus, dashboardFragment)
                    .commit();
        }

        mDrawer = (NavigationView) findViewById(R.id.nav_drawer_bus);
        mDrawer.setNavigationItemSelectedListener(this);
        mDrawerLayout = (DrawerLayout) findViewById(R.id.drawer_layout_bus); //Allows for the drawer to be manipulated
        mDrawerToggle = new ActionBarDrawerToggle(this, //Allows for the action bar to be toggled on/off depending on nav drawer
                mDrawerLayout,
                R.string.navigation_drawer_open,
                R.string.navigation_drawer_close);
        mDrawerLayout.setDrawerListener(mDrawerToggle);
        mDrawerToggle.syncState();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main_activity_bus, menu);
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
            case R.id.navigation_item_bus_1:
                nextFragment = new DashboardBus();
                break;
            case R.id.navigation_item_bus_2:
                nextFragment = new EventListBus();
                break;
        }


        getSupportFragmentManager()
                .beginTransaction()
                .replace(R.id.fragment_container_bus, nextFragment)
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
}
