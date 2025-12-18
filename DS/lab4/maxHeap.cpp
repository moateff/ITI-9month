#include <iostream>
#include <stdexcept>
#include <vector>
using namespace std;

template<typename T>
class MaxHeap {
private:
    vector<T> heap;

    void heapifyUp(int index) {
        while (index > 0) {
            int parent = (index - 1) / 2;

            if (heap[index] > heap[parent]) {
                swap(heap[index], heap[parent]);
                index = parent;
            } else break;
        }
    }

    void heapifyDown(int index) {
        int size = heap.size();

        while (true) {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;

            if (left < size && heap[left] > heap[largest])
                largest = left;

            if (right < size && heap[right] > heap[largest])
                largest = right;

            if (largest != index) {
                swap(heap[index], heap[largest]);
                index = largest;
            } else break;
        }
    }

public:
    MaxHeap() = default;

    void insert(int value) {
        heap.push_back(value);
        heapifyUp(heap.size() - 1);
    }

    int deleteMax() {
        if (heap.empty())
            throw runtime_error("Heap is empty");

        int max = heap[0];
        heap[0] = heap.back();
        heap.pop_back();
        
        if (!heap.empty())
            heapifyDown(0);

        return max;
    }

    int peek() const {
        if (heap.empty())
            throw runtime_error("Heap is empty");
        return heap[0];
    }

    bool empty() const {
        return heap.empty();
    }

    int size() const {
        return heap.size();
    }

    void printArray() const {
        for (int i = 0; i < heap.size(); i++)
            cout << heap[i] << " ";
        cout << endl;
    }

    void printTree() const {
        int level = 0;
        int elementsInLevel = 1;
        int count = 0;

        for (int i = 0; i < heap.size(); i++) {
            cout << heap[i] << " ";
            count++;

            if (count == elementsInLevel) {
                cout << endl;
                level++;
                elementsInLevel = 1 << level; // 2^level
                count = 0;
            }
        }
        cout << endl;
    }

    void clear() {
        heap.clear();
    }

    int& operator[](int index) {
    /*
        if (index < 0 || index > heap.size() - 1)
            throw out_of_range("Index out of range");
    */
        return heap[index];
    }
};

int main() {
    MaxHeap<int> heap;

    cout << "Is heap empty? " 
         << (heap.empty() ? "Yes" : "No") << endl;

    // Insert elements
    vector<int> values = {10, 40, 30, 5, 12, 6, 20};

    cout << "Inserting values: ";
    for (int v : values) {
        cout << v << " ";
        heap.insert(v);
    }
    cout << endl;

    cout << "\nHeap array representation: ";
    heap.printArray();
    cout << "Heap tree representation:\n";
    heap.printTree();

    cout << "Current max (peek): " << heap.peek() << endl;
    cout << "Heap size: " << heap.size() << endl;

    // Delete max repeatedly
    cout << "\nExtracting elements in descending order: ";
    while (!heap.empty()) {
        cout << heap.deleteMax() << " ";
    }
    cout << endl;

    cout << "Heap size after deletions: " << heap.size() << endl;

    // Exception handling test
    try {
        heap.deleteMax();
    } catch (const std::runtime_error& e) {
        cout << "Exception caught: " << e.what() << endl;
    }

    // Reuse heap
    heap.insert(100);
    heap.insert(50);
    heap.insert(75);

    cout << "\nHeap after reinserting elements: " << endl;
    cout << "Heap array representation: ";
    heap.printArray();
    cout << "Heap tree representation:\n";
    heap.printTree();

    heap.clear();
    cout << "Heap cleared. Is empty? "
         << (heap.empty() ? "Yes" : "No") << endl;

    return 0;
}
