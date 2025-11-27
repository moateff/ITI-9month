#include <iostream>
using namespace std;

class Queue {
private:
    int* arr;   // pointer to dynamic array
    int head;   // front index
    int tail;   // rear index
    int size;   // maximum capacity

public:
    // Constructor
    Queue(int s) {
        size = s;
        arr = new int[size];
        head = -1;
        tail = -1;
    }

    // Destructor
    ~Queue() {
        delete[] arr;
    }

    // Check if queue is full
    bool isFull() const {
        return (head != -1 && (tail + 1) % size == head);
    }

    // Check if queue is empty
    bool isEmpty() const {
        return head == -1;
    }

    // Add element to queue
    void enqueue(int value) {
        if (isFull()) {
            cout << "Queue overflow! Cannot enqueue " << value << endl;
            return;
        }

        if (isEmpty()) {
            head = tail = 0;
        } else {
            tail = (tail + 1) % size;
        }

        arr[tail] = value;
    }

    // Remove and return front element
    int dequeue() {
        if (isEmpty()) {
            cout << "Queue underflow! Returning -1" << endl;
            return -1;
        }

        int value = arr[head];

        if (head == tail) { 
            // queue becomes empty
            head = tail = -1;
        } else {
            head = (head + 1) % size;
        }

        return value;
    }

    // Peek at the front element
    int peek() const {
        if (isEmpty()) {
            cout << "Queue is empty! Returning -1" << endl;
            return -1;
        }
        return arr[head];
    }

    // Compute number of elements without count
    int getCount() const {
        if (isEmpty()) return 0;

        if (tail >= head)
            return tail - head + 1;

        // Wrapped around
        return size - (head - tail - 1);
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
