using Riverside.CommitSharp.Abstractions;
using System;
using System.Diagnostics;

namespace Riverside.CommitSharp;

/// <summary>
/// A wrapper class for Git CLI commands.
/// </summary>
public sealed class Git : IVersionControl, IArchivable, IBisectable, IBlamable, IBranchManageable, IBranchMergeable, ICherryPickable, ICleanable, IDiffable, IBranchRebasable, IRefloggable, IRemoteManageable, IStashable, ISubmoduleManageable, ITaggable
{
	private readonly string _repositoryPath;

	/// <summary>
	/// Initializes a new instance of the <see cref="Git"/> class.
	/// </summary>
	/// <param name="repositoryPath">The path to the Git repository.</param>
	public Git(string repositoryPath)
	{
		_repositoryPath = repositoryPath;
	}

	// The basis of all Git commands is to execute a process with the Git executable and the specified arguments.
	// This is the root method that handles the execution of Git commands, and implements the abstraction.
	private string ExecuteGitCommand(string arguments)
	{
		var processStartInfo = new ProcessStartInfo
		{
			FileName = "git",
			Arguments = arguments,
			WorkingDirectory = _repositoryPath,
			RedirectStandardOutput = true,
			RedirectStandardError = true,
			UseShellExecute = false,
			CreateNoWindow = true
		};

		using var process = new Process { StartInfo = processStartInfo };
		process.Start();

		string output = process.StandardOutput.ReadToEnd();
		string error = process.StandardError.ReadToEnd();

		process.WaitForExit();

		if (process.ExitCode != 0)
		{
			throw new InvalidOperationException($"Git command failed: {error}");
		}

		return output;
	}

	/// <inheritdoc />
	public string Reflog()
	{
		return ExecuteGitCommand("reflog");
	}

	/// <inheritdoc />
	public string Bisect(string start, string end, string? good = null, string? bad = null)
	{
		var args = $"bisect start {start} {end}";
		if (!string.IsNullOrEmpty(good)) args += $" {good}";
		if (!string.IsNullOrEmpty(bad)) args += $" {bad}";
		return ExecuteGitCommand(args);
	}

	/// <inheritdoc />
	public string AddSubmodule(string url, string path, string? branch = null)
	{
		var args = $"submodule add {url} {path}";
		if (!string.IsNullOrEmpty(branch)) args += $" -b {branch}";
		return ExecuteGitCommand(args);
	}

	/// <inheritdoc />
	public string UpdateSubmodules()
	{
		return ExecuteGitCommand("submodule update --init --recursive");
	}

	/// <inheritdoc />
	public string Archive(string commit, string format, string outputFile)
	{
		return ExecuteGitCommand($"archive --format={format} --output={outputFile} {commit}");
	}

	/// <summary>
	/// Gives an object a human-readable name based on an available ref.
	/// </summary>
	/// <param name="objectName">The object to describe.</param>
	/// <returns>The output of the Git command.</returns>
	public string Describe(string objectName)
	{
		return ExecuteGitCommand($"describe {objectName}");
	}

	/// <inheritdoc />
	public string Clone(string repositoryUrl, string directory)
	{
		return ExecuteGitCommand($"clone {repositoryUrl} {directory}");
	}

	/// <inheritdoc />
	public string Init()
	{
		return ExecuteGitCommand("init");
	}

	/// <inheritdoc />
	public string Add(string files)
	{
		return ExecuteGitCommand($"add {files}");
	}

	/// <inheritdoc />
	public string Commit(string message, bool all = false, bool amend = false)
	{
		var args = $"commit -m \"{message}\"";
		if (all) args += " --all";
		if (amend) args += " --amend";
		return ExecuteGitCommand(args);
	}

	/// <inheritdoc />
	public string Push(string remote, string branch, bool force = false, bool tags = false)
	{
		var args = $"push {remote} {branch}";
		if (force) args += " --force";
		if (tags) args += " --tags";
		return ExecuteGitCommand(args);
	}

	/// <inheritdoc />
	public string Pull(string remote, string branch, bool rebase = false)
	{
		var args = $"pull {remote} {branch}";
		if (rebase) args += " --rebase";
		return ExecuteGitCommand(args);
	}

	/// <inheritdoc />
	public string Checkout(string branchOrCommit, string? newBranch = null)
	{
		var args = $"checkout {branchOrCommit}";
		if (!string.IsNullOrEmpty(newBranch)) args += $" -b {newBranch}";
		return ExecuteGitCommand(args);
	}

	/// <inheritdoc />
	public string Merge(string branch, bool noFastForward = false)
	{
		var args = $"merge {branch}";
		if (noFastForward) args += " --no-ff";
		return ExecuteGitCommand(args);
	}

	/// <inheritdoc />
	public string Reset(string commit, string mode = "mixed", bool keep = false)
	{
		var args = $"reset --{mode} {commit}";
		if (keep) args += " --keep";
		return ExecuteGitCommand(args);
	}

	/// <inheritdoc />
	public string Status()
	{
		return ExecuteGitCommand("status");
	}

	/// <inheritdoc />
	public string Log()
	{
		return ExecuteGitCommand("log");
	}

	/// <inheritdoc />
	public string Branch(string branchName)
	{
		return ExecuteGitCommand($"branch {branchName}");
	}

	/// <inheritdoc />
	public string DeleteBranch(string branchName)
	{
		return ExecuteGitCommand($"branch -d {branchName}");
	}

	/// <inheritdoc />
	public string Stash()
	{
		return ExecuteGitCommand("stash");
	}

	/// <inheritdoc />
	public string StashApply()
	{
		return ExecuteGitCommand("stash apply");
	}

	/// <inheritdoc />
	public string Diff(string options = "")
	{
		return ExecuteGitCommand($"diff {options}");
	}

	/// <inheritdoc />
	public string Tag(string tagName, string commit)
	{
		return ExecuteGitCommand($"tag {tagName} {commit}");
	}

	/// <inheritdoc />
	public string ListTags()
	{
		return ExecuteGitCommand("tag");
	}

	/// <inheritdoc />
	public string CurrentBranch()
	{
		return ExecuteGitCommand("rev-parse --abbrev-ref HEAD");
	}

	/// <inheritdoc />
	public string RenameBranch(string oldName, string newName)
	{
		return ExecuteGitCommand($"branch -m {oldName} {newName}");
	}

	/// <inheritdoc />
	public string Rebase(string branch)
	{
		return ExecuteGitCommand($"rebase {branch}");
	}

	/// <inheritdoc />
	public string CherryPick(string commit)
	{
		return ExecuteGitCommand($"cherry-pick {commit}");
	}

	/// <inheritdoc />
	public string Blame(string filePath)
	{
		return ExecuteGitCommand($"blame {filePath}");
	}

	/// <inheritdoc />
	public string FileHistory(string filePath)
	{
		return ExecuteGitCommand($"log --follow {filePath}");
	}

	/// <inheritdoc />
	public string ListRemotes()
	{
		return ExecuteGitCommand("remote -v");
	}

	/// <inheritdoc />
	public string AddRemote(string name, string url)
	{
		return ExecuteGitCommand($"remote add {name} {url}");
	}

	/// <inheritdoc />
	public string RemoveRemote(string name)
	{
		return ExecuteGitCommand($"remote remove {name}");
	}

	/// <inheritdoc />
	public string Prune()
	{
		return ExecuteGitCommand("prune");
	}

	/// <inheritdoc />
	public string Clean(bool force = false)
	{
		return ExecuteGitCommand($"clean {(force ? "-f" : "")}");
	}

	/// <inheritdoc />
	public string DiffCached()
	{
		return ExecuteGitCommand("diff --cached");
	}

	/// <inheritdoc />
	public string DiffHead()
	{
		return ExecuteGitCommand("diff HEAD");
	}

	/// <inheritdoc />
	public string DiffCommits(string commit1, string commit2)
	{
		return Diff($"{commit1} {commit2}");
	}
}