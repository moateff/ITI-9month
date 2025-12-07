#include <iostream>
using namespace std;

class Complex {
private:
    double real;
    double imag;

public:
    Complex() : real(0), imag(0) {
        cout << "Default constructor called" << endl;
    }   

    Complex(double r, double i) : real(r), imag(i) {
        cout << "Parameterized constructor called" << endl;
    } 

    Complex(double r) : real(r), imag(0) {
        cout << "Single parameter constructor called" << endl;
    }      

    ~Complex() {
        cout << "Destructor called" << endl; 
    }

    // Setters
    void setReal(double r) { real = r; }
    void setImag(double i) { imag = i; }

    // Getters
    double getReal() const { return real; }
    double getImag() const { return imag; }

    // Method to add two complex numbers
    Complex sum(const Complex c) const {
        Complex result;
        result.setReal(this->real + c.real);
        result.setImag(this->imag + c.imag);
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
};

int main() {
    Complex c1(3, 4), c2(-3, -4), c3(-2);

    Complex sum1 = c1.sum(c2);
    cout << "C1 + C2: "; sum1.print();

    Complex sum2 = c1.sum(c3);
    cout << "C1 + C3: "; sum2.print();

    return 0;
}
