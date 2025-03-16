using MSG_TNO.Model;

namespace MSG_TNO.Systems;

public class TargetTracker {
    public Target InitTrack(TimeStepData step) {
        return new Target( IdentifyFriendOrFoe(step));
    }
    private TargetType IdentifyFriendOrFoe(TimeStepData step) {
        var groups = step.Data.GroupBy(item => item % 2 == 0).ToList();
        var even = groups.First().Count();
        var odd = groups.Last().Count();
        
        if (even > odd)
            return TargetType.Friendly;
        if (even < odd)
            return TargetType.Hostile;
        return TargetType.Neutral;
    }

}