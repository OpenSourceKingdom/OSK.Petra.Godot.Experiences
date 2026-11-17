using Godot;
using OSK.Petra.Experiences.Objectives.Timer;

namespace OSK.Petra.Godot.Experiences.Data.Objectives.Timer;

/// <summary>
/// Configures a timer-that fails if it goes off
/// </summary>
[Tool]
[GlobalClass]
public partial class AlarmObjectiveResource : TimerObjectiveResource
{
    #region TimerObjectiveResource Overrides

    /// <inheritdoc/>
    protected override TimerParameters GetParameters()
        => TimerParameters.Alarm(Name, GetDescription(), Time, c =>
        {
            if (!IsRequired)
            {
                c.NotRequired();
            }
        });

    #endregion
}
