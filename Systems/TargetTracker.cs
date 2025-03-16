using MSG_TNO.Model;

namespace MSG_TNO.Systems;

public class TargetTracker {
    /// <summary>
    /// Initializes a new tracking target based on the provided radar data.
    /// </summary>
    /// <param name="data">The radar data used to identify the target type.</param>
    /// <returns>A new Target with the identified target type.</returns>
    public Target InitTrack(RadarData data) {
        return new Target(IdentifyFriendOrFoe(data));
    }

    /// <summary>
    /// Identifies whether the target is friendly or hostile based on the provided radar data.
    /// </summary>
    /// <param name="step">The radar data used to determine the target type.</param>
    /// <returns>The identified target type.</returns>
    private TargetType IdentifyFriendOrFoe(RadarData step) {
        var groups = step.Data.GroupBy(item => item % 2 == 0).ToList();
        var even = groups.First().Count();
        var odd = groups.Last().Count();

        return even > odd ? TargetType.Friendly : TargetType.Hostile;
    }
}