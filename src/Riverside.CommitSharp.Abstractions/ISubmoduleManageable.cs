namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports managing and using submodules.
/// </summary>
public interface ISubmoduleManageable
{
	/// <summary>
	/// Adds a submodule.
	/// </summary>
	/// <param name="url">The URL of the submodule repository.</param>
	/// <param name="path">The path where the submodule should be added.</param>
	/// <param name="branch">The branch to checkout in the submodule.</param>
	/// <returns>The output of the submodule command.</returns>
	string AddSubmodule(string url, string path, string? branch = null);

	/// <summary>
	/// Updates submodules.
	/// </summary>
	/// <returns>The output of the submodule command.</returns>
	string UpdateSubmodules();
}
