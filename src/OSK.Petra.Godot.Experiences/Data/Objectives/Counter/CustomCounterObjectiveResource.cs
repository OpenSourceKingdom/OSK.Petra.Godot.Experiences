using Godot;
using OSK.Petra.Experiences.Models;
using OSK.Petra.Experiences.Objectives.Counter;

namespace OSK.Petra.Godot.Experiences.Data.Objectives.Counter;

/// <summary>
/// Provides access to all counter variables to customize everything
/// </summary>
[GlobalClass]
[Tool]
public partial class CustomCounterObjectiveResource: CounterObjectiveResource
{
    #region Variables

    [Export]
    private ObjectiveExpectation _expectation;

    [Export]
    private ObjectiveResolutionBehavior _resolutionBehavior;

    [Export]
    private CountComparison _comparison;

    #endregion

    #region Constructors

    internal CustomCounterObjectiveResource(CounterParameters parameters)
        : base(parameters.Id, parameters.Name, parameters.Description, parameters.IsRequired, parameters.InitialValue, parameters.ThresholdValue, parameters.Tags, parameters.TargetIds, parameters.ValueFormatter)
    {
        _expectation = parameters.Expectation;
        _resolutionBehavior = parameters.GetEffectiveResolutionBehavior();
        _comparison = parameters.Comparison;
    }

    /// <summary>
    /// Editor constructor
    /// </summary>
    public CustomCounterObjectiveResource()
    {
    }

    #endregion

    #region CounterObjectiveResource Overrides

    /// <inheritdoc/>
    protected override CounterParameters GetParameters()
    {
        var parameters = new CounterParameters()
        {
            Id = Id,
            IsRequired = IsRequired,
            ThresholdValue = ThresholdValue,
            ResolutionBehavior = _resolutionBehavior,
            Expectation = _expectation
        };

        parameters.WithName(Name);
        parameters.WithDescription(GetDescription());
        parameters.WithTags(GetTags());
        parameters.WithTargets(GetTargetIds());
        parameters.WithInitialValue(InitialValue);
        parameters.WithComparison(_comparison);
        parameters.WithTextFormatter(TextFormatter);

        return parameters;
    }

    #endregion
}
