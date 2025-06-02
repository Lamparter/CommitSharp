namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports blame and file history operations.
/// </summary>
public interface IBlamable
{
	/// <summary>
	/// Shows the commit that changed a file.
	/// </summary>
	/// <param name="filePath">The path to the file.</param>
	/// <returns>The output of the blame command.</returns>
	string Blame(string filePath);

	/// <summary>
	/// Shows the history of a file.
	/// </summary>
	/// <param name="filePath">The path to the file.</param>
	/// <returns>The output of the file history command.</returns>
	string FileHistory(string filePath);
}
