# 💫 CommitSharp

CommitSharp is a .NET Standard 2.0 library providing a wrapper around source control (version control system) commands.
It offers a structured, object-oriented way to interact with repositories, making it easy to integrate VCS operations into your .NET applications.
It offers better integration than using a native implementation such as [LibGit2Sharp](https://github.com/libgit2/libgit2sharp) as CommitSharp is designed to be a thin wrapper around the native VCS CLI commands, providing a more consistent and extensible API, and a far more reliable one.


## ✨ Features

CommitSharp provides a comprehensive set of operations in its abstraction, including but not limited to:

*   **Repository Management:** `Clone`, `Init`
*   **Basic Operations:** `Add`, `Commit`, `Push`, `Pull`, `Status`, `Log`
*   **Branching & Merging:** `Branch`, `DeleteBranch`, `RenameBranch`, `Checkout`, `Merge`, `Rebase`
*   **Tagging:** `Tag`, `ListTags`
*   **Stashing:** `Stash`, `StashApply`
*   **Remote Management:** `ListRemotes`, `AddRemote`, `RemoveRemote`
*   **History & Inspection:** `Reflog`, `Bisect`, `Blame`, `FileHistory`, `Describe`
*   **Submodules:** `AddSubmodule`, `UpdateSubmodules`
*   **Advanced Operations:** `Archive`, `CherryPick`, `Clean`, `Prune`, `Diff`, `DiffCached`, `DiffHead`, `DiffCommits`

## 🚀 Getting Started

### Prerequisites

*   .NET Standard 2.0 compatible project
*   Your chosen VCS provider's CLI installed and available in your system's PATH.

### Installation

```
Install-Package Riverside.CommitSharp 
```

*(Or using the .NET CLI)*
```
dotnet add package Riverside.CommitSharp
```

### Basic Usage

`CommitSharp` provides a simple API to interact with Git repositories.
It also exposes APIs for interacting with other version control systems, although currently it is primarily focused on Git.

1.  **Instantiate the `Git` class** with the path to your repository:

    ```csharp
    using Riverside.CommitSharp;

    var git = new Git("path/to/your/repo");
    ```

2.  **Call Git commands** as methods:

    ```csharp
    // Get repository status
    string status = git.Status();
    Console.WriteLine(status);

    // Add all files
    git.Add(".");

    // Commit changes
    git.Commit("My awesome commit message");

    // Push to remote
    git.Push("origin", "main");
    ```

## 🏛️ Abstractions

CommitSharp is designed with extensibility in mind. It uses a set of interfaces to define Git operations, allowing for potential future support for other Version Control Systems (VCS) or custom implementations.

The core interface is `IVersionControl`, which defines common VCS operations.
The `Riverside.CommitSharp.Abstractions` namespace contains several interfaces that represent different aspects of version control operations, such as `IBlamable`, `IBranchRebasable`, `ICherryPickable`, and more.

The `Git` class implements these interfaces, providing a concrete implementation for Git.

## 🛠️ How It Works

CommitSharp executes Git commands by spawning a `git` process with the appropriate arguments and capturing its standard output and error streams.
The working directory for each command is set to the repository path passed into the `Git` constructor.
