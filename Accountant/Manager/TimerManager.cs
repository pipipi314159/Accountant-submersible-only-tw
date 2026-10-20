using System;
using System.Linq;
using Accountant.Enums;
using Accountant.Gui.Timer;
using Accountant.Timers;
using Accountant.Util;

namespace Accountant.Manager;

public partial class TimerManager
{ }

public sealed partial class TimerManager : IDisposable
{
    public interface ITimerManager : IDisposable
    {
        public void                  SetState();
        public TimerWindow.BaseCache CreateCache(TimerWindow window);
    }

    public readonly RetainerTimers      RetainerTimers    = new();
    public readonly PlotCropTimers      PlotCropTimers    = new();
    public readonly PrivateCropTimers   PrivateCropTimers = new();
    public readonly SubmersibleTimers   SubmersibleTimers = new();
    public readonly AirshipTimers       AirshipTimers     = new();
    public readonly WheelTimers         WheelTimers       = new();
    public readonly TaskTimers          TaskTimers        = new();
    public readonly FreeCompanyStorage  CompanyStorage    = FreeCompanyStorage.Load();

    private readonly ITimerManager[] _managers;

    public TimerManager()
    {
        _managers =
        [
            new SubmersibleManager(SubmersibleTimers, AirshipTimers, CompanyStorage),
        ];
    }

    // Submersible-only build: TimerWindow and DtrManager still expect the retainer, crop and airship caches to exist,
    // so they are created, but with a flag that is never set so that they are never drawn.
    private const ConfigFlags HiddenFlags = ConfigFlags.Enabled | (ConfigFlags)0x40000000;

    public TimerWindow.BaseCache[] CreateCaches(TimerWindow window)
    {
        TimerWindow.BaseCache[] caches =
        [
            new TimerWindow.RetainerCache(window, HiddenFlags, RetainerTimers),
            new TimerWindow.CropCache(window, HiddenFlags, PlotCropTimers, PrivateCropTimers),
            new TimerWindow.MachineCache(window, HiddenFlags, "Airships", MachineType.Airship, AirshipTimers, SubmersibleTimers),
            .. _managers.Select(m => m.CreateCache(window)),
        ];
        return caches;
    }

    public void CheckSettings()
    {
        foreach (var manager in _managers)
            manager.SetState();
    }

    public void Dispose()
    {
        foreach (var manager in _managers)
            manager.Dispose();
    }
}
