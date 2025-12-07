#include <iostream>
using namespace std;

class Stack {
private:
    int* arr;   // pointer to dynamic array
    int tos;    // top of stack index
    int size;   // maximum size of stack

public:
    // Constructor
    Stack(int s) {
        size = s;
        arr = new int[size];
        tos = -1; // stack initially empty
    }

    // Destructor
    ~Stack() {
        delete[] arr;
    }

    // Check if stack is full
    bool isFull() const {
        return tos == size - 1;
    }

    // Check if stack is empty
    bool isEmpty() const {
        return tos == -1;
    }

    // Push a value onto the stack
    void push(int value) {
        if (isFull()) {
            cout << "Stack overflow! Cannot push " << value << endl;
        } else {
            arr[++tos] = value;
        }
    }

    // Pop a value and return it
    int pop() {
        if (isEmpty()) {
            cout << "Stack underflow! Returning -1" << endl;
            return -1;
        } else {
            return arr[tos--];
        }
    }

    // Return the top element without removing it
    int peek() const {
        if (isEmpty()) {
            cout << "Stack is empty! Returning -1" << endl;
            return -1;
        }
        return arr[tos];
    }

    // Return count of elements in stack
    int getCount() const {
        return tos + 1;
    }
};

// Example usage
int main() {
    Stack s(7);

    s.push(3);
    s.push(4);
    s.push(5);

    cout << "Popped: " << s.pop() << endl;
    cout << "Top element: " << s.peek() << endl;
    cout << "Top element: " << s.peek() << endl;
    cout << "Popped: " << s.pop() << endl;

    cout << "Count after pops: " << s.getCount() << endl;

    return 0;
}
