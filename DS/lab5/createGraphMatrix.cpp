#include <iostream>
#include<vector>
using namespace std;

vector<vector<int>> createGraph(int vertices, vector<vector<int>> &edges) {
    vector<vector<int>> mat(vertices, vector<int>(vertices, 0));

    for (const auto& edge : edges) {
        int from = edge[0];
        int to = edge[1];
        int weight = edge[2];
        mat[from][to] = weight;
        // mat[to][from] = weight; // For undirected graph
    }

    return mat;
}

void printGraph(const vector<vector<int>> &graph) {
    for (const auto& row : graph) {
        for (const auto& val : row) {
            cout << val << " ";
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

    vector<vector<int>> graph = createGraph(vertices, edges);

    // Print the adjacency matrix
    cout << "Adjacency Matrix Representation:" << endl;
    printGraph(graph);

    return 0;
}