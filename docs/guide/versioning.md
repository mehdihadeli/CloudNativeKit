# Versioning and releases

CloudNativeKit uses [Nerdbank.GitVersioning (NBGV)](https://dotnet.github.io/Nerdbank.GitVersioning/)
to version every package from the committed `version.json` file and Git
history. All packages in a release use the same `SemVer2` version.

## Release lifecycle

```text
1.0.0-preview.N -> 1.0.0-rc.N -> 1.0.0
```

`main` is the only long-lived branch. Version changes are reviewed pull
requests; ordinary pull requests do not change `version.json`.

| Release state            | Action                                        |
| ------------------------ | --------------------------------------------- |
| Start or advance preview | Merge a PR prepared with `prepare-preview`    |
| Start or advance RC      | Merge a PR prepared with `prepare-rc`         |
| Declare stable           | Merge a PR prepared with `prepare-stable`     |
| Publish RC or stable     | Tag the exact approved commit with `nbgv tag` |

## Prepare a version

Install NBGV once, then use the repository helper:

```bash
dotnet tool install --global nbgv
./release-version.sh prepare-preview 1.0.0
```

The helper increments the current preview or RC number in `version.json`.
Commit that change in a pull request. For stabilization and stable release:

```bash
./release-version.sh prepare-rc 1.0.0
./release-version.sh prepare-stable 1.0.0
```

Check the calculated version with:

```bash
nbgv get-version -v SemVer2
```

## GitHub Actions publication

`.github/workflows/build-and-publish.yml` checks out full Git history, builds
all source projects, and runs unit and integration tests. After those checks:

- A preview version on `main` publishes all packages to NuGet.org.
- An RC or stable `v*` tag publishes all packages to NuGet.org.
- Release Drafter updates the matching draft in the same job.
- A pushed RC or stable tag publishes the draft; preview releases remain drafts.

The workflow passes the NBGV `SemVer2` value to `dotnet pack` as
`PackageVersion`. It does not add date or run-number suffixes, and it never
rewrites `version.json` in CI.

## Publish an approved tag

Create tags only from the exact approved `main` commit:

```bash
git checkout main
git pull --ff-only
nbgv get-version -v SemVer2
./release-version.sh tag
git push origin v1.0.0-rc.1
```

Use the actual tag printed by `nbgv tag`. The tag triggers the same build and
test workflow and publishes the matching Release Drafter draft.

After stable publication, begin the next release line with a new preview
version, for example `./release-version.sh prepare-preview 1.1.0`.

## Release notes

Release Drafter uses pull request labels to group changes and ignores published
pre-releases when selecting the previous stable baseline. Therefore stable
notes include the preview and RC pull requests for that release line. Apply
`skip-changelog` when a pull request should not appear in release notes.
