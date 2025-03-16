namespace MSG_TNO.Model;
public enum TargetType {
    Unknown,
    Friendly,
    Hostile,
    Neutral
}

public record Target(TargetType Type) {
    public bool IsHostile() => Type == TargetType.Hostile;
    public bool IsFriendly() => Type == TargetType.Friendly;
    public bool IsNeutral() => Type == TargetType.Neutral;
}