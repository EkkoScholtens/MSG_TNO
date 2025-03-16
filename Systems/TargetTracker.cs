using MSG_TNO.Model;

namespace MSG_TNO.Systems;

public class TargetTracker {
    /// <summary>
    /// Initializes a new tracking target based on the provided time step data.
    /// </summary>
    /// <param name="step">The time step data used to identify the target type.</param>
    /// <returns>A new Target with the identified target type.</returns>
    public Target InitTrack(TimeStepData step) {
        return new Target(IdentifyFriendOrFoe(step));
    }

    /// <summary>
    /// Identifies whether the target is friendly or hostile based on the provided time step data.
    /// </summary>
    /// <param name="step">The time step data used to determine the target type.</param>
    /// <returns>The identified target type.</returns>
    private TargetType IdentifyFriendOrFoe(TimeStepData step) {
        var groups = step.Data.GroupBy(item => item % 2 == 0).ToList();
        var even = groups.First().Count();
        var odd = groups.Last().Count();

        return even > odd ? TargetType.Friendly : TargetType.Hostile;
    }
}