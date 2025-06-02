namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports being cleaned and pruned.
/// </summary>
public interface ICleanable
{
	/// <summary>
	/// Cleans the working directory by removing untracked files.
	/// </summary>
	/// <param name="force">Whether to force the clean operation.</param>
	/// <returns>The output of the clean command.</returns>
	string Clean(bool force = false);

	/// <summary>
	/// Prunes all unreachable objects from the object database.
	/// </summary>
	/// <returns>The output of the prune command.</returns>
	string Prune();
}
