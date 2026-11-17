using Godot;
using OSK.Petra.Experiences.Models;

namespace OSK.Petra.Godot.Experiences.Data;

/// <summary>
/// Allows configuring experience enumerators from code
/// </summary>
[GlobalClass]
[Tool]
public abstract partial class ExperienceEnumeratorResource : Resource
{
    #region Api

    /// <summary>
    /// Converts the resource to the equivalent enumerator
    /// </summary>
    /// <returns>The enumerator to use</returns>
    public abstract IExperienceEnumerator GetEnumerator();

    #endregion
}
