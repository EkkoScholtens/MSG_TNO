namespace MSG_TNO.Model;

/// <summary>
/// Represents a simulation with a given Probability of Kill (Pk) ratio, number of ticks to run, and time between ticks.
/// </summary>
/// <param name="Pk">The Probability of Kill ratio for the simulation.</param>
/// <param name="Ticks">The number of ticks to run the simulation.</param>
/// <param name="TickTime">The time between ticks in the simulation.</param>
public record Simulation(double Pk, int Ticks, TimeSpan TickTime);