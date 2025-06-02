namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports bisect operations.
/// </summary>
/// <remarks>
/// Bisect operations are generally only supported in systems like Git, where you can perform a binary search through the commit history to find the commit that introduced a bug.
/// </remarks>
public interface IBisectable
{
	/// <summary>
	/// Uses binary search to find the commit that introduced a bug.
	/// </summary>
	/// <remarks>
	/// This is helpful for identifying the commit that introduced a bug by performing a binary search through the commit history.
	/// </remarks>
	/// <param name="start">The starting point for the bisect.</param>
	/// <param name="end">The ending point for the bisect.</param>
	/// <param name="good">The commit known to be good.</param>
	/// <param name="bad">The commit known to be bad.</param>
	/// <returns>The output of the bisect command.</returns>
	public string Bisect(string start, string end, string? good = null, string? bad = null);
}
