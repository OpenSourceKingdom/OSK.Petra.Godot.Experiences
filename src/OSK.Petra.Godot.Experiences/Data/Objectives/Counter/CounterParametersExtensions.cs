using OSK.Petra.Experiences.Objectives.Counter;
using System;

namespace OSK.Petra.Godot.Experiences.Data.Objectives.Counter;

public static class CounterParametersExtensions
{
    /// <summary>
    /// Converts the couinter parameters into an equivalent godot resource
    /// </summary>
    /// <param name="parameters">The parameters to convert</param>
    /// <returns>The resource equivalent</returns>
    /// <exception cref="ArgumentNullException">If the parameters are null</exception>
    public static CounterObjectiveResource ToResource(this CounterParameters parameters)
        => parameters is null
            ? throw new ArgumentNullException(nameof(parameters))
            : new CustomCounterObjectiveResource(parameters);
}
