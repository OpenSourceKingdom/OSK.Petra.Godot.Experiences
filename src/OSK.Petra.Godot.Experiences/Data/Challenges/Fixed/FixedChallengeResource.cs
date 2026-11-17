using Godot;
using OSK.Petra.Experiences.Models;
using System.Collections.Generic;
using System.Linq;

namespace OSK.Petra.Godot.Experiences.Data.Challenges.Simple;

/// <summary>
/// Allows configuring a fixed challenge. A fixed challenge does not account for external experiences or other decisions and outputs. It is fixed to whatever objectives are set.
/// </summary>
[GlobalClass]
[Tool]
public partial class FixedChallengeResource : ExperienceChallengeResource
{
    #region Variables

    [Export]
    private ChallengeObjectiveResource[] _objectives;

    #endregion

    #region Constructors

    /// <summary>
    /// Allows configuring the challenge from the godot editor
    /// </summary>
    public FixedChallengeResource()
    {
        _objectives = [];
    }

    /// <summary>
    /// Configure a fixed challenge
    /// </summary>
    /// <param name="id">The unique named key for the challenge. Must be unique within the experience</param>
    /// <param name="name">Name or title</param>
    /// <param name="description">Insightful text to the purpose of the challenge</param>
    /// <param name="objectives">The objectives the challenge will expect completed</param>
    public FixedChallengeResource(string id, string name, string description, ChallengeObjectiveResource[] objectives)
        : base(id, name, description)
    {
        _objectives = objectives ?? [];
    }

    #endregion

    #region ExperieneChallengeResource Overrides

    /// <inheritdoc/>
    public override IReadOnlyList<IChallengeObjective> GetObjectives(IExperienceTransitionContext context)
        => [.. _objectives.Select(objective => objective.GetObjective())];

    #endregion
}
