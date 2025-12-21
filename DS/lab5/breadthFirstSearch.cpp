#include <iostream>
#include <vector>
#include <queue>
using namespace std;

void breadthFirstSearch(const vector<vector<int>>& adj, int startVertex, 
        vector<bool>& visited, vector<int>& result) 
{
    queue<int> vertexQueue;

    visited[startVertex] = true;
    vertexQueue.push(startVertex);

    while (!vertexQueue.empty()) {
        int currentVertex = vertexQueue.front();
        vertexQueue.pop();
        result.push_back(currentVertex);

        for (int neighbor : adj[currentVertex]) {
            if (!visited[neighbor]) {
                visited[neighbor] = true;
                vertexQueue.push(neighbor);
            }
        }
    }
}

vector<int> breadthFirstSearch(const vector<vector<int>>& adj) {
    vector<bool> visited(adj.size(), false);
    vector<int> result;

    for (int i = 0; i < adj.size(); ++i) {
        if (!visited[i]) {
            breadthFirstSearch(adj, i, visited, result);
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
    vector<vector<int>> adj = createGraph(vertices, edges);

    // Perform BFS starting from vertex 0
    vector<int> bfsResult = breadthFirstSearch(adj);

    // Print the BFS traversal
    cout << "Breadth First Search Traversal: ";
    printVector(bfsResult);

    return 0;
}