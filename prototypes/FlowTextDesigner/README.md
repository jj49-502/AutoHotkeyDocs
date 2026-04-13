# FlowTextDesigner (Avalonia MVP skeleton)

Minimal project skeleton for a cross-platform text-first flow/diagram editor.

## Layout
- Top: toolbar/ribbon placeholder.
- Center: canvas placeholder for grid + nodes + edges.
- Right: property panel.
- Bottom: page tabs (`Page1/Page2/+`).

## Intended next steps
1. Render nodes/edges on `DiagramCanvas`.
2. Add drag/snap interactions.
3. Bind selected object to `PropertyGridViewModel`.
4. Wire save/load commands to `JsonDocumentRepository`.
