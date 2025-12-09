#include <iostream>
#include "doublyList.cpp"
using namespace std;

class Queue : private DoublyList{
public:
    void enqueue(Employee emp){
        insertAtTail(emp);
    }

    Employee dequeue(){
        Employee emp = head->data;
        delete head;
        head = head->next;
        return emp;
    }

    Employee peek(){
        return head->data;
    }
};

int main() {
    Queue queue;

    // Create some employees
    Employee e1 = {1, "Ali", 25, 5000};
    Employee e2 = {2, "Sara", 30, 7000};
    Employee e3 = {3, "Omar", 28, 6000};

    // Test enqueue
    queue.enqueue(e1);
    queue.enqueue(e2);
    queue.enqueue(e3);

    cout << "Front employee (peek): " << queue.peek().name << endl;

    // Test dequeue
    cout << "Dequeued employee: " << queue.dequeue().name << endl;
    cout << "New front employee (peek): " << queue.peek().name << endl;

    return 0;
}