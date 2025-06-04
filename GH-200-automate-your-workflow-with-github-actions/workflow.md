https://docs.github.com/ja/actions/writing-workflows/workflow-syntax-for-github-actions

name: my workflow
on: push
jobs:
  myjob:
    runs-on: ubuntu-latest
    steps:
      - name: Checkout code
        uses: actions/checkout@v4

---


on:
  workflow_call:
    inputs:
      my-input:
        description: 'An input for the workflow'
        required: true
        default: 'default-value'
---

jobs:
  myjob:
    uses: my-org/my-repo/.github/workflows/my-workflow.yml@main
    with:
      my-input: my-value

---

on:
  workflow_dispatch:
    inputs:
      my-input:
        description: 'An input for the workflow'
        required: true
        default: 'default-value'
jobs:
  print-tag:
    runs-on: ubuntu-latest
    if: ${{ inputs.print_tags }} 
    steps:
      - name: Print the input tag to STDOUT
        run: echo  The tags are ${{ inputs.tags }} 