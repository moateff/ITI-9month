#include <iostream>
#include <vector>
using namespace std;

vector<vector<pair<int, int>>> createGraph(int vertices, vector<vector<int>> &edges) {
    vector<vector<pair<int, int>>> adj(vertices);

    for (const auto& edge : edges) {
        int from = edge[0];
        int to = edge[1];
        int weight = edge[2];
        adj[from].emplace_back(to, weight);
        // adj[to].emplace_back(from, weight); // For undirected graph
    }

    return adj;
}

void printGraph(const vector<vector<pair<int, int>>> &graph) {
    for (int i = 0; i < graph.size(); ++i) {
        cout << "Vertex " << i << ": ";
        for (const auto& neighbor : graph[i]) {
            cout << "(" << neighbor.first << ", weight: " << neighbor.second << ") ";
        }
        cout << endl;
    }
}

int main() {
    int vertices = 5;
    vector<vector<int>> edges = {
        {0, 1, 7},
        {0, 4, 8},
        {1, 2, 6},
        {1, 3, 5},
        {1, 4, 2},
        {2, 3, 9},
        {3, 4, 4}
    };

    vector<vector<pair<int, int>>> graph = createGraph(vertices, edges);

    // Print the adjacency list
    cout << "Adjacency List Representation:" << endl;
    printGraph(graph);

    return 0;
}