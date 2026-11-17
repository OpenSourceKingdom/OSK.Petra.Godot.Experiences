using Godot;
using OSK.Petra.Experiences.Objectives.Timer;

namespace OSK.Petra.Godot.Experiences.Data.Objectives.Timer;

/// <summary>
/// Configures a timer that fails if the duratin is not met
/// </summary>
[Tool]
[GlobalClass]
public partial class DurationObjectiveResource: TimerObjectiveResource
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
