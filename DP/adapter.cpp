#include <iostream>
using namespace std;

// Existing class with incompatible interface (Adaptee)
class OldPrinter {
public:
    void oldPrint() {
        cout << "Printing using the old printer..." << endl;
    }
};

// Adapter WITHOUT inheritance
class PrinterAdapter {
private:
    OldPrinter* oldPrinter;  // composition

public:
    PrinterAdapter(OldPrinter* p) : oldPrinter(p) {}

    // This function is what the client expects
    void print() {
        oldPrinter->oldPrint();  // translate call
    }
};

// Client code uses ONLY the adapter
int main() {
    OldPrinter legacy;
    PrinterAdapter adapter(&legacy);

    adapter.print();

    return 0;
}
