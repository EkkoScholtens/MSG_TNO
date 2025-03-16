using MSG_TNO.Model;

namespace MSG_TNO.Systems;
/// <summary>
/// Represents a radar system.
/// </summary>
public class Radar(List<RadarData> data) {

    /// <summary>
    /// Returns the radar data for the specified tick.
    /// </summary>
    /// <param name="tick">The tick to retrieve the radar data for.</param>
    /// <returns>The radar data for the specified tick.</returns>
    public RadarData Scan(int tick) {
        return data[tick];
    }
}