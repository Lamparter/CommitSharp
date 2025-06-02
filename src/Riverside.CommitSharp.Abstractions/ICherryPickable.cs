namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports cherry-picking commits.
/// </summary>
public interface ICherryPickable
{
	/// <summary>
	/// Cherry-picks a commit.
	/// </summary>
	/// <remarks>
	/// This operation applies the changes introduced by a specific commit to the current branch, allowing you to selectively apply changes without merging the entire branch.
	/// </remarks>
	/// <param name="commit">The commit to cherry-pick.</param>
	/// <returns>The output of the cherry-pick command.</returns>
	string CherryPick(string commit);
}
