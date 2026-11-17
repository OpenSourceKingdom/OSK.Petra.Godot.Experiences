using Godot;
using OSK.Petra.Experiences.Models;
using OSK.Petra.Experiences.Objectives.Timer;
using OSK.Petra.Godot.Primitives.Data;

namespace OSK.Petra.Godot.Experiences.Data.Objectives.Timer;

/// <summary>
/// Provides access to configure timer objectives via Godot editor
/// </summary>
[GlobalClass]
[Tool]
public abstract partial class TimerObjectiveResource: ChallengeObjectiveResource
{
    #region Variables

    /// <summary>
    /// The timer's time value
    /// </summary>
    [Export]
    protected TimeSpanResource Time { get; set; }

    #endregion

    #region ChallengeObjectiveResource Overrides

    /// <inheritdoc/>
    public override IChallengeObjective GetObjective()
        => new TimerObjective(GetParameters());

    #endregion

    #region Helpers

    /// <summary>
    /// Gets the parameters for the timer objective
    /// </summary>
    /// <returns>The timer parameters</returns>
    protected abstract TimerParameters GetParameters();

    #endregion
}
