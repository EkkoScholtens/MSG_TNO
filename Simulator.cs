using MSG_TNO.Model;
using MSG_TNO.Systems;

namespace MSG_TNO;

public class Simulator(List<RadarData> data, Simulation simulation) {
    private int _tick;
    private PeriodicTimer _periodicTimer = new(simulation.TickTime);
    private TargetTracker _targetTracker = new();
    private FiringUnit _firingUnit = new(simulation.Pk);
    private Radar _radar  = new(data);

    public async Task Run() {
        _tick = 0;
        _periodicTimer = new PeriodicTimer(simulation.TickTime);
        _targetTracker = new TargetTracker();
        _firingUnit = new FiringUnit(simulation.Pk);
        _radar = new Radar(data);
        while (await _periodicTimer.WaitForNextTickAsync() && _tick < simulation.Ticks) {
            DoTimeStep();
            _tick++;
        }

        _periodicTimer.Dispose();
    }

    private void DoTimeStep() {
        Console.ResetColor();
        Console.WriteLine($"TimeStep {_tick + 1}");
        var scanResult = _radar.Scan(_tick);
        var target = _targetTracker.InitTrack(scanResult);

        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine($"\t {target}");

        if (target.IsFriendly()) return;
        
        Console.WriteLine($"\t Target is hostile, firing missile...");
        var missile = _firingUnit.FireMissile(target);

        Console.ForegroundColor = missile.State == MissileState.Missed ? ConsoleColor.Red : ConsoleColor.Green;

        Console.WriteLine($"\t {missile}");
        if (missile.State == MissileState.Hit) Console.WriteLine("\t Target is neutralized");

    }
}