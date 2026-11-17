using Godot;
using OSK.Petra.Experiences.Enumerators.Sequential;
using OSK.Petra.Experiences.Models;

namespace OSK.Petra.Godot.Experiences.Data.Enumerators.Sequential;

/// <summary>
/// Allows configuring a sequential experience enumerator from Godot
/// </summary>
[GlobalClass]
[Tool]
public partial class SequentialEnumeratorResource : ExperienceEnumeratorResource
{
    #region Variables

    [Export]
    private ExperienceChallengeResource[] _challenges;

    #endregion

    #region Constructors

    /// <summary>
    /// Allows configuring the enumerator from the godot editor
    /// </summary>
    public SequentialEnumeratorResource()
    {
        _challenges = [];
    }

    /// <summary>
    /// Allows creating the resource via code
    /// </summary>
    /// <param name="challenges">The collection of challenges to progress through sequentially</param>
    public SequentialEnumeratorResource(ExperienceChallengeResource[] challenges)
    {
        _challenges = challenges;
    }

    #endregion

    #region ExperienceEnumerator Overrides

    /// <inheritdoc/>
    public override IExperienceEnumerator GetEnumerator()
        => new SequentialChallengeEnumerator(_challenges ?? []);

    #endregion
}
