namespace Riverside.CommitSharp.Abstractions;

/// <summary>
/// Represents a version control system that supports tagging commits.
/// </summary>
/// <remarks>
/// Tagging commits is a fundamental part of a version control system.
/// </remarks>
public interface ITaggable
{
	/// <summary>
	/// Tags a specific commit.
	/// </summary>
	/// <param name="tagName">The name of the tag.</param>
	/// <param name="commit">The commit to tag.</param>
	/// <returns>The output of the tag command.</returns>
	public string Tag(string tagName, string commit);

	/// <summary>
	/// Lists all tags.
	/// </summary>
	/// <returns>The output of the tag command.</returns>
	public string ListTags();
}
