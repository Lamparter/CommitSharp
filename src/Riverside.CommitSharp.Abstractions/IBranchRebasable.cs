namespace Riverside.CommitSharp.Abstractions;

/// <inheritdoc />
/// <remarks>
/// This interface extends <see cref="IBranchManageable"/> to include operations for rebasing branches.
/// </remarks>
public interface IBranchRebasable : IBranchManageable
{
	/// <summary>
	/// Rebases the current branch onto another branch.
	/// </summary>
	/// <param name="branch">The branch to rebase onto.</param>
	/// <returns>The output of the rebase command.</returns>
	string Rebase(string branch);
}
