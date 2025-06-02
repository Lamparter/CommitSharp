namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports showing the reference logs.
/// </summary>
/// <remarks>
/// This is nicknamed <c>reflog</c> in Git.
/// </remarks>
public interface IRefloggable
{
	/// <summary>
	/// Shows the reference logs.
	/// </summary>
	/// <returns>The output of the reflog command.</returns>
	string Reflog();
}
