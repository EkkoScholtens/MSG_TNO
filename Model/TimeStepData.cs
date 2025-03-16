namespace MSG_TNO.Model;

/// <summary>
/// Represents a record containing data for a time step.
/// </summary>
/// <param name="Data">A list of integers representing the data for the time step.</param>
public record TimeStepData(List<int> Data) {
    /// <summary>Returns a string that represents the current object.</summary>
    /// <returns>A string that represents the current object.</returns>
    public override string ToString() {
        return string.Join(", ", Data);
    }
}