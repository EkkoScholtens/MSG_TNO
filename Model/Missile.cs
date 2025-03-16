namespace MSG_TNO.Model;

/// <summary>
/// Enumeration representing the possible states of a missile.
/// </summary>
public enum MissileState
{
    Idle,
    Flying,
    Hit,
    Missed
}

/// <summary>
/// Represents a missile with a target and a probability of hitting the target.
/// </summary>
public class Missile(Target target, double pk) {
    /// <summary>
    /// Gets the success probability of the missile hitting the target.
    /// </summary>
    /// <returns>A random double value between 0.0 and 1.0.</returns>
    private static double GetSuccessProbability() {
        var rand = new Random();
        return rand.NextDouble() * (1.0 - 0.0) + 0.0;
    }

    /// <summary>
    /// Gets the target of the missile.
    /// </summary>
    public Target Target { get; } = target;

    /// <summary>
    /// Gets the probability of the missile hitting the target.
    /// </summary>
    public double Pk { get; } = pk;

    /// <summary>
    /// Gets or sets the current state of the missile.
    /// </summary>
    public MissileState State { get; set; } = GetSuccessProbability() < pk ? MissileState.Hit : MissileState.Missed;
    
    /// <summary>
    /// Returns a string that represents the current state of the missile.
    /// </summary>
    /// <returns>A string representing the missile's state.</returns>
    public override string ToString() {
        return $"Missile: {State}";
    }
}