using Godot;
using OSK.Petra.Experiences.Objectives.Counter;

namespace OSK.Petra.Godot.Experiences.Data.Objectives.Counter;

/// <summary>
/// Provides access to variables that are required for goal counters (i.e. reach X quantity)
/// </summary>
[GlobalClass]
[Tool]
public partial class GoalObjectiveResource : CounterObjectiveResource
{
    #region CounterObjectiveResource Overrides

    /// <inheritdoc/>
    protected override CounterParameters GetParameters()
        => CounterParameters.Goal(Id, ThresholdValue, p =>
        {
            p.WithInitialValue(InitialValue)
             .WithName(Name)
             .WithDescription(GetDescription())
             .WithTags(GetTags())
             .WithTargets(GetTargetIds())
             .WithTextFormatter(TextFormatter);
            if (!IsRequired)
            {
                p.NotRequired();
            }
        });

    #endregion
}
