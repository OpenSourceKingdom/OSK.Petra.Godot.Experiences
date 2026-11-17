using Godot;
using OSK.Petra.Experiences.Objectives.Counter;

namespace OSK.Petra.Godot.Experiences.Data.Objectives.Counter;

/// <summary>
/// Provides access to variables that are required for limit counters (i.e. don't reach X quantity)
/// </summary>
[GlobalClass]
[Tool]
public partial class LimitObjectiveResource: CounterObjectiveResource
{
    /// <inheritdoc/>
    protected override CounterParameters GetParameters()
        => CounterParameters.Limit(Id, ThresholdValue, p =>
        {
            p.WithInitialValue(InitialValue)
             .WithDescription(GetDescription())
             .WithTags(GetTags())
             .WithTargets(GetTargetIds())
             .WithTextFormatter(TextFormatter);
            if (!IsRequired)
            {
                p.NotRequired();
            }
        });
}
