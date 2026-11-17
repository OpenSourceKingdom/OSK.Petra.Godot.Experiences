using Godot;
using OSK.Petra.Experiences.Models;

namespace OSK.Petra.Godot.Experiences.Data;

/// <summary>
/// Allows configuring objectives from the editor
/// </summary>
[Tool]
[GlobalClass]
public abstract partial class ChallengeObjectiveResource : Resource
{
    #region Variables

    /// <summary>
    /// The unique named key for the objective. Mist be unique within the challenge
    /// </summary>
    [Export]
    protected string Id { get; private set; } = string.Empty;

    /// <summary>
    /// The name or title
    /// </summary>
    [Export]
    protected string Name { get; private set; } = string.Empty;

    [Export]
    private string _description;

    /// <summary>
    /// Whether the objective is required to complete the challenge
    /// </summary>
    [Export]
    protected bool IsRequired { get; private set; } = true;

    #endregion

    #region Constructors

    /// <summary>
    /// Editor constructor
    /// </summary>
    protected ChallengeObjectiveResource()
    {
    }

    /// <summary>
    /// Allows configuring a Godot challene via code
    /// </summary>
    /// <param name="id">The unique named key for the objective. Must be unique within the challenge</param>
    /// <param name="name">Name or title</param>
    /// <param name="description">Insightful text for the purpose of the objective</param>
    /// <param name="isRequired">Whether the objective is required to complete the challenge</param>
    protected ChallengeObjectiveResource(string id, string name, string description, bool isRequired)
    {
        Id = id;
        Name = name;
        _description = description;
        IsRequired = isRequired;
    }

    #endregion

    #region Helpers

    /// <summary>
    /// Gets an effective description from the configuration
    /// </summary>
    /// <returns></returns>
    protected string GetDescription()
        => string.IsNullOrWhiteSpace(_description) ? string.Empty : _description;

    /// <summary>
    /// Converts the resource into the equivalent objective
    /// </summary>
    /// <returns>The objective</returns>
    public abstract IChallengeObjective GetObjective();

    #endregion
}
