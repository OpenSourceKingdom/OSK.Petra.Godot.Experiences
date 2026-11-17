using Godot;
using OSK.Petra.Experiences.Models;
using System.Collections.Generic;

namespace OSK.Petra.Godot.Experiences.Data;
    
/// <summary>
/// Allows configuring challenges from the editor
/// </summary>
[Tool]
[GlobalClass]
public abstract partial class ExperienceChallengeResource : Resource, IExperienceChallenge
{
    #region Variables

    [Export]
    private string _id;

    [Export]
    private string _name;

    [Export]
    private string _description;

    #endregion

    #region Constructors

    /// <summary>
    /// Editor constructor
    /// </summary>
    public ExperienceChallengeResource()
    {
    }

    /// <summary>
    /// Allows configuring a Godot experience via code
    /// </summary>
    /// <param name="id">A unique named key for the challenge. Must be unique within the experience</param>
    /// <param name="name">The name or title</param>
    /// <param name="description">Insightful text to the purpose of the challenge</param>
    protected ExperienceChallengeResource(string id, string name, string description)
    {
        _id = id;
        _name = name;
        _description = description;
    }

    #endregion

    #region IExperienceChallenge

    /// <inheritdoc/>
    public string Id => _id;

    /// <inheritdoc/>
    public string Name => _name;

    /// <inheritdoc/>
    public string Description => _description;

    /// <inheritdoc/>
    public abstract IReadOnlyList<IChallengeObjective> GetObjectives(IExperienceTransitionContext context);

    #endregion
}
