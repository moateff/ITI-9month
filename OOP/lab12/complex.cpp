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

    Complex& operator+=(int i) {
        real += i;
        return *this;
    }

    Complex& operator-=(int i) {
        real -= i;
        return *this;
    }

    Complex& operator--() {
        --real;
        --imag;
        return *this;
    }

    Complex operator--(int) {
        Complex temp(*this);
        real--;
        imag--;
        return temp;
    }

    double magnitude() const {
        return sqrt(real * real + imag * imag);
    }

    bool operator==(const Complex &c) const {
        return real == c.real && imag == c.imag;
    }

    bool operator!=(const Complex &c) const {
        return !(*this == c);
    }

    bool operator<(const Complex &c) const {
        return magnitude() < c.magnitude();
    }

    bool operator<=(const Complex &c) const {
        return magnitude() <= c.magnitude();
    }

    bool operator>(const Complex &c) const {
        return magnitude() > c.magnitude();
    }

    bool operator>=(const Complex &c) const {
        return magnitude() >= c.magnitude();
    }

    operator int() const {
        return (int)magnitude();
    }

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

    // ostream<<complex 
    friend ostream& operator<<(ostream& out, const Complex& c) {
        if (c.real == 0 && c.imag == 0)
            out << "0";
        else if (c.real == 0)
            out << c.imag << "i";
        else if (c.imag == 0)
            out << c.real;
        else if (c.imag > 0)
            out << c.real << " + " << c.imag << "i";
        else
            out << c.real << " - " << -c.imag << "i";

        return out;
    }

    // istream>>complex
    friend istream& operator>>(istream& in, Complex& c) {
        in >> c.real >> c.imag;
        return in;
    }

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
    cout << "Example of << operator: \n";
    Complex outTest(6, -2);
    cout << "outTest = " << outTest << endl;

    cout << "Example of >> operator: \n";
    Complex inTest;
    cout << "Enter a complex number (format: real imag): ";
    cin >> inTest;
    cout << "You entered: " << inTest << endl;

    return 0;
}
