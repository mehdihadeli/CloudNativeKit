#!/usr/bin/env bash
set -euo pipefail

: "${NBGV_PATH:?NBGV_PATH must point to the nbgv executable}"
: "${GITHUB_RUN_NUMBER:?GITHUB_RUN_NUMBER must be available in CI}"

version=$($NBGV_PATH get-version -v Version)
base_version=$(printf '%s' "$version" | sed -E 's/^([0-9]+\.[0-9]+\.[0-9]+).*/\1/')
revision="$GITHUB_RUN_NUMBER"

year=$((10#$(date -u +%y)))
month=$((10#$(date -u +%m)))
day=$((10#$(date -u +%d)))
short_date=$((year * 1000 + month * 50 + day))

# Expected formats:
#   main:       10.0.0-preview.1.26468.115
#   RC tag:     10.0.0-rc.1.26468.128
#   Stable tag: 10.0.0
# The date code uses UTC; the final component is GitHub's run number.
if [[ "$GITHUB_REF_NAME" =~ ^v([0-9]+\.[0-9]+\.[0-9]+)-(preview|rc)\.([0-9]+)$ ]]; then
  base_version="${BASH_REMATCH[1]}"
  channel="${BASH_REMATCH[2]}"
  iteration="${BASH_REMATCH[3]}"
  printf '%s-%s.%s.%s.%s\n' "$base_version" "$channel" "$iteration" "$short_date" "$revision"
  exit 0
fi

if [[ "$GITHUB_REF_NAME" =~ ^v[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
  printf '%s\n' "${GITHUB_REF_NAME#v}"
  exit 0
fi

preview_iteration=''
if [[ "$version" =~ ^[0-9]+\.[0-9]+\.[0-9]+-preview\.([0-9]+)$ ]]; then
  preview_iteration="${BASH_REMATCH[1]}"
else
  configured_version=$(jq -r '.version' version.json)
  if [[ "$configured_version" =~ ^[0-9]+\.[0-9]+\.[0-9]+-preview\.([0-9]+)$ ]]; then
    preview_iteration="${BASH_REMATCH[1]}"
  fi
fi

if [[ -n "$preview_iteration" ]]; then
  printf '%s-preview.%s.%s.%s\n' "$base_version" "$preview_iteration" "$short_date" "$revision"
  exit 0
fi

echo "Unsupported ref/version combination: ref=$GITHUB_REF_NAME version=$version" >&2
exit 1