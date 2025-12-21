#include <iostream>
#include <vector>
#include <queue>
#include <algorithm>
#include <unordered_map>
#include <limits>
using namespace std;

template<typename VertexType>
class Graph {
private:
    vector<VertexType> vertices;
    vector<vector<int>> adjMatrix;
    vector<bool> visited;

    int getIndex(const VertexType& vertex) const {
        for (size_t i = 0; i < vertices.size(); ++i)
            if (vertices[i] == vertex)
                return static_cast<int>(i);
        return -1;
    }

    // Visited helpers
    void clearVisited() {
        fill(visited.begin(), visited.end(), false);
    }

    void markVertex(const VertexType& vertex) {
        int index = getIndex(vertex);
        if (index != -1)
            visited[index] = true;
    }

    bool isMarked(const VertexType& vertex) const {
        int index = getIndex(vertex);
        return (index != -1 && visited[index]);
    }

public:
    Graph() = default;

    // Vertex & Edge
    void addVertex(const VertexType& vertex) {
        vertices.push_back(vertex);

        size_t n = vertices.size();
        adjMatrix.resize(n);
        for (auto& row : adjMatrix)
            row.resize(n, 0);

        visited.resize(n, false);
    }

    bool addEdge(const VertexType& from,
                 const VertexType& to,
                 int weight = 1) {
        int u = getIndex(from);
        int v = getIndex(to);

        if (u == -1 || v == -1)
            return false;

        adjMatrix[u][v] = weight;
        return true;
    }

    void GetAdjVertices(const VertexType& vertex,
                        queue<VertexType>& VertexQ) {
        int index = getIndex(vertex);
        if (index == -1) return;

        for (size_t i = 0; i < vertices.size(); ++i) {
            if (adjMatrix[index][i] != 0 &&
                !isMarked(vertices[i])) {

                VertexQ.push(vertices[i]);
                markVertex(vertices[i]);
            }
        }
    }

    // Breadth First Search
    vector<VertexType> breadthFirstSearch(
        const VertexType& startVertex,
        const VertexType& endVertex) {

        if (getIndex(startVertex) == -1 || getIndex(endVertex) == -1)
            return {};

        clearVisited();

        queue<VertexType> q;
        vector<VertexType> result;
        unordered_map<VertexType, VertexType> parent; // child -> parent

        q.push(startVertex);
        markVertex(startVertex);

        bool found = false;

        while (!q.empty() && !found) {
            VertexType current = q.front();
            q.pop();

            if (current == endVertex) {
                found = true;
                break;
            }

            // Push adjacent vertices and record parent
            queue<VertexType> adj;
            GetAdjVertices(current, adj);

            while (!adj.empty()) {
                VertexType neighbor = adj.front();
                adj.pop();
                if (!parent.count(neighbor)) {
                    parent[neighbor] = current; // track parent
                    q.push(neighbor);
                }
            }
        }

        // Reconstruct path from endVertex to startVertex
        if (found) {
            VertexType current = endVertex;
            while (true) {
                result.push_back(current);
                if (current == startVertex)
                    break;
                current = parent[current];
            }
            reverse(result.begin(), result.end());
        }

        return result;
    }

    // Dijkstra's Algorithm
    vector<int> dijkstra(const VertexType& startVertex) {
        int startIndex = getIndex(startVertex);
        if (startIndex == -1)
            return {};

        size_t n = vertices.size();
        vector<int> distances(n, INT_MAX);
        distances[startIndex] = 0;

        using Pair = pair<int, int>; // (distance, vertexIndex)
        priority_queue<Pair, vector<Pair>, greater<Pair>> pq;
        pq.emplace(0, startIndex);

        while (!pq.empty()) {
            auto [currentDist, u] = pq.top();
            pq.pop();

            if (currentDist > distances[u])
                continue;

            for (size_t v = 0; v < n; ++v) {
                if (adjMatrix[u][v] != 0) {
                    int weight = adjMatrix[u][v];
                    if (distances[u] + weight < distances[v]) {
                        distances[v] = distances[u] + weight;
                        pq.emplace(distances[v], v);
                    }
                }
            }
        }

        return distances;
    }

    // Utils
    void clear() {
        vertices.clear();
        adjMatrix.clear();
        visited.clear();
    }

    bool isEmpty() const {
        return vertices.empty();
    }

    void display() const {
        cout << "Adjacency Matrix:\n  ";
        for (const auto& v : vertices)
            cout << v << " ";
        cout << "\n";

        for (size_t i = 0; i < vertices.size(); ++i) {
            cout << vertices[i] << " ";
            for (int w : adjMatrix[i])
                cout << w << " ";
            cout << "\n";
        }
    }
};

template<typename T>
void printVector(const vector<T> &vec) {
    for (const auto& it : vec) {
        cout << it << " ";
    }
    cout << endl;
}

int main() {
    Graph<string> g;

    g.addVertex("A");
    g.addVertex("B");
    g.addVertex("C");
    g.addVertex("D");

    g.addEdge("A", "B", 5);
    g.addEdge("B", "C", 1);
    g.addEdge("A", "C", 9);
    g.addEdge("D", "C", 3);

    g.display();

    vector<string> bfsResult;
    bfsResult = g.breadthFirstSearch("A", "C");
    cout << "Breadth First Search Traversal from A to C: ";
    printVector(bfsResult);

    bfsResult = g.breadthFirstSearch("A", "D");
    cout << "Breadth First Search Traversal from A to D: ";
    printVector(bfsResult);

    vector<int> dijkstraResult;
    dijkstraResult = g.dijkstra("A");
    cout << "Dijkstra Traversal from A: ";
    printVector(dijkstraResult);

    dijkstraResult = g.dijkstra("B");
    cout << "Dijkstra Traversal from B: ";
    printVector(dijkstraResult);

    return 0;
}