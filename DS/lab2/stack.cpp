#include <iostream>
#include "doublyList.cpp"
using namespace std;

class Stack : private DoublyList{
public:
    void push(Employee emp){
        insertAtHead(emp);
    }
    
    Employee pop(){
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
    Stack stack;

    // Create some employees
    Employee e1 = {1, "Ali", 25, 5000};
    Employee e2 = {2, "Sara", 30, 7000};
    Employee e3 = {3, "Omar", 28, 6000};

    // Test push
    stack.push(e1);
    stack.push(e2);
    stack.push(e3);

    cout << "Top employee (peek): " << stack.peek().name << endl;

    // Test pop
    cout << "Popped employee: " << stack.pop().name << endl;
    cout << "New top employee (peek): " << stack.peek().name << endl;

    return 0;
}