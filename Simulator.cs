using MSG_TNO.Model;
using MSG_TNO.Systems;

namespace MSG_TNO;

public class Simulator(List<TimeStepData> data, Simulation simulation) {
    private int _tick;
    private PeriodicTimer _periodicTimer = new(simulation.TickTime);
    private TargetTracker _targetTracker = new();
    private MissileSystem _missileSystem = new(simulation.Pk);
    public async Task Run() {
        _tick = 0;
        _periodicTimer = new PeriodicTimer(simulation.TickTime);
        _targetTracker = new TargetTracker();
        _missileSystem = new MissileSystem(simulation.Pk);
        while (await _periodicTimer.WaitForNextTickAsync() && _tick < simulation.Ticks) {
            DoTimeStep();
            _tick++;
        }
        
        _periodicTimer.Dispose();
    }

    private void DoTimeStep() {
        Console.WriteLine($"TimeStep {_tick+1}");
        var target = _targetTracker.InitTrack(data[_tick]);
        if (target.IsHostile()) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine($"\t Target is hostile, firing missile...");
            var missile = _missileSystem.FireMissile(target);
            
            Console.ForegroundColor = missile.State == MissileState.Missed ? ConsoleColor.Red : ConsoleColor.Green;
            
            Console.WriteLine($"\t {missile}");
            if (missile.State == MissileState.Hit) Console.WriteLine("\t Target is neutralized");
            
            Console.ResetColor();

        }

    }

}