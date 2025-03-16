namespace MSG_TNO.Model;

/// <summary>
/// Represents a record containing data for a time step.
/// </summary>
public record TimeStepData(List<int> Data) {
    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() {
        return string.Join(", ", Data);
    }
}