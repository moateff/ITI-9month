#include <iostream>
using namespace std;

void heapifyUp(int heap[], int index) {
    while (index > 0) {
        int parent = (index - 1) / 2;
        if (heap[index] > heap[parent]) {
            swap(heap[index], heap[parent]);
            index = parent;
        } else {
            break;
        }
    }
}

void insert(int heap[], int &size, int value) {
    heap[size] = value;   // put at end
    heapifyUp(heap, size);
    size++;
}

void heapifyDown(int heap[], int size, int i) {
    while (true) {
        int left = 2*i + 1;
        int right = 2*i + 2;
        int largest = i;

        if (left < size && heap[left] > heap[largest])
            largest = left;

        if (right < size && heap[right] > heap[largest])
            largest = right;

        if (largest != i) {
            swap(heap[i], heap[largest]);
            i = largest;
        } else {
            break;
        }
    }
}

void deleteMax(int heap[], int &size) {
    if (size == 0) return;

    heap[0] = heap[size - 1];  // move last to root
    size--;                    // remove last
    heapifyDown(heap, size, 0);
}

void printHeap(int heap[], int size) {
    for (int i = 0; i < size; i++)
        cout << heap[i] << " ";
    cout << endl;
}

int main() {
    int heap[100];
    int size = 0;

    // assume you already have insert() implemented

    insert(heap, size, 60);
    insert(heap, size, 50);
    insert(heap, size, 40);
    insert(heap, size, 30);
    insert(heap, size, 20);

    cout << "Before delete: ";
    printHeap(heap, size);

    deleteMax(heap, size);

    cout << "After delete:  ";
    printHeap(heap, size);
}
