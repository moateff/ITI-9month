#include <iostream>
using namespace std;

class Singleton {
public:
    static Singleton& getInstance() {
        static Singleton instance;   // Created once, thread-safe
        return instance;
    }

private:
    Singleton() {}
    Singleton(const Singleton&) = delete;
    Singleton& operator=(const Singleton&) = delete;
};

int main() {
    Singleton& s1 = Singleton::getInstance();
    Singleton& s2 = Singleton::getInstance();

    if (&s1 == &s2) {
        cout << "Both pointers point to the same instance." << endl;
    } else {
        cout << "Different instances exist." << endl;
    }

    return 0;
}