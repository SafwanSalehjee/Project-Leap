package hashdashit.projectleapandroid.Adapter;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import hashdashit.projectleapandroid.Model.VolunteerCall;
import hashdashit.projectleapandroid.R;

/**
 * Created by Wald on 2015-08-06.
 */
public class AdapterVolNPO extends BaseAdapter{

    private Activity activity;
    private List<VolunteerCall> data;
    private static LayoutInflater inflater = null;
    public static int counterVolNPO = 0;

    public AdapterVolNPO(Activity a, List<VolunteerCall> d) {
        activity = a;
        data = d;
        inflater = (LayoutInflater)activity.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
    }

    public int getCount() {
        return data.size();
    }

    public Object getItem(int position) {
        return position;
    }

    public long getItemId(int position) {
        return position;
    }

    public View getView(int position, View convertView, ViewGroup parent) {

        View vi = convertView;

        if(convertView == null)
            vi = inflater.inflate(R.layout.volunteer_row_npo, null);

        TextView email = (TextView)vi.findViewById(R.id.lblEmailVol);
        TextView nameSurname = (TextView)vi.findViewById(R.id.lblNameSurnameVol);
        TextView date = (TextView)vi.findViewById(R.id.lblDateVol);

        if(counterVolNPO < data.size())
        {
            email.setText(data.get(counterVolNPO).getUserEmail());
            nameSurname.setText(data.get(counterVolNPO).getUserFN() + " " + data.get(counterVolNPO).getUserLN());
            date.setText("" + data.get(counterVolNPO).getShortDate());

            counterVolNPO++;
        }

        return vi;
    }
}
