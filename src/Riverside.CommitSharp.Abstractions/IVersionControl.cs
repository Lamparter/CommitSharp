namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Defines common operations for a version control system (VCS) provider.
/// </summary>
public interface IVersionControl : IBranchManageable, ITaggable
{
	/// <summary>
	/// Clones a repository.
	/// </summary>
	/// <param name="repositoryUrl">The URL of the repository to clone.</param>
	/// <param name="directory">The directory to clone into.</param>
	/// <returns>The output of the clone command.</returns>
	string Clone(string repositoryUrl, string directory);

	/// <summary>
	/// Initializes a new repository.
	/// </summary>
	/// <returns>The output of the init command.</returns>
	string Init();

	/// <summary>
	/// Adds files to the staging area.
	/// </summary>
	/// <param name="files">The files to add.</param>
	/// <returns>The output of the add command.</returns>
	string Add(string files);

	/// <summary>
	/// Commits changes to the repository.
	/// </summary>
	/// <param name="message">The commit message.</param>
	/// <param name="all">Whether to automatically stage files that have been modified and deleted.</param>
	/// <param name="amend">Whether to amend the previous commit.</param>
	/// <returns>The output of the commit command.</returns>
	string Commit(string message, bool all = false, bool amend = false);

	/// <summary>
	/// Pushes changes to the remote repository.
	/// </summary>
	/// <param name="remote">The name of the remote repository.</param>
	/// <param name="branch">The branch to push to.</param>
	/// <param name="force">Whether to force the push.</param>
	/// <param name="tags">Whether to push tags.</param>
	/// <returns>The output of the push command.</returns>
	string Push(string remote, string branch, bool force = false, bool tags = false);

	/// <summary>
	/// Pulls changes from the remote repository.
	/// </summary>
	/// <param name="remote">The name of the remote repository.</param>
	/// <param name="branch">The branch to pull from.</param>
	/// <param name="rebase">Whether to rebase instead of merge.</param>
	/// <returns>The output of the pull command.</returns>
	string Pull(string remote, string branch, bool rebase = false);

	/// <summary>
	/// Shows the status of the working directory and staging area.
	/// </summary>
	/// <returns>The output of the status command.</returns>
	string Status();

	/// <summary>
	/// Shows the commit log.
	/// </summary>
	/// <returns>The output of the log command.</returns>
	string Log();
}