#include <iostream>
#include <vector>
using namespace std;


void depthFirstSearch(const vector<vector<int>>& adj, int startVertex, 
        vector<bool>& visited, vector<int>& result) 
{
    visited[startVertex] = true;
    result.push_back(startVertex);

    for (int neighbor : adj[startVertex]) {
        if (!visited[neighbor]) {
            depthFirstSearch(adj, neighbor, visited, result);
        }
    }
}

vector<int> depthFirstSearch(const vector<vector<int>>& adj) {
    vector<bool> visited(adj.size(), false);
    vector<int> result;

    for (int i = 0; i < adj.size(); ++i) {
        if (!visited[i]) {
            depthFirstSearch(adj, i, visited, result);
        }
    }

    return result;
}

vector<vector<int>> createGraph(int vertices, vector<vector<int>> &edges) {
    vector<vector<int>> adj(vertices);

    for (const auto& edge : edges) {
        int from = edge[0];
        int to = edge[1];
        adj[from].push_back(to);
        // adj[to].push_back(from); // For undirected graph
    }

    return adj;
}

void printGraph(const vector<vector<int>> &adj) {
    for (int i = 0; i < adj.size(); ++i) {
        cout << "Vertex " << i << ": ";
        for (const auto& neighbor : adj[i]) {
            cout << neighbor << " ";
        }
        cout << endl;
    }
}

void printVector(const vector<int> &vec) {
    for (int it : vec) {
        cout << it << " ";
    }
    cout << endl;
}

int main() {
    int vertices = 5;
    vector<vector<int>> edges = {
        {0, 1},
        {0, 4},
        {1, 2},
        {1, 3},
        {1, 4},
        {2, 3},
        {3, 4}
    };

    // Create adjacency list
    vector<vector<int>> graph = createGraph(vertices, edges);

    // Perform Depth First Search
    vector<int> dfsResult = depthFirstSearch(graph);

    // Print the DFS traversal
    cout << "Depth First Search Traversal:" << endl;
    printVector(dfsResult);

    return 0;
}