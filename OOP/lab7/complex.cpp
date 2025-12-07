#include <iostream>
using namespace std;

class Complex {
private:
    double real;
    double imag;

public:
    // Setters
    void setReal(double r) { real = r; }
    void setImag(double i) { imag = i; }

    // Getters
    double getReal() const { return real; }
    double getImag() const { return imag; }

    // Method to add two complex numbers
    Complex sum(const Complex &other) const {
        Complex result;
        result.real = this->real + other.real;
        result.imag = this->imag + other.imag;
        return result;
    }

    // Print method
    void print() const {
        if (real == 0 && imag == 0) {
            cout << "0";
        } else if (real == 0) {
            cout << imag << "i";
        } else if (imag == 0) {
            cout << real;
        } else {
            cout << real;
            if (imag > 0) cout << " + " << imag << "i";
            else cout << " - " << -imag << "i";
        }
        cout << endl;
    }

    // Subtract function (friend to access private members)
    // friend Complex subtract(const Complex &c1, const Complex &c2);
};

Complex subtract(const Complex &c1, const Complex &c2) {
    Complex result;
    result.setReal(c1.getReal() - c2.getReal());
    result.setImag(c1.getImag() - c2.getImag());
    return result;
}

int main() {
    Complex c1, c2, c3;

    c1.setReal(3); c1.setImag(4);
    c2.setReal(-3); c2.setImag(-4);
    c3.setReal(0); c3.setImag(-2);

    cout << "C1: "; c1.print();
    cout << "C2: "; c2.print();
    cout << "C3: "; c3.print();

    Complex sum1 = c1.sum(c2);
    cout << "C1 + C2: "; sum1.print();

    Complex sum2 = c1.sum(c3);
    cout << "C1 + C3: "; sum2.print();

    c1.setReal(5); c1.setImag(7);
    c2.setReal(2); c2.setImag(3);

    cout << "C1: "; c1.print();
    cout << "C2: "; c2.print();

    c3 = subtract(c1, c2);
    cout << "C1 - C2: "; c3.print();

    return 0;
}