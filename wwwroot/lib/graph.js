function renderGraph(nodes, relationships) {
    var cy = cytoscape({
        container: document.getElementById('cy'), // Contenedor del grafo
        elements: [
            // Agregar nodos
            ...nodes.map(node => ({
                data: { id: node.id, label: node.content }
            })),
            // Agregar relaciones
            ...relationships.map(rel => ({
                data: { source: rel.sourceNodeId, target: rel.targetNodeId, label: rel.type }
            }))
        ],
        style: [
            {
                selector: 'node',
                style: {
                    'label': 'data(label)',
                    'background-color': '#007bff',
                    'color': '#fff',
                    'text-valign': 'center',
                    'text-halign': 'center'
                }
            },
            {
                selector: 'edge',
                style: {
                    'label': 'data(label)',
                    'width': 2,
                    'line-color': '#ccc',
                    'target-arrow-color': '#ccc',
                    'target-arrow-shape': 'triangle'
                }
            }
        ],
        layout: {
            name: 'grid' // Puedes cambiar el layout (grid, circle, etc.)
        }
    });
}