package hashdashit.projectleapandroid.Adapter;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

import hashdashit.projectleapandroid.Model.VolunteerCall;
import hashdashit.projectleapandroid.R;

/**
 * Created by Wald on 2015-08-10.
 */
public class AdapterVolInd extends BaseAdapter {

    private Activity activity;
    private List<VolunteerCall> data;
    private static LayoutInflater inflater = null;
    public static int counterVolInd = 0;

    public AdapterVolInd(Activity a, List<VolunteerCall> d) {
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
            vi = inflater.inflate(R.layout.volunteer_row_ind, null);

        TextView orgName = (TextView)vi.findViewById(R.id.lblOrgNameVol);
        TextView hours = (TextView)vi.findViewById(R.id.lblHoursVol);
        TextView date = (TextView)vi.findViewById(R.id.lblDateVol);

        if(counterVolInd < data.size())
        {
            orgName.setText(data.get(counterVolInd).getOrnName());
            hours.setText("Hours: " + data.get(counterVolInd).getHours());
            date.setText("" + data.get(counterVolInd).getShortDate());

            counterVolInd++;
        }

        return vi;
    }
}