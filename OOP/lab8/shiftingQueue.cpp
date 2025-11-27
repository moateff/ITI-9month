#include <iostream>
using namespace std;

class Queue {
private:
    int* arr;   // pointer to dynamic array
    int tail;   // index of last element
    int size;   // max capacity

public:
    // Constructor
    Queue(int s) {
        size = s;
        arr = new int[size];
        tail = -1;   // queue empty
    }

    // Destructor
    ~Queue() {
        delete[] arr;
    }

    // Check if queue is full
    bool isFull() const {
        return tail == size - 1;
    }

    // Check if queue is empty
    bool isEmpty() const {
        return tail == -1;
    }

    // Enqueue element
    void enqueue(int value) {
        if (isFull()) {
            cout << "Queue overflow! Cannot enqueue " << value << endl;
            return;
        }
        arr[++tail] = value;
    }

    // Dequeue element with shifting
    int dequeue() {
        if (isEmpty()) {
            cout << "Queue underflow! Returning -1" << endl;
            return -1;
        }

        int value = arr[0];

        // Shift elements left
        for (int i = 0; i < tail; i++) {
            arr[i] = arr[i + 1];
        }

        tail--; // One element removed
        return value;
    }

    // Peek at the front element
    int peek() const {
        if (isEmpty()) {
            cout << "Queue is empty! Returning -1" << endl;
            return -1;
        }
        return arr[0];
    }

    // Number of elements currently in queue
    int getCount() const {
        return tail + 1;
    }
};

// Example usage
int main() {
    Queue q(5);

    q.enqueue(10);
    q.enqueue(20);
    q.enqueue(30);

    cout << "Front: " << q.peek() << endl;
    cout << "Count: " << q.getCount() << endl;

    cout << "Dequeued: " << q.dequeue() << endl;
    cout << "Dequeued: " << q.dequeue() << endl;

    q.enqueue(40);
    q.enqueue(50);
    q.enqueue(60);
    q.enqueue(70); // overflow test

    cout << "Front now: " << q.peek() << endl;
    cout << "Final Count: " << q.getCount() << endl;

    return 0;
}
