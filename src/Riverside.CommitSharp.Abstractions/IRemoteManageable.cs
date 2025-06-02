namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports managing remotes.
/// </summary>
public interface IRemoteManageable
{
	/// <summary>
	/// Shows the list of remotes.
	/// </summary>
	/// <returns>The output of the remote command.</returns>
	string ListRemotes();

	/// <summary>
	/// Adds a new remote.
	/// </summary>
	/// <param name="name">The name of the remote.</param>
	/// <param name="url">The URL of the remote.</param>
	/// <returns>The output of the remote command.</returns
	string AddRemote(string name, string url);

	/// <summary>
	/// Removes a remote.
	/// </summary>
	/// <param name="name">The name of the remote to remove.</param>
	/// <returns>The output of the remote command.</returns>
	string RemoveRemote(string name);
}
