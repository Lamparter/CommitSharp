namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports showing differences between commits, the working tree, and the index.
/// </summary>
public interface IDiffable
{
	/// <summary>
	/// Shows the differences between commits, commit and working tree, etc.
	/// </summary>
	/// <param name="options">The options for the diff command.</param>
	/// <returns>The output of the diff command.</returns>
	string Diff(string options = "");

	/// <summary>
	/// Shows the changes between the working directory and the index.
	/// </summary>
	/// <returns>The output of the diff command.</returns>
	string DiffCached();

	/// <summary>
	/// Shows the changes between the index and the last commit.
	/// </summary>
	/// <returns>The output of the diff command.</returns>
	string DiffHead();

	/// <summary>
	/// Shows the changes between two commits.
	/// </summary>
	/// <param name="commit1">The first commit.</param>
	/// <param name="commit2">The second commit.</param>
	/// <returns>The output of the diff command.</returns>
	string DiffCommits(string commit1, string commit2);
}
