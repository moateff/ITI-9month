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

    Complex(double _real, double _imag) : real(_real), imag(_imag) {
        cout << "Parameterized constructor called" << endl;
    } 

    Complex(double _real) : real(_real), imag(0) {
        cout << "Single parameter constructor called" << endl;
    }      

    Complex(const Complex &c) : real(c.real), imag(c.imag) {
        cout << "Copy constructor called" << endl;
    }

    ~Complex() {
        cout << "Destructor called" << endl; 
    }

    // Setters
    void setReal(double _real) { real = _real; }
    void setImag(double _imag) { imag = _imag; }

    // Getters
    double getReal() const { return real; }
    double getImag() const { return imag; }
    
    // Method to add two complex numbers
    // Pass by value
    Complex sumByValue(Complex c) const {
        return Complex(real + c.real, imag + c.imag);
    }

    // Pass by reference
    Complex sumByReference(const Complex &c) const {
        return Complex(real + c.real, imag + c.imag);
    }

    Complex operator+(const Complex &c) const {
        return Complex(real + c.real, imag + c.imag);
    }

    Complex operator-(const Complex &c) const {
        return Complex(real - c.real, imag - c.imag);
    }

    Complex operator+(int i) const {
        return Complex(real + i, imag);
    }

    Complex operator-(int i) const {
        return Complex(real - i, imag);
    }

    friend Complex operator+(int i, const Complex &c) {
        return Complex(i + c.real, c.imag);
    }

    friend Complex operator-(int i, const Complex &c) {
        return Complex(i - c.real, c.imag);
    }

    Complex& operator+=(const Complex &c) {
        real += c.real;
        imag += c.imag;
        return *this;
    }

    Complex& operator-=(const Complex &c) {
        real -= c.real;
        imag -= c.imag;
        return *this;
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
    Complex c1;           
    Complex c2(3, 4);     
    Complex c3(5);       
    Complex c4(c2);      

    cout << "c1 = "; c1.print();
    cout << "c2 = "; c2.print();
    cout << "c3 = "; c3.print();
    cout << "c4 = "; c4.print();

    Complex sv = c2.sumByValue(c3);
    cout << "c2.sumByValue(c3) = "; sv.print();

    Complex sr = c2.sumByReference(c3);
    cout << "c2.sumByReference(c3) = "; sr.print();

    Complex add = c2 + c3;
    cout << "c2 + c3 = "; add.print();

    Complex sub = c2 - c3;
    cout << "c2 - c3 = "; sub.print();

    Complex addInt = c2 + 5;
    cout << "c2 + 5 = "; addInt.print();

    Complex subInt = c2 - 2;
    cout << "c2 - 2 = "; subInt.print();

    Complex intAdd = 7 + c2;
    cout << "7 + c2 = "; intAdd.print();

    Complex intSub = 10 - c2;
    cout << "10 - c2 = "; intSub.print();

    Complex t1(3, 3);
    Complex t2(1, 2);

    t1 += t2;
    cout << "t1 += t2 = "; t1.print();

    t1 -= t2;
    cout << "t1 -= t2 = "; t1.print();

    return 0;
}

