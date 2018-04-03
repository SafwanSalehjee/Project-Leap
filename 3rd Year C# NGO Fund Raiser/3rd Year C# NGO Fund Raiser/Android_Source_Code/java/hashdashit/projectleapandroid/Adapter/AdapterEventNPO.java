package hashdashit.projectleapandroid.Adapter;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.TextView;

import java.util.List;

import hashdashit.projectleapandroid.Model.MobileEventCall;
import hashdashit.projectleapandroid.Model.VolunteerCall;
import hashdashit.projectleapandroid.R;

/**
 * Created by Wald on 2015-08-09.
 */
public class AdapterEventNPO extends BaseAdapter{

    private Activity activity;
    private List<MobileEventCall> data;
    private static LayoutInflater inflater = null;
    public static int counterEventNPO = 0;

    public AdapterEventNPO(Activity a, List<MobileEventCall> d) {
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
            vi = inflater.inflate(R.layout.event_row, null);

        TextView name = (TextView)vi.findViewById(R.id.lblEventNameValRow);
        TextView location = (TextView)vi.findViewById(R.id.lblLocationValRow);
        TextView time = (TextView)vi.findViewById(R.id.lblTimeEventValRow);
        TextView date = (TextView)vi.findViewById(R.id.lblDateVolRow);

        if(counterEventNPO < data.size())
        {
            name.setText(data.get(counterEventNPO).getName());
            location.setText(data.get(counterEventNPO).getLocation());
            time.setText("" + data.get(counterEventNPO).getTime());
            date.setText("" + data.get(counterEventNPO).getDate());

            counterEventNPO++;
        }

        return vi;
    }
}
