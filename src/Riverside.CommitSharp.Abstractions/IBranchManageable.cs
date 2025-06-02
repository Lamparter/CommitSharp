namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports branch management operations.
/// </summary>
/// <remarks>
/// Managing branches is a fundamental part of a version control system.
/// </remarks>
public interface IBranchManageable
{
	/// <summary>
	/// Checks out a branch or commit.
	/// </summary>
	/// <param name="branchOrCommit">The branch or commit to check out.</param>
	/// <param name="newBranch">The name of the new branch to create and check out.</param>
	/// <returns>The output of the checkout command.</returns>
	string Checkout(string branchOrCommit, string? newBranch = null);

	/// <summary>
	/// Resets the current branch to a specific commit.
	/// </summary>
	/// <param name="commit">The commit to reset to.</param>
	/// <param name="mode">The reset mode (soft, mixed, hard).</param>
	/// <param name="keep">Whether to keep the changes in the working directory.</param>
	/// <returns>The output of the reset command.</returns>
	string Reset(string commit, string mode = "mixed", bool keep = false);

	/// <summary>
	/// Renames a branch.
	/// </summary>
	/// <param name="oldName">The current name of the branch.</param>
	/// <param name="newName">The new name of the branch.</param>
	/// <returns>The output of the rename command.</returns>
	string RenameBranch(string oldName, string newName);

	/// <summary>
	/// Creates a new branch.
	/// </summary>
	/// <param name="branchName">The name of the new branch.</param>
	/// <returns>The output of the branch command.</returns>
	string Branch(string branchName);

	/// <summary>
	/// Deletes a branch.
	/// </summary>
	/// <param name="branchName">The name of the branch to delete.</param>
	/// <returns>The output of the delete branch command.</returns>
	string DeleteBranch(string branchName);

	/// <summary>
	/// Shows the current branch.
	/// </summary>
	/// <returns>The output of the current branch command.</returns>
	string CurrentBranch();
}
