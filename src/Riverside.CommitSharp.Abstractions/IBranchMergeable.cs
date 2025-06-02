namespace Riverside.CommitSharp.Abstractions;

/// <inheritdoc />
/// <remarks>
/// This interface extends <see cref="IBranchManageable"/> to include operations for merging branches, since not all version control systems support merging in the same way.
/// </remarks>
public interface IBranchMergeable : IBranchManageable
{
	/// <summary>
	/// Merges a branch into the current branch.
	/// </summary>
	/// <param name="branch">The branch to merge.</param>
	/// <param name="noFastForward">Whether to create a merge commit even if the merge resolves as a fast-forward.</param>
	/// <returns>The output of the merge command.</returns>
	string Merge(string branch, bool noFastForward = false);
}
