using Godot;
using OSK.Petra.Experiences.Models;
using OSK.Petra.Experiences.Objectives;
using OSK.Petra.Experiences.Objectives.Counter;
using System.Collections.Generic;
using System.Linq;

namespace OSK.Petra.Godot.Experiences.Data.Objectives.Counter;

/// <summary>
/// Allows configuring a counter objective from Godot
/// </summary>
[Tool]
[GlobalClass]
public abstract partial class CounterObjectiveResource : ChallengeObjectiveResource
{
    #region Variables
    
    /// <summary>
    /// The initial value for the counter
    /// </summary>
    [Export]
    protected long InitialValue { get; private set; }

    /// <summary>
    /// The value at which the counter comparison checks against
    /// </summary>
    [Export]
    protected long ThresholdValue { get; private set; }

    [Export]
    private string[] _tags;

    [Export]
    private string[] _targetIds;

    /// <summary>
    /// The custom text formatter for display text for the output
    /// </summary>
    protected IObjectiveTextFormatter<CounterParameters, CounterData> TextFormatter { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Editor constructor
    /// </summary>
    protected CounterObjectiveResource()
    {
    }

    /// <summary>
    /// Allows editing the resource via code
    /// </summary>
    /// <param name="id">The unique named key for the objective. Must be unique within the challenge</param>
    /// <param name="name">Name or title</param>
    /// <param name="description">Insightful text for the purpose of the objective</param>
    /// <param name="isRequired">Whether the objective is required to complete the challenge</param>
    /// <param name="initialValue">The initial value that the counter starts with</param>
    /// <param name="thresholdValue">The value the counter comparison compares to when checking for completion</param>
    /// <param name="tags">The tags the objective will use</param>
    /// <param name="targetIds">The targets the objective is tied to</param>
    /// <param name="textFormatter">The text formatter that is used for displaying the counter text</param>
    protected CounterObjectiveResource(string id, string name, string description, bool isRequired, long initialValue, long thresholdValue, IEnumerable<string> tags,
        IEnumerable<string> targetIds, IObjectiveTextFormatter<CounterParameters, CounterData> textFormatter)
        : base(id, name, description, isRequired)
    {
        InitialValue = initialValue;
        ThresholdValue = thresholdValue;
        _tags = tags?.ToArray() ?? [];
        _targetIds = targetIds?.ToArray() ?? [];
        TextFormatter = textFormatter;
    }

    #endregion

    #region ChallengeObjectiveResource

    /// <summary>
    /// Gets the effective tags for the objective
    /// </summary>
    /// <returns></returns>
    protected IEnumerable<string> GetTags() 
        => _tags?.Where(tag => !string.IsNullOrWhiteSpace(tag)) ?? [];

    /// <summary>
    /// Gets the effective targets for the objectives
    /// </summary>
    /// <returns></returns>
    protected IEnumerable<string> GetTargetIds()
        => _targetIds?.Where(targetId => !string.IsNullOrWhiteSpace(targetId)) ?? [];

    /// <summary>
    /// Converts the resource to the equivalent objective
    /// </summary>
    /// <returns></returns>
    public override IChallengeObjective GetObjective()
        => new CounterObjective(GetParameters());

    #endregion

    #region Helpers

    /// <summary>
    /// Gets the set of coubter parameters that represents this resource
    /// </summary>
    /// <returns>The   parameters</returns>
    protected abstract CounterParameters GetParameters();

    #endregion
}
