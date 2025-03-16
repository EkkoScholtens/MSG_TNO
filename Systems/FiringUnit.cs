using MSG_TNO.Model;

namespace MSG_TNO.Systems;

/// <summary>
/// Represents a missile system launch system.
/// </summary>
public class FiringUnit(double pk) {
    /// <summary>
    /// Fires a missile at the specified target.
    /// </summary>
    /// <param name="target">The target to be fired at.</param>
    /// <returns>A new Missile instance targeting the specified target.</returns>
    public Missile FireMissile(Target target) {
        return new Missile(target, pk);
    }
}