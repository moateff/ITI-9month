#include <iostream>
#include <cmath>
#include <cstring>

using namespace std;

class Complex {
private:
    double real;
    double imag;

public:
    Complex() : real(0), imag(0) {}
    Complex(double _real, double _imag) : real(_real), imag(_imag) {}
    Complex(double _real) : real(_real), imag(0) {}
    Complex(const Complex &c) : real(c.real), imag(c.imag) {}
    ~Complex() {}

    void setReal(double _real) { real = _real; }
    void setImag(double _imag) { imag = _imag; }

    double getReal() const { return real; }
    double getImag() const { return imag; }

    // operator overloading
    // complex+complex
    Complex operator+(const Complex &c) const {
        return Complex(real + c.real, imag + c.imag);
    }

    // complex–complex
    Complex operator-(const Complex &c) const {
        return Complex(real - c.real, imag - c.imag);
    }

    // complex+int
    Complex operator+(int i) const {
        return Complex(real + i, imag);
    }

    // complex–int
    Complex operator-(int i) const {
        return Complex(real - i, imag);
    }

    // int+complex
    friend Complex operator+(int i, const Complex &c) {
        return Complex(i + c.real, c.imag);
    }

    // int–complex
    friend Complex operator-(int i, const Complex &c) {
        return Complex(i - c.real, c.imag);
    }

    // complex+=complex
    Complex& operator+=(const Complex &c) {
        real += c.real;
        imag += c.imag;
        return *this;
    }

    // complex-=complex
    Complex& operator-=(const Complex &c) {
        real -= c.real;
        imag -= c.imag;
        return *this;
    }

    // complex+=int
    Complex& operator+=(int i) {
        real += i;
        return *this;
    }

    // complex-=complex
    Complex& operator-=(int i) {
        real -= i;
        return *this;
    }

    // --complex (pre-decrement)
    Complex& operator--() {
        --real;
        --imag;
        return *this;
    }

    // complex (post-decrement)
    Complex operator--(int) {
        Complex temp(*this);
        real--;
        imag--;
        return temp;
    }

    double magnitude() const {
        return sqrt(real * real + imag * imag);
    }

    // complex==complex
    bool operator==(const Complex &c) const {
        return real == c.real && imag == c.imag;
    }

    // complex!=complex
    bool operator!=(const Complex &c) const {
        return !(*this == c);
    }

    // complex<complex
    bool operator<(const Complex &c) const {
        return magnitude() < c.magnitude();
    }

    // complex<=complex
    bool operator<=(const Complex &c) const {
        return magnitude() <= c.magnitude();
    }

    // complex>complex
    bool operator>(const Complex &c) const {
        return magnitude() > c.magnitude();
    }

    // complex>=complex
    bool operator>=(const Complex &c) const {
        return magnitude() >= c.magnitude();
    }

    // (int)complex
    operator int() const {
        return (int)magnitude();
    }

    // (char*)complex
    operator char*() const {
        char* buffer = new char[50];
        
        if (real == 0 && imag == 0)
            sprintf(buffer, "0");
        else if (real == 0)
            sprintf(buffer, "%gi", imag);
        else if (imag == 0)
            sprintf(buffer, "%g", real);
        else if (imag > 0)
            sprintf(buffer, "%g + %gi", real, imag);
        else
            sprintf(buffer, "%g - %gi", real, -imag);

        return buffer;
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
    Complex c1;            // default constructor (0 + 0i)
    Complex c2(3, 4);      // 3 + 4i
    Complex c3(5);         // 5 + 0i
    Complex c4(c2);        // copy of c2

    cout << "c1 = "; c1.print();
    cout << "c2 = "; c2.print();
    cout << "c3 = "; c3.print();
    cout << "c4 = "; c4.print();
    cout << endl;

    // Addition and subtraction
    cout << "c2 + c3 = "; (c2 + c3).print();
    cout << "c2 - c3 = "; (c2 - c3).print();
    cout << "c2 + 5 = "; (c2 + 5).print();
    cout << "c2 - 2 = "; (c2 - 2).print();
    cout << "7 + c2 = "; (7 + c2).print();
    cout << "10 - c2 = "; (10 - c2).print();
    cout << endl;

    // += and -= with Complex
    Complex t1(3, 3);
    Complex t2(1, 2);

    t1 += t2;
    cout << "t1 += t2 = "; t1.print();

    t1 -= t2;
    cout << "t1 -= t2 = "; t1.print();
    cout << endl;

    // += and -= with int
    Complex t3(4, 5);
    t3 += 3;
    cout << "t3 += 3 = "; t3.print();

    t3 -= 2;
    cout << "t3 -= 2 = "; t3.print();
    cout << endl;

    // Pre-decrement
    Complex p1(7, 8);
    --p1;
    cout << "--p1 = "; p1.print();

    // Post-decrement
    Complex p2(10, 10);
    Complex old = p2--;
    cout << "p2-- (returned old) = "; old.print();
    cout << "p2 after p2-- = "; p2.print();
    cout << endl;

    // Comparisons
    Complex a(3,4), b(5,1);

    cout << "Comparisons (by magnitude):\n";
    cout << "a = "; a.print();
    cout << "b = "; b.print();

    cout << "a == b? " << (a == b ? "true" : "false") << endl;
    cout << "a != b? " << (a != b ? "true" : "false") << endl;
    cout << "a < b?  " << (a < b  ? "true" : "false") << endl;
    cout << "a <= b? " << (a <= b ? "true" : "false") << endl;
    cout << "a > b?  " << (a > b  ? "true" : "false") << endl;
    cout << "a >= b? " << (a >= b ? "true" : "false") << endl;
    cout << endl;

    // Casting to int
    cout << "(int)c2 = " << (int)c2 << endl;

    // Casting to char*
    char* str = (char*)c2;
    cout << "(char*)c2 = " << str << endl;
    delete[] str;   // free allocated memory
    cout << endl;

    return 0;
}
