package hashdashit.projectleapandroid.Model;

import com.google.gson.annotations.Expose;

/**
 * Created by Wald on 2015-08-08.
 */
public class MobileFCCall {

    @Expose
    private double Current;

    @Expose
    private double Target;

    public double getCurrent() {
        return Current;
    }

    public void setCurrent(double current) {
        Current = current;
    }

    public double getTarget() {
        return Target;
    }

    public void setTarget(double target) {
        Target = target;
    }
}
