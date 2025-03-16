namespace MSG_TNO.Model;

public enum TargetType {
    Unknown,
    Friendly,
    Hostile,
    Neutral
}

/// <summary>
/// Represents a target with a specified type.
/// </summary>
/// <param name="Type">The type of the target.</param>
public record Target(TargetType Type) {
    /// <summary>
    /// Determines if the target is hostile.
    /// </summary>
    /// <returns>True if the target type is Hostile, otherwise false.</returns>
    public bool IsHostile() => Type == TargetType.Hostile;

    /// <summary>
    /// Determines if the target is friendly.
    /// </summary>
    /// <returns>True if the target type is Friendly, otherwise false.</returns>
    public bool IsFriendly() => Type == TargetType.Friendly;

    /// <summary>
    /// Determines if the target is neutral.
    /// </summary>
    /// <returns>True if the target type is Neutral, otherwise false.</returns>
    public bool IsNeutral() => Type == TargetType.Neutral;

    /// <summary>
    /// Returns a string representation of the target.
    /// </summary>
    /// <returns>A string that represents the target.</returns>
    public override string ToString() => $"Target: {Type}";

}