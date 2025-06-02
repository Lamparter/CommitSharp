namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports stashing and applying changes.
/// </summary>
public interface IStashable
{
	/// <summary>
	/// Stashes changes in the working directory.
	/// </summary>
	/// <returns>The output of the stash command.</returns>
	string Stash();

	/// <summary>
	/// Applies stashed changes.
	/// </summary>
	/// <returns>The output of the stash command.</returns>
	string StashApply();
}
