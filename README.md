# OSK.Petra.Godot.Experiences

An implementation for the experience library in Godot. This project provides access to Godot resources and other configuration files that allow configuring and managing experience domain data structures
from within the Godot editor or via code directly.

The following can be configured using this library:
- `SequentialExperienceEnumerator`: an experience enumerator that progresses through a linear narrative experience (e.g. quest line, quest, single challenge, etc.), without checking external experiences or other decisions a user has previously made
- `FixedChallenge`: a simple challenge that simply returns the objectives assigned to it, without checking external experiences or other decisions a user has previously made
- `TimerObjective`: Timer objectives for duration and alarms
- `CounterObjective`: Counters for goal (e.g. collect 5 ore), limits (e.g. don't take 5 hits), or completely customized counter style objectives