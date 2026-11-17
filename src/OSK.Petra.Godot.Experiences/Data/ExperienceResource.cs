using Godot;
using OSK.Petra.Experiences.Models;
using OSK.Petra.Godot.Primitives.Data;
using System;

namespace OSK.Petra.Godot.Experiences.Data;


/// <summary>
/// A resource that allows configuring experiences from the editor
/// </summary>
[GlobalClass]
public partial class ExperienceResource : Resource, IExperience
{
    #region Variables

    [Export]
    private GuidIdentifier _id;

    [Export]
    private string _name;

    [Export]
    private string _description;

    [Export]
    private bool _isRequired;

    [Export]
    private bool _isSecret;

    [Export]
    private ExperienceStopBehavior _stopBehavior;

    [Export]
    private ExperienceEnumeratorResource _experienceEnumerator;

    #endregion

    #region Constructors

    /// <summary>
    /// Editor constructor
    /// </summary>
    public ExperienceResource()
    {
    }

    /// <summary>
    /// Allows configuring a Godot experience via code
    /// </summary>
    /// <param name="id">The id for the experience</param>
    /// <param name="name">A name or title</param>
    /// <param name="description">Insightful text for the purpose of the experience</param>
    /// <param name="isRequired">Is this required to complete the application</param>
    /// <param name="isSecret">Whether this should be viewable by a user</param>
    /// <param name="stopBehavior">How the experience behaves when a user attempts to stop it</param>
    /// <param name="experienceEnumerator">The enumerator that progresses the experience</param>
    protected ExperienceResource(Guid id, string name, string description, bool isRequired, bool isSecret, ExperienceStopBehavior stopBehavior, ExperienceEnumeratorResource experienceEnumerator)
    {
        _id = new GuidIdentifier(id);
        _name = name;
        _description = description;
        _isRequired = isRequired;
        _isSecret = isSecret;
        _stopBehavior = stopBehavior;
        _experienceEnumerator = experienceEnumerator;
    }

    #endregion

    #region IExperience

    /// <inheritdoc/>
    public Guid Id => _id;

    /// <inheritdoc/>
    public string Name => _name;
    
    /// <inheritdoc/>
    public string Description => _description;

    /// <inheritdoc/>
    public bool IsRequired => _isRequired;

    /// <inheritdoc/>
    public bool IsSecret => _isSecret;

    /// <inheritdoc/>
    public ExperienceStopBehavior StopBehavior => _stopBehavior;

    /// <inheritdoc/>
    public IExperienceEnumerator GetEnumerator()
        => _experienceEnumerator.GetEnumerator();

    #endregion
}
