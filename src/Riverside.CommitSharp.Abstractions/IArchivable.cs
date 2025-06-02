namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports being archived.
/// </summary>
public interface IArchivable
{
	/// <summary>
	/// Creates an archive of files from a named tree.
	/// </summary>
	/// <param name="commit">The tree or commit to archive.</param>
	/// <param name="format">The format of the archive (e.g., tar, zip).</param>
	/// <param name="outputFile">The output file for the archive.</param>
	/// <returns>The output of the archive command.</returns>
	string Archive(string commit, string format, string outputFile);
}
